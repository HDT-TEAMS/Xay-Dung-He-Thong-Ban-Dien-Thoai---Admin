using BUS;
using DTO;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using HeThongBanDienThoai_Admin.GUI.Product;
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

namespace HeThongBanDienThoai_Admin.GUI
{
    public partial class Menu_Form : Form
    {
        private int _maND;
        private Loai_BUS lb = new Loai_BUS();
        public Menu_Form(int maND)
        {
            InitializeComponent();
            _maND = maND;
        }

        private void Menu_Form_Load(object sender, EventArgs e)
        {
            showChucNang();
        }

        private Guna2Button CreateButtonLoaiSP(Loai loai)
        {
            Guna2Button btn = new Guna2Button();
            CustomizableEdges edge1 = new CustomizableEdges();
            CustomizableEdges edge2 = new CustomizableEdges();

            btn.Cursor = Cursors.Hand;
            btn.Animated = true;
            btn.AnimatedGIF = true;
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn.CheckedState.FillColor = Color.RoyalBlue;
            btn.CheckedState.ForeColor = Color.White;
            btn.CustomizableEdges = edge1;
            btn.DisabledState.BorderColor = Color.Transparent;
            btn.DisabledState.CustomBorderColor = Color.Transparent;
            btn.DisabledState.FillColor = Color.Transparent;
            btn.DisabledState.ForeColor = Color.Transparent;
            btn.FillColor = Color.Transparent;
            btn.Font = new Font("Bahnschrift Light Condensed", 12,FontStyle.Regular);
            btn.ForeColor = Color.Black;
            btn.HoverState.FillColor = Color.Transparent;
            btn.ImageAlign = HorizontalAlignment.Left;
            btn.ImageSize = new Size(10, 10);
            btn.Location = new Point(0, 40);
            btn.Margin = new Padding(0);
            btn.Name = "btn_LoaiSanPham";
            btn.Padding = new Padding(26, 0, 0, 0);
            btn.PressedColor = Color.RoyalBlue;
            btn.PressedDepth = 100;
            btn.ShadowDecoration.CustomizableEdges = edge2;
            btn.Size = new Size(248, 40);
            btn.TabIndex = 15;
            btn.Tag = "loaisp" + "|" + loai.TenLoai + "|" + loai.Maloai;
            btn.Text = loai.TenLoai;
            btn.BorderRadius = 8;
            btn.TextAlign = HorizontalAlignment.Left;
            btn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            btn.HoverState.FillColor = Color.WhiteSmoke;

            return btn;
        }

