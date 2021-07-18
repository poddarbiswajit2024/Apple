<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master" AutoEventWireup="true" CodeBehind="ManagePendingUserRegistrationsAll.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.ManagePendingUserRegistrationsAll"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
               Manage Pending User Registrations
            </td>
        </tr>
     
        <tr>
            <td class="tdgap">
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                    <tr>
                        <td class="tdStyle">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:Label ID="lblReportMsg" runat="server" Font-Size ="9pt" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="_gvPendingConnection" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    EmptyDataText="No registered subscribers exist for the given conditions." OnPageIndexChanging="_gvPendingConnection_PageIndexChanging"
                                                    OnRowCommand="_gvPendingConnection_RowCommand" OnRowDeleting="_gvPendingConnection_RowDeleting" Width="100%" GridLines="None" CssClass="gridStyle">
                                                    <Columns>
                                                        <asp:BoundField DataField="NAME" HeaderText=" Registered Name">
                                                            <ItemStyle Width="15%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EMAILID" HeaderText="Email ID">
                                                            <ItemStyle Width="12%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BILLPLAN" HeaderText="Bill Plan">
                                                            <ItemStyle Width="28%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MOBILENUMBER" HeaderText="Mobile Number">
                                                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                              </asp:BoundField>
                                                                     <asp:BoundField DataField="MODON" DataFormatString="{0: dd-MMM-yy}" HeaderText="Uploaded Date">
                                                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                                        
                                                         <HeaderStyle HorizontalAlign="Center" />

                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>

                                                                                                                                   <a href='EditRegistration.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                        <img alt="Edit" title="edit" src="../../../Images/Buttons/edit.png" style="border: 0" /></a>
                                                    &nbsp;&nbsp;<img src="../../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;
                                                                
                                                                   <a href='UserRegistrationDocuments.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                        <img alt="Update documents" title="update documents" src="../../../Images/Buttons/documents.png" style="border: 0" /></a>
                                                    &nbsp;&nbsp;<img src="../../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;

                                                                  <a href='UpdateUserRegistrationDocuments.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                        <img alt="Update document one " width="22" title="update document one by one" src="../../../Images/Buttons/doc-one.png" style="border: 0" /></a>
                                                    &nbsp;&nbsp;<img src="../../../Images/Buttons/dots.gif" border="0" />&nbsp;&nbsp;

                                                                <asp:ImageButton ID="ImageButton_Delete" runat="server" AlternateText="Delete" CausesValidation="false"
                                                                    CommandArgument='<%# Eval("USERID") %>' CommandName="Delete" ImageUrl="~/Images/Buttons/delete.png"
                                                                    OnClientClick="javascript:return confirm('This user will be permanently deleted.Are you sure?')"
                                                                    ToolTip="Delete" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="26%" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <PagerStyle CssClass="gridPagerStyle" />
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                                    <AlternatingRowStyle CssClass="gridAltRow" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                           
                            </asp:UpdatePanel>
                        </td>
                    </tr>
               
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
                            &nbsp;</td>
        </tr>
    </table>
</asp:Content>