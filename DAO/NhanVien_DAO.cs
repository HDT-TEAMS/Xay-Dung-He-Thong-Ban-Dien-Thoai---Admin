using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhanVien_DAO   
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<NhanVien> LoadNV()
        {
            return dB.NhanViens.Select(nv => nv).ToList<NhanVien>();
        }

        public void AddNhanVien(NhanVien newNhanVien)
        {
            dB.NhanViens.InsertOnSubmit(newNhanVien);
            dB.SubmitChanges();
        }

        public void UpdateNhanVien(NhanVien updatedNhanVien)
        {
            var existingNhanVien = dB.NhanViens.SingleOrDefault(nv => nv.MaNB == updatedNhanVien.MaNB);

            if (existingNhanVien != null)
            {
                existingNhanVien.TenNV = updatedNhanVien.TenNV;
                existingNhanVien.NgaySinh = updatedNhanVien.NgaySinh;
                existingNhanVien.GioiTinh = updatedNhanVien.GioiTinh;
                existingNhanVien.SDTNV = updatedNhanVien.SDTNV;
                existingNhanVien.Email=updatedNhanVien.Email;

                dB.SubmitChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên");
            }
        }
        public NhanVien GetNhanVienById(string employeeId)
        {
            return dB.NhanViens.SingleOrDefault(nv => nv.MaNB == employeeId);
        }

        public void DeleteNhanVien(NhanVien deletenhanVien)
        {
            dB.NhanViens.DeleteOnSubmit(deletenhanVien);
            dB.SubmitChanges();
        }

        public string GetNhanVienNameByMaND(int maND)
        {
            var nhanVien = dB.NhanViens.SingleOrDefault(nv => nv.MaND == maND);
            if (nhanVien != null)
            {
                return nhanVien.TenNV;
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên với mã này");
            }
        }

        public int GetMaNVByMaND(int maND)
        {
            var nhanVien = dB.NhanViens.SingleOrDefault(nv => nv.MaND == maND);
            if (nhanVien != null)
            {
                return nhanVien.MaNV;
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên với mã này");
            }
        }

    }
}
