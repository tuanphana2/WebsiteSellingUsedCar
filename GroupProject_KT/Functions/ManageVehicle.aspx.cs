using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class ManageVehicle : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from LOAIXE, HANGXE where LOAIXE.MAHANG=HANGXE.MAHANG";
            dl_muaxe.DataSource = connect.GetData(sql);
            dl_muaxe.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            Response.Redirect("~/Functions/BuyCar.aspx?maxe=" + maxe);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            Response.Redirect("~/Functions/Detail.aspx?maxe=" + maxe);
        }
    }
}