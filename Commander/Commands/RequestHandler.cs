using CSharpExtendedCommands.Code;
using CSharpExtendedCommands.Data.Cryptography;
using CSharpExtendedCommands.Data.SimpleJSON;
using CSharpExtendedCommands.Info;
using CSharpExtendedCommands.Web.Communication;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Commander
{
    partial class Program
    {
        public static void StartReceiveingCommands()
        {
            new Thread(HandleRequest).Start();
        }
        static void Operation(object[] args)
        {
            if (args.Length == 0)
                return;
            if (desktop.EventHandler.CheckEvents(args))
                desktop.EventHandler.InvokeHandler(args);
            else if (args[1] is Action || args[1] is Action<object>)
            { InvokeAction(args); return; }

        }

        static void InvokeAction(object[] args)
        {
            if (args[1] is Action<object> && args.Length > 2)
                ((Action<object>)args[1]).Invoke(args[2]);
            else if (args[1] is Action)
                ((Action)args[1]).Invoke();
        }
        public static void HandleRequest()
        {
            try
            {
                while (true)
                {
                    var pkg = client.ReceiveFromStream();
                    if (((object[])pkg)[0].ToString() == "MouseClick")
                        new Action(() => { }).Invoke();
                    var str = "";
                    if (pkg is string)
                    {
                        str = pkg.ToString();
                        if (str == "COMMAND_DISCONNECT")
                        {
                            Console.Clear();
                            desktop.Shutdown();
                            client.Disconnect();
                            Console.WriteLine("CONNECTION TERMINATED BY SERVER");
                            Thread.Sleep(750);
                            Environment.Exit(0);
                        }
                        else if (str == "COMMAND_RESTART")
                        {
                            Console.Clear();
                            Console.Write("RESTARTING CONNECTION...");
                            client.Restart();
                            Console.WriteLine("\tOK");
                            Console.Write(">");
                        }
                        else
                            Console.WriteLine(str);
                        goto jmp;
                    }
                    else
                    {
                        if (pkg is object[])
                        {
                            Operation((object[])pkg);
                        }
                    }
                jmp:;
                }
            }
            catch { }
        }
        public static string DecryptRequest(TcpPackage pkg)
        {
            return new XORAlgorithm().Decrypt(pkg.ToString(), ComputerInfo.Name);
        }
    }
    public class CommandExecutor
    {
        public CommanderClient Client { get; set; }
        public CommandExecutor(CommanderClient client)
        {
            Client = client;
        }
        private MethodInfo GetMethod(string name)
        {
            return typeof(CommandExecutor).GetMethod(name);
        }
        private MethodInfo this[string name] => GetMethod(name);
        public void Execute(string request)
        {
            JSONNode json = JSON.Parse(request);
            var m = this[json["ExecuteMethod"].Value];
            if (json["ExecuteMethod"].Value == "ExecuteScript")
            {
                var script = Client.ReceivePackage(2048);
                Compile.CSharpSourceCode(script, "v4.0", "C:\\script.exe", Compile.GetDefaultUsedAssemblies, out string output);
                Process.Start("C:\\script.exe");
            }
            else if (m != null)
            {
                Console.CursorLeft = 0;
                Console.WriteLine("SERVER COMMAND: " + m.Name);
                Console.Write(">");
                m.Invoke(this, new object[] { json });
            }
        }
        public void OpenWebPage(JSONNode request)
        {
            var parms = request["Parameters"];
            var page = parms["PageUrl"].Value;
            var navigator = parms["Navigator"].Value;
            if (navigator == null)
                navigator = "iexplore.exe";
            Process.Start(navigator, page);
        }
    }
}
