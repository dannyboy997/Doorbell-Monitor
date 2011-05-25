namespace Doorbell_Client
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.CheckStatus = new System.Windows.Forms.Timer(this.components);
            this.textBoxStatusLog = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.checkBoxLaunchOnStart = new System.Windows.Forms.CheckBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.textBoxSettingsPort = new System.Windows.Forms.TextBox();
            this.labelSettingsPort = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckStatus
            // 
            this.CheckStatus.Enabled = true;
            this.CheckStatus.Tick += new System.EventHandler(this.CheckStatus_Tick);
            // 
            // textBoxStatusLog
            // 
            this.textBoxStatusLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxStatusLog.Location = new System.Drawing.Point(3, 3);
            this.textBoxStatusLog.Multiline = true;
            this.textBoxStatusLog.Name = "textBoxStatusLog";
            this.textBoxStatusLog.ReadOnly = true;
            this.textBoxStatusLog.Size = new System.Drawing.Size(270, 196);
            this.textBoxStatusLog.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStatus);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 262);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.textBoxStatusLog);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(276, 236);
            this.tabPageStatus.TabIndex = 0;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.checkBoxLaunchOnStart);
            this.tabPageSettings.Controls.Add(this.buttonSaveSettings);
            this.tabPageSettings.Controls.Add(this.textBoxSettingsPort);
            this.tabPageSettings.Controls.Add(this.labelSettingsPort);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(276, 236);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxLaunchOnStart
            // 
            this.checkBoxLaunchOnStart.AutoSize = true;
            this.checkBoxLaunchOnStart.Location = new System.Drawing.Point(6, 58);
            this.checkBoxLaunchOnStart.Name = "checkBoxLaunchOnStart";
            this.checkBoxLaunchOnStart.Size = new System.Drawing.Size(161, 17);
            this.checkBoxLaunchOnStart.TabIndex = 8;
            this.checkBoxLaunchOnStart.Text = "Launch when Windows start";
            this.checkBoxLaunchOnStart.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(101, 205);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 4;
            this.buttonSaveSettings.Text = "Save Settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // textBoxSettingsPort
            // 
            this.textBoxSettingsPort.Location = new System.Drawing.Point(74, 32);
            this.textBoxSettingsPort.Name = "textBoxSettingsPort";
            this.textBoxSettingsPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxSettingsPort.TabIndex = 3;
            // 
            // labelSettingsPort
            // 
            this.labelSettingsPort.AutoSize = true;
            this.labelSettingsPort.Location = new System.Drawing.Point(3, 35);
            this.labelSettingsPort.Name = "labelSettingsPort";
            this.labelSettingsPort.Size = new System.Drawing.Size(66, 13);
            this.labelSettingsPort.TabIndex = 2;
            this.labelSettingsPort.Text = "Port Number";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Doorbell Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Maximize);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClient";
            this.Text = "Doorbell Client";
            this.Load += new System.EventHandler(this.FormClient_Resize);
            this.Resize += new System.EventHandler(this.FormClient_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPageStatus.ResumeLayout(false);
            this.tabPageStatus.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CheckStatus;
        private System.Windows.Forms.TextBox textBoxStatusLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox textBoxSettingsPort;
        private System.Windows.Forms.Label labelSettingsPort;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxLaunchOnStart;
    }
}

