﻿<%@ Page Title="Edit Agents" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master"
    AutoEventWireup="true" CodeBehind="AgentEdit.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.AgentEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
            Agent Management :: Edit
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellpadding="0" cellspacing="0" class="tableStyle" border="0" align="center">
                    <tr class="tdStyle">
                        <td colspan="2" class="backbtn">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Buttons/back.png"
                                PostBackUrl="~/UI/MarketingAndSales/SalesHead/AgentsView.aspx" CausesValidation="false" EnableViewState="false" />
                        </td>
                    </tr>
                    <tr class="tdStyle">
                        <td colspan="2" class="tdStyle">
                            <asp:Label ID="_lblSuccess" runat="server"  CssClass="lblSuccess"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="120" class="tdStyle">
                            Agent Name
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbAgentName" runat="server" Width="200px" 
                                CssClass="TextBoxBorder" BackColor="#F2F2F2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbAgentName"
                                ErrorMessage="Cannot be left blank"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Contact Address
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbAgentAddress" runat="server" Height="80px" TextMode="MultiLine"
                                Width="300px" CssClass="TextBoxBorder"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbAgentAddress"
                                ErrorMessage="Address Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Contact Number
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="_tbContactNumber" runat="server" Width="200px" 
                                CssClass="TextBoxBorder"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter numbers only"
                                ValidationExpression="^\d{0,10}$" ControlToValidate="_tbContactNumber"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr class="tdgap">
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnAgentUpdate" runat="server"  OnClick="_btnAgentUpdate_Click"
                                ImageUrl="~/Images/Buttons/update.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tdgap">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
