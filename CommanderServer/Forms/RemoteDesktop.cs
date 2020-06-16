using FormApp.Dialogs;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CommanderServer.Forms
{
    public partial class RemoteDesktop : Form
    {
        public RemoteDesktop()
        {
            InitializeComponent();
        }
        [Browsable(false)]
        public Socket ClientSocket
        {
            get { return RemoteDesktopObject.ClientConnectionSocket; }
            set { SetClient(new TcpClient() { Client = value }); }
        }

        public RemoteDesktopServer RemoteDesktopObject { get => remoteDesktopServer1; }
        public void SetClient(TcpClient client)
        {
            remoteDesktopServer1.SetClient(client);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            remoteDesktopServer1.Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            remoteDesktopServer1.Stop();
        }

        private void RemoteDesktop_Load(object sender, EventArgs e)
        {
            remoteDesktopServer1.Focus();
        }

        private void RemoteDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            remoteDesktopServer1.SendKeyDown(e);
        }
    }
}
