using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Winform1
{
    public partial class Class : Form
    {
        public Class()
        {
            InitializeComponent();
        }

        private class LopHocInput
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }
            public string GhiChu { get; set; }
        }

        private void Class_Load(object sender, EventArgs e)
        {
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.MultiSelect = false;
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.AllowUserToAddRows = false;

            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            keyword = (keyword ?? string.Empty).Trim();

            using (var db = new DataClasses1DataContext())
            {
                var query = db.LopHocs.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(l =>
                        (l.MaLop ?? "").Contains(keyword) ||
                        (l.TenLop ?? "").Contains(keyword) ||
                        (l.GhiChu ?? "").Contains(keyword));
                }

                var data = query
                    .OrderBy(l => l.MaLop)
                    .Select(l => new
                    {
                        MaLop = l.MaLop,
                        TenLop = l.TenLop,
                        GhiChu = l.GhiChu
                    })
                    .ToList();

                dgvLopHoc.DataSource = data;

                if (dgvLopHoc.Columns["MaLop"] != null) dgvLopHoc.Columns["MaLop"].HeaderText = "Mã lớp";
                if (dgvLopHoc.Columns["TenLop"] != null) dgvLopHoc.Columns["TenLop"].HeaderText = "Tên lớp";
                if (dgvLopHoc.Columns["GhiChu"] != null) dgvLopHoc.Columns["GhiChu"].HeaderText = "Ghi chú";
            }
        }

        private bool CheckMaLop(out string maLop)
        {
            maLop = null;

            if (dgvLopHoc.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var cell = dgvLopHoc.CurrentRow.Cells["MaLop"];
            if (cell == null || cell.Value == null)
            {
                MessageBox.Show("Không lấy được mã lớp.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            maLop = cell.Value.ToString();
            return !string.IsNullOrWhiteSpace(maLop);
        }

        private bool DialogLopHoc(LopHocInput current, bool isEdit, out LopHocInput result)
        {
            result = null;

            using (var form = new Form())
            using (var lblMaLop = new Label())
            using (var lblTenLop = new Label())
            using (var lblGhiChu = new Label())
            using (var txtMaLop = new TextBox())
            using (var txtTenLop = new TextBox())
            using (var txtGhiChu = new TextBox())
            using (var btnOk = new Button())
            using (var btnCancel = new Button())
            {
                form.Text = isEdit ? "Sửa lớp học" : "Thêm lớp học";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(420, 240);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                lblMaLop.Text = "Mã lớp:";
                lblMaLop.Location = new Point(20, 20);
                lblMaLop.AutoSize = true;

                txtMaLop.Location = new Point(120, 16);
                txtMaLop.Width = 270;

                lblTenLop.Text = "Tên lớp:";
                lblTenLop.Location = new Point(20, 58);
                lblTenLop.AutoSize = true;

                txtTenLop.Location = new Point(120, 54);
                txtTenLop.Width = 270;

                lblGhiChu.Text = "Ghi chú:";
                lblGhiChu.Location = new Point(20, 96);
                lblGhiChu.AutoSize = true;

                txtGhiChu.Location = new Point(120, 92);
                txtGhiChu.Width = 270;
                txtGhiChu.Height = 70;
                txtGhiChu.Multiline = true;

                btnOk.Text = "Lưu";
                btnOk.Location = new Point(232, 184);
                btnOk.DialogResult = DialogResult.OK;

                btnCancel.Text = "Huỷ";
                btnCancel.Location = new Point(315, 184);
                btnCancel.DialogResult = DialogResult.Cancel;

                form.Controls.AddRange(new Control[]
                {
                    lblMaLop, txtMaLop,
                    lblTenLop, txtTenLop,
                    lblGhiChu, txtGhiChu,
                    btnOk, btnCancel
                });

                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (current != null)
                {
                    txtMaLop.Text = current.MaLop;
                    txtTenLop.Text = current.TenLop;
                    txtGhiChu.Text = current.GhiChu;
                }

                txtMaLop.ReadOnly = isEdit;

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }

                var maLop = txtMaLop.Text.Trim();
                var tenLop = txtTenLop.Text.Trim();
                var ghiChu = txtGhiChu.Text.Trim();

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Mã lớp không được để trống.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(tenLop))
                {
                    MessageBox.Show("Tên lớp không được để trống.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                result = new LopHocInput
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu
                };

                return true;
            }
        }

        private void bt_them_lop_Click(object sender, EventArgs e)
        {
            LopHocInput input;
            if (!DialogLopHoc(null, false, out input))
            {
                return;
            }

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var existed = db.LopHocs.Any(l => l.MaLop == input.MaLop);
                    if (existed)
                    {
                        MessageBox.Show("Mã lớp đã tồn tại.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var lop = new LopHoc
                    {
                        MaLop = input.MaLop,
                        TenLop = input.TenLop,
                        GhiChu = input.GhiChu
                    };

                    db.LopHocs.InsertOnSubmit(lop);
                    db.SubmitChanges();
                }

                LoadData(txtTimKiemLop.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_sua_lop_Click(object sender, EventArgs e)
        {
            string maLop;
            if (!CheckMaLop(out maLop))
            {
                return;
            }

            using (var db = new DataClasses1DataContext())
            {
                var lop = db.LopHocs.FirstOrDefault(l => l.MaLop == maLop);
                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp để sửa.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var current = new LopHocInput
                {
                    MaLop = lop.MaLop,
                    TenLop = lop.TenLop,
                    GhiChu = lop.GhiChu
                };

                LopHocInput edited;
                if (!DialogLopHoc(current, true, out edited))
                {
                    return;
                }

                try
                {
                    lop.TenLop = edited.TenLop;
                    lop.GhiChu = edited.GhiChu;
                    db.SubmitChanges();

                    LoadData(txtTimKiemLop.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thất bại: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bt_xoa_lop_Click(object sender, EventArgs e)
        {
            string maLop;
            if (!CheckMaLop(out maLop))
            {
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xoá lớp mã " + maLop + "?",
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
                    var hasStudent = db.SinhViens.Any(s => s.MaLop == maLop);
                    if (hasStudent)
                    {
                        MessageBox.Show("Lớp đang có sinh viên, không thể xoá.", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var lop = db.LopHocs.FirstOrDefault(l => l.MaLop == maLop);
                    if (lop == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp để xoá.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.LopHocs.DeleteOnSubmit(lop);
                    db.SubmitChanges();
                }

                LoadData(txtTimKiemLop.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemLop_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTimKiemLop.Text);
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
