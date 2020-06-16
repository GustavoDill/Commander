using Row = System.Windows.Forms.DataGridViewRow;
namespace CommanderServer.Commands
{
    public class ClientInfo
    {
        public ClientInfo(Row row)
        {
            ClientIp = row.Cells[0].Value as string;
            ClientPort = ushort.Parse(row.Cells[1].Value.ToString());
            ClientPCName = row.Cells[2].Value as string;
        }
        public ClientInfo(string clientIp, ushort clientPort, string clientPCName)
        {
            ClientIp = clientIp;
            ClientPort = clientPort;
            ClientPCName = clientPCName;
        }

        public string ClientIp { get; }
        public ushort ClientPort { get; }
        public string ClientPCName { get; }
    }
}
