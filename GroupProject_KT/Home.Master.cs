using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tdn"] != null)
            {
                string username = Session["tdn"].ToString();
                LinkFavorite.Visible = true;
                LinkLogin.Visible = false;
                LinkRegister.Visible = false;
                LinkProfile.Visible = true;
                LinkLogout.Visible = true;
                LinkUploadVehicle.Visible = true;
                LinkProfile.Text = $"Profile ({username})";
                LinkProfile.PostBackUrl = "~/Functions/Profile.aspx?username=" + username;
            }
            else
                {
                LinkLogin.Visible = true;
                LinkRegister.Visible = true;
                LinkProfile.Visible = false;
                LinkLogout.Visible = false;
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/HomePage.aspx");
        }
        protected void LinkHomePage_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/HomePage.aspx");
        }
        protected void LinkVehicles_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/ManageVehicle.aspx");
        }

        protected void LinkBuyCar_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/BuyCar.aspx");
        }

        protected void LinkLogin_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/Login.aspx");
        }

        protected void LinkRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/Register.aspx");
        }
        protected void LinkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/HomePage.aspx");
        }

        protected void LinkFavorite_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/Favorite.aspx");
        }
        protected void LinkUploadVehicle_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Functions/UploadVehicle.aspx");
        }
    }
}