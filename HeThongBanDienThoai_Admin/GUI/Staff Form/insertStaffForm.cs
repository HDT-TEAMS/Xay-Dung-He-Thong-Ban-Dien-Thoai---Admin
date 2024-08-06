using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Staff_Form
{
    public partial class InsertStaffForm : Form
    {
        NhanVien_BUS nvBUS = new NhanVien_BUS();
        NguoiDung_BUS ndBUS = new NguoiDung_BUS();
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

            try
            {
                // Check if employee ID already exists
                if (nvBUS.IsEmployeeIDExists(id))
                {
                    MessageBox.Show($"Mã nhân viên {id} đã có.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new NguoiDung object
                NguoiDung newND = new NguoiDung
                {
                    UserName = id,
                    PassWord = MyLib.HashPassword(id.ToString()),
                    IsDeleted = false
                };
                
                if (nvBUS.checkMaNB(id))
                {
                    ndBUS.AddNguoiDung(newND); // Add new user to the database
                }
                else
                {
                    MessageBox.Show("Mã nội bộ nhân viên đã tồn tại !!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                // Add new employee to the database
                nvBUS.AddNhanVien(newND.MaND, id, name, dateOfBirth, gender, phone, email);

                MessageBox.Show("Thêm nhân viên thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form fields
                txtID.Clear();
                txtName.Clear();
                txtEmail.Clear();
                txtPhoneBox.Clear();
                txtDate.Value = DateTime.Now;
                cmbGender.SelectedIndex = -1;
                txtPhoneBox.Clear();
                txtID.Focus();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
