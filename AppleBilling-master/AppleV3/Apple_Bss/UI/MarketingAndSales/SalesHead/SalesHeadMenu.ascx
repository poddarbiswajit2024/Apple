<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesHeadMenu.ascx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.SalesHeadMenu" %>
<link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />




<div class="container">
        <ul id="nav">
            <li><a href="Default.aspx">
                <img id="Img1" runat="server" src="~/menuwithicons/images/home.png" />
                Home</a></li>
            <li><a href="UserRegistration.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/user1.png" />Register</span></a></li>
            <li><a href="ManagePendingUserRegistrationsAll.aspx"><span>
                <img id="Img9" runat="server" src="~/menuwithicons/images/edit.png" />Manage Registrations</span></a></li>
             <li><a href="ManageRejectedRegistrationsAll.aspx"><span>
                <img id="Img4" runat="server" src="~/menuwithicons/images/Arrears1.png" />Rejected Registrations</span></a></li>
            <li><a href="ViewRegisteredConnections.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/report1.png" />Reports</a></li>
            
            <li><a href="#">
                <img id="Img16" runat="server" src="~/menuwithicons/images/fibermng.png" />Agents</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="AgentRegistration.aspx">
                                <img id="Img17" runat="server" src="~/menuwithicons/images/rightarrow.png" />Agent Registration</a></li>
                                <li><a href="AgentsView.aspx">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />View Agents</a></li>                                
                        </ul>
                     </div>
                </div> 
         </li>
              <li><a href="DefaultPaperless.aspx">
                <img id="Img5" runat="server" src="~/menuwithicons/images/trafficplan.png" />Paperless Registration</a></li>

            

    <li style="padding-right: 450px;">
              
                &nbsp;
      </li>
       

     </ul> 

</div>

