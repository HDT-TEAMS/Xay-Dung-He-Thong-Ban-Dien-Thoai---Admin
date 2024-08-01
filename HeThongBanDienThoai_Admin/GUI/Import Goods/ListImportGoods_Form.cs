using BUS;
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
    public partial class ListImportGoods_Form : Form
    {
        private PhieuNhap_BUS nhb = new PhieuNhap_BUS();
        public ListImportGoods_Form()
        {
            InitializeComponent();
        }

        private void ListImportGoods_Form_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            dgv_listPhieuNhap.DataSource = nhb.loadAllPhieuNhap();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

            MyLib.LoadForm(this, new NewImportGood_Form());
        }

        private void dgv_listPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection selected = dgv_listPhieuNhap.CurrentRow.Cells;
            if (e.ColumnIndex == 0)
            {
                int maPN = int.Parse(selected["MaPN"].FormattedValue.ToString());
                
                MyLib.LoadForm(this, new NewImportGood_Form(maPN));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string txtSerach = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(txtSerach))
            {
           
                loadData();
            }
            else
            {
                dgv_listPhieuNhap.DataSource = nhb.searchPN(txtSerach);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
