<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientSearchView.ascx.cs" Inherits="Apple_Bss.UserControl.ClientSearchView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
  <link href="../../../CSS/InetBill.css" rel="stylesheet" type="text/css" />
<style type="text/css">
   
.gridStyle
{
	 background-color:#ffffff; font: 9pt arial;color:#666666; border:solid 0px #fbeed2;
}

 .gridHeader{ background:#f1a80e; background-repeat:repeat-x; 
              background-position:left top; height:30px; padding-left:5px; font:bold 9pt arial;
			  color:#ffffff; border-top: solid 0px #e49e09;
             
        }   

.gridLeftPad
{
	padding-left:10px;
}
.gridRightPad
{
	padding-right:10px;
}

.gridRowStyle
{
	 border-top:solid 4px #f7f7f7;border-bottom:solid 4px #f7f7f7; height:65px;
}
	
.gridAltRow
{
	border-top:solid 0px #e5e5e5;border-bottom:solid 0px #e5e5e5; background-color:#ffffff;height:65px;
}

.gridPagerStyle
{
	padding:5px; text-align: left;
}

</style>
<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
        ChildrenAsTriggers="true">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                        Search &amp; View Client Details</td>
                </tr>
                <tr>
                    <td class="mainTD">
                        
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td colspan="4" class="tdStyle" style="padding-left: 0px">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">
                                    </asp:Label>&nbsp;
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="tdStyle" style="width: 12%">
                                    <strong>USERNAME</strong>
                                </td>
                                <td class="tdStyle" style="width: 20%" >
                               
                                    <asp:TextBox ID="_tbUserName" runat="server" AutoPostBack="True" 
                                        ontextchanged="_tbUserName_TextChanged"></asp:TextBox>
                               

                                    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
                                        CompletionInterval="500" DelimiterCharacters="" Enabled="True" 
                                        MinimumPrefixLength="2" ServiceMethod="GetSubscribers" 
                                        ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserName" 
                                        CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20">
                                    </cc1:AutoCompleteExtender>
                              
                                   
                                    </td>
                                          <td class="tdStyle" style="width: 12%">
                                              <strong>OR  USERID</strong> 
                                              </td>
                                     <td class="tdStyle">

                                              <asp:Label ID="lblBranchCode" runat="server" Text="">
                                    </asp:Label>-SCLX<asp:TextBox ID="tbUserId" runat="server" AutoPostBack="True" ontextchanged="tbUserId_TextChanged"></asp:TextBox>
                                    
                                </td>
                            </tr>
                           
                            <tr>
                                <td class="tdStyle">
                                    &nbsp;
                                </td>
                                <td class="tdStyle" colspan="3" >
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" 
                                        RenderMode="Inline" ChildrenAsTriggers="False">
                                                            <ContentTemplate>
                                                                <asp:Literal ID="_ltrlSubscriberDetails" runat="server"></asp:Literal>                                                                
                                                                <asp:HiddenField ID="HiddenFieldUserId" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="_tbUserName" />
                                                                <asp:AsyncPostBackTrigger ControlID="tbUserId" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                      <span style="color:Green; font-weight:bold">getting customer details ...</span>
                              
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                       
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdgap">
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            Client Details
                        </div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td class="tdStyle" style="width:20%">  Name</td>
                                <td class="tdStyle" style="width:25%">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                                <td class="tdStyle" style="width:20%">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width:20%">Connected Status</td>
                                <td class="tdStyle" style="width:25%">
                                    <asp:Label ID="lblConnectedStatus" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="tdStyle" style="width:40%">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">POP Connected</td>
                                <td class="tdStyle" >
                                    <asp:Label ID="lblPOPConnected" runat="server"></asp:Label>
                                </td>
                                
                                <td class="tdStyle">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Connection Type &amp; Details</td>
                                <td class="tdStyle">
                                    <asp:Label ID="lblConnectionType" runat="server"></asp:Label>
                                </td>
                                <td  class="tdStyle">
                                    -
                                    <asp:Label ID="lblConnectionDetails" runat="server"></asp:Label>
                                </td>
                                
                            </tr>

                              <tr>
                                <td class="tdStyle">
                                    Installation Connection Type</td>
                                <td class="tdStyle">
                                    <asp:Label ID="lblInstallationConnectionType" runat="server"></asp:Label>
                                </td>
                            </tr>


                      
                            <tr>
                                <td class="tdStyle" >Email - Mobile No.</td>
                                <td class="tdStyle" >
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    &nbsp;-
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                </td>
                                <td class="tdStyle" style="text-align:right;">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle" style="vertical-align:text-top" >Installation &amp; Correspondance address</td>
                                <td class="tdStyle" >
                                    <asp:Label ID="lblInstallationAddress" runat="server"></asp:Label>
                                </td>
                                <td class="tdStyle">-<asp:Label ID="lblCorrespondenceAddress" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">Plan Name</td>
                                <td class="tdStyle" colspan="2">
                                    <asp:Label ID="lblBillPlanName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">Monthly Rental</td>
                                <td class="tdStyle">
                                    <asp:Label ID="lblMontlyRental" runat="server"></asp:Label>
                                </td>
                                <td class="tdStyle">&nbsp;</td>
                            </tr>
                               <tr>
                                <td class="tdStyle" style="width:20%">
                                    Connection Date</td>
                                <td class="tdStyle" style="width:25%">
                                    <asp:Label ID="lblConnectionDate" runat="server"></asp:Label>
                                </td>
                                
                                <td class="tdStyle" style="width:40%">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">Has the client registered online?</td>
                                <td class="tdStyle" >
                                    <asp:Label ID="lblOnlineRegisteredStatus" runat="server"></asp:Label>
                                </td>
                                
                                <td class="tdStyle">&nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td class="tdStyle">
                                    Has client applied for forgotten password?</td>
                                <td colspan="2" class="tdStyle">
                                    <asp:Label ID="lblForgottenPasswordStatus" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                        </table>
                    </td>
                </tr>
         

                <tr>
                    <td class="mainTD">
                        
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                         




                              <tr>                       
                                           <td class="tdSubtitle" colspan="3">Last 5 Service Requests Records</td>  

                              </tr>
                            <tr>
                                <td class="tdStyle" colspan="3">
                                    <asp:GridView ID="_gvViewServiceRequestReport" runat="server" AutoGenerateColumns="False" CssClass="gridStyle" EmptyDataText="No record Exist!..." GridLines="None"  PageSize="6" Style="padding-left: 10px" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR Number">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('ServiceRequestDetail.aspx?issueid=<%# Eval("issueid").ToString()%>','myPop1',900,600);" target="_parent"><%#Eval("issueid").ToString() %></a>
                                                </ItemTemplate>
                                                
                                                <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                          
                                            <asp:BoundField DataField="ISSUE" HeaderText="Issue Reported">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="15%" />
                                            </asp:BoundField>

                                                     <asp:BoundField DataField="ISSUECAUSE" HeaderText="Issue Cause /Action Taken">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ISSUEREPORTEDDATETIME" DataFormatString="{0:dd-MMM-yyyy  hh:mm }" HeaderText="Reported On">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ISSUERESOLVEDDATETIME" DataFormatString="{0:dd-MMM-yyyy:: hh:mm }" HeaderText="Fixed On">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="12%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SUPPORTTYPE" DataFormatString="{0:dd-MMM-yyyy hh:mm }" HeaderText="Support Type">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>
                                                 <asp:BoundField DataField="STATUS" HeaderText="Status">
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="8%" />
                                            </asp:BoundField>

                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                                 <tr>
                                <td class="tdSubtitle" colspan="3">             
                                     Last 4 Client Records of Payments Recieved and Bills Raised</td>
                                  
                            </tr>
                            <tr>
                                <td class="tdStyle" colspan="3">

                                    <asp:GridView ID="_gvSubscriberLedger" runat="server" AutoGenerateColumns="False" CssClass="gridStyle" EmptyDataText="No record Exist " GridLines="None"  PageSize="6"  Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Instrument No.">
                                                <ItemTemplate>
                                                    <a href="javascript:PopupCenter('../Billing/SubscriberBillDisplay.aspx?bnum=<%# Eval("INSTRUMENTID").ToString()%>','myPop1',900,700);"><%#Eval("INSTRUMENTID").ToString()%></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MODON" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SPECIFICATIONS"  HeaderText="Ledger Head">
                                          
                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                            <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Due (in Rs.)">
                                                <ItemTemplate>
                                                    <%#Eval("CR").ToString()%>
                                                </ItemTemplate>
                                             
                                                <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="10%" />
                                                        <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paid (in Rs.)">
                                                <ItemTemplate>
                                                    <%#Eval("DR").ToString()%>
                                                </ItemTemplate>
                                              
                                                  
                                                 
                                                <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="15%" />
                                                        <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="gridRowStyle" />
                                        <PagerStyle CssClass="gridPagerStyle" />
                                        <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="gridAltRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 25%" >
                                    
                                    <strong>Total Outstanding Amount (Rs.)</strong></td>
                                 <td class="tdStyle" style="text-align:left;" colspan="2">
                                    
                                     <asp:Label ID="lblTotalOutstandingAmount" runat="server" style="font-weight: 700"></asp:Label>
                                    
                            </tr>
                       
                                   <tr>
                                <td class="tdStyle" style="width: 25%">             
                                     &nbsp;</td>
                                  
                                       <td class="tdStyle" style="text-align:left;">&nbsp;</td>
                                  
                            </tr>
                       
                            <tr>
                                <td class="tdSubtitle" colspan="3">Last 3 Arrears (Morebytes etc.) &amp; Waivers&nbsp
                                    </td>
                                </tr>
                              <tr>
                                  <td class="tdStyle" colspan="3">
                                      <asp:GridView ID="gvArrearsAndWaivers" runat="server" AutoGenerateColumns="False" CssClass="gridStyle" EmptyDataText="No record Exist " GridLines="None" PageSize="6" Width="100%">
                                          <Columns>
                                              <asp:BoundField DataField="MODON" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Entry Date">
                                              <ItemStyle HorizontalAlign="Center" Width="10%" />
                                              </asp:BoundField>
                                              <asp:TemplateField HeaderText="Waiver (in Rs.)">
                                                  <ItemTemplate>
                                                      <%#Eval("waiver").ToString()%>
                                                  </ItemTemplate>
                                                  <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="10%" />
                                                  <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Arrear(in Rs.)">
                                                  <ItemTemplate>
                                                      <%#Eval("Arrear").ToString()%>
                                                  </ItemTemplate>
                                                  <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="10%" />
                                                  <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                              </asp:TemplateField>
                                              <asp:BoundField DataField="Remarks" HeaderText="Narration">
                                              <ItemStyle HorizontalAlign="Left" Width="40%" />
                                              <HeaderStyle CssClass="gridLeftPad" HorizontalAlign="Left" />
                                              </asp:BoundField>
                                          </Columns>
                                          <RowStyle CssClass="gridRowStyle" />
                                          <HeaderStyle CssClass="gridHeader" HorizontalAlign="Center" />
                                          <AlternatingRowStyle CssClass="gridAltRow" />
                                      </asp:GridView>
                                  </td>
                              </tr>
                            </tr>
                          
                        <tr>
                            <td class="tdStyle">&nbsp;</td>
                </tr>
                <tr>
                    <td class="tdgap"></td>
                </tr>
                          
                        </table>
        </ContentTemplate>
    </asp:UpdatePanel>