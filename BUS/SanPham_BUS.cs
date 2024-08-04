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
        KhuyenMai_BUS khuyenMai_BUS = new KhuyenMai_BUS();
        public List<SanPham> loadSanPhams()
        {
            return sanPham_DAO.loadSanPhams();
        }

        public List<View_SanPhamDetailsByLoai> getAllSanPham()
        {
            return sanPham_DAO.loadDetailProduct();
        }

        public List<View_SanPhamDetailsByLoai> getListSanPhamDetail(int maLoai)
        {
            return sanPham_DAO.loadDetailProductByLoai(maLoai);
        }

        public void AddSanPham(string maNB,string tenSP, int ?maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
        {
            sanPham_DAO.InsertSanPham(maNB,tenSP, maDL, giaSP, hinhAnh, soLuong, maLoai, maMau);
        }

        public void UpdateSanPham(int maSP, string maNB, string tenSP, int ?maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
        {
            sanPham_DAO.UpdateSanPham(maSP, maNB, tenSP, maDL, giaSP, hinhAnh, soLuong, maLoai, maMau);
        }

        public void DeleteSanPham(int maSP)
        {
            sanPham_DAO.DeleteSanPham(maSP);
        }

        public SanPham getSanPhamByMaSPs(int maSp)
        {
            return sanPham_DAO.getSanPhamByMaSP(maSp);
        }

        public List<View_SanPhamDetailsByLoai> SearchSanPham(int maLoai,string tenSP)
        {
            return sanPham_DAO.SearchSanPham(maLoai, tenSP);    
        }

        public List<View_SanPhamDetailsByLoai> SearchSanPhamByTenSP(string searchTerm)
        {
      
            return sanPham_DAO.SearchSanPhamByTenSP(searchTerm);
        }

        public int getSoLuongByMaSP(int maSP)
        {
            return sanPham_DAO.getSoLuongByMaSP(maSP);
        }

        public void UpdateSoLuongSanPham(SanPham sanPhams, bool trangThai)
        {
            sanPham_DAO.UpdateSoLuongSanPham(sanPhams, trangThai);
        }

    }
}
