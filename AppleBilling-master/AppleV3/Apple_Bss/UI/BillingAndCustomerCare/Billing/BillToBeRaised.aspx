<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="BillToBeRaised.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.BillToBeRaised"
    Title="Raise Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Connected Broadband Users : Pending Bills
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellspacing="0" cellpadding="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdStyle" style="padding-left: 0px">
                                    <asp:GridView ID="_gvPendingConnections" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="0" CellSpacing="0" Width="100%" EmptyDataText="No Pending Bills"
                                        OnPageIndexChanging="_gvPendingConnections_PageIndexChanging" PageSize="5" GridLines="None"
                                        CssClass="gridStyle">
                                        <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="&amp;gt;&amp;gt;Last"
                                            Mode="NumericFirstLast" NextPageText="&amp;gt;Next" PreviousPageText="&amp;lt;Previous" />
                                        <Columns>
                                            <asp:BoundField DataField="NAME" HeaderText="Name">
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMAILID" HeaderText="Email ID">
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                <HeaderStyle HorizontalAlign="left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                <ItemStyle HorizontalAlign="Left" Width="35%" />
                                                <HeaderStyle HorizontalAlign="left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href='BillRaised.aspx?id=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("USERID").ToString()) %>'>
                                                        Raise Bill</a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
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
                                <td class="tdStyle">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <span style="font-weight: bold">Loading...Please Wait...</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
