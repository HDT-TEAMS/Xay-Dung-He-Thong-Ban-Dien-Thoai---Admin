using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVien_DAO   
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<NhanVien> LoadNV()
        {
            return dB.NhanViens.Select(nv => nv).ToList<NhanVien>();
        }
    }
}
