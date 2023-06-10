﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message;
using MyQQ4Client;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace MyQQ4Client
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        public SqlUtils sqlUtils = new SqlUtils();
        public static String myname = "buaa"; //名字
        static string uid = "";

        public List<Msg> notices = new List<Msg>();
        public Dictionary<string,string> news_dict = new Dictionary<string,string>();

        
        
        public MainForm(EventHandler b1Click, EventHandler b2Click, EventHandler b3Click, EventHandler b4Click,EventHandler b5Click)
        {
            InitializeComponent();
            this.buttonConnect.Click += b1Click;
            this.buttonSend.Click += b2Click;
            this.buttonAddFriend.Click += b3Click;
            this.noticeLable.Click += b5Click;
            this.button_ChangeName.Click += b4Click;

            


            myname = GlobalVariables.myname;
            sqlUtils.setDB(db);
            textBox_username.Text = myname;
            flush_form();
            GlobalVariables.mainForm = this;

        }

        


        // 定义存储额外参数的自定义类
        public class MyEventArgs : EventArgs
        {
            public string Name { get; }

            public MyEventArgs(string name)
            {
                this.Name = name;
            }
        }

        public void record_txt(string name)
        {
            string path = @"./record.txt"; // 存储路径和文件名
            if (File.Exists(path))
            {
                File.WriteAllText(path, ""); // 将文件内容清空
                File.Delete(path); // 删除文件
            }
            File.WriteAllText(path, name);
        }

        //更改名称
        void ChangeName(object sender, EventArgs e)
        {

            SqlUtils sqlUtils = new SqlUtils();
            string res = sqlUtils.getSelfId(GlobalVariables.myname);
            Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
            Match match = regex.Match(res); // 匹配字符串
            uid = match.Groups[1].Value;

            string connStr = "server=127.0.0.1;port=3306;user=root;password=root;database=myqq_user;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string sql = "update qq_user set name = '" + textBox_username.Text + "' where uid = " + uid;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是数据库中受影响的数据行数
                if (result != 0)
                {
                    record_txt(textBox_username.Text);
                    MessageBox.Show("更改成功", "提示");
                }
            }
            else
            {
                MessageBox.Show("数据库连接错误");
            }
        }

        public string GetIPText()
        {
            return this.textBoxIP.Text;
        }

        public int GetPort()
        {
            return (int)this.numericUpDownPort.Value;
        }

        /// <summary>
        /// 发送格式添加目标id
        /// </summary>
        /// <returns></returns>
        public string GetMsgText()
        {
            return GlobalVariables.destiny_id + "&" + this.textBoxSendee.Text.Trim();
        }

        public void ClearMsgText()
        {
            this.textBoxSendee.Clear();
        }

        delegate void VoidString(string s);
        public void Println(string s)
        {
            if (this.richTextBox_msg.InvokeRequired)
            {
                VoidString println = Println;
                this.richTextBox_msg.Invoke(println, s);
            }
            else
            {
                this.richTextBox_msg.AppendText(s + Environment.NewLine);
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
                //this.textBoxMsg.Invoke(sbse, enabled);
                this.richTextBox_msg.Invoke(sbse, enabled);
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
            //timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flush_form();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void flush_form() {
            if (GlobalVariables.myname != "")//每5秒查询更新好友
            {
                SqlUtils sqlUtils = new SqlUtils();
                string result = sqlUtils.getSelfId(GlobalVariables.myname);
                Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                Match match = regex.Match(result); // 匹配字符串
                int uid = 1;
                if (match.Success)
                {
                    string idValue = match.Groups[1].Value; // 提取 id 属性值
                    int id = int.Parse(idValue); // 将字符串转换为整数类型的值
                    uid = id;
                }
                GlobalVariables.id = uid;
                sqlUtils.setDB(db);
                result = sqlUtils.getFriend(uid);
                string pattern = @"Nickname:\s*(\w+),\s*id:\s*\d+";
                regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(result);
                textBox1.Text = string.Empty;
                listView_names.Items.Clear();
                if (matches.Count > 0)
                {
                    foreach (Match match1 in matches)
                    {
                        string nickname = match1.Groups[1].Value;
                        textBox1.Text += nickname + Environment.NewLine; // 输出
                        listView_names.Items.Add(nickname);
                    }
                }
                else
                {
                    Console.WriteLine("No match found.");
                }
            }
        }

        /// <summary>
        /// listview双击切换对话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_names_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left  && listView_names.SelectedItems.Count>0) {
                string destiny_name = listView_names.SelectedItems[0].Text;
                string v = sqlUtils.getSelfId2(destiny_name);
                GlobalVariables.destiny_id = Convert.ToInt32(v);

                //待转换窗口
            }
            
        }

        /// <summary>
        /// 打印显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="news"></param>
        internal void map_notice_and_println(string id,string news)
        {
            string destiny = sqlUtils.getSelfName(id);
            if (!news_dict.ContainsKey(id))
            {
                news_dict.Add(id.ToString(), "");
                Msg msg = new Msg();
                msg.type = MsgType.Notice;
                msg.content = "#####" + destiny + " :给您发了一条消息";
                notices.Add(msg);
            }
            if (!news.Equals("")) {
                news_dict[id.ToString()] += destiny + ": " + news + Environment.NewLine;
            }
            Println(news_dict[id.ToString()]);
        }
    }
}
