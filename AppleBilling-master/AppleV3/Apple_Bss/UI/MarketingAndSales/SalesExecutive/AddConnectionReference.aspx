<%@ Page Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesExecutive/SalesAgent.Master"
    AutoEventWireup="true" CodeBehind="AddConnectionReference.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesExecutive.AddConnectionReference"
    Title="Add Connection reference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" 
                align="center">
                <tr>
                    <td class="tdtitle">
                        Connection Reference
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellpadding="0" cellspacing="0" class="tableStyle" align="center" border="0">
                            <tr>
                                <td class="tdStyle" colspan="3">
                                    <asp:Label ID="_lblMessage" runat="server" Font-Bold="True"></asp:Label>
                                    <asp:Label ID="_lblFail" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" width="15%">
                                    &nbsp;</td>
                                <td class="tdgap" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Referred By
                                </td>
                                <td class="tdStyle" width="20%">
                                    <asp:DropDownList ID="_ddlUser" runat="server" CssClass="TextBoxBorder" 
                                        Height="22px" Width="185px">
                                    </asp:DropDownList>                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_ddlUser" ErrorMessage="*" ValidationGroup="GetUser"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnGetReferralName" runat="server" 
                                        ImageUrl="~/Images/Buttons/Go.jpg" OnClick="_btnGetReferralName_Click" 
                                        ValidationGroup="GetUser" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Referral Name
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbReferrerlName" runat="server" BackColor="#ECE9D8" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Referral Email
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbReferrerEmail" runat="server" BackColor="#ECE9D8" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Referral Mobile No.
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbReferrerMobileNumber" runat="server" BackColor="#ECE9D8" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Name
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbCustName" runat="server" Width="180px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbCustName"
                                        ErrorMessage="Name field cannot be left blank"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Contact No.
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbCustContactNumber" runat="server" Width="180px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_tbCustContactNumber"
                                        ErrorMessage="Enter Numbers Only" ValidationExpression="^\d{0,11}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Email ID
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_tbCustEmailID" runat="server" Width="180px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_tbCustEmailID"
                                        ErrorMessage="Email Format Error" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:ImageButton ID="_btnSubmit" runat="server" ImageUrl="~/Images/Buttons/Submit.jpg" OnClick="_btnSubmit_Click" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" ImageUrl="~/Images/Buttons/Refresh.jpg" OnClick="_btnRefresh_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="3">
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdgap">
                       
                    </td>
                </tr>
                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
