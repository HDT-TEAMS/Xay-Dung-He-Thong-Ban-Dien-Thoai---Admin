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
            this.btnLogin.Click += BtnLogin_Click;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên người dùng và mật khẩu !");
                return;
            }
            else
            {
                NguoiDung user = ndb.checkLogins(username, password);
                MyLib.maND = user.MaND;
                if (user != null)
                {
                    Menu_Form menu = new Menu_Form(user.MaND);
                    menu.LoadAllLoaiSP();
                    MyLib.CloseThisOpenThat(this, menu);
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng !!!");
                    return;
                }
            }

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}
