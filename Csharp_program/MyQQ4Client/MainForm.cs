using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyQQ4Client;

namespace MyQQ4Client
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils(); 
        public MainForm(EventHandler b1Click, EventHandler b2Click)
        {
            InitializeComponent();
            this.buttonConnect.Click += b1Click;
            this.buttonSend.Click += b2Click;
            sqlUtils.setDB(db);
            sqlUtils.GetContent();

            Console.WriteLine(sqlUtils.RegisterUsers("zcz", "123"));//注册用户和密码
            Console.WriteLine(sqlUtils.CheckUser("buaa", "0"));//验证用户和密码 返回错误与数据库不匹配
            Console.WriteLine(sqlUtils.CheckUser("buaa", "123456"));//验证用户和密码 返回正确与数据库匹配
            Console.WriteLine(sqlUtils.AddFriend(9, 5)); //给id为9号的用户添加id为5号的朋友
            Console.WriteLine(sqlUtils.AddFriend(2, 1)); //给id为2号的用户添加id为1号的朋友
            Console.WriteLine(sqlUtils.getFriend(1) + "new1");
            Console.WriteLine(sqlUtils.getSelfId("buaa") + "new2");

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

    }
}
