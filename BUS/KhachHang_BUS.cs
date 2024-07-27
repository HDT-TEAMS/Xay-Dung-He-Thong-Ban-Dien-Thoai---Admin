using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHang_BUS
    {
        KhachHang_DAO khDAO = new KhachHang_DAO();

        public List<KhachHang>LoadKH()
        {
            return khDAO.LoadKH();
        }

        public void UpdateKhachHang(KhachHang updateKhachHang)
        {
            khDAO.UpdateKhachHang(updateKhachHang);
        }

        public KhachHang GetKhachHangById(string CustomerId)
        {
            return khDAO.GetKhachHangById(CustomerId);
        }

        public void DeleteKhachHang(string CustomerId)
        {
            KhachHang kh = khDAO.GetKhachHangById(CustomerId);
            if (kh != null)
            {
                khDAO.DeleteKhachHang(kh);
            }
            else
            {
                throw new Exception("Khách hàng không tồn tại");
            }
        }
    }
}
