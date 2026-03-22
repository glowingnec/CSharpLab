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
            public string MaLop { get; set; }
            public string TenLop { get; set; }
        }
        private class LopOption
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }
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
                var query =
                    from sv in db.SinhViens
                    join lh in db.LopHocs on sv.MaLop equals lh.MaLop into gj
                    from lh in gj.DefaultIfEmpty()
                    select new
                    {
                        sv.MaSV,
                        sv.HoTen,
                        sv.GioiTinh,
                        sv.NgaySinh,
                        sv.MaLop,
                        TenLop = lh == null ? "" : lh.TenLop
                    };

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(x =>
                        (x.MaSV ?? "").Contains(keyword) ||
                        (x.HoTen ?? "").Contains(keyword) ||
                        (x.MaLop ?? "").Contains(keyword) ||
                        (x.TenLop ?? "").Contains(keyword));
                }

                var data = query
                    .OrderBy(x => x.MaSV)
                    .Select(x => new
                    {
                        MaSV = x.MaSV,
                        HoTen = x.HoTen,
                        GioiTinh = x.GioiTinh,
                        NgaySinh = x.NgaySinh,
                        Lop = x.TenLop
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
        private LopOption[] GetDanhSachLop()
        {
            using (var db = new DataClasses1DataContext())
            {
                return db.LopHocs
                    .Where(l => l.MaLop != null && l.MaLop.Trim() != "")
                    .OrderBy(l => l.MaLop)
                    .Select(l => new LopOption
                    {
                        MaLop = l.MaLop,
                        TenLop = l.TenLop
                    })
                    .ToArray();
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
            using (var cboLop = new ComboBox())
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

                cboLop.Location = new Point(120, 156);
                cboLop.Width = 220;
                cboLop.DropDownStyle = ComboBoxStyle.DropDownList;

                var dsLop = GetDanhSachLop();
                cboLop.DataSource = dsLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";

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
                    lblLop, cboLop,
                    btnOk, btnCancel
                });

                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (current != null)
                {
                    txtMaSV.Text = current.MaSV;
                    txtHoTen.Text = current.HoTen;

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

                    if (!string.IsNullOrWhiteSpace(current.MaLop))
                    {
                        cboLop.SelectedValue = current.MaLop;
                    }
                }

                if (!isEdit && cboGioiTinh.SelectedIndex < 0)
                {
                    cboGioiTinh.SelectedIndex = 0;
                }
                if (cboLop.SelectedIndex < 0 && cboLop.Items.Count > 0)
                {
                    cboLop.SelectedIndex = 0;
                }

                txtMaSV.ReadOnly = isEdit;

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                var maSV = txtMaSV.Text.Trim();
                var hoTen = txtHoTen.Text.Trim();
                var maLop = cboLop.SelectedValue == null ? string.Empty : cboLop.SelectedValue.ToString();
                var tenLop = cboLop.Text == null ? string.Empty : cboLop.Text.Trim();
                var gioiTinh = cboGioiTinh.SelectedItem == null ? string.Empty : cboGioiTinh.SelectedItem.ToString();
                DateTime? ngaySinh = dtNgaySinh.Checked ? (DateTime?)dtNgaySinh.Value.Date : null;

                if (string.IsNullOrWhiteSpace(maSV))
                {
                    MessageBox.Show("Mã SV không được để trống.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Vui lòng chọn lớp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                result = new SinhVienInput
                {
                    MaSV = maSV,
                    HoTen = hoTen,
                    GioiTinh = gioiTinh,
                    NgaySinh = ngaySinh,
                    MaLop = maLop,
                    TenLop = tenLop
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
                        MaLop = input.MaLop
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
                    MaLop = sv.MaLop,
                    TenLop = db.LopHocs
                        .Where(l => l.MaLop == sv.MaLop)
                        .Select(l => l.TenLop)
                        .FirstOrDefault()
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
                    sv.MaLop = edited.MaLop;
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

        private void bt_quan_ly_lop_Click(object sender, EventArgs e)
        {
            using (var frm = new Class())
            {
                frm.ShowDialog(this); // mở dạng modal
            }
        }
    }
}