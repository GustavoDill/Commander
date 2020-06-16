using CSharpExtendedCommands.Data.SimpleJSON;
using CSharpExtendedCommands.DataTypeExtensions.Json;
using System.IO;

namespace CommanderServer.Config
{
    public static class Settings
    {
        public static string MainWindowTitle { get; set; }
        public static int EnableDisableDelay { get; set; }
        public static ushort ServerPort { get; set; }
        public static string File => "settings.json";

        public static void LoadDefault()
        {
            MainWindowTitle = "Server";
            EnableDisableDelay = 4;
            ServerPort = 54782;
        }

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
            LoadDefault();
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
