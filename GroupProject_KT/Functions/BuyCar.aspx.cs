using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class BuyCar : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sqlxe = "select * from LOAIXE";
                DropDownList1.DataSource = connect.GetData(sqlxe);
                DropDownList1.DataTextField = "TENXE";
                DropDownList1.DataValueField = "MAXE";
                DropDownList1.DataBind();
                string maxe = Request.QueryString["maxe"] + "";
                if (maxe != "")
                {
                    DropDownList1.SelectedIndex = Convert.ToInt32(maxe) - 1;
                    string sqlgia = "select GIA from LOAIXE where MAXE=" + maxe;
                    float gia = connect.LayGia(sqlgia);
                    lbtbGia.Text = gia + "";
                }
                string tdn = Session["tdn"] + "";
                if (tdn != "")
                {
                    lbTDN.Text = tdn;
                    string sqlten = "select TENKHACHHANG from KHACHHANG where TENDANGNHAP='" + tdn + "'";
                    lbTen.Text = connect.LayDuLieuChu(sqlten);
                    string sqlsdt = "select SDT from KHACHHANG where TENDANGNHAP='" + tdn + "'";
                    txtSDT.Text = connect.LayDuLieuChu(sqlsdt);
                }
                else
                {
                    lbtbten.Text = "You must log in to order a car!";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maxe = DropDownList1.SelectedValue;
            string sqlgia = "select GIA from LOAIXE where MAXE=" + maxe;
            float gia = connect.LayGia(sqlgia);
            lbtbGia.Text = gia + "";
        }
        protected void btDat_Click(object sender, EventArgs e)
        {
            if (lbTDN.Text != "")
            {
                if (DropDownList1.SelectedIndex >= 0)
                {
                    string maxe = DropDownList1.SelectedValue;
                    string sqlmaxe = "select MAXE from LOAIXE where MAXE=" + maxe;
                    float mx = connect.LayGia(sqlmaxe);
                    lbmaxe.Text = mx + "";
                    string sqlgia = "select GIA from LOAIXE where MAXE=" + maxe;
                    float gia = connect.LayGia(sqlgia);
                    lbtbGia.Text = gia + "";
                    string sql = "insert into DONHANG values('" + lbTDN.Text + "', " + lbmaxe.Text + ", " + lbtbGia.Text + ", '" + txtSDT.Text + "', GETDATE())";
                    int kq = connect.ExecuteQuery(sql);
                    if (kq > 0)
                        lbthongbao.Text = "Order successful!";
                    else
                        lbthongbao.Text = "You have already bought this car!";
                }
                else
                    lbthongbao.Text = "You have not selected the type of car you want to buy!";
            }
            else
                lbthongbao.Text = "You must login first!";
        }
    }
}