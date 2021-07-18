<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master" AutoEventWireup="true" CodeBehind="ConnectUser.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.ConnectUser" Title="User Connection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr><td class="tdtitle">Connect User</td></tr>
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
        						
						        <td class="tdStyle" style="width:25%" >
						        Customer Name</td>
        						
						        <td class="tdStyle" colspan="3">
						        <asp:TextBox ID="_tbCustomerName" runat="server" AutoCompleteType="FirstName" 
                                        MaxLength="50" Width="200px" ReadOnly="True" CssClass="TextBoxBorder"></asp:TextBox>
        						
						        &nbsp;</td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">
						        Connection Date</td>
        						
						        <td class="tdStyle">						
						            <asp:TextBox id="_tbConnDate" runat="server" Width="200px" 
                                         BackColor="#F6F6F6" CssClass="TextBoxBorder"></asp:TextBox>
        							
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  CssClass="ajax__calendar"
                                        PopupPosition="Right" TargetControlID="_tbConnDate" DaysModeTitleFormat="MMMM,yyyy" 
                                        Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
        							
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbConnDate" ErrorMessage="*" ></asp:RequiredFieldValidator>
                                </td>
        						
					            <td class="tdStyle">
                                    
                                </td>
                                <td class="tdStyle">
                                    &nbsp;</td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">Username</td>
        						
						        <td class="tdStyle" width="20%">
						        <asp:TextBox ID="_tbUserName" runat="server" MaxLength="20" Width="200px" 
                                        CssClass="TextBoxBorder"  ></asp:TextBox>
        						
						            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="_tbUserName" ErrorMessage="*" ValidationGroup="uavail"></asp:RequiredFieldValidator>
        						
						        &nbsp;</td>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">Password*</td>
        						
						        <td class="tdStyle" colspan="3">
						        <asp:TextBox ID="_tbPassword" runat="server" MaxLength="20" Width="200px" 
                                        TextMode="Password" CssClass="TextBoxBorder"></asp:TextBox>
        						
						        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="_tbPassword" 
                                        ErrorMessage="Required Field. Cannot be left empty" Display="Dynamic" 
                                        ForeColor="#0066FF"></asp:RequiredFieldValidator>
						        </td>
        						
					        </tr>
        					
					        <tr>
        						
						        <td class="tdStyle">Confirm Password*</td>
        						
						        <td class="tdStyle" colspan="3">
						        <asp:TextBox ID="_tbConfirmPassword" runat="server" MaxLength="20" Width="200px" 
                                        TextMode="Password" CssClass="TextBoxBorder"></asp:TextBox>
        						
						        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="_tbConfirmPassword" 
                                        ErrorMessage="Required Field. Cannot be left empty" Display="Dynamic" 
                                        ForeColor="#0066FF"></asp:RequiredFieldValidator>
						        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="_tbPassword" ControlToValidate="_tbConfirmPassword" 
                                        Display="Dynamic" ErrorMessage="Passwords do not match" ForeColor="#0066FF"></asp:CompareValidator>
						        </td>
        						
					        </tr>
        					
					        <tr>
                                <td class="tdStyle">Connected from POP*</td>
                                <td class="tdStyle" colspan="3">
                                    <asp:DropDownList ID="_ddlPopName" runat="server" CssClass="EntryBoxBorder" Height="22px"  Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""> Select POP user connected to </asp:ListItem>                                     

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_ddlPopName" Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" ForeColor="#0066FF"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">Connection Type*</td>
                                <td class="tdStyle" colspan="3">
                                  
                                    <asp:DropDownList ID="ddlConnectionType" runat="server" CssClass="EntryBoxBorder" Height="22px"  Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Value=""> Select Connection Type</asp:ListItem>   
                                        <%--  <asp:ListItem Value=""> select connection type </asp:ListItem>
                                        <asp:ListItem Value="POP(CAT5/CAT6)">POP (CAT5/CAT6)</asp:ListItem>
                                        <asp:ListItem Value="ADSL2+">ADSL2+</asp:ListItem>
                                        <asp:ListItem Value="WIRELESS">WIRELESS</asp:ListItem>
                                        <asp:ListItem Value="FTTB(GEPON)">FTTB(GEPON)</asp:ListItem>
                                        <asp:ListItem Value="FTTH(Active MC)">FTTH(Active MC)</asp:ListItem>
                                        <asp:ListItem Value="FTTH(GEPON)">FTTH(GEPON)</asp:ListItem>
                                        <asp:ListItem Value="EOC">EOC</asp:ListItem>--%>
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


                <tr>
        						
						        <td class="tdStyle">Latitude Installation*</td>
        						
						        <td class="tdStyle" width="20%">
						        <asp:TextBox ID="tbLatitude" runat="server" MaxLength="20" Width="200px" 
                                        CssClass="TextBoxBorder"  ></asp:TextBox>
        						
						            
        						
						        &nbsp;</td>
        						
						        <td class="tdStyle">
						         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="tbLatitude" ErrorMessage="Latitude required" ></asp:RequiredFieldValidator></td>
        						
						        <td class="tdStyle">
						            &nbsp;</td>
        						
					        </tr>


                <tr>
        						
						        <td class="tdStyle">Longitude Installation *</td>
        						
						        <td class="tdStyle" width="20%">
						        <asp:TextBox ID="tbLongitude" runat="server" MaxLength="20" Width="200px" 
                                        CssClass="TextBoxBorder"  ></asp:TextBox>
        						
						     
						        &nbsp;</td>
        						
						        <td class="tdStyle">
						                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="tbLongitude" ErrorMessage="Longitude required" ></asp:RequiredFieldValidator>
        						</td>
        						
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
						        <asp:ImageButton ID="_btnConnect" runat="server" ImageUrl="~/Images/Buttons/connect.jpg" OnClick="_btnConnect_Click"  />
        						
						        &nbsp;<asp:ImageButton ID="_imgBtnRefresh" runat="server" CausesValidation="False" 
                                        ImageUrl="~/Images/Buttons/Refresh.jpg" />
        						
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
             <caption>
                 <p style="padding-top: 15px">
                     <span>&nbsp;</span><asp:HiddenField ID="hdnValidationAnswer" runat="server" Value="" />
                     &nbsp;<asp:XmlDataSource ID="XmlDataSource" runat="server" DataFile="~/App_Data/POPType.xml" XPath="root/PopType/Type"></asp:XmlDataSource>
                 </p>
            </caption>
        </table>	
        			
      </ContentTemplate>    
    </asp:UpdatePanel>
    
</asp:Content>
