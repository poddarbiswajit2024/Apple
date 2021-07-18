<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="Apple_Bss.PasswordChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Password - Apple BSS</title>
    <link rel="Stylesheet" href="CSS/InetBill.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
            <tr>	
            <td style="background:white; height:70px; padding-left:10px; border-bottom: 0px solid silver"  >
            <img alt="" src="Images/Logo/logo-a.bmp" style="width: 140px" />
            </tr>
            <tr>
                <td class="tdtitle" valign="top">Change Password </td>
            </tr>
            <tr>
                <td class="mainTD">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                        <tr>
                            <td class="tdStyle" colspan="2"><asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="Red"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">User ID</td>
                            <td class="tdStyle" style="height:22px">
                                <asp:Label ID="_lblUserID" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                 
                        <tr>
                            <td class="tdStyle">Enter New Password </td>
                            <td class="tdStyle">
                                <asp:TextBox ID="_tbNewPassword" runat="server" Height="16px" MaxLength="50" TextMode="Password" Width="145px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbNewPassword" ErrorMessage="Required Field. Cannot be left empty">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">Confirm New Password </td>
                            <td class="tdStyle">
                                <asp:TextBox ID="_tbConfirmNewPassword" runat="server" Height="16px" MaxLength="50" TextMode="Password" Width="145px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_tbConfirmNewPassword" ErrorMessage="Required Field. Cannot be left empty">*</asp:RequiredFieldValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle" style="width: 225px">&nbsp; </td>
                            <td class="tdStyle">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="_tbNewPassword" ControlToValidate="_tbConfirmNewPassword" ErrorMessage="New passwords do not match!"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">&nbsp; </td>
                            <td class="tdStyle">
                                <asp:ImageButton ID="_btnChangePassword" runat="server" ImageUrl="~/Images/Buttons/Submit.jpg" OnClick="_btnChangePassword_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle" style="width: 225px">&nbsp; </td>
                            <td class="tdStyle">&nbsp; </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </caption>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
