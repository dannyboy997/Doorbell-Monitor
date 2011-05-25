using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Doorbell_Server
{
    static class Settings
    {
        public static int[] buttonsPushed = new int[GetNumberButtons() * 2];

        static RegistryKey startApp = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        const string SETTINGSTCPPORT = "<PORT>";
        const string SETTINGSLPT1OUT = "<LPT1OUT>";
        const string SETTINGSLPT1IN = "<LPT1IN>";
        const string SETTINGSLPT2OUT = "<LPT2OUT>";
        const string SETTINGSLPT2IN = "<LPT2IN>";
        const string SETTINGSLPT3OUT = "<LPT3OUT>";
        const string SETTINGSLPT3IN = "<LPT3IN>";
        const string SETTINGSTIMEOUT = "<FILETIMEOUT>";

        const string BUTTONNAME = "<NAME>";
        const string BUTTONPORT = "<PORT>";
        const string BUTTONPIN = "<PIN>";
        const string BUTTONOPEN = "<OPEN>";

        const string SETTINGSFILE = "settings.conf";
        const string SETTINGSHOSTS = "clientlist.conf";
        const string BUTTONFOLDER = "buttons";
        const string SETTINGSLOG = "pushed.log";
        const string SETTINGSTRANSFER = "transfer.txt";

        private static int TMPBUTTONNUMBER = 0;
        private static string[] TEMPBUTTONSFILE = new string[15];
        private static string TEMPSETTINGS = null;

        const string DEFAULTSETTINGS = SETTINGSTCPPORT + "5530" + SETTINGSTCPPORT + SETTINGSLPT1OUT + "888" + SETTINGSLPT1OUT +
            SETTINGSLPT1IN + "889" + SETTINGSLPT1IN + SETTINGSTIMEOUT + "3" + SETTINGSTIMEOUT;

        public static string runPath = "C:\\Program Files\\Doorbell Monitor\\Server\\";

        private static string GetSettingsFile()
        {
            if (TEMPSETTINGS == null)
            {
                if (File.Exists(SETTINGSFILE))
                {
                    string set = File.ReadAllText(runPath + SETTINGSFILE);
                    TEMPSETTINGS = set;
                    return (set);
                }
                else
                {
                    File.WriteAllText(runPath + SETTINGSFILE, DEFAULTSETTINGS);
                    return (DEFAULTSETTINGS);
                }
            }
            else
            {
                return (TEMPSETTINGS);
            }
        }

        public static void WriteTransfer(string data)
        {
            File.WriteAllText(runPath + SETTINGSTRANSFER, data);
        }

        public static void DeleteTransfer()
        {
            if(File.Exists(runPath + SETTINGSTRANSFER))
            {
                if (File.GetLastWriteTime(runPath  + SETTINGSTRANSFER) < DateTime.Now.AddSeconds(GetTransferTimeout()))
                {
                    try
                    {
                        File.WriteAllText(runPath + SETTINGSTRANSFER, null);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        public static void SetLog(string l)
        {
            File.AppendAllText(runPath + SETTINGSLOG, l + "\n");
        }

        public static string GetLog()
        {
            try
            {
                return (File.ReadAllText(runPath + SETTINGSLOG));
            }
            catch (Exception e)
            {
                return (null);
            }
        }

        public static string GetHost(int index)
        {
            string content = File.ReadAllText(runPath + SETTINGSHOSTS);
            string ret = null;

            for(int i = 0; i <= index; i++)
            {
                try
                {
                    ret = content.Substring(0, content.IndexOf(","));
                    content = content.Substring(ret.Length + 1, content.Length - ret.Length - 1);
                }
                catch (Exception e)
                {
                    return (null);
                }
            }
            return(ret);
        }

        public static void SaveOnStart(bool t)
        {
            string path = "\"" + runPath + "\\Doorbell Server.exe\"";
            if (t)
            {
                startApp.SetValue("Doorbell Server", path);
            }
            else
            {
                startApp.DeleteValue("Doorbell Server", false);
            }
        }

        public static bool GetOnStart()
        {
            if (startApp.GetValue("Doorbell Server", null) == null)
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
            return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSTCPPORT)));
        }

        public static int GetTransferTimeout()
        {
            return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSTIMEOUT)));
        }

        public static int GetLPTPortNumber(int port,bool input)
        {
            if (input)
            {
                switch (port)
                {
                    case 1:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT1IN)));
                    case 2:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT2IN)));
                    case 3:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT3IN)));
                    default:
                        return (0);
                }
            }
            else
            {
                switch (port)
                {
                    case 1:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT1OUT)));
                    case 2:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT2OUT)));
                    case 3:
                        return (Int32.Parse(GetSettingFromString(GetSettingsFile(), SETTINGSLPT3OUT)));
                    default:
                        return (0);
                }
            }  
        }

        public static int GetNumberButtons()
        {
            if (TMPBUTTONNUMBER == 0)
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(runPath + BUTTONFOLDER + "\\");
                try
                {
                    TMPBUTTONNUMBER = dir.GetFiles().Length;
                    return (dir.GetFiles().Length);
                }
                catch
                {
                    dir.Create();
                    return (0);
                }
            }
            else
            {
                return (TMPBUTTONNUMBER);
            }
        }

        public static bool GetButtonStatus(int btnnum)//returns true if state is differant than default
        {
            string file = null;
            string val = null;

            if (TEMPBUTTONSFILE[btnnum] == null)
            {
                file = runPath + BUTTONFOLDER + "\\" + btnnum + ".btn";
                if (File.Exists(file))
                {
                    val = File.ReadAllText(file);
                    TEMPBUTTONSFILE[btnnum] = val;
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                val = TEMPBUTTONSFILE[btnnum];
            }


            int status;
            if (IOControl.GetInputPinValue(Int32.Parse(GetSettingFromString(val, BUTTONPORT)), Int32.Parse(GetSettingFromString(val, BUTTONPIN))))
            {
                status = 1;
            }
            else
            {
                status = 0;
            }

            if (status == Int32.Parse(GetSettingFromString(val, BUTTONOPEN)))
            {
                return (false);
            }
            else
            {
                return (true);
            }


        }

        public static string GetButtonName(int btnnum)
        {
            string file = null;
            string val = null;


            if (TEMPBUTTONSFILE[btnnum] == null)
            {
                file = runPath+ BUTTONFOLDER + "/" + btnnum + ".btn";
                if (File.Exists(file))
                {
                    val = File.ReadAllText(file);
                    TEMPBUTTONSFILE[btnnum] = val;
                }
                else
                {
                    val = "No Button File";
                }
            }
            else
            {
                val = GetSettingFromString(TEMPBUTTONSFILE[btnnum], BUTTONNAME);
            }

            return (val);
        }

        private static string GetSettingFromString(string raw, string GetSetting)
        {
            try
            {
                string sub;
                sub = raw.Substring(raw.IndexOf(GetSetting));
                sub = sub.Remove(0, GetSetting.Length);
                string res = sub.Substring(0, sub.IndexOf(GetSetting));
                if (res == null)
                {
                    return ("null");
                }
                return (res);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.ToString());
                return ("null");
            }

        }
    }
}