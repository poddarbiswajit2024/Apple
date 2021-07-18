<%@ Page Language="C#" MasterPageFile="~/UI/NetworkImplementation/NwImplementation.Master" AutoEventWireup="true" CodeBehind="Reg_UserConnectivityDetails.aspx.cs" Inherits="Symb_InetBill.UI.NetworkImplementation.Reg_UserConnectivityDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>    
        <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
                <tr>
                    <td colspan="2" valign="top" class="tdtitle">
                        Register User Connectivity Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD" valign="top">
                        <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                           <tr>
                               <td class="tdStyle" colspan="3">
                               
                                   <asp:Label ID="_lblMsg" runat="server" ForeColor="#009900"></asp:Label>&nbsp;
                               
                               </td>
                           </tr>
                           <tr>
                               <td class="tdStyle" width="20%">
                               Select User
                                </td>
                               <td class="tdStyle" width="30%" >
                               
                                   <asp:DropDownList ID="_ddlUserName" runat="server" Height="22px" Width="200px" 
                                       onselectedindexchanged="_ddlUserName_SelectedIndexChanged" 
                                       AutoPostBack="True">
                                   </asp:DropDownList>
                               </td>
                               <td class="tdStyle" width="50%">
                               
                                   <asp:Label ID="_lblSelectedUser" runat="server"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td class="tdStyle" width="20%">
                                   Select Connection POP</td>
                               <td class="tdStyle" width="20%" >
                               
                                   <asp:DropDownList ID="_ddlPopName" runat="server" Height="22px" Width="200px" 
                                       onselectedindexchanged="_ddlPopName_SelectedIndexChanged" 
                                       AutoPostBack="True">
                                   </asp:DropDownList>
                               </td>
                               <td class="tdStyle" width="60%">
                               
                                   <asp:Label ID="_lblSelectedPOP" runat="server"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td class="tdStyle" width="20%">
                                   Connectivity Details</td>
                               <td class="tdStyle" width="20%" >
                               
                                   <asp:TextBox ID="_txtConDetails" runat="server" CssClass="TextBoxBorder" 
                                       Width="300px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                               </td>
                               <td class="tdStyle" width="60%">
                               
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                       ErrorMessage="* Enter connectivity Details" 
                                       ControlToValidate="_txtConDetails"></asp:RequiredFieldValidator>
                               </td>
                           </tr>
                           <tr class="tdgap">
                               <td class="tdgap" width="20%">
                                   &nbsp;</td>
                               <td class="tdgap" width="20%" >
                               
                                   &nbsp;</td>
                               <td class="tdgap" width="60%">
                               
                                   &nbsp;</td>
                           </tr>
                           <tr>
                               <td class="tdStyle" width="20%">
                                   &nbsp;</td>
                               <td class="tdStyle" width="20%" >
                               
                                   <asp:ImageButton ID="_imbBtnRegister" runat="server" 
                                       ImageUrl="~/Images/Buttons/Register.jpg" onclick="_imbBtnRegister_Click" />
                                   &nbsp;
                                   <asp:ImageButton ID="_imgBtnRefresh" runat="server" CausesValidation="False" 
                                       ImageUrl="~/Images/Buttons/Refresh.jpg" onclick="_imgBtnRefresh_Click" />
                               </td>
                               <td class="tdStyle" width="60%">
                               
                                   &nbsp;</td>
                           </tr>
                           <tr>
                               <td class="tdStyle" width="20%">
                                   &nbsp;</td>
                               <td class="tdStyle" width="20%" >
                               
                                   &nbsp;</td>
                               <td class="tdStyle" width="60%">
                               
                                   &nbsp;</td>
                           </tr>
                        </table>
                    </td>
                </tr>
            </table>
 </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
