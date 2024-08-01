using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhaCungCap_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public NhaCungCap_DAO() { }
        public List<NhaCC> loadAllNhaCungCap()
        {
            using (var context = new DB_DTDDDataContext())
            {
                return context.NhaCCs.ToList();
            }
        }


        public void InsertNhaCungCap(NhaCC ncc)
        {
            try
            {
                db.NhaCCs.InsertOnSubmit(ncc);
                db.SubmitChanges();
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void UpdateNhaCungCap(NhaCC ncc)
        {
            var checkNCC = db.NhaCCs.SingleOrDefault(nccs => nccs.MaNCC == ncc.MaNCC);
            try
            {
                if (checkNCC != null)
                {
                    checkNCC.MaNB = ncc.MaNB;
                    checkNCC.TenNCC = ncc.TenNCC;
                    checkNCC.SDT = ncc.SDT;
                    checkNCC.DiaChi = ncc.DiaChi;
                }
                db.SubmitChanges();
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeletetNhaCungCap(int maNhaCC)
        {
            try
            {
                var nhaCC = db.NhaCCs.SingleOrDefault(nccs => nccs.MaNCC == maNhaCC);
                if (nhaCC != null)
                {
                    db.NhaCCs.DeleteOnSubmit(nhaCC);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  
            }
        }

        public NhaCC getNhaCCByMaNCC(int maNCC)
        {
            try
            {
                NhaCC ncc = db.NhaCCs.FirstOrDefault(n => n.MaNCC == maNCC);
                return ncc;
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error: " +ex.Message);
                throw;
            }
        }

        public List<NhaCC> searchNhaCC(string maNB)
        {
            // Normalize search terms to lowercase and trim spaces
            maNB = maNB?.ToLower().Trim();

            // Construct the query
            var query = from ncc in db.NhaCCs
                        where (string.IsNullOrEmpty(maNB) || ncc.MaNB.ToLower().Contains(maNB))
                             
                     select ncc;

            // Execute the query and return the results as a list
            return query.ToList();
        }



    }
}
