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
                // Get the value from the "MaQuyen" cell and convert it to string
                string roleIdString = dataGridViewRole.Rows[e.RowIndex].Cells["MaQuyen"].Value.ToString();

                // Try to convert the string to an integer
                if (int.TryParse(roleIdString, out int roleId))
                {
                    // Create the form for editing and pass the integer ID
                    EditRoleForm editRoleForm = new EditRoleForm(roleId);
                    editRoleForm.Show();
                }
                else
                {
                    // Handle the case where conversion fails
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
       
        }


    }
}
