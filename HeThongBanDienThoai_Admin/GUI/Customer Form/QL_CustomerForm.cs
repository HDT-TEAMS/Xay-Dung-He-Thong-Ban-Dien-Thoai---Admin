using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;

namespace HeThongBanDienThoai_Admin.GUI.Customer_Form
{
    public partial class QL_CustomerForm : Form
    {
        KhachHang_BUS khBUS = new KhachHang_BUS();
        public QL_CustomerForm()
        {
            InitializeComponent();
            this.Load += QL_CustomerForm_Load;
            dataGridViewCustomer.CellContentClick += DataGridViewCustomer_CellContentClick;
        }

        private void DataGridViewCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCustomer.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của nhân viên từ hàng hiện tại
                string customerId = dataGridViewCustomer.Rows[e.RowIndex].Cells["MaNB"].Value.ToString();

                // Tạo form chỉnh sửa và truyền ID nhân viên
                EditCustomerForm editStaffForm = new EditCustomerForm(customerId);
                editStaffForm.Show();
            }

            if (e.ColumnIndex == dataGridViewCustomer.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của khách hàng từ hàng hiện tại
                string customerId = dataGridViewCustomer.Rows[e.RowIndex].Cells["MaNB"].Value.ToString();

                // Xóa khách hàng
                try
                {
                    khBUS.DeleteKhachHang(customerId);
                    MessageBox.Show("Khách hàng đã được xóa thành công.");
                    LoadKH(); // Làm mới danh sách khách hàng
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void QL_CustomerForm_Load(object sender, EventArgs e)
        {
            LoadKH();
        }
        public void DeleteKH()
        {
            dataGridViewCustomer.DataSource = khBUS.LoadKH();
        }
        public void LoadKH()
        {
            dataGridViewCustomer.DataSource = khBUS.LoadKH();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadKH();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            List<KhachHang> result = khBUS.SearchKhachHangByName(searchText);
            dataGridViewCustomer.DataSource = result;
        }
    }
}
