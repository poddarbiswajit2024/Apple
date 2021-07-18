<%@ Page Language="C#" MasterPageFile="~/UI/TechnicalSupport/DirectSupport/TechDirectSupport.Master"
    AutoEventWireup="true" CodeBehind="PendingSRConfirmationDirect.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.DirectSupport.PendingSRConfirmationDirect"
    Title="Pending SR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Service Request Pending Confirmation
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" cellspacing="0" cellpadding="0" align="left">
                    <tr>
                        <td class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            The SR No:
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                            &nbsp;has been generated. Please provide the client with this SR No. for future
                            references.
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
                    <tr>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
