using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Staff_Form
{
    public partial class QL_StaffForm : Form
    {
        NhanVien_BUS nvBUS = new NhanVien_BUS();
        public QL_StaffForm()
        {
            InitializeComponent();
            this.Load += QL_StaffForm_Load;
            dataGridViewStaff.CellContentClick += DataGridViewStaff_CellContentClick;

           
        }

      
        private void DataGridViewStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewStaff.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của nhân viên từ hàng hiện tại
                string employeeId = dataGridViewStaff.Rows[e.RowIndex].Cells["MaNB"].Value.ToString();

                // Tạo form chỉnh sửa và truyền ID nhân viên
                EditStaffForm editStaffForm = new EditStaffForm(employeeId);
                editStaffForm.Show();
            }
            if (e.ColumnIndex == dataGridViewStaff.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                // Lấy ID của khách hàng từ hàng hiện tại
                string employeeId = dataGridViewStaff.Rows[e.RowIndex].Cells["MaNB"].Value.ToString();

                // Xóa khách hàng
                try
                {
                    nvBUS.DeleteNhanVien(employeeId);
                    MessageBox.Show("Nhân viên đã được xóa thành công.");
                    LoadNV(); // Làm mới danh sách khách hàng
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void QL_StaffForm_Load(object sender, EventArgs e)
        {
            LoadNV();
        }

        public void LoadNV()
        {
            dataGridViewStaff.DataSource = nvBUS.LoadNV();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadNV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertStaffForm insertStaffForm = new InsertStaffForm();
            insertStaffForm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            List<NhanVien> result = nvBUS.SearchNhanVienByName(searchText);
            dataGridViewStaff.DataSource = result;
        }
    }
}
