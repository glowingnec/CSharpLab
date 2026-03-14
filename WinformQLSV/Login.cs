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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

     

        private void bt_login_Click(object sender, EventArgs e)
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
                    mainForm.FormClosed += (s, args) => this.Close(); // Đóng cả form Login khi Main đóng
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
            txt_pass.UseSystemPasswordChar = true; // Ẩn mật khẩu khi nhập
        }



        private void txt_usr_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lb1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
