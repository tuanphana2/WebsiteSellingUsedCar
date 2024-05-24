using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class Favorite : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }
        protected void LoadData()
        {
            string sql = "select * from LOAIXE, YEUTHICH, HANGXE, KHACHHANG where LOAIXE.MAXE=YEUTHICH.MAXE AND LOAIXE.MAHANG = HANGXE.MAHANG AND KHACHHANG.TENDANGNHAP = YEUTHICH.TENDANGNHAP AND YEUTHICH.TENDANGNHAP='" + Session["tdn"].ToString() + "'";
            DataTable dt = connect.GetData(sql);
            int result = dt.Rows.Count;
            if (result > 1)
            {
                lbtb.Text = "You have " + result + " favorite's cars!";
            }
            else if (result == 1)
            {
                lbtb.Text = "You have " + result + " favorite's car!";
            }
            else
            {
                lbtb.Text = "You don't have a favorite car!";
            }
            dl_muaxe.DataSource = dt;
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

        protected void bt_Remove_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            string sqlRemove = "delete from YEUTHICH where MAXE = '" + maxe + "' AND TENDANGNHAP = '" + Session["tdn"] + "'";
            int result = connect.ExecuteQuery(sqlRemove);
            if (result > 0)
            {
                lbtb.Text = "Remove successful";
            }
            else
            {
                lbtb.Text = "Remove unsuccessful";
            }
        }
    }
}