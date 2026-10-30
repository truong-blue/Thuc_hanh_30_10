using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5._5.DTO
{
    public class ChiTietPhieuKhoDTO
    {
        public int MaPhieu { get; set; }
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
