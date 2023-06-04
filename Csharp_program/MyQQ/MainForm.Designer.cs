namespace MyQQ
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAllClients = new System.Windows.Forms.ComboBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxSendee = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP 地址";
            // 
            // comboBoxAllClients
            // 
            this.comboBoxAllClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAllClients.FormattingEnabled = true;
            this.comboBoxAllClients.Location = new System.Drawing.Point(354, 7);
            this.comboBoxAllClients.Name = "comboBoxAllClients";
            this.comboBoxAllClients.Size = new System.Drawing.Size(141, 20);
            this.comboBoxAllClients.TabIndex = 13;
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(273, 6);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 23);
            this.buttonListen.TabIndex = 12;
            this.buttonListen.Text = "监听";
            this.buttonListen.UseVisualStyleBackColor = true;
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(212, 7);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(55, 21);
            this.numericUpDownPort.TabIndex = 11;
            this.numericUpDownPort.Value = new decimal(new int[] {
            6666,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "端口";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(68, 6);
            this.textBoxIP.MaxLength = 15;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxIP.TabIndex = 9;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // textBoxSendee
            // 
            this.textBoxSendee.Location = new System.Drawing.Point(17, 323);
            this.textBoxSendee.Name = "textBoxSendee";
            this.textBoxSendee.Size = new System.Drawing.Size(400, 21);
            this.textBoxSendee.TabIndex = 16;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(422, 323);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 15;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMsg.Location = new System.Drawing.Point(16, 50);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMsg.Size = new System.Drawing.Size(481, 267);
            this.textBoxMsg.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 356);
            this.Controls.Add(this.textBoxSendee);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.comboBoxAllClients);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "耳卯  --服务器";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAllClients;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxSendee;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMsg;
    }
}

