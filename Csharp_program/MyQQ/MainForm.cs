using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils();
        


        public MainForm(EventHandler bListenClick, EventHandler bSendClick)
        {
            InitializeComponent();
            this.buttonListen.Click += bListenClick;
            this.buttonSend.Click += bSendClick;
            sqlUtils.setDB(db);
            sqlUtils.GetContent();
            Console.WriteLine(sqlUtils.RegisterUsers("zcz", "123"));
            Console.WriteLine(sqlUtils.CheckUser("buaa", "0"));
            Console.WriteLine(sqlUtils.CheckUser("buaa", "123456"));
            Console.WriteLine(sqlUtils.AddFriend(9, 5));
            Console.WriteLine(sqlUtils.AddFriend(2, 1));

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

        public void ComboBoxAddItem(string s)
        {
            if (this.comboBoxAllClients.InvokeRequired)
            {
                VoidString cbAddItem = ComboBoxAddItem;
                this.textBoxMsg.Invoke(cbAddItem, s);
            }
            else
            {
                this.comboBoxAllClients.Items.Add(s);
            }
        }
        public void ComboBoxRemoveItem(string s)
        {
            if (this.comboBoxAllClients.InvokeRequired)
            {
                VoidString cbRmItem = ComboBoxRemoveItem;
                this.textBoxMsg.Invoke(cbRmItem, s);
            }
            else
            {
                this.comboBoxAllClients.Items.Remove(s);
            }
        }
    }
}
