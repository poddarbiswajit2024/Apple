<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemSideMenu.ascx.cs"
    Inherits="Apple_Bss.UI.SystemManagement.SystemSideMenu" %>
 <%--   <link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />--%>
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../menuwithicons/css/menu.css" type="text/css" media="screen" />



<%--<body>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="padding-right: 0px; padding-bottom: 0px">
                <div id="ddtopmenubar" class="mattblackmenu">
                    <ul>
                        <li><a href="#" rel="ddsubmenu1">ACTION</a></li>
                    </ul>
                </div>

                <script type="text/javascript">
ddlevelsmenu.setup("ddtopmenubar", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar|sidebar")
                </script>

                <ul id="ddsubmenu1" class="ddsubmenustyle">
             
<li><a href="../../UI/Management/RegistrationReport.aspx">Registration Report</a></li>
<li><a href="../../UI/Management/PaymentCollectionReport.aspx">Bill Collection Report</a></li>
<li><a href="../../UI/Management/ConnectionReports.aspx">User Connection Report</a></li>

   <li><a href="#">System Users</a>
                        <ul>
                          <li><a href="../../UI/SystemManagement/RegisterSysUser.aspx">Register System User</a> </li>
                          <li><a href="../../UI/SystemManagement/SysUsersManage.aspx">Manage System Users</a> </li>
                        </ul>
                    </li>
                     <li><a href="#">Dark Fiber Management</a>
                        <ul>
                          <li><a href="../../UI/SystemManagement/DarkFiberUserRegister.aspx">Register User</a> </li>
                        </ul>
                    </li>
  
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
            <li><a href="../Management/RegistrationReport.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/srfix.png" />Registration Report</span></a></li>
            <li><a href="../Management/PaymentCollectionReport.aspx"><span>
                <img id="Img9" runat="server" src="~/menuwithicons/images/report1.png" />Bill Collection Report</span></a></li>
            <li><a href="../Management/ConnectionReports.aspx">
                <img id="Img12" runat="server" src="~/menuwithicons/images/paycollection.png" />User Connection Report</a></li>
            
            <li><a href="#">
                <img id="Img16" runat="server" src="~/menuwithicons/images/user1.png" />System Users</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="RegisterSysUser.aspx">
                                <img id="Img17" runat="server" src="~/menuwithicons/images/rightarrow.png" />Register System user</a></li>
                                <li><a href="SysUsersManage.aspx">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />Manage System Users</a></li>                                
                        </ul>
    </div>
    </div> 
    </li>
        <li><a href="#">
                <img id="Img18" runat="server" src="~/menuwithicons/images/fibermng.png" />Dark Fiber Management</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="DarkFiberUserRegister.aspx">
                                <img id="Img19" runat="server" src="~/menuwithicons/images/rightarrow.png" />Register User</a></li>                            
                                </ul>
                    </div>
                </div>
            </li>
    
    
     <li style="padding-right: 450px;">
              
                &nbsp;
      </li>
    
     </ul> </div>
