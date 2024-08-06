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
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HeThongBanDienThoai_Admin.GUI.User_Form
{
    public partial class UserAssignRoleForm : Form
    {
        private int _userId;
        private NguoiDung_BUS ndBUS = new NguoiDung_BUS();
        private Quyen_BUS qBUS = new Quyen_BUS();
        private QuyenNguoiDung_BUS qndB = new QuyenNguoiDung_BUS();
        private List<Quyen> selectRole;
        public UserAssignRoleForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserDetails();
            LoadRoleByUser(userId);
            this.btnSave.Click += BtnSave_Click;
        }

      

        private void LoadUserDetails()
        {
            var user = ndBUS.GetNguoiDungById(_userId);
            if (user != null)
            {
                txtName.Text = user.UserName;
            }
        }

        public async Task<List<Quyen>> LoadRoleAsync()
        {
            return await Task.Run(() => qBUS.LoadRole());
        }

        public async Task<List<int>> GetQuyenNguoiDungAsync(int maND)
        {
            return await Task.Run(() => qndB.GetQuyenNguoiDung(maND));
        }


        private async void LoadRoleByUser(int maND)
        {
            try
            {
                var roleList = await LoadRoleAsync();
                var userRoleList = await GetQuyenNguoiDungAsync(maND);
                dataGridViewRoles.DataSource = roleList;
                foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                {
                    if (row.Cells["MaQuyen"].Value != null)
                    {
                        int maQuyen = Convert.ToInt32(row.Cells["MaQuyen"].Value);
                        row.Cells["checkRole"].Value = userRoleList.Contains(maQuyen);
                    }
                }
                dataGridViewRoles.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPass_Form refs = new ResetPass_Form(_userId);
            refs.Show();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var existingRoles = await GetQuyenNguoiDungAsync(_userId);
                var newRoles = new List<int>();

                foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                {
                    if (row.Cells["MaQuyen"].Value != null)
                    {
                        int maQuyen = Convert.ToInt32(row.Cells["MaQuyen"].Value);
                        bool isChecked = Convert.ToBoolean(row.Cells["checkRole"].Value);

                        if (isChecked)
                        {
                            newRoles.Add(maQuyen);
                        }
                    }
                }
                var rolesToAdd = newRoles.Except(existingRoles).ToList();
                var rolesToRemove = existingRoles.Except(newRoles).ToList();
                await qndB.UpdateUserRolesAsync(_userId, rolesToAdd, rolesToRemove);

                MessageBox.Show("Quyền của người dùng đã được cập nhật thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

    }
}