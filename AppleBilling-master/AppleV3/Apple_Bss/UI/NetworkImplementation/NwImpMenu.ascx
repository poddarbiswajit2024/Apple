<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NwImpMenu.ascx.cs" Inherits="Symb_InetBill.UI.NetworkImplementation.NwImpMenu" %>
       
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../menuwithicons/css/menu.css" type="text/css" media="screen" />
        
          <%-- <link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
        <link rel="stylesheet" type="text/css" href="Menu/ddlevelsmenu-base.css" />
            <script type="text/javascript" src="Menu/ddlevelsmenu.js"></script>

          <body>

            <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td style="padding-right:0px; padding-bottom:0px">
            <div id="ddtopmenubar" class="mattblackmenu">
            <ul>

            <li><a href="#" rel="ddsubmenu1">Action</a></li>

            </ul>
            </div>

            <script type="text/javascript">
            ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
            </script>



            <ul id="ddsubmenu1" class="ddsubmenustyle">
            <li><a href="Reg_UserConnectivityDetails.aspx">Bind User To POP</a></li>
            <li><a href="DailyPopMaintenance.aspx">POP Maintenance</a></li>
            <li><a href="DailyFiberMaintenance.aspx">Fiber Maintenance</a></li>

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
            <li><a href="Reg_UserConnectivityDetails.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/user1.png" />Bind user to POP</span></a></li>
            <li><a href="DailyPopMaintenance.aspx"><span>
                <img id="Img9" runat="server" src="~/menuwithicons/images/popmng.png" />POP Maintenance</span></a></li>
            <li><a href="DailyFiberMaintenance.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/fibermng.png" />Fiber Maintenance</a></li>   
    
    
     <li style="padding-right: 1050px;">
              
                &nbsp;
      </li>
    
     </ul> </div>