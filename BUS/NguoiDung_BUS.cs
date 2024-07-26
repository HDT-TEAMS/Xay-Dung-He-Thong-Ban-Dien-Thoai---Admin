using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NguoiDung_BUS
    {
        NguoiDung_DAO ndDAO = new NguoiDung_DAO();

        public List<NguoiDung> LoadND()
        {
            return ndDAO.LoadND();
        }
    }
}
