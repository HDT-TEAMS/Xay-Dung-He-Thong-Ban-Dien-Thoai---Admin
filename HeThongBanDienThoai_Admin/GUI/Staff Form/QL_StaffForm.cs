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
            dataGridViewUser.CellContentClick += DataGridViewStaff_CellContentClick;
        }

      
        private void DataGridViewStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int employeeId = Convert.ToInt32(dataGridViewUser.Rows[e.RowIndex].Cells["MaNV"].Value.ToString());
            if (e.ColumnIndex == dataGridViewUser.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                EditStaffForm editStaffForm = new EditStaffForm(employeeId);
                editStaffForm.Show();
            }
            if (e.ColumnIndex == dataGridViewUser.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        nvBUS.DeleteNhanVien(employeeId);
                        MessageBox.Show("Nhân viên đã được xóa thành công.");
                        LoadNV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        private void QL_StaffForm_Load(object sender, EventArgs e)
        {
            LoadNV();
        }

        public void LoadNV()
        {
            dataGridViewUser.DataSource = nvBUS.LoadNV();
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
            dataGridViewUser.DataSource = result;
        }
    }
}
