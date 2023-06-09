namespace MyQQ4Client
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
            this.components = new System.ComponentModel.Container();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxSendee = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.button_ChangeName = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(448, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 12);
            this.labelStatus.TabIndex = 17;
            this.labelStatus.Text = "尚未连接";
            // 
            // textBoxSendee
            // 
            this.textBoxSendee.Location = new System.Drawing.Point(16, 315);
            this.textBoxSendee.Name = "textBoxSendee";
            this.textBoxSendee.Size = new System.Drawing.Size(400, 21);
            this.textBoxSendee.TabIndex = 16;
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(421, 315);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 15;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(393, 10);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(49, 23);
            this.buttonConnect.TabIndex = 14;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMsg.Location = new System.Drawing.Point(15, 74);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMsg.Size = new System.Drawing.Size(277, 235);
            this.textBoxMsg.TabIndex = 13;
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(323, 12);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(55, 21);
            this.numericUpDownPort.TabIndex = 12;
            this.numericUpDownPort.Value = new decimal(new int[] {
            6666,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "端口";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(216, 12);
            this.textBoxIP.MaxLength = 15;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(66, 21);
            this.textBoxIP.TabIndex = 10;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP 地址";
            // 
            // buttonAddFriend
            // 
            this.buttonAddFriend.Location = new System.Drawing.Point(367, 39);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFriend.TabIndex = 18;
            this.buttonAddFriend.Text = "添加好友";
            this.buttonAddFriend.UseVisualStyleBackColor = true;
            // 
            // button_ChangeName
            // 
            this.button_ChangeName.Location = new System.Drawing.Point(79, 47);
            this.button_ChangeName.Name = "button_ChangeName";
            this.button_ChangeName.Size = new System.Drawing.Size(67, 21);
            this.button_ChangeName.TabIndex = 23;
            this.button_ChangeName.Text = "更换名称";
            this.button_ChangeName.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_username.Location = new System.Drawing.Point(79, 12);
            this.textBox_username.MaxLength = 15;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(73, 26);
            this.textBox_username.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(290, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 241);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "好友";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.MaxLength = 15;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(207, 215);
            this.textBox1.TabIndex = 25;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 351);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_ChangeName);
            this.Controls.Add(this.buttonAddFriend);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxSendee);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "耳卯   --客户端";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxSendee;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFriend;
        private System.Windows.Forms.Button button_ChangeName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

