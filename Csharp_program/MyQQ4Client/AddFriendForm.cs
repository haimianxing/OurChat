// 添加好友窗口
namespace MyQQ4Client
{
    public class AddFriendForm : Form
    {
        private TextBox textFriendID;
        private Button buttonSave;
        private Label label1;

        public NewForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textFriendID = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();


            // 设置文本框和按钮的属性和位置等
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "好友ID:";
            // 
            // textFriendID
            // 
            this.textFriendID.Location = new System.Drawing.Point(69, 13);
            this.textFriendID.MaxLength = 11;
            this.textFriendID.Name = "textFriendID";
            this.textFriendID.Size = new System.Drawing.Size(100, 21);
            this.textFriendID.TabIndex = 6;
            // 
            // buttonSend
            // 
            //this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(50, 35);
            this.buttonSave.Name = "buttonSend";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "添加";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(130, 45);
            this.Text = "添加好友";

            this.Controls.Add(textFriendID);
            this.Controls.Add(buttonSave);
            this.Controls.Add(label1);
            // 注册按钮点击事件处理程序
            this.buttonSave.Click += ButtonSave_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string FriendID = textFriendID.Text;
        
            if(FriendID == null)
            {
                MessageBox.show("请输入好友ID");
            }
            else
            {
                // 查询好友uid是否注册
                if(MainForm.sqlUtils.IsExistUser(FriendID))
                {
                    //暂时没有得到自己sid的方法，晚些修改
                    if(MainForm.sqlUtils.AddFriend(int.Parse(FriendID), sid))
                    {
                        MessageBox.show("添加成功");
                    }
                }
                else
                {
                    MessageBox.show("未找到对应uid用户");
                }
            }
            
        }
    }
}
