using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HeThongBanDienThoai_Admin.GUI.Statistical
{

    public partial class StatisticalInStrore_Form : Form
    {
        private DonHang_BUS dhb = new DonHang_BUS();

        public StatisticalInStrore_Form()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtThang.Text) || string.IsNullOrWhiteSpace(txtNam.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tháng và năm.");
                return;
            }

            int thang;
            int nam;

            if (!int.TryParse(txtThang.Text, out thang) || !int.TryParse(txtNam.Text, out nam))
            {
                MessageBox.Show("Tháng và năm phải là số nguyên.");
                return;
            }

            if (thang < 1 || thang > 12)
            {
                MessageBox.Show("Tháng phải nằm trong khoảng từ 1 đến 12.");
                return;
            }

            if (nam < 1900 || nam > DateTime.Now.Year)
            {
                MessageBox.Show("Năm phải là năm hợp lệ.");
                return;
            }

            loadChartData(thang, nam);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DonHang_BUS dhb = new DonHang_BUS();
                ExcelExport dt = new ExcelExport();

                if (!int.TryParse(txtThang.Text, out int selectedMonth) || !int.TryParse(txtNam.Text, out int selectedYear))
                {
                    MessageBox.Show("Vui lòng nhập tháng và năm hợp lệ.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<View_DanhSachDonHang> allOrders = dhb.getDanhSachDonHang();

                if (allOrders == null || allOrders.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                var filteredOrders = allOrders
                    .Where(order => (order.MaNB != null && (order.MaNB.StartsWith("DHCH"))
                                    && order.NgayDat.HasValue
                                    && order.NgayDat.Value.Month == selectedMonth
                                    && order.NgayDat.Value.Year == selectedYear))
                    .ToList();

                if (filteredOrders.Count == 0)
                {
                    MessageBox.Show("Không có đơn hàng online cho tháng và năm đã chọn để xuất.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string fileName = string.Empty;
                bool exportResult = dt.ExportOffline(filteredOrders, ref fileName, false);

                if (!exportResult)
                {
                    MessageBox.Show("Xuất dữ liệu ra Excel không thành công.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (System.IO.File.Exists(fileName))
                {
                    dt.OpenFile(fileName);
                }
                else
                {
                    MessageBox.Show("File xuất ra không tìm thấy.", "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadChartData(int thang, int nam)
        {
            try
            {
                DataTable dtOnline = dhb.GetDoanhThuOfflineTheoThangNam(thang, nam);

                chart_Offline.Series.Clear();
                chart_Offline.ChartAreas.Clear();
                chart_Offline.Legends.Clear();

                ChartArea chartAreaOnline = new ChartArea("MainAreaOnline");
                chart_Offline.ChartAreas.Add(chartAreaOnline);

                Series seriesOnline = new Series("Doanh Thu Online")
                {
                    ChartType = SeriesChartType.Line
                };

                foreach (DataRow row in dtOnline.Rows)
                {
                    seriesOnline.Points.AddXY(row["Ngay"], row["TongTien"]);
                }

                chart_Offline.Series.Add(seriesOnline);
                seriesOnline.Label = "#VALY";
                seriesOnline.LegendText = "Online";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message);
            }
        }
    }
}
