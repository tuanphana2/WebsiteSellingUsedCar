<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BuyCar.aspx.cs" Inherits="GroupProject_KT.Functions.BuyCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <asp:Label ID="lbtbten" runat="server" Text=""></asp:Label>
                <td>Username:</td>
                <td>
                    <asp:Label ID="lbTDN" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbtbTDN" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Full name:</td>
                <td>
                    <asp:Label ID="lbTen" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Phone number:</td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Vehicle:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Price:</td>
                <td>
                    <asp:Label ID="lbtbGia" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbmaxe" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="">
                    <asp:Button ID="btDat" runat="server" Text="Order" OnClick="btDat_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
