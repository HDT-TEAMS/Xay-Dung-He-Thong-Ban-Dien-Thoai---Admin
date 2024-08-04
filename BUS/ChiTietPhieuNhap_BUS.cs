using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietPhieuNhap_BUS
    {
        ChiTietPhieuNhap_DAO chiTietPhieuNhap_DAO = new ChiTietPhieuNhap_DAO();
        SanPham_DAO sanPhamDAO = new SanPham_DAO();
        public ChiTietPhieuNhap_BUS() { }
        public void InsertChiTietPhieuNhap(ChiTietPN chiTietPhieuNhap)
        {
            chiTietPhieuNhap_DAO.InsertChiTietPhieuNhap(chiTietPhieuNhap);
        }
        public List<View_DanhSachChiTietPhieuNhap> getListCTPNByMaPN(int maPN)
        {
            return chiTietPhieuNhap_DAO.getListCTPNByMaPN(maPN);
        }

        public void UpdateSanPhamSauKhiNhapHang(ChiTietPN chiTietPhieuNhap)
        {
            var sanPham = sanPhamDAO.getSanPhamByMaSP(chiTietPhieuNhap.MaSP);

            if (sanPham != null)
            {
                int soLuongSanPhamHienTai = sanPham.SoLuong ?? 0;
                int soLuongMoi = chiTietPhieuNhap.SoLuong.GetValueOrDefault();
                sanPham.SoLuong = soLuongSanPhamHienTai + soLuongMoi;

                decimal giaNhapMoi = chiTietPhieuNhap.GiaNhap.GetValueOrDefault();
                decimal giaNhapCu = sanPham.GiaNhap.GetValueOrDefault();

                sanPham.GiaNhap = giaNhapMoi;

                if (giaNhapMoi == giaNhapCu)
                {
                    return; 
                }

                decimal giaBanMoi = giaNhapMoi * 1.2m;

                if (soLuongSanPhamHienTai == 0)
                {
                    sanPham.GiaSP = giaBanMoi;
                }
                else
                {
                    decimal giaBanCu = sanPham.GiaSP.GetValueOrDefault();
                    decimal giaBanTrungBinh = (giaBanCu * soLuongSanPhamHienTai + giaBanMoi * soLuongMoi) / (soLuongSanPhamHienTai + soLuongMoi);
                    sanPham.GiaSP = giaBanTrungBinh;
                }
                sanPhamDAO.UpdateSanPham(sanPham);
            }
        }
    }
}
