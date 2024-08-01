using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public NhaCungCap_BUS() { }

        private NhaCungCap_DAO nhaccDao = new NhaCungCap_DAO();

        public List<NhaCC> loadAllNhaCungCap()
        {
            return nhaccDao.loadAllNhaCungCap();
        }

        public void InsertNhaCungCap(NhaCC ncc)
        {
            nhaccDao.InsertNhaCungCap(ncc);
        }

        public void UpdateNhaCungCap(NhaCC ncc)
        {
            nhaccDao.UpdateNhaCungCap(ncc);
        }

        public void DeletetNhaCungCap(int maNhaCC)
        {
            nhaccDao.DeletetNhaCungCap(maNhaCC);
        }

        public NhaCC getNhaCCByMaNCC(int maNCC)
        {
           return nhaccDao.getNhaCCByMaNCC(maNCC);
        }
        public List<NhaCC> searchNhaCC(string maNB)
        {
            return nhaccDao.searchNhaCC(maNB);
        }

    }
}
