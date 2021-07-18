<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apple_Bss._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Login Page</title>
    
<style type="text/css">
.punchLine{font:bold 9pt Arial Narrow; color:White; padding-left:0px; text-align:left; padding-top:0px }
.tableStyle{font: 9pt arial; color:#4c4c4c; text-align:left}
.tdTitle{font:bold 11pt arial; color:#4c4c4c; text-align:left}
.tdStyle{ padding-left:0px; padding-bottom:2px;}
.txtBox{ padding-left:0px; padding-bottom:2px; border: solid 1px #b6b6b6; width:260px; height:18px}
.tdgap{ height:5px}
.css2 a
{
	font: 8pt arial; padding-left:0px; padding-bottom:2px; color:#fab10a; text-decoration:none;
}
.css2 a:hover
{
	font: 8pt arial; padding-left:0px; padding-bottom:2px; color:#a9a9a9; text-decoration:underline;
}
.copyright{color:#a9a9a9; font: 8pt arial; padding:0px; text-align:left;}
    .style1
    {
        font-family: Arial, Helvetica, sans-serif;
        font-size: 14pt;
        font-weight: bold;
    }
    .style2
    {
        font: normal normal bold 12pt normal Arial, Helvetica, sans-serif;
        color: White;
        padding-left: 0px;
        text-align: center;
        padding-top: 0px;
    }
</style>    

</head>
<body style="margin:0" bgcolor="White">
    <form id="form1" runat="server">
  
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr><td valign="middle" height="500px" width="100%">
  <%--<table id="Table_01" width="650" border="0" cellpadding="0" cellspacing="0" align="center" style="height: 406px">
	<tr>
		<td class="style2" colspan="2" 
            style="background-image: url('Images/Pictures/Img_01.jpg'); background-repeat: no-repeat; background-position: left top; width: 248px; height: 80px">
			<div style="width: 193px; margin-left: 34px; margin-top: 25px" >Apple helps SymBios <br /> to work more efficiently</div>
	    </td>
		<td style="background-image: url('Images/Pictures/Img_02.jpg'); background-repeat: no-repeat; background-position: left top; width: 402px; height: 80px">
			&nbsp;
		</td>
	</tr>
	
	<tr>
		<td colspan="2" style="background-image: url('Images/Pictures/Img_03.jpg'); background-repeat: no-repeat; background-position: left top; width: 248px; height: 80px">
			&nbsp;
		</td>
		<td style="background-image: url('Images/Pictures/Img_04.jpg'); background-repeat: repeat-y; background-position: left top; width: 402px; " rowspan="4" align="center" valign="top">
			
			
		</td>
	</tr>
	
	<tr>
		<td colspan="2" style="background-image: url('Images/Pictures/Img_05.jpg'); background-repeat: no-repeat; background-position: left top; width: 248px; height: 80px">
			&nbsp;
		</td>
	</tr>
	
	<tr>
		<td colspan="2" style="background-image: url('Images/Pictures/Img_07.jpg'); background-repeat: no-repeat; background-position: left top; width: 248px; height: 50px">
			&nbsp;
		</td>
	</tr>
	
	<tr>
		<td style="background-image: url('Images/Pictures/Img_09.jpg'); background-repeat: no-repeat; background-position: left top; width: 42px; height: 64px">
		&nbsp;
		</td>
		<td>
			<img src="Images/Logo/Logo.jpg" width="206" height="64" alt="Apple" /></td>
	</tr>
	
	<tr>
		<td colspan="3" style="background-image: url('Images/Pictures/Img_12.jpg'); background-repeat: no-repeat; background-position: left top; width: 650px; height: 52px">
	        <div style="color:White; font:7pt arial; width:58px; margin-left: 190px; margin-bottom: 11px;">Version 2.1.0</div>
	    </td>
	</tr>
</table>--%>

<table align="center" id="Table_01" width="650px" height="406px" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td rowspan="6">
			<img src="Images/Pictures/LoginImg_01.jpg" width="35px" height="406px" alt=""></td>
		<td colspan="3">
			<img src="Images/Pictures/LoginImg_02.jpg" width="582px" height="25px" alt=""></td>
		<td rowspan="6">
			<img src="Images/Pictures/LoginImg_03.jpg" width="33px" height="406px" alt=""></td>
	</tr>
	<tr>
		<td style="background-image: url('Images/Pictures/LoginImg_04.jpg'); background-repeat: no-repeat; background-position: left top;" 
            width="213px" height="249px" valign="top">
			
			<div class="punchLine" 
                style="width: 193px; margin-left: 10px; margin-top: 10px" >
			        <b><i>Apple BSS: Applied e-Business Support Systems </i></b> provides e-Enabled platform for managing the IT & ISP business vertical of SymBios Creations. This application is a product of our in house development. Apple will be scaled to encompass all other businesses in the realm of IT & ISP.
			
			</div>
		
		

			
        </td>
		<td rowspan="4">
			<img src="Images/Pictures/LoginImg_05.jpg" width="20px" height="351px" alt=""></td>
		<td rowspan="4" width="349px" height="351px" bgcolor="White" valign="top">
		
			<%--FORM AREA--%>
			
			<table align="left" border="0" cellpadding="0" cellspacing="0" width="80%" 
                style="margin-left: 30px; margin-top: 25px;" class="tableStyle">
			 
			 <tr><td class="style1">User Login</td></tr>
			 <tr><td class="tdTitle">&nbsp;</td></tr>
			 
			 <tr><td class="tdStyle">
                 <asp:Label ID="_lblStat" runat="server" ForeColor="Red" 
                     style="font-family: 'Arial Narrow'; font-size: 10pt" Font-Bold="True"></asp:Label>&nbsp;</td></tr>
			 
			 <tr><td class="tdStyle">&nbsp;</td></tr>
			 
			 <tr><td class="tdStyle">Employee ID:</td></tr>
			 
			 <tr><td class="tdStyle">
                 <asp:TextBox ID="_tbEmployeeID" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td></tr>
			 
			 <tr><td class="tdgap"></td></tr>
			 
			 <tr><td class="tdStyle">Password:</td></tr>
			 
			 <tr><td class="tdStyle">
                 <asp:TextBox ID="_tbPasswrd" runat="server" CssClass="txtBox" 
                     TextMode="Password"></asp:TextBox>
                 </td></tr>
			 
			 <tr><td>
			    <asp:CheckBox ID="_chkRememberMe" runat="server" Text="Remember Me" 
                     Font-Size="8pt" />
			 </td></tr>
			 
			 <tr><td class="tdStyle">
                 <asp:ImageButton ID="_ImgbtnLogin" runat="server" ImageUrl="~/Images/Buttons/Login.jpg" 
                     style="margin-top: 3px" onclick="_ImgbtnLogin_Click"/>
                 
                 </td></tr>
			 
			 <tr><td class="css2"><a href="javascript:PopupCenter('PasswordNew.aspx','myPop1',500,300);">Forgot Password?</a></td></tr>
			 
			 <tr><td>&nbsp;</td></tr>
			 
			 <tr><td class="copyright">© SymBios Creations Pvt. Ltd. 2001-2010. <br />
                    All rights are reserved 

                </td></tr>
			 
			</table>
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="_tbEmployeeID"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="_tbPasswrd"></asp:RequiredFieldValidator>
	    </td>
	</tr>
	<tr>
		<td>
			<img src="Images/Pictures/LoginImg_07.jpg" width="213px" height="16px" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="Images/Pictures/LoginImg_08.jpg" width="213px" height="64px" alt=""></td>
	</tr>
	<tr>
		<td width="213px" height="22px" style="background-image: url('Images/Pictures/LoginImg_09.jpg'); background-repeat: no-repeat; background-position: left top;">
			<div style="color:#ffffff; font:6pt arial; width:46px; margin-left: 163px; margin-bottom: 0px; margin-top: 7px; height: 10px;">Version 2.1.0</div></td>
	</tr>
	<tr>
		<td colspan="3">
			<img src="Images/Pictures/LoginImg_10.jpg" width="582px" height="30px" alt=""></td>
	</tr>
</table>
</td></tr>  
</table>
    
    
    </form>
</body>
</html>

