using BUS;
using HeThongBanDienThoai_Admin.GUI.Customer_Form;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;
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
    public partial class QL_RoleForm : Form
    {
        Quyen_BUS rBUS = new Quyen_BUS();
        public QL_RoleForm()
        {
            InitializeComponent();
            this.Load += QL_RoleForm_Load;
            dataGridViewRole.CellContentClick += DataGridViewRole_CellContentClick;
        }

        private void DataGridViewRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRole.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                string roleIdString = dataGridViewRole.Rows[e.RowIndex].Cells["MaQuyen"].Value.ToString();

                if (int.TryParse(roleIdString, out int roleId))
                {
                    EditRoleForm editRoleForm = new EditRoleForm(roleId);
                    editRoleForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid role ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void QL_RoleForm_Load(object sender, EventArgs e)
        {
            LoadRole();
        }
        public void LoadRole()
        {
            dataGridViewRole.DataSource = rBUS.LoadRole();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadRole();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertRole_Form insertr = new InsertRole_Form();
            insertr.Show();
        }


    }
}
