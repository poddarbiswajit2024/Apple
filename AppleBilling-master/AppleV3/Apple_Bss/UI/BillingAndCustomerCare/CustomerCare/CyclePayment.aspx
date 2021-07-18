<%@ Page Title="Cycle Payment" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="CyclePayment.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.CyclePayment" %>

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
                                    Receipt Number
                                </td>
                                <td class="tdStyle">
                                 
                                    <asp:TextBox ID="_txtReceiptNumber" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_txtReceiptNumber"
                                        ErrorMessage="*" ValidationGroup="rcpt"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                   <%-- <asp:ImageButton ID="_btnDuplicateEntry" runat="server" 
                                        ImageUrl="~/Images/Buttons/Check Duplicate Entry.jpg" 
                                        OnClick="_btnDuplicateEntry_Click" ValidationGroup="rcpt" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtReceiptNumber" ErrorMessage="* Receipt Number Required" 
                                        ValidationGroup="PostPayment"></asp:RequiredFieldValidator>--%>
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
                                                                            <td class="tdStyle" valign="top" width="20%">
                                                                                Payment Details
                                                                            </td>
                                                                            <td class="tdStyle" colspan="2">
                                                                                <asp:RadioButtonList ID="_rbtnInstrument" runat="server" AutoPostBack="True" 
                                                                                    OnSelectedIndexChanged="_rbtnInstrument_SelectedIndexChanged" 
                                                                                    RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Selected="True" Value="CASH">Cash</asp:ListItem>
                                                                                    <asp:ListItem Value="CHEQUE/DD">Cheque/DD</asp:ListItem>
                                                                                    
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                                    ControlToValidate="_rbtnInstrument" ErrorMessage="* Select Payment Type" 
                                                                                    ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                                                                &nbsp;&nbsp;
                                                                                <br />
                                                                                <asp:Panel ID="_panelChequeDetails" runat="server">
                                                                                    <asp:Label ID="_lblChequeDetails" runat="server" Font-Bold="False" 
                                                                                        Text="Cheque/DD Details:"></asp:Label>
                                                                                    <br />
                                                                                    <asp:TextBox ID="_txtChequeDetails" runat="server" CssClass="TextBoxBorder" 
                                                                                        Height="30px" Width="250px"></asp:TextBox>
                                                                                    &nbsp;
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                                        ControlToValidate="_txtChequeDetails" ErrorMessage="* Enter Cheque Details" 
                                                                                        ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tdStyle" style="height: 15px">
                                                                                Amount
                                                                            </td>
                                                                            <td class="tdStyle" style="height: 15px" colspan="2">
                                                                                <asp:TextBox ID="_txtAmount" runat="server" CssClass="TextBoxBorder" 
                                                                                    Width="150px"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                                    ControlToValidate="_txtAmount" Display="Dynamic" 
                                                                                    ErrorMessage="* Enter Numbers Only" ValidationExpression="^\d{0,10}$" 
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
                                                                                Collector</td>
                                                                            <td class="tdStyle" width="25%">
                                                                                <asp:DropDownList ID="_ddlCollector" runat="server" Height="22px" Width="155px" 
                                                                                    AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td class="tdStyle">
                                                                                <asp:CheckBox ID="_chkBoxSelf" runat="server" Text="Self" AutoPostBack="True" 
                                                                                    oncheckedchanged="_chkBoxSelf_CheckedChanged" />
                                                                                &nbsp;</td>
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
