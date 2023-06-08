using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyQQ4Client
{
    public partial class Register : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils();
        public Register()
        {
            InitializeComponent();
        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            // 跳转登陆界面
            Login login = new Login();
            this.Hide();
            login.ShowDialog(this);
            this.Dispose();
        }

        private void registerBt_Click(object sender, EventArgs e)
        {
            // 点击 注册 按钮
            string name = nametb.Text;
            string password = passwordtb.Text;
            string password2 = passwordtb2.Text;
            // 验证规则 
            /**
             * 输入 不能为空
             * 两次密码一致
             * 密码必须包含两种不同字符、长度大于8
             */
            if (name == "")
            {
                MessageBox.Show("NAME NULL！");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("PASSWORD NULL!");
                return;
            }
            if (password != password2)
            {
                MessageBox.Show("PASSWORD NOT MATCH!");
                return;
            }

            if (!isRightPassword(password))
            {
                MessageBox.Show("PASSWORD SHOULD CONTAINS number|alphabet|other char," +
                    "Minimum 8 char Maximum 15");
                return;
            }

            /**
             * 库中 不允许 存在 name 相同的情况
             */
            if (sqlUtils.getSelfId(name) != "")
            {
                // 存在相同 name 的情况 
                MessageBox.Show(" CHANGE YOUR name !!!");
                return;
            }

            sqlUtils.RegisterUsers(name, password);
            // 添加成功
            MessageBox.Show(" Register SUCCESS!!!");
        }

        private bool isRightPassword(string password)
        {
            var regex = new Regex(@"
                    (?=.*[0-9])                     #必须包含数字
                    (?=.*[a-zA-Z])                  #必须包含小写或大写字母
                    # (?=([\x21-\x7e]+)[^a-zA-Z0-9])  #必须包含特殊符号
                    .{8,15}                         #至少8个字符，最多30个字符
                    ", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            //校验密码是否符合
            return regex.IsMatch(password);
        }
    }
}
