<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="GroupProject_KT.Functions.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr style="text-align: center; vertical-align: middle;">
                <td>
                    <div>
                        <asp:Label ID="lb_Notify" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <asp:DataList ID="dl_Detail" runat="server">
                    <ItemTemplate>
                        <td rowspan="4">
                            <asp:Image ID="Image1" Width="800px" runat="server" ImageUrl='<%# "/Images/"+Eval("HINH") %>' />
                        </td>
                        <td>
                            <h3>
                                <asp:Label ID="Label6" runat="server" Text="Car company: "></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TENHANG") %>'></asp:Label><br />
                                <br />
                                <asp:Label ID="Label7" runat="server" Text="Vehicle: "></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TENXE") %>'></asp:Label><br />
                                <br />
                                <asp:Label ID="Label8" runat="server" Text="Car color: "></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("MAU") %>'></asp:Label><br />
                                <br />
                                <asp:Label ID="Label9" runat="server" Text="Description: "></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("MOTA") %>'></asp:Label><br />
                                <br />
                                <asp:Label ID="Label10" runat="server" Text="Price: "></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("GIA") %>'></asp:Label><br />
                                <br />
                                <asp:Button ID="btn_Favorite" runat="server" Text="Add favorite" OnClick="btn_Favorite_Click" CommandArgument='<%# Eval("MAXE") %>' />
                                <asp:Button ID="Button1" runat="server" Text="Pre-book" OnClick="Button1_Click" CommandArgument='<%# Eval("MAXE") %>' />
                            </h3>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </tr>
        </table>
    </div>
</asp:Content>
