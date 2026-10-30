using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bai5._5.BUS;
using Bai5._5.DTO;

namespace Bai5._5
{
    public partial class Form1 : Form
    {
        private InventoryBUS inventoryBUS = new InventoryBUS();
        private List<ChiTietPhieuKhoDTO> listChiTietTam = new List<ChiTietPhieuKhoDTO>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ XUẤT - NHẬP KHO NGUYÊN VẬT LIỆU";

            rdoNhap.Checked = true;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvVatTu.DataSource = inventoryBUS.GetListVatTu();
                if (dgvVatTu.Columns["SoLuongTon"] != null)
                {
                    dgvVatTu.Columns["SoLuongTon"].DefaultCellStyle.Format = "N2";
                }
                cboNCC.DataSource = inventoryBUS.GetListNhaCungCap();
                cboNCC.DisplayMember = "TenNCC";
                cboNCC.ValueMember = "MaNCC";
                decimal tongGiaTri = inventoryBUS.GetTongGiaTriTonKho();
                lblTongGiaTriTon.Text = $"Tổng giá trị tồn kho: {tongGiaTri:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL InventoryDB: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rdoNhap_CheckedChanged(object sender, EventArgs e)
        {
            cboNCC.Enabled = rdoNhap.Checked;
        }

        private void rdoXuat_CheckedChanged(object sender, EventArgs e)
        {
            cboNCC.Enabled = !rdoXuat.Checked;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearchKeyword.Text.Trim();
            dgvVatTu.DataSource = inventoryBUS.SearchVatTu(kw);
        }
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (dgvVatTu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư từ bảng bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maVT = dgvVatTu.CurrentRow.Cells["MaVatTu"].Value.ToString();
            string tenVT = dgvVatTu.CurrentRow.Cells["TenVatTu"].Value.ToString();
            decimal soLuong = nmSoLuong.Value;
            decimal donGia = nmDonGia.Value;

            if (soLuong <= 0 || donGia < 0)
            {
                MessageBox.Show("Số lượng phải > 0 và đơn giá >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listChiTietTam.Add(new ChiTietPhieuKhoDTO
            {
                MaVatTu = maVT,
                TenVatTu = tenVT,
                SoLuong = soLuong,
                DonGia = donGia
            });

            BindGridChiTietTam();
        }

        private void BindGridChiTietTam()
        {
            dgvChiTietPhieu.DataSource = null;
            dgvChiTietPhieu.DataSource = listChiTietTam;

            decimal tongTien = 0;
            foreach (var item in listChiTietTam) tongTien += item.ThanhTien;
            lblTongTienPhieu.Text = $"Tổng tiền phiếu: {tongTien:N0} VNĐ";
        }
        private void btnSavePhieu_Click(object sender, EventArgs e)
        {
            if (listChiTietTam.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 vật tư vào phiếu kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiPhieu = rdoNhap.Checked ? "NHAP" : "XUAT";
            int? maNCC = rdoNhap.Checked ? Convert.ToInt32(cboNCC.SelectedValue) : (int?)null;

            string error = "";
            bool ok = inventoryBUS.LapPhieuKho(loaiPhieu, maNCC, listChiTietTam, out error);

            if (ok)
            {
                MessageBox.Show($"Lập phiếu kho [{loaiPhieu}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listChiTietTam.Clear();
                BindGridChiTietTam();
                LoadData();
            }
            else
            {
                MessageBox.Show("Lập phiếu kho thất bại!\nChi tiết: " + error, "Lỗi Transaction (Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCanhBaoTon_Click(object sender, EventArgs e)
        {
            decimal nguong = numericUpDown1.Value;
            DataTable dtSapHet = inventoryBUS.GetVatTuSapHet(nguong);
            dgvVatTu.DataSource = dtSapHet;
            MessageBox.Show($"Đã lọc ra {dtSapHet.Rows.Count} vật tư có số lượng tồn <= {nguong}!", "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void txtSearchKeyword_TextChanged(object sender, EventArgs e) { }
        private void dgvVatTu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTongGiaTriTon_Click(object sender, EventArgs e) { }
        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuong_ValueChanged(object sender, EventArgs e) { }
        private void nmDonGia_ValueChanged(object sender, EventArgs e) { }
        private void dgvChiTietPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTongTienPhieu_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
    }
}