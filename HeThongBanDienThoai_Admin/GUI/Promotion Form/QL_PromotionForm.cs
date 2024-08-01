using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Customer_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Promotion_Form
{
    public partial class QL_PromotionForm : Form
    {
        KhuyenMai_BUS kmBUS = new KhuyenMai_BUS();
        public QL_PromotionForm()
        {
            this.Load += QL_PromotionForm_Load;
            InitializeComponent();
            dataGridViewPromotion.CellContentClick += DataGridViewPromotion_CellContentClick;
        }

        private void DataGridViewPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QL_PromotionForm_Load(object sender, EventArgs e)
        {
            LoadKM();
        }
        public void LoadKM()
        {
            dataGridViewPromotion.DataSource = kmBUS.LoadKM();
        }

        

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            EditPromotionForm editPromoForm = new EditPromotionForm();
            editPromoForm.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadKM();
        }
    }
}
