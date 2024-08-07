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

namespace HeThongBanDienThoai_Admin.GUI.Configuration
{
    public partial class AddColor_Form : Form
    {
        MauSac_BUS mausacbus = new MauSac_BUS();

        public delegate void DataUpdatedHandler();
        public event DataUpdatedHandler DataUpdated;
        public AddColor_Form()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Tên không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Mã không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Focus();
                    return;
                }

                

                MauSac color = new MauSac()
                {
                    TenMau = txtName.Text,
                    MaNB = txtID.Text,
                    IsDeleted = false
                };

                mausacbus.InsertMauSac(color);
                MessageBox.Show("Insert thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataUpdated?.Invoke(); // Kích hoạt sự kiện khi dữ liệu được thêm
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
