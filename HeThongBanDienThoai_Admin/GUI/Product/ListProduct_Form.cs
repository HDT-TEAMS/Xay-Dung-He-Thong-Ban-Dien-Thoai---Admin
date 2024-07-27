using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Product
{
    public partial class ListProduct_Form : Form
    {
        SanPham_BUS spb = new SanPham_BUS();
        Loai loai ;
        
        public ListProduct_Form(Loai loai)
        {
            InitializeComponent();
            this.loai = loai;
            this.dgviewm_listSanPham.CellClick += Dgviewm_listSanPham_CellClick;
        }

        private void Dgviewm_listSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection selected = dgviewm_listSanPham.CurrentRow.Cells;
            int maSp = int.Parse(selected["MaSP"].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                MyLib.LoadForm(this, new NewProduct_Form(loai,maSp));
            }
            else if (e.ColumnIndex == 1)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                             "Xác nhận xóa",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        spb.DeleteSanPham(maSp);
                        MessageBox.Show("Sản phẩm đã được xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void ListProduct_Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
           if (loai != null)
            {
                dgviewm_listSanPham.DataSource = spb.getListSanPhamDetail(loai.Maloai);
            } 
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new NewProduct_Form(loai));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String searchTerm = txtSearch.Text.Trim();
            if (loai != null)
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    loadData();
                }
                else
                {
                    dgviewm_listSanPham.DataSource = spb.SearchSanPham(loai.Maloai,searchTerm);
                }
            }
        }
    }
}
