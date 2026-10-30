
namespace Bai5._4
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
            this.gbRoom = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFilterLoaiPhong = new System.Windows.Forms.ComboBox();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.btnSearchCCCD = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.nmSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.btnAddService = new System.Windows.Forms.Button();
            this.dgvDichVuDaDung = new System.Windows.Forms.DataGridView();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.gbRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.gbCustomer.SuspendLayout();
            this.gbService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRoom
            // 
            this.gbRoom.Controls.Add(this.dgvPhong);
            this.gbRoom.Controls.Add(this.cboFilterLoaiPhong);
            this.gbRoom.Controls.Add(this.label1);
            this.gbRoom.Location = new System.Drawing.Point(12, 12);
            this.gbRoom.Name = "gbRoom";
            this.gbRoom.Size = new System.Drawing.Size(448, 587);
            this.gbRoom.TabIndex = 0;
            this.gbRoom.TabStop = false;
            this.gbRoom.Text = "Quản lý && Lọc danh sách phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại phòng:";
            // 
            // cboFilterLoaiPhong
            // 
            this.cboFilterLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterLoaiPhong.FormattingEnabled = true;
            this.cboFilterLoaiPhong.Location = new System.Drawing.Point(75, 19);
            this.cboFilterLoaiPhong.Name = "cboFilterLoaiPhong";
            this.cboFilterLoaiPhong.Size = new System.Drawing.Size(121, 21);
            this.cboFilterLoaiPhong.TabIndex = 1;
            this.cboFilterLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cboFilterLoaiPhong_SelectedIndexChanged);
            // 
            // dgvPhong
            // 
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(9, 46);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(433, 535);
            this.dgvPhong.TabIndex = 2;
            this.dgvPhong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellContentClick);
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.btnCheckIn);
            this.gbCustomer.Controls.Add(this.txtSDT);
            this.gbCustomer.Controls.Add(this.txtHoTen);
            this.gbCustomer.Controls.Add(this.btnSearchCCCD);
            this.gbCustomer.Controls.Add(this.txtCCCD);
            this.gbCustomer.Controls.Add(this.label4);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Location = new System.Drawing.Point(466, 12);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(284, 164);
            this.gbCustomer.TabIndex = 1;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Thông tin Khách hàng && Check-in";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số CCCD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Họ và tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số điện thoại:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(79, 22);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(184, 20);
            this.txtCCCD.TabIndex = 3;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            // 
            // btnSearchCCCD
            // 
            this.btnSearchCCCD.Location = new System.Drawing.Point(9, 101);
            this.btnSearchCCCD.Name = "btnSearchCCCD";
            this.btnSearchCCCD.Size = new System.Drawing.Size(254, 23);
            this.btnSearchCCCD.TabIndex = 4;
            this.btnSearchCCCD.Text = "Tìm";
            this.btnSearchCCCD.UseVisualStyleBackColor = true;
            this.btnSearchCCCD.Click += new System.EventHandler(this.btnSearchCCCD_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(79, 48);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(184, 20);
            this.txtHoTen.TabIndex = 5;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(79, 75);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(184, 20);
            this.txtSDT.TabIndex = 6;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckIn.Location = new System.Drawing.Point(9, 130);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(254, 23);
            this.btnCheckIn.TabIndex = 7;
            this.btnCheckIn.Text = "Check-in (Nhận phòng)";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // gbService
            // 
            this.gbService.Controls.Add(this.btnCheckOut);
            this.gbService.Controls.Add(this.dgvDichVuDaDung);
            this.gbService.Controls.Add(this.btnAddService);
            this.gbService.Controls.Add(this.nmSoLuongDV);
            this.gbService.Controls.Add(this.cboDichVu);
            this.gbService.Controls.Add(this.label6);
            this.gbService.Controls.Add(this.label5);
            this.gbService.Location = new System.Drawing.Point(466, 182);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(541, 417);
            this.gbService.TabIndex = 2;
            this.gbService.TabStop = false;
            this.gbService.Text = "Dịch vụ && Sử dụng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dịch vụ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số lượng:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(79, 19);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(184, 21);
            this.cboDichVu.TabIndex = 2;
            this.cboDichVu.SelectedIndexChanged += new System.EventHandler(this.cboDichVu_SelectedIndexChanged);
            // 
            // nmSoLuongDV
            // 
            this.nmSoLuongDV.Location = new System.Drawing.Point(79, 46);
            this.nmSoLuongDV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongDV.Name = "nmSoLuongDV";
            this.nmSoLuongDV.Size = new System.Drawing.Size(184, 20);
            this.nmSoLuongDV.TabIndex = 3;
            this.nmSoLuongDV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongDV.ValueChanged += new System.EventHandler(this.nmSoLuongDV_ValueChanged);
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(9, 72);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(254, 23);
            this.btnAddService.TabIndex = 4;
            this.btnAddService.Text = "Thêm Dịch Vụ";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // dgvDichVuDaDung
            // 
            this.dgvDichVuDaDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDichVuDaDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaDung.Location = new System.Drawing.Point(9, 101);
            this.dgvDichVuDaDung.Name = "dgvDichVuDaDung";
            this.dgvDichVuDaDung.Size = new System.Drawing.Size(526, 255);
            this.dgvDichVuDaDung.TabIndex = 5;
            this.dgvDichVuDaDung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVuDaDung_CellContentClick);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Orange;
            this.btnCheckOut.Location = new System.Drawing.Point(9, 362);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(491, 49);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Check-out && Xuất Hóa Đơn";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 611);
            this.Controls.Add(this.gbService);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.gbRoom);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN (HOTEL MANAGEMENT SYSTEM)";
            this.gbRoom.ResumeLayout(false);
            this.gbRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRoom;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.ComboBox cboFilterLoaiPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Button btnSearchCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.DataGridView dgvDichVuDaDung;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.NumericUpDown nmSoLuongDV;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

