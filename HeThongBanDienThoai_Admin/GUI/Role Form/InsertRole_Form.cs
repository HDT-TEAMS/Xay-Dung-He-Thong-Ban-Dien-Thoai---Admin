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

namespace HeThongBanDienThoai_Admin.GUI.Role_Form
{
    public partial class InsertRole_Form : Form
    {
        private Quyen_BUS rBUS = new Quyen_BUS();
        public InsertRole_Form()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate Role Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên quyền không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newRole = new Quyen
            {
                TenQuyen = txtName.Text
            };

            await Task.Run(() => rBUS.addUser(newRole));
            MessageBox.Show("Thêm quyền mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            EditRoleForm edit = new EditRoleForm(newRole.MaQuyen);
            edit.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
