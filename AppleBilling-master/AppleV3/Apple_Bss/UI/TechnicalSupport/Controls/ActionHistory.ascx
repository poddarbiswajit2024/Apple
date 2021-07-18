<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActionHistory.ascx.cs"
    Inherits="Apple_Bss.UI.TechnicalSupport.Controls.ActionHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link rel="stylesheet" href="../../../CSS/InetBill.css" media="screen" type="text/css" />
<table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
    <tr>
        <td class="tdtitle">
            Service Request Details
        </td>
    </tr>
    <tr>
        <td class="mainTD">
            <table cellspacing="0" cellpadding="0" border="0" align="center" class="tableStyle">
                <tr>
                    <td colspan="2" class="tdgap">
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle" width="20%">
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
                <tr>
                    <td class="tdgap" colspan="2">
                        &nbsp;</td>
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
            <div class="tdSubtitle">Action History</div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="0" cellpadding="0" cellspacing="0"  align="center"  class="tableStyle">
                       
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdStyle">
                        <td style="width: 30%; vertical-align: top; padding-left: 5px">
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
                    <tr>
                        <td colspan="3" class="tdStyle">
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
            <div class="tdSubtitle"> New Action</div>
            <asp:Panel ID="_panelNewAction" runat="server">
                <table border="0" cellpadding="0" cellspacing="0"  align="center" class="tableStyle">
                    
                    <tr>
                        <td class="tdgap" width="20%">
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
                        <td colspan="2" class="tdStyle">
                            <asp:TextBox ID="_tbActionTaken" runat="server" AutoCompleteType="FirstName" Font-Names="Arial"
                                MaxLength="50" Rows="4" TextMode="MultiLine" Width="400px" 
                                CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Date
                        </td>
                        <td class="tdStyle" width="25%">
                            <asp:TextBox ID="_txtEndDate" runat="server" Width="150px" 
                                CssClass="TextBoxBorder" />

                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"  CssClass="ajax__calendar"
                                TargetControlID="_txtEndDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtEndDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="tdStyle">
                            Time:
                            <asp:DropDownList ID="_ddlHours" runat="server" Height="20px" Width="40px" AppendDataBoundItems="true"
                                DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                          
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_ddlHours"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            &nbsp;<asp:DropDownList ID="_ddlMinutes" runat="server" Height="20px" Width="50px" 
                                DataSourceID="XmlDataSource2" AppendDataBoundItems="true" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">mm</asp:ListItem>
                             
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_ddlMinutes"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px;">
                            <strong class="tdStyle">Issue Status</strong>
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:RadioButtonList ID="_radResolutionStatus" runat="server" RepeatDirection="Horizontal"
                                Font-Names="Arial" Font-Size="9pt" AutoPostBack="True" > <asp:ListItem Selected="True" Value="P">Pending</asp:ListItem>
                                <asp:ListItem Value="F">Fixed</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblIssueAssignedTo" runat="server" Text="Action Taken By"></asp:Label>
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:DropDownList ID="_ddlIssueAssignedTo" runat="server" Width="350px" CssClass="TextBoxBorder"
                                        Height="20px" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="SEMP3013">Select Technical Support Executive</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                    <tr>
                        <td class="tdStyle">
                            Call Book Number</td>
                        <td class="tdStyle" colspan="2">
                           <asp:TextBox ID="tbCallBookNumber" runat="server" Width="150px" 
                                CssClass="TextBoxBorder" /></td>
                    </tr>
                    <tr>
                        <td class="tdgap">
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
                        <td colspan="2" class="tdStyle">
                            <asp:ImageButton ID="_btnUpdateSR" runat="server" OnClick="_btnRegisterSR_Click"  ImageUrl="~/Images/Buttons/Updateservicerequest.jpg"/>
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                DataFile="~/App_Data/data.xml" XPath="root/Hours/Hour"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" 
                                DataFile="~/App_Data/data.xml" XPath="root/Minutes/Min"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="2">
                        </td>
                        <td class="tdgap">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
