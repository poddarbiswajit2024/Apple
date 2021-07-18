<%@ Page Language="C#" MasterPageFile="~/UI/NetworkImplementation/NwImplementation.Master" AutoEventWireup="true" CodeBehind="DailyFiberMaintenance.aspx.cs" Inherits="Apple_Bss.UI.NetworkImplementation.DailyFiberMaintenance" Title="Fiber Maintenance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
  <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td colspan="2" valign="top" class="tdtitle">
                Fiber Maintenance
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle" width="20%">                           
                           Team Members
                           </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_txtTeam" runat="server" 
                                Width="300px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="_txtTeam" ErrorMessage="*Enter at least one Name"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                             Start Location</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_txtFrom" runat="server" CssClass="TextBoxBorder" 
                                Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="_txtFrom" ErrorMessage="*Fiber start location"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            End Location</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_txtTo" runat="server" CssClass="TextBoxBorder" 
                                Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="_txtTo" ErrorMessage="*Fiber End Location"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                            Date of maintenance</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_txtMaintenanceDate" runat="server" CssClass="TextBoxBorder" 
                                Width="250px"></asp:TextBox>
                            <cc1:CalendarExtender ID="_txtMaintenanceDate_CalendarExtender" runat="server"  CssClass="ajax__calendar"
                                Enabled="True" TargetControlID="_txtMaintenanceDate" Format="dd-MMMM-yyyy" 
                                PopupPosition="Right">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  CssClass="ajax__calendar"
                                ControlToValidate="_txtMaintenanceDate" ErrorMessage="*select Date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                           Work Status</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_txtStatus" runat="server" 
                                Width="300px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="_txtStatus" ErrorMessage="*Status of work cannot be Empty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                            &nbsp;</td>
                        <td class="tdgap">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle">
                           &nbsp;<asp:ImageButton ID="_imgBtnRegister" runat="server" 
                                ImageUrl="~/Images/Buttons/Register.jpg" onclick="_imgBtnRegister_Click" />
                            &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" 
                                ImageUrl="~/Images/Buttons/Refresh.jpg" onclick="_btnRefresh_Click" 
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</ContentTemplate>
</asp:UpdatePanel>  
  
</asp:Content>
