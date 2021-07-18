<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="SubscriberInfoDetails.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.SubscriberInfoDetails"
    Title="Subscriber Information Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        List Of Subscribers
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdStyle" width="15%">
                                    &nbsp;</td>
                                <td class="tdStyle" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            Searching.........
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td class="tdStyle" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Search User
                                </td>
                                <td class="tdStyle" width="20%">
                                    <asp:TextBox ID="_tbSearchText" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbSearchText"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:RadioButtonList ID="_radBtnSearch" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="UNAME">By User Name</asp:ListItem>
                                        <asp:ListItem Value="UID">By User ID</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:ImageButton ID="_btnSearch" ImageUrl="~/Images/Buttons/search.jpg" runat="server" OnClick="_btnSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" colspan="3">
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
                                <td  colspan="3" style="padding-left: 0px">
                                    <asp:GridView ID="_gvUsers" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        GridLines="None" Width="100%" PageSize="5" OnPageIndexChanging="_gvUsers_PageIndexChanging"
                                        OnRowCreated="_gvUsers_RowCreated" CssClass="gridStyle">
                                        <PagerSettings Position="TopAndBottom" />
                                        
                                        <Columns>
                                            <asp:BoundField HeaderText="Name" DataField="NAME">
                                                <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="User Name" DataField="USERNAME">
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Bill Plan" DataField="BILLPLAN">
                                                <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Installation Address">
                                                <ItemTemplate>
                                                    <%#Server.HtmlDecode(Eval("INSADR").ToString())%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Correspondence Address">
                                                <ItemTemplate>
                                                    <%#Server.HtmlDecode(Eval("CORADR").ToString())%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Mobile Number" DataField="MOBILENUMBER">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Landline Number" DataField="LANDLINENUMBER">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width: 100%" bgcolor="White">
                                                        <tr>
                                                            <td align="left" style="padding-left: 10px;font: bold 8pt arial; color: #888888">
                                                                <asp:Label ID="_lblCurrentPageNumber" runat="server"></asp:Label>
                                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                                    <ProgressTemplate>
                                                                        Loading..Please Wait....
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                            <td align="right" style="font: bold 8pt arial; color: #000000">
                                                                Goto Page
                                                                <asp:DropDownList ID="ddlPageSelector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </PagerTemplate>
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
