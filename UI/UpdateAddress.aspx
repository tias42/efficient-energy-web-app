<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateAddress.aspx.cs" Inherits="EfficientEnergyWebApp.UI.UpdateAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAddressList" TypeName="EfficientEnergyWebApp.BLL.Address" UpdateMethod="UpdateAddress">
        <UpdateParameters>
            <asp:Parameter Name="addressID" Type="Int32" />
            <asp:Parameter Name="line1" Type="String" />
            <asp:Parameter Name="line2" Type="String" />
            <asp:Parameter Name="suburb" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="country" Type="String" />
            <asp:Parameter Name="postcode" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/UI/AddAddress.aspx">Add Address</asp:LinkButton>

</asp:Content>
