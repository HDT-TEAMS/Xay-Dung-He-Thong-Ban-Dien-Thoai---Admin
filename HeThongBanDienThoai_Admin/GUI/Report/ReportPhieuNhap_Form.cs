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
    public partial class ReportPhieuNhap_Form : Form
    {
        public ReportPhieuNhap_Form()
        {
            InitializeComponent();
        }

        // Create a public property to access the CrystalReportViewer
        public CrystalReportViewer ReportViewer
        {
            get { return crystalReportViewer1; }
        }
    }


}
