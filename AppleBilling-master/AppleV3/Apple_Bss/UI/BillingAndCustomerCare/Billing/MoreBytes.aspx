<%@ Page Title="" Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="MoreBytes.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.MoreBytes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




            <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
                <tr>
                    <td class="tdtitle">
                    
                    </td>
                </tr>
                <tr>
                    <td class="mainTD">
                        <div class="tdSubtitle">
                            More Bytes</div>
                        <table class="tableStyle" cellspacing="0" cellpadding="0" border="0" align="center">
                            <tr>
                                <td colspan="2" class="tdStyle" style="padding-left: 0px">
                                    <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">
                                    </asp:Label>&nbsp;
                                </td>
                            </tr>
                         
                            <tr>
                                <td class="tdStyle" style="width: 15%">
                                    Location</td>
                                <td class="tdStyle" style="width: 85%">
                               
                                    <asp:RadioButtonList ID="rblLocation" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="DMP">Dimapur</asp:ListItem>
                                        <asp:ListItem Value="KOH">Kohima</asp:ListItem>
                                        <asp:ListItem Value="MKG">Mokokchung</asp:ListItem>
                                    </asp:RadioButtonList>
                              
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblLocation" ErrorMessage="required!"></asp:RequiredFieldValidator>
                              
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle" style="width: 15%">Username </td>
                                <td class="tdStyle" style="width: 85%">
                                    <asp:TextBox ID="_tbUserName" runat="server" AutoPostBack="True" ontextchanged="_tbUserName_TextChanged" onkeyup = "SetContextKey()"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" CompletionInterval="500" CompletionListCssClass="auto_completionListElement" CompletionListHighlightedItemCssClass="auto_highlightedListItem" CompletionListItemCssClass="auto_listItem" CompletionSetCount="20" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="2" ServiceMethod="GetSubscriberInfoByLocation" UseContextKey = "true"  ServicePath="~/CodeFile/ISubscribers.asmx" TargetControlID="_tbUserName">
                                    </cc1:AutoCompleteExtender>
                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="_tbUserName" ErrorMessage="required!"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                     
                            
                            <tr>
                                <td class="tdStyle">
                                    <asp:Label ID="_lblDetails" Visible="true" runat="server" Text="Customer Details"></asp:Label>&nbsp;
                                </td>
                                <td class="tdStyle">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" 
                                        RenderMode="Inline" ChildrenAsTriggers="False">
                                                            <ContentTemplate>
                                                                <asp:Literal ID="_ltrlSubscriberDetails" runat="server"></asp:Literal>                                                                
                                                                <asp:HiddenField ID="HiddenFieldUserId" runat="server" />
                                                                 <asp:Label ID="lblUserPlanCode" runat="server" ></asp:Label>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="_tbUserName" />
                                                              
                                                              
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                      <span style="color:Green; font-weight:bold">getting customer basic details ...</span>
                              
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">Top Up Amount (GB) </td>
                                <td class="tdStyle"><asp:RadioButtonList ID="rbltopups" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Value="1">1 GB</asp:ListItem>
            <asp:ListItem Value="3">3 GB</asp:ListItem>
            <asp:ListItem Value="5">5 GB</asp:ListItem>
            <asp:ListItem Value="10">10 GB</asp:ListItem>
            <asp:ListItem Value="20">20 GB</asp:ListItem>
            <asp:ListItem Value="40">40 GB</asp:ListItem>
            <asp:ListItem Value="80">80 GB</asp:ListItem>
            <asp:ListItem Value="100">100 GB</asp:ListItem>
            <asp:ListItem Value="200">200 GB</asp:ListItem>
            <asp:ListItem Value="500">500 GB</asp:ListItem>
        </asp:RadioButtonList>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rbltopups" ErrorMessage="required!"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">&nbsp;</td>
                                <td class="tdStyle">
                                                                 <asp:Label ID="lblAppliedMoreBytesPackage" runat="server" ></asp:Label>
                                                                  </td>
                            </tr>
                            <tr>
                                <td class="tdStyle">&nbsp;</td>
                                <td class="tdStyle">
                                    <asp:ImageButton ID="_btnActivateMoreBytes" runat="server" CausesValidation="true" ImageUrl="~/Images/Buttons/Submit.jpg" OnClick="_btnActivateMoreBytes_Click"  />
                                    <asp:Button ID="btnActivate" runat="server" OnClick="btnActivate_Click" Text="Activate" />
                                </td>
                            </tr>
                            <tr class="tdgap">
                                <td colspan="2">
                                    &nbsp;
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
                    <td class="tdgap">
                    </td>
                </tr>
            </table>
 
</asp:Content>
