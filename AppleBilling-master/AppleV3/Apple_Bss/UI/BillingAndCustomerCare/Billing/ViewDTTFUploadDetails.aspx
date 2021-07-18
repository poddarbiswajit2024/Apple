<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master" AutoEventWireup="true" CodeBehind="ViewDTTFUploadDetails.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ViewDTTFUploadDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Data Usage Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="tdgap" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Select Month, Year
                                </td>
                                <td class="tdStyle" width="20%">
                                    <asp:DropDownList ID="_ddlMonth" runat="server" Height="22px" Width="160px">                                       
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="_ddlMonth" ErrorMessage="* "></asp:RequiredFieldValidator>
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_imgBtnViewDTFUploadDetails" runat="server" 
                                        ImageUrl="~/Images/Buttons/View.jpg" 
                                        onclick="_imgBtnViewDTFUploadDetails_Click" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:Label ID="_lblMsgDisplay" runat="server"></asp:Label>
                                </td>
                                <td class="tdgap" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Data Transfer Upload Details
                        </div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td class="tdStyle">
                                <asp:GridView ID="_gvSessionDataUpload" runat="server" AutoGenerateColumns="False"
                                        CssClass="gridStyle" Width="50%" EmptyDataText="Sorry No data avaliable for display !!"
                                        GridLines="Horizontal">
                                        <RowStyle Height="35px" />
                                        <Columns>
                                           
                                            <asp:BoundField HeaderText="Date of Upload" DataField="UPLOADDATE">
                                                <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="left" />
                                                <ItemStyle CssClass="gridLeftPad" Width="50%" HorizontalAlign="left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="No of Session" DataField="NOOFSESSION">
                                                <HeaderStyle CssClass="gridRightPad" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridRightPad" Width="50%" HorizontalAlign="Right" />
                                            </asp:BoundField>                                          
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeader" />
                                        <AlternatingRowStyle BackColor="#F1F1F1" />
                                    </asp:GridView>
                                    
                                 </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
