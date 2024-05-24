<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="GroupProject_KT.Functions.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: black; padding: 20px;">
        <h2>Edit Profile</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <br />
        <table>
            <tr>
                <td>Full Name:</td>
                <td>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Age:</td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rblGender" runat="server" CssClass="textbox">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Identity Number:</td>
                <td>
                    <asp:TextBox ID="txtIDNumber" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="bt_Return" runat="server" Text="Return" OnClick="bt_Return_click" />
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
