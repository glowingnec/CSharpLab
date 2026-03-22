namespace Winform1
{
    partial class Class
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Class));
            this.txtTimKiemLop = new System.Windows.Forms.TextBox();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.label_lop = new System.Windows.Forms.Label();
            this.bt_xoa_lop = new System.Windows.Forms.Button();
            this.bt_sua_lop = new System.Windows.Forms.Button();
            this.bt_them_lop = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2_Lop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiemLop
            // 
            this.txtTimKiemLop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemLop.Location = new System.Drawing.Point(94, 14);
            this.txtTimKiemLop.Name = "txtTimKiemLop";
            this.txtTimKiemLop.Size = new System.Drawing.Size(209, 30);
            this.txtTimKiemLop.TabIndex = 2;
            this.txtTimKiemLop.TextChanged += new System.EventHandler(this.txtTimKiemLop_TextChanged);
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Location = new System.Drawing.Point(13, 60);
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.RowHeadersWidth = 51;
            this.dgvLopHoc.RowTemplate.Height = 24;
            this.dgvLopHoc.Size = new System.Drawing.Size(708, 399);
            this.dgvLopHoc.TabIndex = 0;
            // 
            // label_lop
            // 
            this.label_lop.AutoSize = true;
            this.label_lop.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lop.Location = new System.Drawing.Point(23, 15);
            this.label_lop.Name = "label_lop";
            this.label_lop.Size = new System.Drawing.Size(142, 25);
            this.label_lop.TabIndex = 3;
            this.label_lop.Text = "Quản lý lớp học";
            this.label_lop.Click += new System.EventHandler(this.label1_Click);
            // 
            // bt_xoa_lop
            // 
            this.bt_xoa_lop.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_xoa_lop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_xoa_lop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xoa_lop.ForeColor = System.Drawing.Color.White;
            this.bt_xoa_lop.Location = new System.Drawing.Point(28, 174);
            this.bt_xoa_lop.Name = "bt_xoa_lop";
            this.bt_xoa_lop.Size = new System.Drawing.Size(143, 35);
            this.bt_xoa_lop.TabIndex = 2;
            this.bt_xoa_lop.Text = "Xoá lớp";
            this.bt_xoa_lop.UseVisualStyleBackColor = false;
            this.bt_xoa_lop.Click += new System.EventHandler(this.bt_xoa_lop_Click);
            // 
            // bt_sua_lop
            // 
            this.bt_sua_lop.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_sua_lop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_sua_lop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sua_lop.ForeColor = System.Drawing.Color.White;
            this.bt_sua_lop.Location = new System.Drawing.Point(28, 118);
            this.bt_sua_lop.Name = "bt_sua_lop";
            this.bt_sua_lop.Size = new System.Drawing.Size(143, 35);
            this.bt_sua_lop.TabIndex = 1;
            this.bt_sua_lop.Text = "Sửa thông tin lớp";
            this.bt_sua_lop.UseVisualStyleBackColor = false;
            this.bt_sua_lop.Click += new System.EventHandler(this.bt_sua_lop_Click);
            // 
            // bt_them_lop
            // 
            this.bt_them_lop.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_them_lop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_them_lop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_them_lop.ForeColor = System.Drawing.Color.White;
            this.bt_them_lop.Location = new System.Drawing.Point(28, 60);
            this.bt_them_lop.Name = "bt_them_lop";
            this.bt_them_lop.Size = new System.Drawing.Size(143, 35);
            this.bt_them_lop.TabIndex = 0;
            this.bt_them_lop.Text = "Thêm lớp";
            this.bt_them_lop.UseVisualStyleBackColor = false;
            this.bt_them_lop.Click += new System.EventHandler(this.bt_them_lop_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer2.Panel1.Controls.Add(this.label_lop);
            this.splitContainer2.Panel1.Controls.Add(this.bt_xoa_lop);
            this.splitContainer2.Panel1.Controls.Add(this.bt_sua_lop);
            this.splitContainer2.Panel1.Controls.Add(this.bt_them_lop);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer2.Panel2.Controls.Add(this.label2_Lop);
            this.splitContainer2.Panel2.Controls.Add(this.txtTimKiemLop);
            this.splitContainer2.Panel2.Controls.Add(this.dgvLopHoc);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(945, 471);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 1;
            // 
            // label2_Lop
            // 
            this.label2_Lop.AutoSize = true;
            this.label2_Lop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_Lop.Location = new System.Drawing.Point(9, 18);
            this.label2_Lop.Name = "label2_Lop";
            this.label2_Lop.Size = new System.Drawing.Size(79, 23);
            this.label2_Lop.TabIndex = 3;
            this.label2_Lop.Text = "Tìm kiếm";
            // 
            // Class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 471);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Class";
            this.Text = "QLLH";
            this.Load += new System.EventHandler(this.Class_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiemLop;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.Label label_lop;
        private System.Windows.Forms.Button bt_xoa_lop;
        private System.Windows.Forms.Button bt_sua_lop;
        private System.Windows.Forms.Button bt_them_lop;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2_Lop;
    }
}