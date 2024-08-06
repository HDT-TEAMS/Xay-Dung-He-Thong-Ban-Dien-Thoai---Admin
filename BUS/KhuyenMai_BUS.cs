using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhuyenMai_BUS
    {
        KhuyenMai_DAO kmDAO = new KhuyenMai_DAO();

        public List<KhuyenMai> LoadKM()
        {
            return kmDAO.LoadKM();
        }

        public void AddKhuyenMai(KhuyenMai newKhuyenMai)
        {
            kmDAO.AddKhuyenMai(newKhuyenMai);
        }

        public void UpdateKhuyenMai(KhuyenMai updateKhuyenMai)
        {
            kmDAO.UpdateKhuyenMai(updateKhuyenMai);
        }

        public KhuyenMai GetKhuyenMaiById(int id)
        {
            return kmDAO.GetKhuyenMaiById(id);
        }


        public bool IsDiscountIDExists(string discountID)
        {
            return kmDAO.IsDiscountIDExists(discountID);
        }
    }
}
