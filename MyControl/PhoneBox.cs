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
    public partial class PhoneBox : TextBox
    {
        private TextBox textBox;

        public PhoneBox()
        {
            InitializeComponent();
            InitializePhoneBox();
        }

        private void InitializePhoneBox()
        {
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Text = string.Empty;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Dock = DockStyle.Fill;
            textBox.KeyPress += TextBox_KeyPress;
            this.Controls.Add(textBox);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the text associated with this control.")]
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
    }
}
