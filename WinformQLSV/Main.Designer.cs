namespace Winform1
{
    partial class Main
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
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.bt_them_sv = new System.Windows.Forms.Button();
            this.bt_sua_sv = new System.Windows.Forms.Button();
            this.bt_xoa_sv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(13, 47);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.RowTemplate.Height = 24;
            this.dgvSinhVien.Size = new System.Drawing.Size(719, 412);
            this.dgvSinhVien.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.Location = new System.Drawing.Point(78, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(209, 22);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // bt_them_sv
            // 
            this.bt_them_sv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bt_them_sv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_them_sv.ForeColor = System.Drawing.Color.Cornsilk;
            this.bt_them_sv.Location = new System.Drawing.Point(27, 47);
            this.bt_them_sv.Name = "bt_them_sv";
            this.bt_them_sv.Size = new System.Drawing.Size(143, 35);
            this.bt_them_sv.TabIndex = 0;
            this.bt_them_sv.Text = "Thêm sinh viên";
            this.bt_them_sv.UseVisualStyleBackColor = false;
            this.bt_them_sv.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bt_sua_sv
            // 
            this.bt_sua_sv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bt_sua_sv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sua_sv.ForeColor = System.Drawing.Color.Cornsilk;
            this.bt_sua_sv.Location = new System.Drawing.Point(27, 102);
            this.bt_sua_sv.Name = "bt_sua_sv";
            this.bt_sua_sv.Size = new System.Drawing.Size(143, 35);
            this.bt_sua_sv.TabIndex = 1;
            this.bt_sua_sv.Text = "Sửa thông tin SV";
            this.bt_sua_sv.UseVisualStyleBackColor = false;
            this.bt_sua_sv.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_xoa_sv
            // 
            this.bt_xoa_sv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bt_xoa_sv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xoa_sv.ForeColor = System.Drawing.Color.Cornsilk;
            this.bt_xoa_sv.Location = new System.Drawing.Point(27, 161);
            this.bt_xoa_sv.Name = "bt_xoa_sv";
            this.bt_xoa_sv.Size = new System.Drawing.Size(143, 35);
            this.bt_xoa_sv.TabIndex = 2;
            this.bt_xoa_sv.Text = "Xoá sinh viên";
            this.bt_xoa_sv.UseVisualStyleBackColor = false;
            this.bt_xoa_sv.Click += new System.EventHandler(this.bt_xoa_sv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Phần mềm QLSV";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.bt_xoa_sv);
            this.splitContainer2.Panel1.Controls.Add(this.bt_sua_sv);
            this.splitContainer2.Panel1.Controls.Add(this.bt_them_sv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.txtTimKiem);
            this.splitContainer2.Panel2.Controls.Add(this.dgvSinhVien);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(945, 471);
            this.splitContainer2.SplitterDistance = 197;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 471);
            this.Controls.Add(this.splitContainer2);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button bt_them_sv;
        private System.Windows.Forms.Button bt_sua_sv;
        private System.Windows.Forms.Button bt_xoa_sv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
    }
}