using BUS;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Configuration
{
    public partial class AddLoai_Form : Form
    {
        private Loai_BUS  lb = new Loai_BUS();
        private int _id;
        public AddLoai_Form()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
        }

      
        public AddLoai_Form(int id)
        {
            InitializeComponent();
            this._id = id;
            Loai loai = lb.getLoaiByMal(id);
            txtID.Text = loai.MaNB;
            txtName.Text = loai.TenLoai;
            label1.Text = "Sửa Loại";
            this.btnSave.Click += BtnSave_Click1;
        }

        private void BtnSave_Click1(object sender, EventArgs e)
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



                Loai loai = new Loai()
                {
                    Maloai = _id,
                    TenLoai = txtName.Text,
                    MaNB = txtID.Text,
                    IsDeleted = false
                };

                lb.UpdateLoai(loai);
                MessageBox.Show("Update thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
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

                Loai loai = new Loai()
                {
                    TenLoai = txtName.Text,
                    MaNB = txtID.Text,
                    IsDeleted = false
                };

                lb.InsertLoai(loai);
                MessageBox.Show("Insert thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
