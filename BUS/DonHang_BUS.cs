using DAO;
using DTO;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
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

    }
}
