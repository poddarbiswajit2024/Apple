<%@ Page Title="Manage System Users" Language="C#" MasterPageFile="~/UI/SystemManagement/SystemManage.Master"
    AutoEventWireup="true" CodeBehind="SysUsersManage.aspx.cs" Inherits="Apple_Bss.UI.SystemManagement.SysUsersManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type='text/javascript' src="../../Scripts/PopUp.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        System Users List
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="_gvSUsers" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                        AllowPaging="True" OnPageIndexChanging="_gvSUsers_PageIndexChanging" OnRowCommand="_gvSUsers_RowCommand"
                                        OnRowDataBound="_gvSUsers_RowDataBound" OnRowDeleting="_gvSUsers_RowDeleting"
                                        DataKeyNames="empid" PageSize="5" Width="100%" CellPadding="1" GridLines="None"
                                        HorizontalAlign="Center" CssClass="gridStyle">
                                        <Columns>                                           
                                            <asp:BoundField DataField="NAME" HeaderText="Name" ReadOnly="True">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            
                                             <asp:BoundField DataField="EMPID"  HeaderText="System User ID" ReadOnly="true" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="Priv" HeaderText="Privilege">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                         <asp:Image ID="ImgStatus" ImageUrl='~/Images/Buttons/activate.png' runat="server" ToolTip='<%#Eval("STATUS")%>' AlternateText='<%#Eval("STATUS")%>'  />
                                        </ItemTemplate>
                                         <HeaderStyle Width="10%" HorizontalAlign="Center"/>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('PopUpUserDetails.aspx?empid=<%# Eval("empid").ToString()%>','myPop1',700,450);">
                                                        <img alt="View" src="../../Images/Buttons/view.png" style="border: 0" title="View" /></a>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<img src="../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                   
                                                     <asp:ImageButton ID="ImgBtnDeact" runat="server" ImageUrl='~/Images/Buttons/deactivate.png' CommandArgument='<%# Eval("empid") %>' 
                                                                        CommandName="DeAct" CausesValidation="false" AlternateText="DeActivate" ToolTip = "Deactivate"/> 
                                                                        
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<img src="../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:ImageButton ID="ImageButton_Delete" runat="server" ImageUrl="~/Images/Buttons/delete.png"
                                                        CommandArgument='<%# Eval("EMPID") %>' CommandName="Delete" CausesValidation="false"
                                                        AlternateText="Delete" OnClientClick='javascript:return confirm("Permanently delete this user?")'
                                                        ToolTip="Delete" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
