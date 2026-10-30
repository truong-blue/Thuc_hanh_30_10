using System.Collections.Generic;
using System.Data;
using Bai5._5.DAL;
using Bai5._5.DTO;

namespace Bai5._5.BUS
{
    public class InventoryBUS
    {
        private InventoryDAL inventoryDAL = new InventoryDAL();

        public DataTable GetListVatTu() => inventoryDAL.GetListVatTu();
        public DataTable SearchVatTu(string keyword) => inventoryDAL.SearchVatTu(keyword);
        public DataTable GetListNhaCungCap() => inventoryDAL.GetListNhaCungCap();
        public DataTable GetVatTuSapHet(decimal nguong) => inventoryDAL.GetVatTuSapHet(nguong);
        public decimal GetTongGiaTriTonKho() => inventoryDAL.GetTongGiaTriTonKho();

        public bool LapPhieuKho(string loaiPhieu, int? maNCC, List<ChiTietPhieuKhoDTO> listChiTiet, out string errorMessage)
        {
            if (listChiTiet == null || listChiTiet.Count == 0)
            {
                errorMessage = "Vui lòng chọn ít nhất 1 vật tư vào danh sách phiếu kho!";
                return false;
            }
            return inventoryDAL.LapPhieuKhoTransaction(loaiPhieu, maNCC, listChiTiet, out errorMessage);
        }
    }
}