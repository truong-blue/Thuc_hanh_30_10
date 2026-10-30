using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Bai5._5.DTO;

namespace Bai5._5.DAL
{
    public class InventoryDAL : DatabaseAccess
    {
        // 1. Lấy danh sách Vật tư
        public DataTable GetListVatTu() => ExecuteQuery("SELECT * FROM VatTu");

        // 2. Tìm kiếm Vật tư (Chống SQL Injection với SqlParameter)
        public DataTable SearchVatTu(string keyword)
        {
            string query = "SELECT * FROM VatTu WHERE MaVatTu LIKE @kw OR TenVatTu LIKE @kw";
            MySqlParameter[] p = { new MySqlParameter("@kw", "%" + keyword + "%") };
            return ExecuteQuery(query, p);
        }

        // 3. Lấy danh sách Nhà cung cấp
        public DataTable GetListNhaCungCap() => ExecuteQuery("SELECT * FROM NhaCungCap");

        // 4. Lấy các Vật tư tồn dưới ngưỡng an toàn
        public DataTable GetVatTuSapHet(decimal nguoangAnToan)
        {
            string query = "SELECT * FROM VatTu WHERE SoLuongTon <= @Ngong";
            MySqlParameter[] p = { new MySqlParameter("@Ngong", nguoangAnToan) };
            return ExecuteQuery(query, p);
        }

        // 5. Tính tổng giá trị hàng tồn kho (Dùng ExecuteScalar)
        public decimal GetTongGiaTriTonKho()
        {
            string query = @"SELECT IFNULL(SUM(v.SoLuongTon * IFNULL((
                                SELECT ct.DonGia FROM ChiTietPhieuKho ct WHERE ct.MaVatTu = v.MaVatTu ORDER BY ct.MaPhieu DESC LIMIT 1
                             ), 0)), 0) FROM VatTu v";
            object res = ExecuteScalar(query);
            return Convert.ToDecimal(res);
        }

        // 6. LẬP PHIẾU KHỎ (SỬ DỤNG TRANSACTION ĐẢM BẢO ACID)
        public bool LapPhieuKhoTransaction(string loaiPhieu, int? maNCC, List<ChiTietPhieuKhoDTO> listChiTiet, out string errorMessage)
        {
            errorMessage = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Tính tổng tiền phiếu kho
                    decimal tongTien = 0;
                    foreach (var item in listChiTiet) tongTien += item.ThanhTien;

                    // Bước 1: Chèn vào PhieuKho
                    string q1 = "INSERT INTO PhieuKho (LoaiPhieu, NgayLap, MaNCC, TongTien) VALUES (@Loai, NOW(), @MaNCC, @TongTien); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@Loai", loaiPhieu);
                    cmd1.Parameters.AddWithValue("@MaNCC", (object)maNCC ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@TongTien", tongTien);
                    int maPhieu = Convert.ToInt32(cmd1.ExecuteScalar());

                    // Bước 2 & 3: Lặp qua từng chi tiết vật tư
                    foreach (var ct in listChiTiet)
                    {
                        // Chèn ChiTietPhieuKho
                        string q2 = "INSERT INTO ChiTietPhieuKho (MaPhieu, MaVatTu, SoLuong, DonGia) VALUES (@MaPhieu, @MaVatTu, @SoLuong, @DonGia)";
                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                        cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmd2.Parameters.AddWithValue("@MaVatTu", ct.MaVatTu);
                        cmd2.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmd2.Parameters.AddWithValue("@DonGia", ct.DonGia);
                        cmd2.ExecuteNonQuery();

                        // Cập nhật tồn kho VatTu
                        if (loaiPhieu == "NHAP")
                        {
                            string q3 = "UPDATE VatTu SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmd3 = new MySqlCommand(q3, conn, trans);
                            cmd3.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                            cmd3.Parameters.AddWithValue("@MaVatTu", ct.MaVatTu);
                            cmd3.ExecuteNonQuery();
                        }
                        else if (loaiPhieu == "XUAT")
                        {
                            // Kiểm tra số lượng tồn kho hiện tại
                            string qCheck = "SELECT SoLuongTon FROM VatTu WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmdCheck = new MySqlCommand(qCheck, conn, trans);
                            cmdCheck.Parameters.AddWithValue("@MaVatTu", ct.MaVatTu);
                            decimal tonHienTai = Convert.ToDecimal(cmdCheck.ExecuteScalar());

                            if (tonHienTai < ct.SoLuong)
                            {
                                trans.Rollback(); // Hoàn tác nếu không đủ hàng
                                errorMessage = $"Vật tư [{ct.MaVatTu}] không đủ hàng tồn kho! (Tồn hiện tại: {tonHienTai}, Cần xuất: {ct.SoLuong})";
                                return false;
                            }

                            string q3 = "UPDATE VatTu SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaVatTu = @MaVatTu";
                            MySqlCommand cmd3 = new MySqlCommand(q3, conn, trans);
                            cmd3.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                            cmd3.Parameters.AddWithValue("@MaVatTu", ct.MaVatTu);
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    trans.Commit(); // Gọi Commit khi thành công 100%
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}