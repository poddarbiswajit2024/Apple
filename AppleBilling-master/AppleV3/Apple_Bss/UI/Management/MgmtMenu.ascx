<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MgmtMenu.ascx.cs" Inherits="Symb_InetBill.UI.Management.MgmtMenu" %>
<%--<%@ Register src="~/UI/Management/SystemUserMenu.ascx" tagname="SystemUserMenu" tagprefix="uc1" %>--%>


<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../menuwithicons/css/menu.css" type="text/css" media="screen" />
<%--
<link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<body>

<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="50%"  style="padding-right:0px; padding-bottom:0px">
<div id="ddtopmenubar" class="mattblackmenu">
<ul>

    

<li><a href="#" rel="ddsubmenu1">ACTION</a></li>

</ul>
</div>

<script type="text/javascript">
ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>

<ul id="ddsubmenu1" class="ddsubmenustyle">
<li><a href="RegistrationReport.aspx">Registration Report</a></li>
 <li><a href="#">Collection Report</a>
                        <ul>
                          <li><a href="PaymentCollectionReport.aspx">Payment Collection</a> </li>
                          <li><a href="BillCollectionSummary.aspx">Bill Collection Summary</a> </li>
                        </ul>
                    </li>
<li><a href="ConnectionReports.aspx">User Connection Report</a></li>
<uc1:SystemUserMenu ID="SystemUserMenu1" runat="server" Visible="false" />

</ul>

</td>
</tr>

</table>



</body>--%>

    <div class="container">
            <ul id="nav">
                <li><a href="Default.aspx">
                    <img id="Img1" runat="server" src="~/menuwithicons/images/home.png" />
                    Home</a></li>
                <li><a href="RegistrationReport.aspx"><span>
                    <img id="Img2" runat="server" src="~/menuwithicons/images/srfix.png" />Registration Report</span></a></li>                
                <li><a href="#">
                    <img id="Img12" runat="server" src="~/menuwithicons/images/paycollection.png" />Collection Report</a>
                    <div class="subs">
                        <div class="col">
                            <ul>
                                <li><a href="PaymentCollectionReport.aspx">
                                    <img id="Img13" runat="server" src="~/menuwithicons/images/rightarrow.png" />Payment Collection</a></li>
                                <li><a href="BillCollectionSummary.aspx">
                                    <img id="Img14" runat="server" src="~/menuwithicons/images/rightarrow.png" />Bill Collection Summary</a></li>
                            
                            </ul>
                        </div>
                    </div>
                </li>
            
                <li><a href="ConnectionReports.aspx">
                    <img id="Img16" runat="server" src="~/menuwithicons/images/dark.png" />User Connection Report</a></li> 
                    
            <%--        <uc1:SystemUserMenu ID="SystemUserMenu1" runat="server" Visible="false" />   --%>  
    
         <li style="padding-right: 800px;">
              
                    &nbsp;
          </li>
    
         </ul> </div>