<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="EfficientEnergyWebApp.UI.AddAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblEmployeeName" runat="server" Text="Select Employee" AssociatedControlID="IDC_drpEmployeeName"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:DropDownList ID="IDC_drpEmployeeName" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 853px"></td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblAddress1" runat="server" Text="Address Line 1" AssociatedControlID="IDC_txtAddress1"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:TextBox ID="IDC_txtAddress1" runat="server"></asp:TextBox>
            </td>
            <td style="width: 853px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDC_txtAddress1" ErrorMessage="Required field" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblAddress2" runat="server" Text="Address Line 2" AssociatedControlID="IDC_txtAddress2"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:TextBox ID="IDC_txtAddress2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 853px"></td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblSuburb" runat="server" Text="Suburb/City" AssociatedControlID="IDC_txtSuburb"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:TextBox ID="IDC_txtSuburb" runat="server"></asp:TextBox>
            </td>
            <td style="width: 853px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IDC_txtSuburb" ErrorMessage="Required field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblState" runat="server" Text="State" AssociatedControlID="IDC_txtState"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:TextBox ID="IDC_txtState" runat="server"></asp:TextBox>
            </td>
            <td style="width: 853px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="IDC_txtState" ErrorMessage="Required field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblCountry" runat="server" Text="Country" AssociatedControlID="IDC_drpCountry"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:DropDownList ID="IDC_drpCountry" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 853px"></td>
        </tr>
        
        <tr>
            <td style="width: 450px">
                <asp:Label ID="IDC_lblPostcode" runat="server" Text="Post Code" AssociatedControlID="IDC_txtPostCode"></asp:Label>
            </td>
            <td style="width: 930px">
                <asp:TextBox ID="IDC_txtPostCode" runat="server"></asp:TextBox>
            </td>
            <td style="width: 853px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IDC_txtPostCode" ErrorMessage="Required field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="width: 450px; height: 32px"></td>
            <td style="width: 930px; height: 32px">
                <asp:Button ID="IDC_btnAdd" runat="server" OnClick="IDC_btnAdd_Click" Text="Add" Width="67px" />
            </td>
            <td style="width: 853px; height: 32px;"></td>
        </tr>
        
        <tr>
            <td style="width: 450px"></td>
            <td style="width: 930px">
                <asp:Label ID="IDC_lblFeedback" runat="server"></asp:Label>
            </td>
            <td style="width: 853px"></td>
            
        <tr>
            <td style="width: 450px"></td>
            <td style="width: 930px"></td>
            <td style="width: 853px"></td>

        </tr>
        </tr>
    </table>
</asp:Content>
