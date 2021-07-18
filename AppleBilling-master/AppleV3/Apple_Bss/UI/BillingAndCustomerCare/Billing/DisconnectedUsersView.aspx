<%@ Page Title="View Disconnected Users" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="DisconnectedUsersView.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.DisconnectedUsersView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        List of Disconnected Subscribers
                    </td>
                </tr>
                <caption>
                    &nbsp;<tr>
                        <td class="mainTD">
                            <table align="center" bgcolor="White" border="0" cellpadding="0" 
                                cellspacing="0" style="height: 50px" width="100%">
                                <tr>
                                    <td width="50%">
                                        <asp:RadioButtonList ID="_rbtnListStatus" runat="server" 
                                            RepeatDirection="Horizontal" Width="100%">
                                            <asp:ListItem Selected="True" Value="T">Temporarily Disconnected</asp:ListItem>
                                            <asp:ListItem Value="P">Permanently Disconencted</asp:ListItem>
                                             <asp:ListItem Value="D">Deactivated</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="_btnViewUsers" runat="server" 
                                            ImageUrl="~/Images/Buttons/View.jpg" OnClick="_btnViewUsers_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="mainTD">
                            <table align="center" cellpadding="0" cellspacing="0" class="tableStyle">
                                <tr>
                                    <td>
                                        <asp:GridView ID="_gvTempDisconnectUsers" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CssClass="gridStyle" GridLines="None" 
                                            OnPageIndexChanging="_gvTempDisconnectUsers_PageIndexChanging" PageSize="5" 
                                            Style="padding-left: 10px" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="USERID" HeaderText="User ID">
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="15%" />
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="USERNAME" HeaderText="UserName">
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NAME" HeaderText="Subscriber Name">
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%" />
                                                    <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact Number">
                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                    <ItemStyle Width="25%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <a href='DisconnectionActivate.aspx?userID=<%# Apple_Bss.CodeFile.Utilities.QueryStringEncode(Eval("USERID").ToString()) %>'>
                                                        <img alt="Reactivate" border="0" src="Images/ReActivate.png" 
                                                            title="Go to reactivate page for the selected subscriber" /></a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="gridRowStyle" />
                                            <PagerStyle CssClass="gridPagerStyle" />
                                            <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="gridAltRow" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </caption>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
