using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietDonHang_BUS
    {
        public ChiTietDonHang_DAO ctdhd =new ChiTietDonHang_DAO();
        public ChiTietDonHang_BUS() { }

        public List<View_DanhSachChiTietDonHang> loadCTDHByMaDH(int maDH)
        {
           return ctdhd.loadCTDHByMaDH(maDH);
        }

        public void insertCTDonHang(CTDonHang ctdh)
        {
            ctdhd.insertCTDonHang(ctdh);
        }
        public DataTable GetTop5SanPhamBanChayDataTable()
        {
            return ctdhd.GetTop5SanPhamBanChayDataTable();
        }
    }
}
