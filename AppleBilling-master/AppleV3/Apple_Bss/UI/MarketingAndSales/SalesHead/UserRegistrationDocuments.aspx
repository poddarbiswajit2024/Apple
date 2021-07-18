<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesHead.Master"
    AutoEventWireup="true" CodeBehind="UserRegistrationDocuments.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.UserRegistrationDocuments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Broadband Subscriber Registration
                Upload Documents</td>
        </tr>
        <tr>
            <td class="mainTD">
                <div class="tdSubtitle">Upload Documents</div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
             
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Customer Name</td>
                        <td class="tdStyle">
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            &nbsp;</td>
                    </tr>
                      <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload User Photo<font color="red">*</font>
                                            </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadUserPhoto" runat="server" FileTypeRange="jpg,gif,png" />
                        </td>
                    </tr>
                      <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            ID Proof Type</td>
                        <td class="tdStyle">
                   
                            <asp:Label ID="lblIDProofDocumentType" runat="server"></asp:Label>
                   
                        </td>
                    </tr>
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload ID Proof Document<font color="red">*</font></td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadIDProof" runat="server" FileTypeRange="pdf,jpg,png,gif"  />
                        </td>
                    </tr>
               
                    
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
               
                    
                    <tr>
                      
                        
                                 
                                            <td class="tdStyle" style="width: 24%" valign="top">
                                                Installation Address Proof Type
                                            </td>
                                            <td class="tdStyle">


                                                <asp:Label ID="lblAddressProofDocumentType" runat="server"></asp:Label>


                                             </td>
                                   
                
                  
                    </tr>
                    <tr id="address" runat="server">
                        <td class="tdStyle" style="width: 24%">
                            Upload Address Proof Document<font color="red">*</font>
                                            </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadAddressProof" runat="server" FileTypeRange="pdf,jpg,png,gif"
                                Required="False" />
                        </td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            CAF Number</td>
                        <td class="tdStyle">                           
                            <asp:TextBox ID="tbCAFNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>    

                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Annexure Document</td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadCAFAnnexureDoc" runat="server" FileTypeRange="pdf" />
                        </td>
                    </tr>  
                    <tr>
                        <td colspan="2" class="tdgap">
                        </td>
                    </tr>

                     <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload Signature<font color="red">*</font></td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadSignature" runat="server" FileTypeRange="pdf,jpg,png,gif" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" class="tdgap">
                        </td>
                    </tr>

                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnRegister" runat="server" OnClick="_btnRegister_Click" ImageUrl="~/Images/Buttons/update.jpg"
                               OnClientClick="javascript:window.scrollTo(0, 0);" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" colspan="2">
                                  
                                      <b> Instructions:</b><br />
                                       * Image format accepted for user&nbsp; photo are png, jpg or gif.<br /> * Maximum allowed file size of each file is 600KB.
                                       <br />
                                       *All other documents accepted format is pdf.<br /> *Al documents except Annexure document are mandatory<br />

                               
                                </td>
                        </tr>
                         
                    <tr>
                        <td class="tdgap" style="width: 24%">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
  
     
        
        <tr><td class="tdgap"></td></tr>
    </table>
</asp:Content>
