using System.Drawing;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Product
{
    partial class ListProduct_Form
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel_Action = new System.Windows.Forms.TableLayoutPanel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThemMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TableLayoutPanel_Header = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.TableLayoutPanel_Paginator = new System.Windows.Forms.TableLayoutPanel();
            this.dgviewm_listSanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btn_Sua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MaNB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDungLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDungLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel_Action.SuspendLayout();
            this.TableLayoutPanel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewm_listSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel_Action
            // 
            this.TableLayoutPanel_Action.ColumnCount = 3;
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.TableLayoutPanel_Action.Controls.Add(this.btnLamMoi, 1, 0);
            this.TableLayoutPanel_Action.Controls.Add(this.btnThemMoi, 2, 0);
            this.TableLayoutPanel_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel_Action.Location = new System.Drawing.Point(254, 0);
            this.TableLayoutPanel_Action.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_Action.Name = "TableLayoutPanel_Action";
            this.TableLayoutPanel_Action.RowCount = 1;
            this.TableLayoutPanel_Action.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Action.Size = new System.Drawing.Size(523, 56);
            this.TableLayoutPanel_Action.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnLamMoi.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(293, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 50);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnThemMoi.BorderRadius = 8;
            this.btnThemMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemMoi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemMoi.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnThemMoi.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btnThemMoi.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.ForeColor = System.Drawing.Color.White;
            this.btnThemMoi.Location = new System.Drawing.Point(410, 3);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(110, 50);
            this.btnThemMoi.TabIndex = 4;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // TableLayoutPanel_Header
            // 
            this.TableLayoutPanel_Header.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel_Header.ColumnCount = 2;
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.81853F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.18147F));
            this.TableLayoutPanel_Header.Controls.Add(this.txtSearch, 0, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.TableLayoutPanel_Action, 1, 0);
            this.TableLayoutPanel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel_Header.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel_Header.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_Header.Name = "TableLayoutPanel_Header";
            this.TableLayoutPanel_Header.RowCount = 1;
            this.TableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Header.Size = new System.Drawing.Size(777, 56);
            this.TableLayoutPanel_Header.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(3, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(229, 46);
            this.txtSearch.TabIndex = 2;
            // 
            // TableLayoutPanel_Paginator
            // 
            this.TableLayoutPanel_Paginator.ColumnCount = 1;
            this.TableLayoutPanel_Paginator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Paginator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableLayoutPanel_Paginator.Location = new System.Drawing.Point(0, 455);
            this.TableLayoutPanel_Paginator.Name = "TableLayoutPanel_Paginator";
            this.TableLayoutPanel_Paginator.RowCount = 1;
            this.TableLayoutPanel_Paginator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Paginator.Size = new System.Drawing.Size(777, 43);
            this.TableLayoutPanel_Paginator.TabIndex = 1;
            // 
            // dgviewm_listSanPham
            // 
            this.dgviewm_listSanPham.AllowUserToAddRows = false;
            this.dgviewm_listSanPham.AllowUserToDeleteRows = false;
            this.dgviewm_listSanPham.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.dgviewm_listSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgviewm_listSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgviewm_listSanPham.ColumnHeadersHeight = 40;
            this.dgviewm_listSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgviewm_listSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btn_Sua,
            this.btn_Xoa,
            this.MaNB,
            this.TenSP,
            this.TenMau,
            this.TenDungLuong,
            this.SoLuong,
            this.GiaSP,
            this.MaSP,
            this.MaKM,
            this.MaLoai,
            this.MaMau,
            this.MaDungLuong,
            this.IsDeleted});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewm_listSanPham.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgviewm_listSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewm_listSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgviewm_listSanPham.Location = new System.Drawing.Point(0, 56);
            this.dgviewm_listSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.dgviewm_listSanPham.Name = "dgviewm_listSanPham";
            this.dgviewm_listSanPham.ReadOnly = true;
            this.dgviewm_listSanPham.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgviewm_listSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgviewm_listSanPham.RowHeadersVisible = false;
            this.dgviewm_listSanPham.RowHeadersWidth = 51;
            this.dgviewm_listSanPham.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgviewm_listSanPham.RowTemplate.Height = 40;
            this.dgviewm_listSanPham.Size = new System.Drawing.Size(777, 399);
            this.dgviewm_listSanPham.TabIndex = 2;
            this.dgviewm_listSanPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgviewm_listSanPham.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgviewm_listSanPham.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgviewm_listSanPham.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgviewm_listSanPham.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgviewm_listSanPham.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgviewm_listSanPham.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgviewm_listSanPham.ThemeStyle.HeaderStyle.Height = 40;
            this.dgviewm_listSanPham.ThemeStyle.ReadOnly = true;
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.Height = 40;
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgviewm_listSanPham.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btn_Sua
            // 
            this.btn_Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_Sua.DefaultCellStyle = dataGridViewCellStyle13;
            this.btn_Sua.FillWeight = 20F;
            this.btn_Sua.HeaderText = "";
            this.btn_Sua.MinimumWidth = 6;
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.ReadOnly = true;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseColumnTextForButtonValue = true;
            this.btn_Sua.Width = 6;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Xoa.DefaultCellStyle = dataGridViewCellStyle14;
            this.btn_Xoa.FillWeight = 20F;
            this.btn_Xoa.HeaderText = "";
            this.btn_Xoa.MinimumWidth = 6;
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.ReadOnly = true;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseColumnTextForButtonValue = true;
            this.btn_Xoa.Width = 6;
            // 
            // MaNB
            // 
            this.MaNB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaNB.DataPropertyName = "MaNB";
            this.MaNB.DividerWidth = 1;
            this.MaNB.FillWeight = 41.48204F;
            this.MaNB.HeaderText = "Mã sản phẩm";
            this.MaNB.MinimumWidth = 6;
            this.MaNB.Name = "MaNB";
            this.MaNB.ReadOnly = true;
            this.MaNB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaNB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TenSP
            // 
            this.TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.DividerWidth = 1;
            this.TenSP.FillWeight = 41.48204F;
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // TenMau
            // 
            this.TenMau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenMau.DataPropertyName = "TenMau";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TenMau.DefaultCellStyle = dataGridViewCellStyle15;
            this.TenMau.DividerWidth = 1;
            this.TenMau.HeaderText = "Màu";
            this.TenMau.MinimumWidth = 6;
            this.TenMau.Name = "TenMau";
            this.TenMau.ReadOnly = true;
            this.TenMau.Width = 210;
            // 
            // TenDungLuong
            // 
            this.TenDungLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenDungLuong.DataPropertyName = "TenDungLuong";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TenDungLuong.DefaultCellStyle = dataGridViewCellStyle16;
            this.TenDungLuong.DividerWidth = 1;
            this.TenDungLuong.HeaderText = "Dung lượng";
            this.TenDungLuong.MinimumWidth = 6;
            this.TenDungLuong.Name = "TenDungLuong";
            this.TenDungLuong.ReadOnly = true;
            this.TenDungLuong.Width = 209;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle17;
            this.SoLuong.DividerWidth = 1;
            this.SoLuong.FillWeight = 41.48204F;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // GiaSP
            // 
            this.GiaSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GiaSP.DataPropertyName = "GiaSP";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "0,0";
            this.GiaSP.DefaultCellStyle = dataGridViewCellStyle18;
            this.GiaSP.DividerWidth = 1;
            this.GiaSP.FillWeight = 41.48204F;
            this.GiaSP.HeaderText = "Giá";
            this.GiaSP.MinimumWidth = 6;
            this.GiaSP.Name = "GiaSP";
            this.GiaSP.ReadOnly = true;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "MaSP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            this.MaSP.Visible = false;
            // 
            // MaKM
            // 
            this.MaKM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaKM.DataPropertyName = "MaKM";
            this.MaKM.HeaderText = "MaKM";
            this.MaKM.MinimumWidth = 6;
            this.MaKM.Name = "MaKM";
            this.MaKM.ReadOnly = true;
            this.MaKM.Visible = false;
            // 
            // MaLoai
            // 
            this.MaLoai.DataPropertyName = "MaLoai";
            this.MaLoai.HeaderText = "MaLoai";
            this.MaLoai.MinimumWidth = 6;
            this.MaLoai.Name = "MaLoai";
            this.MaLoai.ReadOnly = true;
            this.MaLoai.Visible = false;
            // 
            // MaMau
            // 
            this.MaMau.DataPropertyName = "MaMau";
            this.MaMau.HeaderText = "MaMau";
            this.MaMau.MinimumWidth = 6;
            this.MaMau.Name = "MaMau";
            this.MaMau.ReadOnly = true;
            this.MaMau.Visible = false;
            // 
            // MaDungLuong
            // 
            this.MaDungLuong.DataPropertyName = "MaDungLuong";
            this.MaDungLuong.HeaderText = "MaDungLuong";
            this.MaDungLuong.MinimumWidth = 6;
            this.MaDungLuong.Name = "MaDungLuong";
            this.MaDungLuong.ReadOnly = true;
            this.MaDungLuong.Visible = false;
            // 
            // IsDeleted
            // 
            this.IsDeleted.DataPropertyName = "IsDeleted";
            this.IsDeleted.HeaderText = "IsDeleted";
            this.IsDeleted.MinimumWidth = 6;
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            this.IsDeleted.Visible = false;
            // 
            // ListProduct_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 498);
            this.Controls.Add(this.dgviewm_listSanPham);
            this.Controls.Add(this.TableLayoutPanel_Paginator);
            this.Controls.Add(this.TableLayoutPanel_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListProduct_Form";
            this.Load += new System.EventHandler(this.ListProduct_Form_Load);
            this.TableLayoutPanel_Action.ResumeLayout(false);
            this.TableLayoutPanel_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgviewm_listSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel TableLayoutPanel_Action;
        private TableLayoutPanel TableLayoutPanel_Header;
        private TableLayoutPanel TableLayoutPanel_Paginator;
        private Guna.UI2.WinForms.Guna2DataGridView dgviewm_listSanPham;
        private Guna.UI2.WinForms.Guna2GradientButton btnLamMoi;
        private Guna.UI2.WinForms.Guna2GradientButton btnThemMoi;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private DataGridViewButtonColumn btn_Sua;
        private DataGridViewButtonColumn btn_Xoa;
        private DataGridViewTextBoxColumn MaNB;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn TenMau;
        private DataGridViewTextBoxColumn TenDungLuong;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn GiaSP;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn MaKM;
        private DataGridViewTextBoxColumn MaLoai;
        private DataGridViewTextBoxColumn MaMau;
        private DataGridViewTextBoxColumn MaDungLuong;
        private DataGridViewTextBoxColumn IsDeleted;
    }
}