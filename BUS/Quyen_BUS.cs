using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Quyen_BUS
    {
        Quyen_DAO rDAO = new Quyen_DAO();

        public List<Quyen> LoadRole()
        {
            return rDAO.LoadRole();
        }
    }
}
