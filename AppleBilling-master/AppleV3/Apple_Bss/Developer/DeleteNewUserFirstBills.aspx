<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteNewUserFirstBills.aspx.cs" Inherits="Apple_Bss.Developer.DeleteNewUserFirstBills" %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
      <div class="tdSubtitle">
                            Subscriber Details</div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">
                                    </asp:Label>&nbsp;
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="tdStyle" style="width: 15%">
                                    
                                    &nbsp;</td>
                                <td class="tdStyle" style="width: 85%">
                               
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 8%">
                                  
                              
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 15%">
                                    UserID</td>
                                <td class="tdStyle" style="width: 85%">
                         
                                    <asp:Label ID="lblBranchCode" runat="server" Text="">
                                    </asp:Label>-SCLX<asp:TextBox ID="tbUserId" runat="server" AutoPostBack="True" ontextchanged="tbUserId_TextChanged" 
                                        ></asp:TextBox>
                    
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblDetails" Visible="true" runat="server" Text="UserName"></asp:Label>&nbsp;
                                </td>
                                <td class="tdStyle">
                              <asp:HiddenField ID="hdnUserID" runat="server" />
                                                                <asp:Literal ID="litUsername" runat="server"></asp:Literal>                                                                
                                                           
                                                          
                                    
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
        <asp:Button ID="btnDelete" runat="server" Text="Delete first bills ofthe selected new user" OnClick="btnDelete_Click" />
    </form>
</body>
</html>
