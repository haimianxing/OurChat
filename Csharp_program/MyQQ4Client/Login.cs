using MyQQ4Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyQQ4Client
{
    public partial class Login : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils();
        public Login()
        {
            InitializeComponent();
        }

        private void registerBt_Click(object sender, EventArgs e)
        {
            // 点击注册 跳转注册页面
            Register register = new Register();
            this.Hide();
            register.ShowDialog(this);
            this.Dispose();
        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            String name = nametb.Text, password = passwordtb.Text;

            // 点击登陆 进入登陆界面
            // 需要验证用户名和密码
            if (true)
            {
                // 登陆成功
                MessageBox.Show("Success Login");
            }
            else
            {
                // 登陆失败
                MessageBox.Show("Wrong username and password combination");
            }
        }
    }
}
