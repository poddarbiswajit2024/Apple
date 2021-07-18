<%@ Page Title="Pending SR" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="PendingSRConfirmation.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.PendingSRConfirmation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Service Request Pending Confirmation
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" cellspacing="0" cellpadding="0" align="left" border="0">
                    <tr>
                        <td class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            The SR No:
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                            &nbsp;has been generated.  An sms with this service request number has been sent to the client's registered mobile number&nbsp; 
                            notifying that the request will be rectified within 6 working hours.
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
                            &nbsp;
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
