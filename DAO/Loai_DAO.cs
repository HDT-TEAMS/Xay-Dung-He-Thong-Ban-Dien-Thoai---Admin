using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Loai_DAO
    {
        DB_DTDDDataContext db = new DB_DTDDDataContext();
        public Loai_DAO() { }
        public List<Loai> GetLoaiList() { 
            return db.Loais.Select(l => l).ToList<Loai>();
        }

        public void InsertLoai(Loai l)
        {
            try
            {
                db.Loais.InsertOnSubmit(l);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void UpdateLoai(Loai l)
        {
            var checkl = db.Loais.SingleOrDefault(ls => ls.Maloai == l.Maloai);
            try
            {
                if (checkl != null)
                {
                    checkl.MaNB = l.MaNB;
                    checkl.TenLoai = l.TenLoai;
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeletetLoai(int maLoai)
        {
            try
            {
                var Loai = db.Loais.SingleOrDefault(ls => ls.Maloai == maLoai);
                if (Loai != null)
                {
                    db.Loais.DeleteOnSubmit(Loai);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public Loai getLoaiByMal(int mal)
        {
            try
            {
                Loai l = db.Loais.FirstOrDefault(n => n.Maloai == mal);
                return l;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
