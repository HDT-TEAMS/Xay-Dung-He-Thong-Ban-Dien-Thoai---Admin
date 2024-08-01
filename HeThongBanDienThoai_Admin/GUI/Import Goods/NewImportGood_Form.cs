using BUS;
using DTO;
using Guna.UI2.WinForms;
using HeThongBanDienThoai_Admin.GUI.Report;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Import_Goods
{
    public partial class NewImportGood_Form : Form
    {
        private int _maPN;
        private PhieuNhap_BUS pnb = new PhieuNhap_BUS();
        private ChiTietPhieuNhap_BUS ctpnb = new ChiTietPhieuNhap_BUS();
        private NhaCungCap_BUS nccb = new NhaCungCap_BUS();
        private NhanVien_BUS nvb = new NhanVien_BUS();
        private BindingList<View_SanPhamDetailsByLoai> _productList = new BindingList<View_SanPhamDetailsByLoai>();
        private Dictionary<int, bool> _checkedStates = new Dictionary<int, bool>();
        private int maNhanVien;
        private Des_Report_PrintImports reportObject;
        public NewImportGood_Form()
        {
            InitializeComponent();
            loadCbbNhaCungCap();
            loadControl();
            dateTime_NLP.Text = DateTime.Now.ToString("G");
            dgv_listPhieuNhap.DataSource = _productList;
            dgv_listPhieuNhap.CellValueChanged += Dgv_listPhieuNhap_CellValueChanged;
            dgv_listPhieuNhap.RowsRemoved += Dgv_listPhieuNhap_RowsRemoved;
            this.btnLuu.Click += BtnLuu_Click;
            btnXuatPhieu.Enabled = false;
            Label_Headings.Text = "Thêm phiếu nhập mới: " + txtMaNBPN.Text;
        }

        
        public NewImportGood_Form(int maPN)
        {
            InitializeComponent();
            EnableControl();
            this._maPN = maPN;
            dgv_listPhieuNhap.DataBindingComplete += Dgv_listPhieuNhap_DataBindingComplete;
            loadCbbNhaCungCap();
            loadData();
        }


        private async void loadControl()
        {
            txtMaNBPN.Enabled = false;
            txtNhanVien.Enabled = false;
            txtTongTien.Enabled = false;
            dateTime_NLP.Enabled = false;
            string maNb = await MyLib.RandomMaNBPN();
            txtMaNBPN.Text = maNb;
            txtNhanVien.Text = nvb.GetNhanVienNameById(MyLib.maND);


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
                        GiaNhap = 0,
                        SoLuong = 0
                    };
                    _productList.Add(newProduct);
                }
                _checkedStates[product.MaSP] = true;
            }

            dgv_listPhieuNhap.DataSource = _productList;
            foreach (DataGridViewRow row in dgv_listPhieuNhap.Rows)
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

        private void NewImportGood_Form_Load(object sender, EventArgs e)
        {
            loadCbbNhaCungCap();
            dgv_listPhieuNhap.DataSource = _productList;
        }

        private async void loadData()
        {
            var list = ctpnb.getListCTPNByMaPN(_maPN);
            dgv_listPhieuNhap.DataSource = list;

            if (list.Any())
            {
                var item = list.First();
                txtMaNBPN.Text = item.MaNB;
                Label_Headings.Text = "Thông tin phiếu nhập: " + item.MaNB;
                txtNhanVien.Text = item.TenNV;
                txtTongTien.Text = MyLib.AddCommas(item.TongTien);
                dateTime_NLP.Value = item.NgayNhap ?? DateTime.Now;
                var selectedNCC = nccb.loadAllNhaCungCap() .FirstOrDefault(ncc => ncc.TenNCC == item.TenNCC);
                if (selectedNCC != null)
                {
                    cbbNhaCC.SelectedValue = selectedNCC.MaNCC;
                }
            }

        }

        private void loadCbbNhaCungCap()
        {
            var nccList = nccb.loadAllNhaCungCap();
            nccList.Insert(0, new NhaCC { MaNCC = -1, TenNCC = "Chọn nhà cung cấp" });
            cbbNhaCC.DataSource = nccList;
            cbbNhaCC.DisplayMember = "TenNCC";
            cbbNhaCC.ValueMember = "MaNCC";
        }

        private void EnableControl()
        {
            txtMaNBPN.Enabled = false;
            txtNhanVien.Enabled = false;
            txtTongTien.Enabled = false;
            cbbNhaCC.Enabled = false;
            dateTime_NLP.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ImportProduct_Form frm = new ImportProduct_Form();
            frm.OnProductsSelected += (selectedProducts) =>
            {
                SetSelectedProducts(selectedProducts);
            };
            frm.Show();
        }
        private void Frm_OnProductsSelected(List<View_SanPhamDetailsByLoai> selectedProducts)
        {
            SetSelectedProducts(selectedProducts);
        }

        private void Dgv_listPhieuNhap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_listPhieuNhap.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["checkSP"].Value = true;
                }
            }
        }

        private void sumMoney()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_listPhieuNhap.Rows)
            {
                if (row.IsNewRow) continue;
                decimal giaNhap = Convert.ToDecimal(row.Cells["GiaNhap"].Value ?? 0);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0);
                total += giaNhap * soLuong;
            }
            txtTongTien.Text = MyLib.AddCommas(total);
        }

        private void Dgv_listPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            sumMoney();
        }

        private void Dgv_listPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_listPhieuNhap.Columns["GiaNhap"].Index ||
                e.ColumnIndex == dgv_listPhieuNhap.Columns["SoLuong"].Index)
            {
                sumMoney();
            }
        }

        private void btn_Back_Click_1(object sender, EventArgs e)
        {
            MyLib.LoadForm(this, new ListImportGoods_Form());
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            int maNV = nvb.GetMaNVById(MyLib.maND);

            if (cbbNhaCC.SelectedValue == null || Convert.ToInt32(cbbNhaCC.SelectedValue) == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal? tongTien = MyLib.ParseCurrencyString(txtTongTien.Text, "đ");
            if (tongTien == null || tongTien <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ hoặc không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuNhap newPhieuNhap = new PhieuNhap
            {
                MaNB = txtMaNBPN.Text.Trim(),
                MaNCC = Convert.ToInt32(cbbNhaCC.SelectedValue),
                NgayNhap = DateTime.Now,
                MaNV = maNV,
                TongTien = tongTien
            };

            pnb.InsertPhieuNhap(newPhieuNhap);

            if (_productList == null || !_productList.Any())
            {
                MessageBox.Show("Danh sách sản phẩm không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPN = newPhieuNhap.MaPN;

            foreach (var sp in _productList)
            {
                if (sp.GiaNhap <= 0 || sp.SoLuong <= 0)
                {
                    MessageBox.Show($"Sản phẩm {sp.MaSP} có giá nhập hoặc số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                decimal giaNhap = sp.GiaNhap ?? 0;
                decimal giaNhapLamTron = (giaNhap >= 1000)? Math.Round(giaNhap / 1000) * 1000: giaNhap;

                ChiTietPN chiTietPN = new ChiTietPN
                {
                    MaPN = maPN,
                    MaSP = sp.MaSP,
                    GiaNhap = giaNhapLamTron, 
                    SoLuong = sp.SoLuong
                };

                ctpnb.InsertChiTietPhieuNhap(chiTietPN);

                ctpnb.UpdateSanPhamSauKhiNhapHang(chiTietPN);
            }
            MessageBox.Show("Lưu phiếu nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MyLib.LoadForm(this, new ListImportGoods_Form());
        }

        public void InPhieuNhap(int maPhieu)
        {
            try
            {
                PhieuNhap_BUS phieuNhapBus = new PhieuNhap_BUS();
                List<CreateReportPhieuNhapResult> reportData = phieuNhapBus.GetReportPhieuNhap(maPhieu);

                DataTable dt = ConvertToDataTable(reportData);

                using (reportObject = new Des_Report_PrintImports())
                {
                    reportObject.SetDataSource(dt);

                    using (ReportPhieuNhap_Form reportForm = new ReportPhieuNhap_Form())
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

        private DataTable ConvertToDataTable(List<CreateReportPhieuNhapResult> data)
        {
            DataTable table = new DataTable();

            if (data == null || !data.Any())
                return table;
            var properties = TypeDescriptor.GetProperties(typeof(CreateReportPhieuNhapResult));
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }

        private void btnXuatPhieu_Click(object sender, EventArgs e)
        {
            InPhieuNhap(_maPN);
        }
    }
}
