<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubscriberBillDisplay.aspx.cs"
    Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.SubscriberBillDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Details</title>
    <link rel="stylesheet" href="../../../CSS/InetBill.css" media="screen" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
             Subscriber Bill 
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    
                    <tr>
                        <td>
                            <cr:CrystalReportViewer ID="CrystalReportViewer1" DisplayGroupTree="false" HasCrystalLogo="False"
                                AutoDataBind="true" runat="Server" Width="100%" BestFitPage="False"></cr:CrystalReportViewer>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            <asp:DetailsView ID="_dvReceiptDetails" runat="server" AutoGenerateRows="False" GridLines="None"
                                HorizontalAlign="Left" Width="100%">
                                <Fields>
                                    <asp:BoundField DataField="USERID" HeaderText="UserID">
                                        <HeaderStyle Height="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RECEIPTID" HeaderText="Receipt ID">
                                        <HeaderStyle Height="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RECEIPTNUMBER" HeaderText="Physical Receipt Number">
                                        <HeaderStyle Height="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SPECIFICATIONS" HeaderText="Specifications">
                                        <HeaderStyle Height="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount(Rs.)">
                                        <HeaderStyle Height="30px" />
                                    </asp:BoundField>
                                </Fields>
                                <FieldHeaderStyle Width="35%" />
                            </asp:DetailsView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
