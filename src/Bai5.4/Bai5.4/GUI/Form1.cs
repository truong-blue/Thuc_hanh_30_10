using System;
using System.Data;
using System.Windows.Forms;
using Bai5._4.BUS;
using Bai5._4.DTO;

namespace Bai5._4
{
    public partial class Form1 : Form
    {
        private HotelBUS hotelBUS = new HotelBUS();
        private DataTable dtPhong;
        private DataView dvPhong;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN (HOTEL MANAGEMENT SYSTEM)";

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // 1. Nạp danh sách Phòng ngắt kết nối dùng DataView
                dtPhong = hotelBUS.GetListPhong();
                dvPhong = new DataView(dtPhong);
                dgvPhong.DataSource = dvPhong;

                // 2. Nạp ComboBox Dịch vụ
                cboDichVu.DataSource = hotelBUS.GetListDichVu();
                cboDichVu.DisplayMember = "TenDV";
                cboDichVu.ValueMember = "MaDV";

                // 3. Nạp ComboBox Bộ Lọc ngắt kết nối
                cboFilterLoaiPhong.Items.Clear();
                cboFilterLoaiPhong.Items.AddRange(new string[] { "Tất cả", "Đơn", "Đôi", "VIP" });
                cboFilterLoaiPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL HotelDB: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LỌC DỮ LIỆU NGẮT KẾT NỐI TRÊN DATAVIEW
        private void cboFilterLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dvPhong == null || cboFilterLoaiPhong.SelectedItem == null) return;

            string selected = cboFilterLoaiPhong.SelectedItem.ToString();
            if (selected == "Tất cả")
            {
                dvPhong.RowFilter = "";
            }
            else
            {
                dvPhong.RowFilter = $"LoaiPhong = '{selected}'";
            }
        }

        // TRA CỨU KHÁCH HÀNG THEO CCCD
        private void btnSearchCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập số CCCD để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO kh = hotelBUS.GetKhachHangByCCCD(cccd);
            if (kh != null)
            {
                txtHoTen.Text = kh.HoTen;
                txtSDT.Text = kh.SoDienThoai;
                MessageBox.Show("Tìm thấy thông tin khách hàng cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Khách hàng mới! Vui lòng nhập Họ tên và SĐT.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
            }
        }

        // NHẬN PHÒNG (CHECK-IN)
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần Check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và CCCD của khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
            string trangThai = dgvPhong.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai != "Trống")
            {
                MessageBox.Show("Chỉ được nhận phòng có trạng thái Trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            hotelBUS.CheckIn(soPhong, txtHoTen.Text.Trim(), txtCCCD.Text.Trim(), txtSDT.Text.Trim());
            MessageBox.Show($"Check-in thành công cho phòng {soPhong}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        // GỌI DỊCH VỤ
        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;

            string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
            string trangThai = dgvPhong.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai != "Đang ở")
            {
                MessageBox.Show("Chỉ có thể thêm dịch vụ cho phòng đang trạng thái 'Đang ở'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDichVu.SelectedValue == null) return;

            int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
            int soLuong = (int)nmSoLuongDV.Value;

            hotelBUS.AddSuDungDichVu(soPhong, maDV, soLuong);
            MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reload danh sách dịch vụ đã dùng
            int maPhieu;
            dgvDichVuDaDung.DataSource = hotelBUS.GetSuDungDichVuByPhong(soPhong, out maPhieu);
        }

        // CHECK-OUT & XUẤT HÓA ĐƠN
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;

            string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
            string trangThai = dgvPhong.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai != "Đang ở")
            {
                MessageBox.Show("Chỉ có thể Check-out cho phòng đang có trạng thái 'Đang ở'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaTheoGio = Convert.ToDecimal(dgvPhong.CurrentRow.Cells["GiaTheoGio"].Value);

            DialogResult dr = MessageBox.Show($"Xác nhận thanh toán và Check-out cho phòng {soPhong}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                decimal tongTien;
                bool ok = hotelBUS.CheckOut(soPhong, giaTheoGio, out tongTien);

                if (ok)
                {
                    MessageBox.Show($"Thanh toán & Check-out thành công cho {soPhong}!\nTổng tiền thanh toán: {tongTien:N0} VNĐ\nTrạng thái phòng chuyển sang 'Đang dọn dẹp'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Phòng này hiện chưa có phiếu đặt phòng hoạt động!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow != null && dgvPhong.CurrentRow.Cells["SoPhong"].Value != null)
            {
                string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
                int maPhieu;
                dgvDichVuDaDung.DataSource = hotelBUS.GetSuDungDichVuByPhong(soPhong, out maPhieu);
            }
        }

        // ==============================================================
        // GIỮ LẠI CÁC HÀM SỰ KIỆN RỖNG ĐỂ TRÁNH LỖI DESIGNER
        // ==============================================================
        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtCCCD_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuongDV_ValueChanged(object sender, EventArgs e) { }
        private void dgvDichVuDaDung_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}