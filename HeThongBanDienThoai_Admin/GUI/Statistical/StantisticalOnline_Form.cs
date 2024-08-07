using BUS;
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
using DTO;
namespace HeThongBanDienThoai_Admin.GUI.Statistical
{
    public partial class StantisticalOnline_Form : Form
    {
        private DonHang_BUS dhb = new DonHang_BUS();
        public StantisticalOnline_Form()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DonHang_BUS dhb = new DonHang_BUS();
                ExcelExport dt = new ExcelExport();

                // Kiểm tra dữ liệu nhập vào có hợp lệ không
                if (!int.TryParse(txtThang.Text, out int selectedMonth) || !int.TryParse(txtNam.Text, out int selectedYear))
                {
                    MessageBox.Show("Vui lòng nhập tháng và năm hợp lệ.", "Lỗi Nhập Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy danh sách đơn hàng
                List<View_DanhSachDonHang> allOrders = dhb.getDanhSachDonHang();

                // Kiểm tra danh sách đơn hàng
                if (allOrders == null || allOrders.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lọc đơn hàng theo tháng, năm và loại hóa đơn
                var filteredOrders = allOrders
                    .Where(order => (order.MaNB != null && (order.MaNB.StartsWith("DHTT") || order.MaNB.StartsWith("DHMM"))
                                    && order.NgayDat.HasValue
                                    && order.NgayDat.Value.Month == selectedMonth
                                    && order.NgayDat.Value.Year == selectedYear))
                    .ToList();

                // Kiểm tra danh sách đơn hàng đã lọc
                if (filteredOrders.Count == 0)
                {
                    MessageBox.Show("Không có đơn hàng online cho tháng và năm đã chọn để xuất.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xuất dữ liệu ra file Excel
                string fileName = string.Empty;
                bool exportResult = dt.ExportOnline(filteredOrders, ref fileName, false, true);

                // Kiểm tra kết quả xuất dữ liệu
                if (!exportResult)
                {
                    MessageBox.Show("Xuất dữ liệu ra Excel không thành công.", "Lỗi Xuất Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mở file Excel nếu xuất thành công
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
                DataTable dtOnline = dhb.GetDoanhThuOnlineTheoThangNam(thang, nam);

                // Xóa các phần tử cũ
                chart_xuatOnline.Series.Clear();
                chart_xuatOnline.ChartAreas.Clear();
                chart_xuatOnline.Legends.Clear();

                // Thiết lập ChartArea
                ChartArea chartAreaOnline = new ChartArea("MainAreaOnline");
                chart_xuatOnline.ChartAreas.Add(chartAreaOnline);

                // Thiết lập Series
                Series seriesOnline = new Series("Doanh Thu Online")
                {
                    ChartType = SeriesChartType.Line
                };

                // Thêm dữ liệu vào Series
                foreach (DataRow row in dtOnline.Rows)
                {
                    seriesOnline.Points.AddXY(row["Ngay"], row["TongTien"]);
                }

                // Thêm Series vào Chart
                chart_xuatOnline.Series.Add(seriesOnline);
                seriesOnline.Label = "#VALY";
                seriesOnline.LegendText = "Online";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // Xác thực đầu vào
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

            // Gọi phương thức để tải dữ liệu và hiển thị trên biểu đồ
            loadChartData(thang, nam);
        }

    }
}
