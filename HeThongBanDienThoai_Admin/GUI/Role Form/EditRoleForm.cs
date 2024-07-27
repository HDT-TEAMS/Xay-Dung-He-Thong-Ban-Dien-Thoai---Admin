using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;
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
using System.Xml.Linq;

namespace HeThongBanDienThoai_Admin.GUI.Role_Form
{
    public partial class EditRoleForm : Form
    {

        Quyen_BUS rBUS = new Quyen_BUS();
        public int _roleID;
        public EditRoleForm(int roleID)
        {
            _roleID = roleID;
            InitializeComponent();
            LoadRole();
            LoadChucNang();
        }
        public void LoadRole()
        {

            try
            {
                Quyen quyen = rBUS.GetQuyenById(_roleID); // Sử dụng phương thức mới

                if (quyen != null)
                {
                    txtName.Text = quyen.TenQuyen;

                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void LoadChucNang()
        {
            try
            {
                List<ChucNang> chucNangs = rBUS.GetChucNangByMaQuyen(_roleID);

                if (chucNangs != null && chucNangs.Count > 0)
                {
                    dataGridViewChucNang.DataSource = chucNangs;
                    this.txtName.Enabled = false;
                    
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chức năng cho quyền này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewChucNang.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu chức năng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
