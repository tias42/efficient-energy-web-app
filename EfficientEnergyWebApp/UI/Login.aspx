<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EfficientEnergyWebApp.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Username" AssociatedControlID="IDC_txtUsername"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtUsername" runat="server"></asp:TextBox>
            </td>
            <td style="width: 244px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDC_txtUsername" ErrorMessage="Required Field" ForeColor="#FF3300" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password" AssociatedControlID="IDC_txtPassword"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 244px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IDC_txtPassword" ErrorMessage="Required Field" ForeColor="#FF3300" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td></td>
            <td>
                <asp:Button ID="IDC_btnSubmit" runat="server" OnClick="IDC_btnSubmit_Click" Text="Submit" ValidationGroup="Group1" />
            </td>
            <td style="width: 244px">&nbsp;</td>
        </tr>
        
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/UI/Register.aspx">Register</asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="IDC_lblFeedback" runat="server" ForeColor="Red" AssociatedControlID="IDC_btnSubmit"></asp:Label>
            </td>
            <td style="width: 244px"></td>
        </tr>
    </table>
</asp:Content>
