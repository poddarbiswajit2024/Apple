<%@ Page Title="" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/CustomerCare/CustomerCare.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="RegisteredUsersDocuments.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.RegisteredUsersDocuments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--script for checking files in server-->
         <script>
             setTimeout(ExistPdf, 2000);
             setTimeout(ExistIdProof, 2000);
             setTimeout(ExistAddProof, 2000);

             function ExistPdf()
             {

                 for (var i = 3; i <= 120; i++)
                 {
                     var dynamicIdForHref = "";
                     var dynamicIdForLabel = "";

                     if (i <= 9)
                     {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_anchorPdf";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_errorLabelPdf";
                     }
                     else {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_anchorPdf";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_errorLabelPdf";
                     }


                     var UrlToFile = document.getElementById(dynamicIdForHref).href;

                     var result = doesFileExist(UrlToFile);

                     if (result == true)
                     {
                         document.getElementById(dynamicIdForLabel).innerHTML = "Found.";
                         document.getElementById(dynamicIdForLabel).style.color = "green";
                     }
                     else
                     {
                         document.getElementById(dynamicIdForLabel).innerHTML = "Not found.";
                         document.getElementById(dynamicIdForLabel).style.color = "red";
                     }

                 }
             }

             function ExistIdProof() {

                 for (var i = 3; i <= 120; i++) {
                     var dynamicIdForHref = "";
                     var dynamicIdForLabel = "";

                     if (i <= 9) {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_anchorIdProof";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_errorLabelIdProof";
                     }
                     else {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_anchorIdProof";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_errorLabelIdProof";
                     }


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
             }

             function ExistAddProof() {

                 for (var i = 3; i <= 120; i++) {
                     var dynamicIdForHref = "";
                     var dynamicIdForLabel = "";

                     if (i <= 9) {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_anchorAddProof";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl0" + i + "_errorLabelAddProof";
                     }
                     else {
                         dynamicIdForHref = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_anchorAddProof";
                         dynamicIdForLabel = "ctl00_ContentPlaceHolder1__gvActiveBroadBandUsers_ctl" + i + "_errorLabelAddProof";
                     }


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
             }

             function doesFileExist(UrlToFile)
             {

                 var xhr = new XMLHttpRequest();
                 xhr.open('HEAD', UrlToFile, false);
                 xhr.send();

                 if (xhr.status == 200)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }


    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td class="tdtitle">
                        Broadband Users
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <table border="0" cellpadding="0" cellspacing="0" align="center" 
                            bgcolor="White" width="100%" style="height: 50px">
                            <tr>
                                <td width="50%">
                                    <asp:RadioButtonList ID="_rbtnListStatus" runat="server" 
                                        RepeatDirection="Horizontal" Width="100%">
                                        <asp:ListItem  Value="AL">All</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                        <asp:ListItem Value="D">De-Activated</asp:ListItem>
                                        <asp:ListItem Value="T">Temporaryly Disconnected</asp:ListItem>
                                        <asp:ListItem Value="P">Permanently Disconencted</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:ImageButton ID="_btnViewUsers" runat="server" OnClick="_btnViewUsers_Click" ImageUrl="~/Images/Buttons/View.jpg" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                <td class="tdgap">
                &nbsp;</td>
                </tr>
                
                
                <tr>
                    <td class="mainTD">
                           <table border="0" cellpadding="0" cellspacing="0" align="center" 
                            bgcolor="White" width="100%" style="height: 143px; width: 102%;">
                         
                            <tr>
                                <td class="tdStyle" width="15%">
                                    Search by Username<br /> Search by User ID</td>
                                <td class="tdStyle" width="25%">
                                  <asp:TextBox ID="_tbUserName" runat="server" 
                                        Font-Names="Arial" 
                                        Font-Size="9pt" CssClass="TextBoxBorder" Width="180px" ></asp:TextBox>
                                  
                                    <cc1:AutoCompleteExtender ID="_tbUserName_AutoCompleteExtender" runat="server" 
                                        CompletionInterval="500" DelimiterCharacters="" Enabled="True" 
                                        MinimumPrefixLength="2" ServiceMethod="GetSubscribers" 
                                        ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserName" 
                                        CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20">
                                    </cc1:AutoCompleteExtender>
                                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                        runat="server" ControlToValidate="_tbUserName"
                                        Display="Dynamic" ErrorMessage="Required Field. Cannot be left empty" Font-Names="Arial"
                                        Font-Size="9pt" ForeColor="#0066FF" ValidationGroup="search">*</asp:RequiredFieldValidator>
                                           <br />
                                    <asp:TextBox ID="_tbUserID" runat="server" CssClass="TextBoxBorder" Font-Names="Arial" Font-Size="9pt" Width="180px"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="_tbUserID_AutoCompleteExtender" runat="server" CompletionInterval="500" CompletionListCssClass="auto_completionListElement" CompletionListHighlightedItemCssClass="auto_highlightedListItem" CompletionListItemCssClass="auto_listItem" CompletionSetCount="20" DelimiterCharacters=""  Enabled="True" MinimumPrefixLength="3" ServiceMethod="GetSubscribersUserID" ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserID">
                                    </cc1:AutoCompleteExtender>

                                           </td>
                                             <td class="tdStyle">
                                    <asp:ImageButton ID="Button2" runat="server" 
                                        ImageUrl="~/Images/Buttons/search.jpg" OnClick="_btnSearch_Click" 
                                                     ValidationGroup="search" />
                                                 <br />
                                                 <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/Images/Buttons/search.jpg" OnClick="ImageButton1_Click" Width="71px" />
                                </td>
                            </tr>
                        
                            
                          
                        </table>
                    </td>
                </tr>
                <tr class="tdStyle">
                    <td class="tdStyle">
                        <asp:Label ID="_lblTotalUsers" runat="server"></asp:Label>&nbsp;
                        
                    </td>
                </tr>

                <tr>
                    <td class="mainTD" valign="top">
                        <asp:GridView ID="_gvActiveBroadBandUsers" runat="server" AutoGenerateColumns="False"
                            Width="100%" AllowPaging="True" GridLines="None" OnPageIndexChanging="_gvActiveBroadBandUsers_PageIndexChanging"
                            OnRowCreated="_gvActiveBroadBandUsers_RowCreated" 
                            EmptyDataText="Sorry!! No record exist for this selection." 
                            CssClass="gridStyle" DataKeyNames="USERID,USERNAME" EnableModelValidation="True" PageSize="100">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                                
                                       <asp:TemplateField HeaderText="User ID/ Username">
                                                <ItemTemplate>
                                                        <%#Eval("USERID").ToString() %><br />
                                                    <%#Eval("USERNAME").ToString() %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" CssClass="gridLeftPad" Width="10%" />
                                            </asp:TemplateField>







                                <%-- working on it  every column 15% --%>  <%--    --%>

                                 <asp:TemplateField HeaderText="CAFNUMBER">
                                                <ItemTemplate>
                                                        <%#  Eval("CAFNUMBER").ToString() %><br />
                                                    <br />
                                                    <a id="anchorPdf" href='<%# Apple_Bss.CodeFile.DBConn.GetApplicationPath() + Apple_Bss.CodeFile.DBConn.GetDocumentsPath()  + Eval("CAFDOCUMENTNAME").ToString() %>' style="width: 50px;" target="_blank" runat="server">  <%#Eval("CAFDOCUMENTNAME").ToString() %>  <%-- Document.pdf --%> </a>
                                                    <br />
                                                    <label id="errorLabelPdf" runat="server"> Error label </label> <%--new addition--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="18%" />
                                </asp:TemplateField>



                                <%-- working on it --%>



                                                     
                                           <asp:TemplateField HeaderText="PHOTOFILENAME">
                                                <ItemTemplate>             
                                                    <img src='<%# Apple_Bss.CodeFile.DBConn.GetApplicationPath() + "/UploadedFiles/subscribers/" + Eval("PHOTOFILENAME").ToString() %>'  alt='' title='<%# Eval("PHOTOFILENAME").ToString()%>'/>   
                                                    <%# Eval("PHOTOFILENAME").ToString()%>  
                                                                             
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="14%" />
                                            </asp:TemplateField>

                        

                                 <%--                    working on it                     --%>  <%--  Apple_Bss.CodeFile.DBConn.GetApplicationPath() + Apple_Bss.CodeFile.DBConn.GetDocumentsPath()  +  --%>
                                
                                       <asp:TemplateField HeaderText="IDPROOFTYPE">
                                                <ItemTemplate>                                             
                                                    <%#Eval("IDPROOFTYPE").ToString() %><br />
                                                    <br />
                                                    <a id= "anchorIdProof" href='<%# Apple_Bss.CodeFile.DBConn.GetApplicationPath() + Apple_Bss.CodeFile.DBConn.GetDocumentsPath()  +  Eval("IDPROOFNAME").ToString() %>'  target="_blank" runat="server">  <%#Eval("IDPROOFNAME").ToString() %>  <%--Document.pdf --%> </a>
                                                    <br />
                                                    <label id="errorLabelIdProof" runat="server"> Error label </label> <%--new addition--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="18%" />
                                            </asp:TemplateField>


                                 <%--              working on it          --%>    <%-- Apple_Bss.CodeFile.DBConn.GetApplicationPath() + Apple_Bss.CodeFile.DBConn.GetDocumentsPath()  +  --%>



                        <asp:TemplateField HeaderText="ADDPROOFNAME">
                                                <ItemTemplate>     
                                                     <%#Eval("ADDRESSPROOFTYPE").ToString() %> <br />                                       
                                                   <br />
                                                           <a id= "anchorAddProof" href='<%# Apple_Bss.CodeFile.DBConn.GetApplicationPath() + Apple_Bss.CodeFile.DBConn.GetDocumentsPath()  + Eval("ADDPROOFNAME").ToString() %>' target="_blank" runat="server" >  <%#Eval("ADDPROOFNAME").ToString() %>   <%--Document.pdf --%> </a>
                                                     <br />
                                                    <label id="errorLabelAddProof" runat="server"> Error label </label> <%--new addition--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="18%" />
                                            </asp:TemplateField>


                         
                          </Columns>
                            <PagerTemplate>
                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="tdStyle" style="font: 8pt Arial;text-align: left; color: #888888; padding-left: 0px" width="90%">
                                            <asp:Label ID="_lblCurrentPageNumber" runat="server"></asp:Label>
                                            &nbsp;
                                        
                                        </td>
                                        <td style="font:bold 8pt Arial; color: #000000;" align="right">
                                            Goto Page
                                            <asp:DropDownList ID="ddlPageSelector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <RowStyle CssClass="gridRowStyle" />
                            <PagerStyle CssClass="gridPagerStyle" />
                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeader" />
                            <AlternatingRowStyle CssClass="gridAltRow" />
                        </asp:GridView>
                     
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    Loading... Please Wait
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            
        </ContentTemplate>
   
    </asp:UpdatePanel>

    



</asp:Content>

