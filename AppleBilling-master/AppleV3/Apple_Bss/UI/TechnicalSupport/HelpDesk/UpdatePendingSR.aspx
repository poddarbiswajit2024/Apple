<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePendingSR.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.UpdatePendingSR" %>

<%@ Register src="../Controls/ActionHistory.ascx" tagname="ActionHistory" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Update Pending Service Request</title>
    <link rel="Stylesheet" href="../../../CSS/InetBill.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" align="center" width="100%">
    <tr><td>
    
        <uc1:ActionHistory ID="_actionHistory" runat="server" />
    
        </td>
    </tr>
</table>
</ContentTemplate>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
