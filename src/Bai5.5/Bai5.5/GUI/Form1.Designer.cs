
namespace Bai5._5
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
            this.gbVatTu = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.lblTongGiaTriTon = new System.Windows.Forms.Label();
            this.gbPhieuKho = new System.Windows.Forms.GroupBox();
            this.rdoNhap = new System.Windows.Forms.RadioButton();
            this.rdoXuat = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.nmDonGia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.dgvChiTietPhieu = new System.Windows.Forms.DataGridView();
            this.lblTongTienPhieu = new System.Windows.Forms.Label();
            this.btnSavePhieu = new System.Windows.Forms.Button();
            this.nmNguongAnToan = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnCanhBaoTon = new System.Windows.Forms.Button();
            this.gbVatTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            this.gbPhieuKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            this.nmNguongAnToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVatTu
            // 
            this.gbVatTu.Controls.Add(this.lblTongGiaTriTon);
            this.gbVatTu.Controls.Add(this.dgvVatTu);
            this.gbVatTu.Controls.Add(this.btnSearch);
            this.gbVatTu.Controls.Add(this.label1);
            this.gbVatTu.Controls.Add(this.txtSearchKeyword);
            this.gbVatTu.Location = new System.Drawing.Point(12, 12);
            this.gbVatTu.Name = "gbVatTu";
            this.gbVatTu.Size = new System.Drawing.Size(321, 426);
            this.gbVatTu.TabIndex = 0;
            this.gbVatTu.TabStop = false;
            this.gbVatTu.Text = "Danh mục Vật tư && Tồn kho";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(610, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(8, 8);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Location = new System.Drawing.Point(140, 19);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(175, 20);
            this.txtSearchKeyword.TabIndex = 0;
            this.txtSearchKeyword.TextChanged += new System.EventHandler(this.txtSearchKeyword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập mã hoặc tên vật tư:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(306, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatTu.Location = new System.Drawing.Point(9, 74);
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.ReadOnly = true;
            this.dgvVatTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVatTu.Size = new System.Drawing.Size(306, 322);
            this.dgvVatTu.TabIndex = 3;
            this.dgvVatTu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVatTu_CellContentClick);
            // 
            // lblTongGiaTriTon
            // 
            this.lblTongGiaTriTon.AutoSize = true;
            this.lblTongGiaTriTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiaTriTon.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTongGiaTriTon.Location = new System.Drawing.Point(6, 399);
            this.lblTongGiaTriTon.Name = "lblTongGiaTriTon";
            this.lblTongGiaTriTon.Size = new System.Drawing.Size(192, 16);
            this.lblTongGiaTriTon.TabIndex = 4;
            this.lblTongGiaTriTon.Text = "Tổng giá trị tồn kho: 0 VNĐ";
            this.lblTongGiaTriTon.Click += new System.EventHandler(this.lblTongGiaTriTon_Click);
            // 
            // gbPhieuKho
            // 
            this.gbPhieuKho.Controls.Add(this.btnSavePhieu);
            this.gbPhieuKho.Controls.Add(this.lblTongTienPhieu);
            this.gbPhieuKho.Controls.Add(this.dgvChiTietPhieu);
            this.gbPhieuKho.Controls.Add(this.btnAddToList);
            this.gbPhieuKho.Controls.Add(this.label4);
            this.gbPhieuKho.Controls.Add(this.label3);
            this.gbPhieuKho.Controls.Add(this.nmDonGia);
            this.gbPhieuKho.Controls.Add(this.nmSoLuong);
            this.gbPhieuKho.Controls.Add(this.cboNCC);
            this.gbPhieuKho.Controls.Add(this.label2);
            this.gbPhieuKho.Controls.Add(this.rdoXuat);
            this.gbPhieuKho.Controls.Add(this.rdoNhap);
            this.gbPhieuKho.Location = new System.Drawing.Point(339, 12);
            this.gbPhieuKho.Name = "gbPhieuKho";
            this.gbPhieuKho.Size = new System.Drawing.Size(350, 349);
            this.gbPhieuKho.TabIndex = 2;
            this.gbPhieuKho.TabStop = false;
            this.gbPhieuKho.Text = "Thông tin Phiếu Kho";
            // 
            // rdoNhap
            // 
            this.rdoNhap.AutoSize = true;
            this.rdoNhap.Checked = true;
            this.rdoNhap.Location = new System.Drawing.Point(6, 20);
            this.rdoNhap.Name = "rdoNhap";
            this.rdoNhap.Size = new System.Drawing.Size(72, 17);
            this.rdoNhap.TabIndex = 0;
            this.rdoNhap.TabStop = true;
            this.rdoNhap.Text = "Nhập kho";
            this.rdoNhap.UseVisualStyleBackColor = true;
            this.rdoNhap.CheckedChanged += new System.EventHandler(this.rdoNhap_CheckedChanged);
            // 
            // rdoXuat
            // 
            this.rdoXuat.AutoSize = true;
            this.rdoXuat.Location = new System.Drawing.Point(126, 20);
            this.rdoXuat.Name = "rdoXuat";
            this.rdoXuat.Size = new System.Drawing.Size(68, 17);
            this.rdoXuat.TabIndex = 1;
            this.rdoXuat.Text = "Xuất kho";
            this.rdoXuat.UseVisualStyleBackColor = true;
            this.rdoXuat.CheckedChanged += new System.EventHandler(this.rdoXuat_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhà cung cấp:";
            // 
            // cboNCC
            // 
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(82, 43);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(129, 21);
            this.cboNCC.TabIndex = 3;
            this.cboNCC.SelectedIndexChanged += new System.EventHandler(this.cboNCC_SelectedIndexChanged);
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(82, 70);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(129, 20);
            this.nmSoLuong.TabIndex = 4;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.ValueChanged += new System.EventHandler(this.nmSoLuong_ValueChanged);
            // 
            // nmDonGia
            // 
            this.nmDonGia.Location = new System.Drawing.Point(82, 96);
            this.nmDonGia.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nmDonGia.Name = "nmDonGia";
            this.nmDonGia.Size = new System.Drawing.Size(129, 20);
            this.nmDonGia.TabIndex = 5;
            this.nmDonGia.ValueChanged += new System.EventHandler(this.nmDonGia_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đơn giá:";
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.LightBlue;
            this.btnAddToList.Location = new System.Drawing.Point(9, 122);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(202, 23);
            this.btnAddToList.TabIndex = 8;
            this.btnAddToList.Text = "Thêm vào phiếu";
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // dgvChiTietPhieu
            // 
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(9, 151);
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.ReadOnly = true;
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(335, 145);
            this.dgvChiTietPhieu.TabIndex = 9;
            this.dgvChiTietPhieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieu_CellContentClick);
            // 
            // lblTongTienPhieu
            // 
            this.lblTongTienPhieu.AutoSize = true;
            this.lblTongTienPhieu.BackColor = System.Drawing.Color.Red;
            this.lblTongTienPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPhieu.Location = new System.Drawing.Point(79, 299);
            this.lblTongTienPhieu.Name = "lblTongTienPhieu";
            this.lblTongTienPhieu.Size = new System.Drawing.Size(181, 18);
            this.lblTongTienPhieu.TabIndex = 10;
            this.lblTongTienPhieu.Text = "Tổng tiền phiếu: 0 VNĐ";
            this.lblTongTienPhieu.Click += new System.EventHandler(this.lblTongTienPhieu_Click);
            // 
            // btnSavePhieu
            // 
            this.btnSavePhieu.BackColor = System.Drawing.Color.LightGreen;
            this.btnSavePhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePhieu.Location = new System.Drawing.Point(82, 320);
            this.btnSavePhieu.Name = "btnSavePhieu";
            this.btnSavePhieu.Size = new System.Drawing.Size(178, 23);
            this.btnSavePhieu.TabIndex = 11;
            this.btnSavePhieu.Text = "LƯU PHIẾU KHO (TRANSACTION)";
            this.btnSavePhieu.UseVisualStyleBackColor = false;
            this.btnSavePhieu.Click += new System.EventHandler(this.btnSavePhieu_Click);
            // 
            // nmNguongAnToan
            // 
            this.nmNguongAnToan.Controls.Add(this.btnCanhBaoTon);
            this.nmNguongAnToan.Controls.Add(this.numericUpDown1);
            this.nmNguongAnToan.Controls.Add(this.label5);
            this.nmNguongAnToan.Location = new System.Drawing.Point(339, 367);
            this.nmNguongAnToan.Name = "nmNguongAnToan";
            this.nmNguongAnToan.Size = new System.Drawing.Size(350, 71);
            this.nmNguongAnToan.TabIndex = 3;
            this.nmNguongAnToan.TabStop = false;
            this.nmNguongAnToan.Text = "Cảnh báo tồn kho";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngưỡng an toàn <=:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(114, 23);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnCanhBaoTon
            // 
            this.btnCanhBaoTon.BackColor = System.Drawing.Color.Orange;
            this.btnCanhBaoTon.Location = new System.Drawing.Point(9, 41);
            this.btnCanhBaoTon.Name = "btnCanhBaoTon";
            this.btnCanhBaoTon.Size = new System.Drawing.Size(225, 23);
            this.btnCanhBaoTon.TabIndex = 2;
            this.btnCanhBaoTon.Text = "Lọc tồn kho dưới ngưỡng";
            this.btnCanhBaoTon.UseVisualStyleBackColor = false;
            this.btnCanhBaoTon.Click += new System.EventHandler(this.btnCanhBaoTon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.nmNguongAnToan);
            this.Controls.Add(this.gbPhieuKho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbVatTu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ XUẤT - NHẬP KHO NGUYÊN VẬT LIỆU";
            this.gbVatTu.ResumeLayout(false);
            this.gbVatTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            this.gbPhieuKho.ResumeLayout(false);
            this.gbPhieuKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            this.nmNguongAnToan.ResumeLayout(false);
            this.nmNguongAnToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVatTu;
        private System.Windows.Forms.Label lblTongGiaTriTon;
        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbPhieuKho;
        private System.Windows.Forms.Button btnSavePhieu;
        private System.Windows.Forms.Label lblTongTienPhieu;
        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmDonGia;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoXuat;
        private System.Windows.Forms.RadioButton rdoNhap;
        private System.Windows.Forms.GroupBox nmNguongAnToan;
        private System.Windows.Forms.Button btnCanhBaoTon;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
    }
}

