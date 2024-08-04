using BUS;
using DTO;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using HeThongBanDienThoai_Admin.GUI.Customer_Form;
using HeThongBanDienThoai_Admin.GUI.Report;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HeThongBanDienThoai_Admin.GUI.Order
{
    public partial class OrderInStore_Form : Form
    {
        private SanPham_BUS spb = new SanPham_BUS();
        private Loai_BUS lb = new Loai_BUS();
        private DonHang_BUS dhb = new DonHang_BUS();
        private ChiTietDonHang_BUS ctdhb = new ChiTietDonHang_BUS();
        private KhachHang_BUS khb = new KhachHang_BUS();
        private KhuyenMai_BUS kmb = new KhuyenMai_BUS();
        private NhanVien_BUS nvb = new NhanVien_BUS();
        private List<SanPham> productList;
        private Des_Report_PrintOder reportObject;
        private int currentPage = 1;
        private int itemsPerPage = 10;

        public OrderInStore_Form()
        {
            InitializeComponent();
            this.dgviewm_listSanPham.CellValueChanged += Dgviewm_listSanPham_CellValueChanged;
            this.dgviewm_listSanPham.UserDeletedRow += Dgviewm_listSanPham_UserDeletedRow;
        }

        private void OrderInStore_Form_Load(object sender, EventArgs e)
        {
            GenerateRandomMaNB();
            loadCbbLoaiSanPham();
            loadDataSanPham();
            EnableTextBoxes();
        }

        private void loadCbbLoaiSanPham()
        {
            var loaiList = lb.LoadAllLoai();
            loaiList.Insert(0, new Loai { Maloai = -1, TenLoai = "Tất cả sản phẩm" });
            cbbLoai.DataSource = loaiList;
            cbbLoai.DisplayMember = "TenLoai";
            cbbLoai.ValueMember = "MaLoai";
        }

        private async Task GenerateRandomMaNB()
        {
            txtMaNB.Text = await MyLib.RandomHoaDon();
        }

        private void EnableTextBoxes()
        {
            txtMaNB.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtKhuyenMai.Enabled = false;
            txtTongTien.Enabled = false;
        }

        private void loadDataSanPham()
        {
            // Calculate total pages based on the number of filtered products and items per page
            int totalPages = (int)Math.Ceiling((double)productList.Count / itemsPerPage);

            // Fetch products for the current page
            var productsToShow = productList
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            // Clear existing controls and add new products
            panel_SanPham.Controls.Clear();
            FlowLayoutPanel flowLayoutPanel = CreateProductsFlowPanel(productsToShow);
            panel_SanPham.Controls.Add(flowLayoutPanel);

            // Clear existing pagination controls
            panel_layoutPage.Controls.Clear();

            // Create and add previous page button
            Guna2Button prevButton = new Guna2Button
            {
                Text = "<",
                BorderRadius = 5,
                FillColor = Color.LightGray,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(50, 40),
                Enabled = currentPage > 1,
                Margin = new Padding(5)
            };
            prevButton.Click += (s, e) =>
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    loadDataSanPham();
                }
            };
            panel_layoutPage.Controls.Add(prevButton);

            // Create and add page buttons
            for (int i = 1; i <= totalPages; i++)
            {
                Guna2Button pageButton = new Guna2Button
                {
                    Text = i.ToString(),
                    BorderRadius = 5,
                    FillColor = Color.LightGray,
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Size = new Size(50, 40),
                    Tag = i,
                    Margin = new Padding(5)
                };
                pageButton.Click += PageButton_Click;

                // Highlight the current page button
                if (i == currentPage)
                {
                    pageButton.FillColor = Color.CornflowerBlue;
                    pageButton.ForeColor = Color.White;
                }
                panel_layoutPage.Controls.Add(pageButton);
            }

            // Create and add next page button
            Guna2Button nextButton = new Guna2Button
            {
                Text = ">",
                BorderRadius = 5,
                FillColor = Color.LightGray,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(50, 40),
                Enabled = currentPage < totalPages,
                Margin = new Padding(5)
            };
            nextButton.Click += (s, e) =>
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    loadDataSanPham();
                }
            };
            panel_layoutPage.Controls.Add(nextButton);

            // Configure layout settings
            panel_layoutPage.FlowDirection = FlowDirection.LeftToRight;
            panel_layoutPage.WrapContents = false;
            panel_layoutPage.AutoSize = true;
            panel_layoutPage.Anchor = AnchorStyles.None;
        }


        private FlowLayoutPanel CreateProductsFlowPanel(IEnumerable<SanPham> products)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(40, 50, 30, 30),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0)
            };

            foreach (var product in products)
            {
                flowLayoutPanel.Controls.Add(CreateProductPanel(product));
            }

            panel_SanPham.Controls.Clear();
            panel_SanPham.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Dock = DockStyle.Fill;

            return flowLayoutPanel;
        }
        private void PageButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            if (clickedButton != null)
            {
                currentPage = (int)clickedButton.Tag;
                loadDataSanPham();
            }
        }
        private Panel CreateProductPanel(SanPham product)
        {
            Panel productPanel = new Panel
            {
                Size = new Size(150, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.Gray,
                Tag = product
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = product.HinhAnh.Split(',').FirstOrDefault(),
                Dock = DockStyle.Top
            };

            Label nameLabel = new Label
            {
                Text = product.TenSP,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                ForeColor = Color.White,
            };

            Label priceLabel = new Label
            {
                Text = $"{MyLib.AddCommas(product.GiaSP):C}",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                ForeColor = Color.White

            };

            productPanel.Controls.Add(priceLabel);
            productPanel.Controls.Add(nameLabel);
            productPanel.Controls.Add(pictureBox);

            pictureBox.Click += (s, e) =>
            {
                var selectedProduct = productPanel.Tag as SanPham;
                if (selectedProduct != null)
                {
                    var result = MessageBox.Show($"Bạn có muốn thêm sản phẩm {selectedProduct.TenSP} vào danh sách ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        insertProductToDTGV(selectedProduct);
                    }
                }
            };

            return productPanel;
        }

        private void insertProductToDTGV(SanPham product)
        {
            if (dgviewm_listSanPham == null)
            {
                MessageBox.Show("DataGridView is not initialized");
                return;
            }

            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells["MaSP"].Value) == product.MaSP)
                {
                    int currentQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    row.Cells["SoLuong"].Value = currentQuantity + 1;
                    calculateDiscount();
                    return;
                }
            }

            dgviewm_listSanPham.Rows.Add(product.MaNB, product.TenSP, product.GiaSP, null, 1, product.MaKM, product.MaSP);
            calculateDiscount();
        }


        private void calculateDiscount()
        {
            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (row.IsNewRow) continue;

                int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                int maKM = Convert.ToInt32(row.Cells["MaKM"].Value);
                int SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                var sanPham = spb.getSanPhamByMaSPs(maSP);
                var khuyenMai = kmb.LoadKM().FirstOrDefault(km => km.MaKM == sanPham.MaKM);

                decimal soTienKhuyenMai = 0;
                if (khuyenMai != null)
                {
                    soTienKhuyenMai = (decimal)SoLuong * (decimal)sanPham.GiaSP * ((decimal)khuyenMai.GiamGia / 100);
                }

                row.Cells["KhuyenMai"].Value = soTienKhuyenMai;

            }
            UpdateTotalPrice();
        }


        private void UpdateTotalPrice()
        {
            decimal totalAmount = 0;
            decimal totalDiscount = 0;
            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["SoLuong"].Value != null && row.Cells["GiaSP"].Value != null && row.Cells["KhuyenMai"].Value != null)
                {
                    int quantity = 0;
                    decimal price = 0;
                    decimal discount = 0;

                    if (int.TryParse(row.Cells["SoLuong"].Value.ToString(), out quantity) &&
                        decimal.TryParse(row.Cells["GiaSP"].Value.ToString(), out price) &&
                        decimal.TryParse(row.Cells["KhuyenMai"].Value.ToString(), out discount))
                    {
                        // Apply discount to price
                        decimal discountedPrice = quantity * price - discount;
                        totalAmount += discountedPrice;
                        totalDiscount += discount;
                    }
                    else
                    {
                        MessageBox.Show("Invalid data in DataGridView");
                    }
                }
            }
            txtTongTien.Text = MyLib.AddCommas(totalAmount);
            txtKhuyenMai.Text = " - " + MyLib.AddCommas(totalDiscount);

        }


        private void Dgviewm_listSanPham_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calculateDiscount();
        }

        private void Dgviewm_listSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                calculateDiscount();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text;
            if (string.IsNullOrEmpty(soDienThoai)) {
                MessageBox.Show("Vui lòng nhập số điện thoại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            KhachHang khachHang = khb.LoadKH().FirstOrDefault(kh => kh.SDT == soDienThoai);
            if (khachHang != null)
            {
                txtTenKhachHang.Text = khachHang.TenKH;
            } else
            {
                MessageBox.Show("Khách hàng này chưa có trong hệ thống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditCustomerForm editcus = new EditCustomerForm();
            editcus.ShowDialog();
        }

        private async void btnThanhToanInHD_Click(object sender, EventArgs e)
        {

            // Xử lý control
            string tenKH = txtTenKhachHang.Text;
            string SDT = txtSoDienThoai.Text;
            if (string.IsNullOrEmpty(SDT)) {
                MessageBox.Show("Vui lòng không được để trống SDT khách hàng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng không để trống tên khách hàng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (dgviewm_listSanPham == null || dgviewm_listSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mua sản phẩm trước khi thanh toán !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["SoLuong"].Value != null)
                {
                    int soLuong;
                    if (!int.TryParse(row.Cells["SoLuong"].Value.ToString(), out soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0 cho tất cả sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["SoLuong"].Selected = true;
                        return;
                    }

                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    string tenSP = row.Cells["TenSP"].Value.ToString();
                    int soLuongTrongKho = spb.getSoLuongByMaSP(maSP);
                    if (soLuongTrongKho < soLuong)
                    {
                        MessageBox.Show($"Số lượng sản phẩm {tenSP} yêu cầu ({soLuong}) vượt quá số lượng tồn kho ({soLuongTrongKho})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            KhachHang kh = khb.GetMaKHBySDT(SDT);
            int maKH = kh.MaKH;
            int maNV = nvb.GetMaNVById(MyLib.maND);
            string maNB = txtMaNB.Text;
            //Insert HD
            DonHang donHang = new DonHang
            {
                MaNB = maNB,
                MaKH = maKH,
                MaNV = maNV,
                TrangThai = "Đã hoàn thành",
                DiaChiNhan = "Tại cửa hàng !",
                HinhThucThanhToan = "Thanh toán trực tiếp",
                IsDeleted = true,
                NgayDat = DateTime.Now,
                TongTien = MyLib.ParseCurrencyString(txtTongTien.Text, "đ")
            };
            dhb.InsertDonHang(donHang);
            //Insert CTHD
            foreach (DataGridViewRow row in dgviewm_listSanPham.Rows)
            {
                if (row.IsNewRow) continue;

                int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal giaSP = Convert.ToInt32(row.Cells["GiaSP"].Value);
                var sanPham = spb.getSanPhamByMaSPs(maSP);
                var khuyenMai = kmb.LoadKM().FirstOrDefault(km => km.MaKM == sanPham.MaKM);
                decimal discountPercentage = (decimal)(khuyenMai?.GiamGia ?? 0);

                CTDonHang ctDonHang = new CTDonHang
                {
                    MaDH = donHang.MaDH,
                    MaSP = maSP,
                    SoLuong = soLuong,
                    DonGia = giaSP - (giaSP * discountPercentage / 100)

                };
                ctdhb.insertCTDonHang(ctDonHang);

                SanPham sp = new SanPham
                {
                    MaSP = ctDonHang.MaSP,
                    SoLuong = ctDonHang.SoLuong,

                };
                spb.UpdateSoLuongSanPham(sp, false);
            }

            MessageBox.Show("Thanh toán thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //In hóa đơn
            inPhieuDonHang(donHang.MaDH);

            await GenerateRandomMaNB();
            resetForm();
        }

        public void inPhieuDonHang(int MaDH)
        {
            try
            {
                List<CreateReportHoaDonResult> reportData = dhb.GetReportHoaDon(MaDH);

                DataTable dt = ConvertToDataTable(reportData);

                using (var reportObject = new Des_Report_PrintOder())
                {
                    reportObject.SetDataSource(dt);
                    try
                    {

                        reportObject.SetParameterValue("TienKM", txtKhuyenMai.Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Giá khuyến mãi không hợp lệ. Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var reportForm = new ReportHoaDon_Form())
                    {
                        reportForm.ReportViewer.ReportSource = reportObject;
                        reportForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xuất phiếu nhập: " + ex.Message);
            }
        }

        private DataTable ConvertToDataTable(List<CreateReportHoaDonResult> data)
        {
            DataTable table = new DataTable();

            if (data == null || !data.Any())
                return table;

            var properties = TypeDescriptor.GetProperties(typeof(CreateReportHoaDonResult));
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    var value = prop.GetValue(item);
                    row[prop.Name] = value ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }


        private async void resetForm()
        {
            txtKhuyenMai.Text = string.Empty;
            txtMaNB.Text = string.Empty;
            txtSearchSP.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;

            dgviewm_listSanPham.Rows.Clear();

            await GenerateRandomMaNB();
        }

        private void txtSearchSP_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchSP.Text.Trim().ToLower();
            int selectedLoai = (cbbLoai.SelectedValue is int loaiValue) ? loaiValue : -1;
            var allProducts = spb.loadSanPhams()
                .Where(sp =>
                    (selectedLoai == -1 || sp.MaLoai == selectedLoai) &&
                    (string.IsNullOrEmpty(searchText) || sp.TenSP.ToLower().Contains(searchText))
                )
                .ToList();
            UpdateProductDisplay(allProducts);
        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedLoai = (cbbLoai.SelectedValue is int loaiValue) ? loaiValue : -1;
            var filteredProducts = spb.loadSanPhams()
                .Where(sp => selectedLoai == -1 || sp.MaLoai == selectedLoai)
                .ToList();

            UpdateProductDisplay(filteredProducts);
        }

        private void UpdateProductDisplay(List<SanPham> products)
        {
            currentPage = 1; 
            productList = products;
            loadDataSanPham(); 
        }
    }
}
