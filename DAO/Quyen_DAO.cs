using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Quyen_DAO
    {
        DB_DTDDDataContext dB = new DB_DTDDDataContext();
        public List<Quyen> LoadRole()
        {
            return dB.Quyens.Select(r => r).ToList<Quyen>();
        }

        public void UpdateQuyen(Quyen updatedQuyen)
        {
            var existingQuyen = dB.Quyens.SingleOrDefault(ro => ro.MaQuyen == updatedQuyen.MaQuyen);

            if (existingQuyen != null)
            {
                existingQuyen.TenQuyen = updatedQuyen.TenQuyen;
                existingQuyen.MaQuyen = updatedQuyen.MaQuyen;

                dB.SubmitChanges();
            }
        }
        public List<ChucNang> GetAllChucNangs()
        {
            return dB.ChucNangs.ToList();
        }

        public Quyen GetQuyenById(int roleID)
        {
            return dB.Quyens.SingleOrDefault(ro => ro.MaQuyen == roleID);
        }
        public List<ChucNang> GetChucNangByMaQuyen(int maQuyen)
        {
            var query = from q in dB.Quyens
                        join qcn in dB.QuyenChucNangs
                        on q.MaQuyen equals qcn.MaQuyen
                        join cn in dB.ChucNangs
                        on qcn.MaCN equals cn.MaCN
                        where q.MaQuyen == maQuyen
                        select cn;

            return query.ToList();
        }
    }
}
