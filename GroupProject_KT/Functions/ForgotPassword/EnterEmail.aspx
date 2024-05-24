<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EnterEmail.aspx.cs" Inherits="GroupProject_KT.Functions.ForgotPassword.EnterEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">Enter Email</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Enter your email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
                    <asp:Button ID="btnSendCode" runat="server" Text="Send Code" OnClick="btnSendCode_Click" />
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Enter the code sent to your email:</td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnVerifyCode" runat="server" Text="Verify Code" OnClick="btnVerifyCode_Click" />
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
