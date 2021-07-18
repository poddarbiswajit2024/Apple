<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
	AutoEventWireup="true" CodeBehind="PointOfPresence.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.PointOfPresence"
	Title="POP Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table class="mainTable" cellpadding="0" cellspacing="0" align="center">
		<tr>
			<td class="tdtitle">Add Point of Presence
			</td>
		</tr>
		<tr>
			<td class="mainTD">
				<table class="tableStyle" align="left" cellpadding="0px" cellspacing="0px">
					<tr>
						<td colspan="2" class="tdStyle">
							<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp;
						</td>
					</tr>
					<tr>
						<td style="width: 15%" class="tdStyle">POP Name*
						</td>
						<td style="width: 85%" class="tdStyle">
							<asp:TextBox ID="_tbPopName" runat="server" Width="300px"
								CssClass="TextBoxBorder"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbPopName"
								ErrorMessage="POP Name cannot be left Empty"></asp:RequiredFieldValidator>
						</td>
					</tr>

                    	<tr>
						<td class="tdStyle">Location</td>
						<td class="tdStyle">
							<asp:DropDownList ID="ddlLocation" runat="server" CssClass="TextBoxBorder">
                                <asp:ListItem Value="">Select Location</asp:ListItem>
                                <asp:ListItem Value="DMP">Dimapur</asp:ListItem>
                                <asp:ListItem Value="KOH">Kohima</asp:ListItem>
                                <asp:ListItem Value="MKG">Mokokchung</asp:ListItem>
                                <asp:ListItem Value="WKA">Wokha</asp:ListItem>
                            </asp:DropDownList>
						    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlLocation"
								ErrorMessage="Required"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="tdStyle">Address*
						</td>
						<td class="tdStyle">
							<asp:TextBox ID="_tbPopAddress" runat="server" Height="80px" TextMode="MultiLine"
								Width="300px" CssClass="TextBoxBorder"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbPopAddress"
								ErrorMessage="Address filed cannot be left empty"></asp:RequiredFieldValidator>
						</td>
					</tr>
				
					<tr>
						<td class="tdStyle">Contact Person*</td>
						<td class="tdStyle">
							<asp:TextBox ID="_tbContactPerson" runat="server" Width="200px"
								CssClass="TextBoxBorder"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_tbContactPerson"
								ErrorMessage="Cannot be left blank"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="tdStyle">Mobile Number
						    *</td>
						<td class="tdStyle">
							<asp:TextBox ID="_tbMobileNo" runat="server" Width="200px"
								CssClass="TextBoxBorder"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_tbMobileNo"
								ErrorMessage="Enter Numbers Only" ValidationExpression="^\d{0,11}$"></asp:RegularExpressionValidator>
							&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_tbMobileNo"
								ErrorMessage="Required"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="tdStyle">Landline Number
						</td>
						<td class="tdStyle">
							<asp:TextBox ID="_tbLandLineNo" runat="server" Width="200px"
								CssClass="TextBoxBorder"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_tbLandLineNo"
								ErrorMessage="Enter Numbers Only" ValidationExpression="^\d{0,11}$"></asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="tdStyle">GPD IP*</td>
						<td class="tdStyle">
							<asp:TextBox ID="tbGPDIP" CssClass="TextBoxBorder" runat="server" Width="200px"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbGPDIP"
								ErrorMessage="Cannot be left blank"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="vldRejex" runat="server"
								ControlToValidate="tbGPDIP"
								ErrorMessage="Please enter a valid IP Address"
								ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$">
							</asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr>
						<td class="tdStyle">BPD IP*</td>
						<td class="tdStyle">
							<asp:TextBox ID="tbBPDIP" CssClass="TextBoxBorder" runat="server" Width="200px"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
								ControlToValidate="tbBPDIP" ErrorMessage="cannot be left blank"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
								ControlToValidate="tbBPDIP"
								ErrorMessage="Please enter a valid IP Address"
								ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$">
							</asp:RegularExpressionValidator>
						</td>
					</tr>
					<tr class="tdgap">
						<td class="tdgap" colspan="2">&nbsp;
                            &nbsp;
						</td>
					</tr>
					<tr>
						<td class="tdStyle">&nbsp;
						</td>
						<td class="tdStyle">

							<asp:ImageButton ID="_btnAddPop" runat="server" OnClick="_btnAddPop_Click" ImageUrl="~/Images/Buttons/Add POP.jpg" CausesValidation="true" />
							&nbsp;<asp:ImageButton ID="_btnCancel" runat="server" OnClick="_btnCancel_Click"
								ImageUrl="~/Images/Buttons/cancel.jpg" CausesValidation="False" />
						</td>
					</tr>
					<tr>
						<td class="tdgap" colspan="2">&nbsp;
                            &nbsp;
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
