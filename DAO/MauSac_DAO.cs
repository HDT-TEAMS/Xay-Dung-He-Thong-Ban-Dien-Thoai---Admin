using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MauSac_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public MauSac_DAO() { }

        public List<MauSac> loadDataMauSac()
        {
            return db.MauSacs.Select(ms => ms).ToList<MauSac>();
        }

        public void InsertMauSac(MauSac color)
        {
            try
            {
                db.MauSacs.InsertOnSubmit(color);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void UpdateMauSac(MauSac color)
        {
            var checkcolor = db.MauSacs.SingleOrDefault(colors => colors.MaMau == color.MaMau);
            try
            {
                if (checkcolor != null)
                {
                    checkcolor.MaNB = color.MaNB;
                    checkcolor.TenMau = color.TenMau;
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeletetMauSac(int maMauSac)
        {
            try
            {
                var MauSac = db.MauSacs.SingleOrDefault(colors => colors.MaMau == maMauSac);
                if (MauSac != null)
                {
                    db.MauSacs.DeleteOnSubmit(MauSac);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public MauSac getMauSacByMacolor(int macolor)
        {
            try
            {
                MauSac color = db.MauSacs.FirstOrDefault(n => n.MaMau == macolor);
                return color;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

    }
}
