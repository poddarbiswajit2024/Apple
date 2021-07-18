<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="CollectionReport.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.CollectionReport"
    Title="Collection Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Daily Collection report
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdgap" width="20%">
                                    &nbsp;
                                </td>
                                <td class="tdgap" width="40%" colspan="3">
                                    &nbsp;
                                </td>
                                <td class="tdgap" width="40%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Select Executive Name
                                </td>
                                <td class="tdStyle" width="40%" colspan="3">
                                    <asp:DropDownList ID="_ddlBillExecName" runat="server" Width="155px" 
                                        CssClass="TextBoxBorder" Height="20px">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdView" rowspan="3" width="40%">
                                    <asp:Label ID="_lblCollAmount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select Start Date
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtStartDate" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"
                                        TargetControlID="_txtStartDate" Format="dd-MMM-yyyy" TodaysDateFormat=""  CssClass="ajax__calendar"
                                        DaysModeTitleFormat="MMMM,yyyy">
                                    </cc1:CalendarExtender>
                                    
                                </td>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_txtStartDate" ErrorMessage="* Select start  Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select End Date</td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtEndDate" runat="server" CssClass="TextBoxBorder" 
                                        Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="_txtEndDate_CalendarExtender" runat="server"  CssClass="ajax__calendar"
                                        DaysModeTitleFormat="MMMM,yyyy" Format="dd-MMM-yyyy" PopupPosition="Right" 
                                        TargetControlID="_txtEndDate" TodaysDateFormat="">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnShow" runat="server" 
                                        ImageUrl="~/Images/Buttons/View.jpg" OnClick="_btnShow_Click" />
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="_txtEndDate" ErrorMessage="* Select End  Date"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" colspan="5" style="font-weight:bold">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            Loading...Please wait.
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="5">
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
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdStyle" colspan="3" style="padding-left: 0px">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="_gvCollectionDetails" runat="server" AutoGenerateColumns="False"
                                                Width="100%" EmptyDataText="No record exist !!" ShowFooter="True" GridLines="None"
                                                CssClass="gridStyle" AllowPaging="True" 
                                                onpageindexchanging="_gvCollectionDetails_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="USERNAME" HeaderText="Subscriber UserName">
                                                        <HeaderStyle Width="15%" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RECEIPTID" HeaderText="Receipt ID">
                                                        <HeaderStyle Width="13%" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RECEIPTNUMBER" HeaderText="Receipt No.">
                                                        <HeaderStyle Width="12%" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="INSTRUMENT" HeaderText="Payment Mode">
                                                     
                                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PAYMENTDATE" HeaderText="Payment Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                   
                                                        <HeaderStyle Width="15%" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MODON" HeaderText="Entry Date" DataFormatString="{0:dd-MMM-yyyy}" FooterText="Total Amount">
                                                          <FooterStyle Font-Bold="True" Height="22px" HorizontalAlign="Center" />
                                                        <HeaderStyle Width="15%" HorizontalAlign="Center"  />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Amount Paid">
                                                        <ItemTemplate>
                                                            <%#Eval("AMOUNT").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=amount%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="15%"  CssClass="gridRightPad" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings NextPageText="Next&amp;gt;" PreviousPageText="Prev&amp;lt;" />
                                                <RowStyle CssClass="gridRowStyle" />
                                                <PagerStyle CssClass="gridPagerStyle" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                <AlternatingRowStyle CssClass="gridAltRow" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
    </asp:UpdatePanel>
</asp:Content>
