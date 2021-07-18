<%@ Page Title="SR Reports" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="CableSRReport.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.CableSRReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Service Request Report
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellpadding="0" cellspacing="0" align="left" border="0">
                            <tr>
                                <td width="15%" class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select Status
                                </td>
                                <td class="tdStyle">
                                    <asp:DropDownList ID="_ddlSupportType" runat="server" Width="155px" 
                                        CssClass="TextBoxBorder" Height="22px">
                                        <asp:ListItem Value="P">Pending</asp:ListItem>
                                        <asp:ListItem Value="F">Fixed</asp:ListItem>
                                        <asp:ListItem  Value="R">Resolved</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="A">All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Start Date
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox runat="server" ID="_txtStartDate" Width="150px" 
                                        CssClass="TextBoxBorder" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"  CssClass="ajax__calendar"
                                        TargetControlID="_txtStartDate" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtStartDate" ErrorMessage="Select Start Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    End Date
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox runat="server" ID="_txtEndDate" Width="150px" 
                                        CssClass="TextBoxBorder" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="BottomRight"  CssClass="ajax__calendar"
                                        TargetControlID="_txtEndDate" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="_txtEndDate" ErrorMessage=" Select End Date"></asp:RequiredFieldValidator>
                                    <asp:ImageButton ID="_btnShowReport" runat="server" CausesValidation="False" ImageUrl="~/Images/Buttons/Show Report.jpg" OnClick="_btnShowReport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                </td>
                                <td class="tdStyle">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                    <span style="color: Green;"> Fetching Details...Please wait</span>
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
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
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:GridView ID="_gvViewServiceRequestReport" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" OnPageIndexChanging="_gvViewServiceRequestReport_PageIndexChanging"
                                        PageSize="10" Width="100%" Style="padding-left: 10px" GridLines="None" 
                                        CssClass="gridStyle" EmptyDataText="No record Exist!...">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR Number">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('UpdatePendingSR.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);">
                                                        <%#Eval("issueid").ToString() %></a>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Name" DataField="USERID">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Issue Reported" DataField="ISSUE">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="25%" />
                                            </asp:BoundField>
                                      
                                            <asp:BoundField HeaderText="Reported On" DataField="STARTDATETIME" DataFormatString="{0:dd-MMM-yyyy }">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Resolved On" DataField="ENDDATETIME" DataFormatString="{0:dd-MMM-yyyy }">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Status" DataField="STATUS">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="8%" />
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
