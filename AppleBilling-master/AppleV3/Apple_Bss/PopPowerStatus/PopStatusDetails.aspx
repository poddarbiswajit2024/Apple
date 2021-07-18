<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopStatusDetails.aspx.cs" Inherits="Apple_Bss.PopPowerStatus.PopStatusDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">

       <style type="text/css">
           body
           {
                font-family: 'Lato', sans-serif;
                font-size: 14px;
           }
           </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-bottom: 11px; padding-top: 11px;">
        <asp:DetailsView ID="DetailsView1" runat="server" HorizontalAlign="Center" Height="50px" Width="455px" CellPadding="4" DataSourceID="SqlDataSource1" EnableModelValidation="True" Font-Size="16px" ForeColor="#333333" GridLines="None" AutoGenerateRows="False">

               <FieldHeaderStyle BackColor="#DEE8F5"  />
            
               <Fields>
                <asp:BoundField DataField="POPNAME" HeaderText="POP Name" SortExpression="POPNAME" />
                <asp:BoundField DataField="gridip"  HeaderText="Grid IP" SortExpression="gridip" />
                <asp:BoundField DataField="backupip" HeaderText="Backup IP" SortExpression="backupip" />
            </Fields>


               <AlternatingRowStyle BackColor="White" />
               <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />


            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#EFF3FB" />
          
        </asp:DetailsView>
        </div>

    <div>
        


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="#333333" GridLines="None" AllowSorting="True" AllowPaging="True" Width="92%" HorizontalAlign="Center" PageSize="19">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
     

               <asp:BoundField DataField="STARTDATETIME" HeaderText="START DATE & TIME" SortExpression="STARTDATETIME" DataFormatString="{0:dd.MM.yy   hh:mm:ss tt}" >
                    <ItemStyle Width="14%" HorizontalAlign="Left" CssClass="gridLeftPad"  />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                    </asp:BoundField> 


                <asp:BoundField DataField="STOPDATETIME" HeaderText="STOP DATE & TIME" SortExpression="STOPDATETIME" DataFormatString="{0:dd.MM.yy   hh:mm:ss tt}"  >
                    <ItemStyle Width="14%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                    </asp:BoundField>
                
                 <asp:BoundField DataField="Duration" HeaderText="DURATION (hh:mm:ss)" SortExpression="DURATION" >
                    <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                    </asp:BoundField>
                
                 
                <asp:BoundField DataField="status" HeaderText="STATUS (click to sort)" ReadOnly="True" SortExpression="status" >
                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="gridLeftPad" />
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridLeftPad" />
                    </asp:BoundField> 
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"  PageButtonCount="40" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left"  />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />


        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INETBILLDIMAPURConnectionString %>" SelectCommand="GetPopStatusDetails" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter  Name="popid" QueryStringField="pop" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
