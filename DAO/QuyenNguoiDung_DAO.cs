using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuyenNguoiDung_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();

        public List<int> GetQuyenNguoiDung(int maND)
        {
            return db.QuyenNguoiDungs
                .Where(qnd => qnd.MAND == maND)
                .Select(qnd => qnd.MaQuyen)
                .ToList();
        }

        public async Task UpdateUserRolesAsync(int userId, List<int> rolesToAdd, List<int> rolesToRemove)
        {
            await Task.Run(() =>
            {

                foreach (var role in rolesToRemove)
                {
                    var roleToRemove = db.QuyenNguoiDungs
                        .FirstOrDefault(r => r.MAND == userId && r.MaQuyen == role);

                    if (roleToRemove != null)
                    {
                        db.QuyenNguoiDungs.DeleteOnSubmit(roleToRemove);
                    }
                }
                foreach (var role in rolesToAdd)
                {
                    var roleToAdd = new QuyenNguoiDung
                    {
                        MAND = userId,
                        MaQuyen = role,
                        IsDeleted = false
                    };
                    db.QuyenNguoiDungs.InsertOnSubmit(roleToAdd);
                }
                db.SubmitChanges();
            });
        }


    }
}
