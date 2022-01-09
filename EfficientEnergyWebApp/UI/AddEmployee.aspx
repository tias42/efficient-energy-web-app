<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="EfficientEnergyWebApp.UI.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <thead>

        </thead>
        <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblFirstName" runat="server" Text="First Name" AssociatedControlID="IDC_txtFirstName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtFirstName" runat="server" Width="232px"></asp:TextBox>
            </td>
            <td style="width: 235px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDC_txtFirstName" ErrorMessage="Cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
                <tr>
            <td style="width: 197px; height: 28px;">
                <asp:Label ID="IDC_lblLastName" runat="server" Text="Last Name" AssociatedControlID="IDC_txtLastName"></asp:Label>
            </td>
            <td style="height: 28px">
                <asp:TextBox ID="IDC_txtLastName" runat="server" Width="233px"></asp:TextBox>
            </td>
            <td style="width: 235px; height: 28px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IDC_txtLastName" ErrorMessage="Cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblDateOfBirth" runat="server" Text="Date of Birth" AssociatedControlID="IDC_txtDateOfBirth"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtDateOfBirth" runat="server" TextMode="Date" Width="233px"></asp:TextBox>
            </td>
            <td style="width: 235px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="IDC_txtDateOfBirth" ErrorMessage="Cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblEmploymentType" runat="server" Text="Employment Type" AssociatedControlID="IDC_drpEmploymentType"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="IDC_drpEmploymentType" runat="server">
                    <asp:ListItem Selected="True" Value="full-time">Full-time</asp:ListItem>
                    <asp:ListItem Value="part-time">Part-time</asp:ListItem>
                    <asp:ListItem Value="casual">Casual</asp:ListItem>
                    <asp:ListItem Value="contract">Contract</asp:ListItem>
                    <asp:ListItem Value="volunteer">Volunteer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 235px"></td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblEmail" runat="server" Text="Email" AssociatedControlID="IDC_txtEmail"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtEmail" runat="server" Width="233px"></asp:TextBox>
            </td>
            <td style="width: 235px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="IDC_txtEmail" ErrorMessage="Not a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblMobile" runat="server" Text="Mobile" AssociatedControlID="IDC_txtMobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="IDC_txtMobile" runat="server" Width="233px"></asp:TextBox>
            </td>
            <td style="width: 235px"></td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblPhoto" runat="server" Text="Photo" AssociatedControlID="FileUpload1"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="229px" />
            </td>
            <td style="width: 235px"></td>
        </tr>
                <tr>
            <td style="width: 197px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Upload image" />
            </td>
            <td style="width: 235px"></td>
        </tr>
                <tr>
            <td style="width: 197px">
                <asp:Label ID="IDC_lblComments" runat="server" Text="Comments"></asp:Label>
            </td>
            <td>
                <textarea id="IDC_txtComments" name="S1" style="width: 235px; height: 90px"></textarea></td>
            <td style="width: 235px"></td>
        </tr>
                <tr>
            <td style="width: 197px">
                &nbsp;</td>
            <td>
                <asp:Button ID="IDC_btnSave" runat="server" Height="44px" OnClick="IDC_btnSave_Click" Text="Save" Width="122px" />
            </td>
            <td style="width: 235px">
                <asp:Label ID="IDC_lblTest" runat="server"></asp:Label>
                    </td>
        </tr>
    </table>
</asp:Content>
