using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.Report
{
    public partial class ReportHoaDon_Form : Form
    {
        public ReportHoaDon_Form()
        {
            InitializeComponent();
        }
        public CrystalReportViewer ReportViewer
        {
            get { return crystalReportViewer1; }
        }
    }
}
