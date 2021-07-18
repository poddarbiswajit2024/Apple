<%@ Page Language="C#" MasterPageFile="~/UI/Management/Management.Master" AutoEventWireup="true" CodeBehind="BillCollectionSummary.aspx.cs" Inherits="Apple_Bss.UI.Management.BillCollectionSummary" Title="Untitled Page" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td colspan="2" valign="top" class="tdtitle">
               Bill Collection Summary
               </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdgap"  colspan="3">
                           
                            &nbsp;
                         </td>
                    </tr>
                    
                    <tr>
                        <td class="tdStyle" width="20%">
                        Select Bill Cycle   
                        </td>
                        <td class="tdStyle"  width="20%">
                  
                
                            <asp:DropDownList ID="_ddlBillCycle" runat="server" Height="22px" Width="155px" 
                                AutoPostBack="True" onselectedindexchanged="_ddlBillCycle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="_ddlBillCycle" ErrorMessage="* "></asp:RequiredFieldValidator>
                           
                        </td>
                        <td class="tdStyle">
                           
                            <asp:ImageButton ID="_imgBtnView" runat="server" 
                                ImageUrl="~/Images/Buttons/View.jpg" onclick="_imgBtnView_Click" />
                        </td>
                         
                    </tr>
                   
                    <tr> 
                        <td class="tdgap"  colspan="3">
                           
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle"  colspan="2">
                           
                            <asp:Label ID="_lblMsg" runat="server"></asp:Label>
                        </td>
                        <td  class="tdStyle" style="text-align:right;padding-right:20px">
                        
                            <asp:Button ID="_btnExportExcel" runat="server" CausesValidation="False" 
                             Text="Export to Excel" Width="120px" onclick="_btnExportExcel_Click" />
                        
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap"  colspan="3">
                           
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="padding-right:10px" colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                           
                            <asp:GridView ID="_gvBillCollSummary" runat="server" 
                                AutoGenerateColumns="False" CssClass="gridStyle" Width="100%" 
                                GridLines="Horizontal" 
                                EmptyDataText="Record Empty for this selected Month  !!!">
                                <RowStyle Height="35px" />
                                <Columns>
                                    <asp:BoundField DataField="USERID" HeaderText="Account Number" >
                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad"/>
                                        <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad"  Width="20%"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="USERNAME" HeaderText="User Name" >
                                         <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad"/>
                                        <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="15%"/>
                                    </asp:BoundField>
                                    
                                     <asp:TemplateField HeaderText="Bill Number">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('../BillingAndCustomerCare/Billing/SubscriberBillDisplay.aspx?bnum=<%# Eval("BILLNUMBER").ToString()%>','myPop1',900,700);">
                                                        <%#Eval("BILLNUMBER").ToString()%></a>
                                                </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center"  CssClass="gridLeftPad"/>
                                        <ItemStyle HorizontalAlign="Center" CssClass="gridLeftPad" Width="15%"/>
                                     </asp:TemplateField>
                                                                                                           
                                    <asp:BoundField DataField="SERVICETAX" HeaderText="Service Tax" >
                                        <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="gridRightPad" Width="15%"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BILLEDAMOUNT" HeaderText="Billed Amount" >
                                       <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="gridRightPad" Width="15%"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PAYMENT" HeaderText="payment" >
                                         <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="gridRightPad" Width="20%"/>
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="gridHeader" />
                            </asp:GridView>
                           
                           </ContentTemplate>
                          </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap"  colspan="3">
                           
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
                  <Triggers>                   
                    <asp:PostBackTrigger ControlID="_btnExportExcel" />
                    </Triggers>
                 </asp:UpdatePanel>
 

</asp:Content>
