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
    public partial class InsertStaffForm : Form
    {
        NhanVien_BUS nvBUS = new NhanVien_BUS();
        public InsertStaffForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            DateTime dateOfBirth = txtDate.Value; 
            string gender = cmbGender.Text;
            string phone = txtPhoneBox.Text;
            string email = txtEmail.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng không bỏ trống.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new NhanVien object
            NhanVien newEmployee = new NhanVien
            {
                MaNB = id,
                TenNV = name,
                NgaySinh = dateOfBirth,
                GioiTinh = gender,
                SDTNV = phone,
                Email = email,
                
                // Set other properties as needed
            };

            try
            {
                nvBUS.AddNhanVien(newEmployee);
                MessageBox.Show("Thêm nhân viên thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtID.Clear();
                txtName.Clear();
                txtDate.Value = DateTime.Now; 
                cmbGender.SelectedIndex = -1; 
                txtPhoneBox.Clear();
                txtID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
