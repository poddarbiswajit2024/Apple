<%@ Page Language="C#" AutoEventWireup="true" Title="POP Power Status :: SymBios Broadband " CodeBehind="Default.aspx.cs" Inherits="Apple_Bss.PopPowerStatus.Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

	<style type="text/css">

    
  
        #sidebar ul { background: #eee; padding: 20px;  }
        li { margin: 10px 10px 10px 10px; list-style-type: none; }       
        #sidebar { width: 190px; float: left; }


a:link {
    color: #337ac6; text-decoration: none;
}
a:visited {   
    color: #337ac6;
}
a:hover {
    color:#337ac6; text-decoration: underline;
}
a:active {
    color: red;
}
    </style>
	
    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js?ver=1.3.2'></script>
    <script type="text/javascript">
        $(function () {
            var offset = $("#sidebar").offset();
            var topPadding = 15;
            $(window).scroll(function () {
                if ($(window).scrollTop() > offset.top) {
                    $("#sidebar").stop().animate({
                        marginTop: $(window).scrollTop() - offset.top + topPadding
                    });
                } else {
                    $("#sidebar").stop().animate({
                        marginTop: 0
                    });
                };
            });
        });
    </script>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
 
    <style type="text/css">
 
        
        body
        {
              font-family: 'Lato', sans-serif;
        }
.gridStyle
{
    font-family: 'Lato', sans-serif;
	 background-color:#ffffff; font: 14px;color:#666666; border:solid 0px #fbeed2; text-transform:uppercase; font-weight:bold;
}

 .gridHeader{ 
     font-family: 'Lato', sans-serif;
     background:#0b6599; background-repeat:repeat-x; 
              background-position:left top; height:30px; padding-left:5px; font:bold 14px;
			  color:#ffffff; border-top: solid 0px #e49e09;text-transform:uppercase;font-weight:bold;
             
        }   


.gridLeftPad
{
	padding-left:10px; font-size: 14px;
}
.gridRowStyle
{
	 border-top:solid 4px #f7f7f7;border-bottom:solid 4px #f7f7f7; height:33px;font-size: 14px; 
}
	
.gridAltRow
{
	border-top:solid 0px #e5e5e5;border-bottom:solid 0px #e5e5e5; background-color:#f8f8f8;height:33px;font-size: 14px;
}

.gridPagerStyle
{
	padding:5px; text-align: left;
}

.gridPagerStyle td
{
	padding-left: 4px;padding-right: 4px;
}
.textblink
{
     text-decoration: blink;
}


    </style>

     <meta http-equiv="refresh" content="60"/>
</head>
<body>
    <form id="form1" runat="server">
        	<div id="sidebar">
				
		  	<ul >
			    <li>                <asp:HyperLink ID="hlAll" NavigateUrl="Default.aspx?location=ALL" runat="server">All Locations</asp:HyperLink>
			    </li>
		<li>
    <asp:HyperLink ID="hlDimpaur" NavigateUrl="Default.aspx?location=DIMAPUR" runat="server">Dimapur</asp:HyperLink>
			    </li>
			    <li>
                        <asp:HyperLink ID="hlKohima" NavigateUrl="Default.aspx?location=KOHIMA" runat="server">Kohima</asp:HyperLink>
			    </li>
                    <li>
                            <asp:HyperLink ID="hlMokokchung" NavigateUrl="Default.aspx?location=MOKOKCHUNG" runat="server">Mokokchung</asp:HyperLink>
                    </li>
			</ul>
		
		</div>

		<div>
                    <asp:GridView ID="gvPopList" runat="server" AutoGenerateColumns="False"
            PageSize="5" Width="66%" HorizontalAlign="Center" BorderWidth="0"
                                        GridLines="None" CssClass="gridStyle" 
                        onrowdatabound="GridView1_RowDataBound" 
                        EmptyDataText="No POP to show for selected location!">
                                        <Columns>

                                        <asp:TemplateField HeaderText="Sl.">
                                <HeaderStyle CssClass="gridLeftPad"  HorizontalAlign="Center" />
                                <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Center" Width="10%" />
                           <ItemTemplate>
                            <asp:Label ID="lblSerial" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                           </ItemTemplate></asp:TemplateField> 


                                                <asp:TemplateField HeaderText="POP Name">
                                                <ItemTemplate>
                                                    <a href='PopStatusDetails.aspx?pop=<%#Eval("POPID") %>' title='Grid IP: <%#Eval("GRIDIP") %> Backup IP: <%#Eval("BackupIP") %>' target="_blank">

                                                       <%#Eval("POPNAME") %> 
                                                    </a>

                                  </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="40%" CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                  
                                       <asp:TemplateField HeaderText="STATUS">
                                                <ItemTemplate>
                                                       <asp:Image ID="imgCurrentAvailable" ImageUrl="~/PopPowerStatus/icons/current_available.png" AlternateText="current availability" ToolTip='<%# "Grid Availability. Grid IP: " + Eval("GRIDIP") %>' Width="33px" runat="server" />

                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Image ID="imgBatteryAvailble" ImageUrl="~/PopPowerStatus/icons/battery_available.png" AlternateText="Backup availability" ToolTip=' <%# "Backup Availability  Backup IP:" + Eval("BackupIP") %>' Width="33px" runat="server" />  

&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblPopStatus"  runat="server" BackColor="Green" ForeColor="White" Height="18px" Text="RUNNING"></asp:Label>
                                                     <asp:Image ID="imgPopStatus" ImageUrl="~/PopPowerStatus/icons/downanimated.png" AlternateText="pop down" ToolTip="pop down" Visible="false" width="62px" runat="server" />
                                            
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50%" CssClass="gridRowStyle" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                                   <EmptyDataRowStyle Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" ForeColor="#006600" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                       
                                    </asp:GridView>
                     
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </div>
        

    </form>

</body>
</html>

