using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHang_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<KhachHang> LoadKH()
        {
            return dB.KhachHangs.Select(kh=>kh).ToList<KhachHang>();
        }
    }
}
