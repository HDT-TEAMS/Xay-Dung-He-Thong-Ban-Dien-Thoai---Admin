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

        public void InsertLoai(Loai l)
        {
            loai_DAO.InsertLoai(l);
        }
        public void UpdateLoai(Loai l)
        {
            loai_DAO.UpdateLoai(l);
        }

        public void DeleteLoai(int maLoai)
        {
            loai_DAO.DeletetLoai(maLoai);
        }

        public Loai getLoaiByMal(int mal)
        {
            return loai_DAO.getLoaiByMal(mal);
        }
    }
}
