using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MauSac_BUS
    {
        public MauSac_BUS() { }
        MauSac_DAO msd = new MauSac_DAO();
        public List<MauSac> loadAllMauSac()
        {
            return msd.loadDataMauSac();
        }

        public void InsertMauSac(MauSac color)
        {
            msd.InsertMauSac(color);
        }
        public void UpdateMauSac(MauSac color)
        {
            msd.UpdateMauSac(color);
        }

        public void DeletetMauSac(int maMauSac)
        {
            msd.DeletetMauSac(maMauSac);
        }

        public MauSac getMauSacByMacolor(int macolor)
        {
            return msd.getMauSacByMacolor(macolor);
        }
    }
}
