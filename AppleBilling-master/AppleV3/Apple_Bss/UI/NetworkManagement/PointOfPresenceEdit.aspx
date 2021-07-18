<%@ Page Language="C#" MasterPageFile="~/UI/NetworkManagement/NetworkManagement.Master"
    AutoEventWireup="true" CodeBehind="PointOfPresenceEdit.aspx.cs" Inherits="Apple_Bss.UI.NetworkManagement.PointOfPresenceEdit"
    Title="Edit POP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">
                Point of Presence Edit Section
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" cellpadding="0" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td width="15%" class="tdStyle">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="#133572"></asp:Label>
                        </td>
                        <td class="backbtn">
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/Images/Buttons/back.png"
                                OnClick="ImageButton1_Click" Style="margin-top: 5px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong class="tdStyle">POP Name </strong>
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbPopName" runat="server" Width="300px" 
                                CssClass="TextBoxBorder" BackColor="#F2F2F2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbPopName"
                                ErrorMessage="POp Name cannot be left Empty"></asp:RequiredFieldValidator>
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
                        <td class="tdStyle">
                            Address
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbPopAddress" runat="server" Height="80px" TextMode="MultiLine" CssClass="TextBoxBorder"
                                Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbPopAddress"
                                ErrorMessage="Address filed cannot be left empty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Contact Person
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbContactPerson" runat="server" Width="200px" CssClass="TextBoxBorder"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_tbContactPerson"
                                ErrorMessage="Cannot be left blank"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Mobile Number
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbMobileNo" runat="server" CssClass="TextBoxBorder" Width="200px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="_tbMobileNo"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Landline Number
                        </td>
                        <td class="tdStyle" colspan="2">
                            <asp:TextBox ID="_tbLandLineNo" runat="server" CssClass="TextBoxBorder" Width="200px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_tbLandLineNo"
                                ErrorMessage="Enter Numbers Only" ValidationExpression="^\d{1,9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            GPD IP</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="tbGPDIP" CssClass="TextBoxBorder" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbGPDIP"
                                ErrorMessage="Cannot be left blank"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="tdStyle">
                            BPD IP</td>
                        <td class="tdStyle">
                            <asp:TextBox ID="tbBPDIP" CssClass="TextBoxBorder" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="tbBPDIP" ErrorMessage="cannot be left blank"></asp:RequiredFieldValidator>
                        </td>
                    </tr>


                    <tr>
                        <td class="tdgap" colspan="3">
                            &nbsp;
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnUpdatePop" runat="server"  OnClick="_btnUpdatePop_Click"
                                ImageUrl="~/Images/Buttons/Update POP.jpg"/>
                        </td>
                        <td class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="3">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
