﻿<%@ Page Language="C#" AutoEventWireup="true" Title="Kohima POP Power Status :: SymBios Broadband " CodeBehind="Default.aspx.cs" Inherits="Apple_Bss.PopPowerStatus.Kohima.Default" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 
    <style type="text/css">
 
.gridStyle
{
	 background-color:#ffffff; font: 16px arial;color:#666666; border:solid 0px #fbeed2; text-transform:uppercase; font-weight:bold;
}

 .gridHeader{ background:#0b6599; background-repeat:repeat-x; 
              background-position:left top; height:30px; padding-left:5px; font:bold 16px arial;
			  color:#ffffff; border-top: solid 0px #e49e09;text-transform:uppercase;font-weight:bold;
             
        }   

.gridLeftPad
{
	padding-left:10px; font-size: 16px;
}
.gridRowStyle
{
	 border-top:solid 4px #f7f7f7;border-bottom:solid 4px #f7f7f7; height:65px;font-size: 16px;
}
	
.gridAltRow
{
	border-top:solid 0px #e5e5e5;border-bottom:solid 0px #e5e5e5; background-color:#f8f8f8;height:65px;font-size: 16px;
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
    <div>
  
         
                    <asp:GridView ID="gvPopList" runat="server" AutoGenerateColumns="False"
                                       
                                       
            PageSize="5" Width="100%" BorderWidth="0"
                                        GridLines="None" CssClass="gridStyle" 
                        onrowdatabound="GridView1_RowDataBound" 
                        EmptyDataText="ALL POP RUNNING WITHOUT ANY PROBLEM">
                                        <Columns>

                                        <asp:TemplateField HeaderText="Sl.No">
                                <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Center" />
                                <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Center" Width="10%" />
                           <ItemTemplate>
                              <asp:Label ID="lblSerial" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                           </ItemTemplate></asp:TemplateField> 


                                            <asp:BoundField DataField="POPNAME" HeaderText="POP Name">
                                                <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                            </asp:BoundField> 

                                <asp:TemplateField HeaderText="">
                                 <ItemStyle Width="1%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                           <ItemTemplate>
                              <asp:Label ID="lblFailureTime" Visible="false" title="Grid Power Failure Time" runat="server" Text='<%# Eval("GRIDFAILUREDATETIME") %>'></asp:Label>
                           </ItemTemplate></asp:TemplateField> 

                                   <%--     <asp:TemplateField HeaderText="Battery Failure Time">--%>
                                                 <asp:TemplateField HeaderText="">
                                 <ItemStyle Width="1%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                           <ItemTemplate>
                              <asp:Label ID="lblRestoredTime" Visible="false" title="Battery Failure Time" runat="server" Text='<%# Eval("BatteryStopDateTime") %>'></asp:Label>
                           </ItemTemplate></asp:TemplateField> 


                             
                                           

                                                   <asp:TemplateField HeaderText="STATUS">
                                                <ItemTemplate>
                                                       <asp:Image ID="imgCurrentAvailable" ImageUrl="~/PopPowerStatus/icons/current_available.png" AlternateText="current availability" ToolTip="Current Availability" Width="48px" runat="server" />

                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Image ID="imgBatteryAvailble" ImageUrl="~/PopPowerStatus/icons/battery_available.png" AlternateText="battery availability" ToolTip="Battery Availability" Width="48px" runat="server" />  

&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblPopStatus"  runat="server" BackColor="Green" ForeColor="White" Text="WORKING"></asp:Label>
                                                     <asp:Image ID="imgPopStatus" ImageUrl="~/PopPowerStatus/icons/downanimated.png" AlternateText="pop down" ToolTip="pop down" Visible="false" width="70px" runat="server" />
                                            
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="40%" CssClass="gridRowStyle" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                          <EmptyDataRowStyle Font-Bold="True" Font-Size="X-Large" HorizontalAlign="Center" ForeColor="#006600" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                       
                                    </asp:GridView>
                     
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
   
    </div>
    </form>
</body>
</html>
