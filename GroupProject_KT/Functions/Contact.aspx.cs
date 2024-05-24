using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GroupProject_KT.SellerInfoRetriever;

namespace GroupProject_KT.Functions
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string message = txtMessage.Text;

            string maxe = "your_product_code";
            SellerInfoRetriever sellerInfoRetriever = new SellerInfoRetriever();
            SellerDetails sellerDetails = sellerInfoRetriever.GetSellerDetails(maxe);

            if (sellerDetails != null)
            {
                string sellerEmail = sellerDetails.SellerEmail;

                SendEmail(sellerEmail, name, email, message);

                lblMessage.Text = "Your message has been sent to the seller.";
            }
            else
            {
                lblMessage.Text = "Failed to retrieve seller information.";
            }
        }

        private void SendEmail(string toEmail, string name, string fromEmail, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Message from " + name;
                mailMessage.Body = message;

                SmtpClient smtpClient = new SmtpClient("your.smtp.server");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error sending email: " + ex.Message;
            }
        }

    }
}