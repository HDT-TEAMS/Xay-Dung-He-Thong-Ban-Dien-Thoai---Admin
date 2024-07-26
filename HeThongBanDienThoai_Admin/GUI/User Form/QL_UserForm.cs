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
using DTO;

namespace HeThongBanDienThoai_Admin.GUI.User_Form
{
    public partial class QL_UserForm : Form
    {
        NguoiDung_BUS ndBUS = new NguoiDung_BUS();
        public QL_UserForm()
        {
            InitializeComponent();
            this.Load += QL_UserForm_Load;
        }

        private void QL_UserForm_Load(object sender, EventArgs e)
        {
            LoadND();
        }
        public void LoadND()
        {
            dataGridViewUser.DataSource = ndBUS.LoadND();
        }
    }
}
