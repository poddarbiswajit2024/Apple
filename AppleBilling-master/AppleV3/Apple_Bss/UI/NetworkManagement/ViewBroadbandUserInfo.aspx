<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBroadbandUserInfo.aspx.cs"
    Inherits="Apple_Bss.UI.NetworkManagement.ViewBroadbandUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BroadBand User Info</title>
    <link rel="stylesheet" href="../../CSS/InetBill.css" media="screen" type="text/css" />
    <style type="text/css">
        #imgPhoto {
            height: 70px;
            width: 118px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">
                Broadband Subscriber Information Details
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                    
                    <tr>
                        <td class="tdStyle" width="70%">
                            <asp:DetailsView ID="_dvBroadbandInfoDetails" runat="server" AutoGenerateRows="False"
                                GridLines="None" Width="100%">
                                
                                <RowStyle Height="30px" />
                                <Fields>
                               
                                    <asp:BoundField HeaderText="Name" DataField="NAME"/>
                                    <asp:BoundField HeaderText="Username" DataField="USERNAME" />
                                    <asp:BoundField HeaderText="Status" DataField="STATUS" />
                                    <asp:BoundField HeaderText="Rental Paymode" DataField="RENTALPAYMODE" />
                                    <asp:TemplateField HeaderText="Installation Address">
                                        <ItemTemplate>
                                            <%#Server.HtmlDecode(Eval("INSADR").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Correspondence Address">
                                        <ItemTemplate>
                                            <%#Server.HtmlDecode(Eval("CORADR").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Registration Date" DataField="REGISTRATIONDATE" DataFormatString="{0:dd/MMM/yyy}" />
                                    <asp:BoundField HeaderText="Mobile Number" DataField="MOBILENUMBER" />
                                    <asp:BoundField HeaderText="Alternate Mobile Number" DataField="ALTMOBILENUMBER" />
                                    <asp:BoundField HeaderText="Landline Number" DataField="LANDLINENUMBER" />
                                    <asp:BoundField HeaderText="Email ID" DataField="EMAILID" />
                                    <asp:BoundField HeaderText="Bill Plan" DataField="BILLPLAN" />
                                    
                                </Fields>
                            </asp:DetailsView>
                        </td>
                        
                        <td width="30%" valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <!--Right table -->
                                <tr>
                                    <td class="tdStyle" colspan="2">
                                        <b>Uploaded Files</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" width="30%">
                                        Photo
                                    </td>
                                    <td class="tdStyle" >
                                        <img id="imgPhoto" Height="70px" alt='<%=photo%>' src="../../UploadedFiles/Subscribers/<%=photo%>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle" width="30%">
                                        &nbsp;
                                    </td>
                                    <td class="tdStyle">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        ID Proof
                                    </td>
                                    <td class="tdStyle">
       <%--      <img id="imgIdProof" alt='<%=idproof %>' src='../../UploadedFiles/IDProof/<%=idproof %>' />--%>
           
                       <asp:HyperLink ID="hlnkIDProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        &nbsp;
                                    </td>
                                    <td class="tdStyle">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdStyle">
                                        Address Proof
                                    </td>
                                    <td class="tdStyle">
                                        <%--<img id="imgAddressProof" alt='<%=addrressproof%>' src='../../UploadedFiles/AddressProof/<%=addrressproof %>' />--%>
                                         <asp:HyperLink ID="hlnkAddressProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="tdStyle">
                                        &nbsp;
                                    </td>
                                    <td class="tdStyle">
                                        &nbsp;
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="tdStyle">
                                        CAF Document
                                    </td>
                                    <td class="tdStyle">
                                       
                                         <asp:HyperLink ID="hlnkCAFDocument" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
