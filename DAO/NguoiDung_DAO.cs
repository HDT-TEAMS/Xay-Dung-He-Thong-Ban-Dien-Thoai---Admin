using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Security.Cryptography;

namespace DAO
{
    public class NguoiDung_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public NguoiDung_DAO() { }


        public NguoiDung checkLogin(string username, string password)
        {
            try
            {
                NguoiDung user = db.NguoiDungs
                    .FirstOrDefault(u => u.UserName == username && u.PassWord == password);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public void AddNguoiDung(NguoiDung newNguoiDung)
        {
            db.NguoiDungs.InsertOnSubmit(newNguoiDung);
            db.SubmitChanges();
        }


        public List<NguoiDung> LoadND()
        {
            return db.NguoiDungs.Select(nd => nd).ToList<NguoiDung>();
        }

        public NguoiDung GetNguoiDungById(int userId)
        {
            return db.NguoiDungs.FirstOrDefault(u => u.MaND == userId);
        }
        //public NguoiDung GetNguoiDungById(int userId)
        //{
        //    return db.GetNguoiDungById(userId); // Ensure this method is in NguoiDung_DAO
        //}
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte và băm
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển mảng byte thành chuỗi
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}