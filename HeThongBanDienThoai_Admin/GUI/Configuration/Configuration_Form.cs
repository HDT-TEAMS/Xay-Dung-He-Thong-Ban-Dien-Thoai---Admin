using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using HeThongBanDienThoai_Admin.GUI.Import_Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;

namespace HeThongBanDienThoai_Admin.GUI.Configuration
{
    public partial class Configuration_Form : Form
    {
        DungLuong_BUS dBus = new DungLuong_BUS();
        MauSac_BUS mauSac_BUS = new MauSac_BUS();
        Loai_BUS loaiSP_BUS = new Loai_BUS();

        public Configuration_Form()
        {
            InitializeComponent();
            this.Load += Configuration_Form_Load;
            dgv_MauSac.CellClick += Dgv_MauSac_CellClick;
            dgv_LoaiSP.CellClick += Dgv_LoaiSP_CellClick;
        }

        private void Dgv_LoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int loaisp = Convert.ToInt32(dgv_LoaiSP.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString());
            if (e.ColumnIndex == dgv_MauSac.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                AddLoai_Form addloai = new AddLoai_Form(loaisp);
                addloai.Show();
            }
            
        }

        private void Dgv_MauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int color = Convert.ToInt32(dgv_MauSac.Rows[e.RowIndex].Cells["MaMau"].Value.ToString());
            if (e.ColumnIndex == dgv_MauSac.Columns["btnSua"].Index && e.RowIndex >= 0)
            {
                EditStaffForm editStaffForm = new EditStaffForm(color);
                editStaffForm.Show();
            }
        }

        private void Configuration_Form_Load(object sender, EventArgs e)
        {
            loadAllConfiguration();
        }

        public void loadAllConfiguration()
        {
            dgv_DungLuong.DataSource = dBus.loadAllDungLuong();
            dgv_MauSac.DataSource = mauSac_BUS.loadAllMauSac();
            dgv_LoaiSP.DataSource = loaiSP_BUS.LoadAllLoai();
        }

        private void btn_LamMoi_DL_Click(object sender, EventArgs e)
        {
            loadAllConfiguration();
        }

        private void btn_LamMoi_MauSac_Click(object sender, EventArgs e)
        {
            loadAllConfiguration();
        }

        private void btn_LamMoi_LSP_Click(object sender, EventArgs e)
        {
            loadAllConfiguration();
        }

        private void btn_ThemMoi_MauSac_Click(object sender, EventArgs e)
        {
            AddColor_Form newColor = new AddColor_Form();
            newColor.DataUpdated += NewColor_DataUpdated;
            newColor.ShowDialog();
        }

        private void NewColor_DataUpdated()
        {
            loadAllConfiguration();
        }

        private void btnThemMoi_LSP_Click(object sender, EventArgs e)
        {
            AddLoai_Form newLoai = new AddLoai_Form();
            newLoai.ShowDialog();
        }

      

        
    }
}
