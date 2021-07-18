<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePendingSRDirect.aspx.cs"
    Inherits="Apple_Bss.UI.NetworkManagement.UpdatePendingSRDirect" %>

<%@ Register Src="Control/HistoryAction.ascx" TagName="HistoryAction" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Requests</title>
    <link rel="stylesheet" href="../../CSS/InetBill.css" media="screen" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table align="center" cellpadding="0" cellspacing="0" width="100%" border="0" bgcolor="White">
        <tr>
            <td>
                <uc1:HistoryAction ID="_actionHistory" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
