namespace Winform1
{
    partial class Form1
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
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.txt_usr = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(149, 130);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(98, 16);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Tên đăng nhập";
            this.lb1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(186, 177);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(61, 16);
            this.lb2.TabIndex = 1;
            this.lb2.Text = "Mật khẩu";
            this.lb2.Click += new System.EventHandler(this.lb2_Click);
            // 
            // txt_usr
            // 
            this.txt_usr.Location = new System.Drawing.Point(253, 127);
            this.txt_usr.Name = "txt_usr";
            this.txt_usr.Size = new System.Drawing.Size(176, 22);
            this.txt_usr.TabIndex = 2;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(253, 174);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(176, 22);
            this.txt_pass.TabIndex = 3;
            // 
            // bt_login
            // 
            this.bt_login.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bt_login.Location = new System.Drawing.Point(266, 229);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(132, 30);
            this.bt_login.TabIndex = 4;
            this.bt_login.Text = "Đăng nhập";
            this.bt_login.UseVisualStyleBackColor = false;
            this.bt_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 478);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_usr);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.TextBox txt_usr;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Button bt_login;
    }
}

