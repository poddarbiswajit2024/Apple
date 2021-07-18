<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="DarkFiberConnections.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.DarkFiberConnections"
    Title="Dark Fiber Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdtitle">
                        Dark Fiber Users
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <asp:GridView ID="_gvPendingConnections" runat="server" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="5" OnPageIndexChanging="_gvPendingConnections_PageIndexChanging"
                            Width="100%" GridLines="Horizontal" HorizontalAlign="Center" CssClass="gridStyle">
                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="&amp;gt;&amp;gt;Last"
                                Mode="NumericFirstLast" NextPageText="&amp;gt;Next" PreviousPageText="&amp;lt;Previous" />
                            <Columns>
                                <asp:TemplateField HeaderText="Username/Correspendance Add.">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                         <%--           <a href="javascript:PopupCenter('.aspx?userid=<%# Eval("ACCOUNTID").ToString()%>','myPop1',800,700);">--%>
                                                        <%# Eval("USERNAME") %><%--</a>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font: Arial; font-size: 8pt; color: Gray">
                                                    <%# Apple_Bss.CodeFile.Utilities.Htmlize(Eval("CORADR").ToString())%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font: Arial; font-size: 8pt; color: Gray">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMAILID1" HeaderText="Primary Email ID">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                             
                                <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <a href="AddLinkDF.aspx?id=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("ACCOUNTID").ToString()) %>">
                                            <img alt="ADD LINK"  src="../../Images/Buttons/Add_link.jpg" style="border: 0" title="Add Link" /></a>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
