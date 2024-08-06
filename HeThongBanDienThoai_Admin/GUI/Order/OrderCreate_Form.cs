using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Import_Goods;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Order
{
    public partial class OrderCreate_Form : Form
    {
        private readonly DonHang_BUS dhb = new DonHang_BUS();
        private Dictionary<string, DataGridView> dataGridViewsByStatus;
    

        public OrderCreate_Form()
        {
            InitializeComponent();
            InitializeDataGridViewsByStatus();
            InitializeDataGridViewEventHandlers();
        }

        private void InitializeDataGridViewsByStatus()
        {
            dataGridViewsByStatus = new Dictionary<string, DataGridView>
            {
                { "Chờ xác nhận", dgv_ChoXacNhan },
                { "Đã xác nhận", dgv_DaXacNhap },
                { "Đang giao hàng", dgv_DangGiaoHang },
                { "Đã hủy", dgv_DaHuy },
                { "Đã hoàn thành", dgv_DaHoanThanh }
            };
        }

        private void OrderCreate_Form_Load(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void LoadAllOrders()
        {
            foreach (var entry in dataGridViewsByStatus)
            {
                LoadDataByStatus(entry.Key, entry.Value);
            }
        }

        private void LoadDataByStatus(string status, DataGridView dgv)
        {
            var orders = dhb.getDanhSachDonHang()
                             ?.Where(dh => dh.TrangThai == status)
                             .ToList();
            dgv.DataSource = orders;
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            var dgv = sender as DataGridView;
            if (dgv?.CurrentRow == null) return;

            var columnName = GetColumnName(dgv);
            if (columnName == null) return;

            if (int.TryParse(dgv.CurrentRow.Cells[columnName].FormattedValue.ToString(), out int maDH))
            {
                MyLib.LoadForm(this, new OrderProcessing_Form(maDH));
            }
        }

        private string GetColumnName(DataGridView dgv)
        {
            if (dgv == dgv_ChoXacNhan) return "MaDH1";
            if (dgv == dgv_DaXacNhap) return "MaDH2";
            if (dgv == dgv_DangGiaoHang) return "MaDH3";
            if (dgv == dgv_DaHuy) return "MaDH4";
            if (dgv == dgv_DaHoanThanh) return "MaDH5";
            return null;
        }

        private void InitializeDataGridViewEventHandlers()
        {
            foreach (var dgv in dataGridViewsByStatus.Values)
            {
                dgv.CellClick += DataGridView_CellClick;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch == null)
            {
                throw new InvalidOperationException("txtSearch is not initialized.");
            }

            string searchTerm = txtSearch.Text.Trim();

            if (dhb == null)
            {
                throw new InvalidOperationException("dhb is not initialized.");
            }

            var allOrders = dhb.getDanhSachDonHang();

            if (allOrders == null)
            {
                UpdateDataGridViews(new List<View_DanhSachDonHang>());
                return;
            }

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAllOrders();
            }
            else
            {
                var filteredOrders = allOrders
                                     .Where(dh => dh.MaNB != null && dh.MaNB.ToString().IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                                     .ToList();

                UpdateDataGridViews(filteredOrders);
            }
        }



        private void UpdateDataGridViews(List<View_DanhSachDonHang> orders)
        {
            foreach (var entry in dataGridViewsByStatus)
            {
                entry.Value.DataSource = orders.Where(dh => dh.TrangThai == entry.Key).ToList();
            }
        }
    }
}
