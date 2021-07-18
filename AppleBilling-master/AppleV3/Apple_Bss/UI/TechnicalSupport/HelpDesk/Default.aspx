<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TechnicalSupport/HelpDesk/HelpDesk.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/LoggedActivity.ascx" TagName="LoggedActivity"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="../../../CSS/InetBill.css" rel="stylesheet" type="text/css" />
    <link href="../../../CSS/accordion.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>

    <script src="../../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>

    <script src="../../../Scripts/acc_script.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0" style="vertical-align: top">
        <tr>
            <td width="30%" style="text-align: center; vertical-align: top">
                <img src="../../../Images/Pictures/technical_support.jpg" alt="" />
            </td>
            <td style="vertical-align: top; padding-left: 10px" width="70%">
                <!-- change-->
                <div id="main">
                    <ul class="container">
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#">
                                    <div runat="server" id="divnewnotice" style="width: auto; height: auto; float: left;
                                        margin-top: 5px">
                                        <table id="Table_01" width="32" height="29" border="0" cellpadding="0" cellspacing="0"
                                            style="float: left; margin-right: 10px;">
                                            <tr>
                                                <td style="background-image: url(../../../Images/Buttons/SMS_01.png); background-repeat: no-repeat;"
                                                    width="17" height="29">
                                                    &nbsp;
                                                </td>
                                                <td style="background-image: url(../../../Images/Buttons/SMS_02.png); background-repeat: no-repeat;
                                                    font: bold 8pt arial; color: White;" width="15" height="29" valign="top">
                                                    <asp:Literal ID="lblToday" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="font: bold 10pt arial; color: #ffffff; width: auto; height: auto; float: left;
                                            margin-top: 5px;">
                                            New Service Request SMS
                                        </div>
                                    </div>
                                    <div style="font: bold 10pt arial; color: #ffffff; width: auto; height: auto; float: right;
                                        margin-top: 5px">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>                                   
                                        
                                            <asp:Label ID="lblPageNo" runat="server"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GridView1"/>
                                        </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div runat="server" id="divNoSRNotice" visible="false">
                                        <div style="float: left; margin-right: 10px; width: auto; height: auto">
                                            <img src="../../../Images/Buttons/mail2.png" alt="" />
                                        </div>
                                        <div style="font: bold 10pt arial; color: #ffffff; width: auto; height: auto; float: left;
                                            margin-top: 5px">
                                            No Service Request SMS</div>
                                    </div>
                                </a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li>
                                            <div style="padding: 0 10px 0 10px;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                Width="95%" CellPadding="1" GridLines="None" HorizontalAlign="Left" CssClass="gridStyle"
                                                                AllowPaging="True" ShowHeader="False" PageSize="5">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 760px; height: auto;">
                                                                                <b>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "SMSMobileNumber")%>
                                                                                </b><span class="fadedtext">sent an sms </span>
                                                                                <%# DataBinder.Eval(Container.DataItem, "RequestMessage")%>
                                                                                <span class="fadedtext">on </span>
                                                                                <%# DataBinder.Eval(Container.DataItem, "FirstReceivedTime", "{0: h:mm tt  MMMM dd, yyyy }")%>
                                                                            </div>
                                                                            <div style="float: right; width: 28px; height: auto;">
                                                                                <a href="SMS_SRDetails.aspx?srid=<%#Eval("issueid")%>&username=<%#Eval("username")%>">
                                                                                    <img alt="update SR" style="border: 0; width: 28px; height: auto" src="../../../Images/Buttons/save_accept.png"
                                                                                        title="Update SR" />
                                                                                </a>
                                                                            </div>
                                                                            <br />
                                                                            <div class="timeDateRow">
                                                                                <b>Client Details:</b> <b>Username :</b>
                                                                                <%# DataBinder.Eval(Container.DataItem, "username")%>
                                                                                <b>Available Mobile No. :</b>
                                                                                <%# DataBinder.Eval(Container.DataItem, "StoredMobileNumber")%>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                Generated SRID : <font color="red">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "issueid")%></font>
                                                                                <br />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="itemRowStyle" Width="90%" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerSettings FirstPageText="Oldest" LastPageText="Newest" Mode="NextPreviousFirstLast"
                                                                    NextPageText="Newer" PreviousPageText="Previous" />
                                                                <PagerStyle CssClass="gridPagerStyle" />
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <%--  <cc1:CollapsiblePanelExtender TargetControlID="Panel1" CollapseControlID="lbSRNotice"
                            Collapsed="true" ExpandControlID="lbSRNotice" ID="CollapsiblePanelExtender1"
                            runat="server" SuppressPostBack="True">
                        </cc1:CollapsiblePanelExtender>--%>
                <uc1:LoggedActivity ID="LoggedActivity1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
