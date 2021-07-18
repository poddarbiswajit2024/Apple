<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SitePath.ascx.cs" Inherits="Apple_Bss.UserControl.sitepath" %>
<link href="../CSS/InetBill.css" rel="Stylesheet" type="text/css"/>    


        <table width="100%" cellpadding="0" cellspacing="0" border="0">
        
        <tr>
         <td>         
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
              style="font-size:8pt; font-family:Arial; line-height:20px; padding-left:4px;" ParentLevelsDisplayed="4" ShowToolTips="False"
            RootNodeStyle-Font-Italic="False" SkipLinkText="">
            <PathSeparatorStyle Font-Bold="false" ForeColor="#929292" />
            <CurrentNodeStyle Font-Bold="true" ForeColor="#ef9f05" />
            <NodeStyle Font-Bold="false" ForeColor="Gray" />

             <RootNodeTemplate>
                 Home
             </RootNodeTemplate>

            <RootNodeStyle Font-Bold="true" ForeColor="Gray"/>
        </asp:SiteMapPath>
         </td>
                       
         <td></td>
         </tr>
         
         </table>