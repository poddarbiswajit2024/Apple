<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Apple_Bss.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
			    <img alt="" src="Images/Logo/logo-a.bmp" style="height: 77px; width: 140px" /></td>
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
					You are here because an error has occurred in the application. This might have happened due to any of the following reasons:
					</span>

                <ul style="color: #FF0000">
                <li style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">The URL has been tampered with in the address bar</li>
                <li style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">The Requested page does not exist any more</li>
                <li style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">The data server could not be contacted</li>
                <li style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">The web server is not responding</li>
                                                    <li style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">You have hit 
                                                        the back button of the browser</li>
                </ul>

					<span style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt">We request you to try after sometime. The web administrator has been notified of the error. If the you face the same error again kindly bring the same to out notice at 
					<a href="mailto:info@symbios.in">info@symbios.in </a>
					<br />
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
