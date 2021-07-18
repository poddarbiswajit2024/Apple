<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="ServiceRequestsFixedList.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.ServiceRequestsFixedList"
    Title="SR Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Fixed Service Request List
                    </td>
                </tr>
             
                <tr>
                    <td class="tdgap">
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:GridView ID="_gvViewServiceRequestReport" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" OnPageIndexChanging="_gvViewServiceRequestReport_PageIndexChanging"
                                        PageSize="5" Width="100%" Style="padding-left: 10px" GridLines="None" 
                                        CssClass="gridStyle" EmptyDataText="No record Exist!...">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR Number">
                                                <ItemTemplate>
                                                    <a target="_parent" href="javascript:PopupCenter('ServiceRequestDetail.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);">
                                                        <%#Eval("issueid").ToString() %></a>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="User Name" DataField="USERNAME">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Issue Reported" DataField="ISSUE">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="25%" />
                                            </asp:BoundField>
                                      
                                            <asp:BoundField HeaderText="Reported On" DataField="STARTDATETIME" DataFormatString="{0:dd-MMM-yyyy  hh:mm }">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fixed On" DataField="ENDDATETIME" DataFormatString="{0:dd-MMM-yyyy:: hh:mm }">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
                                            </asp:BoundField>

                                                   <asp:BoundField HeaderText="Support Type" DataField="SUPPORTTYPE" DataFormatString="{0:dd-MMM-yyyy hh:mm }">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="12%" />
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
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
