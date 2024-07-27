using DTO;
using BUS;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Net.Http;

namespace HeThongBanDienThoai_Admin.GUI.Product
{
    public partial class NewProduct_Form : Form
    {
        DungLuong_BUS dlb = new DungLuong_BUS();
        MauSac_BUS msb = new MauSac_BUS();
        SanPham_BUS spb = new SanPham_BUS();
        SanPham sp = new SanPham();
        private List<string> imagePaths = new List<string>();
        private List<string> uploadedImageUrls = new List<string>();
        private ImgurUploader uploader = new ImgurUploader();
        private Loai _loai;
        private int _maSP;

        public NewProduct_Form(Loai loai)
        {
            InitializeComponent();
            this._loai = loai;
        }

        public NewProduct_Form(Loai loai,int masp)
        {
            InitializeComponent();
            this._loai = loai;
            this._maSP= masp;
            loadChiTietSanPham(_maSP);
            Label_Headings.Text = "Cập nhật sản phẩm " + sp.TenSP;
        }


        private async void NewProduct_Form_Load(object sender, EventArgs e)
        {
               loadCbbMauSac();
               loadCbbDungLuong();
        }

        private async Task LoadComboBoxDataAsync()
        {
            await Task.Run(() =>
            {
                var dungLuongList = dlb.loadAllDungLuong();
                dungLuongList.Insert(0, new DungLuong { MaDungLuong = -1, TenDungLuong = "Chọn dung lượng" });
                cbb_DungLuong.Invoke((MethodInvoker)delegate
                {
                    cbb_DungLuong.DataSource = dungLuongList;
                    cbb_DungLuong.DisplayMember = "TenDungLuong";
                    cbb_DungLuong.ValueMember = "MaDungLuong";
                });
                var mauSacList = msb.loadAllMauSac();
                mauSacList.Insert(0, new MauSac { MaMau = -1, TenMau = "Chọn màu sắc" });
                cbb_Mau.Invoke((MethodInvoker)delegate
                {
                    cbb_Mau.DataSource = mauSacList;
                    cbb_Mau.DisplayMember = "TenMau";
                    cbb_Mau.ValueMember = "MaMau";
                });
            });
        }

        private async void loadChiTietSanPham(int maSP)
        {
            sp = spb.getSanPhamByMaSPs(maSP);
            if (sp != null)
            {
                txtMaSPNB.Text = sp.MaNB;
                txtTenSP.Text = sp.TenSP;
                txtGia.Text = sp.GiaSP.HasValue ? sp.GiaSP.Value.ToString("N0") : "0";
                await LoadComboBoxDataAsync();
                if (sp.MaDungLuong.HasValue)
                {
                    if (cbb_DungLuong.Items.Cast<DungLuong>().Any(dl => dl.MaDungLuong == sp.MaDungLuong.Value))
                    {
                        cbb_DungLuong.SelectedValue = sp.MaDungLuong.Value;
                    }
                }
                if (sp.MaMau.HasValue)
                {
                    if (cbb_Mau.Items.Cast<MauSac>().Any(ms => ms.MaMau == sp.MaMau.Value))
                    {
                        cbb_Mau.SelectedValue = sp.MaMau.Value;
                    }
                }
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    imagePaths = sp.HinhAnh.Split(',').ToList();
                    LoadImagesToPanel();
                }
            }
            else
            {
                Console.WriteLine("SanPham not found");
            }
        }

        private void loadCbbDungLuong()
        {
            var dungLuongList = dlb.loadAllDungLuong();
            dungLuongList.Insert(0, new DungLuong { MaDungLuong = -1, TenDungLuong = "Chọn dung lượng" }); 
            cbb_DungLuong.DataSource = dungLuongList;
            cbb_DungLuong.DisplayMember = "TenDungLuong";
            cbb_DungLuong.ValueMember = "MaDungLuong";
        }

        private void loadCbbMauSac()
        {
            var mauSacList = msb.loadAllMauSac();
            mauSacList.Insert(0, new MauSac { MaMau = -1, TenMau = "Chọn màu sắc" }); 
            cbb_Mau.DataSource = mauSacList;
            cbb_Mau.DisplayMember = "TenMau";
            cbb_Mau.ValueMember = "MaMau";
        }

