namespace HeThongBanDienThoai_Admin.GUI.Statistical
{
    partial class IndexStatistical_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTKCH = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTKOL = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartsp_ganhh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_top5sp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartsp_ganhh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_top5sp)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnTKCH);
            this.guna2Panel1.Controls.Add(this.btnTKOL);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(902, 57);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnTKCH
            // 
            this.btnTKCH.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTKCH.BorderRadius = 8;
            this.btnTKCH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTKCH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTKCH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKCH.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKCH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTKCH.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnTKCH.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btnTKCH.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKCH.ForeColor = System.Drawing.Color.White;
            this.btnTKCH.Location = new System.Drawing.Point(472, 5);
            this.btnTKCH.Name = "btnTKCH";
            this.btnTKCH.Size = new System.Drawing.Size(195, 49);
            this.btnTKCH.TabIndex = 4;
            this.btnTKCH.Text = "Thống kê tại cửa hàng";
            this.btnTKCH.Click += new System.EventHandler(this.btnTKCH_Click);
            // 
            // btnTKOL
            // 
            this.btnTKOL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTKOL.BorderRadius = 8;
            this.btnTKOL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTKOL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTKOL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKOL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKOL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTKOL.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnTKOL.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.btnTKOL.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKOL.ForeColor = System.Drawing.Color.White;
            this.btnTKOL.Location = new System.Drawing.Point(691, 4);
            this.btnTKOL.Name = "btnTKOL";
            this.btnTKOL.Size = new System.Drawing.Size(199, 49);
            this.btnTKOL.TabIndex = 3;
            this.btnTKOL.Text = "Thống kê online";
            this.btnTKOL.Click += new System.EventHandler(this.btnTKOL_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6674F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3326F));
            this.tableLayoutPanel1.Controls.Add(this.chartsp_ganhh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart_top5sp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(902, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartsp_ganhh
            // 
            this.chartsp_ganhh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chartsp_ganhh.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chartsp_ganhh.ChartAreas.Add(chartArea1);
            this.chartsp_ganhh.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartsp_ganhh.Legends.Add(legend1);
            this.chartsp_ganhh.Location = new System.Drawing.Point(450, 3);
            this.chartsp_ganhh.Name = "chartsp_ganhh";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartsp_ganhh.Series.Add(series1);
            this.chartsp_ganhh.Size = new System.Drawing.Size(449, 532);
            this.chartsp_ganhh.TabIndex = 2;
            this.chartsp_ganhh.Text = "chart_spganhhs";
            title1.Name = "Những sản phẩm sắp hết hàng";
            this.chartsp_ganhh.Titles.Add(title1);
            // 
            // chart_top5sp
            // 
            this.chart_top5sp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart_top5sp.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.Name = "ChartArea1";
            this.chart_top5sp.ChartAreas.Add(chartArea2);
            this.chart_top5sp.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_top5sp.Legends.Add(legend2);
            this.chart_top5sp.Location = new System.Drawing.Point(3, 3);
            this.chart_top5sp.Name = "chart_top5sp";
            this.chart_top5sp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_top5sp.Series.Add(series2);
            this.chart_top5sp.Size = new System.Drawing.Size(441, 532);
            this.chart_top5sp.TabIndex = 1;
            this.chart_top5sp.Text = "chart_spganhh";
            // 
            // IndexStatistical_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(902, 595);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IndexStatistical_Form";
            this.Text = "IndexStatistical_Form";
            this.guna2Panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartsp_ganhh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_top5sp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartsp_ganhh;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_top5sp;
        private Guna.UI2.WinForms.Guna2GradientButton btnTKCH;
        private Guna.UI2.WinForms.Guna2GradientButton btnTKOL;
    }
}