<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedActivity.ascx.cs"
    Inherits="Apple_Bss.UserControl.LoggedActivity" %>
<link href="../CSS/InetBill.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div style="height: auto;">
            <div class="tdHeader">
                <img src="../../../images/Buttons/Recent.png" border="0" align="absmiddle" style="margin:0 10px 0 0;float:left"/>
                <div style="float:left;width:auto; height:auto;padding-top:5px;"><asp:Label ID="lblToday" runat="server" Text="My Latest Activity"></asp:Label></div>
            </div>
            <div style="padding:0 10px 0 10px;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                    Width="95%" PageSize="8" CellPadding="1" GridLines="None" HorizontalAlign="Left"
                    CssClass="gridStyle" AllowPaging="True" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "EVENT")%>
                                <tr>
                                    <td class="timeDateRow">
                                        <%# DataBinder.Eval(Container.DataItem, "MODON", "{0: h:mm tt  MMMM dd, yyyy }")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <ItemStyle CssClass="itemRowStyle" Width="100%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="Latest" LastPageText="Oldest" Mode="NextPreviousFirstLast"
                        NextPageText="Older" PreviousPageText="Previous" />
                    <PagerStyle CssClass="gridPagerStyle" />
                </asp:GridView>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
