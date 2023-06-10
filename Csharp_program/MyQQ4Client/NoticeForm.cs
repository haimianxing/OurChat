using Message;
using MyQQ4Client;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static MyQQ4Client.MainForm;
//通知窗口
namespace MyQQ4Client
{
    public class NoticeForm : Form
    {
        private SqlUtils sqlUtils;
        public List<Msg> notices;
        private ListView listView1;
        //private string[] strings = null;
        private Dictionary<string, string> dicMessageToId;

        public NoticeForm()
        {
            InitializeComponent();
            sqlUtils = new SqlUtils();
        }

        public NoticeForm(List<Msg> notices)
        {
            InitializeComponent();
            sqlUtils = new SqlUtils();
            //浅拷贝，直接赋值地址
            this.notices = notices;
            dicMessageToId = new Dictionary<string, string>();

            DisplayNotices();
        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(273, 101);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.MultiSelect = false;
            // 
            // NoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 154);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NoticeForm";
            this.Text = "通知";
            this.ResumeLayout(false);

        }

        private void DisplayNotices()
        {
            if (!notices.Any())
            {
                return;
            }
            else
            {
                foreach (Msg msg in notices)
                {
                    string[] strings = msg.content.Split(' ');
                    //dicMessageToId.Add(strings[0], strings[1]);
                    CreatItem(strings[0]);
                }
            }
        }

        //为ListView添加Item
        private void CreatItem(string content)
        {
            ListViewItem item = new ListViewItem(content);
            listView1.Items.Add(item);

        }


        //Item点击事件
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //获取选中的项目
            ListView.SelectedListViewItemCollection item = listView1.SelectedItems;
            //MessageBox.Show("点击了1个item  " + item[0].Text);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            if (!item[0].Text.Contains("#####"))
            {
                solve_notice(item, buttons);
            }
            else {
                solve_news(item);
            
            }

            
        }

        private void solve_notice(ListView.SelectedListViewItemCollection item, MessageBoxButtons buttons) {
            string message = item[0].Text + "想添加你为好友";
            DialogResult result = MessageBox.Show(message, "确认添加", buttons);

            //如果同意则添加好友，拒绝则将这一项移除
            if (result == DialogResult.Yes)
            {
                string res = sqlUtils.getSelfId(GlobalVariables.myname);
                Regex regex = new Regex(@"id:\s*(\d+)"); // 定义正则表达式
                Match match = regex.Match(res); // 匹配字符串
                if (match.Success)
                {
                    //sqlUtils.AddFriend(Convert.ToInt32(dicMessageToId[item[0].Text])
                    if (sqlUtils.AddFriend(Convert.ToInt32(item[0].Text.Split('(')[1].Replace(')', ' ').Trim()), Convert.ToInt32(match.Groups[1].Value)))
                    {
                        MessageBox.Show("添加成功");
                    }

                    for (int i = 0; i < notices.Count; i++)
                    {
                        if (item[0].Text == notices[i].content)
                        {
                            notices.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < notices.Count; i++)
                {
                    if (item[0].Text == notices[i].content)
                    {
                        notices.RemoveAt(i);
                        break;
                    }
                }
            }
        }


        private void solve_news(ListView.SelectedListViewItemCollection item)
        {
            MainForm mainForm = GlobalVariables.mainForm;
            mainForm.richTextBox_msg.Clear();
            mainForm.map_notice_and_println(item[0].Text.Split(':')[0].Replace("#####","").Trim(),"");
        }
    }


}