<%@ Page Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesExecutive/SalesAgent.Master" AutoEventWireup="true" CodeBehind="EditRegistration.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesExecutive.EditRegistration" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
            <tr>
                <td class="tdtitle">
                    Edit Registered User
                </td>
            </tr>
            <tr>
                <td class="mainTD">
                    <table class="tableStyle" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td class="tdgap" colspan="3">
                                &nbsp;</td>
                        </tr>                                    
                        <tr>
                            <td class="tdStyle" width="20%">
                            Select Subscriber
                            </td>
                            <td  class="tdStyle" width="30%">
                            
                                <asp:DropDownList ID="_ddListSubscriberName" runat="server" Height="22px" 
                                    Width="250px">
                                </asp:DropDownList>
                            
                            </td>
                            <td class="tdStyle">
                            
                                <asp:ImageButton ID="_imgBtnSelect" runat="server" 
                                    ImageUrl="~/Images/Buttons/Select.jpg" onclick="_imgBtnSelect_Click" 
                                    CausesValidation="False" />
                            
                            </td>
                        </tr>                                    
                        <tr>
                            <td class="tdgap"  colspan="3">
                                &nbsp;</td>
                        </tr>                                    
                    </table>
                </td>
            </tr>
            <tr>
                <td class="tdgap">
                </td>
            </tr>
            <tr>
                <td class="tdStyle">                          
                  &nbsp; <asp:Label ID="_lblMsg" runat="server"></asp:Label> &nbsp;
                    <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdgap">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="mainTD">
                 <div class="tdSubtitle">Edit Subscriber Details&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:LinkButton ID="_lnkBtnEditProfile" runat="server" CausesValidation="False" 
                         onclick="_lnkBtnEditProfile_Click">Edit Profile</asp:LinkButton>
                     <img src="../../../Images/Buttons/edit.png" />
                    </div>
                    <asp:Panel ID="_panelCustDetails" runat="server">
                    
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                        <tr>
                            <td class="tdStyle" colspan="3">
                              
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle" width="20%">
                                Customer Name</td>
                            <td class="tdStyle" width="30%">
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
                            <td class="tdStyle" width="20%">
                                Installation Address</td>
                            <td class="tdStyle" width="30%">
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
                            <td class="tdStyle" width="20%">
                                Corresspondence Address</td>
                            <td class="tdStyle" width="30%">
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
                            <td class="tdStyle" width="20%">
                                Landline Number</td>
                            <td class="tdStyle" width="30%">
                                <asp:TextBox ID="_tbLandlineNumber" runat="server"  CssClass="TextBoxBorder" 
                                    Width="250px"></asp:TextBox>
                                                </td>
                            <td class="tdStyle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdStyle" width="20%">
                                Mobile Number</td>
                            <td class="tdStyle" width="30%">
                                <asp:TextBox ID="_tbMobileNumber" runat="server"  CssClass="TextBoxBorder" 
                                    Width="250px" ></asp:TextBox>
                                                </td>
                            <td class="tdStyle">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="_tbMobileNumber" ErrorMessage="* Mobile Number Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle" width="20%">
                                Email ID</td>
                            <td class="tdStyle" width="30%">
                                <asp:TextBox ID="_tbEmailID" runat="server"  CssClass="TextBoxBorder" 
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
                            <td class="tdStyle" width="20%">
                                &nbsp;</td>
                            <td class="tdStyle" width="30%">
                                &nbsp;</td>
                            <td class="tdStyle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdStyle" width="20%">
                                &nbsp;</td>
                            <td class="tdStyle" width="30%">
                                <asp:ImageButton ID="_imgBtnCustDetailUpdate" runat="server" 
                                    ImageUrl="~/Images/Buttons/update.jpg" 
                                    onclick="_imgBtnCustDetailUpdate_Click" />
                            </td>
                            <td class="tdStyle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdgap" colspan="3">
                                &nbsp;</td>
                        </tr>
                    </table>
                    
                    </asp:Panel>
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
                 <div class="tdSubtitle">Edit Bill Plan Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     <asp:LinkButton ID="_lnkBtnEditBillPlan" runat="server" 
                         CausesValidation="false" onclick="_lnkBtnEditBillPlan_Click">Edit Bill Plan</asp:LinkButton>
                     <img src="../../../Images/Buttons/edit.png" />
                 </div>
                    <asp:Panel ID="_panelBillDetails" runat="server">               
                   
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="tableStyle">
                        <tr>
                            <td class="tdStyle" width="20%">
                            
                                &nbsp;</td>
                                <td class="tdStyle" width="40%">
                                
                                    <asp:Label ID="_lblBillPlanInfo" runat="server"></asp:Label>
                                
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
                                            <td class="tdStyle" style="width: 20%">
                                                Type of Plan
                                            </td>
                                            <td class="tdStyle">                                              
                                

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
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">


                                            <tr>
                                                <td class="tdStyle" style="width: 20%">
                                                    Bill Plan
                                                </td>
                                                <td class="tdStyle">
                                                    <asp:DropDownList ID="_ddlBillPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddlBillPlan_SelectedIndexChanged"
                                                        Width="400px" CssClass="TextBoxBorder" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdStyle">
                                                    Rental Payment Mode
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
                                                        CssClass="TextBoxBorder" Height="22px">
                                                    </asp:DropDownList>
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
                                                    <asp:ImageButton ID="_imgBtnBillPlanUpdate" runat="server" 
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
                                 
                   </asp:Panel>
                    
                </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
