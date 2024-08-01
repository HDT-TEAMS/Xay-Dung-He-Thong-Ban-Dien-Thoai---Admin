using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhuyenMai_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<KhuyenMai> LoadKM()
        {
            return dB.KhuyenMais.Select(km => km).ToList<KhuyenMai>();
        }

        public void AddKhuyenMai(KhuyenMai newKhuyenMai)
        {
            dB.KhuyenMais.InsertOnSubmit(newKhuyenMai);
            dB.SubmitChanges();

        }
        public void UpdateKhuyenMai(KhuyenMai updatedKhuyenMai)
        {
            var existingKhuyenMai = dB.KhuyenMais.SingleOrDefault(km => km.MaNB == updatedKhuyenMai.MaNB);

            if (existingKhuyenMai != null)
            {
                existingKhuyenMai.TenKM = updatedKhuyenMai.TenKM;
                existingKhuyenMai.GiamGia = updatedKhuyenMai.GiamGia;
                existingKhuyenMai.NgayBD = updatedKhuyenMai.NgayBD;
                existingKhuyenMai.NgayKT = updatedKhuyenMai.NgayKT;
                dB.SubmitChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên");
            }
        }
        public KhuyenMai GetKhuyenMaiById(string DiscountId)
        {
            return dB.KhuyenMais.SingleOrDefault(nv => nv.MaNB == DiscountId);
        }

        public void DeleteKhuyenMai(KhuyenMai deletekhuyenMai)
        {
            dB.KhuyenMais.DeleteOnSubmit(deletekhuyenMai);
            dB.SubmitChanges();
        }

        public bool IsDiscountIDExists(string discountID)
        {
            return dB.KhuyenMais.Any(km => km.MaNB == discountID);
        }
    }

}
