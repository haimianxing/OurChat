namespace MyQQ4Client
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerBt = new System.Windows.Forms.Button();
            this.passwordlb = new System.Windows.Forms.Label();
            this.namelb = new System.Windows.Forms.Label();
            this.loginBt = new System.Windows.Forms.Button();
            this.passwordtb = new System.Windows.Forms.TextBox();
            this.nametb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordtb2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // registerBt
            // 
            this.registerBt.Location = new System.Drawing.Point(248, 301);
            this.registerBt.Name = "registerBt";
            this.registerBt.Size = new System.Drawing.Size(94, 34);
            this.registerBt.TabIndex = 11;
            this.registerBt.Text = "Register";
            this.registerBt.UseVisualStyleBackColor = true;
            this.registerBt.Click += new System.EventHandler(this.registerBt_Click);
            // 
            // passwordlb
            // 
            this.passwordlb.AutoSize = true;
            this.passwordlb.Location = new System.Drawing.Point(162, 164);
            this.passwordlb.Name = "passwordlb";
            this.passwordlb.Size = new System.Drawing.Size(80, 18);
            this.passwordlb.TabIndex = 10;
            this.passwordlb.Text = "Password";
            // 
            // namelb
            // 
            this.namelb.AutoSize = true;
            this.namelb.Location = new System.Drawing.Point(162, 89);
            this.namelb.Name = "namelb";
            this.namelb.Size = new System.Drawing.Size(44, 18);
            this.namelb.TabIndex = 9;
            this.namelb.Text = "Name";
            // 
            // loginBt
            // 
            this.loginBt.Location = new System.Drawing.Point(404, 301);
            this.loginBt.Name = "loginBt";
            this.loginBt.Size = new System.Drawing.Size(94, 34);
            this.loginBt.TabIndex = 14;
            this.loginBt.Text = "TO Login";
            this.loginBt.UseVisualStyleBackColor = true;
            this.loginBt.Click += new System.EventHandler(this.loginBt_Click);
            // 
            // passwordtb
            // 
            this.passwordtb.Location = new System.Drawing.Point(309, 154);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.PasswordChar = '*';
            this.passwordtb.Size = new System.Drawing.Size(242, 28);
            this.passwordtb.TabIndex = 7;
            // 
            // nametb
            // 
            this.nametb.Location = new System.Drawing.Point(309, 80);
            this.nametb.Name = "nametb";
            this.nametb.Size = new System.Drawing.Size(242, 28);
            this.nametb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Password";
            // 
            // passwordtb2
            // 
            this.passwordtb2.Location = new System.Drawing.Point(309, 232);
            this.passwordtb2.Name = "passwordtb2";
            this.passwordtb2.PasswordChar = '*';
            this.passwordtb2.Size = new System.Drawing.Size(242, 28);
            this.passwordtb2.TabIndex = 8;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordtb2);
            this.Controls.Add(this.registerBt);
            this.Controls.Add(this.passwordlb);
            this.Controls.Add(this.namelb);
            this.Controls.Add(this.loginBt);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.nametb);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBt;
        private System.Windows.Forms.Label passwordlb;
        private System.Windows.Forms.Label namelb;
        private System.Windows.Forms.Button loginBt;
        private System.Windows.Forms.TextBox passwordtb;
        private System.Windows.Forms.TextBox nametb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordtb2;
    }
}