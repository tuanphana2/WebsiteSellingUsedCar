using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupProject_KT.Functions
{
    public partial class UploadVehicle : System.Web.UI.Page
    {
        ClassConnectSQLSV connect = new ClassConnectSQLSV();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string carMake = txtCarMake.Text;
            string name = txtName.Text;
            string description = txtDescription.Text;
            string color = txtColor.Text;
            string priceText = txtPrice.Text;
            string vehicleCode = txtVehicleCode.Text;

            if (string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(description) || string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(vehicleCode))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (!float.TryParse(priceText, out float price))
            {
                lblMessage.Text = "Invalid price format.";
                return;
            }

            string checkMakeSql = $"SELECT MAHANG FROM HANGXE WHERE TENHANG = '{carMake}'";
            string makeId = connect.LayDuLieuChu(checkMakeSql);

            if (string.IsNullOrEmpty(makeId))
            {
                string insertMakeSql = $"INSERT INTO HANGXE (TENHANG) VALUES ('{carMake}')";
                int rowsAffecteds = connect.ExecuteQuery(insertMakeSql);

                if (rowsAffecteds > 0)
                {
                    makeId = connect.LayDuLieuChu(checkMakeSql);
                }
                else
                {
                    lblMessage.Text = "Failed to add car make.";
                    return;
                }
            }

            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.FileName);
                string fileExtension = Path.GetExtension(fuImage.FileName);
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" ||
                    fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif")
                {
                    string filePath = Server.MapPath("~E:/CMU-CS_447/Group 10/GroupProject_KT/GroupProject_KT/Images/") + fileName;
                    fuImage.SaveAs(filePath);

                    string insertSql = $"INSERT INTO LOAIXE (TENXE, MOTA, MAU, GIA, MAHANG, MAXE, HINH) " +
                        $"VALUES ('{name}', '{description}', '{color}', {price}, '{makeId}', '{vehicleCode}', '{filePath}')";
                    int rowsAffected = connect.ExecuteQuery(insertSql);

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Vehicle uploaded successfully.";
                    }
                    else
                    {
                        lblMessage.Text = "Failed to upload vehicle.";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid file format. Please upload an image file.";
                }
            }
            else
            {
                lblMessage.Text = "Please select a file to upload.";
            }
        }
    }
}