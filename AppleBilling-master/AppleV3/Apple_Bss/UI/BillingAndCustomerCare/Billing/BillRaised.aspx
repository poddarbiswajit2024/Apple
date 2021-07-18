<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="BillRaised.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.BillRaised"
    Title="Bill Raised" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Raise Bill
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellspacing="0" cellpadding="0" align="left" class="tableStyle" border="0">
                    <tr>
                        <td class="tdStyle" width="20%">
                            &nbsp;&nbsp;
                            </td>
                        <td class="tdStyle" width="60%">
                            <asp:Label ID="_lblMsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                                ForeColor="Maroon"></asp:Label>
                        </td>
                        <td class="backbtn" width="20%">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Buttons/back.png"
                                PostBackUrl="~/UI/BillingAndCustomerCare/Billing/BillToBeRaised.aspx" 
                                CausesValidation="False"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Customer Name
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbCustomerName" runat="server" AutoCompleteType="FirstName" MaxLength="50"
                                 ReadOnly="True" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Connection Date
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbConnDate" runat="server" Width="200px" CssClass="TextBoxBorder"
                                BackColor="#F6F6F6" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Username
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbUserName" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder" ReadOnly="True"                                 ></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbUserName"
                                ErrorMessage="Required Field. Cannot be left empty" Display="Dynamic" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            OTRC Discount
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbOTRCDiscount" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="_tbOTRCDiscount" ErrorMessage="You can enter numbers only"
                                SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Security Deposit Waiver
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbSecuriityDepositWaiver" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="_tbSecuriityDepositWaiver" ErrorMessage="You can enter numbers only"
                                SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Other Waivers
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbOtherWaivers" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="_tbOtherWaivers" ErrorMessage="You can enter numbers only"
                                SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Persistent Waiver
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbPersistentWaiver" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="_tbPersistentWaiver"
                                ErrorMessage="You can enter numbers only" SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Extra OFC Length
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbExtraOFCLength" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                ControlToValidate="_tbExtraOFCLength" ErrorMessage="You can enter numbers only"
                                SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Extra CAT5e/CAT6 Length
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbExtraCAT5Length" runat="server" MaxLength="20" Width="200px" CssClass="TextBoxBorder">0</asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                ControlToValidate="_tbExtraCAT5Length" ErrorMessage="You can enter numbers only"
                                SetFocusOnError="True" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                        <tr>
                                                                         <td class="tdStyle" style="width: 9%">
                                                                             User GSTIN</td>
                                                      <td class="tdStyle">
                                                      <asp:TextBox ID="_txtUserGSTIN" runat="server" Width="200px" BackColor="#F6F6F6" ReadOnly="True"></asp:TextBox>
                                                          
                                                          </td>
                                                                    </tr>
                    
                    <tr>
                        <td class="tdgap">
                        </td>
                        &nbsp;
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:ImageButton ID="_btnConnect" ImageUrl="~/Images/Buttons/Submit Bill.jpg" 
                                runat="server"  OnClick="_btnConnect_Click" style="height: 25px"/>
                            &nbsp;
                            <asp:ImageButton ID="_btnRefresh" ImageUrl="~/Images/Buttons/Refresh.jpg" runat="server" OnClick="_btnRefresh_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
   
</asp:Content>
