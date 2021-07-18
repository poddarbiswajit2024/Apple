<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesExecutive/SalesAgent.Master"
    AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesExecutive.UserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Broadband Subscriber Registration
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <div class="tdSubtitle">Customer Information</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Customer Name<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbCustomerName" runat="server" AutoCompleteType="FirstName" CssClass="TextBoxBorder"
                                Height="18px" MaxLength="50" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbCustomerName"
                                Display="Dynamic" ErrorMessage="Customer name required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            ID Proof<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="_ddlIDProof" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_ddlIDProof_SelectedIndexChanged"
                                        DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" Width="204px"
                                        Style="height: 22px" CssClass="TextBoxBorder" Height="22px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="_tbotherIDProof" runat="server" Visible="False" OnTextChanged="_tbotherIDProof_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="_rfvIDProof" runat="server" ControlToValidate="_ddlIDProof"
                                        Display="Dynamic" ErrorMessage="ID proof required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_ddlIDProof" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td valign="top" class="tdStyle" style="width: 20%">
                                                Installation Address<font color="red">*</font>
                                            </td>
                                            <td class="tdStyle">
                                                <asp:TextBox ID="_tbInstallationAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="2" TextMode="MultiLine" Width="200px" CssClass="TextBoxBorder" 
                                                    Height="35px"></asp:TextBox>
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbInstallationAddress"
                                                    Display="Dynamic" ErrorMessage="Installation address required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle" style="width: 20%" valign="top">
                                                Installation Address Proof<font color="red">*</font>
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlAddressProof" runat="server" AutoPostBack="True" DataSourceID="XmlDataSource2"
                                                    DataTextField="text" DataValueField="value" Width="204px" 
                                                    OnSelectedIndexChanged="_ddlAddressProof_SelectedIndexChanged" 
                                                    CssClass="TextBoxBorder" Height="22px">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="_tbOtherAddrsProof" runat="server" Visible="False" OnTextChanged="_tbOtherAddrsProof_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="_rfvAddrsProof" runat="server" ControlToValidate="_ddlAddressProof"
                                                    Display="Dynamic" ErrorMessage="Address proof required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
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
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td class="tdStyle">
                                                <asp:CheckBox ID="_chkSameAddress" runat="server" AutoPostBack="True" OnCheckedChanged="_chkSameAddress_CheckedChanged"
                                                    Text="Same as installation address" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_chkSameAddress" />
                                    <asp:AsyncPostBackTrigger ControlID="_ddlAddressProof" />
                                    <asp:AsyncPostBackTrigger ControlID="_tbOtherAddrsProof" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Landline Number
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbLandlineNumber" runat="server" Height="18px" MaxLength="12" 
                                Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="_tbLandlineNumber_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="_tbLandlineNumber">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Mobile Number<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbMobileNumber" runat="server" Height="18px" MaxLength="12" 
                                Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="_tbMobileNumber_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="_tbMobileNumber">
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
                                Height="18px" MaxLength="12" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="_tbAltMobileNumber_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="_tbAltMobileNumber">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Email ID<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbEmailID" runat="server" AutoCompleteType="FirstName" Height="18px"
                                MaxLength="50" Width="150px" CssClass="TextBoxBorder"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="_tbEmailID"
                                Display="Dynamic" ErrorMessage="Email ID required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="_tbEmailID" Display="Dynamic" ErrorMessage="Invalid Email ID"
                                ForeColor="#0066FF" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Upload User Photo
                        </td>
                        <td class="tdStyle">
                            <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_doUpload"
                                Width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Upload ID Proof Image
                        </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadPhotoIDProof" runat="server" FileTypeRange="gif,jpg,png,tif" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Upload Address Proof Image
                        </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadPhotoAddrsProof" runat="server" FileTypeRange="gif,jpg,png,tif"
                                Required="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tdgap">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>
        <tr>
            <td class="mainTD">
                <div class="tdSubtitle"> Billing Information</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                    <tr>
                        <td colspan="2" style="height: 10px" class="tdgap">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" 
                                ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">

                                           <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Type of Plan
                                            </td>
                                            <td class="tdStyle">                                              
                                                  <%--<asp:RadioButtonList ID="rbtnTypePlan" runat="server" 
                                                      RepeatDirection="Horizontal" AutoPostBack="True" 
                                                      onselectedindexchanged="rbtnTypePlan_SelectedIndexChanged">
                                <asp:ListItem  Value="N">Normal Plan</asp:ListItem>
                                <asp:ListItem Value="F">Fair Access Plan</asp:ListItem>
                            </asp:RadioButtonList>--%>

                             <asp:CheckBox ID="chkboxPlanNormal" AutoPostBack="true" Text="Normal Plan" 
                                                      runat="server" oncheckedchanged="chkboxPlanNormal_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanNormal_MutuallyExclusiveCheckBoxExtender" 
                                                      runat="server" Enabled="True" Key="1" TargetControlID="chkboxPlanNormal">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                              <asp:CheckBox ID="chkboxPlanFairAccess" AutoPostBack="true" Text=" Fair Access Plan" 
                                                      runat="server" oncheckedchanged="chkboxPlanFairAccess_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanFairAccess_MutuallyExclusiveCheckBoxExtender" 
                                                      runat="server" Enabled="True" Key="1" 
                                                      TargetControlID="chkboxPlanFairAccess">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Bill Plan
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlBillPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddlBillPlan_SelectedIndexChanged"
                                                    Width="400px" CssClass="TextBoxBorder" Height="22px">
                                                </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                Rental Payment Mode
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlPaymentMode" runat="server" Width="150px" 
                                                    CssClass="TextBoxBorder" Height="22px">
                                                    <asp:ListItem Selected="True" Value="M">MONTHLY</asp:ListItem>
                                                    <asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                                    <asp:ListItem Value="H">HALF-YEARLY</asp:ListItem>
                                                    <asp:ListItem Value="A">ANNUALY</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:Label ID="_lblOTRCPaymentMode" runat="server" Enabled="False" Text="OTRC Payment Mode">
																	         

                                                </asp:Label>
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlRegOTRCPlan" runat="server" Width="150px" 
                                                    CssClass="TextBoxBorder" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="tdgap">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                               
                                <Triggers>
                                </Triggers>
                               
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>
        <tr>
            <td class="mainTD">
                <div class="tdSubtitle"> Miscellaneous</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                   
                    <tr>
                        <td colspan="2" class="tdgap">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Date of Registration<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbRegistrationDate" runat="server" BackColor="#F6F6F6" 
                                CssClass="TextBoxBorder" Width="145px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"
                                TargetControlID="_tbRegistrationDate" DaysModeTitleFormat="MMMM,yyyy"  CssClass="ajax__calendar"
                                Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="_tbRegistrationDate"
                                ErrorMessage="Select registration date" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Priority
                        </td>
                        <td class="tdStyle">
                            <asp:DropDownList ID="_ddlPriority" runat="server" Width="150px" 
                                CssClass="TextBoxBorder" Height="22px">
                                <asp:ListItem Value="1">1 - Normal </asp:ListItem>
                                <asp:ListItem Value="2">2 - High </asp:ListItem>
                                <asp:ListItem Value="3">3 - Urgent </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="tdStyle">
                            Is Registerd by Agent?
                        </td>
                        <td  class="tdStyle2" style="height:32px">
                       
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                            <ContentTemplate>
                            <asp:CheckBox ID="_chkbIsAgent" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="_chkbIsAgent_CheckedChanged" CssClass="controlStyle" ToolTip="check if true" />
                            &nbsp;&nbsp;
                            
                            <asp:DropDownList ID="_ddlAgent" runat="server" AppendDataBoundItems="true"
                                CssClass="EntryBoxBorder" Height="22px" Visible="false">
                                <asp:ListItem Selected="True" Value=""> -- select agent -- </asp:ListItem>
                            </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="_rfvAgentSelect"  runat="server"  ForeColor="#0066FF" ErrorMessage="*" Enabled="false" Text="Please select agent" ControlToValidate="_ddlAgent" ></asp:RequiredFieldValidator>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Remarks
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbRemarks" runat="server" Font-Names="Arial"
                              MaxLength="250" Rows="3" TextMode="MultiLine" Width="400px" 
                                CssClass="TextBoxBorder" Height="40px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnRegister" runat="server" OnClick="_btnRegister_Click" ImageUrl="~/Images/Buttons/Register User.jpg"
                               OnClientClick="javascript:window.scrollTo(0, 0);" />
                        </td>
                        <td class="tdStyle">
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/IDProof/ProofDocument"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>
    </table>
</asp:Content>
