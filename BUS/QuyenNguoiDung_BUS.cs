using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class QuyenNguoiDung_BUS
    {
        private QuyenNguoiDung_DAO qndDao = new QuyenNguoiDung_DAO();

        public List<int> GetQuyenNguoiDung(int maND)
        {
            return qndDao.GetQuyenNguoiDung(maND);
        }

        public async Task UpdateUserRolesAsync(int userId, List<int> rolesToAdd, List<int> rolesToRemove)
        {
           await qndDao.UpdateUserRolesAsync(userId, rolesToAdd, rolesToRemove);  
        }
    }
}
