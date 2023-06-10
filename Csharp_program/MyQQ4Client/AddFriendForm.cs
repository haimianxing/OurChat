using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyQQ4Client;
using MySqlX.XDevAPI.Common;
using System.Threading;
using static MyQQ4Client.MainForm;
using Message;
using System.Net.Sockets;


// 添加好友窗口
namespace MyQQ4Client
{
    public class AddFriendForm : Form
    {
        private TextBox textFriendID;
        private Button buttonSave;
        private Label label1;
        private SqlUtils sqlUtils;
        private Socket clientSocket;

        public AddFriendForm()
        {
            InitializeComponent();
            sqlUtils = new SqlUtils();
        }
        

        public AddFriendForm(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            InitializeComponent();
            sqlUtils = new SqlUtils();
        }


        private void InitializeComponent()
        {
            this.textFriendID = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textFriendID
            // 
            this.textFriendID.Location = new System.Drawing.Point(69, 13);
            this.textFriendID.MaxLength = 11;
            this.textFriendID.Name = "textFriendID";
            this.textFriendID.Size = new System.Drawing.Size(100, 21);
            this.textFriendID.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(50, 35);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "添加";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "好友ID:";
            // 
            // AddFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 84);
            this.Controls.Add(this.textFriendID);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Name = "AddFriendForm";
            this.Text = "添加好友";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string FriendID = textFriendID.Text;
        
            if(FriendID == null)
            {
                MessageBox.Show("请输入好友ID");
            }
            else
            {
                // 查询好友uid是否注册
                if(sqlUtils.IsExistUser(FriendID))
                {
                    //只支持在线添加好友
                    //检查好友是否在线
                    try
                    {
                        //发送检查
                        Program.SendCheckOnline(FriendID);
                        //等2s
                        Thread.Sleep(2000);
                        if (GlobalVariables.isOnline == "offline")
                        {
                            MessageBox.Show("好友不在线");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    string v = sqlUtils.getSelfId(GlobalVariables.myname).Split(' ')[3].Replace(')',' ').Trim();


                    MsgType type = MsgType.Notice;
                    string content = GlobalVariables.myname + "(" + v + ") " + FriendID;
                    Program.SendMsg(type, content,clientSocket);
                    

                }
                else
                {
                    MessageBox.Show("未找到对应uid用户");
                }
            }
            
        }
    }
}
