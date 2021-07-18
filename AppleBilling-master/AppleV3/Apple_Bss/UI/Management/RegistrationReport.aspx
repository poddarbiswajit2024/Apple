<%@ Page Language="C#" MasterPageFile="~/UI/Management/Management.Master" AutoEventWireup="true" CodeBehind="RegistrationReport.aspx.cs" Inherits="Apple_Bss.UI.Management.RegistrationReport" Title="Sales Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
             <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
                    <tr>
                        <td valign="top" class="tdtitle">
                            Marketing and Sales Report
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
                                        Select Registration Report Type
                                     </td>
                                    <td class="tdStyle" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                        <td width="40%">
                                        
                                            <asp:RadioButtonList ID="_rbtnRegReport" runat="server" 
                                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                                onselectedindexchanged="_rbtnRegReport_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="ALL">All Registration</asp:ListItem>
                                                <asp:ListItem Value="DTR">By Date Range</asp:ListItem>
                                                <asp:ListItem Value="MTH">By Month</asp:ListItem>
                                            </asp:RadioButtonList>
                                        
                                        </td>
                                            <td width="20%" >
                                                <asp:ImageButton ID="_imgBtnView" runat="server" 
                                                    ImageUrl="~/Images/Buttons/View.jpg" onclick="_imgBtnView_Click" />
                                            </td>
                                            <td  width="40%">
                                                &nbsp;</td>
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
                                                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  CssClass="ajax__calendar"
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
                                    <td class="tdgap" style=" vertical-align:top;" valign="top"  colspan="2">
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
                                       &nbsp;&nbsp;Report Summary
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        <asp:Label ID="_lblMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">
                                   
                                        <asp:GridView ID="_gvReportByMonth" runat="server" AutoGenerateColumns="False" 
                                            CssClass="gridStyle" GridLines="Horizontal" Width="40%" AllowPaging="True" 
                                            onpageindexchanging="_gvReportByMonth_PageIndexChanging" PageSize="6">
                                            <RowStyle CssClass="gridRowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="MONTH" HeaderText="Month">
                                                    <HeaderStyle Width="50%"  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                                </asp:BoundField>
                                                                                                                                              
                                                <asp:TemplateField HeaderText="Registrations">
                                                <ItemTemplate>
                                               <a href="javascript:PopupCenter('MonthRegDisplay.aspx?cid=<%# Eval("BILLCYCLEID").ToString()%>','myPop1',600,500);">
                                               <%#Eval("REGISTRATIONS").ToString()%></a>
                                                </ItemTemplate>
                                                  <HeaderStyle Width="50%"  CssClass="gridRightPad" HorizontalAlign="Right"/>
                                                 <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right"/>
                                                   
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="gridPagerStyletd" />
                                            <HeaderStyle CssClass="gridHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">
                                        &nbsp;</td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                </table>
    
    </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
