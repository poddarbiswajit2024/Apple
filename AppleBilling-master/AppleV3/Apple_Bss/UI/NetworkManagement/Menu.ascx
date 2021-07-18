<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="Symb_InetBill.UI.NetworkManagement.Menu.Menu" %>

<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />



<div class="container">
        <ul id="nav">
            <li><a href="Default.aspx">
                <img id="Img1" runat="server" src="~/menuwithicons/images/home.png" />
                Home</a></li>
            <li><a href="PointOfPresenceView.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/popmng.png" />POP Manage</span></a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="PointOfPresence.aspx">
                                <img id="Img5" runat="server" src="~/menuwithicons/images/rightarrow.png" />Add POP</a></li>
                            <li><a href="PointOfPresenceView.aspx">
                                <img id="Img6" runat="server" src="~/menuwithicons/images/rightarrow.png" />View POP</a></li>
                            
                        </ul>
                    </div>
                </div>
                </li>
            <li><a href="PendingConnections.aspx"><span>
                <img id="Img9" runat="server" src="~/menuwithicons/images/pending.png" />Pending Connection</span></a></li>
            <li><a href="Rep_ViewServiceRequests.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/sereq.png" />Service Request</a></li>
            
            <li><a href="BroadbandUsers.aspx">
                <img id="Img16" runat="server" src="~/menuwithicons/images/dark.png" />BroadBand Users</a></li>
        <li><a href="#">
                <img id="Img18" runat="server" src="~/menuwithicons/images/report.png" />Reports</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="PopMaintenanceReport.aspx">
                                <img id="Img19" runat="server" src="~/menuwithicons/images/rightarrow.png" />POP Maintenance Report</a></li>
                            <li><a href="FiberMaintenanceReport.aspx">
                                <img id="Img20" runat="server" src="~/menuwithicons/images/rightarrow.png" />Fiber Maintenance Report</a></li>
                                </ul>
                    </div>
                </div>
            </li>
    <li><a href="DarkFiberConnections.aspx">
                <img id="Img21" runat="server" src="~/menuwithicons/images/fibermng.png" />Dark Fiber Clients</a></li>
    
     <li style="padding-right: 450px;">
              
                &nbsp;
      </li>
    
     </ul> </div>