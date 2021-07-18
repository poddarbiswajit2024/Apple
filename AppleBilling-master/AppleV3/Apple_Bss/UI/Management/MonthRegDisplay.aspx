<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthRegDisplay.aspx.cs" Inherits="Apple_Bss.UI.Management.MonthRegDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Month Wise Registration Report </title>
    <link rel="Stylesheet" href="../../CSS/InetBill.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td colspan="2" valign="top" class="tdtitle">
               Registration Report for &nbsp;
               <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdStyle" style="padding-left:0px">
                           
                            <asp:GridView ID="_gvMonthRegDisplay" runat="server" 
                                AutoGenerateColumns="False" GridLines="Horizontal" Width="100%">
                                <RowStyle CssClass="gridRowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="NAME" HeaderText="Sales Executive Name">
                                        <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" width="50%"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGISTRATIONS" HeaderText="Registrations">
                                        <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                        <ItemStyle CssClass="gridRightPad" HorizontalAlign="Right" width="50%" />
                                    </asp:BoundField>                                   
                                </Columns>
                                <HeaderStyle CssClass="gridHeader" />
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
