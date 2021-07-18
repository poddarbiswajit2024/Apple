<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="BroadbandUsers.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.BroadbandUsers"
    Title="Broadband Users" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Broadband Users
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" align="center" 
                            bgcolor="White" width="100%" style="height: 50px">
                            <tr>
                                <td width="50%">
                                    <asp:RadioButtonList ID="_rbtnListStatus" runat="server" 
                                        RepeatDirection="Horizontal" Width="100%">
                                        <asp:ListItem Selected="True" Value="AL">All</asp:ListItem>
                                        <asp:ListItem Value="A">Active</asp:ListItem>
                                        <asp:ListItem Value="D">De-Activated</asp:ListItem>
                                        <asp:ListItem Value="T">Temporaryly Disconnected</asp:ListItem>
                                        <asp:ListItem Value="P">Permanently Disconencted</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:ImageButton ID="_btnViewUsers" runat="server" OnClick="_btnViewUsers_Click" ImageUrl="~/Images/Buttons/View.jpg" />
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
                           <table border="0" cellpadding="0" cellspacing="0" align="center" 
                            bgcolor="White" width="100%" style="height: 50px">
                         
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Search by Username
                                </td>
                                <td class="tdStyle" width="35%">
                                  <asp:TextBox ID="_tbUserName" runat="server" 
                                        Font-Names="Arial" 
                                        Font-Size="9pt" CssClass="TextBoxBorder" Width="180px" ></asp:TextBox>
                                  
                                    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
                                        CompletionInterval="500" DelimiterCharacters="" Enabled="True" 
                                        MinimumPrefixLength="2" ServiceMethod="GetSubscribers" 
                                        ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserName" 
                                        CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20">
                                    </cc1:AutoCompleteExtender>
                                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                        runat="server" ControlToValidate="_tbUserName"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" Font-Names="Arial"
                                        Font-Size="9pt" ForeColor="#0066FF" ValidationGroup="search">*</asp:RequiredFieldValidator>
                                           </td>
                                             <td class="tdStyle">
                                    <asp:ImageButton ID="Button1" runat="server" 
                                        ImageUrl="~/Images/Buttons/search.jpg" OnClick="_btnSearch_Click" 
                                                     ValidationGroup="search" />
                                </td>
                            </tr>
                        
                            
                          
                        </table>
                    </td>
                </tr>
                <tr class="tdStyle">
                    <td class="tdStyle">
                        <asp:Label ID="_lblTotalUsers" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="mainTD" valign="top">
                        <asp:GridView ID="_gvActiveBroadBandUsers" runat="server" AutoGenerateColumns="False"
                            Width="100%" AllowPaging="True" PageSize="5" GridLines="None" OnPageIndexChanging="_gvActiveBroadBandUsers_PageIndexChanging"
                            OnRowCreated="_gvActiveBroadBandUsers_RowCreated" 
                            EmptyDataText="Sorry!! No record exist for this selection." 
                            CssClass="gridStyle" onrowcommand="_gvActiveBroadBandUsers_RowCommand" 
                            onrowdatabound="_gvActiveBroadBandUsers_RowDataBound">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                                <asp:TemplateField HeaderText="User ID">
                                    <ItemTemplate>
                                        <a href="javascript:PopupCenter('ViewBroadbandUserInfo.aspx?userid=<%# Eval("USERID").ToString()%>','myPop1',800,700);">
                                            <%# Eval("USERID").ToString() %></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="USERNAME" HeaderText="Username">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NAME" HeaderText="Subscriber Name">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField> 
                                     
                                       <asp:BoundField DataField="STATUS" HeaderText="Status">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="gridLeftPad" />
                                            </asp:BoundField>                                   
                                 
                                     <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>                                                   
                                                     <asp:ImageButton ID="ImgBtnDeact" runat="server" ImageUrl='~/Images/Buttons/deactivate.png' CommandArgument='<%# Eval("USERID") %>' 
                                                                        CommandName="Dea" CausesValidation="false" AlternateText="DeActivate" ToolTip = "Deactivate"/>   
                                                                        &nbsp;   
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                 
                               
                            </Columns>
                            <PagerTemplate>
                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="tdStyle" style="font: 8pt Arial;text-align: left; color: #888888; padding-left: 0px" width="90%">
                                            <asp:Label ID="_lblCurrentPageNumber" runat="server"></asp:Label>
                                            &nbsp;
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    Loading... Please Wait
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="font:bold 8pt Arial; color: #000000;" align="right">
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
