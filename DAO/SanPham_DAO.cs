using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPham_DAO
    {   
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public SanPham_DAO() { }

        public List<View_SanPhamDetail> loadDetailSanPham()
        {
            var detailSanPham = db.View_SanPhamDetails.ToList();
            return detailSanPham;
        }

    }
}
