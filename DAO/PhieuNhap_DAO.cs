using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAO
{
    public class PhieuNhap_DAO
    {

        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public PhieuNhap_DAO() { }
        
        public List<View_DanhSachNhapHang> loadAllPhieuNhap()
        {
            return dB.View_DanhSachNhapHangs.ToList();
        }

        public PhieuNhap GetPhieuNhapByMaPN(int maPhieu)
        {
            return dB.PhieuNhaps.FirstOrDefault(pn => pn.MaPN == maPhieu);
        }

        public void InserPhieunhap(PhieuNhap phieuNhap)
        {
            dB.PhieuNhaps.InsertOnSubmit(phieuNhap);
            dB.SubmitChanges();
        }

        public void UpdatePhieuNhap(PhieuNhap phieuNhap)
        {
            var checkPhieuNhap = dB.PhieuNhaps.FirstOrDefault(pn => pn.MaPN == phieuNhap.MaPN);
            if (checkPhieuNhap == null)
            {
               
            }
        }

        public void DeletePhieuNhap(int maphieu)
        {
            var phieunhap = GetPhieuNhapByMaPN(maphieu);
            if (phieunhap != null) { 
                dB.PhieuNhaps.DeleteOnSubmit(phieunhap);
                dB.SubmitChanges();
            }
        }

        public PhieuNhap getPhieuNhapByMaPhieuNhap(int maPN)
        {
            var phieunhap = dB.PhieuNhaps.FirstOrDefault(pn => pn.MaPN == maPN);
            return phieunhap;
        }


        public List<string> GetAllMaNB()
        {
            return dB.PhieuNhaps.Select(b => b.MaNB).ToList();
        }


        public List<CreateReportPhieuNhapResult> GetReportPhieuNhap(int maPN)
        {
            ISingleResult<CreateReportPhieuNhapResult> result = dB.CreateReportPhieuNhap(maPN);
            return result.ToList();
        }

        public List<View_DanhSachNhapHang> searchPhieuNhapHang(string maNB)
        {
            return dB.View_DanhSachNhapHangs.Where(pn => pn.MaNB.Contains(maNB)).ToList();
        }


    }
}
