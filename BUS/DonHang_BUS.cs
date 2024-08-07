using DAO;
using DTO;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DonHang_BUS
    {
        private DonHang_DAO dha = new DonHang_DAO();

        public List<View_DanhSachDonHang> getDanhSachDonHang()
        {
            return dha.getDanhSachDonHang(); 
        }

        public int InsertDonHang(DonHang donHang)
        {
            return dha.InsertDonHang(donHang);
        }

        public void UpdateTrangThaiDonHang(DonHang donHang)
        {
            dha.UpdateTrangThaiDonHang(donHang);
        }

        public DonHang getDonHangByMaĐH(int maDH)
        {
            return dha.getDonHangByMaĐH(maDH);
        }

        public List<CreateReportHoaDonResult> GetReportHoaDon(int maHD)
        {
            return dha.GetReportHoaDon(maHD);
        }

        public DataTable GetDoanhThuOnlineTheoThangNam(int thang, int nam)
        {
           return dha.GetDoanhThuOnlineTheoThangNam(thang,nam);
        }

        // Lấy doanh thu offline theo tháng và năm
        public DataTable GetDoanhThuOfflineTheoThangNam(int thang, int nam)
        {
            return dha.GetDoanhThuOfflineTheoThangNam(thang, nam);
        }


    }
}
