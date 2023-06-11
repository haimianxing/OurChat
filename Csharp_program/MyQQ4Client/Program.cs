using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.IO;
using MySqlX.XDevAPI.Common;
using static MyQQ4Client.MainForm;
using System.Runtime.Serialization.Formatters.Binary;
using Message;
using System.Drawing;

namespace MyQQ4Client
{
    static class Program
    {        
        static Socket clientSocket = null;
        static IPAddress ip = null;
        static IPEndPoint point = null;
                /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm(bConnectClick, bSendClick,bAddFriendClick,bChangeClick,bNoticiClick);
            Application.Run(new Login());
            if (Publicv.Creatmainform)
            {
                Publicv.Creatmainform = false;//标志复位
                form.textBox_username.Text = GlobalVariables.myname;
                Application.Run(form);//启动主界面
                form.flush_form();
            }
            
        }

        static PictureBox pictureBox = null;
        static TextBox textBox_name = null;
        static TextBox textBox_friend = null;
        static string uid = "";
        static MainForm form = null;
        static SqlUtils sqlUtils = new SqlUtils();




        static EventHandler bConnectClick = SetConnection;
        static EventHandler bAddFriendClick = AddFriend;
        static EventHandler bChangeClick = ChangeName;
        static EventHandler bSendClick = SendText;
        static EventHandler bNoticiClick = Notice;


