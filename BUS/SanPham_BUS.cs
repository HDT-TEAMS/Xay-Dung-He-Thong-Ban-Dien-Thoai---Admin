using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPham_BUS
    {
        public SanPham_BUS() { }
        SanPham_DAO sanPham_DAO = new SanPham_DAO();
        public List<View_SanPhamDetailsByLoai> getListSanPhamDetail(int maLoai)
        {
            return sanPham_DAO.loadDetailProductByLoai(maLoai);
        }

        public void AddSanPham(string maNB,string tenSP, int maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
        {
            sanPham_DAO.InsertSanPham(maNB,tenSP, maDL, giaSP, hinhAnh, soLuong, maLoai, maMau);
        }

        public SanPham getSanPhamByMaSPs(int maSp)
        {
            return sanPham_DAO.getSanPhamByMaSP(maSp);
        }
    }
}
