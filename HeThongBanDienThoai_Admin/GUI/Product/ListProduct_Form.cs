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
        Loai loai;
        
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
                MyLib.LoadForm(this, new NewProduct_Form(maSp));
            }

        }

        private void ListProduct_Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dgviewm_listSanPham.DataSource = spb.getListSanPhamDetail(loai.Maloai);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new NewProduct_Form(loai));
            
        }


    }
}
