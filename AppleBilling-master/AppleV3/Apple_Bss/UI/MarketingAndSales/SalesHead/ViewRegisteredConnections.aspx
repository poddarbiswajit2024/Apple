<%@ Page Title="Registered Subscribers" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master"
    AutoEventWireup="true" CodeBehind="ViewRegisteredConnections.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.ViewRegisteredConnections" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Registered Broadband Subscribers
            </td>
        </tr>
        <tr>
            <td class="mainTD">
             <asp:UpdatePanel ID="upSalesPeople" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                            <ContentTemplate>
                          
                <table class="tableStyle" cellpadding="0" cellspacing="0" align="center" border="0">
                    <tr>
                        <td colspan="3" class="tdgap">
                        </td>
                        <a href="EditRegistration.aspx">EditRegistration.aspx</a>
                    </tr>
                    <tr>
                        <td class="tdStyle" width="13%">
                            Select Status
                        </td>
                        <td class="tdStyle">
                            <asp:RadioButtonList ID="_rbtnStatus" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="ALL" Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="A">Activated</asp:ListItem>
                                <asp:ListItem Value="C">Connected</asp:ListItem>
                                <asp:ListItem Value="P">Pending</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                     
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Registered By
                        </td>
                        <td class="tdStyle" width="25%">                            
                            <asp:RadioButtonList ID="rblSalesPpl" runat="server" 
                                RepeatDirection="Horizontal" 
                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                AutoPostBack="True">                                
                                 <asp:ListItem Value="E">Executive</asp:ListItem>
                                <asp:ListItem Value="A">Agent</asp:ListItem>
                                <asp:ListItem  Value="B">Both</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="tdStyle" > 
                       
                            <asp:DropDownList ID="_ddlSalesExecutive" runat="server" 
                                    AppendDataBoundItems="True" CssClass="TextBoxBorder" Height="22px" 
                                    AutoPostBack="True" Enabled="false"
                                    onselectedindexchanged="_ddlSalesExecutive_SelectedIndexChanged"> 
                                <asp:ListItem  Value="" Selected="True"> -- select executive --</asp:ListItem>
                                <asp:ListItem  Value="A" >All Executives</asp:ListItem>
                                
                            </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="_ddlAgents" runat="server" AppendDataBoundItems="True" 
                                    CssClass="TextBoxBorder" Height="22px" AutoPostBack="True" 
                                    Enabled="False" onselectedindexchanged="_ddlAgents_SelectedIndexChanged"> 
                                  <asp:ListItem  Value="" Selected="True"> -- select agent --</asp:ListItem>
                                  <asp:ListItem  Value="A" >All Agents</asp:ListItem>
                            </asp:DropDownList>  
                                &nbsp;<asp:RequiredFieldValidator ID="rfvExec" 
                                    ControlToValidate="_ddlSalesExecutive" Text ="Select executive" runat="server" 
                                    ErrorMessage="" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>                                                      
                            
                                <asp:RequiredFieldValidator ID="rfvAgent" ControlToValidate="_ddlAgents" 
                                    Text ="Select agent" runat="server" ErrorMessage="" 
                                    Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>                                                      
                          
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblSalesPpl"
                                ErrorMessage="Select registered by" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Dates</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtStartDate" runat="server" Width="150px" 
                                CssClass="TextBoxBorder" />
                            <cc1:TextBoxWatermarkExtender ID="_txtStartDate_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="_txtStartDate" 
                                WatermarkText=" -- select start date --">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Monday"  CssClass="ajax__calendar"
                                PopupPosition="Right" TargetControlID="_txtStartDate" Format="dd MMMM yyyy">
                            </cc1:CalendarExtender>
                            &nbsp;to
                            <asp:TextBox ID="_txtEndDate" runat="server" CssClass="TextBoxBorder" 
                                Width="150px" />
                            <cc1:TextBoxWatermarkExtender ID="_txtEndDate_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="_txtEndDate" 
                                WatermarkText=" -- select end date -- ">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  CssClass="ajax__calendar"
                                FirstDayOfWeek="Monday" Format="dd MMMM yyyy" PopupPosition="Right" 
                                TargetControlID="_txtEndDate">
                            </cc1:CalendarExtender>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="_txtStartDate" Display="Dynamic" 
                                ErrorMessage="Select start date"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="_txtEndDate" ErrorMessage="Select end date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr class="tdgap">
                        <td colspan="3" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 150px">
                            &nbsp;
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:ImageButton ID="_btnShowReport" runat="server" 
                                OnClick="_btnShowReport_Click" ImageUrl="~/Images/Buttons/Show Report.jpg" 
                                Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                    </ContentTemplate>                            
                            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                    <tr>
                        <td class="tdStyle">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:Label ID="lblReportMsg" runat="server" Font-Size ="9pt" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="_gvPendingConnection" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    EmptyDataText="No registered subscribers exist for the given conditions." OnPageIndexChanging="_gvPendingConnection_PageIndexChanging"
                                                    OnRowCommand="_gvPendingConnection_RowCommand" OnRowDeleting="_gvPendingConnection_RowDeleting"
                                                    PageSize="5" Width="100%" GridLines="None" CssClass="gridStyle">
                                                    <Columns>
                                                        <asp:BoundField DataField="NAME" HeaderText=" Subscriber Name">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EMAILID" HeaderText="Email ID">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                            <ItemStyle Width="30%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton_Delete" runat="server" AlternateText="Delete" CausesValidation="false"
                                                                    CommandArgument='<%# Eval("USERID") %>' CommandName="Delete" ImageUrl="~/Images/Buttons/delete.png"
                                                                    OnClientClick="javascript:return confirm('This user will be permanently deleted.Are you sure?')"
                                                                    ToolTip="Delete" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="16%" />
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
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_btnShowReport" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr><td>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:GridView ID="_gvRegReport" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                 EmptyDataText="No registered subscribers exist for the given conditions." OnPageIndexChanging="_gvRegReport_PageIndexChanging"
                                                 PageSize="5"  Width="100%" GridLines="None" CssClass="gridStyle">
                                                 <Columns>
                                                        <asp:BoundField DataField="NAME" HeaderText=" Subscriber Name">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EMAILID" HeaderText="Email ID">
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                            <ItemStyle Width="30%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>  
                                                          
                                                                                                                
                                               </Columns>
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <PagerStyle CssClass="gridPagerStyle" />
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                    <AlternatingRowStyle CssClass="gridAltRow" />
                        </asp:GridView>
                     </ContentTemplate>
                     <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_btnShowReport" />
                                </Triggers>
                     </asp:UpdatePanel>
                    </td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
                            &nbsp;</td>
        </tr>
    </table>
</asp:Content>