        public void LoadAllLoaiSP()
        {
            if (!MyLib.CheckPermission(_maND, "sanpham.view"))
            {
                panel_sidebar.Controls.Remove(Panel_MasterSanPham);
                return;
            }
            try
            {
                var loaiSPList = lb.LoadAllLoai();
                Guna2Button btnMasterSP = (Guna2Button)this.Controls.Find("btn_MasterSanPham", true)[0];
                MyLib.RemoveChildFrom(Panel_MasterSanPham, 1);
                MyLib.Collapse(true, Panel_MasterSanPham);

                foreach (Loai loai in loaiSPList)
                {
                    Guna2Button btn = CreateButtonLoaiSP(loai);
                    MyLib.AddControl(Panel_MasterSanPham,btn,DockStyle.Top);
                    int panelHeight = Panel_MasterSanPham.Height + 40;
                    Panel_MasterSanPham.MaximumSize  = new Size(248,panelHeight);
                    Panel_MasterSanPham.Height = panelHeight;
                }
                btnMasterSP.SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void showChucNang()
        {
            var panelMasterCauHinh = Panel_MasterCauHinh.Controls;
            var panelMasterSanPham = Panel_MasterSanPham.Controls;
            var panelMasterBanHang = Panel_MasterBanHang.Controls;
            var panelMasterNhapHang = Panel_MasterNhapHang.Controls;
            var panelMasterHeThong = Panel_MasterHeThong.Controls;

            for (int i = 0; i < panelMasterCauHinh.Count; i++)
            {
                Guna2Button btn = (Guna2Button)panelMasterCauHinh[i];

                if (!MyLib.CheckControlPermission(btn, _maND))
                {
                    Panel_MasterCauHinh.Height -= btn.Height;
                    Panel_MasterCauHinh.MaximumSize = new Size(0, Panel_MasterCauHinh.Height);
                    Panel_MasterCauHinh.Controls.Remove(btn);
                    i = -1;
                }
            }

            for (int i = 0; i < panelMasterSanPham.Count; i++)
            {
                Guna2Button btn = (Guna2Button)panelMasterSanPham[i];

                if (!MyLib.CheckControlPermission(btn, _maND))
                {
                    Panel_MasterSanPham.Height -= btn.Height;
                    Panel_MasterSanPham.MaximumSize = new Size(0, Panel_MasterSanPham.Height);
                    Panel_MasterSanPham.Controls.Remove(btn);
                    i = -1;
                }

            }

            for (int i = 0; i < panelMasterBanHang.Count; i++)
            {
                Guna2Button btn = (Guna2Button)panelMasterBanHang[i];

                if (!MyLib.CheckControlPermission(btn, _maND))
                {
                    Panel_MasterBanHang.Height -= btn.Height;
                    Panel_MasterBanHang.MaximumSize = new Size(0, Panel_MasterBanHang.Height);
                    Panel_MasterBanHang.Controls.Remove(btn);
                    i = -1;
                }
            }

            for (int i = 0; i < panelMasterNhapHang.Count; i++)
            {
                Guna2Button btn = (Guna2Button)panelMasterNhapHang[i];

                if (!MyLib.CheckControlPermission(btn, _maND))
                {
                    Panel_MasterNhapHang.Height -= btn.Height;
                    Panel_MasterNhapHang.MaximumSize = new Size(0, Panel_MasterNhapHang.Height);
                    Panel_MasterNhapHang.Controls.Remove(btn);
                    i = -1;
                }
            }


            for (int i = 0; i < panelMasterHeThong.Count; i++)
            {
                Guna2Button btn = (Guna2Button)panelMasterHeThong[i];

                if (!MyLib.CheckControlPermission(btn, _maND))
                {
                    Panel_MasterHeThong.Height -= btn.Height;
                    Panel_MasterHeThong.MaximumSize = new Size(0, Panel_MasterHeThong.Height);
                    Panel_MasterHeThong.Controls.Remove(btn);
                    i = -1;
                }
            }

            if (panelMasterCauHinh.Count == 0)
            {
                panel_sidebar.Controls.Remove(Panel_MasterCauHinh);
            }
            if (panelMasterSanPham.Count == 0)
            {
                panel_sidebar.Controls.Remove(Panel_MasterSanPham);
            }
            if (panelMasterBanHang.Count == 0)
            {
                panel_sidebar.Controls.Remove(Panel_MasterBanHang);
            }
            if (panelMasterNhapHang.Count == 0)
            {
                panel_sidebar.Controls.Remove(Panel_MasterNhapHang);
            }
            if (panelMasterHeThong.Count == 0)
            {
                panel_sidebar.Controls.Remove(Panel_MasterHeThong);
            }
        }

        private void btn_MasterCauHinh_Click(object sender, EventArgs e)
        {
            MyLib.Collapse(!btn_MasterCauHinh.Checked, Panel_MasterCauHinh);
        }

        private void btn_MasterSanPham_Click(object sender, EventArgs e)
        {
            MyLib.Collapse(!btn_MasterSanPham.Checked, Panel_MasterSanPham);
        }

        private void btnMasterNhapHang_Click(object sender, EventArgs e)
        {
            MyLib.Collapse(!btnMasterNhapHang.Checked, Panel_MasterNhapHang);
        }

        private void btn_MasterBanHang_Click(object sender, EventArgs e)
        {
            MyLib.Collapse(!btn_MasterBanHang.Checked, Panel_MasterBanHang);
        }

        private void btn_MasterHeThong_Click(object sender, EventArgs e)
        {
            MyLib.Collapse(!btn_MasterHeThong.Checked, Panel_MasterHeThong);
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            ListProduct_Form listProduct = new ListProduct_Form();
            MyLib.LoadForm(panel_container, listProduct, DockStyle.Fill);
        }
    }
}
