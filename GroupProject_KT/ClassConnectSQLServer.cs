using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Tls;

namespace GroupProject_KT
{
    public class ClassConnectSQLSV : System.Web.UI.Page
    {
        SqlConnection con;
        private void Connect()
        {
            string sqlcn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
            + Server.MapPath("/App_Data/Database1.mdf") + ";Integrated Security=True";
            con = new SqlConnection(sqlcn);
            con.Open();
        }
        private void DisConnect()
        {
            if (con != null && con.State == ConnectionState.Open)
                con.Close();
        }
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Connect();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return dt;
        }
        public int ExecuteQuery(string sql)
        {
            int ketqua = 0;
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, con);
                ketqua = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ketqua = 0;
                Console.WriteLine("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return ketqua;
        }
        public string LayDuLieuChu(string sql)
        {
            string ketqua = "";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, con);
                ketqua = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ketqua = "";
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return ketqua;
        }
        public float LayGia(string sql)
        {
            float ketqua = 0;
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, con);
                ketqua = Convert.ToSingle(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ketqua = 0;
                Console.WriteLine("Lỗi khi lấy giá trị: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return ketqua;
        }
    }
}
