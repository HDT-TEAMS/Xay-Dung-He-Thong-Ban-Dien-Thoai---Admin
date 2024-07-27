using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DungLuong_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public DungLuong_DAO() { }
        public List<DungLuong> loadDataDungLuong()
        {
            return db.DungLuongs.Select(dl => dl).ToList<DungLuong>();  
        }
    }
}
