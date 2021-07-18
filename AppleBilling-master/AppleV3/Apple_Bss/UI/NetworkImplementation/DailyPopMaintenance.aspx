<%@ Page Language="C#" MasterPageFile="~/UI/NetworkImplementation/NwImplementation.Master" AutoEventWireup="true" CodeBehind="DailyPopMaintenance.aspx.cs" Inherits="Apple_Bss.UI.NetworkImplementation.DailyPopMaintenance" Title="Pop Maintenance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
  <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td valign="top" class="tdtitle">
                Daily POP Maintenance
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td class="tdStyle" colspan="3">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" width="20%">
                            Select POP Name</td>
                        <td class="tdStyle" width="30%">
                            <asp:DropDownList ID="_ddlPopName" runat="server" Height="22px" Width="200px" CssClass="EntryBoxBorder" 
                                AutoPostBack="True" 
                                onselectedindexchanged="_ddlPopName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblPopName" runat="server"></asp:Label>
                                            </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">                           
                            Manual Meter Charge</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtMeterCharge" runat="server" CssClass="TextBoxBorder" 
                                Width="200px" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Battery Status Cell wise</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtBatteryStatus" runat="server" 
                                Rows="3" TextMode="MultiLine" Width="250px" CssClass ="EntryBoxBorder" 
                                MaxLength="250"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Inverter Charging Status</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtInverterCharge" runat="server" CssClass="TextBoxBorder" 
                                Width="200px" MaxLength="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                            Replacement Details</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtReplacement" runat="server" CssClass="EntryBoxBorder" 
                                Width="200px" TextMode="MultiLine" MaxLength="500" Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                            Date of maintenance</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtMaintenanceDate" runat="server" CssClass="TextBoxBorder" 
                                Width="200px"></asp:TextBox>
                            <cc1:CalendarExtender ID="_txtMaintenanceDate_CalendarExtender" runat="server"  CssClass="ajax__calendar"
                                Enabled="True" TargetControlID="_txtMaintenanceDate" Format="dd-MMMM-yyyy" 
                                PopupPosition="Right">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="_txtMaintenanceDate" ErrorMessage="*select Date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Remarks</td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_txtRemarks" runat="server" TextMode="MultiLine" CssClass="EntryBoxBorder"
                                Width="250px" MaxLength="1000" Rows="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                            &nbsp;</td>
                        <td class="tdgap" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle" colspan="2">
                            <asp:ImageButton ID="_imgBtnRegister" runat="server" 
                                ImageUrl="~/Images/Buttons/Register.jpg" onclick="_imgBtnRegister_Click" />
                           &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" 
                                ImageUrl="~/Images/Buttons/Refresh.jpg" onclick="_btnRefresh_Click" 
                                CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle" colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</ContentTemplate>
</asp:UpdatePanel>  
  
</asp:Content>
