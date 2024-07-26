using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace HeThongBanDienThoai_Admin.GUI.Customer_Form
{
    public partial class QL_CustomerForm : Form
    {
        KhachHang_BUS khBUS = new KhachHang_BUS();
        public QL_CustomerForm()
        {
            InitializeComponent();
            this.Load += QL_CustomerForm_Load;
        }

        private void QL_CustomerForm_Load(object sender, EventArgs e)
        {
            LoadKH();
        }
        public void LoadKH()
        {
            dataGridViewCustomer.DataSource = khBUS.LoadKH();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadKH();
        }
    }
}
