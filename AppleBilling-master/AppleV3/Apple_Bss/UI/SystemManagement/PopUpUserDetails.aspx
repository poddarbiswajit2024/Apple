<%@ Page Title="System User Details" Language="C#" AutoEventWireup="true" CodeBehind="PopUpUserDetails.aspx.cs"
    Inherits="Apple_Bss.UI.SystemManagement.PopUpUserDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="DOB.ascx" TagName="DOB" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>System User Details</title>
    <link href="../../CSS/InetBill.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                     System User Details
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" align="center" class="tableStyle">
                           
                            <tr>
                                <td colspan="3" class="tdStyle">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Font-Bold="True"></asp:Label> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">
                                    Employee ID
                                </td>
                                <td class="tdStyle" width="1%">
                                    :
                                </td>
                                <td class="tdStyle" width="79%">
                                    <asp:Label ID="Label_empid" runat="server"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="ibeditmode" runat="server" AlternateText="Edit Details" CausesValidation="false"
                                        ImageUrl="~/Images/Buttons/edit.png" onclick="ibeditmode_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Status
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:Label ID="Label_Status" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Name<span style="color: Red">*</span>
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    <asp:TextBox ID="tbName" runat="server" ReadOnly="True" Width="150px" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName"
                                        ErrorMessage="Name is Required "></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Password
                                </td>
                                <td class="tdStyle">
                                    :
                                </td>
                                <td class="tdStyle">
                                    &nbsp; ****
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
                                        Style="font-family: Arial; font-size: small" CssClass="TextBoxBorder" 
                                        Height="20px" DataSourceID="XmlDataSource1" 
                                        AppendDataBoundItems="True" DataTextField="value" DataValueField="value">
                                        <asp:ListItem Selected="True" Value=""> --</asp:ListItem>                                       
                                    </asp:DropDownList>
                                    <span lang="en-us">&nbsp;</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server" ControlToValidate="_ddlPriv" ErrorMessage="Please select privilege level"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="tbDesignation" runat="server" Width="200px" ReadOnly="True" 
                                        CssClass="TextBoxBorder"></asp:TextBox>
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
                                     <!--DoB user control-->
                                     <uc2:DOB ID="DOB1" runat="server" />  <asp:Label ID="Label_dob" runat="server"></asp:Label>
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
                                    <asp:TextBox ID="tbMobileNumber" runat="server" MaxLength="12" Width="150px" 
                                        ReadOnly="True" CssClass="TextBoxBorder"></asp:TextBox>
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
                                    <asp:TextBox ID="tbLandlineNo" runat="server" MaxLength="12" Width="150px" 
                                        ReadOnly="True" CssClass="TextBoxBorder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="tdgap">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="tdStyle">
                              
                                    &nbsp;&nbsp;<asp:ImageButton ID="ibUpdate" runat="server" AlternateText="Update" 
                                        ImageUrl="~/Images/Buttons/update.jpg" onclick="ibUpdate_Click" 
                                        Visible="False" />
                                                                          
                                       
                                    &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ibCancel" runat="server" 
                                        Enabled="False"  AlternateText="Cancel" Visible="False"
                                        ImageUrl="~/Images/Buttons/cancel.jpg" onclick="ibCancel_Click"  />
                                        <!--
&nbsp;<input ID="Button1" causesvalidation="false" onclick="JavaScript:window.close()" style="height: 22px; width: 100px" 
                                        type="button" value="Close Window" />
                                        -->
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
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                        TargetControlID="tbLandlineNo">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
