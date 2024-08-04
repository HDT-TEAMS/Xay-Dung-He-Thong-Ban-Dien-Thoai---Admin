using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
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
            btnSave.Click += BtnSave_Click1;
        }

       

        public EditCustomerForm()
        {
            InitializeComponent();
            heading_text.Text = "Thêm mới khách hàng";
            txtID.Text = MyLib.GenerateCustomerCode().ToString();
            txtID.Enabled = false;
            btnSave.Click += BtnSave_Click;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Mã người bán không được để trống.");
                txtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống.");
                txtName.Focus();
                return;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                cmbGender.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPhoneBox.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.");
                txtPhoneBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống.");
                txtEmail.Focus();
                return;
            }

            string maNB = txtID.Text;
            string tenKH = txtName.Text;
            DateTime ngaySinh = DateTime.Parse(txtDate.Text);
            string gioiTinh = cmbGender.SelectedItem.ToString();
            string sdt = txtPhoneBox.Text;
            string diaChi = txtAddress.Text;
            string email = txtEmail.Text;

            if (khBUS.LoadKH().Any(kh => kh.SDT == sdt))
            {
                MessageBox.Show("Số điện thoại đã tồn tại !");
                txtPhoneBox.Focus();  
                return;
            }

            if (khBUS.LoadKH().Any(kh => kh.Email == email))
            {
                MessageBox.Show("Email đã tồn tại !");
                txtPhoneBox.Focus();
                return;
            }

            KhachHang khachHang = new KhachHang
            {
                MaNB = maNB,
                TenKH = tenKH,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                SDT = sdt,
                DiaChi = diaChi,
                Email = email,
                IsDeleted = false,
            };

            khBUS.InsertKhachHang(khachHang);

            MessageBox.Show("Thêm khách hàng thành công !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            this.Close();
        }

        private void BtnSave_Click1(object sender, EventArgs e)
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

