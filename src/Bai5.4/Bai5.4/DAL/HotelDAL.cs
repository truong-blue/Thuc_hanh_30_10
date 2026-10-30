using System;
using System.Data;
using MySql.Data.MySqlClient;
using Bai5._4.DTO;

namespace Bai5._4.DAL
{
    public class HotelDAL : DatabaseAccess
    {
        // Lấy danh sách toàn bộ Phòng
        public DataTable GetListPhong()
        {
            return ExecuteQuery("SELECT * FROM Phong");
        }

        // Tìm khách hàng theo CCCD (SqlParameter)
        public KhachHangDTO GetKhachHangByCCCD(string cccd)
        {
            string query = "SELECT * FROM KhachHang WHERE CCCD = @CCCD";
            MySqlParameter[] p = { new MySqlParameter("@CCCD", cccd) };
            DataTable dt = ExecuteQuery(query, p);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    HoTen = r["HoTen"].ToString(),
                    CCCD = r["CCCD"].ToString(),
                    SoDienThoai = r["SoDienThoai"].ToString()
                };
            }
            return null;
        }

        // Thêm khách hàng mới
        public int InsertKhachHang(KhachHangDTO kh)
        {
            string query = "INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@HoTen, @CCCD, @SDT); SELECT LAST_INSERT_ID();";
            MySqlParameter[] p = {
                new MySqlParameter("@HoTen", kh.HoTen),
                new MySqlParameter("@CCCD", kh.CCCD),
                new MySqlParameter("@SDT", kh.SoDienThoai)
            };
            return Convert.ToInt32(ExecuteScalar(query, p));
        }

        // Lập phiếu nhận phòng (Check-in)
        public void CheckIn(string soPhong, int maKH)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Thêm Phiếu đặt phòng
                    string q1 = "INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong, TrangThai) VALUES (@SoPhong, @MaKH, NOW(), 0)";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmd1.Parameters.AddWithValue("@MaKH", maKH);
                    cmd1.ExecuteNonQuery();

                    // 2. Chuyển trạng thái phòng sang "Đang ở"
                    string q2 = "UPDATE Phong SET TrangThai = 'Đang ở' WHERE SoPhong = @SoPhong";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // Thêm dịch vụ sử dụng
        public void AddSuDungDichVu(int maPhieu, int maDV, int soLuong)
        {
            string query = "INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) VALUES (@MaPhieu, @MaDV, @SoLuong, NOW())";
            MySqlParameter[] p = {
                new MySqlParameter("@MaPhieu", maPhieu),
                new MySqlParameter("@MaDV", maDV),
                new MySqlParameter("@SoLuong", soLuong)
            };
            ExecuteNonQuery(query, p);
        }

        // Lấy mã phiếu active của phòng
        public int GetActivePhieuByPhong(string soPhong)
        {
            string query = "SELECT MaPhieu FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND TrangThai = 0";
            MySqlParameter[] p = { new MySqlParameter("@SoPhong", soPhong) };
            object result = ExecuteScalar(query, p);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Lấy chi tiết dịch vụ đã dùng của phiếu
        public DataTable GetSuDungDichVuByPhieu(int maPhieu)
        {
            string query = @"SELECT dv.TenDV, sd.SoLuong, dv.DonGia, (sd.SoLuong * dv.DonGia) AS ThanhTien, sd.ThoiGian
                             FROM SuDungDichVu sd
                             JOIN DichVu dv ON sd.MaDV = dv.MaDV
                             WHERE sd.MaPhieu = @MaPhieu";
            MySqlParameter[] p = { new MySqlParameter("@MaPhieu", maPhieu) };
            return ExecuteQuery(query, p);
        }

        public DataTable GetListDichVu()
        {
            return ExecuteQuery("SELECT * FROM DichVu");
        }

        // Check-out & Xuất hóa đơn (SqlTransaction)
        public bool CheckOutTransaction(int maPhieu, string soPhong, decimal tongTien)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Cập nhật phiếu đặt phòng
                    string q1 = "UPDATE PhieuDatPhong SET NgayTraPhong = NOW(), TongTienThanhToan = @TongTien, TrangThai = 1 WHERE MaPhieu = @MaPhieu";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd1.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd1.ExecuteNonQuery();

                    // 2. Chuyển trạng thái phòng sang "Đang dọn dẹp"
                    string q2 = "UPDATE Phong SET TrangThai = 'Đang dọn dẹp' WHERE SoPhong = @SoPhong";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}