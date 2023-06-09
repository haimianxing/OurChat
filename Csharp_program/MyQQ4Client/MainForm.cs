﻿using System;
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

namespace MyQQ4Client
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils();
        public static String myname = "buaa"; //名字
        public MainForm(EventHandler b1Click, EventHandler b2Click, EventHandler b3Click, EventHandler b4Click)
        {
            InitializeComponent();
            this.buttonConnect.Click += b1Click;
            this.buttonSend.Click += b2Click;
            this.buttonAddFriend.Click += b3Click;
            this.button_ChangeName.Click += b3Click;
            sqlUtils.setDB(db);
            sqlUtils.GetContent();

            //Console.WriteLine(sqlUtils.RegisterUsers("zcz", "123"));//注册用户和密码
            //Console.WriteLine(sqlUtils.CheckUser("buaa", "0"));//验证用户和密码 返回错误与数据库不匹配
            //Console.WriteLine(sqlUtils.CheckUser("buaa", "123456"));//验证用户和密码 返回正确与数据库匹配
            //Console.WriteLine(sqlUtils.AddFriend(9, 5)); //给id为9号的用户添加id为5号的朋友
            //Console.WriteLine(sqlUtils.AddFriend(2, 1)); //给id为2号的用户添加id为1号的朋友
            //Console.WriteLine(sqlUtils.getFriend(1) );
            //Console.WriteLine(sqlUtils.getSelfId("buaa") );

        }

        public string GetIPText()
        {
            return this.textBoxIP.Text;
        }

        public int GetPort()
        {
            return (int)this.numericUpDownPort.Value;
        }

        public string GetMsgText()
        {
            return this.textBoxSendee.Text.Trim();
        }

        public void ClearMsgText()
        {
            this.textBoxSendee.Clear();
        }

        delegate void VoidString(string s);
        public void Println(string s)
        {
            if (this.textBoxMsg.InvokeRequired)
            {
                VoidString println = Println;
                this.textBoxMsg.Invoke(println, s);
            }
            else
            {
                this.textBoxMsg.AppendText(s + Environment.NewLine);
            }
        }

        delegate void VoidBoolString(bool b, string s);
        public void SetConnectionStatusLabel(bool isConnect, string point = null)
        {
            if (this.labelStatus.InvokeRequired)
            {
                VoidBoolString scsl = SetConnectionStatusLabel;
                this.labelStatus.Invoke(scsl, isConnect, point);
            }
            else
            {
                if (isConnect)
                {
                    this.labelStatus.ForeColor = Color.Green;
                    this.labelStatus.Text = point;
                }
                else
                {
                    this.labelStatus.ForeColor = Color.Red;
                    this.labelStatus.Text = "尚未连接";
                }
            }
        }

        delegate void VoidBool(bool b);
        public void SetButtonSendEnabled(bool enabled)
        {
            if (this.buttonSend.InvokeRequired)
            {
                VoidBool sbse = SetButtonSendEnabled;
                this.textBoxMsg.Invoke(sbse, enabled);
            }
            else
            {
                this.buttonSend.Enabled = enabled;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            button_ChangeName.Visible = false;
            textBox_username.Visible = false;
            textBox_username.Text = "";
            timer1.Interval = 50000;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox_username.Text != "")//每5秒查询更新好友
            {
                SqlUtils sqlUtils = new SqlUtils();
                string result = sqlUtils.getSelfId(textBox_username.Text);
                Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                Match match = regex.Match(result); // 匹配字符串
                int uid = 1;
                if (match.Success)
                {
                    string idValue = match.Groups[1].Value; // 提取 id 属性值
                    int id = int.Parse(idValue); // 将字符串转换为整数类型的值
                    uid = id;
                }


                sqlUtils.setDB(db);
                result = sqlUtils.getFriend(uid);
                string pattern = @"Nickname:\s*(\w+),\s*id:\s*\d+";
                 regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(result);
                textBox1.Text = string.Empty;
                if (matches.Count > 0)
                {
                    foreach (Match match1 in matches)
                    {
                        string nickname = match1.Groups[1].Value;
                        textBox1.Text += nickname + Environment.NewLine; // 输出
                    }
                }
                else
                {
                    Console.WriteLine("No match found.");
                }
            }
        }
    }
}
