<%@ Page Title="Raise SR" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="RaiseBroadbandSR.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.RaiseBroadbandSR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
        ChildrenAsTriggers="False">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Raise Support Request
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Subscriber Details</div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">
                                    </asp:Label>&nbsp;
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="tdStyle" style="width: 15%">
                                    Username
                                </td>
                                <td class="tdStyle" style="width: 85%">
                               
                                    <asp:TextBox ID="_tbUserName" runat="server" AutoPostBack="True" 
                                        ontextchanged="_tbUserName_TextChanged"></asp:TextBox>
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
                                <td class="tdStyle" style="width: 8%">
                                  
                              
                                    OR</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 15%">
                                    UserID</td>
                                <td class="tdStyle" style="width: 85%">
                         
                                    <asp:Label ID="lblBranchCode" runat="server" Text="">
                                    </asp:Label>-SCLX<asp:TextBox ID="tbUserId" runat="server" AutoPostBack="True" ontextchanged="tbUserId_TextChanged" 
                                        ></asp:TextBox>
                                 <%-- <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                        CompletionInterval="500" DelimiterCharacters="" Enabled="True" 
                                        MinimumPrefixLength="2" ServiceMethod="GetSubscribersUserID" 
                                        ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="tbUserId" 
                                        CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20">
                                    </cc1:AutoCompleteExtender>--%>
                               
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblDetails" Visible="true" runat="server" Text="Customer Details"></asp:Label>&nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" 
                                        RenderMode="Inline" ChildrenAsTriggers="False">
                                                            <ContentTemplate>
                                                                <asp:Literal ID="_ltrlSubscriberDetails" runat="server"></asp:Literal>                                                                
                                                                <asp:HiddenField ID="HiddenFieldUserId" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="_tbUserName" />
                                                                <asp:AsyncPostBackTrigger ControlID="tbUserId" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                      <span style="color:Green; font-weight:bold">getting customer basic details ...</span>
                              
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="2">
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
                        <div class="tdSubtitle">
                            SR Details
                        </div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td class="tdgap" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Call Date &amp; Time
                                </td>
                                <td class="tdStyle" style="width: 25%">
                                    <asp:TextBox ID="_txtStartDate" runat="server" CssClass="TextBoxBorder" Width="150px" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                        TargetControlID="_txtStartDate" 
                                        Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_txtStartDate"
                                        ErrorMessage="Select Start Date"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    Time&nbsp;&nbsp;
                                    <asp:DropDownList ID="_ddlHours" runat="server" Height="20px" Width="40px" 
                                        DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" 
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                                     
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvstartHours" runat="server" ControlToValidate="_ddlHours"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:DropDownList ID="_ddlMinutes" runat="server" Height="20px" Width="50px"
                                        AppendDataBoundItems="True" DataSourceID="XmlDataSource2" DataTextField="text" 
                                        DataValueField="value">
                                        <asp:ListItem Selected="True" Value="">mm</asp:ListItem>  
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvstartminutes" runat="server" ControlToValidate="_ddlMinutes"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Issue Reported
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_tbIssueReported" runat="server" AutoCompleteType="FirstName" MaxLength="50"
                                        Rows="3" TextMode="MultiLine" Width="350px" CssClass="TextBoxBorder" Height="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_tbIssueReported"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
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
                        <div class="tdSubtitle">
                            Resolution Details
                        </div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td class="tdgap" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Support Type
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:DropDownList ID="_ddlSupportType" runat="server" Enabled="False" Width="350px"
                                        CssClass="TextBoxBorder" Height="20px">
                                        <asp:ListItem Value="O">On-Site Support</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="T">Telephonic Support</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Findings
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_tbIssueCause" runat="server" AutoCompleteType="FirstName" Font-Names="Arial"
                                        MaxLength="50" Rows="3" TextMode="MultiLine" Width="350px" CssClass="TextBoxBorder"
                                        Height="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_tbIssueCause"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Issue Type
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:DropDownList ID="_ddlIssueType" runat="server" Width="350px" CssClass="TextBoxBorder"
                                        Height="20px">
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
                                        MaxLength="70" Rows="3" TextMode="MultiLine" Width="350px" CssClass="TextBoxBorder"
                                        Height="50px"></asp:TextBox>
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
                                        <asp:ListItem Value="F">Fixed</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblResDateTime" runat="server" Text="Resolution Date "></asp:Label>
                                </td>
                                <td class="tdStyle" width="25%">
                                    <asp:TextBox runat="server" ID="_txtEndDate" CssClass="TextBoxBorder" Width="150px" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="Right"  CssClass="ajax__calendar"
                                        TargetControlID="_txtEndDate" Format="dd-MMM-yyyy" 
                                      >
                                    </cc1:CalendarExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="_txtEndDate"
                                        ErrorMessage="Select End Date" Enabled="False"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblResTime" runat="server" Text="Time"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="_ddlEndHours" runat="server" Height="20px"
                                        Width="40px" AppendDataBoundItems="True" DataSourceID="XmlDataSource1" 
                                        DataTextField="text" DataValueField="value">
                                        <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                                        
                                       
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvHours" runat="server" ControlToValidate="_ddlEndHours"
                                        ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:DropDownList ID="_ddlEndMinutes" runat="server" Height="20px" Width="50px"
                                        AppendDataBoundItems="True" DataSourceID="XmlDataSource2" DataTextField="text" 
                                        DataValueField="value">
                                        <asp:ListItem Selected="True" Value="">mm</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvminutes" runat="server" ControlToValidate="_ddlEndMinutes"
                                        ErrorMessage="*" Enabled="False"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                  
                            <tr>
                                <td colspan="3"  class="tdStyle">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel3" DynamicLayout="False">
                                    <ProgressTemplate>
                                    <span style="color:Green; font-weight:bold">Sending Request...Please Wait...</span>
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2">
                                    <asp:ImageButton ID="_btnRegisterSR" runat="server" OnClick="_btnRegisterSR_Click" ImageUrl="~/Images/Buttons/Register service request.jpg"/>
                                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                        DataFile="~/App_Data/data.xml" XPath="root/Hours/Hour"></asp:XmlDataSource>
                                    <asp:XmlDataSource ID="XmlDataSource2" runat="server" 
                                        DataFile="~/App_Data/data.xml" XPath="root/Minutes/Min"></asp:XmlDataSource>
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
            </table>
        </ContentTemplate>
        
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="_radResolutionStatus" />
            <asp:AsyncPostBackTrigger ControlID="_btnRegisterSR" />
        </Triggers>
        
    </asp:UpdatePanel>
</asp:Content>
