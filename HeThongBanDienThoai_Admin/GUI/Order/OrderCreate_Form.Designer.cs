namespace HeThongBanDienThoai_Admin.GUI.Order
{
    partial class OrderCreate_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_page = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.TableLayoutPanel_Header = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel_Action = new System.Windows.Forms.TableLayoutPanel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThemMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dgv_XuLyDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Sua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MaNB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel_Header.SuspendLayout();
            this.TableLayoutPanel_Action.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuLyDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_page
            // 
            this.panel_page.BackColor = System.Drawing.Color.White;
            this.panel_page.ColumnCount = 1;
            this.panel_page.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_page.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_page.Location = new System.Drawing.Point(0, 517);
            this.panel_page.Name = "panel_page";
            this.panel_page.RowCount = 1;
            this.panel_page.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_page.Size = new System.Drawing.Size(762, 59);
            this.panel_page.TabIndex = 8;
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
            this.TableLayoutPanel_Header.Size = new System.Drawing.Size(762, 56);
            this.TableLayoutPanel_Header.TabIndex = 7;
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
            this.TableLayoutPanel_Action.Location = new System.Drawing.Point(250, 0);
            this.TableLayoutPanel_Action.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel_Action.Name = "TableLayoutPanel_Action";
            this.TableLayoutPanel_Action.RowCount = 1;
            this.TableLayoutPanel_Action.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Action.Size = new System.Drawing.Size(512, 56);
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
            this.btnLamMoi.Location = new System.Drawing.Point(282, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 50);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
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
            this.btnThemMoi.Location = new System.Drawing.Point(399, 3);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(110, 50);
            this.btnThemMoi.TabIndex = 4;
            this.btnThemMoi.Text = "Thêm mới";
            // 
            // dgv_XuLyDonHang
            // 
            this.dgv_XuLyDonHang.AllowUserToAddRows = false;
            this.dgv_XuLyDonHang.AllowUserToDeleteRows = false;
            this.dgv_XuLyDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_XuLyDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_XuLyDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_XuLyDonHang.ColumnHeadersHeight = 40;
            this.dgv_XuLyDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_XuLyDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sua,
            this.MaNB,
            this.TenNV,
            this.TenKH,
            this.SDT,
            this.NgayDat,
            this.TongTien,
            this.TrangThai,
            this.MaDH});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_XuLyDonHang.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_XuLyDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_XuLyDonHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_XuLyDonHang.Location = new System.Drawing.Point(0, 56);
            this.dgv_XuLyDonHang.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_XuLyDonHang.Name = "dgv_XuLyDonHang";
            this.dgv_XuLyDonHang.ReadOnly = true;
            this.dgv_XuLyDonHang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_XuLyDonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_XuLyDonHang.RowHeadersVisible = false;
            this.dgv_XuLyDonHang.RowHeadersWidth = 51;
            this.dgv_XuLyDonHang.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgv_XuLyDonHang.RowTemplate.Height = 40;
            this.dgv_XuLyDonHang.Size = new System.Drawing.Size(762, 461);
            this.dgv_XuLyDonHang.TabIndex = 10;
            this.dgv_XuLyDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_XuLyDonHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_XuLyDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_XuLyDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_XuLyDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_XuLyDonHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_XuLyDonHang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_XuLyDonHang.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_XuLyDonHang.ThemeStyle.ReadOnly = true;
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.Height = 40;
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_XuLyDonHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Sua
            // 
            this.Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Sua.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sua.FillWeight = 20F;
            this.Sua.HeaderText = "";
            this.Sua.MinimumWidth = 6;
            this.Sua.Name = "Sua";
            this.Sua.ReadOnly = true;
            this.Sua.Text = "Sửa";
            this.Sua.UseColumnTextForButtonValue = true;
            this.Sua.Width = 6;
            // 
            // MaNB
            // 
            this.MaNB.DividerWidth = 1;
            this.MaNB.HeaderText = "Mã Đơn Hàng";
            this.MaNB.Name = "MaNB";
            this.MaNB.ReadOnly = true;
            // 
            // TenNV
            // 
            this.TenNV.DividerWidth = 1;
            this.TenNV.HeaderText = "Nhân Viên";
            this.TenNV.Name = "TenNV";
            this.TenNV.ReadOnly = true;
            // 
            // TenKH
            // 
            this.TenKH.DividerWidth = 1;
            this.TenKH.HeaderText = "Khách Hàng";
            this.TenKH.Name = "TenKH";
            this.TenKH.ReadOnly = true;
            // 
            // SDT
            // 
            this.SDT.DividerWidth = 1;
            this.SDT.HeaderText = "Số Điện Thoại";
            this.SDT.Name = "SDT";
            this.SDT.ReadOnly = true;
            // 
            // NgayDat
            // 
            this.NgayDat.DividerWidth = 1;
            this.NgayDat.HeaderText = "NgayDat";
            this.NgayDat.Name = "NgayDat";
            this.NgayDat.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.DividerWidth = 1;
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DividerWidth = 1;
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // MaDH
            // 
            this.MaDH.DividerWidth = 1;
            this.MaDH.HeaderText = "MaDH";
            this.MaDH.Name = "MaDH";
            this.MaDH.ReadOnly = true;
            this.MaDH.Visible = false;
            // 
            // OrderCreate_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 576);
            this.Controls.Add(this.dgv_XuLyDonHang);
            this.Controls.Add(this.panel_page);
            this.Controls.Add(this.TableLayoutPanel_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderCreate_Form";
            this.Text = "OrderCreate_Form";
            this.TableLayoutPanel_Header.ResumeLayout(false);
            this.TableLayoutPanel_Action.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_XuLyDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panel_page;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel_Header;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel_Action;
        private Guna.UI2.WinForms.Guna2GradientButton btnLamMoi;
        private Guna.UI2.WinForms.Guna2GradientButton btnThemMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_XuLyDonHang;
        private System.Windows.Forms.DataGridViewButtonColumn Sua;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDH;
    }
}