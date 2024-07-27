using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MauSac_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public MauSac_DAO() { }

        public List<MauSac> loadDataMauSac()
        {
            return db.MauSacs.Select(ms => ms).ToList<MauSac>();
        }
    }
}
