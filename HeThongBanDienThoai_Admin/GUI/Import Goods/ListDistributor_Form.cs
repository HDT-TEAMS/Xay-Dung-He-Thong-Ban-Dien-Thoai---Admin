using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Product;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Import_Goods
{
    public partial class ListDistributor_Form : Form
    {
        NhaCungCap_BUS nhaCungCap_BUS = new NhaCungCap_BUS();
        public ListDistributor_Form()
        {
            InitializeComponent();
            dgv_nhaCungCap.CellClick += Dgv_nhaCungCap_CellClick;
        }

        private void ListDistributor_Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            var data = nhaCungCap_BUS.loadAllNhaCungCap();
            if (data != null)
            {
                dgv_nhaCungCap.DataSource = data;
            }
            else
            {
                MessageBox.Show("No data returned from the data source.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            NewDistributor_Form newDistributor = new NewDistributor_Form();
            newDistributor.DataUpdated += NewDistributor_DataUpdated;
            newDistributor.ShowDialog();
        }

        private void NewDistributor_DataUpdated()
        {
            loadData();
        }

        private void Dgv_nhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection selected = dgv_nhaCungCap.CurrentRow.Cells;
            int maNCC = int.Parse(selected["MaNCC"].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                NewDistributor_Form newForm = new NewDistributor_Form(maNCC);
                newForm.DataUpdated += NewDistributor_DataUpdated;
                newForm.ShowDialog();
            }
            else if (e.ColumnIndex == 1)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        nhaCungCap_BUS.DeletetNhaCungCap(maNCC);
                        MessageBox.Show("Sản phẩm đã được xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string maNB = txtSearch.Text.Trim();

            List<NhaCC> searchResults = nhaCungCap_BUS.searchNhaCC(maNB);
            dgv_nhaCungCap.DataSource = searchResults;
        }
    }

}
