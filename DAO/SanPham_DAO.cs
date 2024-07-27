using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPham_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public SanPham_DAO() { }

        public List<View_SanPhamDetailsByLoai> loadDetailProductByLoai(int maLoai)
        {
            var detailSanPham = db.View_SanPhamDetailsByLoais
                                  .Where(sp => sp.MaLoai == maLoai)
                                  .ToList();
            return detailSanPham;
        }

        public void InsertSanPham(string maNB,string tenSP, int maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
        {
            var sanPham = new SanPham
            {
                MaNB = maNB,
                TenSP = tenSP,
                HinhAnh = hinhAnh,
                SoLuong = soLuong,
                GiaSP = giaSP,
                MaLoai = maLoai,
                MaMau = maMau,
                MaDungLuong = maDL,
                MaKM = null,
                IsDeleted = false
            };

            db.SanPhams.InsertOnSubmit(sanPham);
            db.SubmitChanges();
        }

        public SanPham getSanPhamByMaSP(int maSP)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
            return sanPham;
        }


    }
}
