using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DungLuong_BUS
    {
        public DungLuong_BUS() { }
        DungLuong_DAO dla = new DungLuong_DAO();
        public List<DungLuong> loadAllDungLuong()
        {
            return dla.loadDataDungLuong();
        }
    }
}
