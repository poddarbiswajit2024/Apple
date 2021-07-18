<%@ Page Title="Register System User" Language="C#" MasterPageFile="~/UI/SystemManagement/SystemManage.Master"
    AutoEventWireup="true" CodeBehind="RegisterSysUser.aspx.cs" Inherits="Apple_Bss.UI.SystemManagement.RegisterSysUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="DOB.ascx" TagName="DOB" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Register System User
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
                            <tr>
                                <td colspan="3" class="tdStyle">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Font-Bold="True"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Name<span style="color: Red">*</span>
                                </td>
                                <td class="tdStyle" width="1%">
                                    :
                                </td>
                                <td class="tdStyle" width="79%">
                                    <asp:TextBox ID="tbName" runat="server" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName"
                                        ErrorMessage="Name is Required "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Password<span style="color: Red">*</span>
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="tbPasswrd" runat="server" TextMode="Password" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPasswrd"
                                        ErrorMessage=" Password is required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Privilege<span style="color: Red">*</span>
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:DropDownList ID="_ddlPriv" runat="server" 
                                        Style="font-family: Arial; font-size: small" 
                                        CssClass="TextBoxBorder" AppendDataBoundItems="True" Height="22px" 
                                        DataSourceID="XmlDataSource1" DataTextField="value" DataValueField="value">
                                        <asp:ListItem Selected="True" Value=""> --</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_ddlPriv"
                                        ErrorMessage="Please select privilege level"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Designation
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="tbDesignation" runat="server" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Date of Birth
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <!-- dob -->
                                    <uc1:DOB ID="DOB1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Mobile Number
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="tbMobileNumber" runat="server" MaxLength="11" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Landline Number
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="tbLandlineNo" runat="server" MaxLength="11" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="btnCreateSysUser" runat="server" 
                                        AlternateText="Create System User" OnClick="btnCreateSysUser_Click" ImageUrl="~/Images/Buttons/Create System User.jpg"
                                        />
                                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                        DataFile="~/App_Data/data.xml" XPath="root/PrivilegeNumber/Priv">
                                    </asp:XmlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="tdgap">
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                        TargetControlID="tbMobileNumber">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
