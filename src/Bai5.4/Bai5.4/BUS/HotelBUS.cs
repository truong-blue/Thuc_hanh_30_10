using System;
using System.Data;
using Bai5._4.DAL;
using Bai5._4.DTO;

namespace Bai5._4.BUS
{
    public class HotelBUS
    {
        private HotelDAL hotelDAL = new HotelDAL();

        public DataTable GetListPhong() => hotelDAL.GetListPhong();
        public DataTable GetListDichVu() => hotelDAL.GetListDichVu();

        public KhachHangDTO GetKhachHangByCCCD(string cccd) => hotelDAL.GetKhachHangByCCCD(cccd);

        public int CheckIn(string soPhong, string hoTen, string cccd, string sdt)
        {
            KhachHangDTO kh = hotelDAL.GetKhachHangByCCCD(cccd);
            int maKH = kh != null ? kh.MaKH : hotelDAL.InsertKhachHang(new KhachHangDTO { HoTen = hoTen, CCCD = cccd, SoDienThoai = sdt });

            hotelDAL.CheckIn(soPhong, maKH);
            return maKH;
        }

        public void AddSuDungDichVu(string soPhong, int maDV, int soLuong)
        {
            int maPhieu = hotelDAL.GetActivePhieuByPhong(soPhong);
            if (maPhieu != -1)
            {
                hotelDAL.AddSuDungDichVu(maPhieu, maDV, soLuong);
            }
        }

        public DataTable GetSuDungDichVuByPhong(string soPhong, out int maPhieu)
        {
            maPhieu = hotelDAL.GetActivePhieuByPhong(soPhong);
            if (maPhieu != -1)
            {
                return hotelDAL.GetSuDungDichVuByPhieu(maPhieu);
            }
            return new DataTable();
        }

        public bool CheckOut(string soPhong, decimal giaTheoGio, out decimal tongTien)
        {
            tongTien = 0;
            int maPhieu = hotelDAL.GetActivePhieuByPhong(soPhong);
            if (maPhieu == -1) return false;

            // Tính tiền dịch vụ
            DataTable dtDV = hotelDAL.GetSuDungDichVuByPhieu(maPhieu);
            decimal tienDV = 0;
            foreach (DataRow r in dtDV.Rows)
            {
                tienDV += Convert.ToDecimal(r["ThanhTien"]);
            }

            // Tính tiền phòng (Giả định tối thiểu 1 giờ)
            decimal tienPhong = giaTheoGio * 2; // Ví dụ tạm tính 2 giờ ở
            tongTien = tienPhong + tienDV;

            return hotelDAL.CheckOutTransaction(maPhieu, soPhong, tongTien);
        }
    }
}