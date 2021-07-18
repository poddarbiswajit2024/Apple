<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arrears.aspx.cs" Inherits="Apple_Bss.Developer.Arrears" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:Grid ID="Grid1" runat="server"  DataSourceID="SqlDataSource1" PageSize="10" AllowFiltering="True" AllowGrouping="True"></cc1:Grid>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INETBILLDIMAPURConnectionString %>" DeleteCommand="DELETE FROM [WAD] WHERE [ID] = @ID" InsertCommand="INSERT INTO [WAD] ([USERID], [WAIVER], [ARREAR], [DNB], [CYCLEID], [MODON], [MODBY], [REMARKS]) VALUES (@USERID, @WAIVER, @ARREAR, @DNB, @CYCLEID, @MODON, @MODBY, @REMARKS)" SelectCommand="SELECT top 100 * FROM [WAD] ORDER BY [ID] DESC" UpdateCommand="UPDATE [WAD] SET [USERID] = @USERID, [WAIVER] = @WAIVER, [ARREAR] = @ARREAR, [DNB] = @DNB, [CYCLEID] = @CYCLEID, [MODON] = @MODON, [MODBY] = @MODBY, [REMARKS] = @REMARKS WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="USERID" Type="String" />
                <asp:Parameter Name="WAIVER" Type="Double" />
                <asp:Parameter Name="ARREAR" Type="Double" />
                <asp:Parameter Name="DNB" Type="String" />
                <asp:Parameter Name="CYCLEID" Type="Decimal" />
                <asp:Parameter Name="MODON" Type="DateTime" />
                <asp:Parameter Name="MODBY" Type="String" />
                <asp:Parameter Name="REMARKS" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="USERID" Type="String" />
                <asp:Parameter Name="WAIVER" Type="Double" />
                <asp:Parameter Name="ARREAR" Type="Double" />
                <asp:Parameter Name="DNB" Type="String" />
                <asp:Parameter Name="CYCLEID" Type="Decimal" />
                <asp:Parameter Name="MODON" Type="DateTime" />
                <asp:Parameter Name="MODBY" Type="String" />
                <asp:Parameter Name="REMARKS" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
