using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using MyControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Promotion_Form
{
    public partial class EditPromotionForm : Form
    {
        private System.Windows.Forms.Timer timer_checkPromotionS;
        private KhuyenMai_BUS kmBUS = new KhuyenMai_BUS();
        private SanPham_BUS spBUS = new SanPham_BUS();
        private Dictionary<int, bool> _checkedStates = new Dictionary<int, bool>();
        private BindingList<View_SanPhamDetailsByLoai> _productList = new BindingList<View_SanPhamDetailsByLoai>();
        private int _MaKM;

        public EditPromotionForm()
        {
            InitializeComponent();
            btnLuu.Click += BtnLuu_Click;
            timer_checkPromotionS = new Timer();
            timer_checkPromotionS.Interval = 1000;
            timer_checkPromotionS.Tick += Timer_checkPromotionS_Tick;
            timer_checkPromotionS.Start();
            Label_Headings.Text = " Tạo mới một chương trình khuyến mãi ";
        }



        public EditPromotionForm(int MaKM)
        {
            InitializeComponent();
            ConfigureDateTimePickers();
            this._MaKM = MaKM;
            enableControls();
            loadData(_MaKM);
            this.btnLuu.Click += BtnLuu_Click1;
            this.btnLamMoi.Click += BtnLamMoi_Click1;
        }


        private void ConfigureDateTimePickers()
        {
            date_NgayBD.Format = DateTimePickerFormat.Custom;
            date_NgayBD.CustomFormat = "dd/MM/yyyy HH:mm";
            date_NgayBD.ShowUpDown = true;

            date_KetThuc.Format = DateTimePickerFormat.Custom;
            date_KetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
            date_KetThuc.ShowUpDown = true;
        }

        public void loadData(int MaKM)
        {
            KhuyenMai km = kmBUS.GetKhuyenMaiById(MaKM);
            if (km != null)
            {
                txtMaKM.Text = km.MaNB.ToString();
                txtTenKM.Text = km.TenKM.ToString();
                txtTrangThai.Text = (bool)km.IsDeleted ? "Kết thúc" : "Đang hoạt động";
                txtGiamGia.Text = km.GiamGia.ToString();
                date_NgayBD.Value = km.NgayBD.Value;
                date_KetThuc.Value = km.NgayKT.Value;
                Label_Headings.Text = "Chương trình: " + km.TenKM.ToString();
                dgviewm_listSanPham.DataSource = spBUS.getAllSanPham().Where(sp => sp.MaKM == MaKM).ToList();
            }
        }

        public void enableControls()
        {
            txtMaKM.Enabled = false;
            txtTenKM.Enabled = false;
            txtTrangThai.Enabled = false;
            txtGiamGia.Enabled = false;
            date_NgayBD.Enabled = false;
            date_KetThuc.Enabled = false;
        }

        public void SetSelectedProducts(List<View_SanPhamDetailsByLoai> selectedProducts)
        {
            var selectedProductIds = selectedProducts.Select(p => p.MaSP).ToHashSet();
            foreach (var product in selectedProducts)
            {
                var existingProduct = _productList.FirstOrDefault(p => p.MaSP == product.MaSP);
                if (existingProduct == null)
                {
                    var newProduct = new View_SanPhamDetailsByLoai
                    {
                        MaSP = product.MaSP,
                        MaNB = product.MaNB,
                        TenSP = product.TenSP,
                        TenDungLuong = product.TenDungLuong,
                        TenMau = product.TenMau,
                        MaKM = product.MaKM
                    };
                    _productList.Add(newProduct);
                }
                _checkedStates[product.MaSP] = true;
            }
            dgviewm_listSanPham.DataSource = _productList;
            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                var item = row.DataBoundItem as View_SanPhamDetailsByLoai;
                if (item != null)
                {
                    bool isChecked;
                    _checkedStates.TryGetValue(item.MaSP, out isChecked);
                    row.Cells["checkSP"].Value = isChecked;
                }
            }
        }

        private void dgviewm_listSanPham_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["checkSP"].Value = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddProductPromotionForm addp = new AddProductPromotionForm();
            addp.OnProductsSelected += (selectedProducts) =>
            {
                SetSelectedProducts(selectedProducts);
            };
            addp.ShowDialog();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text) ||
                string.IsNullOrWhiteSpace(txtTenKM.Text) ||
                string.IsNullOrWhiteSpace(txtGiamGia.Text) ||
                !DateTime.TryParse(date_NgayBD.Text, out DateTime ngayBD) ||
                !DateTime.TryParse(date_KetThuc.Text, out DateTime ngayKT))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngayBD > ngayKT)
            {
                MessageBox.Show("Ngày kết thúc phải lớn ngày bắt đầu .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ngayBD < DateTime.Now)
            {
                MessageBox.Show("Ngày đầu phải lớn hơn ngày hiện tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhuyenMai km = new KhuyenMai
            {
                MaNB = txtMaKM.Text,
                TenKM = txtTenKM.Text,
                GiamGia = float.Parse(txtGiamGia.Text),
                NgayBD = ngayBD,
                NgayKT = ngayKT,
                IsDeleted = false
            };

            kmBUS.AddKhuyenMai(km);

            foreach (var product in _productList)
            {
                var sanPham = new SanPham
                {
                    MaSP = product.MaSP,
                    MaKM = km.MaKM
                };
                spBUS.UpdateKhuyenMaiSanPham(sanPham);
            }
            MessageBox.Show("Cập nhật khuyến mãi thành công rồi nha !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MyLib.LoadForm(this, new QL_PromotionForm());
        }

        public void UpdatePromotionStatus()
        {
            try
            {
                var khuyenMais = kmBUS.LoadKM().ToList();
                var sanPhams = spBUS.getAllSanPham().ToList(); // Lấy tất cả sản phẩm từ DB

                // 1. Cập nhật MaKM cho sản phẩm khi ngày bắt đầu khuyến mãi đến
                var activePromotions = khuyenMais.Where(km => km.NgayBD <= DateTime.Now && km.NgayKT > DateTime.Now).ToList();
                foreach (var km in activePromotions)
                {
                    var productsToUpdate = sanPhams.Where(sp => sp.MaKM == null).ToList();
                    foreach (var sp in productsToUpdate)
                    {
                        sp.MaKM = km.MaKM;

                        var sanPhamToUpdate = new SanPham
                        {
                            MaSP = sp.MaSP,
                            MaKM = sp.MaKM,
                        };

                        try
                        {
                            spBUS.UpdateKhuyenMaiSanPham(sanPhamToUpdate);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi cập nhật khuyến mãi cho sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // 2. Cập nhật trạng thái IsDeleted và xóa MaKM của sản phẩm khi khuyến mãi hết hạn
                var expiredPromotions = khuyenMais.Where(km => km.NgayKT < DateTime.Now && !(km.IsDeleted ?? false)).ToList();
                foreach (var km in expiredPromotions)
                {
                    km.IsDeleted = true;
                    try
                    {
                        kmBUS.UpdateKhuyenMai(km);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật khuyến mãi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Xóa MaKM của các sản phẩm liên quan
                    var productsToClear = sanPhams.Where(sp => sp.MaKM == km.MaKM).ToList();
                    foreach (var sp in productsToClear)
                    {
                        sp.MaKM = null;
                        var sanPhamToClear = new SanPham
                        {
                            MaSP = sp.MaSP,
                            MaKM = sp.MaKM
                        };

                        try
                        {
                            spBUS.UpdateKhuyenMaiSanPham(sanPhamToClear);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa khuyến mãi sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái khuyến mãi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Timer_checkPromotionS_Tick(object sender, EventArgs e)
        {
            UpdatePromotionStatus();
        }

        private void BtnLuu_Click1(object sender, EventArgs e)
        {
            if (_MaKM <= 0 || _productList.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm và xác nhận mã khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProductIds = _productList.Select(p => p.MaSP).ToList();
            var allProducts = spBUS.getAllSanPham().ToList();

            try
            {
                // Xóa mã khuyến mãi cho các sản phẩm đã chọn mà khuyến mãi đã hết hạn
                foreach (var productId in selectedProductIds)
                {
                    var existingProduct = allProducts.SingleOrDefault(sp => sp.MaSP == productId);
                    if (existingProduct != null)
                    {
                        var existingPromotion = kmBUS.LoadKM().SingleOrDefault(km => km.MaKM == existingProduct.MaKM);
                        if (existingPromotion != null && existingPromotion.NgayKT < DateTime.Now)
                        {
                            // Chuyển đổi từ View_SanPhamDetailsByLoai thành SanPham
                            var sanPhamToUpdate = new SanPham
                            {
                                MaSP = existingProduct.MaSP,
                                MaKM = null // Xóa mã khuyến mãi
                            };

                            try
                            {
                                spBUS.UpdateKhuyenMaiSanPham(sanPhamToUpdate); // Cập nhật sản phẩm
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xóa khuyến mãi cho sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                // Cập nhật mã khuyến mãi cho các sản phẩm được chọn
                foreach (var product in _productList)
                {
                    var sanPhamToUpdate = new SanPham
                    {
                        MaSP = product.MaSP,
                        MaKM = _MaKM
                    };

                    try
                    {
                        spBUS.UpdateKhuyenMaiSanPham(sanPhamToUpdate); // Cập nhật sản phẩm
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật khuyến mãi cho sản phẩm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Cập nhật khuyến mãi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyLib.LoadForm(this, new QL_PromotionForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu khuyến mãi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click1(object sender, EventArgs e)
        {
            loadData(_MaKM);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this,new QL_PromotionForm());
        }
    }
}