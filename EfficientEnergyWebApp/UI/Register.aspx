<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EfficientEnergyWebApp.UI.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 783px">
        <tr>
            <td style="width: 467px">
                <asp:Label ID="IDC_lblUsername" runat="server" Text="Username" AssociatedControlID="IDC_txtUsername"></asp:Label>
            </td>
            <td style="width: 566px">
                <asp:TextBox ID="IDC_txtUsername" runat="server"></asp:TextBox>
            </td>
            <td style="width: 634px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDC_txtUsername" ErrorMessage="Required field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 467px; height: 23px">
                <asp:Label ID="IDC_lblPassword" runat="server" Text="Password" AssociatedControlID="IDC_txtPassword"></asp:Label>
            </td>
            <td style="width: 566px; height: 23px">
                <asp:TextBox ID="IDC_txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 634px; height: 23px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IDC_txtPassword" ErrorMessage="Required field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 467px">
                <asp:Label ID="IDC_lblConfirmPassword" runat="server" Text="Confirm Password" AssociatedControlID="IDC_txtConfirmPassword"></asp:Label>
            </td>
            <td style="width: 566px">
                <asp:TextBox ID="IDC_txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 634px">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="IDC_txtPassword" ControlToValidate="IDC_txtConfirmPassword" ErrorMessage="Passwords must match" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 467px">
                <asp:Label ID="IDC_lblEmployee" runat="server" Text="Employee" ForeColor="Black" AssociatedControlID="IDC_drpEmployee"></asp:Label>
            </td>
            <td style="width: 566px">
                <asp:DropDownList ID="IDC_drpEmployee" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 634px"></td>
        </tr>
        
        <tr>
            <td style="width: 467px"></td>
            <td style="width: 566px">
                <asp:Button ID="IDC_btnRegister" runat="server" OnClick="IDC_btnRegister_Click" Text="Register" />
            </td>
            <td style="width: 634px"></td>
        </tr>
                <tr>
            <td style="width: 467px"></td>
            <td style="width: 566px">
           
                <asp:Label ID="IDC_lblFeedback" runat="server" ForeColor="Red"></asp:Label>
           
            </td>
            <td style="width: 634px"></td>
        </tr>
    </table>
</asp:Content>
