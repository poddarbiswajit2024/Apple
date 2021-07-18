<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="BroadbandSubscriberLedger.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.BroadbandSubscriberLedger"
    Title="Subscriber Ledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Broadband Subscriber Ledger
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdgap" width="20%">
                                    &nbsp;
                                </td>
                                <td class="tdgap" width="20%">
                                    &nbsp;
                                </td>
                                <td class=" tdgap" width="15%">
                                    &nbsp;
                                </td>
                                <td class=" tdgap" width="45%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdgap">
                                    &nbsp;
                                </td>
                                <td class="tdView" rowspan="4">
                                    <asp:Label ID="_lblName" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    User Status
                                </td>
                                <td class="tdStyle">
                                    <asp:DropDownList ID="_ddlUserType" runat="server" Width="180px" 
                                        CssClass="TextBoxBorder" Height="20px">
                                        <asp:ListItem Value="">------- Select -------</asp:ListItem>
                                        <asp:ListItem Value="A">Active</asp:ListItem>
                                        <asp:ListItem Value="T">Temporary De-Activate</asp:ListItem>
                                        <asp:ListItem Value="P">Permanently Disconnected</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_ddlUserType"
                                        ErrorMessage="*" ValidationGroup="select"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnUserType" ImageUrl="~/Images/Buttons/Select.jpg" runat="server" OnClick="_btnUserType_Click" ValidationGroup="select" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select User
                                </td>
                                <td class="tdStyle">
                                    <asp:DropDownList ID="_ddlUser" runat="server" Width="180px" 
                                        CssClass="TextBoxBorder" Height="20px">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnSelectedUser" ImageUrl="~/Images/Buttons/View.jpg" runat="server" OnClick="_btnSelectedUser_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            Loading... Please Wait
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" style="padding-left: 0px"  colspan="4">
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
                                <td>
                                    <asp:GridView ID="_gvSubscriberLedger" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        OnPageIndexChanging="_gvSubscriberLedger_PageIndexChanging" PageSize="5" ShowFooter="True"
                                        Width="100%" EmptyDataText="No record Exist " GridLines="None" CssClass="gridStyle">
                                        
                                        <Columns>
                                            <asp:TemplateField HeaderText="Instrument No.">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('../Billing/SubscriberBillDisplay.aspx?bnum=<%# Eval("INSTRUMENTID").ToString()%>','myPop1',900,700);">
                                                        <%#Eval("INSTRUMENTID").ToString()%></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MODON" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Entry Date">
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SPECIFICATIONS" HeaderText="Ledger Head" FooterText="Total Amount In Rs.">
                                                <FooterStyle HorizontalAlign="Right"  VerticalAlign="Top"/>
                                                <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Credit (Cr.)">
                                                <ItemTemplate>
                                                    <%#Eval("CR").ToString()%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <span style="color: Black; font-weight: bold">
                                                        <%=totalCredit %></span>
                                                </FooterTemplate>
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" CssClass="gridRightPad" />
                                                <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                                <ItemStyle HorizontalAlign="Right" Width="15%" CssClass="gridRightPad" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Debit (Dr.)">
                                                <ItemTemplate>
                                                    <%#Eval("DR").ToString()%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <span style="color: Black; font-weight: bold">
                                                        <%=totalDebit %>
                                                    </span>
                                                    <br />
                                                    <span style="color: Red; font-weight: bold; padding-right: 2%">Outstanding Amt.=<%=OutstandingAmount%></span>
                                                </FooterTemplate>
                                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" CssClass="gridRightPad" />
                                                <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                                <ItemStyle HorizontalAlign="Right" Width="15%" CssClass="gridRightPad" />
                                            </asp:TemplateField>
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
