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
using System.Web.Management;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.GUI.User_Form
{
    public partial class ResetPass_Form : Form
    {
        private NguoiDung_BUS ndBus = new NguoiDung_BUS();
        private int _maND;
        public ResetPass_Form(int maND)
        {
            InitializeComponent();
            this._maND = maND;
            load();
            txtPassWord.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load()
        {
            var userName = ndBus.GetNguoiDungById(this._maND);
            if (userName != null)
            {
                txtUserName.Text = userName.UserName;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            string newpassword = txtNewPassWord.Text;
            string hasspasswordNew = MyLib.HashPassword(newpassword);

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(newpassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đổi mật khẩu !");
                return;
            }

            var userNameCheck = ndBus.LoadND().SingleOrDefault(nd => nd.UserName == username);

            if (userNameCheck != null) { 
                var  passCheck = ndBus.checkLogins(username, MyLib.HashPassword(password)); 
                if (passCheck != null) { 
                   
                    NguoiDung nd = new NguoiDung()
                    {
                        MaND = _maND,
                        PassWord = hasspasswordNew
                    };
                    ndBus.UpdateNguoiDung(nd);
                    MessageBox.Show("Đổi mật khẩu thành công !","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("PassWord không đúng vui lòng nhập lại !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtPassWord.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("UserName không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            
        }


    }
}
