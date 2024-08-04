using System;
using System.ComponentModel;
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
            this.Validating += PhoneBox_Validating;
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhoneBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.TextLength != 10)
            {
                MessageBox.Show("Vui lòng nhập đủ 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Giữ focus lại trên TextBox nếu số ký tự không hợp lệ
            }
        }
    }
}
