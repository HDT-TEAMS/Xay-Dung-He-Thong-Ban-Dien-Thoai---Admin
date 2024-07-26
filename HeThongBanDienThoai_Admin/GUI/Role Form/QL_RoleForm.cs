using BUS;
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
            insertRoleForm insertRole = new insertRoleForm();
            insertRole.Show();
        }
    }
}
