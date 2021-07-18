<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="PointOfPresenceView.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.PointOfPresenceView"
    Title="POP List " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Point of Presence List
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellpadding="0" cellspacing="0" align="center" width="100%">
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="_gvPop" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        OnPageIndexChanging="_gvPop_PageIndexChanging" OnRowCommand="_gvPop_RowCommand"
                                        OnRowDeleting="_gvPop_RowDeleting" PageSize="5" Width="100%" BorderWidth="0"
                                        GridLines="None" CssClass="gridStyle">
                                        <Columns>
                                            <asp:BoundField DataField="POPNAME" HeaderText="POP Name">
                                                <ItemStyle Width="15%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ADDRESS" HeaderText="POP Address">
                                                <ItemStyle Width="15%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="GPDIP" HeaderText="Grid IP">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="BPDIP" HeaderText="Back Up IP">
                                                <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONTACTPERSON" HeaderText="Contact Person">
                                                <ItemStyle Width="12%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile No">
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                          <%--  <asp:BoundField DataField="LANDLINENUMBER" HeaderText="LandLine No">
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="STATUS" HeaderText="Status">
                                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href='PointOfPresenceEdit.aspx?popid=<%#Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("POPID").ToString())%>'>
                                                       <img alt="Edit" src="../../Images/Buttons/edit.png" border="0" /></a> 
                                                      <%-- &nbsp;&nbsp;
                                                    <img
                                                            src="../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                                  <asp:ImageButton ID="ImageButton_Deactivate" runat="server" ImageUrl="~/Images/Buttons/Deactivate.png"
                                                        CommandArgument='<%# Eval("POPID") %>' CommandName="DeAct" CausesValidation="false"
                                                        AlternateText="DeActivate" OnClientClick='javascript:return confirm("Are you sure you want to DeActivate this?")' />
                                                    &nbsp;&nbsp;<img src="../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Buttons/activate.png"
                                                        CommandArgument='<%# Eval("POPID") %>' CommandName="Act" CausesValidation="false"
                                                        AlternateText="Activate" OnClientClick='javascript:return confirm("Are you sure you want to Activate this")' />--%>
                                                   &nbsp;&nbsp;<img src="../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton_Delete" runat="server" ImageUrl="~/Images/Buttons/delete.png"
                                                        CommandArgument='<%# Eval("POPID") %>' CommandName="Delete" CausesValidation="false"
                                                        AlternateText="Delete" OnClientClick='javascript:return confirm("This Will be Permanently Deleted:Are you sure you want to Delete this permanently?")' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="30%" HorizontalAlign="Center" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
