<%@ Page Title="Update Subscriber Files" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master" AutoEventWireup="true" CodeBehind="UploadSubscriberFilesOnebyOne.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.CustomerCare.UploadSubscriberFilesOnebyOne" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../../UserControl/UploadPhoto.ascx" tagname="UploadPhoto" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 1st Main Table-->
    <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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


             <asp:Panel ID="panelUpdateSection" Visible="false" runat="server">
                <table class="tableStyle" cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                        </td>
                    </tr>
              
                    <tr>
                        <td class="tdStyle" style="width: 24%" >
                            
                           
                            &nbsp;</td>
                        <td class="tdStyle">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">Upload New User Photo</td>
                        <td class="tdStyle">&nbsp;<uc1:UploadPhoto ID="UploadPhoto" runat="server" FileTypeRange="gif,png,jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">&nbsp;</td>
                        <td class="tdStyle" valign="top" style="vertical-align:text-top">
                           
                            <asp:ImageButton ID="btnUpdateUserPhoto" runat="server"  ToolTip="Update user photo" AlternateText="Update User photo" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnUpdateUserPhoto_Click"
                              />
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
                        <td class="tdStyle" style="width: 20%">
                            New ID Proof Type</td>
                        <td class="tdStyle">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                    <asp:DropDownList ID="_ddlIDProof" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_ddlIDProof_SelectedIndexChanged"
                                        DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" Width="204px"
                                        Style="height: 22px" CssClass="TextBoxBorder" Height="22px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="_tbotherIDProof" runat="server" Visible="False" OnTextChanged="_tbotherIDProof_TextChanged"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_ddlIDProof" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            Uploaded ID Proof Document</td>
                        <td class="tdStyle">
                            
                            <asp:HyperLink ID="hlnkIDProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                            <asp:Label ID="IDLabel" runat="server" Text="Checking..." ForeColor="#FF9900"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload ID Proof Document</td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadIDProof" runat="server" FileTypeRange="pdf"  />
                        </td>
                    </tr>
                        <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="btnUpdateIDProof" runat="server" ToolTip="Update ID proof Details" AlternateText="Update User photo" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnUpdateIDProof_Click"
                              />
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
                                                Installation Address Proof&nbsp; Type</td>
                                            <td class="tdStyle">


                                                <asp:Label ID="lblAddressProofDocumentType" runat="server"></asp:Label>


                                             </td>
                                   
                
                  
                    </tr>
                       
                       
                        <tr>
                                                <td class="tdStyle" style="width: 20%" valign="top">
                                                    New Address Proof Type</td>
                                                <td class="tdStyle">
                                                       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                                    <asp:DropDownList ID="_ddlAddressProof" runat="server" AutoPostBack="True" DataSourceID="XmlDataSource2"
                                                        DataTextField="text" DataValueField="value" Width="204px" 
                                                        OnSelectedIndexChanged="_ddlAddressProof_SelectedIndexChanged" 
                                                        CssClass="TextBoxBorder" Height="22px">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="_tbOtherAddrsProof" runat="server" Visible="False" OnTextChanged="_tbOtherAddrsProof_TextChanged"></asp:TextBox>                                    </ContentTemplate>
                                <Triggers>
                                   
                                    <asp:AsyncPostBackTrigger ControlID="_ddlAddressProof" />
                                   
                                </Triggers>
                            </asp:UpdatePanel>
                                                </td>
                                            </tr>
                     
                       
                        <tr>
                                                <td class="tdStyle" style="width: 20%" valign="top">
                                                    Uploaded Address Proof</td>
                                                <td class="tdStyle">
                            
                            <asp:HyperLink ID="hlnkAddressProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                                    <asp:Label ID="ADDLabel" runat="server" Text="Checking..." ForeColor="#FF9900"></asp:Label>
                                                </td>
                                            </tr>
                     
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Upload Address Proof Document 
                                            </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadAddressProof" runat="server" FileTypeRange="pdf"
                                Required="False" />
                        </td>
                    </tr>
            

                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="btnAddressProof" runat="server" ToolTip="Update Adress Proof Details" AlternateText="Update Address Proof Details" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnAddressProof_Click"
                              />
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
                            <asp:TextBox ID="tbCAFNumber" ReadOnly="true" BorderColor="White" CssClass="TextBoxBorder" runat="server" Width="196px"></asp:TextBox>
                        </td>
                    </tr>
            

                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            Uploaded CAF Document</td>
                        <td class="tdStyle">
                            
                            <asp:HyperLink ID="hlnkCAFDocument" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                            <asp:Label ID="CAFLabel" runat="server" Text="Checking..." ForeColor="#FF9900"></asp:Label>
                        </td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            New CAF Document<font color="red" >*</font>
                                            </td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadCAFDoc" runat="server" FileTypeRange="pdf" />
                        </td>
                    </tr>
            
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="btnUpdateCAFDetails" runat="server" ToolTip="Update CAF Details" AlternateText="Update CAF Details" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnUpdateCAFDetails_Click"/>
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
                            Uploaded Annexure Document</td>
                        <td class="tdStyle">
                            
                            <asp:HyperLink ID="hlnkAnnexureDocument" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                            <asp:Label ID="ANNXLabel" runat="server" Text="Checking..." ForeColor="#FF9900"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            New
                            Annexure Document</td>
                        <td class="tdStyle">
                            <uc1:UploadPhoto ID="UploadCAFAnnexureDoc" runat="server" FileTypeRange="pdf" />
                        </td>
                    </tr>
                  
                
                    
                    <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="btnUpdateCAFDAnnexure" runat="server" ToolTip="Update CAF Annexure" AlternateText="Update CAF Annexure" ImageUrl="~/Images/Buttons/update.jpg" OnClick="btnUpdateCAFDAnnexure_Click"/>
                        </td>
                    </tr>
                  
                <tr>
                        <td class="tdStyle" colspan="2">
                                   <asp:Panel ID="panelInstructions" runat="server" ScrollBars="Auto" >
                                      <b> Instructions:</b><br />
                                       * Image format accepted for user&nbsp; photo are png, jpg or gif.<br /> * Maximum allowed file size of each file is 600KB.
                                       <br />
                                       *All other documents accepted format is pdf.<br /> *Select which document you want to update on click on the relevant update button.<br /> *Select new document proof type only if it is different. Else, you can upload only the documnt you wish to update.<br />

                                   </asp:Panel>
                        <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" 
    TargetControlID="panelInstructions"
    CollapsedSize="0"
    ExpandedSize="200"
    Collapsed="false"
    ExpandControlID="LinkButton1"
    CollapseControlID="LinkButton1"
    AutoCollapse="False"
    AutoExpand="False"
    ScrollContents="True"
    TextLabelID="Label1"
                         
    CollapsedText="Show Details..."
    ExpandedText="Hide Details" 
    ImageControlID="Image1"
    ExpandedImage="~/images/collapse.jpg"
    CollapsedImage="~/images/expand.jpg"
    ExpandDirection="Vertical" />        </td>
                        </tr>
                    
                    <tr>
                        <td colspan="2" class="tdgap">
                        </td>
                    </tr>
                         <tr>
                        <td class="tdStyle" style="width: 24%">
                            &nbsp;</td>
                        <td class="tdStyle">
                                <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/IDProof/ProofDocument"></asp:XmlDataSource>
                            <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
                                XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>
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
             <asp:PostBackTrigger ControlID="btnUpdateUserPhoto" />
             <asp:PostBackTrigger ControlID="btnUpdateIDProof" />
               <asp:PostBackTrigger ControlID="btnAddressProof" />
               <asp:PostBackTrigger ControlID="btnUpdateCAFDetails" />
               <asp:PostBackTrigger ControlID="btnUpdateCAFDAnnexure" />
             
                  
         </Triggers>
    </asp:UpdatePanel>      
       --%>

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
