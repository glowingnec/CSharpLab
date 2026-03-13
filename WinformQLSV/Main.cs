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
    public partial class Main : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Main()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

  
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Load dữ liệu SQL các thứ :D
        private void LoadData()
        {    
            var query = from sv in db.SinhViens
                        select new
                        {
                            Mã_SV = sv.MaSV,
                            Họ_Tên = sv.HoTen,
                            Giới_Tính = sv.GioiTinh,
                            Ngày_Sinh = sv.NgaySinh,
                            Lớp = sv.Lop
                        };

           
            dgvSinhVien.DataSource = query.ToList();
        }

        // Phần tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var query = from sv in db.SinhViens
                        where sv.HoTen.Contains(keyword) || sv.MaSV.Contains(keyword) || sv.Lop.Contains(keyword)
                        select new
                        {
                            Mã_SV = sv.MaSV,
                            Họ_Tên = sv.HoTen,
                            Giới_Tính = sv.GioiTinh,
                            Ngày_Sinh = sv.NgaySinh,
                            Lớp = sv.Lop
                        };

            dgvSinhVien.DataSource = query.ToList();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            LoadData();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

