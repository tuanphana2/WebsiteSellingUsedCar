<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GroupProject_KT.Functions.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Contact Seller</h2>
        <p>Please use the form below to contact the seller of the vehicle:</p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
        <asp:TextBox ID="txtName" runat="server" placeholder="Your Name" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter your name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Your Email" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter your email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" placeholder="Your Message" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage" ErrorMessage="Please enter your message" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSend_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
