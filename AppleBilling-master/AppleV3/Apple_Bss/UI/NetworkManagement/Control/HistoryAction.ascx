<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryAction.ascx.cs"
    Inherits="Apple_Bss.UI.NetworkManagement.Control.HistoryAction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link rel="stylesheet" href="../../../CSS/InetBill.css" media="screen" type="text/css" />
<body>
    <table align="center" cellpadding="0" cellspacing="0" class="mainTable">
        <tr>
            <td class="mainTD">
                <table cellpadding="0" cellspacing="0" border="0" class="tableStyle" align="center">
                    <tr>
                        <td colspan="2" class="tdtitle">
                            Service Request Details
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            SR Number
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblSRN" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Status
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Issue Reported
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblIssueReported" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            First Attended By
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblIssueFirstAttendedBy" runat="server"></asp:Label>
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
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" class="tableStyle" align="center">
                            <tr>
                                <td colspan="3" class="tdtitle">
                                    Action History
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tdStyle">
                            <td style="width: 30%; vertical-align: top; padding-left: 10px">
                                <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"MODON")).ToString("f") %>
                            </td>
                            <td style="width: 50%; vertical-align: top">
                                <%# DataBinder.Eval(Container.DataItem,"ACTIONTAKEN") %>
                            </td>
                            <td style="width: 20%; vertical-align: top">
                                <%# DataBinder.Eval(Container.DataItem,"ACTIONBY") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr class="tdgap">
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <asp:Panel ID="_panelNewAction" runat="server">
                    <table cellpadding="0" cellspacing="0" border="0" class="tableStyle" align="center">
                        <tr>
                            <td colspan="3" class="tdtitle">
                                New Action
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" class="tdgap" width="15%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                Action Taken
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="_tbActionTaken" runat="server" AutoCompleteType="FirstName" Font-Names="Arial"
                                    MaxLength="50" Rows="4" TextMode="MultiLine" Width="400px" 
                                    CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                Date &amp; Time
                            </td>
                            <td width="30%">
                                <asp:TextBox ID="_txtEndDate" runat="server" Width="200px" 
                                    CssClass="TextBoxBorder" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                    TargetControlID="_txtEndDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_txtEndDate"
                                    ErrorMessage="Select Date" Font-Bold="True" Font-Size="8pt"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdStyle">
                                Time:<asp:DropDownList ID="_ddlHours" runat="server"
                                    Height="20px" Width="40px" DataSourceID="XmlDataSource1" 
                                    DataTextField="text" DataValueField="value" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                                
                                </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_ddlHours"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                &nbsp;<asp:DropDownList ID="_ddlMinutes" Height="20px" Width="50px" 
                                    runat="server" AppendDataBoundItems="True" DataSourceID="XmlDataSource2" 
                                    DataTextField="text" DataValueField="value">
                                    <asp:ListItem Selected="True" Value="">mm</asp:ListItem>                                    
                               
                                </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_ddlMinutes"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                Issue Status
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList ID="_radResolutionStatus" runat="server" RepeatDirection="Horizontal"
                                    Font-Names="Arial" Font-Size="9pt">
                                    <asp:ListItem Selected="True" Value="P">Pending</asp:ListItem>
                                    <asp:ListItem Value="R">Resolved</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <asp:ImageButton ID="_btnUpdateSR" runat="server" OnClick="_btnRegisterSR_Click" ImageUrl="~/Images/Buttons/update.jpg"/>
                                <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                    DataFile="~/App_Data/data.xml" XPath="root/Hours/Hour"></asp:XmlDataSource>
                                <asp:XmlDataSource ID="XmlDataSource2" runat="server" 
                                    DataFile="~/App_Data/data.xml" XPath="root/Minutes/Min"></asp:XmlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</body>
