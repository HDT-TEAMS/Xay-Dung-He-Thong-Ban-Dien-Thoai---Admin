using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
            return dB.KhuyenMais.ToList();
        }

        public void AddKhuyenMai(KhuyenMai newKhuyenMai)
        {
            dB.KhuyenMais.InsertOnSubmit(newKhuyenMai);
            dB.SubmitChanges();

        }
        public void UpdateKhuyenMai(KhuyenMai updatedKhuyenMai)
        {
            var existingKhuyenMai = dB.KhuyenMais.SingleOrDefault(km => km.MaKM == updatedKhuyenMai.MaKM);

            if (existingKhuyenMai != null)
            {
                // Kiểm tra xem sản phẩm đã có khuyến mãi nào chưa
                var sanPhamsWithKhuyenMai = dB.SanPhams
                    .Where(sp => sp.MaKM != null && sp.MaKM != updatedKhuyenMai.MaKM)
                    .ToList();

                if (sanPhamsWithKhuyenMai.Any())
                {
                    // Nếu có, ném ngoại lệ để lớp gọi xử lý
                    throw new InvalidOperationException("Có sản phẩm đã có khuyến mãi khác. Không thể cập nhật.");
                }

                existingKhuyenMai.MaNB = updatedKhuyenMai.MaNB;
                existingKhuyenMai.TenKM = updatedKhuyenMai.TenKM;
                existingKhuyenMai.GiamGia = updatedKhuyenMai.GiamGia;
                existingKhuyenMai.NgayBD = updatedKhuyenMai.NgayBD;
                existingKhuyenMai.NgayKT = updatedKhuyenMai.NgayKT;
                existingKhuyenMai.IsDeleted = updatedKhuyenMai.IsDeleted;

                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        dB.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        saveFailed = true;
                        foreach (ObjectChangeConflict conflict in dB.ChangeConflicts)
                        {
                            conflict.Resolve(RefreshMode.OverwriteCurrentValues);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Đã xảy ra lỗi khi cập nhật khuyến mãi.", ex);
                    }
                } while (saveFailed);
            }
            else
            {
                throw new KeyNotFoundException("Khuyến mãi không tồn tại.");
            }
        }





        public KhuyenMai GetKhuyenMaiById(int id)
        {
            return dB.KhuyenMais.SingleOrDefault(nv => nv.MaKM == id);
        }

        public bool IsDiscountIDExists(string discountID)
        {
            return dB.KhuyenMais.Any(km => km.MaNB == discountID);
        }
    }

}