        //更改名称
        static void ChangeName(object sender, EventArgs e)
        {
            string name = (e as MyEventArgs)?.Name;

            string res = sqlUtils.getSelfId(GlobalVariables.myname);
            Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
            Match match = regex.Match(res); // 匹配字符串
            uid = match.Groups[1].Value;

            string connStr = "server=127.0.0.1;port=3306;user=root;password=root;database=myqq_user;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string sql = "update qq_user set name = '" + name + "' where uid = " + uid;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是数据库中受影响的数据行数
                if (result != 0)
                {
                    MessageBox.Show("更改成功", "提示");
                }
            }
            else
            {
                MessageBox.Show("数据库连接错误");
            }
        }

        static void SetConnection(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(form.GetIPText());
            point = new IPEndPoint(ip, form.GetPort());

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //进行连接
                clientSocket.Connect(point);
                form.SetConnectionStatusLabel(true, point.ToString());
                form.SetButtonSendEnabled(true);
                form.Println($"已经连接 {point} 的服务器。");


                //给上线成功的用户随机分配一个头像
                Control.ControlCollection controls = form.Controls;
                foreach (Control control in controls)
                {

                    if (control.GetType() == typeof(PictureBox))
                    {
                        pictureBox = control as PictureBox;
                    }
                    if (control.Name == "textBox_username")
                    {
                        textBox_name = control as TextBox;
                        textBox_name.Visible = true;
                    }
                    if (control.Name == "button_ChangeName")
                    {
                        control.Visible = true;

                    }

                    if (control is GroupBox)
                    {
                        textBox_friend = control.Controls.Find("textBox1", true).FirstOrDefault() as TextBox;

                    }
                }
                Random random = new Random();
                int image = random.Next(1, 4);
                string solutionPath = AppDomain.CurrentDomain.BaseDirectory;
                switch (image)
                {
                    case 1: pictureBox.Image = Image.FromFile(Path.Combine(solutionPath + "Resources", "image1.jpg")); break;
                    case 2: pictureBox.Image = Image.FromFile(Path.Combine(solutionPath + "Resources", "image2.jpg")); break;
                    case 3: pictureBox.Image = Image.FromFile(Path.Combine(solutionPath + "Resources", "image3.jpg")); break;
                }
                Database db = new Database();
                SqlUtils sqlUtils = new SqlUtils();
                textBox_name.Text = GlobalVariables.myname;


                //不停的接收服务器端发送的消息
                Thread thread = new Thread(Receive);
                thread.IsBackground = true;
                //连接成功发送自己Id给服务器
                SendMsg(MsgType.ConnectMessage, form.sqlUtils.getSelfId(GlobalVariables.myname));
                thread.Start(clientSocket);

               


            }
            catch (Exception ex)
            {
                form.Println("错误：" + ex.Message);
            }
        }
        static void Receive(object so)
        {
            Socket send = so as Socket;
            while (true)
            {
                try
                {
                    //获取发送过来的消息
                    byte[] buf = new byte[1024 * 1024 * 2];
                    int len = send.Receive(buf);
                    if (len == 0) break;

                    //反序列化
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new BinaryFormatter();
                    using (System.IO.MemoryStream ms = new MemoryStream(buf, 0, len))
                    {
                        Msg msg = (Msg)formatter.Deserialize(ms);

                        switch (msg.type)
                        {
                            //文本消息 
                            case MsgType.Text:
                                //form.Println(msg.content);
                                //form.Println(msg.content);
                                HandlePrivateChat(msg.content);
                                break;
                            //通知消息
                            case MsgType.Notice:
                                form.notices.Add(msg);
                                //刷新通知显示数量
                                form.noticeLable.Text = "通知 " + form.notices.Count;
                                break;
                            //检查在线消息,收到不回复，服务器处理
                            case MsgType.CheckOnline:
                                GlobalVariables.isOnline = msg.content;
                                break;
                            //在线检查返回信息
                            default: break;
                        }
                    }

                }
                catch (Exception e)
                {
                    form.SetConnectionStatusLabel(false);
                    form.SetButtonSendEnabled(false);
                    form.Println($"服务器已中断连接：{e.Message}");
                    break;
                }

            }
        }

        //消息发送
        public static void SendMsg(MsgType type, string content)
        {
            Msg msg = new Msg();
            msg.type = type;
            msg.content = content;
            //序列化
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, msg);
                byte[] data = ms.ToArray();

                // 使用 Socket 发送msg class
                clientSocket.Send(data);
            }
        }

        //消息发送
        public static void SendMsg(MsgType type, string content,Socket socket)
        {
            Msg msg = new Msg();
            msg.type = type;
            msg.content = content;
            //序列化
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, msg);
                byte[] data = ms.ToArray();

                // 使用 Socket 发送msg class
                socket.Send(data);
            }
        }

        //发送文本
        static void SendText(object sender, EventArgs e)
        {
            //string myId = form.sqlUtils.getSelfIdPure(GlobalVariables.myname);
            string destId = GlobalVariables.destiny_id.ToString();
            string message = form.GetMsgText();

            //检查好友是否在线
            try
            {
                //发送检查
                Program.SendCheckOnline(destId);
                //等0.1s
                Thread.Sleep(100);
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


            //发送的信息也需要进聊天记录
            if (!form.chatMessage.ContainsKey(destId))
            {
                form.chatMessage.Add(destId, "");
            }
            form.chatMessage[destId] += "我 ：" + message + "\n";
            form.Println(form.chatMessage[destId]);
            

            MsgType type = MsgType.Text;

            string content = destId + "&" + message;
            if (content == "" || destId == "") return;
            SendMsg(type, content);

            form.ClearMsgText();
        }

        static void SendMsg(object sender, EventArgs e)
        {
            string msg = form.GetMsgText();
            if (msg == "") return;
            byte[] sendee = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(sendee);
            form.ClearMsgText();
        }

        //添加好友
        static void AddFriend(object sender, EventArgs e)
        {
            //打开输入信息窗口
            AddFriendForm fAddFriend = new AddFriendForm(clientSocket);
            fAddFriend.Show();
        }

        //通知
        static void Notice(object sender, EventArgs e)
        {

            //打开通知窗口
            NoticeForm fNotice = new NoticeForm(form.notices);
            fNotice.Show();
            fNotice.FormClosing += (Object t, FormClosingEventArgs s) =>
            {
                if (form.notices.Count > 0)
                {
                    //刷新通知显示数量
                    form.noticeLable.Text = "通知 " + form.notices.Count;
                }
            };
        }

        //检查在线信息发送
        public static void SendCheckOnline(string uid)
        {
            //缺少根据uid查询对方ip地址的方法
            MsgType type = MsgType.CheckOnline;
            string content = uid;
            SendMsg(type, content);
        }

        //处理接收私聊消息格式为id&content
        public static void HandlePrivateChat(string msgContent)
        {

            string[] s = msgContent.Split('&');
            string id = s[0];
            string content = s[1];


            //文本消息处理格式对齐
            SqlUtils sqlUtils = new SqlUtils();
            string news = "";
            if (null ==  id   || id.Equals("")  )
            {
                news += "我：";
            }
            else
            {
                news += sqlUtils.getSelfName(id) + ": ";
            }
            news += content;
            GlobalVariables.destiny_id = Convert.ToInt32(id);
            form.map_notice_and_println(id, news);

        }
    }
}
