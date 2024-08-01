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
                // Lấy tất cả các chức năng từ BUS
                List<ChucNang> chucNangs = rBUS.GetAllChucNangs();

                // Lấy các chức năng đã được gán cho vai trò hiện tại
                List<ChucNang> assignedChucNangs = rBUS.GetChucNangByMaQuyen(_roleID);

                if (chucNangs != null && chucNangs.Count > 0)
                {
                    // Gán danh sách chức năng vào DataGridView
                    dataGridViewChucNang.DataSource = chucNangs;

                    // Đánh dấu các quyền đã được gán cho vai trò
                    foreach (DataGridViewRow row in dataGridViewChucNang.Rows)
                    {
                        // Đảm bảo hàng không phải là hàng tiêu đề
                        if (row.DataBoundItem != null)
                        {
                            var chucNangId = Convert.ToInt32(row.Cells["MaCN"].Value);
                            // Đánh dấu CheckBox nếu chức năng đã được gán cho vai trò
                            row.Cells["Check"].Value = assignedChucNangs.Any(cn => cn.MaCN == chucNangId);
                        }
                    }

                    // Vô hiệu hóa chỉnh sửa tên quyền
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedChucNangs = new List<int>();
                foreach (DataGridViewRow row in dataGridViewChucNang.Rows)
                {
                    // Kiểm tra nếu hàng không phải là hàng tiêu đề
                    if (row.DataBoundItem != null)
                    {
                        if (Convert.ToBoolean(row.Cells["Check"].Value))
                        {
                            selectedChucNangs.Add(Convert.ToInt32(row.Cells["MaCN"].Value));
                        }
                    }
                }

                var currentChucNangs = rBUS.GetChucNangByMaQuyen(_roleID).Select(cn => cn.MaCN).ToList();

                // Xác định các chức năng cần thêm và cần gỡ bỏ
                var chucNangsToAdd = selectedChucNangs.Except(currentChucNangs).ToList();
                var chucNangsToRemove = currentChucNangs.Except(selectedChucNangs).ToList();

                // Thêm chức năng mới
                foreach (var chucNangId in chucNangsToAdd)
                {
                    rBUS.AddChucNangToRole(_roleID, chucNangId);
                }

                // Gỡ bỏ chức năng không còn được chọn
                foreach (var chucNangId in chucNangsToRemove)
                {
                    rBUS.RemoveChucNangFromRole(_roleID, chucNangId);
                }

                MessageBox.Show("Cập nhật quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi lưu dữ liệu quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
