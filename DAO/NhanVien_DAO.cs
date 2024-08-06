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


        public void AddNhanVien(int MaND, string maNB, string tenNV, DateTime ngaySinh, string gioiTinh, string sdtNV, string email)
        {
                var nhanVien = new NhanVien
                {
                    MaND = MaND,
                    MaNB = maNB,
                    TenNV = tenNV,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    SDTNV = sdtNV,
                    Email = email,
                    IsDeleted = false
                };

            dB.NhanViens.InsertOnSubmit(nhanVien);
            dB.SubmitChanges();
        }

        public bool checkMaNB(String maNB)
        {
            var nhanVien = dB.NhanViens.FirstOrDefault(nv => nv.MaNB == maNB);
            if (nhanVien != null)
            {
                return false;
            }
            else return true;
        }

        public void UpdateNhanVien(NhanVien updatedNhanVien)
        {
            var existingNhanVien = dB.NhanViens.FirstOrDefault(nv => nv.MaNV == updatedNhanVien.MaNV);

            if (existingNhanVien != null)
            {
                existingNhanVien.MaNB = updatedNhanVien.MaNB;   
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

        public NhanVien GetNhanVienById(int employeeId)
        {
            return dB.NhanViens.SingleOrDefault(nv => nv.MaNV == employeeId);
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


        public List<NhanVien> SearchNhanVienByName(string name)
        {
            return dB.NhanViens.Where(nv => nv.TenNV.Contains(name)).ToList();
        }

        public bool IsEmployeeIDExists(string employeeId)
        {
            return dB.NhanViens.Any(nv => nv.MaNB == employeeId);
        }
    }
}
