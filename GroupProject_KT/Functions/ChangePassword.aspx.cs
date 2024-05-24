using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tdn"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void bt_ChangePassword_click(object sender, EventArgs e)
        {
            string username = Session["tdn"] as string;
            string oldPassword = txt_OPW.Text;
            string newPassword = txt_NPW.Text;
            lb_OPW.Text = "";
            lb_NPW.Text = "";
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                lb_OPW.Text = "Old password is required!";
                lb_NPW.Text = "New password is required!";
                return;
            }

            string sql = "SELECT MATKHAU FROM TAIKHOAN WHERE TENDANGNHAP = @Username";
            DataTable dt = connect.GetData(sql.Replace("@Username", "'" + username + "'"));

            if (dt != null && dt.Rows.Count > 0)
            {
                string currentPassword = dt.Rows[0]["MATKHAU"].ToString();

                if (currentPassword == oldPassword)
                {
                    string updateSql = "UPDATE TAIKHOAN SET MATKHAU = @NewPassword WHERE TENDANGNHAP = @Username";
                    int result = connect.ExecuteQuery(updateSql.Replace("@NewPassword", "'" + newPassword + "'").Replace("@Username", "'" + username + "'"));

                    if (result > 0)
                    {
                        lb_NPW.Text = "Password changed successfully!";
                    }
                    else
                    {
                        lb_NPW.Text = "Failed to change password!";
                    }
                }
                else
                {
                    lb_OPW.Text = "Old password is incorrect!";
                }
            }
            else
            {
                lb_OPW.Text = "User not found!";
            }
        }
        protected void bt_Return_click(object sender, EventArgs e)
        {

            Response.Redirect("~/Functions/Profile.aspx");
        }
    }
}