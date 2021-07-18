<%@ Page Title="Client Search and View" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="ClientSearchView.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.ClientSearchView" %>


<%@ Register src="../../../UserControl/ClientSearchView.ascx" tagname="ClientSearchView" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ClientSearchView ID="ClientSearchView1" runat="server" />
    
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="headContentPlaceHolder">
</asp:Content>

