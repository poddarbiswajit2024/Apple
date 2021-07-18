<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpDeskMenu.ascx.cs"
    Inherits="Apple_Bss.UI.TechnicalSupport.HelpDesk.HelpDeskMenu" %>
    <link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />






<div class="container">
        <ul id="nav">
            <li><a href="Default.aspx">
                <img id="Img1" runat="server" src="~/menuwithicons/images/home.png" />
                Home</a></li>

                   <li><a href="ClientSearchView.aspx">
                <img id="Img6" runat="server" src="~/menuwithicons/images/user1.png" />Client Search View</a></li> 


                      <li><a href="RaiseBroadbandSR.aspx">
                <img id="Img16" runat="server" src="~/menuwithicons/images/telephone.png" />Raise Support Request</a>
                <%--<div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="RaiseBroadbandSR.aspx">
                                <img id="Img17" runat="server" src="~/menuwithicons/images/rightarrow.png" />Broadband SR</a></li>
                                <li><a href="RaiseCableUserSR.aspx">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />Cable SR</a></li></ul>
    </div>
    </div> --%>


    </li>
               <li><a href="ServiceRequestSearch.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/report1.png" />Service Requests Search</a></li> 


                     <li><a href="#">
                <img id="Img2" runat="server" src="~/menuwithicons/images/fibermng.png" />Service Requests Reports</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="Rep_ViewServiceRequests.aspx">
                                <img id="Img4" runat="server" src="~/menuwithicons/images/rightarrow.png" />Broadband SRs Reports</a></li>
                                <li><a href="CableSRReport.aspx">
                                <img id="Img5" runat="server" src="~/menuwithicons/images/rightarrow.png" />Cable SRs Reports</a></li></ul>
    </div>
    </div> 
    </li>
            


         
    
     <li style="padding-right: 850px;">
              
                &nbsp;
      </li>
    
     </ul> </div>