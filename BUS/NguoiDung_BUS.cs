using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class NguoiDung_BUS
    {
        private NguoiDung_DAO ndd = new NguoiDung_DAO();
        public NguoiDung_BUS() { }

        public List<NguoiDung> LoadND()
        {
            return ndd.LoadND();
        } 
        public NguoiDung checkLogins(string username, string password)
        {
            return ndd.checkLogin(username,password);
        }
        
    }
}
