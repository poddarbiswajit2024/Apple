<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="PendingConnections.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.PendingConnections"
    Title="Pending Connections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdtitle">
                        Pending Connections
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <asp:GridView ID="_gvPendingConnections" runat="server" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="500" OnPageIndexChanging="_gvPendingConnections_PageIndexChanging"
                            Width="100%" GridLines="Horizontal" HorizontalAlign="Center" CssClass="gridStyle">
                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="&amp;gt;&amp;gt;Last"
                                Mode="NumericFirstLast" NextPageText="&amp;gt;Next" PreviousPageText="&amp;lt;Previous" />
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <a href="javascript:PopupCenter('RegisteredUserInfoDetails.aspx?userid=<%# Eval("USERID").ToString()%>','myPop1',800,700);">
                                                        <%# Eval("NAME") %></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font: Arial; font-size: 8pt; color: Gray">
                                                    <%# Apple_Bss.CodeFile.Utilities.Htmlize(Eval("INSADR").ToString())%>
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
                                <asp:BoundField DataField="EMAILID" HeaderText="Email ID">
                                    <ItemStyle Width="18%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                    <ItemStyle Width="33%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                    <ItemStyle Width="12%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="MODON" DataFormatString="{0: dd-MMM-yy}" HeaderText="Uploaded Date">
                                    <ItemStyle Width="12%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                     <%--   <a href="connectuser.aspx?id=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("USERID").ToString()) %>">
                                            <img alt="Connect" src="../../Images/Buttons/connect.jpg" style="border: 0" title="Connect" /></a>
                                        
                                        <br />--%>

                                        <a href="verifyDocs.aspx?id=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("USERID").ToString()) %>">
                                            <img alt="Connect" src="../../Images/Buttons/connect.jpg" style="border: 0" title=" Verify Documents and Connect" /></a>
                                        
                                        <br />

                                     <%--   <a href="verifyDocs.aspx?id=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("USERID").ToString()) %>">
                                            <%--<img alt="Connect" src="../../Images/Buttons/connect.jpg" style="border: 0" title="Connect" />
                                            Verify Docs  </a>--%>

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
