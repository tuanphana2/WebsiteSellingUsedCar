<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NewPassword.aspx.cs" Inherits="GroupProject_KT.Functions.ForgotPassword.NewPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">New Password</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Enter new password:</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Confirm new password:</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
