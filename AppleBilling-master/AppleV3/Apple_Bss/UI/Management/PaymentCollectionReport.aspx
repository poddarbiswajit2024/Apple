<%@ Page Language="C#" MasterPageFile="~/UI/Management/Management.Master" AutoEventWireup="true" CodeBehind="PaymentCollectionReport.aspx.cs" Inherits="Apple_Bss.UI.Management.PaymentCollectionReport" Title="Collection Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
             <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
                    <tr>
                        <td valign="top" class="tdtitle">
                            Payment Collection Report
                        </td>
                    </tr>
                    <tr>
                        <td class="mainTD">
                            <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                                <tr class="tdgap">
                                    <td class="tdgap" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" width="20%" valign="top" style=" vertical-align:top; padding-top:10px">
                                        Select Payment Collection Report
                                     </td>
                                    <td class="tdStyle" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                        <td width="30%">
                                        
                                            <asp:RadioButtonList ID="_rbtnPaymentColln" runat="server" 
                                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                                onselectedindexchanged="_rbtnPaymentColln_SelectedIndexChanged">                                               
                                                <asp:ListItem Value="DTR">By Date Range</asp:ListItem>
                                                <asp:ListItem Value="MTH">By Month</asp:ListItem>
                                            </asp:RadioButtonList>
                                        
                                        </td>
                                            <td width="20%">
                                                <asp:ImageButton ID="_imgBtnView" runat="server" 
                                                    ImageUrl="~/Images/Buttons/View.jpg" onclick="_imgBtnView_Click" />
                                            </td>
                                            <td width="50%">
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <span style="color:Green; font-weight:bold">Loading... Please Wait...</span>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td width="40%" colspan="3" class="tdStyle">
                                                    <asp:Panel ID="_panelDateRange" runat="server" Width="100%">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                        
                                                            Start Date
                                                            <asp:TextBox ID="_txtStartDate" runat="server" CssClass="TextBoxBorder" 
                                                                Width="150px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  CssClass="ajax__calendar"
                                                                Format="dd-MMM-yyyy" PopupPosition="Right" TargetControlID="_txtStartDate">
                                                            </cc1:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="_txtStartDate" ErrorMessage="* Start Date"></asp:RequiredFieldValidator>
                                                        </td>
                                                         <td width="35%">
                                                             End Date&nbsp;
                                                             <asp:TextBox ID="_txtEndDate" runat="server" CssClass="TextBoxBorder" 
                                                                 Width="150px"></asp:TextBox>
                                                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                                 Format="dd-MMM-yyyy" TargetControlID="_txtEndDate">
                                                             </cc1:CalendarExtender>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                 ControlToValidate="_txtEndDate" ErrorMessage="* End Date"></asp:RequiredFieldValidator>
                                                          </td>
                                                          <td width="30%">
                                                          &nbsp;
                                                          </td>
                                                     </tr>
                                                    </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                     </td>
                                </tr>
                                <tr>
                                    <td class="tdgap" style=" vertical-align:top;" valign="top" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="mainTD">
                            <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td class="tdtitle">
                                       &nbsp;&nbsp;Collection Report Summary
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        <asp:Label ID="_lblMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">                                   
                                        <asp:GridView ID="_gvAmtByDateRange" runat="server" AutoGenerateColumns="False" 
                                            CssClass="gridStyle" GridLines="Horizontal" Width="40%" 
                                            EmptyDataText="No Data Exist!...">
                                            <RowStyle CssClass="gridRowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="NAME" HeaderText="Collector Name">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="50%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AMOUNT" HeaderText="Amount Collected (in Rs.)">
                                                    <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                    <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="50%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">
                                        <asp:GridView ID="_gvAmtByMonth" runat="server" AutoGenerateColumns="False" 
                                            CssClass="gridStyle" GridLines="Horizontal" Width="50%" AllowPaging="True" 
                                            onpageindexchanging="_gvAmtByMonth_PageIndexChanging" PageSize="6" 
                                            EmptyDataText="No Data Exist!...">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" 
                                                LastPageText="&amp;gt;&amp;gt;Last" Mode="NextPreviousFirstLast" 
                                                NextPageText="&amp;gt;Next" PreviousPageText="&amp;lt;Previous" />
                                                <PagerStyle CssClass="gridPagerStyletd" Height="30px" />
                                            <RowStyle CssClass="gridRowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="MONTH" HeaderText="Month">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="30%" />
                                                </asp:BoundField>
                                       
                                                <asp:BoundField DataField="AMOUNT" HeaderText="Amount Collected (in Rs.)">                                                
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                    <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="35%" />
                                                 </asp:BoundField>
                                                 <asp:TemplateField HeaderText="View Details">
                                                <ItemTemplate >
                                                   <a href="javascript:PopupCenter('AmountCollected.aspx?cid=<%# Eval("BILLCYCLEID").ToString()%>','myPop1',600,500);">
                                                       <asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/Buttons/View.png"/></a>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="gridRightPad" HorizontalAlign="Center" Width="35%" />
                                                </asp:TemplateField>                                              
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                </table>
    
    </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>