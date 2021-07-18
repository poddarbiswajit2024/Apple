<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="CSVFileUpload.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.CSVFileUpload"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    Upload CSV File
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table cellpadding="0" cellspacing="0" class="tableStyle">
                            
                            <tr class="tdStyle">
                                <td colspan="2" class="tdStyle">
                                    &nbsp;<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                            
                            
                            
                            
                            
                            
                            <tr>
                                <td class="tdStyle" style="width: 20%">
                                    Select CSV File</td>
                                <td class="tdStyle">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
                                 &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="FileUpload1" ErrorMessage="File is required"></asp:RequiredFieldValidator>
                                 
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="ibtnUpload" runat="server" 
                                        ImageUrl="~/Images/Buttons/Submit.jpg" onclick="ibtnUpload_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" colspan="2">
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
     
        
  
</asp:Content>
