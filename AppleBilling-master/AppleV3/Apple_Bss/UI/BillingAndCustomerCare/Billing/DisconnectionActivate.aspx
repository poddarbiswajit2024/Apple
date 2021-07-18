<%@ Page Title="Activate Temporary Disconnected Connection" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="DisconnectionActivate.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.DisconnectionActivate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    Re Activate Disconnected User
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellpadding="0" cellspacing="0" align="center" class="tableStyle">
                           
                            <tr>
                                <td class="tdStyle" colspan="2">
                                   &nbsp; <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                                <td class="backbtn">
                                    
                                    <%--<asp:ImageButton ID="_iBtnBack" runat="server" TabIndex="88" CausesValidation="False" ImageUrl="~/Images/Buttons/back.png"
                                        OnClick="_iBtnBack_Click" Style="margin-top: 5px" />--%>
                                </td>
                            </tr>

                            <tr>
                                <td width="20%" class="tdStyle">
                                    User ID &nbsp;
                                </td>
                                <td width="20%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>-SCLX<asp:TextBox ID="_txtUserID"
                                        runat="server" CssClass="TextBoxBorder" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_txtUserID"
                                        ErrorMessage="*" ValidationGroup="UserID"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="_txtUserID"
                                        ErrorMessage="*" ValidationGroup="Disconnect"></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle" width="60%">
                                    <asp:ImageButton ID="_btnGetUserDetails"  def  runat="server" ImageUrl="~/Images/Buttons/Get User Detail.jpg"
                                        OnClick="_btnGetUserDetails_Click"   ValidationGroup="UserID"  />
                                  
                                    </td>
                            </tr>
                            <tr>
                                <td width="20%" class="tdStyle">
                                    Subscriber Name
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_txtCustName" runat="server" BackColor="#ECE9D8" ReadOnly="True"
                                        Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    User Name
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="_txtUserName" runat="server" BackColor="#ECE9D8" CssClass="TextBoxBorder"
                                        Width="150px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td class="tdStyle" style="height: 27px">
                                    Status
                                </td>
                                <td colspan="2" class="tdStyle" style="height: 27px">
                                    <asp:TextBox ID="_txtStatus" runat="server" BackColor="#ECE9D8" CssClass="TextBoxBorder"
                                        ReadOnly="True" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Outstanding Amount
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtOutStanding" runat="server" BackColor="#ECE9D8" CssClass="TextBoxBorder"
                                        ReadOnly="True" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Reactivation&nbsp;Date
                                </td>
                                <td class="tdStyle">
                        
                                    <asp:TextBox ID="_txtStartDate" runat="server" CssClass="TextBoxBorder" Width="150px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False" PopupPosition="Right"
                                        TargetControlID="_txtStartDate" DaysModeTitleFormat="MMM"  CssClass="ajax__calendar"
                                        >
                                    </cc1:CalendarExtender>
                                </td>
                                <td width="15%" class="tdStyle">
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ControlToValidate="_txtStartDate" ErrorMessage="* Select Date" 
                                        ValidationGroup="Disconnect"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Set Arrear
                                </td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="_txtArrear" runat="server" CssClass="TextBoxBorder" Text="0" Width="150px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_txtArrear"
                                        ErrorMessage="* Enter Numbers Only" ValidationExpression="^\d{0,8}$"></asp:RegularExpressionValidator>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtArrear"
                                        ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Set Waiver
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtWaiver"  Text="0" runat="server" CssClass="TextBoxBorder" Width="150px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_txtWaiver"
                                        ErrorMessage="* Enter Numbers Only" ValidationExpression="^\d{0,8}$"></asp:RegularExpressionValidator>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_txtWaiver"
                                        ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Remarks
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtRemarks" runat="server" CssClass="TextBoxBorder" Height="60px"
                                        TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr >
                                <td colspan="3" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:ImageButton ID="_btnReactivate" runat="server" OnClick="_btnReactivate_Click"
                                        ImageUrl="~/Images/Buttons/Reactivate.jpg" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" OnClick="_btnRefresh_Click" 
                                    ImageUrl="~/Images/Buttons/Refresh.jpg" />
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
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
