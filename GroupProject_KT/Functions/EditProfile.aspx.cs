using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GroupProject_KT.Functions
{
    public partial class EditProfile : System.Web.UI.Page
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
                txtFullName.Text = row["TENKHACHHANG"].ToString();
                txtAge.Text = row["TUOI"].ToString();
                string gender = row["GIOITINH"].ToString();
                if (gender == "Male")
                    rblGender.SelectedValue = "Male";
                else if (gender == "Female")
                    rblGender.SelectedValue = "Female";
                else
                    rblGender.SelectedValue = "Other";
                txtAddress.Text = row["DIACHI"].ToString();
                txtPhone.Text = row["SDT"].ToString();
                txtIDNumber.Text = row["CCCD"].ToString();
                txtEmail.Text = row["EMAIL"].ToString();
            }
            else
            {
                lblMessage.Text = "User not found!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Session["tdn"] as string;
            if (!string.IsNullOrEmpty(username))
            {
                string fullName = txtFullName.Text.Trim();
                string age = txtAge.Text.Trim();
                string gender = rblGender.SelectedValue;
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string idNumber = txtIDNumber.Text.Trim();
                string email = txtEmail.Text.Trim();
                if (string.IsNullOrEmpty(fullName))
                {
                    lblMessage.Text = "You must enter full name!";
                    return;
                }

                if (string.IsNullOrEmpty(age))
                {
                    lblMessage.Text = "You must enter age!";
                    return;
                }

                if (!int.TryParse(age, out int parsedAge))
                {
                    lblMessage.Text = "Age must be a number!";
                    return;
                }

                if (!IsValidEmail(email))
                {
                    lblMessage.Text = "Invalid email address!";
                    return;
                }

                if (!IsValidPhoneNumber(phone))
                {
                    lblMessage.Text = "Invalid phone number!";
                    return;
                }

                if (!IsValidIDNumber(idNumber))
                {
                    lblMessage.Text = "Invalid ID number!";
                    return;
                }
                string sql = @"UPDATE KHACHHANG 
                               SET TENKHACHHANG = N'" + fullName + "', " +
                                             "TUOI = " + age + ", " +
                                             "GIOITINH = N'" + gender + "', " +
                                             "DIACHI = N'" + address + "', " +
                                             "SDT = '" + phone + "', " +
                                             "CCCD = '" + idNumber + "', " +
                                             "EMAIL = '" + email + "' " +
                             "WHERE TENDANGNHAP = '" + username + "'";

                int result = connect.ExecuteQuery(sql);
                if (result > 0)
                {
                    lblMessage.Text = "Update successfully!";
                }
                else
                {
                    lblMessage.Text = "Update failed!";
                }
            }
            else
            {
                Response.Redirect("~/Functions/Login.aspx");
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(?:\+?61|0)[2-478](?:[ -]?[0-9]){8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private bool IsValidIDNumber(string idNumber)
        {
            string pattern = @"^\d{9}$";
            return Regex.IsMatch(idNumber, pattern);
        }
        protected void bt_Return_click(object sender, EventArgs e)
        {

            Response.Redirect("~/Functions/Profile.aspx");
        }
    }
}