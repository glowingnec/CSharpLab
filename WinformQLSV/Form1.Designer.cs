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
            this.usrtxt = new System.Windows.Forms.TextBox();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.bt1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(149, 130);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(70, 16);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Username";
            this.lb1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(152, 180);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(67, 16);
            this.lb2.TabIndex = 1;
            this.lb2.Text = "Password";
            // 
            // usrtxt
            // 
            this.usrtxt.Location = new System.Drawing.Point(225, 127);
            this.usrtxt.Name = "usrtxt";
            this.usrtxt.Size = new System.Drawing.Size(176, 22);
            this.usrtxt.TabIndex = 2;
            // 
            // passtxt
            // 
            this.passtxt.Location = new System.Drawing.Point(225, 174);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(176, 22);
            this.passtxt.TabIndex = 3;
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(274, 234);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(119, 23);
            this.bt1.TabIndex = 4;
            this.bt1.Text = "Đăng nhập";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 372);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.usrtxt);
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
        private System.Windows.Forms.TextBox usrtxt;
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.Button bt1;
    }
}

