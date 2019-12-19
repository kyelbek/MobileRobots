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
            ((System.ComponentModel.ISupportInitialize)(this.Eng_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Eng_L)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNConnect
            // 
            this.BTNConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNConnect.Location = new System.Drawing.Point(191, 10);
            this.BTNConnect.Name = "BTNConnect";
            this.BTNConnect.Size = new System.Drawing.Size(75, 23);
            this.BTNConnect.TabIndex = 0;
            this.BTNConnect.Text = "Connect";
            this.BTNConnect.UseVisualStyleBackColor = true;
            this.BTNConnect.Click += new System.EventHandler(this.BTNConnect_Click);
            // 
            // BTNDisconnect
            // 
            this.BTNDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNDisconnect.Location = new System.Drawing.Point(286, 10);
            this.BTNDisconnect.Name = "BTNDisconnect";
            this.BTNDisconnect.Size = new System.Drawing.Size(75, 23);
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
            this.IPBox.Size = new System.Drawing.Size(161, 20);
            this.IPBox.TabIndex = 2;
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // LogBOX
            // 
            this.LogBOX.AcceptsTab = true;
            this.LogBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBOX.Location = new System.Drawing.Point(191, 179);
            this.LogBOX.Multiline = true;
            this.LogBOX.Name = "LogBOX";
            this.LogBOX.ReadOnly = true;
            this.LogBOX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBOX.Size = new System.Drawing.Size(597, 243);
            this.LogBOX.TabIndex = 3;
            this.LogBOX.WordWrap = false;
            this.LogBOX.TextChanged += new System.EventHandler(this.LogBOX_TextChanged);
            // 
            // LED_G
            // 
            this.LED_G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LED_G.AutoSize = true;
            this.LED_G.Location = new System.Drawing.Point(79, 38);
            this.LED_G.Name = "LED_G";
            this.LED_G.Size = new System.Drawing.Size(61, 17);
            this.LED_G.TabIndex = 4;
            this.LED_G.Text = "LED_G";
            this.LED_G.UseVisualStyleBackColor = true;
            this.LED_G.CheckedChanged += new System.EventHandler(this.Led_G_CheckedChanged);
            // 
            // LED_R
            // 
            this.LED_R.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LED_R.AutoSize = true;
            this.LED_R.Location = new System.Drawing.Point(12, 38);
            this.LED_R.Name = "LED_R";
            this.LED_R.Size = new System.Drawing.Size(61, 17);
            this.LED_R.TabIndex = 5;
            this.LED_R.Text = "LED_R";
            this.LED_R.UseVisualStyleBackColor = true;
            this.LED_R.CheckedChanged += new System.EventHandler(this.LED_R_CheckedChanged);
            // 
            // BatteryLevel
            // 
            this.BatteryLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryLevel.Location = new System.Drawing.Point(688, 10);
            this.BatteryLevel.Name = "BatteryLevel";
            this.BatteryLevel.Size = new System.Drawing.Size(100, 23);
            this.BatteryLevel.Step = 1;
            this.BatteryLevel.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BatteryLevel.TabIndex = 6;
            this.BatteryLevel.Value = 50;
            this.BatteryLevel.Click += new System.EventHandler(this.BatteryLevel_Click);
            // 
            // BTNLogClear
            // 
            this.BTNLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNLogClear.Location = new System.Drawing.Point(12, 415);
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
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // BTNSend
            // 
            this.BTNSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNSend.Location = new System.Drawing.Point(530, 10);
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
            this.CMDBox.Location = new System.Drawing.Point(385, 12);
            this.CMDBox.MaxLength = 12;
            this.CMDBox.Name = "CMDBox";
            this.CMDBox.Size = new System.Drawing.Size(139, 20);
            this.CMDBox.TabIndex = 10;
            this.CMDBox.TextChanged += new System.EventHandler(this.CMDBox_TextChanged);
            // 
            // BTNIsConnected
            // 
            this.BTNIsConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNIsConnected.Location = new System.Drawing.Point(98, 415);
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
            this.Eng_R.Location = new System.Drawing.Point(12, 128);
            this.Eng_R.Maximum = 127;
            this.Eng_R.Minimum = -128;
            this.Eng_R.Name = "Eng_R";
            this.Eng_R.Size = new System.Drawing.Size(776, 45);
            this.Eng_R.TabIndex = 12;
            this.Eng_R.Scroll += new System.EventHandler(this.Eng_R_Scroll);
            // 
            // Eng_L
            // 
            this.Eng_L.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Eng_L.Location = new System.Drawing.Point(12, 77);
            this.Eng_L.Maximum = 127;
            this.Eng_L.Minimum = -128;
            this.Eng_L.Name = "Eng_L";
            this.Eng_L.Size = new System.Drawing.Size(776, 45);
            this.Eng_L.TabIndex = 13;
            this.Eng_L.Scroll += new System.EventHandler(this.Eng_L_Scroll);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(this.LogBOX);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.BTNDisconnect);
            this.Controls.Add(this.BTNConnect);
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
    }
}

