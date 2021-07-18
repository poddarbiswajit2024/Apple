<%@ Page Title="SR Reports" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="ServiceRequestSearch.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.ServiceRequestSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
               
                <tr>
                    <td class="mainTD"  width="40%">
                        <table class="tableStyle" cellpadding="0" cellspacing="0" align="left" border="0">
                            <tr>
                    <td class="tdtitle">
                        Service Request Search
                    </td>
                </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                   
                            <tr>
                                <td class="tdStyle">
                                    <strong>SRV</strong><asp:TextBox ID="tbSRNo" runat="server" AutoCompleteType="Search"></asp:TextBox>
                                    &nbsp;</td>
                               
                            </tr>
                      
                          
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                            </tr>
                      
                          
                            <tr>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="imgBtnGetDetails0" runat="server" 
                                        ImageUrl="~/Images/Buttons/Get Details.jpg" onclick="imgBtnGetDetails_Click" 
                                        ValidationGroup="srno" />
                                </td>
                            </tr>
                      
                          
                            <tr>
                               
                                <td class="tdStyle">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                    <span style="color: Green;"> Fetching Details...Please wait</span>
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                      <td class="mainTD">
                      <table cellspacing="0" cellpadding="0" border="0" align="center" class="tableStyle">
                      <tr>
                      <td class="tdtitle" colspan="2">
            Service Request Details
        </td></tr>
                <tr>
                    <td colspan="2" class="tdgap">
                    </td>
                </tr>
                          <tr>
                    <td class="tdStyle" width="20%">
                        User ID
                    </td>
                    <td class="tdStyle">
                        <asp:Label ID="_lblUSERID" runat="server" Font-Bold="True"></asp:Label>
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
                <tr class="tdgap">
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="mainTD" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
 
 
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
                            <asp:TextBox ID="_txtEndDate" runat="server"
                                CssClass="TextBoxBorder" />
                                
                                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="TopLeft"  CssClass="ajax__calendar"
                                        TargetControlID="_txtEndDate" Format="dd-MMM-yyyy"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_txtEndDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="tdStyle">
                            Time:
                            <asp:DropDownList ID="_ddlHours" runat="server" Height="20px" Width="40px" AppendDataBoundItems="true"
                                DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                          
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_ddlHours"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            &nbsp;<asp:DropDownList ID="_ddlMinutes" runat="server" Height="20px" Width="50px" 
                                DataSourceID="XmlDataSource2" AppendDataBoundItems="true" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">mm</asp:ListItem>
                             
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_ddlMinutes"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px;">
                            <strong class="tdStyle">Issue Status</strong>
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:RadioButtonList ID="_radResolutionStatus" runat="server" RepeatDirection="Horizontal"
                                Font-Names="Arial" Font-Size="9pt">
                                <asp:ListItem Selected="True" Value="P">Pending</asp:ListItem>
                                <asp:ListItem Value="F">Fixed</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
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
                            <asp:ImageButton ID="_btnUpdateSR" runat="server"  
                                ImageUrl="~/Images/Buttons/Updateservicerequest.jpg" 
                                onclick="_btnUpdateSR_Click"/>
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                DataFile="~/App_Data/data.xml" XPath="root/Hours/Hour"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" 
                                DataFile="~/App_Data/data.xml" XPath="root/Minutes/Min"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="tdStyle" colspan="2">
                            &nbsp;</td>
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
                    </td>
                </tr>
                <tr>
                    <td class="tdgap">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
