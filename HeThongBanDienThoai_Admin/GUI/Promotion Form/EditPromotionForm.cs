using BUS;
using DTO;
using MyControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Promotion_Form
{
    public partial class EditPromotionForm : Form
    {
        KhuyenMai_BUS kmBUS = new KhuyenMai_BUS();
        public EditPromotionForm()
        {
            InitializeComponent();
            this.Load += EditPromotionForm_Load;
            this.txtDisscount.KeyPress += TxtDisscount_KeyPress;
        }

        private void TxtDisscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;                                                                                                                                                                                                                                                                                                                                  
            }
        }

        private void EditPromotionForm_Load(object sender, EventArgs e)
        {
            LoadKM();
        }

        public void LoadKM()
        {
            dataGridViewPromotion.DataSource = kmBUS.LoadKM();
        }

        
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string name = txtName.Text;
            DateTime dateStart = txtStartDate.Value;
            DateTime dateEnd = txtEndDate.Value;
            string discountText = txtDisscount.Text;  // Use this for validation and conversion

            if (kmBUS.IsDiscountIDExists(ID))
            {
                MessageBox.Show($"Mã khuyến mãi {ID} đã có.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate inputs
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng không bỏ trống.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate date range
            if (dateStart >= dateEnd)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate and convert discount
            int discount;
            if (!int.TryParse(discountText, out discount))
            {
                MessageBox.Show("Vui lòng nhập giá trị giảm giá hợp lệ.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KhuyenMai newKM = new KhuyenMai
            {
                MaNB = ID,
                TenKM = name,
                NgayBD = dateStart,
                NgayKT = dateEnd,
                GiamGia = discount  // Set the discount property
            };

            try
            {
                kmBUS.AddKhuyenMai(newKM);
                MessageBox.Show("Thêm khuyến mãi thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtID.Clear();
                txtName.Clear();
                txtStartDate.Value = DateTime.Now;
                txtEndDate.Value = DateTime.Now;
                txtDisscount.Clear();  // Clear the discount textbox
                txtID.Focus();
                LoadKM();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