        private FlowLayoutPanel CreateFlowLayoutPanel()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };
        }

        private Panel CreateImagePanel(string url)
        {
            var panel = new Panel
            {
                Padding = new Padding(10),
                Size = new Size(141, 167),
                Margin = new Padding(10),
                Anchor = AnchorStyles.None
            };

            var pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 3, 12, 3),
                Padding = new Padding(0, 0, 12, 0),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            try
            {
                pictureBox.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hình ảnh: {url}\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var deleteButton = new Button
            {
                Text = "Xóa",
                Height = 36,
                Dock = DockStyle.Bottom,
                Margin = new Padding(0, 0, 0, 10)
            };
            deleteButton.Click += (sender, e) => DeleteImage(url);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(deleteButton);

            return panel;
        }



        private void DeleteImage(string imageUrl)
        {
            imagePaths.Remove(imageUrl);
            LoadImagesToPanel();
        }

        private void LoadImagesToPanel()
        {
            panel_HinhAnh.Controls.Clear();
            var flowLayoutPanel = CreateFlowLayoutPanel();
            foreach (var imagePath in imagePaths)
            {
                var imagePanel = CreateImagePanel(imagePath);
                flowLayoutPanel.Controls.Add(imagePanel);
            }
            panel_HinhAnh.Controls.Add(flowLayoutPanel);
        }


        private void pictureImage_Click(object sender, EventArgs e)
        {
            using (var openImage = new OpenFileDialog())
            {
                openImage.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
                openImage.Multiselect = true;

                if (openImage.ShowDialog() == DialogResult.OK)
                {
                    var validPaths = openImage.FileNames.Where(path => File.Exists(path)).ToList();
                    imagePaths.AddRange(validPaths);
                    LoadImagesToPanel();
                }
            }
        }


        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string maNB = txtMaSPNB.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            decimal donGia;
            int soluong = 0;

            if (string.IsNullOrEmpty(maNB))
            {
                MessageBox.Show("Vui lòng nhập mã nội bộ!");
                txtMaSPNB.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                txtTenSP.Focus();
                return;
            }

            if (!decimal.TryParse(txtGia.Text, out donGia))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ!");
                txtGia.Focus();
                return;
            }

            int? maDL = null;
            if (int.TryParse(cbb_DungLuong.SelectedValue.ToString(), out int dl) && dl != -1)
            {
                maDL = dl;
            }

            int maMau = -1;
            if (int.TryParse(cbb_Mau.SelectedValue.ToString(), out int mau) && mau != -1)
            {
                maMau = mau;
            }

            try
            {
                string oldImageUrls = string.Empty;
                if (_maSP != 0)
                {
                    var existingProduct = spb.getSanPhamByMaSPs(_maSP);
                    if (existingProduct != null)
                    {
                        oldImageUrls = existingProduct.HinhAnh;
                    }
                }

                uploadedImageUrls.Clear();
                foreach (var imagePath in imagePaths)
                {
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            string imageUrl = await uploader.UploadFileAsync(imagePath);
                            if (!string.IsNullOrEmpty(imageUrl))
                            {
                                uploadedImageUrls.Add(imageUrl);
                            }
                            else
                            {
                                MessageBox.Show($"Không thể upload hình ảnh: {imagePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi upload hình ảnh: {imagePath}\n{ex.Message}");
                        }
                    }
                }

                // Xác định các URL hình ảnh cần giữ lại (hình ảnh cũ không bị xóa)
                var oldImageUrlsList = oldImageUrls.Split(',')
                                                    .Where(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                                                    .ToList();
                var unchangedImageUrls = oldImageUrlsList.Intersect(imagePaths).ToList();
                var finalImageUrls = unchangedImageUrls.Union(uploadedImageUrls).ToList();
                string finalImageUrlsString = string.Join(",", finalImageUrls);

                if (_maSP == 0)
                {
                    spb.AddSanPham(maNB, tenSP, maDL, donGia, finalImageUrlsString, soluong, _loai.Maloai, maMau);
                    MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearControls(this);
                }
                else
                {
                    SanPham existingProduct = spb.getSanPhamByMaSPs(_maSP);
                    if (existingProduct != null)
                    {
                        int updatedSoLuong = soluong > 0 ? soluong : existingProduct.SoLuong ?? 0;
                        spb.UpdateSanPham(_maSP, maNB, tenSP, maDL , donGia, finalImageUrlsString, updatedSoLuong, _loai.Maloai, maMau);
                        MessageBox.Show("Sản phẩm đã được cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void ClearControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }
                else if (control.HasChildren)
                {
                    ClearControls(control);
                }
            }
            imagePaths.Clear();
            uploadedImageUrls.Clear();
            panel_HinhAnh.Controls.Clear();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new ListProduct_Form(_loai));
        }
    }
}
