<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceRequestDetail.aspx.cs"
 Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.ServiceRequestDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Validate Fixed Service Request</title>
    <link rel="Stylesheet" href="../../../CSS/InetBill.css" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>

<link rel="stylesheet" href="../../../CSS/InetBill.css" media="screen" type="text/css" />
<table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
    <tr>
        <td class="tdtitle">
            Fixed
            Service Request&nbsp; Details
        </td>
    </tr>
    <tr>
        <td class="mainTD">
            <table cellspacing="0" cellpadding="0" border="0" align="center" class="tableStyle">
                <tr>
                    <td colspan="2" class="tdgap">
                    </td>
                </tr>
                <tr>
                    <td class="tdStyle" width="20%">
                        SR Number
                    </td>
                    <td class="tdStyle">
                        <asp:Label ID="_lblSRN" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
           
                <tr>
                    <td class="tdStyle">
                        Issue Reported
                    </td>
                    <td class="tdStyle">
                        <asp:Label ID="_lblIssueReported" runat="server"></asp:Label>
                    </td>
                </tr>

                     <tr>
                    <td class="tdStyle">
                        Status
                    </td>
                    <td class="tdStyle">
                        <asp:Label ID="_lblStatus" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
          
                <tr>
                    <td class="tdStyle">
                        UserID</td>
                    <td class="tdStyle">
                        <asp:Label ID="lblUserId" runat="server"></asp:Label>
                    </td>
                </tr>
          
                <tr>
                    <td class="tdgap" colspan="2">
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
        <td class="mainTD">
            <div class="tdSubtitle">Action History</div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="0" cellpadding="0" cellspacing="0"  align="center"  class="tableStyle">
                       
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tdStyle">
                        <td style="width: 30%; vertical-align: top; padding-left: 5px">
                            <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"MODON")).ToString("f") %>
                        </td>
                        <td style="width: 50%; vertical-align: top">
                            <%# DataBinder.Eval(Container.DataItem,"ACTIONTAKEN") %>
                        </td>
                        <td style="width: 20%; vertical-align: top">
                            <%# DataBinder.Eval(Container.DataItem,"ACTIONBY") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="3" class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td class="tdgap">
        </td>
    </tr>
    <tr>
        <td class="mainTD">
            <div class="tdSubtitle"> Action</div>
            <asp:Panel ID="Panel1" runat="server">

          
                <table border="0" cellpadding="0" cellspacing="0"  align="center" class="tableStyle">
                    
                    <tr>
                        <td class="tdgap" width="20%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    
                    
                    
                            
                    <tr>
                        <td class="tdStyle">
                            Verification Call Date &amp; Time<span style="color:Red">*</span>
                        </td>
                        <td class="tdStyle" width="25%">
                            <asp:TextBox ID="_txtEndDate" runat="server" Width="150px" 
                                CssClass="TextBoxBorder" />

                         

                            <cc1:CalendarExtender ID="_txtEndDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="_txtEndDate" Format="dd-MMM-yyyy" >
                            </cc1:CalendarExtender>

                         

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_txtEndDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="tdStyle">
                            Time:
                            <asp:DropDownList ID="_ddlHours" runat="server" Height="20px" Width="40px" AppendDataBoundItems="true"
                                DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">hh</asp:ListItem>                          
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_ddlHours"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            &nbsp;<asp:DropDownList ID="_ddlMinutes" runat="server" Height="20px" Width="50px" 
                                DataSourceID="XmlDataSource2" AppendDataBoundItems="true" DataTextField="text" DataValueField="value">
                                <asp:ListItem Selected="True" Value="">mm</asp:ListItem>
                             
                            </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="_ddlMinutes"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
   <td class="tdStyle">
                            Remarks/ Customer Feedback
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:TextBox ID="_tbActionTaken" runat="server" AutoCompleteType="FirstName" Font-Names="Arial"
                                MaxLength="50" Rows="4" TextMode="MultiLine" Width="400px" 
                                CssClass="TextBoxBorder" Height="60px"></asp:TextBox>
                      
                        </td>
                    </tr>
                    
                    
                    
                            
                    
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2" class="tdStyle">
                            <asp:ImageButton ID="imgBtnClose" runat="server" 
                                AlternateText="Close Service Request" ImageUrl="~/Images/Buttons/close_servicereq.png" 
                                onclick="imgBtnClose_Click"/>
                      
                            &nbsp;<asp:ImageButton ID="imgBtnPending" runat="server"  AlternateText="Reopen Service Request"
                                ImageUrl="~/Images/Buttons/reopen_service.png" 
                                onclick="imgBtnPending_Click"/>
                      
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="2">
                        </td>
                        <td class="tdgap">
                        </td>
                    </tr>
                </table>
         </asp:Panel>
            
        </td>
    </tr>
</table>
<%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                                DataFile="~/App_Data/data.xml" 
        XPath="root/Hours/Hour"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" 
                                DataFile="~/App_Data/data.xml" 
        XPath="root/Minutes/Min"></asp:XmlDataSource>
    
    </form>
</body>
</html>
