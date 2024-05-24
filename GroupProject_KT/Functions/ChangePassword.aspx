<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="GroupProject_KT.Functions.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 style="display: flex; justify-content: center; align-items: center; min-height: 50px">REGISTER</h2>
        <table style="width: 100%;">
            <tr style="width: 100%">
                <td>Enter old password:</td>
                <td>
                    <asp:TextBox ID="txt_OPW" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:Label ID="lb_OPW" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Enter new password:</td>
                <td>
                    <asp:TextBox ID="txt_NPW" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:Label ID="lb_NPW" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>Confirm password:</td>
                <td>
                    <asp:TextBox ID="txt_NPW1" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ErrorMessage="Two password must be equal!"
                        ControlToValidate="txt_NPW1"
                        ControlToCompare="txt_NPW"
                        Display="Dynamic"
                        Operator="Equal"
                        Type="String">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="bt_Return" runat="server" Text="Return" OnClick="bt_Return_click" />
                </td>
                <td>
                    <asp:Button ID="bt_ChangePassword" runat="server" Text="Change password" OnClick="bt_ChangePassword_click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
