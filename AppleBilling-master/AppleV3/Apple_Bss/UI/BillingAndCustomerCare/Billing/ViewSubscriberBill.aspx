<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewSubscriberBill.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ViewSubscriberBill"
    Title="Subscriber Bill Display" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Subscriber Bill
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                            <tr>
                                <td class="tdStyle" colspan="4">
                                    
                                    <asp:Label ID="_lblValidUser" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Load User</td>
                                <td class="tdStyle" width="18%">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>
                                    -SCLX
                                    <asp:TextBox ID="_txtUserID" runat="server" Width="105px" 
                                        CssClass="TextBoxBorder" ValidationGroup="uid"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="uid"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle" width="15%">
                                    <asp:ImageButton ID="_btnGetBillNumber" runat="server" 
                                        ImageUrl="~/Images/Buttons/View.jpg" OnClick="_btnGetBillNumber_Click" 
                                        ValidationGroup="uid" />
                                   
                                </td>
                                <td class="tdView" width="50%" rowspan="2">
                                    <asp:Label ID="_lblName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="15%">
                                    User&nbsp; Name
                                </td>
                                <td class="tdStyle" width="18%">
                                    <asp:TextBox ID="_txtUserName" runat="server" BackColor="#F2F2F2" 
                                        CssClass="TextBoxBorder" ReadOnly="True" Width="175px"></asp:TextBox>
                                    &nbsp;
                                    </td>
                                <td class="tdStyle" width="15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="4">
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
                                <td class="tdStyle" colspan="4" style="padding-left: 0px">
                                    <asp:GridView ID="_gvBillDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                        GridLines="None" AllowPaging="True" PageSize="5" CssClass="gridStyle">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Bill Number">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('SubscriberBillDisplay.aspx?bnum=<%# Eval("billnumber").ToString()%>','myPop1',900,600);">
                                                        <%#Eval("BILLNUMBER").ToString() %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BILLCYCLEID" HeaderText="Bill Cycle ID">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BILLSTARTDATE" HeaderText="Bill Start Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BILLENDDATE" HeaderText="Bill End Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LASTDATEOFPAYMENT" HeaderText="Last Date of Payment" DataFormatString="{0:dd-MMM-yyyy}">
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PAYMENTMODE" HeaderText="Payment Mode">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTALOUTSTANDING" HeaderText="Amount">
                                                <HeaderStyle HorizontalAlign="Right" CssClass="gridRightPad" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="gridRightPad" />
                                            </asp:BoundField>
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
                <tr>
                    <td class="tdgap">
                    </td>
                </tr>
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
