<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GroupProject_KT.Functions.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">Register</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtTDN" runat="server"></asp:TextBox>
                    <asp:Label ID="lbtbTDN" runat="server" Text="" ForeColor="Red"></asp:Label><br />
                    <asp:Label ID="lbtbNhapTDN" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtMK" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:Label ID="lbtbMK" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Confirm Password:</td>
                <td>
                    <asp:TextBox ID="txtMK1" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ErrorMessage="Two passwords must be equal!"
                        ControlToValidate="txtMK1"
                        ControlToCompare="txtMK"
                        Display="Dynamic"
                        Operator="Equal"
                        Type="String" ForeColor="Red">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Full name:</td>
                <td>
                    <asp:TextBox ID="txtTen" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lbtbNhapTen" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Age:</td>
                <td>
                    <asp:TextBox ID="txtTuoi" runat="server" TextMode="Number"></asp:TextBox></td>
                    <asp:Label ID="lbtbTuoi" runat="server" Text="" ForeColor="Red"></asp:Label>
            </tr>
            <tr style="width: 100%">
                <td>Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rblGT" runat="server" RepeatDirection="Horizontal" Style="margin-top: 0px">
                        <asp:ListItem Text="Male"></asp:ListItem>
                        <asp:ListItem Text="Female"></asp:ListItem>
                        <asp:ListItem Text="Other" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lbtbGT" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Address:</td>
                <td>
                    <asp:TextBox ID="txtDC" runat="server"></asp:TextBox>
                    <asp:Label ID="lbtbDC" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Phone number:</td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lbtbSDT" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Identify Code:</td>
                <td>
                    <asp:TextBox ID="txtCCCD" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lbtbNhapCCCD" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lbtbEmail" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td></td>
                <td>
                    <asp:Button ID="btDangKy" runat="server" Text="Đăng ký" OnClick="btDangKy_Click" />
                    <asp:Label ID="lbthongbao" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
