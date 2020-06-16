using CommanderServer.Config;
using CSharpExtendedCommands.Data;
using FormApp.Dialogs;
using System;
using System.IO;
using System.Net;

namespace Commander
{
    partial class Program
    {
        static CommanderClient client;
        static CommandExecutor executor;
        static RemoteDesktopClient desktop;
        static void Main(string[] args)
        {
            //Console.WriteLine(Settings.EIP("192.168.0.101"));
            //Console.ReadKey();
            if (!File.Exists(Settings.File))
            {
                Settings.LoadDefault();
                Settings.SaveJSON(Settings.File);
            }
            else
                Settings.LoadJSON(Settings.File);
            if (!File.Exists(AutoIt.AutoItX_DLLImport.AutoIt86))
                Resource.Export("Commander.AutoIt.AutoItX3.dll", AutoIt.AutoItX_DLLImport.AutoIt86);
            if (!File.Exists(AutoIt.AutoItX_DLLImport.AutoIt64))
                Resource.Export("Commander.AutoIt.AutoItX3_x64.dll", AutoIt.AutoItX_DLLImport.AutoIt64);
            client = new CommanderClient(IPAddress.Parse(Settings.ServerIp), Settings.ServerPort);
            if (Settings.ConnectionRetries >= 1)
            {
                bool flag = false;
                for (int i = 0; i < Settings.ConnectionRetries; i++)
                    try { client.Connect(); flag = client.Connected; break; } catch { ResetCursor(); Console.WriteLine(string.Format("Failed to connect to server! Attempt {0}/{1}", i + 1, Settings.ConnectionRetries)); }
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("Failed to connect to server! Press any key to exit...", Settings.ConnectionRetries, Settings.ConnectionRetries));
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }
            else
            {
                bool flag = false;
                int i = 1;
                while (!flag)
                {
                    try { client.Connect(); flag = client.Connected; break; } catch { ResetCursor(); Console.WriteLine(string.Format("Failed to connect to server! Attempt {0}/{1}", i, "*")); i++; }
                }
            }
            Console.WriteLine("Connected");
            desktop = new RemoteDesktopClient(true);
            desktop.EventHandler = new RemoteDesktopClient.RemoteDesktopEventHandler();
            desktop.EventHandler.MouseMove = Commands.Operations.MouseMove;
            desktop.EventHandler.MouseClick = Commands.Operations.MouseClick;
            desktop.EventHandler.MouseDown += Commands.Operations.MouseDown;
            desktop.EventHandler.MouseUp += Commands.Operations.MouseUp;
            desktop.EventHandler.MouseDoubleClick += Commands.Operations.MouseDoubleClick;
            desktop.EventHandler.KeyDown += Commands.Operations.KeyDown;
            desktop.Initialize();
            desktop.SetClient(new System.Net.Sockets.TcpClient() { Client = client.ClientSocket });
            executor = new CommandExecutor(client);
            StartReceiveingCommands();
            desktop.StartStream();
            while (true)
            {
                System.Console.Write(">");
                var request = System.Console.ReadLine();
                if (request == "exit")
                {
                    if (client.Connected)
                        client.Disconnect();
                    System.Environment.Exit(0);
                }
                else
                {
                   // client.SendToStream(request);
                    //try { System.Console.WriteLine(client.ReceivePackage().ToString()); } catch { Console.WriteLine("DISCONNECTED"); Thread.Sleep(750); Environment.Exit(2); }
                }
            }
        }
        static void ResetCursor()
        {
            SetCursorPos(0, 0);
        }
        static void SetCursorPos(int x = -1, int y = -1)
        {
            if (x != -1)
                Console.CursorLeft = x;
            if (y != -1)
                Console.CursorTop = y;
        }
    }
}
