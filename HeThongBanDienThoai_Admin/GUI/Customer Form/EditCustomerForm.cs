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

namespace HeThongBanDienThoai_Admin.GUI.Customer_Form
{
    public partial class EditCustomerForm : Form
    {
        KhachHang_BUS khBUS = new KhachHang_BUS();
        public string _customerId;
        public EditCustomerForm(string customerId)
        {
            _customerId = customerId;
            InitializeComponent();
            LoadCustomerData();
            this.txtID.Enabled = false;
        }
        public void LoadCustomerData()
        {
            try
            {
                KhachHang customer = khBUS.GetKhachHangById(_customerId); // Sử dụng phương thức mới

                if (customer != null)
                {
                    // Điền dữ liệu vào các trường của form
                    txtID.Text = customer.MaNB;
                    txtName.Text = customer.TenKH;
                    txtDate.Value = customer.NgaySinh ?? DateTime.Now;
                    cmbGender.Text = customer.GioiTinh;
                    txtPhoneBox.Text = customer.SDT;
                    txtEmail.Text = customer.Email;
                    txtAddress.Text = customer.DiaChi;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            KhachHang updatedCustomer = new KhachHang
            {
                MaNB = txtID.Text,
                TenKH = txtName.Text,
                NgaySinh = txtDate.Value,
                GioiTinh = cmbGender.Text,
                SDT = txtPhoneBox.Text,
                DiaChi = txtAddress.Text
            };
            // Validate inputs
            if (string.IsNullOrWhiteSpace(updatedCustomer.TenKH) ||
                string.IsNullOrWhiteSpace(updatedCustomer.DiaChi) ||
                string.IsNullOrWhiteSpace(updatedCustomer.GioiTinh) ||
                string.IsNullOrWhiteSpace(updatedCustomer.SDT))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Update employee data using the business logic layer with the correct method
                khBUS.UpdateKhachHang(updatedCustomer); // Ensure this method accepts KhachHang object
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

