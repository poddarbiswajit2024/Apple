﻿<%@ Page Language="C#" MasterPageFile="~/UI/NetworkImplementation/NwImplementation.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Symb_InetBill.UI.NetworkImplementation.Default" Title="Untitled Page" %>
<%@ Register src="../../UserControl/LoggedActivity.ascx" tagname="LoggedActivity" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <table cellpadding="0" cellspacing="0" width="100%" align="center"  border="0" style="vertical-align: top">
<tr>
<td width="30%"  style="text-align:center; vertical-align: top">
            <img src="../../Images/Pictures/networkimplementation.jpg" alt="" /> 
           </td>          
<td style="vertical-align:top; padding-left: 10px" width="70%" >
    <uc1:LoggedActivity ID="LoggedActivity1" runat="server" />
             </td>
 </tr>
</table>
    
</asp:Content>