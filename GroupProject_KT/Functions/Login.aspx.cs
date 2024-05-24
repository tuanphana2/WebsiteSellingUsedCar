using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class Login : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btDangNhap_Click(object sender, EventArgs e)
        {
            string tdn = txtTDN.Text;
            string mk = txtMK.Text;
            if (string.IsNullOrEmpty(tdn) || string.IsNullOrEmpty(mk))
            {
                lbthongbao.Text = "Username and password are required!";
                return;
            }

            if (!IsValidUsername(tdn))
            {
                lbthongbao.Text = "Invalid username!";
                return;
            }
            else
            {
                lbtbNhapTDN.Text = "";
                lbtbMK.Text = "";
                string sql = "SELECT * FROM TAIKHOAN WHERE TENDANGNHAP = '" + tdn + "' AND MATKHAU = '" + mk + "'";
                DataTable dt = connect.GetData(sql);
                if (dt.Rows.Count > 0)
                {
                    Session["tdn"] = tdn;
                    Server.Transfer("~/HomePage.aspx");
                }
                else
                {
                    lbthongbao.Text = "Username or password is incorrect!";
                }
            }
        }
        protected void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/ForgotPassword/ForgotPassword.aspx");
        }
        private bool IsValidUsername(string username)
        {
            return !Regex.IsMatch(username, "[^a-zA-Z0-9]");
        }
    }
}