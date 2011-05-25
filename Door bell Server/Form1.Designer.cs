namespace Doorbell_Server
{
    partial class FormServer1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer1));
            this.CheckStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBoxLaunchOnStart = new System.Windows.Forms.CheckBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CheckStatusTimer
            // 
            this.CheckStatusTimer.Enabled = true;
            this.CheckStatusTimer.Interval = 20;
            this.CheckStatusTimer.Tick += new System.EventHandler(this.CheckStatusTimer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Doorbell Monitor Server";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Maximize);
            // 
            // checkBoxLaunchOnStart
            // 
            this.checkBoxLaunchOnStart.AutoSize = true;
            this.checkBoxLaunchOnStart.Location = new System.Drawing.Point(35, 233);
            this.checkBoxLaunchOnStart.Name = "checkBoxLaunchOnStart";
            this.checkBoxLaunchOnStart.Size = new System.Drawing.Size(161, 17);
            this.checkBoxLaunchOnStart.TabIndex = 9;
            this.checkBoxLaunchOnStart.Text = "Launch when Windows start";
            this.checkBoxLaunchOnStart.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(203, 233);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 8;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(284, 227);
            this.richTextBoxLog.TabIndex = 11;
            this.richTextBoxLog.Text = "";
            // 
            // FormServer1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.checkBoxLaunchOnStart);
            this.Controls.Add(this.buttonSaveSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServer1";
            this.Text = "Doorbell Server";
            this.Resize += new System.EventHandler(this.FormServer1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer CheckStatusTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox checkBoxLaunchOnStart;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}

