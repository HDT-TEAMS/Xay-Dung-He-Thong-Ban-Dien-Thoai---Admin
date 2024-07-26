using BUS;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Staff_Form
{
    public partial class QL_StaffForm : Form
    {
        NhanVien_BUS nvBUS = new NhanVien_BUS();
        public QL_StaffForm()
        {
            InitializeComponent();
            this.Load += QL_StaffForm_Load;
        }

        private void QL_StaffForm_Load(object sender, EventArgs e)
        {
            LoadNV();
        }

        public void LoadNV()
        {
            dataGridViewStaff.DataSource = nvBUS.LoadNV();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadNV();
        }
    }
}
