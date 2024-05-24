using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT
{
    public partial class HomePage : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var LinkLogin = Master.FindControl("LinkLogin") as LinkButton;
                var LinkRegister = Master.FindControl("LinkRegister") as LinkButton;
                var LinkProfile = Master.FindControl("LinkProfile") as LinkButton;
                var LinkLogout = Master.FindControl("LinkLogout") as LinkButton;
                if (LinkLogin != null && LinkProfile != null && LinkLogout != null)
                {
                    LinkLogin.Visible = false;
                    LinkRegister.Visible = false;
                    LinkProfile.Visible = true;
                    LinkLogout.Visible = true;
                }
                else
                {
                    LinkLogin.Visible = true;
                    LinkRegister.Visible = true;
                    LinkProfile.Visible = false;
                    LinkLogout.Visible = false;
                }
                LoadHotCar();
                LoadNewCar();
            }
        }
        private void LoadHotCar()
        {
            string sqlXeHot = "SELECT TOP 5 * FROM LOAIXE ORDER BY NEWID()";
            DataTable dtXeHot = connect.GetData(sqlXeHot);
            if (dtXeHot != null && dtXeHot.Rows.Count > 0)
            {
                DataList2.DataSource = dtXeHot;
                DataList2.DataBind();
            }
        }
        private void LoadNewCar()
        {
            string sqlXeMoi = "SELECT TOP 5 * FROM LOAIXE ORDER BY NEWID()";
            DataTable dtXeMoi = connect.GetData(sqlXeMoi);
            if (dtXeMoi != null && dtXeMoi.Rows.Count > 0)
            {
                DataList1.DataSource = dtXeMoi;
                DataList1.DataBind();
            }
        }
        protected void btn_ViewNew_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            Response.Redirect("~/Functions/Detail.aspx?maxe=" + maxe);
        }
        protected void btn_ViewHot_Click(object sender, EventArgs e)
        {
            string maxe = ((Button)sender).CommandArgument;
            Response.Redirect("~/Functions/Detail.aspx?maxe=" + maxe);
        }
    }
}