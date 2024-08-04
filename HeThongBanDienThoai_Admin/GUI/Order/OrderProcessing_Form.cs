using BUS;
using DTO;
using Guna.UI2.WinForms;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Order
{
    public partial class OrderProcessing_Form : Form
    {
        private int _maDH;
        private DonHang_BUS dhb = new DonHang_BUS();
        private SanPham_BUS spb = new SanPham_BUS();
        private ChiTietDonHang_BUS ctdhb = new ChiTietDonHang_BUS();
        private NhanVien_BUS nvb = new NhanVien_BUS();
        private KhuyenMai_BUS kmb = new KhuyenMai_BUS();
        public OrderProcessing_Form()
        {
            InitializeComponent();
        }

        public OrderProcessing_Form(int maDH)
        {
            InitializeComponent();
            this._maDH = maDH;
            LoadDataAsync();
            this.btnXacNhan.Click += BtnXacNhan_Click;
            this.btnHuy.Click += BtnHuy_Click;
            this.btnGiaoHang.Click += BtnGiaoHang_Click;
            this.btnHoanTat.Click += BtnHoanTat_Click;
        }


        private async void LoadDataAsync()
        {
            await LoadData(_maDH);
            await LoadDataGVCTDH(_maDH);
            EnableControls();
        }

        private async Task LoadData(int madh)
        {
            var danhSachDonHang = await Task.Run(() => dhb.getDanhSachDonHang());
            var donHang = danhSachDonHang.FirstOrDefault(dh => dh.MaDH == madh);

            if (donHang != null)
            {
                txtMaDH.Text = donHang.MaNB.ToString();
                txtTenKH.Text = donHang.TenKH;
                txtNhanVien.Text = donHang.TenNV;
                dateTime_NDH.Text = donHang.NgayDat.ToString();
                txtTongTien.Text = MyLib.AddCommas(donHang.TongTien);
                txtTrangThai.Text = donHang.TrangThai;
            }

            Label_Headings.Text = "Thông tin đơn hàng : " + donHang.MaNB + " - Trạng thái: " + txtTrangThai.Text;
        }

        private async Task LoadDataGVCTDH(int maDH)
        {
            var chiTietDonHangList = await Task.Run(() => ctdhb.loadCTDHByMaDH(maDH));

            // Cập nhật dữ liệu cho DataGridView
            dgv_CTDH.DataSource = chiTietDonHangList;

            // Đánh dấu tất cả sản phẩm
            foreach (DataGridViewRow row in dgv_CTDH.Rows)
            {
                row.Cells["checkSP"].Value = true;
            }

            foreach (DataGridViewRow row in dgv_CTDH.Rows)
            {
                int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal giaSP = Convert.ToDecimal(row.Cells["DonGia"].Value); 
                decimal tongTien = 0;

                var sanPham = spb.getSanPhamByMaSPs(maSP);
                if (sanPham != null)
                {
                    var khuyenMai = kmb.LoadKM().FirstOrDefault(km => km.MaKM == sanPham.MaKM);
                    decimal soTienKhuyenMai = 0;

                    if (khuyenMai != null)
                    {
                        soTienKhuyenMai = giaSP * ((decimal)khuyenMai.GiamGia / 100);
                    }
                    tongTien = soLuong * (giaSP - soTienKhuyenMai);

                    row.Cells["GiaKhuyenMai"].Value = soTienKhuyenMai;
                    row.Cells["TongTien"].Value = tongTien;
                }
            }
        }

        private void EnableControls()
        {
            switch (txtTrangThai.Text)
            {
                case "Chờ xác nhận":
                    SetButtonVisibility( false, true, false, true);
                    break;
                case "Đã xác nhận":
                    SetButtonVisibility( false, false, true, true);
                    break;
                case "Đang giao hàng":
                    SetButtonVisibility( true, false, false, true);
                    break;
                case "Đã hủy":
                    SetButtonVisibility( false, false, false, false);
                    break;
                default:
                    SetButtonVisibility(false, false, false, false);
                    break;
            }
            EnableTextBoxes(false);
        }

        private void SetButtonVisibility( bool hoanTat, bool xacNhan, bool giaoHang, bool huy)
        {
            btnHoanTat.Visible = hoanTat;
            btnXacNhan.Visible = xacNhan;
            btnGiaoHang.Visible = giaoHang;
            btnHuy.Visible = huy;
        }

        private void EnableTextBoxes(bool enable)
        {
            txtMaDH.Enabled = enable;
            txtTenKH.Enabled = enable;
            txtNhanVien.Enabled = enable;
            dateTime_NDH.Enabled = enable;
            txtTongTien.Enabled = enable;
            txtTrangThai.Enabled = enable;
        }

        private async Task<bool> checkAndUpdateQuantity(int maDH)
        {
            var ctdhs = await Task.Run(() => ctdhb.loadCTDHByMaDH(maDH));
            bool isQuantityValid = true;

            foreach (var item in ctdhs)
            {
                var sanPham = await Task.Run(() => spb.getSanPhamByMaSPs(item.MaSP ?? 0));
                if (sanPham.SoLuong < item.SoLuong)
                {
                    isQuantityValid = false;
                    break;
                }
            }

            if (isQuantityValid)
            {
                foreach (var item in ctdhs)
                {
                    SanPham sp = new SanPham()
                    {
                        MaSP = item.MaSP ?? 0,
                        SoLuong = item.SoLuong,
                    };
                    spb.UpdateSoLuongSanPham(sp, false);
                }
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm trong kho không đủ!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isQuantityValid;
        }

        private async void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xác nhận đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string trangthai = "Đã xác nhận";
                bool isCheck = await checkAndUpdateQuantity(_maDH);
                int maNV = nvb.GetMaNVById(MyLib.maND);

                if (isCheck)
                {
                    DonHang dh = new DonHang()
                    {
                        MaDH = _maDH,
                        MaNV = maNV,
                        TrangThai = trangthai.Trim()
                    };
                    dhb.UpdateTrangThaiDonHang(dh);
                    MessageBox.Show("Cập nhật đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyLib.LoadForm(this, new OrderCreate_Form());
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string trangthai = "Đã hủy";
                var donhang = await Task.Run(() => dhb.getDonHangByMaĐH(_maDH));
                var chiTietDHList = await Task.Run(() => ctdhb.loadCTDHByMaDH(_maDH));
                int maNV = nvb.GetMaNVById(MyLib.maND);

                if (donhang.TrangThai == "Đã xác nhận" || donhang.TrangThai == "Đang giao hàng")
                {
                    foreach (var ctdh in chiTietDHList)
                    {
                        SanPham sp = new SanPham()
                        {
                            MaSP = ctdh.MaSP ?? 0, 
                            SoLuong = ctdh.SoLuong,
                        };
                        spb.UpdateSoLuongSanPham(sp, true);
                    }
                }

                DonHang dh = new DonHang()
                {
                    MaDH = _maDH,
                    MaNV = maNV,
                    TrangThai = trangthai.Trim()
                };
                dhb.UpdateTrangThaiDonHang(dh);

                MessageBox.Show("Đơn hàng đã được hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyLib.LoadForm(this, new OrderCreate_Form());
            }
        }

        private async void BtnGiaoHang_Click(object sender, EventArgs e)
        {
            int maNV = nvb.GetMaNVById(MyLib.maND);
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string trangthai = "Đang giao hàng";
                var donhang =  await Task.Run(() => dhb.getDonHangByMaĐH(_maDH));
                if (donhang != null)
                {
                    DonHang dh = new DonHang()
                    {
                       MaDH = _maDH,
                       MaNV = maNV,
                       TrangThai = trangthai.Trim()
                    };
                    dhb.UpdateTrangThaiDonHang(dh);
                }
                MessageBox.Show("Đơn hàng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyLib.LoadForm(this, new OrderCreate_Form());
            }
        }

        private async void BtnHoanTat_Click(object sender, EventArgs e)
        {
            int maNV = nvb.GetMaNVById(MyLib.maND);
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string trangthai = "Đã hoàn thành";
                var donhang = await Task.Run(() => dhb.getDonHangByMaĐH(_maDH));
                if (donhang != null)
                {
                    DonHang dh = new DonHang()
                    {
                        MaDH = _maDH,
                        MaNV = maNV,
                        TrangThai = trangthai.Trim()
                    };
                    dhb.UpdateTrangThaiDonHang(dh);
                }
                MessageBox.Show("Đơn hàng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyLib.LoadForm(this, new OrderCreate_Form());
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new OrderCreate_Form());
        }
    }
}
