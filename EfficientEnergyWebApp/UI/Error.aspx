<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EfficientEnergyWebApp.UI.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="Image1" runat="server" Height="340px" ImageUrl="~/Images/error.png" Width="593px" />
<br />
<asp:Label ID="Label1" runat="server" AssociatedControlID="Image1" Text="Error loading page"></asp:Label>
</asp:Content>
