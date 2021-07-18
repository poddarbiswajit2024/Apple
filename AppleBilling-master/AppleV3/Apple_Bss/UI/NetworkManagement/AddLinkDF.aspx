<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master" AutoEventWireup="true" CodeBehind="AddLinkDF.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.AddLinkDF" Title="" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>   
        <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr><td class="tdtitle">Add Link and Details</td></tr>
        <tr><td class="mainTD">
            <table cellspacing="0" cellpadding="0" align="left" class="tableStyle">					
        										
					        <tr>
        						
						        <td class="tdStyle" width="15%">
                                    &nbsp;</td>
        						
						        <td class="tdStyle" width="78%" colspan="2">
                                    <asp:Label ID="_lblMsg" runat="server" Font-Bold="True" Font-Names="Arial" 
                                        Font-Size="9pt" ForeColor="Maroon"></asp:Label>&nbsp;
                                </td>
        						
						        <td width="7%" class="backbtn">
                                    <asp:ImageButton ID="_iBtnBack" runat="server" CausesValidation="False" 
                                        onclick="_iBtnBack_Click" ImageUrl="~/Images/Buttons/back.png"/>
                                </td>
        						
					        </tr>
        															
					        <tr>
        						
						        <td class="tdStyle" width="20%"  >
						        Customer Name</td>
        						
						        <td class="tdStyle" colspan="3">
						        <asp:TextBox ID="_tbCustomerName" runat="server" AutoCompleteType="FirstName" 
                                        MaxLength="50" Width="200px" ReadOnly="True" CssClass="TextBoxBorder"></asp:TextBox>
        						
						        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ControlToValidate="_tbCustomerName" Display="Dynamic" 
                                        ErrorMessage="Name required" ForeColor="#0066FF" ValidationGroup="link"></asp:RequiredFieldValidator>
                                </td>
        						
					        </tr>
					        
					        
                    <tr>
                                            <td valign="top" class="tdStyle" style="width: 20%">
                                                Installation Address<font color="red">*</font>
                                            </td>
                                            <td class="tdStyle" colspan="3">
                                                <asp:TextBox ID="_tbInstallationAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="2" TextMode="MultiLine" Width="200px" CssClass="TextBoxBorder" 
                                                    Height="35px"></asp:TextBox>
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbInstallationAddress"
                                                    Display="Dynamic" ErrorMessage="Installation address required" 
                                                    ForeColor="#0066FF" ValidationGroup="link"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                    
        					
					        
					          <tr>
        						
						        <td class="tdStyle">Length Aerial(metres)<font color="red">*</font></td>
                              
						        <td class="tdStyle" colspan="3" >
                                    <asp:TextBox ID="_tbLengthAerial" Width="200px" CssClass="TextBoxBorder" runat="server" 
                                        ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="_tbLengthAerial_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" FilterType="Numbers" 
                                        TargetControlID="_tbLengthAerial">
                                    </cc1:FilteredTextBoxExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvAccountid0" runat="server" 
                                        ControlToValidate="_tbLengthAerial" Display="Dynamic" EnableViewState="False" 
                                        ErrorMessage="Please enter aerial fiber length" 
                                        ForeColor="#0066FF" ValidationGroup="link"></asp:RequiredFieldValidator>
                                  
                                  </td>
                              
        						
					        </tr>
					             <tr>
        						
						        <td class="tdStyle">Length Underground(m)<font color="red">*</font></td>
                             
						        <td class="tdStyle" colspan="3" >
                                    <asp:TextBox ID="_tbLengthUndergorund" Width="200px"  CssClass="TextBoxBorder" runat="server" 
                                        ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="_tbLengthUndergorund_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" FilterType="Numbers" 
                                        TargetControlID="_tbLengthUndergorund">
                                    </cc1:FilteredTextBoxExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="rfvAccountid1" runat="server" 
                                        ControlToValidate="_tbLengthUndergorund" Display="Dynamic" EnableViewState="False" 
                                        ErrorMessage="Please enter underground fiber length" 
                                        ForeColor="#0066FF" ValidationGroup="link"></asp:RequiredFieldValidator>
                                  
                                     </td>
                              
        						
					        </tr>
					        
					        
					        <tr>
        						
						        <td class="tdStyle">
						        Connection Date</td>
        						
						        <td class="tdStyle">						
						            <asp:TextBox id="_tbConnDate" runat="server" Width="200px" 
                                         BackColor="#F6F6F6" CssClass="TextBoxBorder"></asp:TextBox>
        							
                                    <cc1:CalendarExtender ID="_tbConnDate_CalendarExtender" runat="server"  CssClass="ajax__calendar"
                                        Enabled="True" PopupPosition="Right" TargetControlID="_tbConnDate">
                                    </cc1:CalendarExtender>
        							
                                    &nbsp;</td>
        						
					            <td class="tdStyle">
                                    &nbsp;</td>
                                <td class="tdStyle">
                                    &nbsp;</td>
        						
					        </tr>
					        <tr>
                        <td class="tdStyle">
                            Upload JMC Report<font color="red">*</font></td>
                        <td class="tdStyle" colspan="3">
                            <uc1:UploadPhoto ID="UploadJMCReport"  FileTypeRange="gif,jpg,png,tif,pdf" 
                                runat="server" Required="True" Vgroup="link" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" >
                            Upload OTDR Report<font color="red">*</font></td>
                        <td class="tdStyle" colspan="3">
                            <uc1:UploadPhoto ID="UploadOTDRReport"  runat="server" 
                                FileTypeRange="gif,jpg,png,tif,pdf" Required="True" Vgroup="link" />
                        </td>
                    </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">&nbsp;</td>
        						
						        <td class="tdStyle" width="20%">
						            &nbsp;</td>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
					        </tr>
        					
					        
					        <tr class="tdgap">
        						
						        <td class="tdgap" colspan="4">&nbsp;</td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
						        <td class="tdStyle">
						        <asp:ImageButton ID="_btnConnect" runat="server" ImageUrl="~/Images/Buttons/Add_link_details.jpg" OnClick="_btnConnect_Click"  AlternateText="Add Link Details" ValidationGroup="link" />
        						
						        &nbsp;<asp:ImageButton ID="_imgBtnRefresh" runat="server" CausesValidation="False" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" onclick="_imgBtnRefresh_Click" />
        						
						        </td>
        						
						        <td colspan="2" class="tdStyle">
						            &nbsp;</td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">&nbsp;</td>
        						
						        <td colspan="3">&nbsp;</td>
        						
					        </tr>
        					
				        </table>
	        </td>   
        </tr>
        </table>				
       </ContentTemplate>    
       <Triggers>
       <asp:PostBackTrigger ControlID="_btnConnect" />
       </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
