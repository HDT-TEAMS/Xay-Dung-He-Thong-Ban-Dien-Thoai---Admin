using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DonHang_DAO
    {
        private DB_DTDDDataContext db = new DB_DTDDDataContext();
        public DonHang_DAO() { }


        public List<View_DanhSachDonHang> getDanhSachDonHang()
        {
            return db.View_DanhSachDonHangs.Select(dsdh => dsdh).ToList<View_DanhSachDonHang>();
        }

        public DonHang checkDonHang(int maDH)
        {
            return db.DonHangs.SingleOrDefault(dh => dh.MaDH == maDH);
        }

        public int InsertDonHang(DonHang donHang)
        {
            try
            {
                db.DonHangs.InsertOnSubmit(donHang);
                db.SubmitChanges();
                return donHang.MaDH;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public void UpdateTrangThaiDonHang(DonHang donHang)
        {
            var dh = checkDonHang(donHang.MaDH);
            if (dh != null)
            {
                dh.MaDH = donHang.MaDH;
                dh.TrangThai = donHang.TrangThai; 
                dh.MaNV = donHang.MaNV;
                db.SubmitChanges(); 
            }
        }

        public List<CreateReportHoaDonResult> GetReportHoaDon(int maHD)
        {
            ISingleResult<CreateReportHoaDonResult> result = db.CreateReportHoaDon(maHD);
            return result.ToList();
        }

        public DonHang getDonHangByMaĐH(int maDH)
        {
            return db.DonHangs.FirstOrDefault(dh => dh.MaDH == maDH);
        }

        //public decimal GetDoanhThuTheoThangVaNamOnline(int thang, int nam)
        //{
        //    var maHoadonOnline = new[] { "DHTT", "DHMM" };

        //    var doanhThuOnline = db.DonHangs
        //        .Where(dh => dh.TrangThai == "Đã hoàn thành"
        //                     && dh.NgayDat.Month == thang
        //                     && dh.NgayDat.Year == nam
        //                     && maHoadonOnline.Any(m => dh.MaNB.StartsWith(m))
        //        )
        //        .Sum(dh => dh.TongTien);

        //    return doanhThuOnline;
        //}

        //public decimal GetDoanhThuTheoThangVaNamOffline(int thang, int nam)
        //{
        //    var maHoadonOffline = new[] { "DHCH" };

        //    var doanhThuOffline = db.DonHangs
        //        .Where(dh => dh.TrangThai == "Đã hoàn thành"
        //                     && dh.NgayDat.Month == thang
        //                     && dh.NgayDat.Year == nam
        //                     && maHoadonOffline.Any(m => dh.MaNB.StartsWith(m))
        //        )
        //        .Sum(dh => dh.TongTien);

        //    return doanhThuOffline;
        //}

        public DataTable GetDoanhThuOnlineTheoThangNam(int thang, int nam)
        {
            try
            {
                var maHoadonOnline = new[] { "DHTT", "DHMM" };

                var doanhThuOnline = db.DonHangs
                    .Where(dh => dh.TrangThai == "Đã hoàn thành"
                                && dh.NgayDat.HasValue
                                && dh.NgayDat.Value.Month == thang
                                && dh.NgayDat.Value.Year == nam
                                && dh.MaNB != null // Kiểm tra null trước khi dùng
                                && maHoadonOnline.Any(m => dh.MaNB.StartsWith(m))
                    )
                    .GroupBy(dh => dh.NgayDat.Value.Date)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        TongTien = g.Sum(dh => dh.TongTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Ngay", typeof(DateTime));
                dt.Columns.Add("TongTien", typeof(decimal));

                foreach (var item in doanhThuOnline)
                {
                    dt.Rows.Add(item.Ngay, item.TongTien);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable(); // Trả về DataTable rỗng nếu có lỗi
            }
        }

        public DataTable GetDoanhThuOfflineTheoThangNam(int thang, int nam)
        {
            try
            {
                var maHoadonOffline = new[] { "DHCH" };

                var doanhThuOffline = db.DonHangs
                    .Where(dh => dh.TrangThai == "Đã hoàn thành"
                                && dh.NgayDat.HasValue
                                && dh.NgayDat.Value.Month == thang
                                && dh.NgayDat.Value.Year == nam
                                && dh.MaNB != null // Kiểm tra null trước khi dùng
                                && dh.MaNB.StartsWith("DHCH")
                    )
                    .GroupBy(dh => dh.NgayDat.Value.Date)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        TongTien = g.Sum(dh => dh.TongTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("Ngay", typeof(DateTime));
                dt.Columns.Add("TongTien", typeof(decimal));

                foreach (var item in doanhThuOffline)
                {
                    dt.Rows.Add(item.Ngay, item.TongTien);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable(); // Trả về DataTable rỗng nếu có lỗi
            }
        }



    }
}
