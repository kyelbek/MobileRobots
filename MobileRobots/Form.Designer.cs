namespace MobileRobots
{
    partial class Form
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.BTNConnect = new System.Windows.Forms.Button();
            this.BTNDisconnect = new System.Windows.Forms.Button();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.LogBOX = new System.Windows.Forms.TextBox();
            this.LED_G = new System.Windows.Forms.CheckBox();
            this.LED_R = new System.Windows.Forms.CheckBox();
            this.BatteryLevel = new System.Windows.Forms.ProgressBar();
            this.BTNLogClear = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.BTNSend = new System.Windows.Forms.Button();
            this.CMDBox = new System.Windows.Forms.TextBox();
            this.BTNIsConnected = new System.Windows.Forms.Button();
            this.Eng_R = new System.Windows.Forms.TrackBar();
            this.Eng_L = new System.Windows.Forms.TrackBar();
            this.Battery_Label = new System.Windows.Forms.Label();
            this.BTNLog = new System.Windows.Forms.Button();
            this.BTNSettings = new System.Windows.Forms.Button();
            this.BTNSTOP = new System.Windows.Forms.Button();
            this.Sensor3 = new System.Windows.Forms.ProgressBar();
            this.Sensor2 = new System.Windows.Forms.ProgressBar();
            this.Sensor1 = new System.Windows.Forms.ProgressBar();
            this.Sensor4 = new System.Windows.Forms.ProgressBar();
            this.Sensor5 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Eng_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eng_L)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNConnect
            // 
            this.BTNConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNConnect.Location = new System.Drawing.Point(148, 9);
            this.BTNConnect.Name = "BTNConnect";
            this.BTNConnect.Size = new System.Drawing.Size(75, 25);
            this.BTNConnect.TabIndex = 0;
            this.BTNConnect.Text = "Connect";
            this.BTNConnect.UseVisualStyleBackColor = true;
            this.BTNConnect.Click += new System.EventHandler(this.BTNConnect_Click);
            // 
            // BTNDisconnect
            // 
            this.BTNDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNDisconnect.Location = new System.Drawing.Point(229, 9);
            this.BTNDisconnect.Name = "BTNDisconnect";
            this.BTNDisconnect.Size = new System.Drawing.Size(75, 25);
            this.BTNDisconnect.TabIndex = 1;
            this.BTNDisconnect.Text = "Disconnect";
            this.BTNDisconnect.UseVisualStyleBackColor = true;
            this.BTNDisconnect.Click += new System.EventHandler(this.BTNDisconnect_Click);
            // 
            // IPBox
            // 
            this.IPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IPBox.Location = new System.Drawing.Point(12, 12);
            this.IPBox.MaxLength = 12;
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(119, 20);
            this.IPBox.TabIndex = 2;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // LogBOX
            // 
            this.LogBOX.AcceptsTab = true;
            this.LogBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBOX.Location = new System.Drawing.Point(194, 177);
            this.LogBOX.Multiline = true;
            this.LogBOX.Name = "LogBOX";
            this.LogBOX.ReadOnly = true;
            this.LogBOX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBOX.Size = new System.Drawing.Size(594, 240);
            this.LogBOX.TabIndex = 3;
            this.LogBOX.WordWrap = false;
            this.LogBOX.TextChanged += new System.EventHandler(this.LogBOX_TextChanged);
            // 
            // LED_G
            // 
            this.LED_G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LED_G.AutoSize = true;
            this.LED_G.BackColor = System.Drawing.SystemColors.Control;
            this.LED_G.Location = new System.Drawing.Point(67, 40);
            this.LED_G.Name = "LED_G";
            this.LED_G.Size = new System.Drawing.Size(64, 17);
            this.LED_G.TabIndex = 4;
            this.LED_G.Text = "GREEN";
            this.LED_G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LED_G.UseVisualStyleBackColor = false;
            this.LED_G.CheckedChanged += new System.EventHandler(this.Led_G_CheckedChanged);
            // 
            // LED_R
            // 
            this.LED_R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LED_R.AutoSize = true;
            this.LED_R.BackColor = System.Drawing.SystemColors.Control;
            this.LED_R.Location = new System.Drawing.Point(12, 40);
            this.LED_R.Name = "LED_R";
            this.LED_R.Size = new System.Drawing.Size(49, 17);
            this.LED_R.TabIndex = 5;
            this.LED_R.Text = "RED";
            this.LED_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LED_R.UseVisualStyleBackColor = false;
            this.LED_R.CheckedChanged += new System.EventHandler(this.LED_R_CheckedChanged);
            // 
            // BatteryLevel
            // 
            this.BatteryLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryLevel.Location = new System.Drawing.Point(628, 10);
            this.BatteryLevel.Name = "BatteryLevel";
            this.BatteryLevel.Size = new System.Drawing.Size(160, 23);
            this.BatteryLevel.Step = 1;
            this.BatteryLevel.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BatteryLevel.TabIndex = 6;
            this.BatteryLevel.Value = 50;
            this.BatteryLevel.Click += new System.EventHandler(this.BatteryLevel_Click);
            // 
            // BTNLogClear
            // 
            this.BTNLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNLogClear.Location = new System.Drawing.Point(194, 423);
            this.BTNLogClear.Name = "BTNLogClear";
            this.BTNLogClear.Size = new System.Drawing.Size(75, 23);
            this.BTNLogClear.TabIndex = 7;
            this.BTNLogClear.Text = "Clear";
            this.BTNLogClear.UseVisualStyleBackColor = true;
            this.BTNLogClear.Click += new System.EventHandler(this.ClearLogBTN_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(715, 428);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(73, 13);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Disconnected";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // BTNSend
            // 
            this.BTNSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNSend.Location = new System.Drawing.Point(512, 10);
            this.BTNSend.Name = "BTNSend";
            this.BTNSend.Size = new System.Drawing.Size(75, 23);
            this.BTNSend.TabIndex = 9;
            this.BTNSend.Text = "Send";
            this.BTNSend.UseVisualStyleBackColor = true;
            this.BTNSend.Click += new System.EventHandler(this.BTNSend_Click);
            // 
            // CMDBox
            // 
            this.CMDBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CMDBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CMDBox.Location = new System.Drawing.Point(372, 12);
            this.CMDBox.MaxLength = 6;
            this.CMDBox.Name = "CMDBox";
            this.CMDBox.Size = new System.Drawing.Size(134, 20);
            this.CMDBox.TabIndex = 10;
            this.CMDBox.TextChanged += new System.EventHandler(this.CMDBox_TextChanged);
            // 
            // BTNIsConnected
            // 
            this.BTNIsConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNIsConnected.Location = new System.Drawing.Point(12, 423);
            this.BTNIsConnected.Name = "BTNIsConnected";
            this.BTNIsConnected.Size = new System.Drawing.Size(75, 23);
            this.BTNIsConnected.TabIndex = 11;
            this.BTNIsConnected.Text = "Check";
            this.BTNIsConnected.UseVisualStyleBackColor = true;
            this.BTNIsConnected.Click += new System.EventHandler(this.BTNIsConnected_Click);
            // 
            // Eng_R
            // 
            this.Eng_R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Eng_R.Location = new System.Drawing.Point(67, 63);
            this.Eng_R.Maximum = 127;
            this.Eng_R.Minimum = -128;
            this.Eng_R.Name = "Eng_R";
            this.Eng_R.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Eng_R.Size = new System.Drawing.Size(45, 354);
            this.Eng_R.TabIndex = 12;
            this.Eng_R.TickFrequency = 20;
            this.Eng_R.Scroll += new System.EventHandler(this.Eng_R_Scroll);
            // 
            // Eng_L
            // 
            this.Eng_L.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Eng_L.Location = new System.Drawing.Point(16, 63);
            this.Eng_L.Maximum = 127;
            this.Eng_L.Minimum = -128;
            this.Eng_L.Name = "Eng_L";
            this.Eng_L.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Eng_L.RightToLeftLayout = true;
            this.Eng_L.Size = new System.Drawing.Size(45, 354);
            this.Eng_L.TabIndex = 13;
            this.Eng_L.TickFrequency = 20;
            this.Eng_L.Scroll += new System.EventHandler(this.Eng_L_Scroll);
            // 
            // Battery_Label
            // 
            this.Battery_Label.Location = new System.Drawing.Point(625, 36);
            this.Battery_Label.Name = "Battery_Label";
            this.Battery_Label.Size = new System.Drawing.Size(163, 13);
            this.Battery_Label.TabIndex = 14;
            this.Battery_Label.Text = "Battery Level";
            this.Battery_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Battery_Label.Click += new System.EventHandler(this.Battery_Label_Click);
            // 
            // BTNLog
            // 
            this.BTNLog.Location = new System.Drawing.Point(93, 423);
            this.BTNLog.Name = "BTNLog";
            this.BTNLog.Size = new System.Drawing.Size(75, 23);
            this.BTNLog.TabIndex = 15;
            this.BTNLog.Text = "Log";
            this.BTNLog.UseVisualStyleBackColor = true;
            this.BTNLog.Click += new System.EventHandler(this.BTNLog_Click);
            // 
            // BTNSettings
            // 
            this.BTNSettings.Location = new System.Drawing.Point(625, 423);
            this.BTNSettings.Name = "BTNSettings";
            this.BTNSettings.Size = new System.Drawing.Size(75, 23);
            this.BTNSettings.TabIndex = 16;
            this.BTNSettings.Text = "Settings";
            this.BTNSettings.UseVisualStyleBackColor = true;
            this.BTNSettings.Click += new System.EventHandler(this.BTNSettings_Click);
            // 
            // BTNSTOP
            // 
            this.BTNSTOP.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSTOP.Location = new System.Drawing.Point(544, 423);
            this.BTNSTOP.Name = "BTNSTOP";
            this.BTNSTOP.Size = new System.Drawing.Size(75, 23);
            this.BTNSTOP.TabIndex = 17;
            this.BTNSTOP.Text = "STOP (ESC)";
            this.BTNSTOP.UseVisualStyleBackColor = true;
            this.BTNSTOP.Click += new System.EventHandler(this.BTNSTOP_Click);
            // 
            // Sensor3
            // 
            this.Sensor3.Location = new System.Drawing.Point(148, 218);
            this.Sensor3.Maximum = 2000;
            this.Sensor3.Name = "Sensor3";
            this.Sensor3.Size = new System.Drawing.Size(621, 30);
            this.Sensor3.Step = 1;
            this.Sensor3.TabIndex = 18;
            this.Sensor3.Value = 5;
            // 
            // Sensor2
            // 
            this.Sensor2.Location = new System.Drawing.Point(148, 158);
            this.Sensor2.Maximum = 2000;
            this.Sensor2.Name = "Sensor2";
            this.Sensor2.Size = new System.Drawing.Size(621, 30);
            this.Sensor2.Step = 1;
            this.Sensor2.TabIndex = 19;
            this.Sensor2.Value = 5;
            // 
            // Sensor1
            // 
            this.Sensor1.Location = new System.Drawing.Point(148, 98);
            this.Sensor1.Maximum = 2000;
            this.Sensor1.Name = "Sensor1";
            this.Sensor1.Size = new System.Drawing.Size(621, 30);
            this.Sensor1.Step = 1;
            this.Sensor1.TabIndex = 20;
            this.Sensor1.Value = 5;
            // 
            // Sensor4
            // 
            this.Sensor4.Location = new System.Drawing.Point(148, 278);
            this.Sensor4.Maximum = 2000;
            this.Sensor4.Name = "Sensor4";
            this.Sensor4.Size = new System.Drawing.Size(621, 30);
            this.Sensor4.Step = 1;
            this.Sensor4.TabIndex = 21;
            this.Sensor4.Value = 5;
            // 
            // Sensor5
            // 
            this.Sensor5.Location = new System.Drawing.Point(148, 338);
            this.Sensor5.Maximum = 2000;
            this.Sensor5.Name = "Sensor5";
            this.Sensor5.Size = new System.Drawing.Size(621, 30);
            this.Sensor5.Step = 1;
            this.Sensor5.TabIndex = 22;
            this.Sensor5.Value = 5;
            // 
            // Form
            // 
            this.AcceptButton = this.BTNConnect;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BTNSTOP;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNSTOP);
            this.Controls.Add(this.BTNSettings);
            this.Controls.Add(this.BTNLog);
            this.Controls.Add(this.Battery_Label);
            this.Controls.Add(this.Eng_L);
            this.Controls.Add(this.Eng_R);
            this.Controls.Add(this.BTNIsConnected);
            this.Controls.Add(this.CMDBox);
            this.Controls.Add(this.BTNSend);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.BTNLogClear);
            this.Controls.Add(this.BatteryLevel);
            this.Controls.Add(this.LED_R);
            this.Controls.Add(this.LED_G);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.BTNDisconnect);
            this.Controls.Add(this.BTNConnect);
            this.Controls.Add(this.LogBOX);
            this.Controls.Add(this.Sensor5);
            this.Controls.Add(this.Sensor4);
            this.Controls.Add(this.Sensor1);
            this.Controls.Add(this.Sensor2);
            this.Controls.Add(this.Sensor3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Robot Control";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Eng_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eng_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNConnect;
        private System.Windows.Forms.Button BTNDisconnect;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox LogBOX;
        private System.Windows.Forms.CheckBox LED_G;
        private System.Windows.Forms.CheckBox LED_R;
        private System.Windows.Forms.ProgressBar BatteryLevel;
        private System.Windows.Forms.Button BTNLogClear;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button BTNSend;
        private System.Windows.Forms.TextBox CMDBox;
        private System.Windows.Forms.Button BTNIsConnected;
        private System.Windows.Forms.TrackBar Eng_R;
        private System.Windows.Forms.TrackBar Eng_L;
        private System.Windows.Forms.Label Battery_Label;
        private System.Windows.Forms.Button BTNLog;
        private System.Windows.Forms.Button BTNSettings;
        private System.Windows.Forms.Button BTNSTOP;
        private System.Windows.Forms.ProgressBar Sensor3;
        private System.Windows.Forms.ProgressBar Sensor2;
        private System.Windows.Forms.ProgressBar Sensor1;
        private System.Windows.Forms.ProgressBar Sensor4;
        private System.Windows.Forms.ProgressBar Sensor5;
    }
}

