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
        public List<View_SanPhamDetail> getListSanPhamDetail()
        {
            return sanPham_DAO.loadDetailSanPham();
        }
    }
}
