<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="salesAgentMenu.ascx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesExecutive.salesAgentMenu" %>
<link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />





<%--
<link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<script type="text/javascript" src="../Menu/ddlevelsmenu.js"></script>
<body>

<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right:0px; padding-bottom:0px">
<div id="ddtopmenubar" class="mattblackmenu">
<ul>

<li><a href="#" rel="ddsubmenu1">ACTION</a></li>

</ul>

        <ul>
                        <li><a href="#" rel="ddsubmenu2">Registrations</a></li>
                    </ul>
                </div>


<script type="text/javascript">
ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
</script>



<ul id="ddsubmenu1" class="ddsubmenustyle">
    
      <li><a href="#">Registrations</a>
        <ul>
           <li><a href="UserRegistration.aspx">Register Broadband User</a></li>
            <li><a href="EditRegistration.aspx">Edit Registration</a></li>					        
        </ul>
    </li>			        
    <li><a href="RegisteredConnections.aspx">Connection Reports</a></li>
    <li><a href="#">Manage References</a>
        <ul>
            <li><a href="AddConnectionReference.aspx">Add Reference</a></li>
            <li><a href="#">View Reference</a></li>					        
        </ul>
    </li>	
</ul>

  <ul id="ddsubmenu2" class="ddsubmenustyle">
      <li><a href="UserRegistration.aspx">Register Broadband User</a></li>
            <li><a href="EditRegistration.aspx">Edit Registration</a></li>					        
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
            <li><a href="UserRegistration.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/user1.png" />Register Broadband User</span></a></li>
            <li><a href="EditRegistration.aspx"><span>
                <img id="Img9" runat="server" src="~/menuwithicons/images/edit.png" />Registration Edit</span></a></li>
            <li><a href="RegisteredConnections.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/report2.png" />Connection Reports</a></li>
            
            <li><a href="#">
                <img id="Img16" runat="server" src="~/menuwithicons/images/sereq.png" />Manage References</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="AddConnectionReference.aspx">
                                <img id="Img17" runat="server" src="~/menuwithicons/images/rightarrow.png" />Add Reference</a></li>
                            <%--    <li><a href="#">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />View Reference</a></li>--%>
                                
                        </ul>
    </div>
    </div> 
    </li>    
     <li style="padding-right: 450px;">
              
                &nbsp;
      </li>
    
     </ul> </div>