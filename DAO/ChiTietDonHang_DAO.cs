using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAO
{
    public class ChiTietDonHang_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();   
        public ChiTietDonHang_DAO() { }


        public List<View_DanhSachChiTietDonHang> loadCTDHByMaDH(int maDH)
        {
            return db.View_DanhSachChiTietDonHangs.Where(ctdh => ctdh.MaDH == maDH).ToList();
        }

        public void insertCTDonHang(CTDonHang ctdh)
        {
            db.CTDonHangs.InsertOnSubmit(ctdh);
            db.SubmitChanges();
        }

        public CTDonHang checkCTDH(int maDH)
        {
            return db.CTDonHangs.SingleOrDefault(dh => dh.MaDH == maDH);
        }

        public void upDateBoSungDonHang(CTDonHang ctdh)
        {
            var ctdhs = checkCTDH(ctdh.MaDH);
            if (ctdh != null)
            {
                ctdhs.MaSP = ctdh.MaSP;
                ctdh.SoLuong = ctdh.SoLuong;
                ctdh.DonGia = ctdh.DonGia;
            }
        }

        public DataTable GetTop5SanPhamBanChayDataTable()
        {
            var topSanPhamBanChay = db.VIEW_TOP5SANPHAMBANCHAYs
                                              .OrderByDescending(sp => sp.TotalSold)
                                              .Take(5)
                                              .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP", typeof(int));
            dt.Columns.Add("TenSP", typeof(string));
            dt.Columns.Add("TotalSold", typeof(int));

            foreach (var item in topSanPhamBanChay)
            {
                DataRow row = dt.NewRow();
                row["MaSP"] = item.MaSP;
                row["TenSP"] = item.TenSP;
                row["TotalSold"] = item.TotalSold;
                dt.Rows.Add(row);
            }

            return dt;
        }

    }
}
