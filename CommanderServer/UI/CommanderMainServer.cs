using CommanderServer.Commands;
using CSharpExtendedCommands.Web.Communication;
using System.Windows.Forms;

namespace CommanderServer.UI
{
    public static class CommanderMainServer
    {
        public static void FillOrUpdateGrid(this TCPServer server)
        {
            //clientsView.Rows.Clear();
            //foreach (var client in server.ConnectedClients)
            //    clientsView.Rows.Add(client.Ip.ToString(), client.Port.ToString(), R);
        }
        public static string RequestClientInfo(this TCPClient client)
        {
            client.SendPackage("REQUEST-INFO");
            var info = client.ReceivePackage();
            return info.ToString();
        }
        public static ClientInfo AddClientView(this TCPClient client)
        {
            var info = new ClientInfo(client.Ip.ToString(), ushort.Parse(client.Port.ToString()), client.RequestClientInfo());
            clientsView.Rows.Add(info.ClientIp, info.ClientPort.ToString(), info.ClientPCName);
            return info;
        }
        public static void RemoveClientView(this TCPClient client)
        {
            for (int i = 0; i < clientsView.Rows.Count; i++)
            {
                var r = clientsView.Rows[i];
                var ip = r.Cells[0].Value.ToString();
                var port = r.Cells[1].Value.ToString();
                var name = r.Cells[2].Value.ToString();
                if (ip == client.Ip.ToString() && port == client.Port.ToString())
                { clientsView.Rows.RemoveAt(i); break; }
            }
        }
        public static DataGridView clientsView;
        public static void Shutdown(this TCPServer server, bool reuseSocket)
        {
            if (reuseSocket)
            {
                foreach (var client in server.ConnectedClients)
                    server.DisconnectClient(client, "Server shutdown.");
            }
            else
                server.Shutdown();
        }

    }
}
