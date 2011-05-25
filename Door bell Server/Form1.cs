using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Doorbell_Server
{
    public partial class FormServer1 : Form
    {
        public FormServer1()
        {
            InitializeComponent();
            LoadAllSettings();
            Minimize();
        }

        private void LoadAllSettings()
        {
            checkBoxLaunchOnStart.Checked = Settings.GetOnStart();
        }

        private void SaveAllSettings()
        {
            Settings.SaveOnStart(checkBoxLaunchOnStart.Checked);
        }

        private void CheckStatusTimer_Tick(object sender, EventArgs e)
        {
            richTextBoxLog.Text = Settings.GetLog();
            for(int i = 0; i < Settings.GetNumberButtons(); i++)
            {
                if(Settings.GetButtonStatus(i + 1))
                {
                    int h = 0;
                    Settings.WriteTransfer(Settings.GetButtonName(i + 1));
                    Settings.SetLog(DateTime.Now.ToString() + " - " + Settings.GetButtonName(i + 1));

                    while(Settings.GetHost(h) != null)
                    {
                        TCPClient.SendData(Settings.GetHost(h), Settings.GetButtonName(i + 1));
                        h++;
                    }
                }
            }
            
            Settings.DeleteTransfer();
            
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        public void Minimize()
        {
            Hide();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            notifyIcon1.Visible = true;
        }

        public void Maximize(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            notifyIcon1.Visible = false;
        }

        private void FormServer1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Minimize();
            }
        }
    }
}
