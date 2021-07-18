<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="ConfirmConnection.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ConfirmConnection"
    Title="Confirm Connection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                New User Connection Confirmation
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellpadding="0" cellspacing="0" class="tableStyle">
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            <span style="color: Red; font-weight: bold">New user successfully created.</span>
                            <br />
                            <br />
                            The first bill with Bill Number:
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            &nbsp;has been successfully raised.
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
