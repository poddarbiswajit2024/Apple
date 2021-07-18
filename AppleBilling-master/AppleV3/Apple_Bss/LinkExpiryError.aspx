<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkExpiryError.aspx.cs" Inherits="Apple_Bss.LinkExpiryError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Error Page</title>
    <style type="text/css">
        .style1
        {
            color: #FF3300;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%; background-color: #FFFFFF" cellpadding="2" align="center">
		<tr>
			<td style="background:white; height:70px; padding-left:10px; border-bottom: 1px solid silver"  >
			    <img alt="" src="Images/Logo/logo-a.bmp" style="width: 140px" /></td>
		</tr>
		
		<tr>
			<td >
			</td>
	    </tr>
			
				<tr>
					<td style="font-family:Arial; font-size: 14pt; padding-left:5%" valign="top" 
                        class="style1">
					<strong>Error</strong></td>
				</tr>
				<tr>
					<td >&nbsp;</td>
				</tr>
				<tr>
					<td style="text-align: left; padding-left:5%" valign="top">
					
					<span style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">
					<strong>Dear User,</strong> <br />
					<br />
					    You are here because the link has expired. Kindly try again.<br />
                        <br />
					</span>
					
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="padding-left:5%">
					<asp:TextBox runat="server" id="_tbErrorStackTrace" Rows="30" TextMode="MultiLine" 
                            Width="980px" Visible="false"></asp:TextBox>
					&nbsp;</td>
				</tr>
				
			
		<tr>
			<td>
			

			</td>
		</tr>
	</table>
    </form>
</body>
</html>
