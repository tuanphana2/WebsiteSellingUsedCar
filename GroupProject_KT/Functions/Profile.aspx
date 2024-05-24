<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GroupProject_KT.Functions.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: black; padding: 20px;">
        <h2>Profile</h2>
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Full Name:</td>
                <td>
                    <asp:Label ID="lblFullName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Age:</td>
                <td>
                    <asp:Label ID="lblAge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Identity Number:</td>
                <td>
                    <asp:Label ID="lblIDNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
    </div>
</asp:Content>
