﻿using BUS;
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
    public partial class EditStaffForm : Form
    {
        NhanVien_BUS nvBUS = new NhanVien_BUS();
        public int _employeeId;
        public EditStaffForm(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            this.txtID.Enabled = false;
            LoadEmployeeData();
        }
        public void LoadEmployeeData()
        {
            try
            {
                NhanVien employee = nvBUS.GetNhanVienById(_employeeId); // Sử dụng phương thức mới

                if (employee != null)
                {
                    txtID.Text = employee.MaNB;
                    txtName.Text = employee.TenNV;
                    txtDate.Value = employee.NgaySinh ?? DateTime.Now;
                    cmbGender.Text = employee.GioiTinh;
                    txtPhoneBox.Text = employee.SDTNV;
                    txtEmail.Text = employee.Email;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            NhanVien updatedEmployee = new NhanVien
            {
                MaNV = _employeeId,
                MaNB = txtID.Text,
                TenNV = txtName.Text,
                NgaySinh = txtDate.Value,
                GioiTinh = cmbGender.Text,
                SDTNV = txtPhoneBox.Text,
                Email = txtEmail.Text,     
            };

            // Validate inputs
            if (string.IsNullOrWhiteSpace(updatedEmployee.TenNV) ||
                string.IsNullOrWhiteSpace(updatedEmployee.Email)||
                string.IsNullOrWhiteSpace(updatedEmployee.GioiTinh) ||
                string.IsNullOrWhiteSpace(updatedEmployee.SDTNV))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nvBUS.UpdateNhanVien(updatedEmployee);
                MessageBox.Show("Cập nhật nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
