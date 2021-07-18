<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DOB.ascx.cs" Inherits="Apple_Bss.UI.SystemManagement.DOB" %>

<link rel="Stylesheet" href="../../CSS/InetBill.css" type="text/css" />
 <table><tr>
 <td style="text-align: left;" > 

     <asp:DropDownList ID="_ddlDay" runat="server" 
         style="font-family: Arial; font-size: small" CssClass="TextBoxBorder" 
         Width="50px" Height="22px">
                                              <asp:ListItem Selected="True" Value="">Day</asp:ListItem>
                                              <asp:ListItem Value="01">1</asp:ListItem>
                                              <asp:ListItem Value="02">2</asp:ListItem>
                                              <asp:ListItem Value="03">3</asp:ListItem>
                                              <asp:ListItem Value="04">4</asp:ListItem>
                                              <asp:ListItem Value="05">5</asp:ListItem>
                                              <asp:ListItem Value="06">6</asp:ListItem>
                                              <asp:ListItem Value="07">7</asp:ListItem>
                                              <asp:ListItem Value="08">8</asp:ListItem>
                                              <asp:ListItem Value="09">9</asp:ListItem>
                                              <asp:ListItem Value="10">10</asp:ListItem>
                                              <asp:ListItem Value="11">11</asp:ListItem>
                                              <asp:ListItem Value="12">12</asp:ListItem>
                                              <asp:ListItem Value="13">13</asp:ListItem>
                                              <asp:ListItem Value="14">14</asp:ListItem>
                                              <asp:ListItem Value="15">15</asp:ListItem>
                                              <asp:ListItem Value="16">16</asp:ListItem>
                                              <asp:ListItem Value="17">17</asp:ListItem>
                                              <asp:ListItem Value="18">18</asp:ListItem>
                                              <asp:ListItem Value="19">19</asp:ListItem>
                                              <asp:ListItem Value="20">20</asp:ListItem>
                                              <asp:ListItem Value="21">21</asp:ListItem>
                                              <asp:ListItem Value="22">22</asp:ListItem>
                                              <asp:ListItem Value="23">23</asp:ListItem>
                                              <asp:ListItem Value="24">24</asp:ListItem>
                                              <asp:ListItem Value="25">25</asp:ListItem>
                                              <asp:ListItem Value="26">26</asp:ListItem>
                                              <asp:ListItem Value="27">27</asp:ListItem>
                                              <asp:ListItem Value="28">28</asp:ListItem>
                                              <asp:ListItem Value="29">29</asp:ListItem>
                                              <asp:ListItem Value="30">30</asp:ListItem>
                                              <asp:ListItem Value="31">31</asp:ListItem>
                                          </asp:DropDownList>
                                                                          
                                          <asp:DropDownList ID="_ddlMonth" runat="server" 
                                              
         style="font-family: Arial; font-size: small" CssClass="TextBoxBorder" 
          Height="22px">
                                              <asp:ListItem Selected="True" Value="">Month</asp:ListItem>
                                              <asp:ListItem Value="01">January</asp:ListItem>
                                              <asp:ListItem Value="02">February</asp:ListItem>
                                              <asp:ListItem Value="03">March</asp:ListItem>
                                              <asp:ListItem Value="04">April</asp:ListItem>
                                              <asp:ListItem Value="05">May</asp:ListItem>
                                              <asp:ListItem Value="06">June</asp:ListItem>
                                              <asp:ListItem Value="07">July</asp:ListItem>
                                              <asp:ListItem Value="08">August</asp:ListItem>
                                              <asp:ListItem Value="09">September</asp:ListItem>
                                              <asp:ListItem Value="10">October</asp:ListItem>
                                              <asp:ListItem Value="11">November</asp:ListItem>
                                              <asp:ListItem Value="12">December</asp:ListItem>
                                          </asp:DropDownList>
                                                                    
                                          <asp:DropDownList ID="_ddlYear" runat="server" 
                                              
         style="font-family: Arial; font-size: small" CssClass="TextBoxBorder" 
         Width="60px" Height="22px">
                                          <asp:ListItem Selected="True" Value="">Year</asp:ListItem>
                                          </asp:DropDownList>
                                                                                                 
                                          &nbsp;<asp:Label ID="Label1" 
         runat="server" ForeColor="#FF3300" Font-Names="Arial" Font-Size="9pt" ></asp:Label> </td></tr>
                                    </table>