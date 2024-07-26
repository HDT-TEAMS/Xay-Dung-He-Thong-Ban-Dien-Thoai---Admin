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
    }
}
