using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPham_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public SanPham_DAO() { }
        public List<SanPham> loadSanPhams()
        {
            return db.SanPhams.Select(sp => sp).ToList<SanPham>();
        }

        public List<View_SanPhamDetailsByLoai> loadDetailProduct()
        {
            return db.View_SanPhamDetailsByLoais.Select(sp => sp).ToList();
        }

        public List<View_SanPhamDetailsByLoai> loadDetailProductByLoai(int maLoai)
        {
            var detailSanPham = db.View_SanPhamDetailsByLoais
                                  .Where(sp => sp.MaLoai == maLoai)
                                  .ToList();
            return detailSanPham;
        }

        public void InsertSanPham(string maNB, string tenSP, int? maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
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

        public void UpdateSanPham(int maSP, string maNB, string tenSP, int? maDL, decimal giaSP, string hinhAnh, int soLuong, int maLoai, int maMau)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);

            if (sanPham != null)
            {
                sanPham.MaNB = maNB;
                sanPham.TenSP = tenSP;
                sanPham.MaDungLuong = maDL;
                sanPham.GiaSP = giaSP;
                sanPham.HinhAnh = hinhAnh;
                sanPham.SoLuong = soLuong;
                sanPham.MaLoai = maLoai;
                sanPham.MaMau = maMau;

                db.SubmitChanges();
            }
            else
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }
        }

        public void UpdateSanPham(SanPham sanPham)
        {
            var existingSanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == sanPham.MaSP);
            if (existingSanPham != null)
            {
                existingSanPham.SoLuong = sanPham.SoLuong;
                existingSanPham.GiaSP = sanPham.GiaSP;
                existingSanPham.GiaNhap = sanPham.GiaNhap;
                db.SubmitChanges();
            }
        }

        public void UpdateSoLuongSanPham(SanPham sanPhams, bool trangThai)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == sanPhams.MaSP);
            if (sanPham != null)
            {
                if (trangThai)
                {
                    sanPham.SoLuong += sanPhams.SoLuong;
                }
                else
                {
                    sanPham.SoLuong -= sanPhams.SoLuong;
                }
                db.SubmitChanges(); 
            }
        }

        public void UpdateKhuyenMaiSanPham(SanPham sanPham)
        {
            using (var context = new DB_DTDDDataContext())
            {
                // Tìm sản phẩm dựa trên MaSP
                var existingProduct = context.SanPhams.SingleOrDefault(p => p.MaSP == sanPham.MaSP);
                if (existingProduct != null)
                {
                    // Cập nhật thông tin khuyến mãi
                    existingProduct.MaKM = sanPham.MaKM;
                    context.SubmitChanges(); // Đồng bộ
                }

            }
        }



        public void DeleteSanPham(int maSP)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
            if (sanPham != null)
            {
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
            }
            else
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }
        }

        public SanPham getSanPhamByMaSP(int maSP)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
            return sanPham;
        }

        public List<View_SanPhamDetailsByLoai> SearchSanPham(int maLoai, string searchTerm)
        {
            var detailSanPham = db.View_SanPhamDetailsByLoais
                                   .Where(sp => sp.MaLoai == maLoai && sp.TenSP.Contains(searchTerm))
                                   .ToList();
            return detailSanPham;
        }

        public List<View_SanPhamDetailsByLoai> SearchSanPhamByTenSP(string searchTerm)
        {
            var detailSanPham = db.View_SanPhamDetailsByLoais .Where(sp =>  sp.TenSP.Contains(searchTerm)).ToList();
            return detailSanPham;
        }

        public int getSoLuongByMaSP(int maSP)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp =>sp.MaSP == maSP);
            return sanPham != null ? sanPham.SoLuong.GetValueOrDefault(0) : 0;
        }

        public List<SanPham> GetSanPhamGanHetHang()
        {
            return db.SanPhams
                     .Where(sp => sp.SoLuong < 10 && sp.IsDeleted == false)
                     .ToList();
        }

        public DataTable GetSanPhamGanHetHangDataTable()
        {
            var sanPhamGanHetHang = GetSanPhamGanHetHang();
            DataTable dt = new DataTable();
            dt.Columns.Add("TenSP", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));

            foreach (var sp in sanPhamGanHetHang)
            {
                dt.Rows.Add( sp.TenSP, sp.SoLuong);
            }

            return dt;
        }

    }
}
