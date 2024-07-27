using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace MyControl
{
    public partial class textEmail : Guna2TextBox
    {
        private ErrorProvider errorProvider;
        public textEmail()
        {
            errorProvider = new ErrorProvider();
            InitializeComponent();
            InitializeErrorProvider();
            this.TextChanged += TextEmail_TextChanged;
        }
        private void InitializeErrorProvider()
        {
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError,
            };
        }
        private void TextEmail_TextChanged(object sender, EventArgs e)
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
