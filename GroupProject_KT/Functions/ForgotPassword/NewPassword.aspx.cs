using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace GroupProject_KT.Functions.ForgotPassword
{
    public partial class NewPassword : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tdn"] == null || Session["ResetCode"] == null)
            {
                Response.Redirect("~/Functions/ForgotPassword/EnterEmail.aspx");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = Session["tdn"] as string;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword == confirmPassword)
            {
                string updateSql = "UPDATE TAIKHOAN SET MATKHAU = '" + newPassword + "' WHERE TENDANGNHAP = '" + username + "'";
                int result = connect.ExecuteQuery(updateSql);

                if (result > 0)
                {
                    lblMessage.Text = "Password changed successfully!";
                }
                else
                {
                    lblMessage.Text = "Failed to change password.";
                }
            }
            else
            {
                lblMessage.Text = "Passwords do not match.";
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/ForgotPassword/EnterEmail.aspx");
        }
    }
}