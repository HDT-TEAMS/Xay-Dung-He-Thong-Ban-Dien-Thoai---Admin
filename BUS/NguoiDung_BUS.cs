using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class NguoiDung_BUS
    {
        private NguoiDung_DAO ndd = new NguoiDung_DAO();
        public NguoiDung_BUS() { }

        public void AddNguoiDung(NguoiDung newNguoiDung)
        {
            ndd.AddNguoiDung(newNguoiDung);
        }

        public List<NguoiDung> LoadND()
        {
            return ndd.LoadND();
        }

        public NguoiDung checkLogins(string username, string password)
        {
            return ndd.checkLogin(username, password);
        }

        public NguoiDung GetNguoiDungById(int userId)
        {
            return ndd.GetNguoiDungById(userId);
        }

        public void UpdateNguoiDung(NguoiDung nguoiDung)
        {
            ndd.UpdateNguoiDung(nguoiDung);
        }
    }
}
