<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master" AutoEventWireup="true" CodeBehind="PermanentDisconnection.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.PermanentDisconnection" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Permanent Disconnection
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellpadding="0" cellspacing="0">
                           
                            <tr class="tdStyle">
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
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
                                    <asp:ImageButton ID="_btnGetUserDetails" runat="server" ImageUrl="~/Images/Buttons/Get User Detail.jpg"
                                        OnClick="_btnGetUserDetails_Click" ValidationGroup="UserID"  />
                                  
                                    </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    User Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtUserName" runat="server" Width="150px" ReadOnly="True" BackColor="#ECE9D8"
                                        CssClass="TextBoxBorder"></asp:TextBox>
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
                                    Customer Name
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtCustomerName" runat="server" Width="150px" BackColor="#ECE9D8"
                                        CssClass="TextBoxBorder" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Bill Plan
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtBillPlan" runat="server" Width="300px" BackColor="#ECE9D8" CssClass="TextBoxBorder"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Payment Mode
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:TextBox ID="_txtPaymentMode" runat="server" BackColor="#ECE9D8" CssClass="TextBoxBorder"
                                        ReadOnly="True" Width="150px"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="height: 27px">
                                    Outstanding Amount
                                </td>
                                <td colspan="2" class="tdStyle" style="height: 27px">
                                    <asp:TextBox ID="_txtOutStanding" runat="server" BackColor="#ECE9D8" Width="150px"
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                         
                      
                            <tr>
                                <td class="tdStyle">
                                    Disconnection&nbsp;Date
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
                                    Upload Scanned Application Form</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:FileUpload ID="FileUpload1" CssClass="NormalTextBox" runat="server" 
                                        Width="367px" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="FileUpload1"  
                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.jpeg|.png|.gif)$"  
                                        ErrorMessage="only image files are allowed. jpg,png,gif"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Remarks(Reasons for permanent disconnection)</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:TextBox ID="tbReasons" runat="server" CssClass="NormalTextBox" TextMode="MultiLine" Width="367px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2" class="tdStyle">
                                    <asp:ImageButton ID="_btnTempDisconect" runat="server" OnClick="_btnTempDisconect_Click"
                                        ValidationGroup="Disconnect" ImageUrl="~/Images/Buttons/Disconnect .jpg"/>
                                    &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" OnClick="_btnRefresh_Click" />
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
        <Triggers>
        <asp:PostBackTrigger ControlID="_btnTempDisconect" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
