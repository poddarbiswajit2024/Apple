<%@ Page Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="EditRegistration.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.EditRegistration" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">Edit Registered User
                    </td>
                </tr>

                <tr>
                    <td class="tdgap"></td>
                </tr>
                <tr>
                    <td class="tdStyle">&nbsp;
                        <asp:Label ID="_lblMsg" runat="server"></asp:Label>
                        &nbsp;
                    <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdgap">&nbsp;</td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Edit Subscriber Details
                     
                        </div>


                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                            <tr>
                                <td class="tdStyle" colspan="3">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 20%">CAF Number<font color="red">*</font> &nbsp;</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="tbCAFNumber" runat="server" Height="18px" MaxLength="12"
                                        Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="tbCAFNumber_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="tbCAFNumber">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCAFNumber"
                                        Display="Dynamic" ErrorMessage="CAF number required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Customer Name</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbCustomerName" runat="server" CssClass="TextBoxBorder"
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="_tbCustomerName"
                                        ErrorMessage="* customer Name field cannot be left empty"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Installation Address</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbInstallationAddress" runat="server"
                                        CssClass="TextBoxBorder" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="_tbInstallationAddress"
                                        ErrorMessage="* Installation Address required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Corresspondence Address</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbCorresspondenceAddress" runat="server"
                                        CssClass="TextBoxBorder" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="_tbCorresspondenceAddress"
                                        ErrorMessage="* Correspondence Address required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Landline Number</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbLandlineNumber" runat="server" CssClass="TextBoxBorder"
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Mobile Number</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbMobileNumber" runat="server" CssClass="TextBoxBorder"
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="_tbMobileNumber" ErrorMessage="* Mobile Number Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">Email ID</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:TextBox ID="_tbEmailID" runat="server" CssClass="TextBoxBorder"
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td class="tdStyle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="_tbEmailID" ErrorMessage="* Email Required"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="_tbEmailID" ErrorMessage="* Invalid email ID"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                              
                            <tr>
                                <td class="tdStyle" width="20%">&nbsp;</td>
                                <td class="tdStyle" style="width: 37%">&nbsp;</td>
                                <td class="tdStyle">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">&nbsp;</td>
                                <td class="tdStyle" style="width: 37%">
                                    <asp:ImageButton ID="_imgBtnCustDetailUpdate" runat="server"
                                        ImageUrl="~/Images/Buttons/update.jpg"
                                        OnClick="_imgBtnCustDetailUpdate_Click" />
                                </td>
                                <td class="tdStyle">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="tdgap" colspan="3">&nbsp;</td>
                            </tr>
                        </table>


                    </td>
                </tr>
                <tr>
                    <td class="tdgap">&nbsp;
                    </td>
                </tr>

                <tr>
                    <td class="tdStyle">
                        <asp:Label ID="lblupdatebillmsg" runat="server" Font-Bold="True"
                            ForeColor="#009933"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Edit Bill Plan Details
                        </div>

                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                            <tr>
                                <td class="tdStyle" width="20%">&nbsp;</td>
                                <td class="tdStyle" width="40%">

                                    <asp:Label ID="_lblBillPlanInfo" runat="server"></asp:Label>

                                </td>
                                <td class="tdStyle" style="padding-right: 20px">&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="tdStyle" style="width: 20%">Type of Plan
                                </td>
                                <td class="tdStyle">


                                    <asp:CheckBox ID="chkboxPlanNormal" AutoPostBack="true" Text="Normal Plan"
                                        runat="server" OnCheckedChanged="chkboxPlanNormal_CheckedChanged" />
                                    <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanNormal_MutuallyExclusiveCheckBoxExtender"
                                        runat="server" Enabled="True" Key="1" TargetControlID="chkboxPlanNormal">
                                    </cc1:MutuallyExclusiveCheckBoxExtender>
                                    <asp:CheckBox ID="chkboxPlanFairAccess" AutoPostBack="true" Text=" Fair Access Plan"
                                        runat="server" OnCheckedChanged="chkboxPlanFairAccess_CheckedChanged" />
                                    <cc1:MutuallyExclusiveCheckBoxExtender ID="chkboxPlanFairAccess_MutuallyExclusiveCheckBoxExtender"
                                        runat="server" Enabled="True" Key="1"
                                        TargetControlID="chkboxPlanFairAccess">
                                    </cc1:MutuallyExclusiveCheckBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" width="20%">&nbsp;</td>
                                <td class="tdStyle" width="40%">&nbsp;</td>
                                <td class="tdStyle" style="padding-right: 20px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="tdStyle" style="width: 20%">Bill Plan
                                                    </td>
                                                    <td class="tdStyle">
                                                        <asp:DropDownList ID="_ddlBillPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddlBillPlan_SelectedIndexChanged"
                                                            Width="400px" CssClass="TextBoxBorder" Height="22px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle">Rental Payment Mode
                                                    </td>
                                                    <td class="tdStyle">
                                                        <asp:DropDownList ID="_ddlPaymentMode" runat="server" Width="400px"
                                                            CssClass="TextBoxBorder" Height="22px">
                                                            <asp:ListItem Selected="True" Value="M">MONTHLY
    																		

                                                            </asp:ListItem>
                                                            <asp:ListItem Value="Q">QUARTERLY
    																		

                                                            </asp:ListItem>
                                                            <asp:ListItem Value="H">HALF-YEARLY
    																		

                                                            </asp:ListItem>
                                                            <asp:ListItem Value="A">ANNUALY
    																		

                                                            </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle">
                                                        <asp:Label ID="_lblOTRCPaymentMode" runat="server" Enabled="False" Text="OTRC Payment Mode">
    																	         

                                                        </asp:Label>
                                                    </td>
                                                    <td class="tdStyle">
                                                        <asp:DropDownList ID="_ddlRegOTRCPlan" runat="server" Width="400px"
                                                            CssClass="TextBoxBorder" Height="22px" OnSelectedIndexChanged="_ddlRegOTRCPlan_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%" cellpadding="0" cellspacing="0">

                                                                    <tr>
                                                                        <td class="tdStyle" style="width: 9%">Access Type
                                                                        </td>
                                                                        <td class="tdStyle2">
                                                                            <asp:CheckBox ID="chkboxSymBiosNetwork" AutoPostBack="true" CssClass="controlStyle" Text="SymBios Network"
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
                                                                            &nbsp;<asp:RequiredFieldValidator ID="rfvddlCableOperator" runat="server" ForeColor="#0066FF" ErrorMessage="*" Enabled="false" Text="Please select cable operator name" ControlToValidate="ddlCableOperator"></asp:RequiredFieldValidator>
                                                                    </tr>
                                                                    <tr>
                                            <td class="tdStyle" style="width: 9%">
                                                Installation Connection Type
                                            </td>
                                            <td class="tdStyle" style="width: 37%">                                              
                                

 <asp:CheckBox ID="ResidentialCheckBox" AutoPostBack="true" Text="Residential" runat="server" oncheckedchanged="chkboxResidential_CheckedChanged" />

