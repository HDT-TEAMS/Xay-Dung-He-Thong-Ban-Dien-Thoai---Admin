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

namespace HeThongBanDienThoai_Admin.GUI.Statistical
{
    public partial class IndexStatistical_Form : Form
    {
        private ChiTietDonHang_BUS ctdhb = new ChiTietDonHang_BUS();
        private SanPham_BUS spb = new SanPham_BUS();
        public IndexStatistical_Form()
        {
            InitializeComponent();
            loadChartTop5SP();
            LoadSanPhamGanHetHangChart();
        }

        private void loadChartTop5SP()
        {
            try
            {
                DataTable dt = ctdhb.GetTop5SanPhamBanChayDataTable();
                chart_top5sp.Series.Clear();
                chart_top5sp.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("MainArea");
                chart_top5sp.ChartAreas.Add(chartArea);

                Series series = new Series("Top 5 Sản Phẩm Bán Chạy")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.Navy, 
                    BorderWidth = 3 
                };

                foreach (DataRow row in dt.Rows)
                {
                    DataPoint point = new DataPoint();
                    point.AxisLabel = row["TenSP"].ToString();
                    point.YValues = new double[] { Convert.ToDouble(row["TotalSold"]) };
                    point.Color = Color.FromArgb(100, 200, 250);
                    series.Points.Add(point);
                }
                chart_top5sp.Series.Add(series);

                Series lineSeries = new Series("Line")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Red, 
                    BorderWidth = 2 
                };

                foreach (DataRow row in dt.Rows)
                {
                    lineSeries.Points.AddXY(row["TenSP"], row["TotalSold"]);
                }

                chart_top5sp.Series.Add(lineSeries);

                // Thêm tiêu đề cho biểu đồ
                Title chartTitle = new Title
                {
                    Text = "Biểu Đồ Top 5 Sản Phẩm Bán Chạy Nhất",
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    ForeColor = Color.Blue
                };
                chart_top5sp.Titles.Add(chartTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message);
            }
        }

        private void LoadSanPhamGanHetHangChart()
        {
            try
            {
                DataTable dt = spb.GetSanPhamGanHetHangDataTable();

                chartsp_ganhh.Series.Clear();
                chartsp_ganhh.ChartAreas.Clear();
                chartsp_ganhh.Legends.Clear();

                ChartArea chartArea = new ChartArea("MainArea");
                chartsp_ganhh.ChartAreas.Add(chartArea);

                Series series = new Series("Sản Phẩm Gần Hết Hàng")
                {
                    ChartType = SeriesChartType.Pie
                };

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["TenSP"], row["SoLuong"]);
                }

                chartsp_ganhh.Series.Add(series);

                // Thiết lập nhãn và chú thích cho biểu đồ
                series.Label = "#PERCENT{P2}"; // Hiển thị phần trăm
                series.LegendText = "#VALX (#VALY)"; // Hiển thị tên sản phẩm và số lượng

                Legend legend = new Legend("Default");
                chartsp_ganhh.Legends.Add(legend);
                series.Legend = "Default";

                // Thêm tiêu đề cho biểu đồ
                Title chartTitle = new Title
                {
                    Text = "Biểu Đồ Sản Phẩm Gần Hết Hàng",
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    ForeColor = Color.Blue
                };
                chartsp_ganhh.Titles.Add(chartTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message);
            }
        }

        private void btnTKOL_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new StantisticalOnline_Form());
        }

        private void btnTKCH_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new StatisticalInStrore_Form());
        }
    }
}
