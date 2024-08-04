using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHang_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<KhachHang> LoadKH()
        {
            return dB.KhachHangs.Select(kh=>kh).ToList<KhachHang>();
        }

        public void InsertKhachHang(KhachHang khachHang)
        {
            dB.KhachHangs.InsertOnSubmit(khachHang);
            dB.SubmitChanges();
        }

        public void UpdateKhachHang(KhachHang updatedKhachHang)
        {
            // Attach the updated entity to the context
            var existingKhachHang = dB.KhachHangs.SingleOrDefault(nv => nv.MaNB == updatedKhachHang.MaNB);

            if (existingKhachHang != null)
            {
                // Copy the properties from the updated entity to the existing one
                existingKhachHang.TenKH = updatedKhachHang.TenKH;
                existingKhachHang.NgaySinh = updatedKhachHang.NgaySinh;
                existingKhachHang.GioiTinh = updatedKhachHang.GioiTinh;
                existingKhachHang.SDT = updatedKhachHang.SDT;
                existingKhachHang.Email = updatedKhachHang.Email;
                existingKhachHang.DiaChi = updatedKhachHang.DiaChi;
                dB.SubmitChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên");
            }
        }
        public KhachHang GetKhachHangById(string customerID)
        {
            return dB.KhachHangs.SingleOrDefault(nv => nv.MaNB == customerID);
        }

        public KhachHang GetMaKHbySDT(string sdt)
        {
            return dB.KhachHangs.SingleOrDefault(nv => nv.SDT == sdt);
        }

        public void DeleteKhachHang(KhachHang deleteKhachHang)
        {
            dB.KhachHangs.DeleteOnSubmit(deleteKhachHang);
            dB.SubmitChanges();
        }

        public List<KhachHang> SearchKhachHangByName(string name)
        {
            return dB.KhachHangs.Where(kh => kh.TenKH.Contains(name)).ToList();
        }
    }
}
