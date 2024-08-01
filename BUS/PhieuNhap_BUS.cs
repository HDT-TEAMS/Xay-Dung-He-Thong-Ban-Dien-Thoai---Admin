using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class PhieuNhap_BUS
    {
        public PhieuNhap_BUS() { }
        PhieuNhap_DAO phieuNhap = new PhieuNhap_DAO();
        public List<View_DanhSachNhapHang> loadAllPhieuNhap()
        {
            return phieuNhap.loadAllPhieuNhap();
        }

        public void InsertPhieuNhap(PhieuNhap phieuNhaps)
        {
            phieuNhap.InserPhieunhap(phieuNhaps);
        }

        public List<string> GetAllInternalCodes()
        {
            return phieuNhap.GetAllMaNB();
        }

        public List<CreateReportPhieuNhapResult> GetReportPhieuNhap(int maPN)
        {
            return phieuNhap.GetReportPhieuNhap(maPN);
        }

        public List<View_DanhSachNhapHang> searchPN(string MaNB)
        {
            return phieuNhap.searchPhieuNhapHang(MaNB);
        }

    }
}
