using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Asn1.X500;

namespace GroupProject_KT.Functions
{
    public partial class Profile : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Session["tdn"] as string;
                if (!string.IsNullOrEmpty(username))
                {
                    LoadUserProfile(username);
                }
                else
                {
                    Response.Redirect("~/Functions/Login.aspx");
                }
            }
        }

        private void LoadUserProfile(string username)
        {
            string sql = "SELECT * FROM KHACHHANG WHERE TENDANGNHAP = @Username";
            DataTable dt = connect.GetData(sql.Replace("@Username", "'" + username + "'"));

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblUsername.Text = row["TENDANGNHAP"].ToString();
                lblFullName.Text = row["TENKHACHHANG"].ToString();
                lblAge.Text = row["TUOI"].ToString();
                lblGender.Text = row["GIOITINH"].ToString();
                lblPhone.Text = row["SDT"].ToString();
                lblAddress.Text = row["DIACHI"].ToString();
                lblIDNumber.Text = row["CCCD"].ToString();
                lblEmail.Text = row["EMAIL"].ToString();
            }
            else
            {
                lblMessage.Text = "User not found!";
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/EditProfile.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/ChangePassword.aspx");
        }
    }
}