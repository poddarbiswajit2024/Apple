<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Apple_Bss.ForgotPassword" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
   <%-- <head id="Head1" runat="server">--%>
     <title>Forgot Password - Apple BSS</title>
   <%-- <link href="../../CSS/InetBill.css" rel="Stylesheet" type="text/css" />--%>
     <link href="CSS/InetBill.css" rel="Stylesheet" type="text/css" />
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="mainTable">
                    <tr>
                        <td class="tdtitle" valign="top">Forgot Password </td>
                    </tr>
                    <tr>
                        <td class="mainTD">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                         
                                <tr>
                                    <td class="tdStyle" colspan="2" style="height: 10px">
                                        <strong>   Enter your UserID and Email ID in order to reset your password.
                                        
                                    
                                        <br />
                                        <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="Red"></asp:Label>
                                        <br /> </strong></td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" width="35%">User ID</td>
                                    <td class="tdStyle" width="65%">
                                       <asp:TextBox ID="_tbUserID" runat="server" AutoCompleteType="FirstName"  Height="16px" MaxLength="50"  Width="145px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbUserID" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">Email ID </td>
                                    <td class="tdStyle">
                                        <asp:TextBox ID="_tbRegisteredEmail" CssClass="txtBox"  runat="server" Height="16px" MaxLength="50" Width="145px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbRegisteredEmail" ErrorMessage="Required Field. Cannot be left empty">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <caption>
                                    <br />
                                    <tr>
                                        <td class="tdStyle">&nbsp; </td>
                                        <td class="tdStyle">
                                            <asp:ImageButton ID="_btnSubmit" runat="server" ImageUrl="~/Images/Buttons/Submit.jpg" OnClick="_btnChangePassword_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdStyle" style="width: 225px">&nbsp; </td>
                                        <td class="tdStyle">&nbsp; </td>
                                    </tr>
                                </caption>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
      
    </form>
      
    