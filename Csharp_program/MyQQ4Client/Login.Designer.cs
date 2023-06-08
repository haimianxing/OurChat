namespace MyQQ4Client
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.nametb = new System.Windows.Forms.TextBox();
            this.passwordtb = new System.Windows.Forms.TextBox();
            this.loginBt = new System.Windows.Forms.Button();
            this.namelb = new System.Windows.Forms.Label();
            this.passwordlb = new System.Windows.Forms.Label();
            this.registerBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nametb
            // 
            this.nametb.Location = new System.Drawing.Point(295, 75);
            this.nametb.Name = "nametb";
            this.nametb.Size = new System.Drawing.Size(242, 28);
            this.nametb.TabIndex = 0;
            // 
            // passwordtb
            // 
            this.passwordtb.Location = new System.Drawing.Point(295, 164);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.PasswordChar = '*';
            this.passwordtb.Size = new System.Drawing.Size(242, 28);
            this.passwordtb.TabIndex = 1;
            // 
            // loginBt
            // 
            this.loginBt.Location = new System.Drawing.Point(257, 274);
            this.loginBt.Name = "loginBt";
            this.loginBt.Size = new System.Drawing.Size(94, 34);
            this.loginBt.TabIndex = 2;
            this.loginBt.Text = "Login";
            this.loginBt.UseVisualStyleBackColor = true;
            this.loginBt.Click += new System.EventHandler(this.loginBt_Click);
            // 
            // namelb
            // 
            this.namelb.AutoSize = true;
            this.namelb.Location = new System.Drawing.Point(148, 84);
            this.namelb.Name = "namelb";
            this.namelb.Size = new System.Drawing.Size(44, 18);
            this.namelb.TabIndex = 3;
            this.namelb.Text = "Name";
            // 
            // passwordlb
            // 
            this.passwordlb.AutoSize = true;
            this.passwordlb.Location = new System.Drawing.Point(148, 171);
            this.passwordlb.Name = "passwordlb";
            this.passwordlb.Size = new System.Drawing.Size(80, 18);
            this.passwordlb.TabIndex = 4;
            this.passwordlb.Text = "Password";
            // 
            // registerBt
            // 
            this.registerBt.Location = new System.Drawing.Point(396, 274);
            this.registerBt.Name = "registerBt";
            this.registerBt.Size = new System.Drawing.Size(94, 34);
            this.registerBt.TabIndex = 5;
            this.registerBt.Text = "Register";
            this.registerBt.UseVisualStyleBackColor = true;
            this.registerBt.Click += new System.EventHandler(this.registerBt_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registerBt);
            this.Controls.Add(this.passwordlb);
            this.Controls.Add(this.namelb);
            this.Controls.Add(this.loginBt);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.nametb);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nametb;
        private System.Windows.Forms.TextBox passwordtb;
        private System.Windows.Forms.Button loginBt;
        private System.Windows.Forms.Label namelb;
        private System.Windows.Forms.Label passwordlb;
        private System.Windows.Forms.Button registerBt;
    }
}

