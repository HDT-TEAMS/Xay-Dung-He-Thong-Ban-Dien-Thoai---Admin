using BUS;
using CrystalDecisions.CrystalReports.Engine;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanDienThoai_Admin.LIB
{
    public static class MyLib
    {
        private static Thread thread;
        public static int maND { get; set; }
        public static string UserName { get; set; }
        public static void CloseThisOpenThat(Form pOldForm, Form pNewForm)
        {
            pOldForm.Close();
            thread = new Thread(() =>
            {
                Application.Run(pNewForm);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public static void LoadForm(Control pBody, Control pControl, DockStyle? dockStyle = DockStyle.Fill)
        {
            pBody.Controls.Clear();
            if (pControl is Form form)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                pBody.Controls.Add(form);
                form.Dock = (DockStyle)dockStyle;
                form.Show();
            }
            else
            {

                AddControl(pBody, pControl, (DockStyle)dockStyle);
            }
        }

        public static void Collapse(bool collapse, Control container)
        {

            if (collapse)
            {
                container.Size = container.MinimumSize;
            }
            else
            {
                container.Size = container.MaximumSize;
            }
        }

        public static void LoadForm(Form form, bool isDialog = false)
        {
            if (isDialog)
            {
                form.ShowDialog();
            }
            else
            {
                form.Show();
            }
        }

        public static void IsNumber(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public static string AddCommas(decimal? number, string currency = "đ")
        {
            return (string.Format("{0:n0}", number) + currency).Trim();
        }

        public static decimal? ParseCurrencyString(string currencyString, string currencySymbol)
        {
            if (string.IsNullOrWhiteSpace(currencyString))
            {
                return null;
            }
            string cleanString = currencyString.Replace(currencySymbol, "").Replace(",", "").Trim();

            if (decimal.TryParse(cleanString, out decimal result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }


        public static string ConvertToTime(int pNumber, int cost)
        {
            int hour = pNumber / cost;
            int minute = (pNumber % cost * 60) / 10000;
            int second = (minute % cost * 60) / 10000;

            return AddZero(hour.ToString()) + ":" + AddZero(minute.ToString()) + ":" + AddZero(second.ToString());
        }

        public static string DeleteCommas(string pStr)
        {
            pStr = pStr.Replace('đ', ' ');
            pStr = pStr.Trim();
            string newStr = "";
            string[] list = pStr.Split(new char[] { '.', ',' });
            foreach (string str in list)
            {
                newStr += str;
            }

            return newStr;
        }

        public static string AddZero(string pStr)
        {
            int number = int.Parse(pStr);
            string newStr = pStr;
            if (number >= 0 && number <= 9)
            {
                newStr = "0" + pStr;
            }
            return newStr;
        }


        public static DateTime GetDateItemFromGunaData(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;

            string nDate = year + "-" + month + "-" + day;

            return DateTime.Parse(nDate);
        }

        public static void AddControl(Control parent, Control chil, DockStyle dockStyle)
        {
            chil.Dock = dockStyle;
            parent.Controls.Add(chil);
        }

        public static void RemoveChildFrom(Control parent, int from)
        {
            int length = parent.Controls.Count - from;

            for (int i = 0; i < length; i++)
            {
                parent.Controls.RemoveAt(0);
            }
        }

        public static bool CheckControlPermission(Control control, int userId)
        {
            if (control.Tag == null)
            {
                return false; 
            }
            string[] tags = control.Tag.ToString().Split('|');
            if (tags.Length < 1)
            {
                return true;
            }
            string controlType = tags[0];
            string permissionName = tags[1];
            using (var db = new DB_DTDDDataContext())
            {
                var userPermissions = db.QuyenNguoiDungs
                    .Where(qnd => qnd.MAND == userId && !(qnd.IsDeleted ?? false))
                    .Join(db.QuyenChucNangs,
                           qnd => qnd.MaQuyen,
                           qcn => qcn.MaQuyen,
                           (qnd, qcn) => new { qnd, qcn })
                    .Join(db.ChucNangs,
                           temp => temp.qcn.MaCN,
                           cn => cn.MaCN,
                           (temp, cn) => cn.TenCN)
                    .ToList();
                switch (controlType)
                {
                    case "parent":
                        string[] requiredPermissions = permissionName.Split(',');
                        foreach (string requiredPermission in requiredPermissions)
                        {
                            if (userPermissions.Contains(requiredPermission))
                            {
                                return true;
                            }
                        }
                        return false;
                    case "children":
                        if (userPermissions.Contains(permissionName))
                        {
                            return true;
                        }
                        return false;

                    default:
                        return true; 
                }
            }
        }


        public static bool CheckPermission(int userId, string permission)
        {
            using (var db = new DB_DTDDDataContext())
            {
                var userPermissions = db.QuyenNguoiDungs
                    .Where(qnd => qnd.MAND == userId && !(qnd.IsDeleted ?? false))
                    .Join(db.QuyenChucNangs,
                           qnd => qnd.MaQuyen,
                           qcn => qcn.MaQuyen,
                           (qnd, qcn) => new { qnd, qcn })
                    .Join(db.ChucNangs,
                           temp => temp.qcn.MaCN,
                           cn => cn.MaCN,
                           (temp, cn) => cn.TenCN)
                    .ToList();
                return userPermissions.Contains(permission);
            }
        }

        public static async Task<string> RandomMaNBPN()
        {
            try
            {
                PhieuNhap_BUS phieuNhap_BUS = new PhieuNhap_BUS();
                List<string> listMaNB = phieuNhap_BUS.GetAllInternalCodes();

                int max = 0;
                foreach (var maNB in listMaNB)
                {
                    var parts = maNB.Split('-');
                    if (parts.Length >= 3)
                    {
                        int number = int.Parse(parts[2]);
                        max = Math.Max(max, number);
                    }
                }

                max++;

                if (max > 99999)
                {
                    max = 1;
                }

                string numberPart = max.ToString("D5"); 
                DateTime currentDate = DateTime.Now;

                string newCode = "PN-" + currentDate.ToString("ddMMyyyy") + "-" + numberPart;
                return newCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating internal code: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<string> RandomHoaDon()
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("ddMMyyyyHHmmss");
            string maHoaDon = $"DHCH{formattedDate}";
            return await Task.FromResult(maHoaDon);
        }

        public static string GenerateCustomerCode()
        {
            KhachHang_BUS khang = new KhachHang_BUS();
            var maxCode = khang.LoadKH()
                               .Where(kh => kh.MaNB.StartsWith("KH") && kh.MaNB.Length == 6)
                               .OrderByDescending(kh => kh.MaNB)
                               .Select(kh => kh.MaNB)
                               .FirstOrDefault();

            if (maxCode == null)
            {
                return "KH0001";
            }

            int maxNumber = int.Parse(maxCode.Substring(2));
            int newNumber = maxNumber + 1;
            return "KH" + newNumber.ToString("D4");
        }




    }
}
