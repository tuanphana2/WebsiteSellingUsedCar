using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace GroupProject_KT.Functions
{
    public partial class Register : System.Web.UI.Page
    {
        ClassConnectSQLSV ketnoi = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btDangKy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string tdn = txtTDN.Text.Trim();
                string mk = txtMK.Text.Trim();
                string hoten = txtTen.Text.Trim();
                string tuoi = txtTuoi.Text.Trim();
                string gioitinh = rblGT.SelectedItem?.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diachi = txtDC.Text.Trim();
                string cccd = txtCCCD.Text.Trim();
                string email = txtEmail.Text.Trim();
                bool isValid = true;

                if (string.IsNullOrEmpty(tdn))
                {
                    lbtbNhapTDN.Text = "You must enter a username";
                    isValid = false;
                }
                else if (!IsValidUsername(tdn))
                {
                    lbtbNhapTDN.Text = "Username must be 3-20 characters long and contain only letters, numbers, or underscores.";
                    isValid = false;
                }
                else
                {
                    lbtbNhapTDN.Text = "";
                }

                if (string.IsNullOrEmpty(mk))
                {
                    lbtbMK.Text = "You must enter a password!";
                    isValid = false;
                }
                else if (mk.Length < 6)
                {
                    lbtbMK.Text = "Password must be at least 6 characters long.";
                    isValid = false;
                }
                else
                {
                    lbtbMK.Text = "";
                }

                if (string.IsNullOrEmpty(hoten))
                {
                    lbtbNhapTen.Text = "You must enter your name!";
                    isValid = false;
                }
                else
                {
                    lbtbNhapTen.Text = "";
                }

                if (string.IsNullOrEmpty(tuoi))
                {
                    lbtbTuoi.Text = "You must enter your age!";
                    isValid = false;
                }
                else if (!int.TryParse(tuoi, out int parsedAge) || parsedAge <= 0)
                {
                    lbtbTuoi.Text = "You must enter a valid age!";
                    isValid = false;
                }
                else
                {
                    lbtbTuoi.Text = "";
                }

                if (string.IsNullOrEmpty(gioitinh))
                {
                    lbtbGT.Text = "You must select your gender!";
                    isValid = false;
                }
                else
                {
                    lbtbGT.Text = "";
                }

                if (string.IsNullOrEmpty(sdt))
                {
                    lbtbSDT.Text = "You must enter a phone number!";
                    isValid = false;
                }
                else if (!Regex.IsMatch(sdt, @"^\d{10,15}$"))
                {
                    lbtbSDT.Text = "Phone number must be between 10 and 15 digits.";
                    isValid = false;
                }
                else
                {
                    lbtbSDT.Text = "";
                }

                if (string.IsNullOrEmpty(diachi))
                {
                    lbtbDC.Text = "You must enter an address!";
                    isValid = false;
                }
                else
                {
                    lbtbDC.Text = "";
                }

                if (string.IsNullOrEmpty(cccd))
                {
                    lbtbNhapCCCD.Text = "You must enter an identity code!";
                    isValid = false;
                }
                else if (!Regex.IsMatch(cccd, @"^\d{9,12}$"))
                {
                    lbtbNhapCCCD.Text = "Identity code must be between 9 and 12 digits.";
                    isValid = false;
                }
                else
                {
                    lbtbNhapCCCD.Text = "";
                }

                if (string.IsNullOrEmpty(email))
                {
                    lbtbEmail.Text = "You must enter an email!";
                    isValid = false;
                }
                else if (!IsValidEmail(email))
                {
                    lbtbEmail.Text = "You must enter a valid email address!";
                    isValid = false;
                }
                else
                {
                    lbtbEmail.Text = "";
                }

                if (isValid)
                {
                    string sql_dulieu = "SELECT * FROM TAIKHOAN WHERE TENDANGNHAP = '" + tdn + "'";
                    DataTable dt = ketnoi.GetData(sql_dulieu);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lbtbNhapTDN.Text = "Username already exists!";
                    }
                    else
                    {
                        lbtbNhapTDN.Text = "";

                        string sql_checkEmail = "SELECT * FROM KHACHHANG WHERE EMAIL = '" + email + "'";
                        DataTable dtEmail = ketnoi.GetData(sql_checkEmail);

                        if (dtEmail != null && dtEmail.Rows.Count > 0)
                        {
                            lbtbEmail.Text = "Email already exists!";
                        }
                        else
                        {
                            lbtbEmail.Text = "";

                            string sql_tk = "INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU) VALUES ('" + tdn + "', '" + mk + "')";
                            int kq = ketnoi.ExecuteQuery(sql_tk);

                            string sql_ttkh = "INSERT INTO KHACHHANG (TENDANGNHAP, TENKHACHHANG, TUOI, GIOITINH, SDT, DIACHI, CCCD, EMAIL) " +
                                              "VALUES ('" + tdn + "', N'" + hoten + "', " + tuoi + ", N'" + gioitinh + "', '" + sdt + "', N'" + diachi + "', '" + cccd + "', '" + email + "')";
                            int kq1 = ketnoi.ExecuteQuery(sql_ttkh);

                            if (kq > 0 && kq1 > 0)
                            {
                                Server.Transfer("~/Functions/Login.aspx");
                            }
                            else
                            {
                                lbthongbao.Text = "Registration unsuccessful";
                            }
                        }
                    }
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9_]{3,20}$");
        }
    }
}
