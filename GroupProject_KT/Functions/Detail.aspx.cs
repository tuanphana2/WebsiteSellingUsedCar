using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class Detail : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lb_Notify.Text = "";
            }
            string maxe = Request.QueryString["maxe"] + "";
            if (maxe != "")
            {
                string sql = "select * from LOAIXE, HANGXE where LOAIXE.MAHANG=HANGXE.MAHANG and MAXE=" + maxe;
                dl_Detail.DataSource = connect.GetData(sql);
                dl_Detail.DataBind();
            }
            else
            {
                lb_Notify.Text = "This car doesn't exist!";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            Response.Redirect("~/Functions/BuyCar.aspx?maxe=" + maxe);
        }

        protected void btn_Favorite_Click(object sender, EventArgs e)
        {
            string tdn = Session["tdn"] + "";
            if (tdn == "")
            {
                lb_Notify.Text = "You must log in to add the car to favorite!";
            }
            string maxe = Request.QueryString["maxe"] + "";
            string sqlFavarite = "insert into YEUTHICH values('" + Session["tdn"] + "', '" + maxe + "')";
            int result = connect.ExecuteQuery(sqlFavarite);
            if (result == 0)
            {
                lb_Notify.ForeColor = System.Drawing.Color.Red;
                lb_Notify.Text = "Added to favorites unsuccessfully!";
            }
            else
            {
                lb_Notify.ForeColor = System.Drawing.Color.YellowGreen;
                lb_Notify.Text = "Added to favorites successfully!";
            }
        }
    }
}