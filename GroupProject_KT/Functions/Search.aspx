<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="GroupProject_KT.Functions.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 20px;">
        <h2>Search for Vehicles</h2>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter search criteria"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br />
        <asp:RadioButtonList ID="rblSearchBy" runat="server">
            <asp:ListItem Text="Search by Make" Value="Make"></asp:ListItem>
            <asp:ListItem Text="Search by User" Value="User"></asp:ListItem>
            <asp:ListItem Text="Search by Price Range" Value="Price"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Panel ID="pnlPriceRange" runat="server" Visible="false">
            Min Price: <asp:TextBox ID="txtMinPrice" runat="server"></asp:TextBox>
            Max Price: <asp:TextBox ID="txtMaxPrice" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <div>
                    <h3><%# Eval("TENHANG") %></h3>
                    <p>NAME: <%# Eval("TENXE") %></p>
                    <p>Price: <%# Eval("GIA") %></p>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
