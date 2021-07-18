<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="BillPaymentDarkFiber.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.BillPaymentDarkFiber"
    Title="Dark Fiber Bill Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">.
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate></ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Dark Fiber Bill Payment Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" align="left" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" class="tdStyle">
                                    &nbsp;<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Username</td>
                                <td width="20%" class="tdStyle">
                                    <asp:TextBox ID="_tbUsername"
                                        runat="server" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbUsername"
                                        ErrorMessage="*" ValidationGroup="UserID"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_tbUsername"
                                        ErrorMessage="*" ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:ImageButton ID="_btnGetUserDetails" ImageUrl="~/Images/Buttons/Get User Detail.jpg" runat="server" 
                                        OnClick="_btnGetUserDetails_Click" ValidationGroup="UserID" />
                                &nbsp;
                                        <asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" 
                                                                                    EnableViewState="False" ImageUrl="~/Images/Buttons/Refresh.jpg" 
                                                                                    OnClick="_btnRefresh_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left; padding-left: 10px;" align="left"  colspan="4">
                                 
                                   
                                    <fieldset id="fielsetClientDetails" runat="server" visible="false" style="width: 32%; text-align: right">
                                        <legend style='color: #3b5889'>Client Detials</legend>
                                        <table align="left" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdStyle" style="width:30%" >
                                                    AccountID
                                                </td>
                                                <td class="tdStyle">  
                                                    <asp:Label ID="lblAccountID"  runat="server"></asp:Label>
                                                </td>
                                        </tr>
                                             <tr>
                                <td class="tdStyle">
                                    Status
                                </td>
                                <td class="tdStyle">
                                      <asp:Label ID="lblStatus"  runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Name
                                </td>
                                <td class="tdStyle">
                                  <asp:Label ID="lblClientName"  runat="server"></asp:Label>  &nbsp;</td>
                            </tr>
                             <tr>
                                <td class="tdStyle">
                                    Mobile Number
                                </td>
                                <td class="tdStyle">
                                  <asp:Label ID="lblMobileNumber"  runat="server"></asp:Label>  &nbsp;</td>
                            </tr>
                       
                            
                                 </table>
                                    </fieldset>
                                    <caption>
                                        &nbsp;
                                    </caption>
                                </td>
                            </tr>
                       <tr id="trReceiptNumber" visible="false" runat="server" >
                                <td class="tdStyle" >
                                    Receipt Number&nbsp;
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
                               </td>
                               <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtReceiptNumber" ErrorMessage="* Receipt Number Required" 
                                        ValidationGroup="PostPayment" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:Label ID="_lblExist" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                           
                            
                            <tr> <!-- Panel TR Strrts Here -->
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle" colspan="2" valign="top">
                                 
                                   <asp:Panel ID="_panelPaymentDetails" Visible="false" runat="server">
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
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td class="tdStyle" valign="top" width="20%">
                                                                                Payment Details
                                                                            </td>
                                                                       
                                                                            <td class="tdStyle" valign="top" style="height:100px;">
                                                                            <asp:RadioButtonList ID="_rbtnInstrument" runat="server" AutoPostBack="True" 
                                                                                    OnSelectedIndexChanged="_rbtnInstrument_SelectedIndexChanged" 
                                                                                    RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="CA">Cash</asp:ListItem>
                                                                                    <asp:ListItem Value="CH">Cheque/DD</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                                    ControlToValidate="_rbtnInstrument" ErrorMessage="* Select Payment Type" 
                                                                                    ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                                                                  </td>
                                                                        
                                                                            <td class="tdStyle" valign="top" style="height:100px; padding-top:12px;">
                                                                                <asp:Panel ID="_panelChequeDetails" Visible="false" runat="server">
                                                                                    <asp:Label ID="_lblChequeDetails" runat="server" Font-Bold="False" 
                                                                                        Text="Cheque/DD No.& Bank:"></asp:Label> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                                        ControlToValidate="_txtChequeDetails" ErrorMessage="* Enter Cheque Details" 
                                                                                        ValidationGroup="PostPayment" Enabled="False"></asp:RequiredFieldValidator>
                                                                                    <br />
                                                                                    <asp:TextBox ID="_txtChequeDetails" runat="server" CssClass="TextBoxBorder" 
                                                                                        Height="30px" Width="250px"></asp:TextBox>
                                                                                    
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
                                                                                <cc1:FilteredTextBoxExtender ID="_txtAmount_FilteredTextBoxExtender" 
                                                                                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="_txtAmount">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
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
                                                                                    PopupPosition="Right" TargetControlID="_txtPaymentDate" CssClass="ajax__calendar"
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
