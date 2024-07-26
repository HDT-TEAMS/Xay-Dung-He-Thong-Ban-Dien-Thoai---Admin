using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControl
{
    public partial class TopTaskbarButton : UserControl
    {
        public TopTaskbarButton()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();
            if (currentForm != null)
            {
                if (currentForm.WindowState == FormWindowState.Normal)
                {
                    currentForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    currentForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();
            if (currentForm != null)
            {
                currentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
