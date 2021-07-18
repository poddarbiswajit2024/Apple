<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="Rep_ViewServiceRequests.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.Rep_ViewServiceRequests"
    Title="Service Request Report " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Service Request Report
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td width="15%" class="tdgap">
                                    &nbsp;
                                </td>
                                <td width="30%" class="tdgap">
                                </td>
                                <td class="tdgap" colspan="2" width="55%">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select Name
                                </td>
                                <td  class="tdStyle">
                                    <asp:DropDownList ID="_ddlSupportName" runat="server" Width="205px" 
                                        CssClass="TextBoxBorder" Height="22px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_ddlSupportName"
                                        ErrorMessage="Select "></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle" width="20%">
                                    <asp:RadioButtonList ID="_rbtnSupportType" runat="server" 
                                        RepeatDirection="Horizontal" Width="100%">
                                        <asp:ListItem Value="R" Selected="True">Resolved</asp:ListItem>
                                        <asp:ListItem Value="P">Pending</asp:ListItem>
                                        <asp:ListItem Value="A">All</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_rbtnSupportType" ErrorMessage="select"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Start Date
                                </td>
                                <td class="tdStyle" width="25%">
                                    <asp:TextBox ID="_txtStartDate" runat="server" BackColor="#F6F6F6" 
                                        CssClass="TextBoxBorder" Width="200px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" CssClass="ajax__calendar" runat="server" 
                                        PopupPosition="Right" TargetControlID="_txtStartDate" 
                                        DaysModeTitleFormat="MMMM,yyyy" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtStartDate" ErrorMessage="select start date"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdView" colspan="2" rowspan="2" width="20%">
                                    <asp:Label ID="_lblInfo" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    End Date
                                </td>
                                <td class="tdStyle" width="25%">
                                    <asp:TextBox ID="_txtEndDate" runat="server" BackColor="#F6F6F6" 
                                        CssClass="TextBoxBorder" Width="200px" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  CssClass="ajax__calendar"
                                        PopupPosition="Right"  TargetControlID="_txtEndDate" 
                                        DaysModeTitleFormat="MMMM,yyyy" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="_txtEndDate" ErrorMessage=" select end date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle" width="25%">
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel4">
                                        <ProgressTemplate>
                                            Loading...Please Wait..
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td class="tdStyle" width="20%">
                                    &nbsp;</td>
                                <td class="tdStyle">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td colspan="3" class="tdStyle">
                                    <asp:ImageButton ID="_btnShowReport" runat="server" OnClick="_btnShowReport_Click" 
                                        ImageUrl="~/Images/Buttons/Show Report.jpg" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="4">
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
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="tdStyle" style="padding-left: 0px">
                                    <asp:Label ID="_lblRequestType" runat="server" CssClass="lblRequest" ></asp:Label>
                                    <asp:GridView ID="_gvNmViewPendingServiceRequest" runat="server" AllowPaging="True"
                                        AutoGenerateColumns="False" GridLines="None" OnPageIndexChanging="_gvNmViewPendingServiceRequest_PageIndexChanging"
                                        PageSize="5" Width="100%" HorizontalAlign="Center" CssClass="gridStyle" 
                                        EmptyDataText="No record Exist!...">
                                        <Columns>
                                            <asp:BoundField DataField="USERNAME" HeaderText="User Name">
                                                <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ISSUE" HeaderText="Issue">
                                                <ItemStyle Width="40%" CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STARTDATETIME" DataFormatString="{0:dd/MMM/yyy}" HeaderText="Issue Reported Date">
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('UpdatePendingSRDirect.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);">
                                                        <img alt="View Details" src="../../Images/Buttons/view.png" style="border: 0" title="view Request" /></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" valign="top" style="padding-left: 0px">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    Loading...Please Wait....
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="_gvNmViewResolvedServiceRequest" runat="server" AllowPaging="True"
                                                AutoGenerateColumns="False" OnPageIndexChanging="_gvNmViewResolvedServiceRequest_PageIndexChanging"
                                                PageSize="5" Width="100%" GridLines="None" CssClass="gridStyle" 
                                                EmptyDataText="No record Exist!..">
                                                <Columns>
                                                    <asp:BoundField DataField="USERNAME" HeaderText="User Name">
                                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ISSUE" HeaderText="Issue">
                                                        <ItemStyle Width="25%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="STARTDATETIME" DataFormatString="{0:dd/MMM/yyy}" HeaderText="Issue Reported Date">
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ENDDATETIME" DataFormatString="{0:dd/MMM/yyy}" HeaderText="Issue Resolved Date">
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RESOLVEDTIMETAKEN" HeaderText="Service Span(mins)">
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <a href="javascript:PopupCenter('UpdatePendingSRDirect.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);">
                                                                <img alt="View Details" src="../../Images/Buttons/view.png" style="border: 0" /></a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="gridRowStyle" />
                                                <PagerStyle CssClass="gridPagerStyle" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                <AlternatingRowStyle CssClass="gridAltRow" />
                                            </asp:GridView>
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                <ProgressTemplate>
                                                    Loading...
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="_gvNmViewAllServiceRequest" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                OnPageIndexChanging="_gvNmViewAllServiceRequest_PageIndexChanging" PageSize="5"
                                                Width="100%" GridLines="None" CssClass="gridStyle" 
                                                EmptyDataText="No record Exist!..">
                                                <Columns>
                                                    <asp:BoundField DataField="USERNAME" HeaderText="User Name">
                                                        <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ISSUE" HeaderText="Issue">
                                                        <ItemStyle Width="50%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="STATUS" HeaderText="status">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <a href="javascript:PopupCenter('UpdatePendingSRDirect.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);">
                                                                <img alt="View Details" src="../../Images/Buttons/view.png" style="border: 0" /></a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="gridRowStyle" />
                                                <PagerStyle CssClass="gridPagerStyle" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                <AlternatingRowStyle CssClass="gridAltRow" />
                                            </asp:GridView>
                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                                <ProgressTemplate>
                                                    Loading...
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap">
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
