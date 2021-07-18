<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="ViewSubscriberFirstBill.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ViewSubscriberFirstBill"
    Title="Subscriber First Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Subscriber First Bill
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <div>
                    <cr:CrystalReportViewer ID="CrystalReportViewer1" DisplayGroupTree="false" HasCrystalLogo="False"
                        AutoDataBind="true" runat="Server" Width="350px" Height="50px"></cr:CrystalReportViewer>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
