<%@ Page Title="Update Subscriber Files" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master" AutoEventWireup="true" CodeBehind="UploadSubscriberFiles.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.UploadSubscriberFiles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../../UserControl/UploadPhoto.ascx" tagname="UploadPhoto" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 1st Main Table-->
    <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>--%>
 <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                
 <tr >
   <!--1st main td -->
 <td class="tdStyle" style="width: 60%">
 <!-- table 1 under 1st main td -->
 <table style="width:100%" class="tableStyle" cellpadding="0" cellspacing="0"  align="center"> 
 
 <tr >
 <td class="tdtitle" colspan="3">
 Search Subscriber
 </td>
 </tr> 
 <tr>
 <td class="tdStyle" width="32%">
     User ID
 </td>
 <td class="tdStyle" width="30%">
 
         <asp:Label ID="_lblBc" runat="server"></asp:Label>-SCLX <asp:TextBox ID="_tbUserID" runat="server" CssClass="TextBoxBorder" MaxLength="4" Width="90px"></asp:TextBox>         
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="_tbUserID" ErrorMessage="*">*</asp:RequiredFieldValidator>
                
     </td>     
     <td class="tdStyle" width="38%">                         
        <asp:ImageButton ID="_ibtnGet" runat="server" ImageUrl="~/Images/Buttons/View.jpg" 
        onclick="_ibtnGetPhoto_Click" />
     </td>
 </tr>

 
 <tr>
 <td class="tdStyle" width="32%">
     &nbsp;</td>
 <td class="tdStyle" width="30%">
 
     &nbsp;</td>     
     <td class="tdStyle" width="38%">                         
         &nbsp;</td>
 </tr>

 
 </table>

 
 </td> 

     
        
 <td class="tdView" width="40%">
  
            
 <div align="left" style="float:left;">
 <asp:Image ID="_imgUser" Visible="false" Height="70px" runat="server" />                
 </div>    
  <div style="float:left; padding-left:10px">
   <asp:Literal ID="_ltrlSubscriberDetails" runat="server"></asp:Literal> 
     <br />  Name   : <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
 </div>   
       </td>            
 </tr>  


 <tr><td class="tdgap">&nbsp;</td>
     </tr>

 </table>

             <asp:Panel ID="panelUpdateDocuments" Visible="false" runat="server">
              
                <table  class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    
             
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                        </td>
                    </tr>

                 
                  
                      <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload User Photo<font color="red">*</font>
                                            </td>
                        <td class="tdStyle">
                          <%--  <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" ForeColor="#0066FF" OnUploadedComplete="AsyncFileUpload1_doUpload"
                                Width="287px" />--%>
                            <uc1:UploadPhoto ID="UploadUserPhoto" runat="server" FileTypeRange="jpg,gif,png" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">&nbsp;</td>
                        <td class="tdStyle">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            ID Proof</td>
                        <td class="tdStyle">
                   
                            <asp:Label ID="lblIDProofDocumentType" runat="server"></asp:Label>
                   
                            &nbsp;<br /> <asp:HyperLink ID="hlnkIDProof" runat="server" ForeColor="Blue" Target="_blank"></asp:HyperLink>
                   
                            <asp:Label ID="IDLabel" runat="server" ForeColor="#FF9900" Text="Checking..."></asp:Label>
                   
                        </td>
                    </tr>
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload ID Proof Document<font color="red">*</font></td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadIDProof" runat="server" FileTypeRange="pdf"  />
                        </td>
                    </tr>
               
                    
                    <tr>
                        <td class="tdStyle" style="width: 24%">&nbsp;</td>
                        <td class="tdStyle">&nbsp;</td>
                    </tr>
               
                    
                    <tr>
                      
                        
                                 
                                            <td class="tdStyle" style="width: 24%" valign="top">
                                                Installation Address Proof<font color="red">*</font>
                                            </td>
                                            <td class="tdStyle">


                                                <asp:Label ID="lblAddressProofDocumentType" runat="server"></asp:Label>


                                                &nbsp;<br /> <asp:HyperLink ID="hlnkAddressProof" runat="server" ForeColor="Blue" Target="_blank"></asp:HyperLink>


                                                <asp:Label ID="ADDLabel" runat="server" ForeColor="#FF9900" Text="Checking..."></asp:Label>


                                             </td>
                                   
                
                  
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload Address Proof Document<font color="red">*</font>
                                            </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadAddressProof" runat="server" FileTypeRange="pdf"
                                Required="False" />
                        </td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">&nbsp;</td>
                        <td class="tdStyle">&nbsp;</td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            CAF Number</td>
                        <td class="tdStyle">                           
                            <asp:TextBox ID="tbCAFNumber" CssClass="TextBoxBorder" runat="server"></asp:TextBox>
                            <br />
                            <asp:HyperLink ID="hlnkCAFDocument" runat="server" ForeColor="Blue" Target="_blank"></asp:HyperLink>
                            <asp:Label ID="CAFLabel" runat="server" ForeColor="#FF9900" Text="Checking..."></asp:Label>
                        </td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload CAF Document<font color="red">*</font></td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadCAFDoc" runat="server" FileTypeRange="pdf" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">Annexure Document</td>
                        <td class="tdStyle">
                            <asp:HyperLink ID="hlnkAnnexureDocument" runat="server" ForeColor="Blue" Target="_blank"></asp:HyperLink>
                            <asp:Label ID="ANNXLabel" runat="server" ForeColor="#FF9900" Text="Checking..."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
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
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnRegister" runat="server" ImageUrl="~/Images/Buttons/update.jpg" OnClick="_btnRegister_Click" OnClientClick="javascript:window.scrollTo(0, 0);" />
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
                 </asp:Panel>
    <%--   </ContentTemplate>
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="_ibtnGet" />  
             <asp:PostBackTrigger ControlID="_btnRegister" />           
         </Triggers>
    </asp:UpdatePanel> --%>   
    
    <script>

        setTimeout(checkForFile("ctl00_ContentPlaceHolder1_hlnkIDProof", "ctl00_ContentPlaceHolder1_IDLabel"), 2000);
        setTimeout(checkForFile("ctl00_ContentPlaceHolder1_hlnkAddressProof", "ctl00_ContentPlaceHolder1_ADDLabel"), 2000);
        setTimeout(checkForFile("ctl00_ContentPlaceHolder1_hlnkCAFDocument", "ctl00_ContentPlaceHolder1_CAFLabel"), 2000);
        setTimeout(checkForFile("ctl00_ContentPlaceHolder1_hlnkAnnexureDocument", "ctl00_ContentPlaceHolder1_ANNXLabel"), 2000);

        function checkForFile(LinkId, LabelId) {
            var dynamicIdForHref = LinkId;
            var dynamicIdForLabel = LabelId;

            var UrlToFile = document.getElementById(dynamicIdForHref).href;
            var result = doesFileExist(UrlToFile);
            if (result == true) {
                document.getElementById(dynamicIdForLabel).innerHTML = "Found.";
                document.getElementById(dynamicIdForLabel).style.color = "green";
            }
            else {
                document.getElementById(dynamicIdForLabel).innerHTML = "Not found.";
                document.getElementById(dynamicIdForLabel).style.color = "red";
            }
        }

        function doesFileExist(UrlToFile) {
            var xhr = new XMLHttpRequest();
            xhr.open('HEAD', UrlToFile, false);
            xhr.send();
            if (xhr.status == 200) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
          
</asp:Content>
