using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Quyen_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<Quyen> LoadRole()
        {
            return dB.Quyens.Select(r => r).ToList<Quyen>();
        }
    }
}
