<%@ Page Title="" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="ExDataTransferPayment.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.ExDataTransferPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    c<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    Extra Data Transfer Payment Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table width="100%" class="tableStyle" cellspacing="0" cellpadding="0">
                            
                            <tr >
                                <td colspan="3" class="tdStyle">
                                    <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" 
                                        CssClass="lblSuccess"></asp:Label> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    User ID &nbsp;
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
                                  <asp:ImageButton ID="_btnGetUserDetails" ImageUrl="~/Images/Buttons/Get User Detail.jpg" runat="server" OnClick="_btnGetUserDetails_Click" ValidationGroup="UserID"/>
                                   
                                    </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    User Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtUserName" runat="server" Width="150px" ReadOnly="True"
                                        BackColor="#ECE9D8" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Customer Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtCustomerName" runat="server" Height="16px" Width="150px" BackColor="#ECE9D8"
                                        CssClass="TextBoxBorder" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Bill Cycle Details</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:Label ID="_lblBillCycleDetails" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Receipt Number
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtReceiptNumber" runat="server" CssClass="TextBoxBorder" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtReceiptNumber"
                                        ErrorMessage="* " ValidationGroup="rcpt"></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;</td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnDuplicateEntry" runat="server" 
                                        ImageUrl="~/Images/Buttons/Check Duplicate Entry.jpg" 
                                        onclick="_btnDuplicateEntry_Click" ValidationGroup="rcpt" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                        ControlToValidate="_txtReceiptNumber" 
                                        ErrorMessage="*Required field Cannot be left Blank" 
                                        ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                    <asp:Label ID="_lblExist" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td class="tdgap" colspan="3">
                                    &nbsp; </td>
                            </tr>
                      <tr>
                          <td class="tdStyle">
                              &nbsp;</td>
                          <td class="tdStyle" colspan="2" valign="top">
                                      
                   <asp:Panel ID ="_panelPaymentDetails" runat="server"> <!-- main Panel Starts here -->
                            
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle" colspan="3" >
                                   
                                   <table class="mainTD" width="90%" cellpadding="0" cellspacing="0" border="0">  <!-- main Table Starts here-->
                                   <tr >
                                   <td>
                                        
                                        <table class="tdStyle" width="98%" cellpadding="0" cellspacing="0" border="0"> <!-- Payment detail table begins -->
                                           <tr style="background-color: white">
                                               <td>
                                                   &nbsp; <b>Payment Details</b></td>
                                            </tr>
                                            <tr style="background-color: white">
                                               <td valign="top">
                                               <table cellpadding="0" cellspacing="0" border="0"> <!--payment Inner table begins -->
                                               <tr>
                                <td class="tdStyle" valign="top">
                                    Payment Details
                                </td>
                                <td class="tdStyle">
                                    <asp:RadioButtonList ID="_rbtnInstrument" runat="server" OnSelectedIndexChanged="_rbtnInstrument_SelectedIndexChanged"
                                        RepeatDirection="Horizontal" AutoPostBack="True">
                                        <asp:ListItem Value="CASH">Cash</asp:ListItem>
                                        <asp:ListItem Value="CHEQUE/DD">Cheque/DD</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_rbtnInstrument"
                                        ErrorMessage="* Select Payment Type" ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;
                                    <br />
                                    
                                    <asp:Panel ID="_panelChequeDetails" runat="server">
                                        <asp:Label ID="_lblChequeDetails" runat="server" Text="Cheque/DD Details:" Font-Bold="False"></asp:Label>
                                        <br/>
                                        <asp:TextBox ID="_txtChequeDetails" runat="server" Height="30px" Width="250px" 
                                            CssClass="TextBoxBorder"></asp:TextBox>
                                         &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_txtChequeDetails"
                                            ErrorMessage="* Enter Cheque Details" ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                            
                                    </asp:Panel>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle" style="height: 15px">
                                    Amount
                                </td>
                                <td style="height: 15px" class="tdStyle">
                                    <asp:TextBox ID="_txtAmount" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_txtAmount"
                                        ErrorMessage="* Enter Numbers Only" ValidationExpression="^\d{0,10}$" ValidationGroup="PostPayment"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_txtAmount"
                                        ErrorMessage="* Enter Amount" ValidationGroup="PostPayment" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Payment Date
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtPaymentDate" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <cc1:CalendarExtender ID="_txtPaymentDate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="_txtPaymentDate" PopupPosition="Right"  CssClass="ajax__calendar"
                                        DaysModeTitleFormat="MMMM,yyyy" Format="dd-MM-yyyy" TodaysDateFormat="">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtPaymentDate"
                                        ErrorMessage="* Select Payment Date" ValidationGroup="PostPayment"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                                   <tr>
                                                       <td class="tdStyle">
                                                           Collector</td>
                                                       <td class="tdStyle">
                                                           <asp:DropDownList ID="_ddlCollector" runat="server" Height="22px" Width="155px">
                                                           </asp:DropDownList>
                                                           &nbsp;<asp:CheckBox ID="_chkBoxSelf" runat="server" AutoPostBack="True" 
                                                               oncheckedchanged="_chkBoxSelf_CheckedChanged" Text="Self" />
                                                       </td>
                                                   </tr>
                            <tr>
                                <td class="tdStyle">
                                    Remarks
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtRemarks" runat="server" Height="60px" TextMode="MultiLine" 
                                        Width="300px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnPostPayment" runat="server" OnClick="_btnPostPayment_Click" ImageUrl="~/Images/Buttons/Post Payment.jpg" 
                                        ValidationGroup="PostPayment"/>
                                    &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" OnClick="_btnRefresh_Click" />
                                </td>
                            </tr>
                                               
                                               </table> <!-- Inner table ends-->
                                               
                                                      
                                               </td>
                                            </tr>
                                            <tr style="background-color: white">
                                               <td>
                                               &nbsp;                                               
                                               </td>
                                            </tr>
                                       
                                       </table> <!-- payment table ends-->
                                   
                                   </td>
                                   
                                   </tr>
                                   
                                   </table> <!-- Main Table ends-->
                                   
                                    
                                    
                                    </td>
                            </tr>
                            
                            </asp:Panel> <!--Main Panel Ends  -->
                                 </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="tdgap">
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
