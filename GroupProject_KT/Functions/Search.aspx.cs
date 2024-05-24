using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class Search : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Xây dựng câu truy vấn dựa trên lựa chọn của người dùng
            string sqlQuery = "";
            string searchTerm = "%" + txtSearch.Text + "%"; // Thêm dấu % cho phía trước và sau để tìm kiếm một phần của chuỗi

            switch (rblSearchBy.SelectedValue)
            {
                case "Make":
                    sqlQuery = "SELECT * FROM LOAIXE, HANGXE WHERE LOAIXE.TENHANG = HANGXE.TENHANG AND LOAIXE.TENHANG LIKE @searchTerm";
                    break;
                case "User":
                    sqlQuery = "SELECT * FROM LOAIXE WHERE TENDANGNHAP LIKE @searchTerm";
                    break;
                case "Price":
                    sqlQuery = "SELECT * FROM LOAIXE WHERE GIA BETWEEN @MinPrice AND @MaxPrice";
                    break;
            }

            // Thực hiện truy vấn và hiển thị kết quả trên DataList
            DataTable dt = connect.GetData(sqlQuery);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
    }
}