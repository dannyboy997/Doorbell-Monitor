using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Doorbell_Client
{
    static class Settings
    {
        static RegistryKey regKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Doorbell Monitor Client");

        const string SETTINGSTCPPORT = "PORT";

        static RegistryKey startApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private static string TEMPTCPHOST = null;
        private static int TEMPTCPPORT = 0;

        public static string runPath = "C:\\Program Files\\Doorbell Monitor\\Client\\";

        public static void SaveOnStart(bool t)
        {
            string path = "\"" + runPath + "\\Doorbell Client.exe\"";
            if (t)
            {
                startApp.SetValue("Doorbell Client", path);
            }
            else
            {
                startApp.DeleteValue("Doorbell Client", false);
            }
        }

        public static bool GetOnStart()
        {
            if (startApp.GetValue("Doorbell Client", null) == null)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        public static int GetTCPPortNumber()
        {
            if (TEMPTCPPORT == 0)
            {
                Int32 port = (Int32)regKey.GetValue(SETTINGSTCPPORT, 5530);
                TEMPTCPPORT = port;
                return (port);
            }
            else
            {
                return (TEMPTCPPORT);
            }
        }

        public static void SaveTCPPortNumber(int port)
        {
            regKey.SetValue(SETTINGSTCPPORT, port);
            TEMPTCPPORT = port;
        }
    }
}