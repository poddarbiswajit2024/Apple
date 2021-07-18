<%@ Page Language="C#" MasterPageFile="~/UI/TechnicalSupport/DirectSupport/TechDirectSupport.Master"
    AutoEventWireup="true" CodeBehind="RaiseBroadbandSRDirect.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.DirectSupport.RaiseBroadbandSRDirect"
    Title="Raise SR " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" 
        ChildrenAsTriggers="true">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Raise Support Request
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">Subscriber Details</div>
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                           
                            <tr>
                                <td colspan="3" class="tdStyle">
                                    <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">
                                    </asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="20%" class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap" width="20%">
                                    &nbsp;
                                </td>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Username
                                </td>
                                <td colspan="2" class="tdStyle">
                                
                                   <asp:TextBox ID="_tbUserName" runat="server" AutoPostBack="True" 
                                        ontextchanged="_tbUserName_TextChanged" Font-Names="Arial" 
                                        Font-Size="9pt" CssClass="TextBoxBorder" Width="150px" ></asp:TextBox>
                                       
                                    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
                                        CompletionInterval="500" DelimiterCharacters="" Enabled="True" 
                                        MinimumPrefixLength="2" ServiceMethod="GetSubscribers" 
                                        ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserName" 
                                        CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20">
                                    </cc1:AutoCompleteExtender>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblDetails" runat="server" Text="Customer Details"></asp:Label>&nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" 
                                        RenderMode="Inline" ChildrenAsTriggers="False">
                                                            <ContentTemplate>
                                                                <asp:Literal ID="_ltrlSubscriberDetails" runat="server"></asp:Literal>                                                                
                                                                <asp:HiddenField ID="HiddenFieldUserId" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="_tbUserName" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap">
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
                        <div class="tdSubtitle">SR Details</div>
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            
                            <tr>
                                <td style="width: 20%;" class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap" width="40%">
                                    &nbsp;
                                </td>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Call Date
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtStartDate" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                        TargetControlID="_txtStartDate" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="_txtStartDate"
                                        ErrorMessage="Select Start Date"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    Time&nbsp;&nbsp;
                                    <asp:DropDownList ID="_ddlHours" runat="server" Height="20px" Width="40px" 
                                        AppendDataBoundItems="True" DataSourceID="XmlDataSource1" DataTextField="text" 
                                        DataValueField="value">
                                        <asp:ListItem Selected="True" Value="">hh</asp:ListItem>  
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_ddlHours"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:DropDownList ID="_ddlMinutes" runat="server" Height="20px" Width="50px" 
                                        DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" 
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="">mm</asp:ListItem>                                        
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_ddlMinutes"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Issue Reported
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_tbIssueReported" runat="server" AutoCompleteType="FirstName" Font-Names="AC"
                                        MaxLength="50" Rows="4" TextMode="MultiLine" Width="400px" 
                                        CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_tbIssueReported"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdgap">
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
                       <div class="tdSubtitle"> Resolution Details</div>
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                           
                            <tr>
                                <td class="tdgap" width="20%">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="tdStyle">
                                    Support Type
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:DropDownList ID="_ddlSupportType" runat="server" Height="20px" 
                                        Width="300px" CssClass="TextBoxBorder">
                                        <asp:ListItem Value="O">On-Site Support</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="T">Telephonic Support</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="tdStyle">
                                    Findings
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_tbIssueCause" runat="server" AutoCompleteType="FirstName"
                                        MaxLength="50" Rows="4" TextMode="MultiLine" Width="300px" 
                                        CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_tbIssueCause"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Issue Type
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:DropDownList ID="_ddlIssueType" runat="server" Width="300px" 
                                        CssClass="TextBoxBorder" Height="20px">
                                        <asp:ListItem Value="S">SymBios Network Issue</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="C">Client-End Issue</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Action Taken
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_tbActionTaken" runat="server" AutoCompleteType="FirstName" Font-Names="Arial"
                                        MaxLength="50" Rows="4" TextMode="MultiLine" Width="300px" 
                                        CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbActionTaken"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Issue Status
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:RadioButtonList ID="_radResolutionStatus" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="P">Pending</asp:ListItem>
                                        <asp:ListItem Value="R">Resolved</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblResDateTime" runat="server" Text="Resolution Date"></asp:Label>
                                </td>
                                <td class="tdStyle" width="25%">
                                    <asp:TextBox runat="server" ID="_txtEndDate" Width="150px" 
                                        CssClass="TextBoxBorder" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="BottomRight"  CssClass="ajax__calendar"
                                        TargetControlID="_txtEndDate" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="_txtEndDate"
                                      Enabled="false"  ErrorMessage="Select End Date"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblResTime" runat="server" Text="Time"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="_ddlEndHours" runat="server" Height="20px"
                                        Width="40px" AppendDataBoundItems="True" DataSourceID="XmlDataSource1" 
                                        DataTextField="text" DataValueField="value">
                                        <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                                        
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvHours" runat="server" ControlToValidate="_ddlEndHours"
                                        ErrorMessage="*" Enabled="false"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:DropDownList ID="_ddlEndMinutes" runat="server" Height="20px" Width="50px" 
                                        DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" 
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="">mm</asp:ListItem>                                        
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvminutes" runat="server" ControlToValidate="_ddlEndMinutes"
                                        ErrorMessage="*" Enabled="false"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblIssueAssignedTo" runat="server" Text="Assign SR"></asp:Label>
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:DropDownList ID="_ddlIssueAssignedTo" runat="server" Width="350px" CssClass="TextBoxBorder"
                                        Height="20px">
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr><td class="tdgap"> &nbsp;</td></tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="_btnRegisterSR0" runat="server" 
                                        ImageUrl="~/Images/Buttons/Register service request.jpg" 
                                        OnClick="_btnRegisterSR_Click" />
                                </td>
                                <td>
                                    &nbsp;
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
      
    </asp:UpdatePanel>
</asp:Content>
