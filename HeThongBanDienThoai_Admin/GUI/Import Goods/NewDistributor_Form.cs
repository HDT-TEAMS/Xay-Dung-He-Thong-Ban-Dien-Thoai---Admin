using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Import_Goods
{
    public partial class NewDistributor_Form : Form
    {
        public delegate void DataUpdatedHandler();
        public event DataUpdatedHandler DataUpdated;

        private int _maNCC;
        private NhaCungCap_BUS nccb = new NhaCungCap_BUS();

        public NewDistributor_Form()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click1;
        }

        public NewDistributor_Form(int maNCC)
        {
            InitializeComponent();
            this._maNCC = maNCC;
            loadData(maNCC);
            this.btnSave.Click += BtnSave_Click1;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_Click1(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút save thêm
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNCC.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNCC.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Focus();
                    return;
                }

                NhaCC nhacc = new NhaCC()
                {
                    TenNCC = txtTenNCC.Text,
                    MaNB = txtMaNCC.Text,
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text
                };

                nccb.InsertNhaCungCap(nhacc);
                MessageBox.Show("Insert thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataUpdated?.Invoke(); // Kích hoạt sự kiện khi dữ liệu được thêm
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút save sửa
        private void BtnSave_Click1(object sender, EventArgs e)
        {
            try
            {
                NhaCC ncc = nccb.getNhaCCByMaNCC(this._maNCC);
                if (ncc != null)
                {
                    ncc.TenNCC = txtTenNCC.Text;
                    ncc.MaNB = txtMaNCC.Text;
                    ncc.SDT = txtSDT.Text;
                    ncc.DiaChi = txtDiaChi.Text;
                    nccb.UpdateNhaCungCap(ncc);
                }
                MessageBox.Show("Updated thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataUpdated?.Invoke(); // Kích hoạt sự kiện khi dữ liệu được sửa
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadData(int maNCC)
        {
            NhaCC ncc = nccb.getNhaCCByMaNCC(maNCC);
            txtTenNCC.Text = ncc.TenNCC;
            txtMaNCC.Text = ncc.MaNB;
            txtSDT.Text = ncc.SDT;
            txtDiaChi.Text = ncc.DiaChi;
        }
    }

}
