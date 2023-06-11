using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MySqlX.XDevAPI.Common;
using System.Text.RegularExpressions;
using Message;

namespace MyQQ
{
    static class Program
    {
        static Socket serverSocket = null;
        static IPAddress ip = null;
        static IPEndPoint point = null;

        static Dictionary<string, Socket> allClientSockets = null;
        static Dictionary<string, Socket> idIpDic = null;

        static MainForm form = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            allClientSockets = new Dictionary<string, Socket>();
            idIpDic = new Dictionary<string, Socket>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm(bListenClick, bSendClick);
            Application.Run(form);

        }

        static EventHandler bListenClick = SetListen;
        //static EventHandler bSendClick = SendMsg;
        static EventHandler bSendClick = SendText;

        static void SetListen(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(form.GetIPText());
            point = new IPEndPoint(ip, form.GetPort());

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(point);
                serverSocket.Listen(20);
                form.Println($"服务器开始在 {point} 上监听。");

                Thread thread = new Thread(Listen);
                thread.IsBackground = true;
                thread.Start(serverSocket);
            }
            catch (Exception ex)
            {
                form.Println($"错误： {ex.Message}");
            }
        }

        static void Listen(object so)
        {
            Socket serverSocket = so as Socket;
            while (true)
            {
                try
                {
                    //等待连接并且创建一个负责通讯的socket
                    Socket clientSocket = serverSocket.Accept();
                    //获取链接的IP地址
                    string clientPoint = clientSocket.RemoteEndPoint.ToString();
                    form.Println($"{clientPoint} 上的客户端请求连接。");

                    allClientSockets.Add(clientPoint, clientSocket);
                    form.ComboBoxAddItem(clientPoint);

                    //开启一个新线程不停接收消息
                    Thread thread = new Thread(Receive);
                    thread.IsBackground = true;
                    thread.Start(clientSocket);
                }
                catch (Exception e)
                {
                    form.Println($"错误： {e.Message}");
                    break;
                }
            }
        }

        static void Receive(object so)
        {
            Socket clientSocket = so as Socket;
            string clientPoint = clientSocket.RemoteEndPoint.ToString();
            while (true)
            {
                try
                {
                    //获取发送过来的消息容器
                    byte[] buf = new byte[1024 * 1024 * 2];
                    int len = clientSocket.Receive(buf);
                    //有效字节为0则跳过
                    if (len == 0) break;

                    //string s = Encoding.UTF8.GetString(buf, 0, len);
                    //form.Println($"{clientPoint}: {s}");

                    //foreach (Socket t in allClientSockets.Values)
                    //{
                    //    byte[] sendee = Encoding.UTF8.GetBytes($"{clientPoint}: {s}");
                    //    t.Send(sendee);
                    //}

                    //反序列化
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (System.IO.MemoryStream ms = new MemoryStream(buf, 0, len))
                    {
                        Msg msg = (Msg)formatter.Deserialize(ms);
                        //form.Println("反序列化成功了");
                        form.Println($"{clientPoint}: {msg.content},{msg.type}");
                        switch (msg.type)
                        {
                            //私聊消息
                            case MsgType.Text:
                                HandlePrivateChate(msg, clientSocket);
                                break;
                            //通知消息
                            case MsgType.Notice:
                                HandleNoticeMessage(msg);
                                break;
                            //检查在线消息
                            case MsgType.CheckOnline:
                                HandleCheckOnlineMessage(msg, clientSocket);
                                break;
                            //客户端连接服务器就会发送这个消息，服务器存储到id、ip映射中
                            case MsgType.ConnectMessage:
                                Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                                Match match = regex.Match(msg.content); // 匹配字符串
                                if (match.Success)
                                {
                                    string id = match.Groups[1].Value; // 提取 id 属性值
                                    idIpDic.Add(id, clientSocket);
                                    form.Println($"{id},{msg.type} 已加入字典。" + idIpDic.ToString());
                                }
                                break;
                            default: break;
                        }
                    }

                }
                catch (SocketException e)
                {
                    //allClientSockets.Remove(clientPoint);
                    form.ComboBoxRemoveItem(clientPoint);

                    //断连移除socket
                    if (e.SocketErrorCode == SocketError.ConnectionReset)
                    {
                        foreach (var pair in idIpDic)
                        {
                            if (pair.Value == clientSocket)
                            {
                                idIpDic.Remove(pair.Key);
                                break;
                            }
                        }
                    }

                    form.Println($"客户端 {clientSocket.RemoteEndPoint} 中断连接： {e.Message}");
                    clientSocket.Close();
                    break;
                }
                catch (Exception e)
                {
                    form.Println($"错误： {e.Message}");
                }
            }
        }

        //static void SendMsg(object sender, EventArgs e)
        //{
        //    string msg = form.GetMsgText();
        //    if (msg == "") return;
        //    byte[] sendee = Encoding.UTF8.GetBytes($"服务器：{msg}");
        //    foreach (Socket s in allClientSockets.Values)
        //        s.Send(sendee);
        //    form.Println(msg);
        //    form.ClearMsgText();
        //}

        //消息发送
        public static void SendMsg(MsgType type, string content, Socket clientSocket)
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

        //发送文本（群）
        static void SendText(object sender, EventArgs e)
        {
            MsgType type = MsgType.Text;
            string content = "管理员" + "&" + form.GetMsgText();
            if (content == "") return;
            foreach (Socket s in allClientSockets.Values)
            {
                SendMsg(type, content, s);
            }

            form.Println(content);
            form.ClearMsgText();
        }
        //处理通知
        static void HandleNoticeMessage(Msg msg)
        {
            string[] strings = msg.content.Split(' ');
            //去字典找对应socket
            Socket destination = idIpDic[strings[1]];

            //发送通知
            SendMsg(msg.type, msg.content, destination);

        }
        //处理检查在线
        static void HandleCheckOnlineMessage(Msg msg, Socket clientSockt)
        {
            string onlineState;
            //连接中有这个ip，则设置在线标志为online
            if (idIpDic.ContainsKey(msg.content))
            {
                onlineState = "online";
            }
            else
            {
                onlineState = "offline";
            }

            SendMsg(MsgType.CheckOnline, onlineState, clientSockt);

        }

        //私聊信息转发
        static void HandlePrivateChate(Msg msg, Socket clientSockt)
        {
            MsgType type = MsgType.Text;
            string[] s = msg.content.Split('&');
            string sourceId = "";

            foreach (var pair in idIpDic)
            {
                if (clientSockt == pair.Value)
                {
                    sourceId = pair.Key;
                }
            }

            string content = sourceId + "&" + s[1];
            //string content = s[0] + "&" + s[1];

            form.Println("原msg："+msg.content+" .转换后："+content);
            //发送过来的第一个ip就是destId
            Socket dest = idIpDic[s[0]];

            SendMsg(type, content, dest);

        }

    }
}
