<%@ Page Title="User Registration" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master"
    AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.UserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Broadband Subscriber Registration

                <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="mainTD2">
                <div class="tdSubtitle">Customer Information</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            CAF Number<font color="red">*</font> &nbsp;</td>
                        <td class="tdStyle">
                             <asp:TextBox ID="tbCAFNumber" runat="server" Height="18px" MaxLength="12" 
                                Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="tbCAFNumber_FilteredTextBoxExtender" runat="server"
                                Enabled="True" FilterType="Numbers" TargetControlID="tbCAFNumber">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCAFNumber"
                                Display="Dynamic" ErrorMessage="CAF number required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                        &nbsp;</td>
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
                                            <td class="tdStyle" valign="top">
                                                <asp:TextBox ID="_tbCorrespondenceAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="2" TextMode="MultiLine" Width="200px" CssClass="TextBoxBorder"  AutoPostBack ="true"
                                                    Height="35px"></asp:TextBox>
                                                <asp:CheckBox ID="_chkSameAddress" runat="server" AutoPostBack="True" OnCheckedChanged="_chkSameAddress_CheckedChanged"
                                                    Text="Same as installation address" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_tbCorrespondenceAddress"
                                                    Display="Dynamic" ErrorMessage="Correspondence address required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
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
                                Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
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
                                Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
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
                                Height="18px" MaxLength="12" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
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
                                MaxLength="50" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="_tbEmailID"
                                Display="Dynamic" ErrorMessage="Email ID required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="_tbEmailID" Display="Dynamic" ErrorMessage="Invalid Email ID"
                                ForeColor="#0066FF" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                        </td>
                    </tr>
               
                
                </table>
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>
        <tr>
            <td class="mainTD2">
                <div class="tdSubtitle"> Billing & Connectivity Information</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
                  
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">

                                    <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Type of Plan
                                            </td>
                                            <td class="tdStyle">                                              
                                

                             <asp:CheckBox ID="chkboxPlanNormal" AutoPostBack="true" Enabled="false" Text="Normal Plan" 
                                                      runat="server" oncheckedchanged="chkboxPlanNormal_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanNormal_MutuallyExclusiveCheckBoxExtender" 
                                                      runat="server" Enabled="True" Key="1" TargetControlID="chkboxPlanNormal">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>

                                              <!--  <oncheckedchanged="chkboxPlanFairAccess_CheckedChanged" AutoPostBack="true" -->
                                              <asp:CheckBox ID="chkboxPlanFairAccess" Enabled="false"  Text=" Fair Access Plan" 
                                                      runat="server" Checked="true" />
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
                                                <asp:DropDownList ID="_ddlBillPlan" runat="server" 
                                                    Width="500px" CssClass="TextBoxBorder" Height="22px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlCableOperator0" runat="server" ControlToValidate="_ddlBillPlan" Enabled="true" ErrorMessage="*" ForeColor="#0066FF" Text="Bill Plan required"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                Rental Payment Mode
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlPaymentMode" runat="server" Width="150px" 
                                                    CssClass="TextBoxBorder"  Height="22px">
                                                    <asp:ListItem Selected="True" Value="M">MONTHLY</asp:ListItem>
                                                   <%-- <asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                                    <asp:ListItem Value="H">HALF-YEARLY</asp:ListItem>--%>
                                                    <asp:ListItem Value="A">ANNUALY</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <asp:Label ID="_lblOTRCPaymentMode" runat="server" Enabled="False" Text="Subscription Plan">
                                                </asp:Label>
                                            </td>
                                            <td class="tdStyle">
                                                <asp:DropDownList ID="_ddlRegOTRCPlan" runat="server" Width="500px" 
                                                    CssClass="TextBoxBorder" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                 
                                        <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">

                                    <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Access Type
                                            </td>
                                            <td class="tdStyle2"> 
                             <asp:CheckBox ID="chkboxSymBiosNetwork" AutoPostBack="true" Checked="true" CssClass="controlStyle" Text="SymBios Network" 
                                                      runat="server" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender1" 
                                                      runat="server" Enabled="True" Key="2" TargetControlID="chkboxSymBiosNetwork">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                              <asp:CheckBox ID="chkboxCableProvider" CssClass="controlStyle" AutoPostBack="true" Text="Cable Provider" 
                                                      runat="server" OnCheckedChanged="chkboxCableProvidee_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender2" 
                                                      runat="server" Enabled="True" Key="2" 
                                                      TargetControlID="chkboxCableProvider">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                            &nbsp;&nbsp;
                            <asp:DropDownList ID="ddlCableOperator" runat="server" AppendDataBoundItems="true"
                                CssClass="EntryBoxBorder" Height="22px" Enabled="false">
                                <asp:ListItem Selected="True" Value=""> -- select cable operator -- </asp:ListItem>
                            </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="rfvddlCableOperator"  runat="server"  ForeColor="#0066FF" ErrorMessage="*" Enabled="false" Text="Please select cable operator name" ControlToValidate="ddlCableOperator" ></asp:RequiredFieldValidator>
                         
                            
                      
                                        </tr>
                                          <tr><td class="tdgap"></td></tr>
                              
                             <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Installation Connection Type*
                                            </td>
                                 <td class="tdStyle">                                              
             <asp:CheckBox ID="ChkBoxResidential"  Text="Residential" runat="server" Checked="true" oncheckedchanged="ChkBoxResidential_CheckChanged" />    

                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender5" 
                                                      runat="server" Enabled="True" Key="5" TargetControlID="ChkBoxResidential">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                       <asp:CheckBox ID="ChkBoxCommercial"  Text="Commercial" runat="server"  oncheckedchanged="ChkBoxCommercial_CheckChanged"/> 
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender6" 
                                                      runat="server" Enabled="True" Key="5" 
                                                      TargetControlID="ChkBoxCommercial">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                            </td>
                                         
                   
                                            </td>
                              
                                        </tr>
                                        <tr>
                                             <td class="tdStyle" style="width: 20%">
                                                User GSTIN*
                                            </td>
                                            <td class="tdStyle">
                                                
                                                <asp:TextBox ID="_txtUserGSTIN" runat="server" Width="216px"></asp:TextBox>
                                               
                                                    <asp:CheckBox ID="Chkgst" runat="server" Text="GSTIN not provided" OnCheckedChanged="Chkgst_CheckedChanged" AutoPostBack="true" />
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required GSTIN" ControlToValidate="_txtUserGSTIN"></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_txtUserGSTIN" ErrorMessage="Please Enter a valid Gst number" ValidationExpression="^([0]{1}[1-9]{1}|[1-2]{1}[0-9]{1}|[3]{1}[0-7]{1})([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$"></asp:RegularExpressionValidator>
                                                
                                         
                                                 </td>
                                             
                                        </tr>
                                        
                                    </table>
                                </ContentTemplate>
                                 <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="Chkgst" />
                                 </Triggers>
                            </asp:UpdatePanel>

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
        <tr><td class="tdgap"></td></tr>
        <tr>
            <td class="mainTD2">
                <div class="tdSubtitle"> Miscellaneous</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                   
                 
                    <tr>
                        <td class="tdStyle" style="width: 20%">
                            Date of Registration<font color="red">*</font>
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbRegistrationDate" runat="server" BackColor="#F6F6F6" 
                                CssClass="TextBoxBorder" Width="145px" Enabled="false"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"
                                TargetControlID="_tbRegistrationDate" DaysModeTitleFormat="MMMM,yyyy"  
                                Format="dd-MM-yyyy" >
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
               
             
                </table>
            </td>
        </tr>
        <tr><td class="tdgap"></td></tr>

   

          <tr>
            <td class="tdStyle">
                <asp:ImageButton ID="_btnRegister" runat="server" OnClick="_btnRegister_Click" ImageUrl="~/Images/Buttons/submit.jpg"
                               OnClientClick="javascript:window.scrollTo(0, 0);" />

                   <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/IDProof/ProofDocument" OnTransforming="XmlDataSource1_Transforming" ></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>
            </td>
        </tr>
          <tr><td class="tdgap"></td></tr>
    </table>
</asp:Content>
