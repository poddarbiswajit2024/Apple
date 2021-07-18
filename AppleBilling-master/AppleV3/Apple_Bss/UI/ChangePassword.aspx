<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Apple_Bss.UI.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Password - Apple BSS</title>
    <link rel="Stylesheet" href="../CSS/InetBill.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td valign="top" class="tdtitle">
                Change Password
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" colspan="2" style="height: 22px" >
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="Red"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" width="35%">
                            Current Password
                        </td>
                        <td class="tdStyle" width="65%">
                            <asp:TextBox ID="_tbCurrentPassword" runat="server" AutoCompleteType="FirstName"
                                CssClass="WaterMarkedTextBox" MaxLength="50" TextMode="Password" Width="145px"
                                Height="16px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="_tbCurrentPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            New Password
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbNewPassword" runat="server" MaxLength="50" TextMode="Password"
                                Width="145px" Height="16px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="_tbNewPassword" 
                                ErrorMessage="Required Field. Cannot be left empty">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Confirm New Password
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbConfirmNewPassword" runat="server" MaxLength="50" TextMode="Password"
                                Width="145px" Height="16px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="_tbConfirmNewPassword" 
                                ErrorMessage="Required Field. Cannot be left empty">*</asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 225px" class="tdStyle">
                            &nbsp;
                        </td>
                        <td class="tdStyle">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="_tbNewPassword"
                                ControlToValidate="_tbConfirmNewPassword" 
                                ErrorMessage="New passwords do not match!"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnChangePassword" ImageUrl="~/Images/Buttons/Change Password .jpg"
                                runat="server" OnClick="_btnChangePassword_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 225px" class="tdStyle">
                            &nbsp;
                        </td>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
