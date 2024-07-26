using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NguoiDung_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<NguoiDung> LoadND()
        {
            return dB.NguoiDungs.Select(nd => nd).ToList<NguoiDung>();
        }
    }
}
