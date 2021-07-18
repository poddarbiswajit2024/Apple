<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="OnlinePaymentsList.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.OnlinePaymentsList"
    Title="Online Payments List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
 <script>
     $(function () {

         var currentTime = new Date()
         var minDate = new Date(currentTime.getFullYear(), currentTime.getMonth(), +1); //one day next before month
         var maxDate = new Date(currentTime.getFullYear(), currentTime.getMonth() + 1, 0);
         $("#ctl00_ContentPlaceHolder1_tbDate1").datepicker({
             minDate: minDate,
             maxDate: maxDate,
             dateFormat: 'yy-mm-dd'
         });

         $("#ctl00_ContentPlaceHolder1_tbDate2").datepicker({
             minDate: minDate,
             maxDate: maxDate,
             dateFormat: 'yy-mm-dd'
         });
     });



  </script>

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Online Payments List
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="auto-style3">
                                    Payment Status</td>
                                <td class="tdStyle2" colspan="2">
                                   <asp:CheckBoxList ID="chkBoxListPaymentStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
        <asp:ListItem Selected="True">INITIATED</asp:ListItem>
        <asp:ListItem Selected="True">SUCCESSFUL</asp:ListItem>
      <asp:ListItem Selected="True">CAPTURED</asp:ListItem>
        <asp:ListItem Selected="True">FAILURE</asp:ListItem>
           <asp:ListItem Selected="False">REFUNDED</asp:ListItem>
    </asp:CheckBoxList>
                                    <asp:CheckBox ID="chkboxVerifiedStatus"  Text="Include Verified Payment Status" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    Payment Date Between</td>
                                <td class="tdStyle2">
                                
                              <asp:TextBox ID="tbDate1"  CssClass="TextBoxBorder" runat="server"></asp:TextBox>                                
                                    <asp:TextBox ID="tbDate2" CssClass="TextBoxBorder" runat="server"></asp:TextBox>                               
                               
                                </td>
                                <td class="tdStyle">
                                   
                                    &nbsp;</td>
                            </tr>
                    
                                <tr>
                                    <td class="auto-style3">&nbsp;</td>
                                    <td class="tdStyle2">
                                        <asp:ImageButton ID="btnViewPayments" runat="server" ImageUrl="~/Images/Buttons/View.jpg" OnClick="btnViewPayments_Click" />
                                    </td>
                                    <td class="tdStyle">&nbsp;</td>
                            </tr>
                    
                                <tr>
                    <td class="auto-style4">
                    </td>
                </tr>
                            <tr>
                                <td class="auto-style3">Search by Userid</td>
                                <td class="tdStyle2">
                                    <asp:DropDownList ID="ddlAccountPrefix"  runat="server">
        <asp:ListItem>DMP-SCLX</asp:ListItem>
        <asp:ListItem>KOH-SCLX</asp:ListItem>
         <asp:ListItem>MKG-SCLX</asp:ListItem>
          </asp:DropDownList>  <asp:TextBox ID="tbUserid" CssClass="TextBoxBorder"  runat="server"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style5"></td>
                                <td class="auto-style1">
                                    <asp:ImageButton ID="btnUserID" runat="server" ImageUrl="~/Images/Buttons/search.jpg" OnClick="btnUserID_Click" />
                                </td>
                                <td class="auto-style2"></td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    &nbsp;
                                </td>
                                <td class="tdStyle2" colspan="2" align="center">
                           <%--         <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            Loading... Please Wait
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdgap">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <%--<tr>
                                       <td class="tdStyle2" style="padding-left: 10px; vertical-align:text-bottom; width:250px;"  >
                                   <b>Update Payment Status&nbsp;</b>
                                    <asp:DropDownList ID="ddlUpdatePaymentStatus" CssClass="TextBoxBorder" runat="server">
                                         <asp:ListItem Value=""> -- select --</asp:ListItem>
                                        <asp:ListItem>Bounced</asp:ListItem>                                     
                                        <asp:ListItem Value="Failure">Failed</asp:ListItem>
                                    </asp:DropDownList>
                                      </td>
                                    <td class="tdStyle">
                                    <asp:ImageButton ID="btnUpdatePaymentStatus" ValidationGroup="paymentStatus" runat="server" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnUpdatePaymentStatus_Click"  />

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUpdatePaymentStatus" ErrorMessage="Payment status required" ValidationGroup="paymentStatus"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="tdStyle" colspan="2" style="padding-left: 0px; vertical-align:text-bottom">
                                   

                                    <asp:GridView ID="gvOnlinepaymentsList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="TRANSACTIONID" 
                                        PageSize="10" ShowFooter="True"
                                        Width="100%" EmptyDataText="No record Exist " GridLines="None" CssClass="gridStyle" OnRowCommand="gvOnlinepaymentsList_RowCommand" OnRowDataBound="gvOnlinepaymentsList_RowDataBound">
                                        <Columns>
                                 <%--           <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                                   <HeaderStyle  HorizontalAlign="Center" />         
                                              
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>--%>


                                                          <asp:TemplateField HeaderText="Userid"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
              
                             <asp:Label ID="lblAccountNumber" runat="server"  Text='<%# Eval("AccountNumber") %>'></asp:Label>
                                  <asp:HiddenField ID="hdnAmount" runat="server" Value='<%# Eval("amount") %>'/>
                </ItemTemplate>
                                                                <HeaderStyle CssClass="gridLeftPad"   />         
                             <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" />                  
            </asp:TemplateField>

             


                                       
            <asp:BoundField DataField="amount" HeaderStyle-Font-Bold="true" HeaderText="Amount(Rs.)" SortExpression="amount" DataFormatString="{0:N2}" />



                                                      <asp:TemplateField HeaderText="Full Name<br/>Username"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server"  Text='<%# Eval("FirstName") + " " + Eval("LastName")%>'></asp:Label>
                    <br />
                    <%# Eval("Username") %>                    
                </ItemTemplate>
                 
            </asp:TemplateField>

               <asp:TemplateField HeaderText="Payment Status<br/>Transaction ID"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
               
                       <asp:Label ID="lblPaymentStatus" runat="server"  Text='<%# Eval("PaymentStatus") %> '></asp:Label>
                    <br />
                             <asp:Label ID="lblTransactionID" runat="server"  Text='<%# Eval("TransactionID") %>'></asp:Label>
                                  
                </ItemTemplate>
            </asp:TemplateField>

     

                  <asp:TemplateField HeaderText="EmailID<br/>PhoneNumber"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
                 
                         <asp:Label ID="lblEmailID" runat="server"  Text='<%# Eval("EmailID") %> '></asp:Label>
                     <br />
                 
                         <asp:Label ID="lblPhoneNumber" runat="server"  Text='<%# Eval("PhoneNumber") %> '></asp:Label>              
                </ItemTemplate>                 
            </asp:TemplateField>

               <asp:TemplateField HeaderText="Submitted & <br/>Updated Time"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
                 Submitted Time:   
                         <asp:Label ID="lblPaymentSubmittedTime" runat="server"  Text='<%# Eval("SubmittedTimestamp") %> '></asp:Label>
                     <br />
                  Updated Time:   <%# Eval("UpdatedTimeStamp") %>                  
                </ItemTemplate>   
                   <ItemStyle Width="220px" />              
            </asp:TemplateField>

                                                   <asp:TemplateField HeaderText="Action"  HeaderStyle-Font-Bold="true">
                <ItemTemplate>
                    <asp:LinkButton ID="linkbtnAcceptPayment" CommandName="Received" runat="server">Mark as Received</asp:LinkButton>    
                       &nbsp;&nbsp; &nbsp; &nbsp; 
                       <asp:LinkButton ID="linkbtnPaymentFailed" CommandName="Failed" runat="server">Payment Failed</asp:LinkButton>             
                </ItemTemplate>   
                   <ItemStyle Width="220px" HorizontalAlign="Center"/>   
                                                       <HeaderStyle HorizontalAlign="Center" />           
            </asp:TemplateField>
                                         

                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeader" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                           <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                    </asp:GridView>
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
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="headerContentPlaceHolder">
    
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            vertical-align: bottom;
            padding-left: 8px;
            color: #444444;
            font: normal normal normal 9pt arial;
            height: 27px;
        }
        .auto-style2 {
            text-align: left;
            vertical-align: middle;
            padding-left: 10px;
            line-height: 2.3;
            color: #444444;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 9pt;
            font-family: arial;
            height: 27px;
        }
        .auto-style3 {
            text-align: left;
            vertical-align: bottom;
            padding-left: 8px;
            color: #444444;
            font: normal normal normal 9pt arial;
            width: 184px;
        }
        .auto-style4 {
            height: 15px;
            width: 184px;
        }
        .auto-style5 {
            text-align: left;
            vertical-align: bottom;
            padding-left: 8px;
            color: #444444;
            font: normal normal normal 9pt arial;
            height: 27px;
            width: 184px;
        }
    </style>
    
</asp:Content>

