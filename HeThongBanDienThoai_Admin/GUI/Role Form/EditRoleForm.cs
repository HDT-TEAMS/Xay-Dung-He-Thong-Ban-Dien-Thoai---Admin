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
            loadDetail();
            LoadChucNangAsync();
        }

        public void loadDetail()
        {
            txtName.Enabled = false;
            var role = rBUS.GetQuyenById( _roleID );
            if (role != null)
            {
                txtName.Text = role.TenQuyen;
            }
        }

        public async Task LoadChucNangAsync()
        {
            try
            {
                List<ChucNang> allChucNangs = await Task.Run(() => rBUS.GetAllChucNangs());
                List<ChucNang> roleChucNangs = await Task.Run(() => rBUS.GetChucNangByMaQuyen(_roleID));

                dataGridViewChucNang.DataSource = allChucNangs;
                if (dataGridViewChucNang == null || dataGridViewChucNang.Rows.Count == 0)
                {
                    MessageBox.Show("DataGridView is empty or not initialized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataGridViewRow row in dataGridViewChucNang.Rows)
                {
                    if (row.IsNewRow) continue; 
                    int maCN = Convert.ToInt32(row.Cells["MaCN"].Value);
                    bool isChecked = roleChucNangs.Any(cn => cn.MaCN == maCN);
                    row.Cells["Check"].Value = isChecked;
                }
                dataGridViewChucNang.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu chức năng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ChucNang> allChucNangs = await Task.Run(() => rBUS.GetAllChucNangs());
                List<ChucNang> roleChucNangs = await Task.Run(() => rBUS.GetChucNangByMaQuyen(_roleID));
                var checkedChucNangs = new HashSet<int>();
                foreach (DataGridViewRow row in dataGridViewChucNang.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool isChecked = Convert.ToBoolean(row.Cells["Check"].Value);
                    int maCN = Convert.ToInt32(row.Cells["MaCN"].Value);

                    if (isChecked)
                    {
                        checkedChucNangs.Add(maCN);
                    }
                }
                var currentChucNangs = roleChucNangs.Select(cn => cn.MaCN).ToHashSet();
                var toAdd = checkedChucNangs.Except(currentChucNangs);
                var toRemove = currentChucNangs.Except(checkedChucNangs);
                foreach (var chucNangId in toAdd)
                {
                    await Task.Run(() => rBUS.AddChucNangToRole(_roleID, chucNangId));
                }
                foreach (var chucNangId in toRemove)
                {
                    await Task.Run(() => rBUS.RemoveChucNangFromRole(_roleID, chucNangId));
                }

                MessageBox.Show("Chức năng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lưu dữ liệu chức năng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
