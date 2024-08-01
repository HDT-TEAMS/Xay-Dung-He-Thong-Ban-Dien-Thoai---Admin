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

namespace HeThongBanDienThoai_Admin.GUI.User_Form
{
    public partial class UserAssignRoleForm : Form
    {
        private int _userId;
        private NguoiDung_BUS ndBUS = new NguoiDung_BUS();
        private Quyen_BUS qBUS = new Quyen_BUS();
        private List<Quyen> allRoles;
        public UserAssignRoleForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            this.Load += UserAssignRoleForm_Load;
            this.dataGridViewRoles.CurrentCellDirtyStateChanged += DataGridViewRoles_CurrentCellDirtyStateChanged1;
            dataGridViewRoles.CellValueChanged += DataGridViewRoles_CellValueChanged;

            ConfigureDataGridView();
        }

        private void DataGridViewRoles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRoles.Columns["Check"].Index && e.RowIndex >= 0)
            {
                bool isChecked = (bool)dataGridViewRoles.Rows[e.RowIndex].Cells["Check"].Value;
                int roleId = (int)dataGridViewRoles.Rows[e.RowIndex].Cells["MaQuyen"].Value;

                if (isChecked)
                {
                    qBUS.AddRoleToUser(_userId, roleId);
                }
                else
                {
                    qBUS.RemoveRoleFromUser(_userId, roleId);
                }
            }
        }

        private void DataGridViewRoles_CurrentCellDirtyStateChanged1(object sender, EventArgs e)
        {
            if (dataGridViewRoles.IsCurrentCellDirty)
            {
                dataGridViewRoles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UserAssignRoleForm_Load(object sender, EventArgs e)
        {
            LoadUserDetails();
            LoadUserRoles();
        }
        private void LoadUserDetails()
        {
            var user = ndBUS.GetNguoiDungById(_userId);
            if (user != null)
            {
                txtName.Text = user.UserName;
            }
        }

        

        private void DataGridViewRoles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
           
        }

        private void ConfigureDataGridView()
        {
            // Tạo cột checkbox
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "Check";
            checkBoxColumn.HeaderText = "Chọn";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;

            // Thêm cột checkbox vào DataGridView
            dataGridViewRoles.Columns.Add(checkBoxColumn);

            // Cấu hình các cột khác của DataGridView nếu cần thiết
        }
        private void LoadUserRoles()
        {
            allRoles = qBUS.LoadRole();

            // Lấy danh sách các quyền mà người dùng hiện tại có
            var userRoles = qBUS.GetChucNangByMaQuyen(_userId);

            // Tạo danh sách các quyền mà người dùng hiện tại có
            var userRoleIds = userRoles.Select(r => r.MaCN).ToList();

            // Gán danh sách quyền vào DataGridView
            dataGridViewRoles.DataSource = allRoles;

            // Đảm bảo 'Check' là tên của cột checkbox và 'MaQuyen' là cột ID quyền
            foreach (DataGridViewRow row in dataGridViewRoles.Rows)
            {
                if (row.DataBoundItem != null) // Đảm bảo có dữ liệu trong row
                {
                    var roleId = Convert.ToInt32(row.Cells["MaQuyen"].Value);

                    // Kiểm tra nếu người dùng có quyền này thì đánh dấu checkbox
                    row.Cells["Check"].Value = userRoleIds.Contains(roleId);
                }
            }
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var selectedRoles = new List<int>();
            var existingRoles = qBUS.GetChucNangByMaQuyen(_userId);

            foreach (DataGridViewRow row in dataGridViewRoles.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Check"].Value))
                {
                    selectedRoles.Add(Convert.ToInt32(row.Cells["MaQuyen"].Value));
                }
            }

            var userAssignedRoles = existingRoles.Select(r => r.MaCN).ToList();
            var rolesToAdd = selectedRoles.Except(userAssignedRoles).ToList();
            var rolesToRemove = userAssignedRoles.Except(selectedRoles).ToList();

            foreach (var roleId in rolesToAdd)
            {
                qBUS.AddRoleToUser(_userId, roleId);
            }

            foreach (var roleId in rolesToRemove)
            {
                qBUS.RemoveRoleFromUser(_userId, roleId);
            }


            MessageBox.Show("Cập nhật quyền thành công.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}