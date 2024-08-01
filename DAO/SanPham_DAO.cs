﻿using DTO;
using System;
using System.Collections.Generic;
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

        //public List<SanPham> loadAllSanPham()
        //{
        //    return 
        //}

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
            var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);

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


        public void DeleteSanPham(int maSP)
        {
            var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);
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

    }
}
