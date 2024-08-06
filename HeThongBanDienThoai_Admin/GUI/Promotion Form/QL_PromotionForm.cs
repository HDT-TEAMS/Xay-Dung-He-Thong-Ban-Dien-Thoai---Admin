using BUS;
using DTO;
using HeThongBanDienThoai_Admin.GUI.Customer_Form;
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

namespace HeThongBanDienThoai_Admin.GUI.Promotion_Form
{
    public partial class QL_PromotionForm : Form
    {
        private KhuyenMai_BUS kmBUS = new KhuyenMai_BUS();
        public QL_PromotionForm()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            var khuyenMaiList = kmBUS.LoadKM(); 
            var khuyenMaiUpdate = khuyenMaiList.Select(km => new
            {
                km.MaNB,
                km.TenKM,
                km.NgayBD,
                km.NgayKT,
                km.GiamGia,
                TrangThai =(bool) !km.IsDeleted ? "Đang hoạt động" : "Kết thúc",
                km.MaKM
            }).ToList();
            dgv_khuyenmai.DataSource = khuyenMaiUpdate;
        }


        private void QL_PromotionForm_Load(object sender, EventArgs e)
        {
            loadData();
            btnReload.Click += BtnReload_Click;
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            dgv_khuyenmai.DataSource = kmBUS.LoadKM();
        }

            private void dgv_khuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection selected = dgv_khuyenmai.CurrentRow.Cells;
            int maKM = int.Parse(selected["MaKM"].Value.ToString());
            if (e.ColumnIndex == 0) {
                MyLib.LoadForm(this, new EditPromotionForm(maKM));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new EditPromotionForm());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();


            var khuyenMaiList = kmBUS.LoadKM().ToList();

            var filteredList = khuyenMaiList
                .Where(km =>
                    km.TenKM.ToLower().Contains(searchText) ||
                    km.MaNB.ToString().Contains(searchText))
                .Select(km => new
                {
                    km.MaKM,
                    km.TenKM,
                    km.NgayBD,
                    km.NgayKT,
                    km.GiamGia,
                    TrangThai = (km.NgayKT < DateTime.Now && !(km.IsDeleted ?? false)) ? "Kết thúc" : "Đang hoạt động"
                }).ToList();

            dgv_khuyenmai.DataSource = filteredList;

            dgv_khuyenmai.Refresh();
        }

        private void btnReload_Click_1(object sender, EventArgs e)
        {
            dgv_khuyenmai.DataSource = kmBUS.LoadKM();
        }
    }
}
