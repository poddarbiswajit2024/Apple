<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Apple_Bss.UserControl.Header" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<style type="text/css">
.lblVisible
{
	text-align:center;
	vertical-align:middle;
	padding-top:5px;		
}
.toplink a{ font:9pt arial; text-decoration:none; text-align:center}
.toplink a:hover{ font:9pt arial; text-decoration:underline ; text-align:center}
</style>
<!--  Date-->
<script language="Javascript">
<!-- Gracefully hide from old browsers
var this_weekday_name_array = new Array("Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday")	//predefine weekday names
var this_month_name_array = new Array("January","February","March","April","May","June","July","August","September","October","November","December")	//predefine month names

var this_date_timestamp=new Date()	//get current day-time stamp

var this_weekday = this_date_timestamp.getDay()	//extract weekday
var this_date = this_date_timestamp.getDate()	//extract day of month
var this_month = this_date_timestamp.getMonth()	//extract month
var this_year = this_date_timestamp.getYear()	//extract year

if (this_year < 1000)
	this_year+= 1900;	//fix Y2K problem
if (this_year==101)
	this_year=2001;		//fix Netscape browsers - it displays the year as being the year 101!

var this_date_string = this_weekday_name_array[this_weekday] + ", " + this_month_name_array[this_month] + " " + this_date + ", " + this_year	//concat long date string
// -->
</script>

<script type="text/javascript" language="javascript">
function PopupCenter(pageURL,title, w,h) 
{
var left = (screen.width/2)-(w/2);
var top = (screen.height/2)-(h/2);
var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=1, resizable=no, copyhistory=no, width=' + w + ',height='+h+ ', top=' +top+ ',left=' +left);
}
</script>

<body>

<table border="0" cellpadding="0" cellspacing="0" width="100%" height="70px" style="border-bottom:1px solid #dddddd">
    <tr>
        <td width="20%" style ="padding-left:5px">        
            <asp:Image ID="Image1" runat="server" Height="66px" 
                ImageUrl="~/Images/Logo/logo-a.bmp" Width="127px" />
        </td>
        <td width="40%">
        
       
        <table width="100%" cellpadding="0" cellspacing="0" style="height:100%">
         <tr><td style="height:50%">
         &nbsp;
        </td></tr>
        <tr><td style="text-align:right; padding-right:10px; height:50%;padding-top:12px;">
                 
            <asp:Label ID="_lblBranchDisplay" runat="server" BackColor="#EBA111" 
                BorderColor="#FFFF99" BorderWidth="2px" Font-Bold="True" Font-Names="Arial" 
                Font-Size="9pt" ForeColor="White" Height="20px" CssClass="lblVisible" 
                Width="130px"></asp:Label>
            <cc1:AlwaysVisibleControlExtender ID="_lblBranchDisplay_AlwaysVisibleControlExtender" 
                runat="server" Enabled="True" HorizontalOffset="10" 
                TargetControlID="_lblBranchDisplay" VerticalOffset="10" VerticalSide="Bottom">
            </cc1:AlwaysVisibleControlExtender>
                 
        </td></tr>
        </table>
        
       </td>
        <td width="40%">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height:100%; padding-right:10px" class="toplink">
                <tr>
                <td style="font:bold 8pt Arial; padding-bottom:10px;color:#fab10a" align="right" height="50%" width="100%">
                    
                    <span style="color:#666666"><script type="text/javascript" language="JavaScript">document.write(this_date_string)</script></span>
                    &nbsp;&nbsp; |&nbsp;&nbsp;
               
                   <a style="color: #666666; font: bold 8pt arial" href="Default.aspx">Home</a>
                            &nbsp;&nbsp;|&nbsp;&nbsp;
                  
                    <a style="color: #666666; font: bold 8pt arial" href ="javascript:PopupCenter('../ChangePassword.aspx','cp', 700,400);">  Change Password</a>
                   &nbsp;&nbsp; |&nbsp;&nbsp;
                    
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                        Font-Names="Arial" Font-Size="8pt" Font-Bold="True" CausesValidation="False" ForeColor="#666666">Logout</asp:LinkButton>
                </td>
                
                </tr>
                
                <tr>                                      
                    <td align="right" height="50%" width="100%"  style="padding-top:10px">
                        <asp:Label ID="_lblEmployeeName" runat="server" Font-Bold="True" 
                        Font-Names="Arial" Font-Size="9pt" ></asp:Label>  
                    </td>
                    
                </tr>
                
                
            </table>
        </td>
    </tr>

</table>
</body>
