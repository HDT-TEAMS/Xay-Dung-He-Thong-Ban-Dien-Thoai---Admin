using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        NhanVien_DAO nvDAO = new NhanVien_DAO();

        public List<NhanVien> LoadNV()
        {
            return nvDAO.LoadNV();
        }
        public void AddNhanVien(NhanVien newNhanVien)
        {
            nvDAO.AddNhanVien(newNhanVien);
        }

        public void UpdateNhanVien (NhanVien updateNhanVien)
        {
            nvDAO.UpdateNhanVien(updateNhanVien);
        }

        public NhanVien GetNhanVienById(string employeeId)
        {
            return nvDAO.GetNhanVienById(employeeId);
        }

        public void DeleteNhanVien(string employeeId)
        {
            NhanVien nv = nvDAO.GetNhanVienById(employeeId);
            if (nv != null)
            {
                nvDAO.DeleteNhanVien(nv);
            }
            else
            {
                throw new Exception("Nhân viên không tồn tại");
            }
        }

        public string GetNhanVienNameById(int maND)
        {
           return nvDAO.GetNhanVienNameByMaND(maND);
        }

        public int GetMaNVById(int maND)
        {
            return nvDAO.GetMaNVByMaND(maND);
        }
    }
}
