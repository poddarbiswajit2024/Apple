<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="ConnectionShifting.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.ConnectionShifting"
    Title="Connection Shifting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    Connection Shifting
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table width="100%" class="tableStyle" cellspacing="0" cellpadding="0">
                            
                            <tr>
                                <td colspan="3" class="tdStyle">
                                    &nbsp;<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Load User
                                </td>
                                <td width="23%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>
                                    -SCLX
                                    <asp:TextBox ID="_txtUserID" runat="server" Height="16px" Width="100px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="uid"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="all"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnLoadUser" ImageUrl="~/Images/Buttons/Load User.jpg" 
                                        runat="server" OnClick="_btnLoadUser_Click" ValidationGroup="uid" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    User Name
                                </td>
                                <td class="tdStyle" width="23%">
                                    <asp:TextBox ID="_txtUserName" runat="server" BackColor="#F2F2F2" 
                                        CssClass="TextBoxBorder" Height="16px" Width="170px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="_txtUserName" ErrorMessage="*" ValidationGroup="all"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    &nbsp;&nbsp;
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Current Installation Address
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtCurrentIstAddress" runat="server" Height="60px" ReadOnly="True"
                                        TextMode="MultiLine" Width="300px" BackColor="#ECECE6" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    New Installation Address
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtNewInstAddress" runat="server" Height="60px" TextMode="MultiLine"
                                        Width="300px" CssClass="TextBoxBorder"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtNewInstAddress"
                                        ErrorMessage="*Please Enter New Installation Address" ValidationGroup="all"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Select Connection Type
                                </td>
                                <td class="tdStyle" colspan="2" align="left">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" align="left">
                                        <tr>
                                            <td width="15%">
                                                <asp:RadioButtonList ID="_rbtnConnType" runat="server" Font-Bold="False" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="W">Wired</asp:ListItem>
                                                    <asp:ListItem Value="WL">Wireless</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td width="85%" class="tdStyle">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_rbtnConnType"
                                                    ErrorMessage="*Select Connection Type" Display="Dynamic" ValidationGroup="all"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:ImageButton ID="_btnPostInstAddress" ImageUrl="~/Images/Buttons/Update Address.jpg" runat="server" Height="25px" OnClick="_btnPostInstAddress_Click"
                                         ValidationGroup="all" />
                                    &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" OnClick="_btnRefresh_Click" />
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
