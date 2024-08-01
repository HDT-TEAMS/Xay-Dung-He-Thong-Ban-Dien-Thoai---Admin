using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Role_Form;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;

namespace HeThongBanDienThoai_Admin.GUI.User_Form
{
    public partial class QL_UserForm : Form
    {
        NguoiDung_BUS ndBUS = new NguoiDung_BUS();
        public QL_UserForm()
        {
            InitializeComponent();
            this.Load += QL_UserForm_Load;
            dataGridViewUser.CellContentClick += DataGridViewUser_CellContentClick;
        }

        private void DataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewUser.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridViewUser.Rows[e.RowIndex].Cells["MaND"].Value);
                UserAssignRoleForm updateUserForm = new UserAssignRoleForm(userId);
                updateUserForm.Show();
            }
        }

        private void QL_UserForm_Load(object sender, EventArgs e)
        {
            LoadND();
        }
        public void LoadND()
        {
            dataGridViewUser.DataSource = ndBUS.LoadND();
        }
    }
}
