<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UploadVehicle.aspx.cs" Inherits="GroupProject_KT.Functions.UploadVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">Upload New Vehicle</h2>
        <table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <tr>
                <td>Make:</td>
                <td>
                    <asp:TextBox ID="txtCarMake" runat="server" placeholder="Car Make"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Vehicle Code:</td>
                <td>
                    <asp:TextBox ID="txtVehicleCode" runat="server" placeholder="Vehicle Code"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" placeholder="Name"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Description"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Color:</td>
                <td>
                    <asp:TextBox ID="txtColor" runat="server" placeholder="Color"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Image:</td>
                <td>
                    <asp:FileUpload ID="fuImage" runat="server" onchange="previewImage(this)" /></td>
                <td>
                    <img id="imgPreview" src="#" alt="Preview" style="display: none; max-width: 200px; max-height: 200px;" /></td>
            </tr>
            <tr>
                <td>Price:</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Price"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function previewImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    document.getElementById('imgPreview').src = e.target.result;
                    document.getElementById('imgPreview').style.display = 'block';
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
