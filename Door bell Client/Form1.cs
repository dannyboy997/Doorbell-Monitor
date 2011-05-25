using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Doorbell_Client
{
    public partial class FormClient : Form
    {
        Thread NSthread = new Thread(new ThreadStart(TCPServer.ServerLoop));

        public FormClient()
        {
            InitializeComponent();
            LoadAllSettings();
            Minimize();
            try
            {
                NSthread.Name = "Doorbell Monitor TCP";
                NSthread.IsBackground = true;
                NSthread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void LoadAllSettings()
        {
            textBoxSettingsPort.Text = Settings.GetTCPPortNumber().ToString();
            checkBoxLaunchOnStart.Checked = Settings.GetOnStart();
        }

        private void SaveAllSettings()
        {
            Settings.SaveTCPPortNumber(Int32.Parse(textBoxSettingsPort.Text));
            Settings.SaveOnStart(checkBoxLaunchOnStart.Checked);
        }

        private void CheckStatus_Tick(object sender, EventArgs e)
        {
            string returnData = TCPServer.GetStatus();
            if (returnData == null)
            {
                textBoxStatusLog.Text = "";
            }
            else
            {
                textBoxStatusLog.Text = returnData;
                notifyIcon1.ShowBalloonTip(2000, "Doorbell", returnData + "\n" + DateTime.Now.ToString(), ToolTipIcon.Info);
                SoundPlayer doorbellchime = new SoundPlayer("C:\\Program Files\\Doorbell Monitor\\Client\\chimes.wav");
                doorbellchime.Play();
                TCPServer.ClearStatus();
            }
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

        private void FormClient_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                Minimize();
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            SaveAllSettings();
        }
    }
}
