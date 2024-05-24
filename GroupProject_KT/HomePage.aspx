<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GroupProject_KT.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 style="display: flex; justify-content: center;">Home Page</h1>
        <h2 style="display: flex; justify-content: center;">Welcome to our auto store!</h2>
        <h3>Hot car</h3>
        <div style="display: flex; justify-content: center;">
            <asp:DataList ID="DataList2" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <table>
                        <tr style="width: 30%"></tr>
                        <tr>
                            <td style="width:200px">
                                <a href='<%# "~/Functions/Detail.aspx?Maxe=" + Eval("MAXE") %>'>
                                    <asp:Image ID="img_HC" runat="server" ImageUrl='<%# "Images/" + Eval("HINH") %>' Width="175px" Height="125px" />
                                </a>
                                <br />
                                <asp:Label ID="lbl_HCN" runat="server" Text='<%# Eval("TENXE") %>'></asp:Label><br />
                                <asp:Label ID="lbl_HCP" runat="server" Text='<%# Eval("GIA") + "$" %>'></asp:Label><br />
                                <asp:Button ID="btn_ViewHot" runat="server" Text="View detail" CommandName="ViewDetail" CommandArgument='<%# Eval("MAXE") %>' OnClick="btn_ViewHot_Click" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <h3>New Car</h3>
        <div style="display: flex; justify-content: center;">
            <br />
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width:200px">
                                <a href='<%# "~/Functions/Detail.aspx?Maxe=" + Eval("MAXE") %>'>
                                    <asp:Image ID="img_NC" runat="server" ImageUrl='<%# "Images/" + Eval("HINH") %>' Width="175px" Height="125px" />
                                </a>
                                <br />
                                <asp:Label ID="lbl_NCN" runat="server" Text='<%# Eval("TENXE") %>'></asp:Label><br />
                                <asp:Label ID="lbl_NCP" runat="server" Text='<%# Eval("GIA") + "$" %>'></asp:Label><br />
                                <asp:Button ID="btn_ViewNew" runat="server" Text="View Detail" CommandName="ViewDetail" CommandArgument='<%# Eval("MAXE") %>' OnClick="btn_ViewNew_Click" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
