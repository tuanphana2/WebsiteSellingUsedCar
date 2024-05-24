using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions.ForgotPassword
{
    public partial class EnterEmail : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tdn"] == null)
            {
                Response.Redirect("~/Functions/ForgotPassword/ForgotPassword.aspx");
            }
        }

        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            string username = Session["tdn"] as string;
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                string sql = "SELECT EMAIL FROM KHACHHANG WHERE TENDANGNHAP = '" + username + "'";
                DataTable dt = connect.GetData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string storedEmail = dt.Rows[0]["EMAIL"].ToString();
                    if (storedEmail == email)
                    {
                        // Generate a random code
                        Random random = new Random();
                        string code = random.Next(100000, 999999).ToString();
                        Session["ResetCode"] = code;

                        // Send email
                        MailMessage mail = new MailMessage("your_email@example.com", email);
                        mail.Subject = "Password Reset Code";
                        mail.Body = "Your password reset code is " + code;

                        // Configure SMTP client
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential("autokt222@gmail.com", "@utokt123"),
                            EnableSsl = true
                        };

                        try
                        {
                            client.Send(mail);
                            lblMessage.Text = "Code sent to your email.";
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "Error sending email: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Email does not match.";
                    }
                }
                else
                {
                    lblMessage.Text = "User not found.";
                }
            }
            else
            {
                lblMessage.Text = "Please enter your email.";
            }
        }

        protected void btnVerifyCode_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            if (code == Session["ResetCode"].ToString())
            {
                Response.Redirect("~/Functions/ForgotPassword/NewPassword.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid code. Please try again.";
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Functions/ForgotPassword/ForgotPassword.aspx");
        }
    }
}