<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master" AutoEventWireup="true" CodeBehind="PaymentCycleChange.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.PaymentCycleChange" Title="Payment Cycle Change Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                       Billing : Change Payment Cycle Plan
                    </td>
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
                                <td class="tdView" colspan="3" style="padding-left:200px; padding-right:300px; padding-bottom:10px; padding-top:10px">                                  
                                    <asp:Literal ID="_ltrUserInfo" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            
                            
                        </table>
                    </td>                    
                </tr>
                <tr>
                <td class="tdStyle">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="_lblSuccess" runat="server"></asp:Label>
                    &nbsp;</td>                
                </tr>
                 <tr>
                  
                       
                     
                  <td class="mainTD">
                   <asp:Panel ID="_panelEditBillPlan" runat="server">
                 <div class="tdSubtitle">Update Payment Cycle Plan&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    </div>
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
                                                Present Payment Cycle &nbsp;</td>
                                            <td class="tdStyle" colspan="2">
                                                <asp:Label ID="lblPresentPaymentCylce" runat="server" ></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                New Payment Cycle
                                            </td>
                                            <td class="tdStyle" colspan="2">
                                                <asp:DropDownList ID="_ddlNewPaymentMode" runat="server" Height="22px" 
                                                    Width="200px" AutoPostBack="True" 
                                                    onselectedindexchanged="_ddlNewPaymentMode_SelectedIndexChanged" 
                                                    AppendDataBoundItems="True">
                                                     
                                                    <asp:ListItem Value="M">MONTHLY</asp:ListItem>
                                                    <asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                                    <asp:ListItem Value="H">HALF YEARLY</asp:ListItem>
                                                    <asp:ListItem Value="A">YEARLY</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                                </td>
                                        </tr>

                                          <tr>
                                            <td class="tdStyle">
                                                Change W.E.F Bill Cycle</td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlBillCycle" runat="server" Height="22px" Width="200px">
                                                </asp:DropDownList>
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
                                                       />
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
                </asp:Panel>  
               </td> 
                           
                </tr>
                <tr>
                    <td class="mainTD">
                 <div class="tdSubtitle">View Payment Plan Change Requests&nbsp;&nbsp; &nbsp;
                 <img  src="../../../Images/Buttons/view.png" />
                     <asp:LinkButton ID="_lnkBtnShow" runat="server" 
                         onclick="_lnkBtnShow_Click" CausesValidation="False">Show</asp:LinkButton>
                     &nbsp;&nbsp;&nbsp;
                     <asp:LinkButton ID="_lnkBtnHide" runat="server" onclick="_lnkBtnHide_Click">Hide </asp:LinkButton>
                    </div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td colspan="2" style="height: 10px" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           
                            <asp:Panel ID="_panelGridView" runat="server">                            
                            
                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:GridView ID="_gvBillPlanChangeRequest" runat="server" 
                                                    AutoGenerateColumns="False" CssClass="gridStyle" GridLines="Horizontal" 
                                                    Width="100%">
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="Subscriber Name" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"  Width="15%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="USERNAME" HeaderText="User Name" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"  Width="10%"/>
                                                        </asp:BoundField>
                                                      <%--  <asp:BoundField DataField="OLDPACKAGENAME" HeaderText="Current Bill Plan" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="30%"/>
                                                        </asp:BoundField>--%>
                                                       <asp:BoundField DataField="OLDPAYMENTMODE" HeaderText="Current Payment Cycle" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="PAYMENTMODE" HeaderText="New Payment Cycle" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BILLCYCLENAME" HeaderText="With Effect From" >
                                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="15%"/>
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
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>