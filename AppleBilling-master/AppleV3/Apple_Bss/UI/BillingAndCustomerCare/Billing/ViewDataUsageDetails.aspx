<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewDataUsageDetails.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ViewDataUsageDetails"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Data Usage Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="tdgap" colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Select Payment Type
                                </td>
                                <td class="tdStyle" width="50%" colspan="2">
                                    <asp:DropDownList ID="_ddlPaymentType" runat="server" Height="22px" Width="160px"
                                        AutoPostBack="True" OnSelectedIndexChanged="_ddlPaymentType_SelectedIndexChanged">
                                        <asp:ListItem Value="">-Select Payment Type-</asp:ListItem>
                                        <asp:ListItem Value="M">MONTHLY</asp:ListItem>
                                        <asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                        <asp:ListItem Value="H">HALF YEARLY</asp:ListItem>
                                        <asp:ListItem Value="A">ANNUALLY</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_ddlPaymentType" ErrorMessage="* select payment type"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select Bill Cycle
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:DropDownList ID="_ddlBillCycleName" runat="server" Height="22px" Width="160px">
                                    </asp:DropDownList>
                                </td>
                                <td class="tdStyle" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Select Options
                                </td>
                                <td class="tdStyle" width="50%">
                                    <asp:RadioButtonList ID="_rbtnListDTUsage" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="100" Selected="True">100% and Above</asp:ListItem>
                                        <asp:ListItem Value="90">90%-99%</asp:ListItem>
                                        <asp:ListItem Value="75">75%-89%</asp:ListItem>
                                        <asp:ListItem Value="50">50%-74%</asp:ListItem>
                                        <asp:ListItem Value="0" >All</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="tdStyle" colspan="2" width="10%">
                                    <asp:ImageButton ID="_imgBtnViewDTUsage" runat="server" ImageUrl="~/Images/Buttons/View.jpg"
                                        OnClick="_imgBtnViewDTUsage_Click" />
                                </td>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle" >
                                
                                    <asp:Label ID="_lblMsgDisplay" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                        AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="False">
                                        <ProgressTemplate>
                                            <span style="font-weight: bold">Fetching DT Details... Please wait... </span>
                                        </ProgressTemplate>
                                        
                                    </asp:UpdateProgress></td>
                            
                            </tr>
 
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Data Transfer Details
                        </div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="tdStyle">
                                    <asp:GridView ID="_gvDataUsage" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CssClass="gridStyle" Width="100%" EmptyDataText="Sorry No data avaliable for display !!"
                                        GridLines="Horizontal" PageSize="50" 
                                        onpageindexchanging="_gvDataUsage_PageIndexChanging">
                                        <RowStyle Height="35px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="User ID">
                                                <ItemTemplate>
                                                <a href="javascript:PopupCenter('ViewDTUsageBreakup.aspx?uid=<%#Eval("USERID").ToString()%>&bcid=<%=bcID%>&pm=<%=pm%>','myPop1',1000,600);">
                                                    <%#Eval("USERID")%> 
                                                 </a>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Center" />
                                                <ItemStyle CssClass="gridLeftPad" Width="15%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Username" DataField="USERNAME">
                                                <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="center" />
                                                <ItemStyle CssClass="gridLeftPad" Width="15%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="DT Download" DataField="DOWNLOAD">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" Width="10%" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="DT Upload" DataField="UPLOAD">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Allocated DTF" DataField="DTA">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Total Used" DataField="TOTAL">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="DTF Available" DataField="AVAILABLEUSAGE">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Consumption">
                                                <ItemTemplate>
                                                    <%#Eval("CONSUMPTION") %> %
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeader" />
                                        <AlternatingRowStyle BackColor="#F1F1F1" />
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
