<%@ Page Title="Update Subscriber Details" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="UpdateSubscriberDetails.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.UpdateSubscriberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Update Subscriber Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="3" class="tdStyle">
                                   &nbsp; <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Load User</td>
                                <td width="20%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>
                                    -SCLX
                                    <asp:TextBox ID="_txtUserID" runat="server" CssClass="TextBoxBorder" 
                                        Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="uid"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnGetUserDetails" runat="server" 
                                        OnClick="_btnGetUserDetails_Click"  ImageUrl="~/Images/Buttons/Load User.jpg" 
                                        ValidationGroup="uid"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    User Name</td>
                                <td class="tdStyle" width="20%">
                                    <asp:TextBox ID="_txtUserName" runat="server" BackColor="#F2F2F2" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="150px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="_txtUserName" ErrorMessage="* Username cannot be blank"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtName" runat="server" Width="150px" BackColor="#F2F2F2"  CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtName"
                                        ErrorMessage="* Name Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Email ID
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtEmailID" runat="server" Width="200px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_txtEmailID"
                                        ErrorMessage="* Incorrect Email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Landline Number
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtLandlineNumber" runat="server" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_txtLandlineNumber"
                                        ErrorMessage="* Enter Numbers Only" ValidationExpression="^\d{0,10}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Mobile Number
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtMobileNumber" runat="server" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="_txtMobileNumber"
                                        ErrorMessage="* Enter 10 digit Numbers" ValidationExpression="^\d{0,10}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Customer GSTIN</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_txtCustomerGSTIN" runat="server" CssClass="TextBoxBorder" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Installation Address
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtInstAddress" runat="server" Height="60px" CssClass="TextBoxBorder"
                                        Width="300px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtInstAddress"
                                        ErrorMessage="*Installation Address  Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Correspondence Address
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtCorresAddress" runat="server" Height="60px" CssClass="TextBoxBorder"
                                        Width="300px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_txtCorresAddress" ErrorMessage="*Correspondence Address  Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:ImageButton ID="_btnUpdateUser" runat="server" OnClick="_btnUpdateUser_Click" ImageUrl="~/Images/Buttons/update.jpg" Enabled="False" />
                                    &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" OnClick="_btnRefresh_Click" />
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
