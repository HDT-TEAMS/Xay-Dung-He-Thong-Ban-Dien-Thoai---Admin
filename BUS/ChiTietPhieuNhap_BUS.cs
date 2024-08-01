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
                // Cập nhật số lượng sản phẩm
                sanPham.SoLuong = (sanPham.SoLuong ?? 0) + chiTietPhieuNhap.SoLuong;

                // Xử lý giá nhập
                decimal oldGiaNhap = sanPham.GiaNhap.GetValueOrDefault(); 
                decimal newGiaNhap = chiTietPhieuNhap.GiaNhap.GetValueOrDefault();

                // Xử lý số lượng cũ
                int oldQuantity = sanPham.SoLuong.GetValueOrDefault();

                // Xử lý giá bán
                decimal giaSPCu = sanPham.GiaSP.GetValueOrDefault(); 
                decimal soLuongSanPham = sanPham.SoLuong.GetValueOrDefault(); 

                // Tính giá bán mới
                decimal giaSPMoi = (soLuongSanPham == 0)? newGiaNhap : ((giaSPCu * oldQuantity) + (newGiaNhap * chiTietPhieuNhap.SoLuong.GetValueOrDefault())) / soLuongSanPham;

                sanPham.GiaSP = giaSPMoi;
                sanPham.GiaNhap = newGiaNhap; 

                // Cập nhật sản phẩm trong cơ sở dữ liệu
                sanPhamDAO.UpdateSanPham(sanPham);
            }
        }





    }
}
