<%@ Page Title="Connection Reports" Language="C#" MasterPageFile="~/UI/Management/Management.Master" AutoEventWireup="true" CodeBehind="ConnectionReports.aspx.cs" Inherits="Apple_Bss.UI.Management.ConnectionReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
                  <tr>
                        <td valign="top" class="tdtitle">
                            Connection Reports
                        </td>
                    </tr>                  
                    <tr>
                    <td class="mainTD" style="padding-left:10px">
                     <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center" style="padding-left:10px">
                    <tr>
                    
                    <td class="gridHeader" width="20%" height="35px">
                    
                        Type of Subscribers</td>
                     
                         <td class="gridHeader" width="28%" height="35px" style=" text-align:center"> 
                         &nbsp;&nbsp;Number of Users</td>
                         
                         <td class="tdStyle">&nbsp;</td>
                    </tr>
                    <tr>
                    <td class="tdStyle">
                   <span style="color:green; font-weight:bold">Active Users</span></td>
                       <td class="tdStyle" valign="top" style="text-align:center">
                                         <asp:Label ID="lbConnectedUsers" runat="server"></asp:Label>
                                     </td>
                    </tr>
                    
                    <tr><td class="tdStyle" style="height: 28px">
                   <span style="color:Maroon; font-weight:bold">Temporarily Disconnected Users</span>
                    </td>
                    <td class="tdStyle" style="text-align:center; height: 28px;">
                                         <asp:Label ID="lblTempDisconnct" runat="server"></asp:Label>
                    
                    </td></tr>
                    
                    <tr><td class="tdStyle">
                   <span style="color:Red; font-weight:bold"> De Activated / Cancelled Users</span>
                    </td>
                    <td class="tdStyle" style="text-align:center">
                                         <asp:Label ID="lblDisconnected" runat="server"></asp:Label>
                    
                    </td></tr>
                    
                        <tr><td class="tdStyle">
                    Total
                    </td>
                    <td class="tdStyle" style="text-align:center">
                                         <asp:Label ID="lblTotalUsrs" runat="server"></asp:Label>                    
                    </td></tr> 
                    </table>
                    </td>
                    </tr>
                     <tr><td class="tdgap">
                &nbsp; 
                </td></tr>
                    <tr>
                   
                    <td class="tdtitle">
                   
                     Monthly Summary Report</td></tr>
                    
                    <tr>
                    <td class="mainTD">
                                        
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                     <table class="tableStyle" border="0" cellpadding="0" cellspacing="0" align="center">
   
                       
                     <tr><td  colspan="2" class="tdgap">
                &nbsp; 
                </td></tr>
                <tr>
                 <td class="tdStyle" width="30%" style=" vertical-align:top;" valign="top">                                      
                                   
                       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                           GridLines="Horizontal" Width="100%" 
                             AllowPaging="True" PageSize="6" 
                             onpageindexchanging="GridView2_PageIndexChanging" 
                                          BorderWidth="0px">
                                            
                                          
                                            <RowStyle BorderColor="#F2F2F2" BorderWidth="4px" Height="50px" />
                                          
                                            <Columns>
                                                <asp:BoundField DataField="MONTH" HeaderText="Month Year">
                                                    <HeaderStyle Width="25%"  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                                </asp:BoundField> 
                                                                                               
                                                  <asp:BoundField DataField="allusers" HeaderText="Total Subscribers">
                                                    <HeaderStyle Width="20%"  CssClass="gridLeftPad" HorizontalAlign="Center"/>
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Center"/>
                                                </asp:BoundField>  
                                                
                                                
                                                
                                               
                                                
                                            
                                            </Columns>
                                            
                                             
                                            <PagerStyle CssClass="gridPagerStyletd" Height="30px" Wrap="True" BorderWidth="0px" />
                                            
                                            <HeaderStyle CssClass="gridHeader" />
                                           
                            </asp:GridView>                   
                                        
                 
                                       
                 </td>
                     <td  width="70%" style=" vertical-align:top;" valign="top">
                  
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                             GridLines="Horizontal" Width="27%" 
                                            AllowPaging="True" PageSize="6" 
                             BorderWidth="0px">
                                            <PagerSettings Visible="False" />
                                           
                                            <RowStyle BorderColor="#F2F2F2" BorderWidth="4px" Height="50px" />
                                           
                                            <Columns>
                                                    <asp:BoundField DataField="newusers" HeaderText="New Subscribers">
                                                    <HeaderStyle Width="20%"  CssClass="gridLeftPad" HorizontalAlign="Center"/>
                                                    <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Center"/>
                                                </asp:BoundField>  
                                                
                                            </Columns> 
                                            <HeaderStyle CssClass="gridHeader" />
                                            
                                        </asp:GridView>
                 </td>
                </tr>
                
                    </table>
                    </ContentTemplate>
                         </asp:UpdatePanel>
                    </td></tr>
                
                
                    </table>
                   
</asp:Content>
