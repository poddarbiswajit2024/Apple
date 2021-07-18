<%@ Page Title="Client Search and View" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master"
    AutoEventWireup="true" CodeBehind="ClientSearchView.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.ClientSearchView" %>


<%@ Register src="../../../UserControl/ClientSearchView.ascx" tagname="ClientSearchView" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ClientSearchView ID="ClientSearchView1" runat="server" />
    
</asp:Content>