<asp:CheckBox ID="CommercialCheckBox" AutoPostBack="true" Text="Commercial" runat="server" oncheckedchanged="chkboxCommercial_CheckedChanged"/><br />
                                                <asp:Label ID="InstallationConnectionType" runat="server" Text=""></asp:Label>
                    
                                            </td>
                                        </tr>
                                                                    <tr>
                                                                         <td class="tdStyle" style="width: 9%">
                                                                             User GSTIN
                                            </td>
                                                      <td class="tdStyle">
                                                      <asp:TextBox ID="_txtUserGSTIN" runat="server" Width="216px"></asp:TextBox>
                                                         
                                                          </td>
                                                                    </tr>

                                                                </table>
                                                            </ContentTemplate>
                                            
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td class="tdStyle">&nbsp;</td>
                                                    <td class="tdStyle">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="tdStyle">&nbsp;</td>
                                                    <td class="tdStyle">
                                                        <asp:ImageButton ID="_imgBtnBillPlanUpdate" runat="server"
                                                            ImageUrl="~/Images/Buttons/update.jpg"
                                                            OnClick="_imgBtnBillPlanUpdate_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="tdgap">&nbsp;
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


                <%--<tr>
                <td class="mainTD">
                 <div class="tdSubtitle">Edit Connectivity Details
                 </div>
                
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                        <tr>
                            <td class="tdStyle" width="20%">
                            
                                &nbsp;</td>
                                <td class="tdStyle" width="40%">
                                
                                    <asp:Label ID="lblConnectivity" runat="server"></asp:Label>
                                
                                </td>
                            <td  class="tdStyle" style="padding-right:20px">                        
                                &nbsp;</td>
                        </tr>

                        
                        <tr>
                            <td class="tdStyle" width="20%">
                                &nbsp;</td>
                            <td class="tdStyle" width="40%">
                                &nbsp;</td>
                            <td class="tdStyle" style="padding-right:20px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdStyle" style="width: 20%">
                                                    &nbsp;</td>
                                                <td class="tdStyle">
                                                    &nbsp;</td>
                                            </tr>

                                            <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">

                                    <tr>
                                            <td class="tdStyle" style="width: 20%">
                                                Access Type
                                            </td>
                                            <td class="tdStyle2"> 
                             <asp:CheckBox ID="CheckBox3" AutoPostBack="true" CssClass="controlStyle" Text="SymBios Network" 
                                                      runat="server" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender5" 
                                                      runat="server" Enabled="True" Key="2" TargetControlID="chkboxSymBiosNetwork">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                              <asp:CheckBox ID="CheckBox4" CssClass="controlStyle" AutoPostBack="true" Text="Cable Provider" 
                                                      runat="server" OnCheckedChanged="chkboxCableProvidee_CheckedChanged" />
                                                  <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender6" 
                                                      runat="server" Enabled="True" Key="2" 
                                                      TargetControlID="chkboxCableProvider">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>
                                            &nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="true"
                                CssClass="EntryBoxBorder" Height="22px" Enabled="false">
                                <asp:ListItem Selected="True" Value=""> -- select cable operator -- </asp:ListItem>
                            </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7"  runat="server"  ForeColor="#0066FF" ErrorMessage="*" Enabled="false" Text="Please select cable operator name" ControlToValidate="ddlCableOperator" ></asp:RequiredFieldValidator>
                         
                            
                      
                                        </tr>
                                          <tr><td class="tdgap"></td></tr>
                              
                            
                                    </table>
                                </ContentTemplate>
                               
                            </asp:UpdatePanel>
                        </td>
                    </tr>


                                            <tr>
                                                <td class="tdStyle">
                                                    &nbsp;</td>
                                                <td class="tdStyle">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="tdStyle">
                                                    &nbsp;</td>
                                                <td class="tdStyle">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                                        ImageUrl="~/Images/Buttons/update.jpg" 
                                                        onclick="_imgBtnBillPlanUpdate_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="tdgap">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>  
         
                    
                </td>
            </tr>--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
