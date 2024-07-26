using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Product
{
    public partial class ListProduct_Form : Form
    {
        SanPham_BUS spb = new SanPham_BUS();
        public ListProduct_Form()
        {
            InitializeComponent();
        }

        private void ListProduct_Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            dgviewm_listSanPham.DataSource = spb.getListSanPhamDetail();
        }

    }
}
