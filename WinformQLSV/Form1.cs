using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_usr.Text.Trim();
            string pass = txt_pass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
                using (var db = new DataClasses1DataContext())
                {
                    bool tinChuan = db.TaiKhoans.Any(tk =>
                        tk.TenDangNhap == username && tk.MatKhau == pass);

                    if (tinChuan)
                    {
                        Main mainForm = new Main();
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên tk hoặc mật khẩu", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_pass.Clear();
                        txt_pass.Focus();
                    }
                }
            }
            
        

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_pass.UseSystemPasswordChar = true;
        }

        private void lb2_Click(object sender, EventArgs e)
        {
        }
    }
}
