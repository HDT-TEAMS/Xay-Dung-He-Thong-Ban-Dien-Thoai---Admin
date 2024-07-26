using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.Linq;

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

        public List<NguoiDung> LoadND()
        {
            return db.NguoiDungs.Select(nd => nd).ToList<NguoiDung>();
        }



    }
}
