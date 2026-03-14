using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Winform1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private class SinhVienInput
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public string GioiTinh { get; set; }
            public DateTime? NgaySinh { get; set; }
            public string Lop { get; set; }
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;

            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            keyword = (keyword ?? string.Empty).Trim();

            using (var db = new DataClasses1DataContext())
            {
                var query = db.SinhViens.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(sv =>
                        (sv.MaSV ?? "").Contains(keyword) ||
                        (sv.HoTen ?? "").Contains(keyword) ||
                        (sv.Lop ?? "").Contains(keyword));
                }

                var data = query
                    .OrderBy(sv => sv.MaSV)
                    .Select(sv => new
                    {
                        MaSV = sv.MaSV,
                        HoTen = sv.HoTen,
                        GioiTinh = sv.GioiTinh,
                        NgaySinh = sv.NgaySinh,
                        Lop = sv.Lop
                    })
                    .ToList();

                dgvSinhVien.DataSource = data;

                if (dgvSinhVien.Columns["MaSV"] != null) dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                if (dgvSinhVien.Columns["HoTen"] != null) dgvSinhVien.Columns["HoTen"].HeaderText = "Họ Tên";
                if (dgvSinhVien.Columns["GioiTinh"] != null) dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvSinhVien.Columns["NgaySinh"] != null) dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvSinhVien.Columns["Lop"] != null) dgvSinhVien.Columns["Lop"].HeaderText = "Lớp";
            }
        }

        private bool CheckMaSV(out string maSV)
        {
            maSV = null;

            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var cell = dgvSinhVien.CurrentRow.Cells["MaSV"];
            if (cell == null || cell.Value == null)
            {
                MessageBox.Show("Không lấy được mã SV.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            maSV = cell.Value.ToString();
            return !string.IsNullOrWhiteSpace(maSV);
        }

        private bool DialogSinhVien(SinhVienInput current, bool isEdit, out SinhVienInput result)
        {
            result = null;

            using (var form = new Form())
            using (var lblMaSV = new Label())
            using (var lblHoTen = new Label())
            using (var lblGioiTinh = new Label())
            using (var lblNgaySinh = new Label())
            using (var lblLop = new Label())
            using (var txtMaSV = new TextBox())
            using (var txtHoTen = new TextBox())
            using (var cboGioiTinh = new ComboBox())
            using (var dtNgaySinh = new DateTimePicker())
            using (var txtLop = new TextBox())
            using (var btnOk = new Button())
            using (var btnCancel = new Button())
            {
                form.Text = isEdit ? "Sửa sinh viên" : "Thêm sinh viên";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(380, 250);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                lblMaSV.Text = "Mã SV:";
                lblMaSV.Location = new Point(20, 20);
                lblMaSV.AutoSize = true;

                txtMaSV.Location = new Point(120, 16);
                txtMaSV.Width = 220;

                lblHoTen.Text = "Họ Tên:";
                lblHoTen.Location = new Point(20, 55);
                lblHoTen.AutoSize = true;

                txtHoTen.Location = new Point(120, 51);
                txtHoTen.Width = 220;

                lblGioiTinh.Text = "Giới Tính:";
                lblGioiTinh.Location = new Point(20, 90);
                lblGioiTinh.AutoSize = true;

                cboGioiTinh.Location = new Point(120, 86);
                cboGioiTinh.Width = 220;
                cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
                cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });

                lblNgaySinh.Text = "Ngày Sinh:";
                lblNgaySinh.Location = new Point(20, 125);
                lblNgaySinh.AutoSize = true;

                dtNgaySinh.Location = new Point(120, 121);
                dtNgaySinh.Width = 220;
                dtNgaySinh.Format = DateTimePickerFormat.Short;
                dtNgaySinh.ShowCheckBox = true;

                lblLop.Text = "Lớp:";
                lblLop.Location = new Point(20, 160);
                lblLop.AutoSize = true;

                txtLop.Location = new Point(120, 156);
                txtLop.Width = 220;

                btnOk.Text = "Lưu";
                btnOk.Location = new Point(184, 200);
                btnOk.DialogResult = DialogResult.OK;

                btnCancel.Text = "Huỷ";
                btnCancel.Location = new Point(265, 200);
                btnCancel.DialogResult = DialogResult.Cancel;

                form.Controls.AddRange(new Control[]
                {
                    lblMaSV, txtMaSV,
                    lblHoTen, txtHoTen,
                    lblGioiTinh, cboGioiTinh,
                    lblNgaySinh, dtNgaySinh,
                    lblLop, txtLop,
                    btnOk, btnCancel
                });

                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (current != null)
                {
                    txtMaSV.Text = current.MaSV;
                    txtHoTen.Text = current.HoTen;
                    txtLop.Text = current.Lop;

                    if (!string.IsNullOrWhiteSpace(current.GioiTinh))
                    {
                        cboGioiTinh.SelectedItem = current.GioiTinh;
                    }

                    if (current.NgaySinh.HasValue)
                    {
                        dtNgaySinh.Value = current.NgaySinh.Value;
                        dtNgaySinh.Checked = true;
                    }
                    else
                    {
                        dtNgaySinh.Checked = false;
                    }
                }

                if (!isEdit && cboGioiTinh.SelectedIndex < 0)
                {
                    cboGioiTinh.SelectedIndex = 0;
                }

                txtMaSV.ReadOnly = isEdit;

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                var maSV = txtMaSV.Text.Trim();
                var hoTen = txtHoTen.Text.Trim();
                var lop = txtLop.Text.Trim();
                var gioiTinh = cboGioiTinh.SelectedItem == null ? string.Empty : cboGioiTinh.SelectedItem.ToString();
                DateTime? ngaySinh = dtNgaySinh.Checked ? (DateTime?)dtNgaySinh.Value.Date : null;

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Mã SV không được để trống.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                result = new SinhVienInput
                {
                    MaSV = maSV,
                    HoTen = hoTen,
                    GioiTinh = gioiTinh,
                    NgaySinh = ngaySinh,
                    Lop = lop
                };

                return true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SinhVienInput input;
            if (!DialogSinhVien(null, false, out input))
            {
                return;
            }

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    bool existed = db.SinhViens.Any(s => s.MaSV == input.MaSV);
                    if (existed)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var sv = new SinhVien
                    {
                        MaSV = input.MaSV,
                        HoTen = input.HoTen,
                        GioiTinh = input.GioiTinh,
                        NgaySinh = input.NgaySinh,
                        Lop = input.Lop
                    };

                    db.SinhViens.InsertOnSubmit(sv);
                    db.SubmitChanges();
                }

                LoadData(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maSV;
            if (!CheckMaSV(out maSV))
            {
                return;
            }

            using (var db = new DataClasses1DataContext())
            {
                var sv = db.SinhViens.FirstOrDefault(s => s.MaSV == maSV);
                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên để sửa.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var current = new SinhVienInput
                {
                    MaSV = sv.MaSV,
                    HoTen = sv.HoTen,
                    GioiTinh = sv.GioiTinh,
                    NgaySinh = sv.NgaySinh,
                    Lop = sv.Lop
                };

                SinhVienInput edited;
                if (!DialogSinhVien(current, true, out edited))
                {
                    return;
                }

                try
                {
                    sv.HoTen = edited.HoTen;
                    sv.GioiTinh = edited.GioiTinh;
                    sv.NgaySinh = edited.NgaySinh;
                    sv.Lop = edited.Lop;
                    db.SubmitChanges();

                    LoadData(txtTimKiem.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thất bại: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bt_xoa_sv_Click(object sender, EventArgs e)
        {
            string maSV;
            if (!CheckMaSV(out maSV))
            {
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xoá sinh viên mã " + maSV + "?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var sv = db.SinhViens.FirstOrDefault(s => s.MaSV == maSV);
                    if (sv == null)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xoá.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.SinhViens.DeleteOnSubmit(sv);
                    db.SubmitChanges();
                }

                LoadData(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text);
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        
    }
}