<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    Title="Search User" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.SearchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Search Broadband User
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="left" border="0">
                            <tr>
                                <td class="tdgap" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Search User
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_tbSearchText" runat="server" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbSearchText"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" Font-Names="Arial"
                                        Font-Size="9pt" ForeColor="#0066FF">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:RadioButton ID="_radBtnSearchByUsername" runat="server" Checked="True" Font-Names="Arial"
                                        Font-Size="8pt" GroupName="_grpSearchType" Text="By Username" />&nbsp;<asp:RadioButton
                                            ID="_radBtnSearchByUserID" runat="server" Font-Names="Arial" Font-Size="8pt" GroupName="_grpSearchType"
                                            Text="By User ID" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="Button1" runat="server" OnClick="_btnSearch_Click"  ImageUrl="~/Images/Buttons/search.jpg"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="2">
                                    &nbsp; &nbsp;
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
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="left" border="0">
                            
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:GridView ID="_gvUsers" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" BorderStyle="None" CaptionAlign="Left" CellPadding="0"
                                        EmptyDataText="Sorry!! No data associated with current selections exist." HorizontalAlign="Center"
                                        OnPageIndexChanging="_gvUsers_PageIndexChanging" OnRowCommand="_gvUsers_RowCommand"
                                        OnRowCreated="_gvUsers_RowCreated" OnRowDeleting="_gvUsers_RowDeleting" OnRowDataBound="_gvUsers_RowDataBound"
                                        PageSize="5" Style="padding-left: 0px" Width="100%" GridLines="None" 
                                        CssClass="gridStyle">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        
                                        <EmptyDataRowStyle Font-Bold="True" Height="22px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="USERID" HeaderText="User ID" Visible="False">
                                                <ItemStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Top"
                                                    Width="5%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Username">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('ViewBroadbandUserInfo.aspx?userid=<%# Eval("USERID").ToString()%>','myPop1',700,600);">
                                                        <%# Eval("USERNAME") %></a>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="gridLeftPad" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NAME" HeaderText="Subscriber Name">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STATUS" HeaderText="STATUS">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton_Activate" runat="server" AlternateText="Activate"
                                                        ToolTip="Activate" CausesValidation="false" CommandArgument='<%# Eval("USERID") %>'
                                                        CommandName="Act" ImageUrl="~/Images/Buttons/activate.png" OnClientClick="javascript:return confirm('Are you sure you want to Activate this user?')" />
                                                    <!-- &nbsp;&nbsp;<asp:Image ID="Img1" runat="server" AlternateText="" ImageUrl="../../Images/Buttons/dots.gif" />&nbsp;&nbsp;-->
                                                  <asp:ImageButton ID="ImageButton_Deactivate" runat="server" 
                                                                                        AlternateText="DeActivate" ToolTip="DeActivate" CausesValidation="false" 
                                                                                        CommandArgument='<%# Eval("USERID") %>' CommandName="Dea" 
                                                                                        ImageUrl="~/Images/Buttons/Deactivate.png" 
                                                                                        OnClientClick="javascript:return confirm('Are you sure you want to DeActivate this user?')" />
                                                     </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table cellpadding="0" cellspacing="0" style="width: 100%" border="0">
                                                <tr>
                                                    <td align="left" style="font:bold 8pt arial; color: #888888">
                                                        Matches found!!
                                                    </td>
                                                    <td align="right" style="font:bold 8pt arial; color: #000000">
                                                        Goto Page
                                                        <asp:DropDownList ID="ddlPageSelector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>
                                        
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="2" style="padding: 0px 0px 0px 0px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
