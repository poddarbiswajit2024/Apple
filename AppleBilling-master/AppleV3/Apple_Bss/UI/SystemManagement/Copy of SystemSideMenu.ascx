<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemSideMenu.ascx.cs"
    Inherits="Apple_Bss.UI.SystemManagement.SystemSideMenu" %>
<link rel="stylesheet" type="text/css" href="Menu/ddlevelsmenu-base.css" />
<script type="text/javascript" src="Menu/ddlevelsmenu.js"></script>

<body>
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
</body>


