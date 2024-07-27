using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Loai_BUS
    {
        private Loai_DAO loai_DAO = new Loai_DAO();
        public Loai_BUS() { }   

        public List<Loai> LoadAllLoai()
        {
            return loai_DAO.GetLoaiList();
        }


    }
}
