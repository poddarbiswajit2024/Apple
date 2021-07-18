<%@ Page Title="Cycle Payment" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="OnlinePaymentCorrection.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.OnlinePaymentCorrection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Cycle Payment Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" align="left" cellpadding="0" cellspacing="0">
                            <tr >
                                <td colspan="3" class="tdStyle">
                                    &nbsp;<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    User ID 
                                </td>
                                <td width="20%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>-SCLX:<asp:TextBox ID="_txtUserID"
                                        runat="server" Width="86px" CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_txtUserID"
                                        ErrorMessage="*" ValidationGroup="UserID"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_txtUserID"
                                        ErrorMessage="*" ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnGetUserDetails" ImageUrl="~/Images/Buttons/Get User Detail.jpg" runat="server" 
                                        OnClick="_btnGetUserDetails_Click" ValidationGroup="UserID" />
                                   
                                    </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    User Name
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtUserName" runat="server" Width="150px" ReadOnly="True"
                                        BackColor="#ECE9D8" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Status
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtStatus" runat="server" BackColor="#ECE9D8" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtCustomerName" runat="server" Width="150px" BackColor="#ECE9D8"
                                        CssClass="TextBoxBorder" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Outstanding Amount
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtOutstandAmount" runat="server" BackColor="#ECE9D8" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" >
                                    Transaction ID
                                </td>
                                <td class="tdStyle">
                                 
                                    <asp:TextBox ID="_txtReceiptNumber" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_txtReceiptNumber"
                                        ErrorMessage="*" ValidationGroup="rcpt"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnDuplicateEntry" runat="server" 
                                        ImageUrl="~/Images/Buttons/Check Duplicate Entry.jpg" 
                                        OnClick="_btnDuplicateEntry_Click" ValidationGroup="rcpt" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtReceiptNumber" ErrorMessage="* Receipt Number Required" 
                                        ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                    <asp:Label ID="_lblExist" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr> <!-- Panel TR Strrts Here -->
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle" colspan="2" valign="top">
                                 
                                   <asp:Panel ID="_panelPaymentDetails" runat="server">
                                        <tr>
                                        <td class="tdStyle">
                                            &nbsp;</td>
                                        <td class="tdStyle" colspan="3">
                                            <table class="mainTD" width="90%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table class="tdStyle" width="98%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr style="background-color: white">
                                                                <td>
                                                                    &nbsp; <b>Payment Details</b></td>
                                                            </tr>
                                                            <tr style="background-color: white">
                                                                <td valign="top">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                  
                                                                        <tr>
                                                                            <td class="tdStyle" style="height: 15px">
                                                                                Amount
                                                                            </td>
                                                                            <td class="tdStyle" style="height: 15px" colspan="2">
                                                                                <asp:TextBox ID="_txtAmount" runat="server" CssClass="TextBoxBorder" 
                                                                                    Width="150px"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                                    ControlToValidate="_txtAmount" Display="Dynamic" 
                                                                                    ErrorMessage="* Enter Amount Value Only" ValidationExpression="^[1-9]\d*(\.\d+)?$" 
                                                                                    ValidationGroup="PostPayment"></asp:RegularExpressionValidator>
                                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                                    ControlToValidate="_txtAmount" Display="Dynamic" ErrorMessage="* Enter Amount" 
                                                                                    ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tdStyle">
                                                                                Payment Date
                                                                            </td>
                                                                            <td class="tdStyle" colspan="2">
                                                                                <asp:TextBox ID="_txtPaymentDate" runat="server" CssClass="TextBoxBorder" 
                                                                                    Width="150px"></asp:TextBox>
                                                                                <cc1:CalendarExtender ID="_txtPaymentDate_CalendarExtender" runat="server" 
                                                                                    DaysModeTitleFormat="MMMM,yyyy" Enabled="True" Format="dd-MM-yyyy" 
                                                                                    PopupPosition="Right" TargetControlID="_txtPaymentDate"  CssClass="ajax__calendar"
                                                                                    TodaysDateFormat="">
                                                                                </cc1:CalendarExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                                    ControlToValidate="_txtPaymentDate" ErrorMessage="* Select Payment Date" 
                                                                                    ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                     
                                                                        <tr>
                                                                            <td class="tdStyle">
                                                                                Remarks
                                                                            </td>
                                                                            <td class="tdStyle" colspan="2">
                                                                                <asp:TextBox ID="_txtRemarks" runat="server" CssClass="TextBoxBorder" 
                                                                                    Height="60px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tdgap">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="tdStyle" colspan="2">
                                                                                <asp:ImageButton ImageUrl="~/Images/Buttons/Post Payment.jpg" ID="_btnPostPayment" runat="server" OnClick="_btnPostPayment_Click" 
                                                                                     ValidationGroup="PostPayment" />
                                                                                &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" 
                                                                                    EnableViewState="False" ImageUrl="~/Images/Buttons/Refresh.jpg" 
                                                                                    OnClick="_btnRefresh_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="background-color: white">
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                       </tr>
                                    </asp:Panel>    
                                   
                                </td>
                            </tr> <!-- Panel TR EndsHere -->
                           
                            <tr>
                                <td colspan="3" style="line-height: 10px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
