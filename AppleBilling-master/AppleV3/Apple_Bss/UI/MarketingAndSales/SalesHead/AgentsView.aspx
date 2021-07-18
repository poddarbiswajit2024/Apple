<%@ Page Title="Agents List" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master"
    AutoEventWireup="true" CodeBehind="AgentsView.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.AgentsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Agent Management :: List of Symbios Agents
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" border="0" class="tableStyle" align="center">
                            <tr class="tdStyle">
                                <td style="padding-left: 0px">
                                    <asp:GridView ID="_gvAgentList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        OnPageIndexChanging="_gvAgentList_PageIndexChanging" OnRowCommand="_gvAgentList_RowCommand"
                                        OnRowDeleting="_gvAgentList_RowDeleting" EmptyDataText="There are currently no registered agents."
                                        Width="100%" Style="padding-left: 10px" GridLines="None" 
                                        CssClass="gridStyle" PageSize="5" 
                                        onrowdatabound="_gvAgentList_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="AGENTCODE" HeaderText="Agent Code">
                                                <HeaderStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad"/>
                                                <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AGENTNAME" HeaderText="Agent Name">
                                                <HeaderStyle Width="20%" HorizontalAlign="Left"/>
                                                <ItemStyle Width="20%" HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ADDRESS" HeaderText="Address">
                                                <HeaderStyle Width="30%" HorizontalAlign="Left"/>
                                                <ItemStyle Width="30%" HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                         
                                        <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                         <asp:Image ID="ImgStatus" ImageUrl='~/Images/Buttons/activate.png' runat="server" ToolTip='<%#Eval("STATUS")%>' AlternateText='<%#Eval("STATUS")%>'  />
                                        </ItemTemplate>
                                         <HeaderStyle Width="10%" HorizontalAlign="Center"/>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                            <asp:BoundField DataField="CONTACTNUMBER" HeaderText="Contact Number">
                                                <HeaderStyle Width="10%" HorizontalAlign="Left"/>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <a href='AgentEdit.aspx?agentid=<%#Eval("AGENTCODE").ToString()%>'>
                                                        <img alt="Edit" src="../../../Images/Buttons/edit.png" style="border: 0" /></a>
                                                    &nbsp;&nbsp;<img src="../../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                                    
                                                     <asp:ImageButton ID="ImgBtnDeact" runat="server" ImageUrl='~/Images/Buttons/deactivate.png' CommandArgument='<%# Eval("AGENTCODE") %>' 
                                                                        CommandName="DeAct" CausesValidation="false" AlternateText="DeActivate" ToolTip = "Deactivate"/> 
                                                                        &nbsp;&nbsp;<img src="../../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                          
                                          
                                                  <asp:ImageButton ID="ImageButton_Delete" runat="server" ImageUrl="~/Images/Buttons/delete.png" CommandArgument='<%# Eval("AGENTCODE") %>' 
                                                                        CommandName="Delete" CausesValidation="false" AlternateText="Delete" OnClientClick='javascript:return confirm("This agent will be permanently deleted:Are you sure?")'  /> 
                                                     </ItemTemplate>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
