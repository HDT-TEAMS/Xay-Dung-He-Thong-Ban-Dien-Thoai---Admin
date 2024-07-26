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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Button_Create = new Guna.UI2.WinForms.Guna2Button();
            this.Button_Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.Text_Search = new Guna.UI2.WinForms.Guna2TextBox();
            this.TableLayoutPanel_Action = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel_Header = new System.Windows.Forms.TableLayoutPanel();
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
            // Button_Create
            // 
            this.Button_Create.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Button_Create.AnimatedGIF = true;
            this.Button_Create.BorderRadius = 8;
            this.Button_Create.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_Create.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_Create.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_Create.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_Create.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Button_Create.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Button_Create.ForeColor = System.Drawing.Color.White;
            this.Button_Create.Location = new System.Drawing.Point(289, 4);
            this.Button_Create.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(100, 35);
            this.Button_Create.TabIndex = 0;
            this.Button_Create.Text = "Thêm mới";
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Button_Refresh.AnimatedGIF = true;
            this.Button_Refresh.BorderRadius = 8;
            this.Button_Refresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_Refresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_Refresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_Refresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_Refresh.FillColor = System.Drawing.Color.Green;
            this.Button_Refresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Button_Refresh.ForeColor = System.Drawing.Color.White;
            this.Button_Refresh.Location = new System.Drawing.Point(179, 4);
            this.Button_Refresh.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(101, 35);
            this.Button_Refresh.TabIndex = 1;
            this.Button_Refresh.Text = "Làm mới";
            // 
            // Text_Search
            // 
            this.Text_Search.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Text_Search.Animated = true;
            this.Text_Search.BorderRadius = 5;
            this.Text_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text_Search.DefaultText = "";
            this.Text_Search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Text_Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Text_Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Text_Search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Text_Search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Text_Search.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Text_Search.ForeColor = System.Drawing.Color.Black;
            this.Text_Search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Text_Search.Location = new System.Drawing.Point(0, 4);
            this.Text_Search.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Search.Name = "Text_Search";
            this.Text_Search.PasswordChar = '\0';
            this.Text_Search.PlaceholderText = "Tìm kiếm...";
            this.Text_Search.SelectedText = "";
            this.Text_Search.Size = new System.Drawing.Size(201, 35);
            this.Text_Search.TabIndex = 2;
            // 
            // TableLayoutPanel_Action
            // 
            this.TableLayoutPanel_Action.ColumnCount = 3;
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.TableLayoutPanel_Action.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.TableLayoutPanel_Action.Controls.Add(this.Button_Create, 2, 0);
            this.TableLayoutPanel_Action.Controls.Add(this.Button_Refresh, 1, 0);
            this.TableLayoutPanel_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel_Action.Location = new System.Drawing.Point(388, 0);
            this.TableLayoutPanel_Action.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_Action.Name = "TableLayoutPanel_Action";
            this.TableLayoutPanel_Action.RowCount = 1;
            this.TableLayoutPanel_Action.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Action.Size = new System.Drawing.Size(389, 43);
            this.TableLayoutPanel_Action.TabIndex = 1;
            // 
            // TableLayoutPanel_Header
            // 
            this.TableLayoutPanel_Header.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel_Header.ColumnCount = 2;
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Header.Controls.Add(this.TableLayoutPanel_Action, 1, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.Text_Search, 0, 0);
            this.TableLayoutPanel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel_Header.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel_Header.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_Header.Name = "TableLayoutPanel_Header";
            this.TableLayoutPanel_Header.RowCount = 1;
            this.TableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel_Header.Size = new System.Drawing.Size(777, 43);
            this.TableLayoutPanel_Header.TabIndex = 0;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgviewm_listSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgviewm_listSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgviewm_listSanPham.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgviewm_listSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgviewm_listSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgviewm_listSanPham.Location = new System.Drawing.Point(0, 43);
            this.dgviewm_listSanPham.Margin = new System.Windows.Forms.Padding(0);
            this.dgviewm_listSanPham.Name = "dgviewm_listSanPham";
            this.dgviewm_listSanPham.ReadOnly = true;
            this.dgviewm_listSanPham.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgviewm_listSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgviewm_listSanPham.RowHeadersVisible = false;
            this.dgviewm_listSanPham.RowHeadersWidth = 51;
            this.dgviewm_listSanPham.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgviewm_listSanPham.RowTemplate.Height = 40;
            this.dgviewm_listSanPham.Size = new System.Drawing.Size(777, 412);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btn_Sua.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Xoa.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.TenDungLuong.DividerWidth = 1;
            this.TenDungLuong.HeaderText = "Dung lượng";
            this.TenDungLuong.MinimumWidth = 6;
            this.TenDungLuong.Name = "TenDungLuong";
            this.TenDungLuong.ReadOnly = true;
            this.TenDungLuong.Width = 209;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoLuong.DividerWidth = 1;
            this.SoLuong.FillWeight = 41.48204F;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 87;
            // 
            // GiaSP
            // 
            this.GiaSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GiaSP.DataPropertyName = "GiaSP";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0,0";
            this.GiaSP.DefaultCellStyle = dataGridViewCellStyle6;
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
        private Guna.UI2.WinForms.Guna2Button Button_Create;
        private Guna.UI2.WinForms.Guna2Button Button_Refresh;
        private Guna.UI2.WinForms.Guna2TextBox Text_Search;
        private TableLayoutPanel TableLayoutPanel_Action;
        private TableLayoutPanel TableLayoutPanel_Header;
        private TableLayoutPanel TableLayoutPanel_Paginator;
        private Guna.UI2.WinForms.Guna2DataGridView dgviewm_listSanPham;
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