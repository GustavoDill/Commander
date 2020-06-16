using CSharpExtendedCommands.Data.Cryptography;
using CSharpExtendedCommands.Data.SimpleJSON;
using CSharpExtendedCommands.DataTypeExtensions.Json;
using CSharpExtendedCommands.Info;
using System.IO;
using System.Text.RegularExpressions;

namespace CommanderServer.Config
{
    public static class Settings
    {
        public static int ConnectionRetries { get; set; }
        public static ushort ServerPort { get; set; }
        private static string _sip;
        public static string ServerIp
        {
            get { return _sip; }
            set { if (Regex.IsMatch(value, @"\d+\.\d+\.\d+\.") || Regex.IsMatch(value, @"\w+\.\w+\.\w+\.")) _sip = value; else _sip = new XORAlgorithm().Decrypt(new Base64Cryptor().MultiDecode(value, 2), ComputerInfo.Name); }
        }

        public static string File => "settings.json";

        public static void LoadDefault()
        {
            ConnectionRetries = 5;
            ServerPort = 54782;
            ServerIp = SIP;
        }
        public static string DIP(string p)
        {
            return new XORAlgorithm().Decrypt(new Base64Cryptor().MultiDecode(p, 2), "Ip_Encrypton_Key");
        }
        public static string EIP(string p)
        {
            return new Base64Cryptor().MultiEncode(new XORAlgorithm().Encrypt(p, "Ip_Encrypton_Key"), 2);
        }
        private static string SIP { get => EIP("127.0.0.1"); }
        public static void SaveJSON(string path)
        {
            JSONNode json = JSON.Parse("{}");
            foreach (var prop in typeof(Settings).GetProperties())
                if (prop.Name != "File")
                    json.AddTuple(prop.Name, prop.GetValue(null, null).ToString());
            var writer = new StreamWriter(path);
            writer.Write(json.Formatted());
            writer.Close();
        }
        public static void LoadJSON(string path)
        {
            ServerIp = "192.168.0.106";
            ServerPort = 54782;
            //if (!System.IO.File.Exists(path))
            //    return;
            //var reader = new StreamReader(path);
            //var json = JSON.Parse(reader.ReadToEnd());
            //reader.Close();
            //foreach (var prop in typeof(Settings).GetProperties())
            //    if (prop.Name != "File")
            //        prop.SetValue(null, Convert.ChangeType(json[prop.Name].Value, prop.PropertyType));
        }
    }
}