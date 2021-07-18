<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="PostWaivers.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.PostWaivers"
    Title="Post Waivers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    Post Waiver
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellpadding="0" cellspacing="0" class="tableStyle">
                            
                            <tr class="tdStyle">
                                <td colspan="3" class="tdStyle">
                                    &nbsp;<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    User Account Number</td>
                                <td width="20%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>
                                    -SCLX
                                    <asp:TextBox ID="_txtUserID" runat="server" Height="16px" Width="105px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="uid"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnLoadUserDetails" ImageUrl="~/Images/Buttons/Get Details.jpg" 
                                        runat="server"
                                        OnClick="_btnLoadUserDetails_Click" ValidationGroup="uid" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    User Name
                                </td>
                                <td class="tdStyle" width="15%">
                                    <asp:TextBox ID="_txtUserName" runat="server" BackColor="#F2F2F2" 
                                        CssClass="TextBoxBorder" Height="16px" ReadOnly="True" Width="175px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="_txtUserName" ErrorMessage="* Name Field Cannot be empty"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="tdStyle">
                                    Select Bill Cycle
                                </td>
                                <td class="tdStyle">
                                    <asp:DropDownList ID="_ddlBillCycles" runat="server" Height="22px" 
                                        Width="180px" CssClass="TextBoxBorder">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="tdStyle">
                                    Waiver Amount
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtAmount" runat="server" Width="175px" 
                                        CssClass="TextBoxBorder" Height="16px"></asp:TextBox>
                                    &nbsp;</td>
                                <td class="tdStyle">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="_txtAmount" ErrorMessage="Enter Numbers Only" 
                                        ValidationExpression="^\d{0,8}$"></asp:RegularExpressionValidator>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtAmount" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="tdStyle">
                                    Remarks
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtRemarks" runat="server" Height="60px" TextMode="MultiLine" 
                                        Width="300px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" class="tdgap">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:ImageButton ID="_btnPostWaiver" ImageUrl="~/Images/Buttons/Post Waivers.jpg" runat="server" OnClick="_btnPostWaiver_Click"  />
                                    &nbsp;
                                    <asp:ImageButton ID="_btnRefresh" ImageUrl="~/Images/Buttons/Refresh.jpg" 
                                        runat="server" OnClick="_btnRefresh_Click" CausesValidation="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" colspan="3">
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
