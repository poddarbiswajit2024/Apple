<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceRequestDetail.aspx.cs"
    Inherits="Apple_Bss.UI.NetworkManagement.ServiceRequestDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Request Details</title>
    <link rel="stylesheet" href="../../CSS/InetBill.css" media="screen" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">
                Detail of Service Call Record
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellspacing="0" cellpadding="0" align="center" width="650px" style="border: solid 1px #e5e5e5">
                    <tr>
                        <td class="tdStyle">
                            <asp:DetailsView ID="_dvServiceRequestDetail" runat="server" AutoGenerateRows="False"
                                Width="98%" GridLines="None" HorizontalAlign="Center">
                                <Fields>
                                    <asp:BoundField DataField="USERNAME" HeaderText="User Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ISSUEID" HeaderText="Issue Number &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ISSUE" HeaderText="Issue &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ISSUECAUSE" HeaderText="Cause of Issue &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ISSUETYPE" HeaderText="Type of Issue &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ASSIGNEDTOTECHSUPPORT" HeaderText="Assigned to &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="STARTDATETIME" HeaderText="Issue Reported Date :" DataFormatString="{0:dd-MMM-yyyy :HH:mm}">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ENDDATETIME" HeaderText="Issue Resolved Date :" DataFormatString="{0:dd-MMM-yyyy :HH:mm}">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Status &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:">
                                        <HeaderStyle Width="20%" Font-Bold="True" ForeColor="#fab10a" Height="30px" />
                                        <ItemStyle Width="80%" />
                                    </asp:BoundField>
                                </Fields>
                                <HeaderStyle Font-Bold="True" />
                            </asp:DetailsView>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtitle">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
