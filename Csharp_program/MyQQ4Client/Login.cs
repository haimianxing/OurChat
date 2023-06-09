using MyQQ4Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace MyQQ4Client
{
    //增加一个class作为判断标记
    public class Publicv
    {   //跳转主界面判断标志，退出登录时返回登录界面也要更改
        public static bool Creatmainform=false;
    }
    
    public partial class Login : Form
    {
        Database db = new Database();
        SqlUtils sqlUtils = new SqlUtils();
        public Login()
        {
            InitializeComponent();

        }

        public void record_txt(string name) {
            string path = @"./record.txt"; // 存储路径和文件名
            if (File.Exists(path))
            {
                File.WriteAllText(path, ""); // 将文件内容清空
                File.Delete(path); // 删除文件
            }
            File.WriteAllText(path, name);
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
            // 点击登陆 进入登陆界面
            // 需要验证用户名和密码         
            //获取用户名和密码
            String name = nametb.Text, password = passwordtb.Text;
            bool loginornot=false;

            if (name.Equals("") || password.Equals(""))//用户名或密码为空
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else       //用户名或密码不为空
            {
                //与数据库中对比验证
                loginornot=sqlUtils.CheckUser(name, password);

                if (!loginornot)
                {
                    // 登陆失败
                    MessageBox.Show("Wrong username and password combination");
                }
            }

           // loginornot = true; //测试用的bool
            if (loginornot)
            {
                // 登陆成功
                MessageBox.Show("Success Login");
                // 跳转主界面
                this.Hide();//隐藏当前页面   
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                this.Close();
                //返回并创建一个主页面
                record_txt(name);
                Publicv.Creatmainform = true;
                return ;                                    
            }
            
        }
    }
}
