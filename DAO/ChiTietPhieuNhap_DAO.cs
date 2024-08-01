using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietPhieuNhap_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();

        public ChiTietPhieuNhap_DAO()
        {

        }

        public void InsertChiTietPhieuNhap(ChiTietPN chiTietPhieuNhap)
        {
            db.ChiTietPNs.InsertOnSubmit(chiTietPhieuNhap);
            db.SubmitChanges();
        }

        public List<View_DanhSachChiTietPhieuNhap> getListCTPNByMaPN(int maPN)
        {
            return db.View_DanhSachChiTietPhieuNhaps.Where(ctpn => ctpn.MaPN == maPN).ToList();
        }
    }
}
