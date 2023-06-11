using System;
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
using Renci.SshNet.Security;

namespace MyQQ4Client
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        public SqlUtils sqlUtils = new SqlUtils();
        public static String myname = "buaa"; //名字
        static string uid = "";

        public List<Msg> notices = new List<Msg>();
        public Dictionary<string,string> chatMessage = new Dictionary<string,string>();
        //聊天记录




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
            return this.textBoxSendee.Text.Trim();
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
                this.richTextBox_msg.Text = s;
            }
        }

        //delegate void VoidString(string s);
        //public void Println2(string s)
        //{
        //    this.richTextBox_msg.Text = string.Empty;
        //    this.richTextBox_msg.Text += s;
        //}

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
                richTextBox_msg.Text = string.Empty;
                if (chatMessage.ContainsKey(GlobalVariables.destiny_id.ToString()))
                {
                    Println(chatMessage[GlobalVariables.destiny_id.ToString()]);
                    //换行符分割每一条信息
                    //string[] everyMessage = chatMessage[GlobalVariables.destiny_id.ToString()].Split('\n');
                    ////遍历输出每一条信息
                    //for (int i = 0; i < everyMessage.Length; i++)
                    //{
                    //    //截取前两个字符
                    //    string subMessage = everyMessage[i].Substring(0, 2);
                    //    if (subMessage == "我：")
                    //    {
                    //        AddSentMessage(everyMessage[i]);
                    //    }
                    //    else
                    //    {
                    //        AddReceiveMessage(everyMessage[i]);
                    //    }
                    //}
                }
            }
            
        }

        /// <summary>
        /// 接收的消息左对齐和颜色设置
        /// </summary>
        /// <param name="message"></param>
        private void AddReceiveMessage(string message)
        {
            richTextBox_msg.AppendText(message + Environment.NewLine);

            int index = richTextBox_msg.Text.LastIndexOf(message);
            richTextBox_msg.Select(index, message.Length);
            richTextBox_msg.SelectionColor = Color.YellowGreen;
            richTextBox_msg.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox_msg.Select(richTextBox_msg.Text.Length, 0);
            richTextBox_msg.ScrollToCaret();

        }
        /// <summary>
        /// 自己发送的消息左对齐和颜色设置
        /// </summary>
        /// <param name="message"></param>
        private void AddSentMessage(string message)
        {
            richTextBox_msg.AppendText(message + Environment.NewLine);

            int index = richTextBox_msg.Text.LastIndexOf(message);
            richTextBox_msg.Select(index, message.Length);
            richTextBox_msg.SelectionColor = Color.Blue;
            richTextBox_msg.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox_msg.Select(richTextBox_msg.Text.Length, 0);
            richTextBox_msg.ScrollToCaret();
        }


        /// <summary>
        /// 打印显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="news"></param>
        public void map_notice_and_println(string id,string news)
        {
            string destiny = sqlUtils.getSelfName(id);
            if (!chatMessage.ContainsKey(id))
            {
                chatMessage.Add(id.ToString(), "");
            }
            if (!news.Equals("")) {
                chatMessage[id.ToString()] +=   news + "\n";
            }
            combox_friend_operation(id.ToString());
            Println(chatMessage[id.ToString()]);
        }

        private void comboBox_friends_MouseMove(object sender, MouseEventArgs e)
        {
            combox_friend_operation(GlobalVariables.destiny_id.ToString());
        }

        public void combox_friend_operation(string id) {
            if (chatMessage.Count < 1) return;
            comboBox_friends.Items.Clear();
            comboBox_friends.Text = sqlUtils.getSelfName(id) + ":" + id;
            foreach (string key in chatMessage.Keys)
            {
                //if (key.Equals(GlobalVariables.destiny_id.ToString())) continue;
                comboBox_friends.Items.Add(sqlUtils.getSelfName(key) + ":" + key);
            }
        }

        private void comboBox_friends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_friends.SelectedItem != null)
            {
                string selectedValue = comboBox_friends.SelectedItem.ToString().Split(':')[1];
                Console.WriteLine("Selected Value: " + selectedValue);

                Println(chatMessage[selectedValue]);
            }
        }

        private void textBoxSendee_TextChanged(object sender, EventArgs e)
        {
            combox_friend_operation(GlobalVariables.destiny_id.ToString());
        }
    }

}
