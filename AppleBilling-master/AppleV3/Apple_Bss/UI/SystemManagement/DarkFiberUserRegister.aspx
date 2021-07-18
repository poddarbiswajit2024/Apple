<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/UI/SystemManagement/SystemManage.Master"
    AutoEventWireup="true" CodeBehind="DarkFiberUserRegister.aspx.cs" Inherits="Apple_Bss.UI.SystemManagement.DarkFiberUserRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Dark Fiber User Registration
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <div class="tdSubtitle">User Information</div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>   
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Name<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbCustomerName" runat="server" AutoCompleteType="FirstName" CssClass="TextBoxBorder"
                                Height="18px" MaxLength="50" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbCustomerName"
                                Display="Dynamic" ErrorMessage="Customer name required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
               
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Username<font color="red">*</font></td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbUserName" runat="server" CssClass="TextBoxBorder"
                                Height="18px" MaxLength="100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="_tbUserName"
                                Display="Dynamic" ErrorMessage="Username required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
               
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Password<font color="red">*</font></td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbPassword" runat="server" CssClass="TextBoxBorder"
                                Height="18px" MaxLength="100" Width="200px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="_tbUserName"
                                Display="Dynamic" ErrorMessage="Password required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
               
                                        <tr>
                                            <td class="tdStyle" style="width: 20%" valign="top">
                                                Correspondence Address<font color="red">*</font>
                                            </td>
                                            <td class="tdStyle">
                                                <asp:TextBox ID="_tbCorrespondenceAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="2" TextMode="MultiLine" Width="200px" CssClass="TextBoxBorder" 
                                                    Height="35px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_tbCorrespondenceAddress"
                                                    Display="Dynamic" ErrorMessage="Correspondence address required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
              
                    <tr>
                        <td class="tdStyle">
                            Landline Number
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbLandlineNumber" runat="server" Height="18px" MaxLength="12" 
                                Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Mobile Number<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbMobileNumber" runat="server" Height="18px" MaxLength="12" 
                                Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="_tbMobileNumber_FilteredTextBoxExtender" 
                                runat="server"  FilterType="Numbers" 
                                TargetControlID="_tbMobileNumber">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_tbMobileNumber"
                                Display="Dynamic" ErrorMessage="Mobile number required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Alternative Mobile Number
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbAltMobileNumber" runat="server" AutoCompleteType="FirstName"
                                Height="18px" MaxLength="12" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                               
                            <cc1:FilteredTextBoxExtender ID="_tbAltMobileNumber_FilteredTextBoxExtender" 
                                runat="server" FilterType="Numbers"  TargetControlID="_tbAltMobileNumber">
                            </cc1:FilteredTextBoxExtender>
                               
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                           Primary Email ID<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbEmailID" runat="server" AutoCompleteType="FirstName" Height="18px"
                                MaxLength="100" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="_tbEmailID"
                                Display="Dynamic" ErrorMessage="Email ID required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="_tbEmailID" Display="Dynamic" ErrorMessage="Invalid Email ID"
                                ForeColor="#0066FF" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="tdStyle">
                        Second Email ID 
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbEmail2" runat="server" AutoCompleteType="FirstName" Height="18px"
                                MaxLength="100" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="_tbEmail2" Display="Dynamic" ErrorMessage="Invalid Email ID"
                                ForeColor="#0066FF" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                                 <tr>
                        <td class="tdStyle">
                        Third Email ID 
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbEmailID3" runat="server" AutoCompleteType="FirstName" Height="18px"
                                MaxLength="100" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="_tbEmailID3" Display="Dynamic" ErrorMessage="Invalid Email ID"
                                ForeColor="#0066FF" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    
                    <tr>
                        <td class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnRegister" runat="server" OnClick="_btnRegister_Click" ImageUrl="~/Images/Buttons/Register User.jpg"
                               />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tdgap">
                        </td>
                    </tr>
                </table>
                           </ContentTemplate>      
                </asp:UpdatePanel>
           
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>
      
     
    </table>
      
</asp:Content>
