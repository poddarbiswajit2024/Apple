<%@ Page Title="Registered Subscribers" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesExecutive/SalesAgent.Master"
    AutoEventWireup="true" CodeBehind="RegisteredConnections.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesExecutive.RegisteredConnections" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Registered Broadband Subscribers
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td colspan="3" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 12%" width="15%">
                            Select Status
                        </td>
                        <td width="25%" class="tdStyle">
                            <asp:RadioButtonList ID="_rbtnStatus" runat="server" RepeatDirection="Horizontal"
                               >
                                <asp:ListItem Value="ALL" Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="C">Connected</asp:ListItem>
                                <asp:ListItem Value="P">Pending</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="tdStyle" width="60%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Start Date
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtStartDate" runat="server" Width="150px" CssClass="TextBoxBorder" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                TargetControlID="_txtStartDate" Format="dd MMM yyyy">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtStartDate"
                                ErrorMessage="Select start date">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            End Date
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtEndDate" runat="server" Width="150px" CssClass="TextBoxBorder" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                TargetControlID="_txtEndDate" Format="dd MMM yyyy">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_txtEndDate"
                                ErrorMessage="Select end date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="tdgap">
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:ImageButton ID="_btnShowReport" runat="server" OnClick="_btnShowReport_Click" ImageUrl="~/Images/Buttons/Show Report.jpg" />
                        </td>
                    </tr>
                    <tr class="tdgap">
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                   
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:Label ID="lblReportMsg" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle" style="padding-left: 0">
                                                <asp:GridView ID="_gvActiveConnection" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="_gvActiveConnection_PageIndexChanging" PageSize="5" Width="100%"
                                                    GridLines="None" EmptyDataText="No record exist for the selected Item!" CssClass="gridStyle">
                                                    
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Subscriber Name" DataField="NAME">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Email ID" DataField="EMAILID">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Bill Plan" DataField="BILLPLAN">
                                                            <ItemStyle Width="45%" CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Mobile Number" DataField="MOBILENUMBER">
                                                            <ItemStyle HorizontalAlign="center" Width="15%" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>                                                        
                                                    </Columns>
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <PagerStyle CssClass="gridPagerStyle" />
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_btnShowReport" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
