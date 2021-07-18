<%@ Page Title="" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master" AutoEventWireup="true" CodeBehind="UpdateUserPOPDetails.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.UpdateUserPOPDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Update Subscriber Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="3" class="tdStyle">
                                   &nbsp; <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" CssClass="lblSuccess"></asp:Label>
                                </td>
                            </tr>
                           
                            <tr>
                                <td width="20%" class="tdStyle">
                                   User ID*</td>
                              <td width="20%" class="tdStyle">
                                    <asp:Label ID="_lblBc" runat="server"></asp:Label>
                                    -SCLX
                                    <asp:TextBox ID="_txtUserID" runat="server" CssClass="TextBoxBorder" AutoPostBack="True" 
                                        Width="100px" OnTextChanged="_txtUserID_TextChanged" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_txtUserID" ErrorMessage="*" ValidationGroup="uid"></asp:RequiredFieldValidator>
                                   <Triggers>
    
    
    </Triggers>
                                </td>
                               
                               
                            </tr>
                          <td class="tdStyle">POP Name*</td>
                                <td class="tdStyle" colspan="3">
                                    <asp:DropDownList ID="_ddlPopName" runat="server" CssClass="EntryBoxBorder" Height="22px"  Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""> Select POP Name</asp:ListItem>                                     

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_ddlPopName" Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                     
                                </td>
                            
                             <tr>
                                  <td class="tdStyle">Connection Type Used</td>
                                  <td class="tdStyle" colspan="3">
                                 <asp:Label ID="_lblConnectionType" runat="server" Text=""></asp:Label> 
                         
                                </td>
                               
                               
                            </tr>
                             <tr>
                                <td class="tdStyle">Change Connection Type*</td>
                                <td class="tdStyle" colspan="3">
                                  
                                    <asp:DropDownList ID="ddlConnectionType" runat="server" CssClass="EntryBoxBorder" Height="22px"  Width="250px" AppendDataBoundItems="True">
                                         <asp:ListItem Value=""> Select Connection Type</asp:ListItem>   
             
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlConnectionType" Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                
                                </td>
                            </tr>

                             <tr>
                                <td class="tdStyle">Connection Details</td>
                                <td class="tdStyle" colspan="3">
                                    <asp:TextBox ID="tbConnectionDetails" runat="server" AutoCompleteType="FirstName" CssClass="TextBoxBorder" MaxLength="50" TextMode="MultiLine" Width="302px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    &nbsp;
                                </td>
                                <td colspan="2" class="tdStyle">

                                    <asp:ImageButton ID="_btnUpdatePOPDetails" runat="server" CausesValidation="false" OnClick="_btnUpdatePOPDetails_Click"  ImageUrl="~/Images/Buttons/update.jpg" />
                                   <%-- <asp:ImageButton ID="_btnUpdatePOPDetails" runat="server" CausesValidation="false" OnClick="_btnUpdatePOPDetails_Click" ImageUrl="~/Images/Buttons/update.jpg"/>--%>
                                   <%-- <asp:ImageButton ID="_btnUpdateUser" runat="server" CausesValidation="False"  OnClick="_btnUpdateUser_Click" ImageUrl="~/Images/Buttons/update.jpg" Enabled="False" />--%>
                                    &nbsp;<asp:ImageButton ID="_btnRefresh" runat="server" CausesValidation="False" 
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
                <p style="padding-top: 15px"><span>&nbsp;</span><asp:HiddenField 
            ID="hdnValidationAnswer" runat="server" Value="" />
&nbsp;<asp:XmlDataSource ID="XmlDataSource" runat="server" 
            DataFile="~/App_Data/POPType.xml" XPath="root/PopType/Type">
        </asp:XmlDataSource>
    
           </p>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $('#_txtUserID').focus();
        jQuery(document).ready(function () {
            App.init();
        });
</script>
</asp:Content>
