<%@ Page Language="C#" MasterPageFile="~/UI/BillingAndCustomerCare/Billing/BillingMaster.Master"
    AutoEventWireup="true" CodeBehind="ArrearWaiverHistory.aspx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.ArrearWaiverHistory"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table border="0" cellpadding="0" cellspacing="0" class="mainTable" align="center">
        <tr>
            <td class="tdtitle">
                Arrears and Waivers History
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="tableStyle"
                    align="center">
                    <tr>
                        <td class="tdStyle" colspan="2">
                        &nbsp;
                            <asp:Label ID="_lblValidUser" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" colspan="2">
                            <asp:RadioButtonList ID="_rbtnArWaiv" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="A">Arrear History</asp:ListItem>
                                <asp:ListItem Value="W">Waiver History</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" width="20%">
                            <asp:Label ID="_lblBc" runat="server"></asp:Label>
                            -SCLX &nbsp;<asp:TextBox ID="_txtUserID" runat="server" Width="100px" CssClass="TextBoxBorder"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="_txtUserID" ErrorMessage="*"></asp:RequiredFieldValidator>
                            
                            </td>
                        <td class="tdStyle">
                            <asp:ImageButton ID="_btnViewHistory" runat="server" 
                                ImageUrl="~/Images/Buttons/View History.jpg"  onclick="_btnViewHistory_Click" />
                        </td>
                    </tr>
                    <tr class="tdgap">
                        <td class="tdgap" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdgap" colspan="2">
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
                <asp:Panel ID="_panelArrear" runat="server">
                 <div class="tdSubtitle">Arrear</div>
                <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                    <tr>
                        <td class="">
                            <asp:GridView ID="_gvArrearHistory" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No record exist!" CssClass="gridStyle" GridLines="None" 
                                PageSize="5">
                                <Columns>
                                    <asp:BoundField HeaderText="Date" DataField="MODON" 
                                        DataFormatString="{0:dd-MMM-yyyy}" >
                                        <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField HeaderText="Cycle ID" DataField="CYCLEID" >
                                        <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField HeaderText="Arrear Amount" DataField="ARREAR" >
                                       <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                   
                                    <asp:BoundField HeaderText="Remarks" DataField="REMARKS" >
                                      <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="40%"/>
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="gridRowStyle" />
                                <PagerStyle CssClass="gridPagerStyle" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                <AlternatingRowStyle CssClass="gridAltRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tdgap">
            </td>
        </tr>
        <tr>
            <td class="mainTD">
                <asp:Panel ID="_panelWaiver" runat="server">
                
                <div class="tdSubtitle">Waiver</div>
                <table border="0" cellpadding="0" cellspacing="0" class="tableStyle" align="center">
                    <tr>
                        <td class="">
                            <asp:GridView ID="_gvWaiverHistory" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No record Exist!" CssClass="gridStyle" GridLines="None" 
                                PageSize="5">
                                <Columns>
                                     <asp:BoundField HeaderText="Date" DataField="MODON" 
                                        DataFormatString="{0:dd-MMM-yyyy}" >
                                        <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField HeaderText="Cycle ID" DataField="CYCLEID" >
                                        <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField HeaderText="Waiver Amount" DataField="WAIVER" >
                                       <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="20%"/>
                                    </asp:BoundField>
                                   
                                    <asp:BoundField HeaderText="Remarks" DataField="REMARKS" >
                                      <HeaderStyle  CssClass="gridLeftPad" HorizontalAlign="Left"/>
                                        <ItemStyle CssClass="gridLeftPad" HorizontalAlign="Left" Width="40%"/>
                                    </asp:BoundField>
                                    </Columns>
                                <RowStyle CssClass="gridRowStyle" />
                                <PagerStyle CssClass="gridPagerStyle" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="gridHeader" />
                                <AlternatingRowStyle CssClass="gridAltRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
