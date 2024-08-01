using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAO
{
    public class Quyen_DAO
    {
        private DB_DTDDDataContext dB = new DB_DTDDDataContext();

        public List<Quyen> LoadRole()
        {
            return dB.Quyens.ToList();
        }

        public void UpdateQuyen(Quyen updatedQuyen)
        {
            var existingQuyen = dB.Quyens.SingleOrDefault(ro => ro.MaQuyen == updatedQuyen.MaQuyen);

            if (existingQuyen != null)
            {
                existingQuyen.TenQuyen = updatedQuyen.TenQuyen;
                dB.SubmitChanges();
            }
        }

        public List<ChucNang> GetAllChucNangs()
        {
            return dB.ChucNangs.ToList();
        }

        public Quyen GetQuyenById(int roleID)
        {
            return dB.Quyens.SingleOrDefault(ro => ro.MaQuyen == roleID);
        }

        public List<ChucNang> GetChucNangByMaQuyen(int maQuyen)
        {
            var query = from q in dB.Quyens
                        join qcn in dB.QuyenChucNangs on q.MaQuyen equals qcn.MaQuyen
                        join cn in dB.ChucNangs on qcn.MaCN equals cn.MaCN
                        where q.MaQuyen == maQuyen
                        select cn;

            return query.ToList();
        }

        public void AddRoleToUser(int userId, int roleId)
        {
            var existingUserRole = dB.QuyenNguoiDungs
                .FirstOrDefault(ur => ur.MAND == userId && ur.MaQuyen == roleId);

            if (existingUserRole == null)
            {
                var userRole = new QuyenNguoiDung
                {
                    MAND = userId,
                    MaQuyen = roleId,
                    IsDeleted = false
                };

                dB.QuyenNguoiDungs.InsertOnSubmit(userRole);
                dB.SubmitChanges();
            }
            else if (existingUserRole.IsDeleted.GetValueOrDefault())
            {
                existingUserRole.IsDeleted = false;
                dB.SubmitChanges();
            }
        }

        public void RemoveRoleFromUser(int userId, int roleId)
        {
            var userRole = dB.QuyenNguoiDungs
                .FirstOrDefault(ur => ur.MAND == userId && ur.MaQuyen == roleId);

            if (userRole != null)
            {
                userRole.IsDeleted = true;
                dB.SubmitChanges();
            }
        }

        // Thêm chức năng vào quyền
        public void AddChucNangToRole(int roleId, int chucNangId)
        {
            var existing = dB.QuyenChucNangs
                .FirstOrDefault(qcn => qcn.MaQuyen == roleId && qcn.MaCN == chucNangId);

            if (existing == null)
            {
                var quyenChucNang = new QuyenChucNang
                {
                    MaQuyen = roleId,
                    MaCN = chucNangId
                };

                dB.QuyenChucNangs.InsertOnSubmit(quyenChucNang);
                dB.SubmitChanges();
            }
        }

        // Xóa chức năng khỏi quyền
        public void RemoveChucNangFromRole(int roleId, int chucNangId)
        {
            var existing = dB.QuyenChucNangs
                .FirstOrDefault(qcn => qcn.MaQuyen == roleId && qcn.MaCN == chucNangId);

            if (existing != null)
            {
                dB.QuyenChucNangs.DeleteOnSubmit(existing);
                dB.SubmitChanges();
            }
        }
    }
}
