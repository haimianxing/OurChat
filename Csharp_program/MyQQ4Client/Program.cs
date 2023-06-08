using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//using AddFriendForm;

namespace MyQQ4Client
{
    static class Program
    {        
        static Socket clientSocket = null;
        static IPAddress ip = null;
        static IPEndPoint point = null;

        static MainForm form = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm(bConnectClick, bSendClick,bAddFriendClick);
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
