using CSharpExtendedCommands.Info;
using CSharpExtendedCommands.Web.Communication;
using System;
using System.Net;
using System.Threading;

namespace Commander
{
    public class CommanderClient : TCPClient
    {
        public CommanderClient(IPAddress ip, ushort port)
        {
            Ip = ip;
            Port = port;
        }
        public override void Connect()
        {
            base.Connect();
            var pkg = base.ReceivePackage();
            if (pkg == "REQUEST-INFO")
                SendPackage(ComputerInfo.Name);
        }
        public void Restart()
        {
            SendPackage("Disconnect");
            ClientSocket.Disconnect(true);
            Thread.Sleep(250);
            ClientSocket.BeginConnect(Ip, Port, (IAsyncResult result) =>
            {
                ClientSocket.EndConnect(result);
                Thread.Sleep(1500);
                ReceivePackage();
                SendPackage(ComputerInfo.Name);
            }, null);
        }
        public override void Disconnect()
        {
            SendPackage("Disconnect");
            base.Disconnect();
        }
    }
}
