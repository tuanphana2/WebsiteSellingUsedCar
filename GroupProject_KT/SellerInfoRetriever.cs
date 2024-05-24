using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GroupProject_KT
{
    public class SellerInfoRetriever
    {
        private readonly ClassConnectSQLSV connect = new ClassConnectSQLSV();

        public class SellerDetails
        {
            public string SellerName { get; set; }
            public string SellerEmail { get; set; }

            public SellerDetails(string sellerName, string sellerEmail)
            {
                SellerName = sellerName;
                SellerEmail = sellerEmail;
            }
        }
        public SellerDetails GetSellerDetails(string maxe)
        {
            SellerDetails sellerDetails = null;

            string sql = @"
        SELECT KHACHHANG.TENKHACHHANG, KHACHHANG.EMAIL
        FROM LOAIXE
        INNER JOIN KHACHHANG ON LOAIXE.TENDANGNHAP = KHACHHANG.TENDANGNHAP
        WHERE LOAIXE.MAXE = @Maxe";

            DataTable dt = connect.GetData(sql.Replace("@Maxe", "'" + maxe + "'"));

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string sellerName = row["TENKHACHHANG"].ToString();
                string sellerEmail = row["EMAIL"].ToString();

                sellerDetails = new SellerDetails(sellerName, sellerEmail);
            }

            return sellerDetails;
        }
    }
}