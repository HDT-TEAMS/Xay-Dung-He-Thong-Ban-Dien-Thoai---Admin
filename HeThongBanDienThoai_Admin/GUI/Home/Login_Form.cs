using BUS;
using DTO;
using HeThongBanDienThoai_Admin.LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI
{
    public partial class Login_Form : Form
    {
        NguoiDung_BUS ndb = new NguoiDung_BUS();

        public Login_Form()
        {
            InitializeComponent();
            txtUsername.Focus();
            this.btnLogin.Click += BtnLogin_Click;
   
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;

        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '●';
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            //string haspassword = MyLib.HashPassword(password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên người dùng và mật khẩu !");
                return;
            }
            else
            {
                NguoiDung user = ndb.checkLogins(username, password);
                if (user != null)
                {
                    MyLib.maND = user.MaND;
                    Menu_Form menu = new Menu_Form(user.MaND);
                    menu.LoadAllLoaiSP();
                    MyLib.CloseThisOpenThat(this, menu);
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng !!!","Thông báo !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked == true)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
