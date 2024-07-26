using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        NhanVien_DAO nvDAO = new NhanVien_DAO();

        public List<NhanVien> LoadNV()
        {
            return nvDAO.LoadNV();
        }
    }
}
