using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Loai_DAO
    {
        DB_DTDDDataContext db = new DB_DTDDDataContext();
        public Loai_DAO() { }
        public List<Loai> GetLoaiList() { 
            return db.Loais.Select(l => l).ToList<Loai>();
        }
    }
}
