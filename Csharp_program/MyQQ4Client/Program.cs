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

namespace MyQQ4Client
{
    static class Program
    {        
        static Socket clientSocket = null;
        static IPAddress ip = null;
        static IPEndPoint point = null;
        static PictureBox pictureBox = null;
        static TextBox textBox_name = null;
        static TextBox textBox_friend = null;
        static string uid = "";

        static MainForm form = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm(bConnectClick, bSendClick,bAddFriendClick,bChangeClick);
            Application.Run(new Login());
            if (Publicv.Creatmainform)
            {
                Publicv.Creatmainform = false;//标志复位
                Application.Run(form);//启动主界面
            }
            
        }

        static EventHandler bConnectClick = SetConnection;
        static EventHandler bSendClick = SendMsg;
        static EventHandler bAddFriendClick = AddFriend;
        static EventHandler bChangeClick = ChangeName;


        //更改名称
        static void ChangeName(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;password=root;database=myqq_user;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string sql = "update qq_user set name = '" + textBox_name.Text + "' where uid = " + uid;
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
                form.Println($"连接 {point} 的服务器。");


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
                switch (image)
                {
                    case 1: pictureBox.Image = Properties.Resources.image1; break;
                    case 2: pictureBox.Image = Properties.Resources.image2; break;
                    case 3: pictureBox.Image = Properties.Resources.image3; break;
                }
                Database db = new Database();
                SqlUtils sqlUtils = new SqlUtils();
                string result = sqlUtils.getSelfId(MainForm.myname);
                Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                Match match = regex.Match(result); // 匹配字符串
                if (match.Success)
                {
                    string idValue = match.Groups[1].Value; // 提取 id 属性值
                    int id = int.Parse(idValue); // 将字符串转换为整数类型的值
                    uid = id.ToString();
                }
                    
                string connStr = "server=127.0.0.1;port=3306;user=root;password=root;database=myqq_user;";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql_id = "SELECT * FROM qq_user where uid=" + uid;
                //string sql_fri = "SELECT b1.name AS pidName, b2.name AS sidName FROM friend_table\r\nJOIN qq_user AS b1 ON friend_table.pid=b1.uid\r\nJOIN qq_user AS b2 ON friend_table.sid=b2.uid\r\nWHERE friend_table.friend_id="+uid+";";
                //查用户名的sql
                MySqlCommand cmd = new MySqlCommand(sql_id, conn);
                MySqlDataReader reader = cmd.ExecuteReader();       //处理查询结果,创建一个实例保存查询出来的结构
                while (reader.Read())
                {
                    textBox_name.Text = reader.GetString(1);
                }
                // 关闭数据读取器
                reader.Close();
                try
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        //MessageBox.Show("数据库已打开");
                    }
                    else
                    {
                        MessageBox.Show("数据库打开失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();


                //不停的接收服务器端发送的消息
                Thread thread = new Thread(Receive);
                thread.IsBackground = true;
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
                    string s = Encoding.UTF8.GetString(buf, 0, len);
                    form.Println(s);
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
            AddFriendForm fAddFriend = new AddFriendForm();
            fAddFriend.Show();
        }
    }
}
