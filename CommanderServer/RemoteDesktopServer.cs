using CSharpExtendedCommands.Info;
using CSharpExtendedCommands.Web.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FormApp.Dialogs
{
    public class RemoteDesktopServer : PictureBox
    {
        #region Fields
        TcpClient client;
        TcpListener listener;
        BinaryFormatter binaryFormatter;
        Thread ClientUpdater;
        NetworkStream mainStream;
        #endregion

        #region Properties
        public int Port { get; set; } = 54782;
        [Browsable(false), CompilerGenerated]
        public bool Enabled { get; private set; }
        [Browsable(false)]
        public Socket ClientConnectionSocket { get => client.Client; }
        #endregion

        #region Constructors
        public RemoteDesktopServer()
        {
            Constructor(54782);
        }

        void Constructor(int port)
        {
            Port = port;
            SizeMode = PictureBoxSizeMode.StretchImage;
            MouseDoubleClick += S_MouseDoubleClick;
            MouseClick += S_MouseClick;
            MouseDown += S_MouseDown;
            MouseUp += S_MouseUp;
        }
        void InvokeEvent(object[] msg)
        {
            if (SendManualMessage != null)
                SendManualMessage.Invoke(msg);
            else
                Send(msg);
        }
        public void SendKeyDown(KeyEventArgs e)
        {
            string k = "";
            if (Regex.IsMatch(e.KeyCode.ToString(), "F\\d{1,2}"))
                k = $"{{{e.KeyCode.ToString().ToUpper()}}}";
            else if (Regex.IsMatch(e.KeyCode.ToString(), "d[0-9]"))
                k = e.KeyCode.ToString().Substring(1);
            else if (e.KeyCode == Keys.Escape)
                k = "{ESC}";
            else if (e.KeyCode == Keys.Return)
                k = "{ENTER}";
            else if (e.KeyCode == Keys.Back)
                k = "{BS}";
            else if (e.KeyCode == Keys.Space)
                k = " ";
            else if (e.KeyCode == Keys.Up)
                k = "{UP}";
            else if (e.KeyCode == Keys.Left)
                k = "{LEFT}";
            else if (e.KeyCode == Keys.Down)
                k = "{DOWN}";
            else if (e.KeyCode == Keys.Right)
                k = "{RIGHT}";
            if (e.Shift && k == "")
                k = e.KeyCode.ToString().ToUpper();
            else if (k == "")
                k = e.KeyCode.ToString().ToLower();
            if (e.Shift)
                k = "+" + k;
            if (e.Alt)
                k += "%" + k;
            if (e.Control)
                k = "^" + k;
            InvokeEvent(new object[] { "KeyDown", k });
        }
        #region Events

        private void S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var args = MapMouseArgs(Size, DesktopImageSize, e);
            InvokeEvent(new object[] { "MouseDoubleClick", args.Button, args.Clicks, args.Location });
        }

        private void S_MouseDown(object sender, MouseEventArgs e)
        {
            var args = MapMouseArgs(Size, DesktopImageSize, e);
            InvokeEvent(new object[] { "MouseDown", args.Button, args.Location });
        }
        private void S_MouseUp(object sender, MouseEventArgs e)
        {
            var args = MapMouseArgs(Size, DesktopImageSize, e);
            InvokeEvent(new object[] { "MouseUp", args.Button, args.Location });
        }
        private void S_MouseMove(object sender, MouseEventArgs e)
        {
            var args = MapMouseArgs(Size, DesktopImageSize, e);
            InvokeEvent(new object[] { "MouseMove", args.Location });
        }

        private void S_MouseClick(object sender, MouseEventArgs e)
        {
            var args = MapMouseArgs(Size, DesktopImageSize, e);
            InvokeEvent(new object[] { "MouseClick", args.Button, args.Clicks, args.Location });
        }
        #endregion

        #endregion

        #region MouseMapping

        Point MapMousePosition(Point src, Point origin, Point value)
        {
            return MapMousePosition(new Size(src.X, src.Y), new Size(origin.X, origin.Y), value);
        }
        Point MapMousePosition(Size src, Size origin, Point value)
        {
            var t = src;
            var v = value;
            double pX = v.X * 100d / t.Width;
            double pY = v.Y * 100d / t.Height;
            double newX = origin.Width * (pX / 100d);
            double newY = origin.Height * (pY / 100d);
            return new Point((int)Math.Round(newX), (int)Math.Round(newY));
        }
        MouseEventArgs MapMouseArgs(Size src, Size origin, MouseEventArgs v)
        {
            var pos = MapMousePosition(src, origin, v.Location);
            return new MouseEventArgs(v.Button, v.Clicks, pos.X, pos.Y, v.Delta);
        }
        #endregion


        #region Initialization
        protected override void InitLayout()
        {
            base.InitLayout();
            Initialize();
        }
        public void Initialize()
        {
            listener = new TcpListener(Port);
            ClientUpdater = new Thread(OnClientUpdate);
            binaryFormatter = new BinaryFormatter();
        }
        #endregion

        TCPClient cs_tcp;
        public void SetClient(TcpClient client)
        {
            this.client = client;
        }
        private Size DesktopImageSize;
        public bool ManualHandling { get; set; } = false;
        #region ManualUpdating
        public void SetDesktopImage(Image img)
        {
            DesktopImageSize = img.Size;
            Image = img;
        }
        public delegate void MessageSenderHandler(object message);
        public event MessageSenderHandler SendManualMessage;
        #endregion
        void OnClientUpdate()
        {
            if (client == null)
            {
                client = listener.AcceptTcpClient();
                cs_tcp = new TCPClient(client);
            }
            while (client.Connected)
            {
                try
                {
                    if (!Enabled)
                        goto Jmp;
                    mainStream = client.GetStream();
                    var obj = binaryFormatter.Deserialize(mainStream);
                    if (obj != null)
                        OnClientDataReceived(obj);
                    Jmp:;
                }
                catch { }
            }
        }
        void OnClientDataReceived(object data)
        {
            if (data is Image)
                Image = (Image)data;
        }
        public void Send(object send)
        {
            //bool flag = Enabled;
            //if (Enabled)
            //    Enabled = false;
            Try(() => mainStream = client.GetStream());
            Try(() => binaryFormatter.Serialize(mainStream, send));
            //if (flag)
            //    Enabled = true;
        }

        public void Start()
        {
            if (Enabled)
                return;
            Enabled = true;
            if (ManualHandling)
                return;
            if (client is null)
                listener.Start();
            if (!ClientUpdater.IsAlive)
                ClientUpdater.Start();
        }
        public void Stop()
        {
            if (!Enabled)
                return;
            Enabled = false;
        }
        void Try(Action action) { try { action.Invoke(); } catch { } }
        public void Shutdown()
        {
            if (ClientUpdater.IsAlive)
                ClientUpdater.Abort();
            Try(() => listener.Server.Shutdown(SocketShutdown.Both));
            Try(() => listener.Server.Close());
            Try(() => listener.Server.Dispose());
            Try(() => client.Client.Shutdown(SocketShutdown.Both));
            Try(() => client.Client.Close());
            Try(() => client.Client.Dispose());
        }
    }
    public class RemoteDesktopClient : Component
    {
        #region EventHandler
        public RemoteDesktopEventHandler EventHandler { get; set; }
        public class RemoteDesktopEventHandler
        {
            public bool CheckEvents(object[] msg)
            {
                var evens = GetType().GetFields();
                foreach (var ev in evens)
                    if (ev.Name == msg[0].ToString())
                        return true;
                return false;
            }
            public void InvokeHandler(object[] msg)
            {
                InvokeHandler(msg[0].ToString(), msg);
            }
            public void InvokeHandler(string name, object[] msg)
            {
                var actionField = GetType().GetField(name).GetValue(this);
                if (actionField == null)
                    return;
                var prop = actionField.GetType().GetProperty("Method").GetValue(actionField);
                if (prop == null)
                    return;
                var f = (MethodInfo)prop;
                if (f == null)
                    return;
                var p = f.GetParameters();
                if (p.Length == 0)
                    f.Invoke(this, new object[] { });
                List<object> prms = new List<object>();
                for (int i = 1; i < msg.Length; i++)
                    prms.Add(Convert.ChangeType(msg[i], p[i - 1].ParameterType));
                f.Invoke(this, prms.ToArray());
            }
            public Action<Point> MouseMove;
            public Action<MouseButtons, Point> MouseDown;
            public Action<MouseButtons, Point> MouseUp;
            public Action<MouseButtons, int, Point> MouseClick;
            public Action<MouseButtons, int, Point> MouseDoubleClick;
            public Action<string> KeyDown;
        }
        #endregion

        #region Fields
        TcpClient client;
        NetworkStream mainStream;
        Thread ClientStreamer;
        Thread Receiver;
        bool desktopStreamDelay = false;
        private BinaryFormatter binaryFormatter;
        #endregion

        #region Properties
        private bool _canReceive;

        public bool CanReceive
        {
            get { return _canReceive; }
            set { if (!Enabled) _canReceive = value; }
        }

        public bool IsShutdown { get; private set; }
        public int Port { get; set; } = 54782;
        [Browsable(false)]
        public bool Enabled { get; private set; }
        [Browsable(false)]
        private IPAddress HostIp { get; set; } = IPAddress.Parse("127.0.0.1");//{ get { try { return IPAddress.Parse(Host); } catch { return null; } } }
        public string Host
        {
            get { return HostIp.ToString(); }
            set { try { HostIp = IPAddress.Parse(value); } catch { } }
        }
        public bool ManualHandling { get; set; }
        #endregion

        #region Constructors
        public RemoteDesktopClient() { }
        public RemoteDesktopClient(bool manual)
        {
            ManualHandling = manual;
        }
        public RemoteDesktopClient(string host, int port)
        {
            Constructor(host, port);
        }
        void Constructor(string host, int port)
        {
            HostIp = Dns.GetHostAddresses(host)[0];
            Port = port;
        }
        #endregion

        #region Initialialization
        public void Initialize()
        {
            binaryFormatter = new BinaryFormatter();
            ClientStreamer = new Thread(Stream);
            Receiver = new Thread(Receive);
            client = new TcpClient();
        }
        public void SetClient(TcpClient client)
        {
            this.client = client;
        }
        #endregion

        bool CheckMessage(object[] obj, string check)
        {
            if (!(obj.Length > 0))
                return false;
            if (!(obj[0] is string))
                return false;
            return obj[0].ToString() == check;
        }

        void InvokeMethod(object[] msg)
        {
            if (msg[1] is Action<object>)
                ((Action<object>)msg[1]).Invoke(msg[2]);
            else
                ((Action)msg[1]).Invoke();
        }

        void Receive()
        {
            while (client.Connected)
            {
                try
                {
                    mainStream = client.GetStream();
                    var obj = binaryFormatter.Deserialize(mainStream);
                    if (obj is Action)
                        ((Action)obj).Invoke();
                    if (obj is object[])
                        if (CheckMessage((object[])obj, "MethodInvoke"))
                            InvokeMethod((object[])obj);
                }
                catch { }
            }
        }

        public void Stream(object send)
        {
            while (client.Connected)
            {
                try
                {

                    mainStream = client.GetStream();
                    if (send != null)
                        binaryFormatter.Serialize(mainStream, send);
                    else if (Enabled)
                        binaryFormatter.Serialize(mainStream, ComputerInfo.Screenshot);
                }
                catch { }
                if (desktopStreamDelay)
                    Thread.Sleep(1);
            }
        }

        public void Shutdown()
        {
            StopStream();
            if (ClientStreamer.IsAlive)
                ClientStreamer.Abort();
            Try(() => client.Client.Shutdown(SocketShutdown.Both));
            Try(() => client.Client.Close());
            Try(() => client.Client.Dispose());
            IsShutdown = true;
        }

        void Try(Action action) { try { action.Invoke(); } catch { } }

        public void StartStream()
        {
            if (IsShutdown)
                throw new ObjectDisposedException("RemoteDesktop object already shutdown!");
            if (!client.Connected)
                client.Connect(Host, Port);
            if (!ClientStreamer.IsAlive)
                ClientStreamer.Start();
            if (CanReceive && !Receiver.IsAlive)
                Receiver.Start();
            Enabled = true;
        }
        public void StopStream()
        {
            if (!Enabled)
                return;
            Enabled = false;
        }
        public void StopReceiveing()
        {
            if (Receiver.IsAlive)
                Receiver.Abort();
        }
    }
}
