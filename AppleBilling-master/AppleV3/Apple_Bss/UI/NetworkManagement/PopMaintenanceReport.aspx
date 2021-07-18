<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master" AutoEventWireup="false" CodeBehind="PopMaintenanceReport.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.PopMaintenanceReport" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td colspan="2" valign="top" class="tdtitle">
               POP Maintenance Report
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
                                       View POP Maintenance By
                                     </td>
                                    <td class="tdStyle" valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                        <td width="30%">
                                        
                                            <asp:RadioButtonList ID="_rbtnViewPopMaintenance" runat="server" 
                                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                                onselectedindexchanged="_rbtnViewPopMaintenance_SelectedIndexChanged">                                               
                                                <asp:ListItem Value="DTR">Date Range</asp:ListItem>
                                                <asp:ListItem Value="ALL">List All</asp:ListItem>
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
                                                                Format="dd-MMMM-yyyy" PopupPosition="Right" 
                                                                TargetControlID="_txtStartDate">
                                                            </cc1:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="_txtStartDate" ErrorMessage="* Start Date"></asp:RequiredFieldValidator>
                                                        </td>
                                                         <td width="35%">
                                                             End Date&nbsp;
                                                             <asp:TextBox ID="_txtEndDate" runat="server" CssClass="TextBoxBorder" 
                                                                 Width="150px"></asp:TextBox>
                                                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  CssClass="ajax__calendar"
                                                                 Format="dd-MMMM-yyyy" TargetControlID="_txtEndDate">
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
        
        <td class="mainTD">
                            <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td class="tdtitle">
                                        &nbsp;&nbsp;Maintenance Report Summary
                                        <asp:Label ID="_lblMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdgap">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">
                                                                         
                                        <asp:GridView ID="_gvMaintenance" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CssClass="gridStyle" GridLines="Horizontal" 
                                            PageSize="30" Width="100%" EmptyDataText="No Data Exist !...">
                                            <RowStyle Height="35px" />
                                            <Columns>
                                                <asp:BoundField DataField="POPNAME" HeaderText="POP Name">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DATEOFMAINTENANCE" 
                                                    DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Maintenance Date">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MANUALMETERCHARGE" HeaderText="Manual Meter Charge">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="BATTERYSTATUS" HeaderText="Battery Charging Status">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="INVERTERCHARGINGSTATUS" 
                                                    HeaderText="Inverter Charging Status">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="REPLACEMENT" HeaderText="Replacement">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="10%"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="REMARKS" HeaderText="Remarks">
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="15%"/>
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeader" />
                                        </asp:GridView>
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" style=" vertical-align:top;" valign="top">
                                        &nbsp;&nbsp;</td>
                                </tr>
                                </table>
                        </td>
        </tr>
    </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
