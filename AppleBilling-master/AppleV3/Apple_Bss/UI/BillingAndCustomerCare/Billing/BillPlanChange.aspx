<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="BillPlanChange.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.BillPlanChange" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
 <script>
      $(function () {
       
          var currentTime = new Date()
          var minDate = new Date(currentTime.getFullYear(), currentTime.getMonth(), -30,0); //allowing previous month also
       var maxDate = new Date(currentTime.getFullYear(), currentTime.getMonth() +1, 0); 
          $("#ctl00_ContentPlaceHolder1_datepicker").datepicker({
              minDate: minDate,
              maxDate: maxDate,
              dateFormat: 'yy-mm-dd'
          });
        
      });
 
   
     
  </script>

   </asp:Content> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                       Billing : Change Bill Plan
                        Requests</td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellspacing="0" cellpadding="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdgap" style="padding-left: 0px" colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    &nbsp;Search Username</td>
                                <td class="tdStyle" width="20%">
                                    <asp:TextBox ID="_txtUserName" runat="server" CssClass="TextBoxBorder" 
                                        Width="150px"></asp:TextBox>
                                     
                                     <cc1:AutoCompleteExtender ID="_txtUserName_AutoCompleteExtender" runat="server" 
                                         DelimiterCharacters="" Enabled="True" ServicePath="~/CodeFile/ISubscribers.asmx" 
                                         ServiceMethod="GetSubscribers" CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        MinimumPrefixLength="2"
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20" CompletionInterval="500"
                                        TargetControlID="_txtUserName">
                                    </cc1:AutoCompleteExtender>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="_txtUserName" ErrorMessage="* required" 
                                     ValidationGroup="uname"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_imgBtnGetDetails" runat="server" 
                                    ValidationGroup="uname" onclick="_imgBtnGetDetails_Click" 
                                    ImageUrl="~/Images/Buttons/Get Details.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdView" colspan="3" 
                                    style="padding-left:200px; padding-right:300px; padding-bottom:10px; padding-top:10px; height: 35px;">                                  
                                    <asp:Literal ID="_ltrUserInfo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                      
                            
                        </table>
                    </td>                    
                </tr>
                <tr>
                <td class="tdStyle">
                    <asp:Label ID="_lblSuccess" Font-Size="Small" runat="server"></asp:Label>                   
                   
                    <br />
                   
                    <asp:Label ID="_lblArrear" Font-Size="Small"  runat="server"></asp:Label>                 

                    <asp:Label ID="_lblWaiver"  Font-Size="Small" runat="server"></asp:Label>
                 <asp:Label ID="_lblTotalArrear" Font-Size="Small" runat="server"></asp:Label>
                   <asp:Label ID="_lblTotalWaiver" Font-Size="Small" runat="server"></asp:Label>
                </td>                
                </tr>
                 <tr>
                 
                    
                  <td class="mainTD">
                    <asp:Panel ID="_panelEditBillPlan" runat="server">
                 <div class="tdSubtitle">Update Bill Plan&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    </div>
           <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td colspan="2" style="height: 10px" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                                                                                   
                            <table style="width: 100%" cellpadding="0" cellspacing="0">

                               <tr>
                                            <td class="tdStyle">
                                                Present 
                                                Bill Plan &nbsp;</td>
                                            <td class="tdStyle" colspan="2">
                                                <asp:Label ID="lblPresentBillPlan" Font-Bold="true" runat="server" ></asp:Label>&nbsp;</td>
                                        </tr>

                            

                                     <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Type of New Bill Plan
                                            </td>
                                            <td class="tdStyle">                                              
                                  
                                                &nbsp;
                             <asp:CheckBox ID="chkboxPlanNormal" AutoPostBack="true" Text="Normal Plan"   Enabled="false"
                                                      runat="server" oncheckedchanged="chkboxPlanNormal_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanNormal_MutuallyExclusiveCheckBoxExtender" 
                                                      runat="server" Enabled="True" Key="1" TargetControlID="chkboxPlanNormal">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                              <asp:CheckBox ID="chkboxPlanFairAccess" AutoPostBack="true" Text=" Fair Access Plan" 
                                                      runat="server" oncheckedchanged="chkboxPlanFairAccess_CheckedChanged"  Enabled="false"
                                                    Checked="True" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanFairAccess_MutuallyExclusiveCheckBoxExtender" 
                                                      runat="server" Enabled="false" Key="1" 
                                                      TargetControlID="chkboxPlanFairAccess">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                            </td>
                                        </tr>

                                         <tr>
                                         <td class="tdStyle">Select Security Deposit of User</td>
                                         <td class="tdStyle" style="text-align:left;">
                                             <asp:RadioButtonList  ID="rblSecurityDepositType" runat="server" RepeatDirection="Horizontal">
                                                      <asp:ListItem Value="0" Selected="True">No SD Change</asp:ListItem> 
                                                  <%-- <asp:ListItem Value="MR">Same as Monthly Rental</asp:ListItem>
                                                    <asp:ListItem Value="0">No Security Deposit</asp:ListItem>
                                                     <asp:ListItem Value="1500">1500 Security Deposit</asp:ListItem>--%>
                                            
                                                   
                                                </asp:RadioButtonList>
                                             </td>
                                                 <td class="tdStyle">
                                             <asp:RequiredFieldValidator ID="requiredSecurityDepositType" Display="Dynamic" ControlToValidate="rblSecurityDepositType" runat="server" ErrorMessage="Type of Security Deposit Required"></asp:RequiredFieldValidator>
                                         </td>
                                </tr>

                                        <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Select New Bill Plan</td>
                                            <td class="tdStyle" width="40%">
                                                <asp:DropDownList ID="_ddlNewBillPlans" runat="server" Height="29px" 
                                                    Width="600px" AppendDataBoundItems="false" >
                                                   <%--  <Items>
                                                          <asp:ListItem Text="Select New Bill Plan" Selected="False" />
                                                     </Items>--%>
                                                   
                                                 
                                                </asp:DropDownList>

                                            </td>
                                          <%--  <td class="tdStyle">
                                                <asp:RequiredFieldValidator ID="requiredSecurityDepositType0" runat="server" ControlToValidate="requiredSecurityDepositType" Display="Dynamic" ErrorMessage="Plan Name Required"></asp:RequiredFieldValidator>
                                            </td>--%>
                                        </tr>

                                              
                                        <tr>
                                            <td class="tdStyle">
                                               New Bill Cycle</td>
                                            <td class="tdStyle">
                                                <asp:RadioButtonList ID="_rbBILLCYCLE" runat="server" RepeatDirection="Horizontal" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="_rbBILLCYCLE_SelectedIndexChanged" >
                                                     <asp:ListItem Value="M">Monthly</asp:ListItem> 
                                                 <%--    <asp:ListItem Value="Q">Quarterly</asp:ListItem>
                                                     <asp:ListItem Value="H">Half Yearly</asp:ListItem>--%>
                                                     <asp:ListItem Value="A">Annually</asp:ListItem>
                                                </asp:RadioButtonList>
                                      
                                            </td>
                                            <td class="tdStyle">
                                                &nbsp;</td>
                                        </tr>
                                  
           
                                        <tr>                            
                                            <td class="tdStyle">Change w.e.f. date</td>
                                            <td class="tdStyle">
            
                                                 <input type="text" runat="server" id="datepicker"/>           
                     
                                                 <asp:CheckBox ID="chkBoxChangeNextBillCycle" AutoPostBack="true" runat="server" Text="Change from next billing" OnCheckedChanged="chkBoxChangeNextBillCycle_CheckedChanged" />
                                                                                    

                                            </td>

                                            <td class="tdStyle">&nbsp;</td>
                                          
                                </tr>

                                          
                    
                                  <tr>
                                            <td class="tdStyle">
                                                Next Bill Cycle</td>
                                            <td class="tdStyle">
                                           <%--     <asp:DropDownList ID="_ddlBillCycle" runat="server" Height="22px" Enabled="false" Width="200px">
                                                </asp:DropDownList>--%>
                                                <asp:Label ID="lblNextBillCycle" Font-Bold="true" runat="server" ></asp:Label>&nbsp;<asp:HiddenField ID="hdnFieldNextBillCycleStartDate" runat="server" />
                                            </td>
                                            </td>
                                            <td class="tdStyle">
                                                &nbsp;</td>
                                        </tr>
                                  
                            

                                        <tr>
                                            <td class="tdStyle">
                                                &nbsp;
                                             </td>
                                              <td class="tdStyle" colspan="2">
                                                <asp:ImageButton ID="_imgBtnUpdate" runat="server" 
                                                ImageUrl="~/Images/Buttons/update.jpg" onclick="_imgBtnUpdate_Click" 
                                                      onclientclick="Are you sure you wan to change this Bill Plan" />
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

                                                     <Triggers>
                                                         <asp:AsyncPostBackTrigger ControlID="_rbBILLCYCLE" />
                                                         <asp:AsyncPostBackTrigger ControlID="chkBoxChangeNextBillCycle" />
                                                         <asp:PostBackTrigger ControlID="_imgBtnUpdate" />
                                                         
                                                     </Triggers>
                                                 </asp:UpdatePanel>  
                  </asp:Panel> 
               </td> 

                             
                </tr>
                <tr>
                    <td class="mainTD">
                 <div class="tdSubtitle">View Bill Plan Change Requests&nbsp;&nbsp; &nbsp;
                 <img  src="../../../Images/Buttons/view.png" />
                     <asp:LinkButton ID="_lnkBtnShow" runat="server" 
                         onclick="_lnkBtnShow_Click" CausesValidation="False">Show All Users</asp:LinkButton>
                     &nbsp;&nbsp;&nbsp;
                     <asp:LinkButton ID="_lnkBtnHide" runat="server" onclick="_lnkBtnHide_Click">Hide All Users</asp:LinkButton>
                    </div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td colspan="2" style="height: 10px" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           
                            <asp:Panel ID="_panelGridView" runat="server">                            
                            
                            <table style="width: 99%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:GridView ID="_gvBillPlanChangeRequest" runat="server" 
                                                    AutoGenerateColumns="False" CssClass="gridStyle" GridLines="Horizontal" 
                                                    Width="100%" AllowPaging="True" 
                                                    onpageindexchanging="_gvBillPlanChangeRequest_PageIndexChanging">
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="Subscriber Name" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"  Width="13%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="USERNAME" HeaderText="User Name" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"  Width="9%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="OLDPACKAGENAME" HeaderText="Current Bill Plan" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="27%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NEWPACKAGENAME" HeaderText="New Bill plan" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="28%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BILLCYCLENAME" HeaderText="Bill Cycle" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="14%"/>
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="FROMDATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="With Effect From" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="23%"/>
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="gridHeader" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdgap">
                                                &nbsp;</td>
                                        </tr>
                            </table>
                           
                           </asp:Panel> 
                               
                        </td>
                    </tr>
                </table>
               </td>
                </tr>
            </table>

</asp:Content>