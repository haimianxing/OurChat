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
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.button_ChangeName = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_names = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.noticeLable = new System.Windows.Forms.Label();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.comboBox_friends = new System.Windows.Forms.ComboBox();
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
            this.textBoxSendee.TextChanged += new System.EventHandler(this.textBoxSendee_TextChanged);
            // 
            // buttonSend
            // 
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
            this.buttonAddFriend.Location = new System.Drawing.Point(296, 39);
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
            this.groupBox1.Controls.Add(this.listView_names);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(290, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 241);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "好友";
            // 
            // listView_names
            // 
            this.listView_names.FullRowSelect = true;
            this.listView_names.HideSelection = false;
            this.listView_names.Location = new System.Drawing.Point(8, 20);
            this.listView_names.Name = "listView_names";
            this.listView_names.Size = new System.Drawing.Size(205, 215);
            this.listView_names.TabIndex = 26;
            this.listView_names.UseCompatibleStateImageBehavior = false;
            this.listView_names.View = System.Windows.Forms.View.List;
            this.listView_names.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_names_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(32, 167);
            this.textBox1.MaxLength = 15;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 68);
            this.textBox1.TabIndex = 25;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // noticeLable
            // 
            this.noticeLable.AutoSize = true;
            this.noticeLable.Location = new System.Drawing.Point(448, 44);
            this.noticeLable.Name = "noticeLable";
            this.noticeLable.Size = new System.Drawing.Size(29, 12);
            this.noticeLable.TabIndex = 27;
            this.noticeLable.Text = "通知";
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.Location = new System.Drawing.Point(12, 74);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(270, 235);
            this.richTextBox_msg.TabIndex = 27;
            this.richTextBox_msg.Text = "";
            // 
            // comboBox_friends
            // 
            this.comboBox_friends.FormattingEnabled = true;
            this.comboBox_friends.Location = new System.Drawing.Point(213, 47);
            this.comboBox_friends.Name = "comboBox_friends";
            this.comboBox_friends.Size = new System.Drawing.Size(69, 20);
            this.comboBox_friends.TabIndex = 28;
            this.comboBox_friends.SelectedIndexChanged += new System.EventHandler(this.comboBox_friends_SelectedIndexChanged);
            this.comboBox_friends.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comboBox_friends_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 351);
            this.Controls.Add(this.comboBox_friends);
            this.Controls.Add(this.richTextBox_msg);
            this.Controls.Add(this.noticeLable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_ChangeName);
            this.Controls.Add(this.buttonAddFriend);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxSendee);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonConnect);
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
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFriend;
        private System.Windows.Forms.Button button_ChangeName;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label noticeLable;
        private System.Windows.Forms.ListView listView_names;
        public System.Windows.Forms.RichTextBox richTextBox_msg;
        public System.Windows.Forms.ComboBox comboBox_friends;
    }
}

