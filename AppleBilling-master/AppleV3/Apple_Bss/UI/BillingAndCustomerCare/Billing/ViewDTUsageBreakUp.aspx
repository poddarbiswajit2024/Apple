<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDTUsageBreakUp.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ViewDTUsageBreakUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Subscrber Data Transfer Detaiuls</title>
      <link rel="Stylesheet" href="../../../CSS/InetBill.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td colspan="2" valign="top" class="tdtitle">
                &nbsp;Data Transfer Details for&nbsp;
               <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdStyle" style="padding-left:0px">
                             <asp:GridView ID="_gvDataTransferDetails" runat="server" 
                                AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" 
                                HorizontalAlign="Center" CssClass="gridStyle" 
                                EmptyDataText="record does not exist.." ShowFooter="True">
                                <RowStyle Height="30px" />
                            <Columns>
                                
                                <asp:BoundField DataField="CLIENTIP" HeaderText="Client IP Address">
                                    <ItemStyle Width="13%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SNATIP" HeaderText="SNAT IP Address">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                 </asp:BoundField>                                
                                <asp:BoundField DataField="STARTTIME" HeaderText="Start Time" DataFormatString="{0:dd MMM yyyy hh:mm:ss tt }">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="STOPTIME" HeaderText="Stop Time" DataFormatString="{0:dd MMM yyyy hh:mm:ss tt }">
                                     <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="USEDTIME" HeaderText="Used Time" FooterText="Total">
                                     <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <FooterStyle HorizontalAlign="Right" CssClass="gridRightPad" Font-Bold="True" />
                                </asp:BoundField>
                                  <asp:TemplateField HeaderText="Upload MB">
                                                        <ItemTemplate>
                                                            <%#Eval("UPLOADBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=totUploadData%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Download MB">
                                                        <ItemTemplate>
                                                            <%#Eval("DOWNLOADBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=totDownloadData%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Total MB">
                                                        <ItemTemplate>
                                                            <%#Eval("TOTALBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=TotalDataTransfer%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                              
                            </Columns>
                            <PagerStyle CssClass="gridPagerStyle" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                        </asp:GridView>
                         </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
