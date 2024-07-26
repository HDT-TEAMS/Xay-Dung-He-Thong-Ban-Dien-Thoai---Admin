using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyControl
{
    public partial class EmailBox : TextBox
    {
        private ErrorProvider errorProvider;

        public EmailBox()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            this.TextChanged += EmailBox_TextChanged;
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidEmail(this.Text))
            {
                errorProvider.SetError(this, "Email không hợp lệ.");
            }
            else
            {
                errorProvider.SetError(this, "");
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                // Sử dụng biểu thức chính quy (regex) để kiểm tra định dạng email
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                return emailRegex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
