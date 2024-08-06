﻿using BUS;
using DTO;
using Guna.UI2.WinForms;
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
    public partial class AddProductPromotionForm : Form
    {
        private SanPham_BUS spb = new SanPham_BUS();
        private int pageSize = 9;
        private int currentPage = 1;
        private int totalProducts;
        private int totalPages;
        public List<View_SanPhamDetailsByLoai> selectedProducts = new List<View_SanPhamDetailsByLoai>();
        private Guna2Button currentButton;
        private Dictionary<int, bool> _checkedStates = new Dictionary<int, bool>();
        private List<View_SanPhamDetailsByLoai> allProducts;
        public delegate void PassSelectedProductsHandler(List<View_SanPhamDetailsByLoai> selectedProducts);
        public event PassSelectedProductsHandler OnProductsSelected;

        public AddProductPromotionForm()
        {
            InitializeComponent();
        }

        private void AddProductPromotionForm_Load(object sender, EventArgs e)
        {
            allProducts = spb.getAllSanPham();
            totalProducts = allProducts.Count;
            totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            LoadData();
        }

        private void LoadData()
        {
            var productsForCurrentPage = allProducts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dgviews_SanPham.DataSource = productsForCurrentPage;

            foreach (DataGridViewRow row in dgviews_SanPham.Rows)
            {
                var product = (View_SanPhamDetailsByLoai)row.DataBoundItem;
                if (_checkedStates.ContainsKey(product.MaSP))
                {
                    row.Cells["checkSP"].Value = _checkedStates[product.MaSP];
                }
                else
                {
                    row.Cells["checkSP"].Value = false;
                }
            }
            dgviews_SanPham.Refresh();
            CreatePageButtons();
        }



        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            selectedProducts.Clear();
            foreach (var product in allProducts)
            {
                if (_checkedStates.ContainsKey(product.MaSP) && _checkedStates[product.MaSP])
                {
                    selectedProducts.Add(product);
                }
            }
            OnProductsSelected?.Invoke(selectedProducts);
            this.Hide();
        }

        private void CreatePageButtons()
        {
            flowLayoutPanel_page.Controls.Clear();
            if (currentPage > 1)
            {
                Guna2Button btnPrevious = Button("<");
                btnPrevious.Click += (sender, e) =>
                {
                    currentPage--;
                    LoadData();
                };
                flowLayoutPanel_page.Controls.Add(btnPrevious);
            }

            for (int i = 1; i <= totalPages; i++)
            {
                Guna2Button btn = Button(i.ToString());
                btn.Click += (sender, e) =>
                {
                    if (currentButton != null)
                    {
                        currentButton.FillColor = Color.LightGray;
                        currentButton.ForeColor = Color.Black;
                    }
                    currentButton = btn;
                    currentButton.FillColor = Color.RoyalBlue;
                    currentButton.ForeColor = Color.White;

                    currentPage = (int)btn.Tag;
                    LoadData();
                };
                btn.Tag = i;
                if (i == currentPage)
                {
                    btn.FillColor = Color.RoyalBlue;
                    btn.ForeColor = Color.White;
                    currentButton = btn;
                }
                flowLayoutPanel_page.Controls.Add(btn);
            }

            if (currentPage < totalPages)
            {
                Guna2Button btnNext = Button(">");
                btnNext.Click += (sender, e) =>
                {
                    currentPage++;
                    LoadData();
                };
                flowLayoutPanel_page.Controls.Add(btnNext);
            }
            flowLayoutPanel_page.Location = new Point((this.ClientSize.Width - flowLayoutPanel_page.Width) / 2,
                                                 this.ClientSize.Height - flowLayoutPanel_page.Height - 20);
        }

        private Guna2Button Button(string text)
        {
            Guna2Button btn = new Guna2Button();
            btn.BorderRadius = 5;
            btn.FillColor = Color.LightGray;
            btn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn.ForeColor = Color.Black;
            btn.Size = new Size(40, 40);
            btn.Text = text;
            return btn;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text;

            if (string.IsNullOrEmpty(text))
            {
                LoadData();
            }
            else
            {
                dgviews_SanPham.DataSource = spb.SearchSanPhamByTenSP(text);
            }
        }

        private void dgviewm_listSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgviews_SanPham.Columns["checkSP"].Index && e.RowIndex >= 0)
            {
                int maSP = Convert.ToInt32(dgviews_SanPham.Rows[e.RowIndex].Cells["MaSP"].Value);
                bool isChecked = Convert.ToBoolean(dgviews_SanPham.Rows[e.RowIndex].Cells["checkSP"].Value);
                _checkedStates[maSP] = !isChecked;
                dgviews_SanPham.Rows[e.RowIndex].Cells["checkSP"].Value = !isChecked;
            }
        }
    }
}
