<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroupProject_KT.Functions.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">LOGIN</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtTDN" runat="server" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lbtbNhapTDN" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtMK" runat="server" TextMode="Password" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lbtbMK" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btDangNhap" runat="server" Text="Login" OnClick="btDangNhap_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="lnkForgotPassword" runat="server" Text="Forgot Password?" OnClick="lnkForgotPassword_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
