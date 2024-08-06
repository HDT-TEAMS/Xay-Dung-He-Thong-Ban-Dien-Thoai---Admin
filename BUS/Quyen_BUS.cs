using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class Quyen_BUS
    {
        private Quyen_DAO rDAO = new Quyen_DAO();

        public void AddRoleToUser(int userId, int roleId)
        {
            rDAO.AddRoleToUser(userId, roleId);
        }

        public void RemoveRoleFromUser(int userId, int roleId)
        {
            rDAO.RemoveRoleFromUser(userId, roleId);
        }

        public List<Quyen> LoadRole()
        {
            return rDAO.LoadRole();
        }

        public void UpdateQuyen(Quyen updateQuyen)
        {
            rDAO.UpdateQuyen(updateQuyen);
        }

        public Quyen GetQuyenById(int roleID)
        {
            return rDAO.GetQuyenById(roleID);
        }

        public List<ChucNang> GetAllChucNangs()
        {
            return rDAO.GetAllChucNangs();
        }

        public List<ChucNang> GetChucNangByMaQuyen(int maQuyen)
        {
            return rDAO.GetChucNangByMaQuyen(maQuyen);
        }

        public void AddChucNangToRole(int roleId, int chucNangId)
        {
            rDAO.AddChucNangToRole(roleId, chucNangId);
        }

        public void RemoveChucNangFromRole(int roleId, int chucNangId)
        {
            rDAO.RemoveChucNangFromRole(roleId, chucNangId);
        }

        public void addUser(Quyen quyen)
        {
            rDAO.addUser(quyen);
        }
    }
}
