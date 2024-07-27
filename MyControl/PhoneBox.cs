using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace MyControl
{
    public partial class phoneBox : Guna2TextBox
    {
        public phoneBox()
        {
            InitializeComponent();
            this.KeyPress += PhoneBox_KeyPress;
        }

        private void PhoneBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
    }
}
