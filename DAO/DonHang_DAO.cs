using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DonHang_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public DonHang_DAO() { }


        public List<View_DanhSachDonHang> getDanhSachDonHang()
        {
            return db.View_DanhSachDonHangs.Select(dsdh => dsdh).ToList<View_DanhSachDonHang>();
        }

        public DonHang checkDonHang(int maDH)
        {
            return db.DonHangs.SingleOrDefault(dh => dh.MaDH == maDH);
        }

        public int InsertDonHang(DonHang donHang)
        {
            try
            {
                db.DonHangs.InsertOnSubmit(donHang);
                db.SubmitChanges();
                return donHang.MaDH;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public void UpdateTrangThaiDonHang(DonHang donHang)
        {
            var dh = checkDonHang(donHang.MaDH);
            if (dh != null)
            {
                dh.MaDH = donHang.MaDH;
                dh.TrangThai = donHang.TrangThai; 
                dh.MaNV = donHang.MaNV;
                db.SubmitChanges(); 
            }
        }

        public List<CreateReportHoaDonResult> GetReportHoaDon(int maHD)
        {
            ISingleResult<CreateReportHoaDonResult> result = db.CreateReportHoaDon(maHD);
            return result.ToList();
        }

        public DonHang getDonHangByMaĐH(int maDH)
        {
            return db.DonHangs.FirstOrDefault(dh => dh.MaDH == maDH);
        }




    }
}
