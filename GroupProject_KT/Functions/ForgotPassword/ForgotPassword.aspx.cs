using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions.ForgotPassword
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (!string.IsNullOrEmpty(username))
            {
                string sql = "SELECT * FROM KHACHHANG WHERE TENDANGNHAP = '" + username + "'";
                DataTable dt = connect.GetData(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["tdn"] = username;
                    Response.Redirect("~/Functions/ForgotPassword/EnterEmail.aspx");
                }
                else
                {
                    lblMessage.Text = "Username does not exist!";
                }
            }
            else
            {
                lblMessage.Text = "Please enter a username!";
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/Login.aspx");
        }
    }
}