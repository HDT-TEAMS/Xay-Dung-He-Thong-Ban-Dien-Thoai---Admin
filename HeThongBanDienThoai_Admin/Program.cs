using HeThongBanDienThoai_Admin.GUI;
using HeThongBanDienThoai_Admin.GUI.Customer_Form;
using HeThongBanDienThoai_Admin.GUI.Role_Form;
using HeThongBanDienThoai_Admin.GUI.Staff_Form;
using HeThongBanDienThoai_Admin.GUI.User_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace HeThongBanDienThoai_Admin
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Form());
        }
    }
}
