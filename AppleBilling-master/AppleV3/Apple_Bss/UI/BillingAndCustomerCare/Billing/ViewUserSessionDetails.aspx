<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master" AutoEventWireup="true" CodeBehind="ViewUserSessionDetails.aspx.cs" Inherits="Symb_InetBill.UI.BillingAndCustomerCare.Billing.ViewUserSessionDetails" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="mainTable" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="tdtitle">
                Session Data Transfer Details
            </td>
        </tr>
        
        <tr>
              <td class="mainTD">
                <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                    
                    <tr>
                        <td class="tdgap" colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdStyle" width="20%">
                            Search Subscriber&nbsp; Username</td>
                        <td class="tdStyle" width="25%">
                          <asp:TextBox ID="_txtUserName" runat="server" CssClass="TextBoxBorder" 
                                        Width="150px"></asp:TextBox>
                                     
                                     <cc1:AutoCompleteExtender ID="_txtUserName_AutoCompleteExtender" runat="server" 
                                         DelimiterCharacters="" Enabled="True" ServicePath="~/CodeFile/ISubscribers.asmx" 
                                         ServiceMethod="GetSubscribers" CompletionListCssClass="auto_completionListElement" 
                                        CompletionListHighlightedItemCssClass="auto_highlightedListItem" 
                                        MinimumPrefixLength="2"
                                        CompletionListItemCssClass="auto_listItem" CompletionSetCount="20" CompletionInterval="500"
                                        TargetControlID="_txtUserName">
                                    </cc1:AutoCompleteExtender>
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="_txtUserName" ErrorMessage="* required" 
                                     ValidationGroup="uname"></asp:RequiredFieldValidator>
                        </td>
                        <td class="tdStyle" width="10%">
                            <asp:ImageButton ID="_imgBtnGetDetails" runat="server" 
                            ValidationGroup="uname" onclick="_imgBtnGetDetails_Click" 
                            ImageUrl="~/Images/Buttons/Get Details.jpg" />
                        </td>
                        <td class="tdView" rowspan="4">
                            <asp:Literal ID="_ltrUserInfo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            <asp:Label ID="_lblBillCycle" runat="server" Text="Bill Cycle Name"></asp:Label>
                        </td>
                        <td class="tdStyle">
                            <asp:DropDownList ID="_ddlBillCycle" runat="server" Height="22px" Width="155px">
                            </asp:DropDownList>
                        </td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="ImgBtnView" runat="server" 
                                ImageUrl="~/Images/Buttons/View.jpg" onclick="ImgBtnView_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="3">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
           
            <!--<asp:Panel ID="_panelGridview" runat="server"> -->
             <td class="mainTD">
               <div class="tdSubtitle">Data Transfer Details </div>
                <table class="tableStyle" cellspacing="0" cellpadding="0" align="center">
                    
                    <tr>
                        <td class="tdStyle">
                            <asp:GridView ID="_gvDataTransferDetails" runat="server" 
                                AutoGenerateColumns="False" Width="100%" GridLines="Horizontal" 
                                HorizontalAlign="Center" CssClass="gridStyle" 
                                EmptyDataText="record does not exist.." ShowFooter="True">
                                <RowStyle Height="30px" />
                            <Columns>
                                
                                <asp:BoundField DataField="CLIENTIP" HeaderText="Client IP Address">
                                    <ItemStyle Width="13%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SNATIP" HeaderText="SNAT IP Address">
                                    <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                 </asp:BoundField>                                
                                <asp:BoundField DataField="STARTTIME" HeaderText="Start Time" DataFormatString="{0:dddd,MMM,yyyy hh:mm:ss tt }">
                                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="STOPTIME" HeaderText="Stop Time" DataFormatString="{0:dddd,MMM,yyyy hh:mm:ss tt }">
                                     <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                </asp:BoundField>
                                <asp:BoundField DataField="USEDTIME" HeaderText="Used Time" FooterText="Total">
                                     <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                                    <FooterStyle HorizontalAlign="Right" CssClass="gridRightPad" Font-Bold="True" />
                                </asp:BoundField>
                                  <asp:TemplateField HeaderText="Upload MB">
                                                        <ItemTemplate>
                                                            <%#Eval("UPLOADBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=totUploadData%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Download MB">
                                                        <ItemTemplate>
                                                            <%#Eval("DOWNLOADBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=totDownloadData%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Total MB">
                                                        <ItemTemplate>
                                                            <%#Eval("TOTALBYTES").ToString()%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <span style="color: red; font-weight: bold">
                                                                <%=TotalDataTransfer%>
                                                            </span>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="Center" Height="22px" CssClass="gridRightPad" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" CssClass="gridRightPad" />
                                                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gridRightPad" />
                                </asp:TemplateField>
                              
                            </Columns>
                            <PagerStyle CssClass="gridPagerStyle" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                        </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
             
           <!-- </asp:Panel> -->
        </tr>
                
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
 
</asp:Content>
