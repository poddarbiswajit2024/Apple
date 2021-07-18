<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisteredUserInfoDetails.aspx.cs"
    Inherits="Apple_Bss.UI.NetworkManagement.RegisteredUserInfoDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registered User Details</title>
    <link rel="stylesheet" href="../../CSS/InetBill.css" media="screen" type="text/css" />
</head>
<body>
    
    <form id="form1" runat="server">
    <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">
                Registered User Details
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table cellpadding="0" cellspacing="0" border="0" class="tableStyle">
                    
                    <tr>
                        <td width="70%" valign="top">
                             
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <!-- Left Table -->
                                
                                <tr>
                                    <td class="tdStyle">
                                        <asp:DetailsView ID="_dvRegDetails" runat="server" AutoGenerateRows="False" Width="100%"
                                            GridLines="None">
                                            <RowStyle Height="22px" />
                                            <FieldHeaderStyle Font-Bold="True" />
                                            <Fields>
                                                <asp:BoundField HeaderText="Customer Name" DataField="NAME">
                                                    <HeaderStyle Width="30%" Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Installation Address" DataField="INSADR">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Correspondence Address" DataField="CORADR">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Registration Date" DataField="REGISTRATIONDATE" DataFormatString="{0:dd-MMM-yyyy}">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Mobile Number" DataField="MOBILENUMBER">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Landline Number" DataField="LANDLINENUMBER">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Email ID" DataField="EMAILID">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Bill Plan" DataField="BILLPLAN">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Rental Payment Mode" DataField="RENTALPAYMODE">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                              <%--  <asp:BoundField HeaderText="Address Proof" DataField="ADDRESSPROOFNAME">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField HeaderText="Identification Proof" DataField="IDPROOFTYPE">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Registered By" DataField="EMPID">
                                                    <HeaderStyle Height="30px" />
                                                </asp:BoundField>
                                            </Fields>
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:DetailsView>
                                    </td>
                                </tr>
                            </table>
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
                                    <td class="tdStyle">
                                        <img id="imgPhoto" runat="server" alt='<%=photo%>' src="../../UploadedFiles/Subscribers/<%=photo%>" />
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
                                        <%--<img id="imgIdProof" alt='<%=idproof %>' src='../../UploadedImages/IDproof/<%=idproof %>' />--%>
                                       <a href="../../UploadedFiles/IDproof/<%=idproof %>" id="Customer_idProof_Front" runat="server"><%=idproof %></a>
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
                                        <%--<img id="imgAddressProof" alt='<%=addrressproof%>' src='../../UploadedImages/Addressproof/<%=addrressproof %>' />--%>
                                        <a href="../../UploadedFiles/AddressProof/<%=addrressproof %>" id="Customer_addProof_Front" runat="server"><%=addrressproof %></a>
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
