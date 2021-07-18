<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMasterTable.aspx.cs" Inherits="Apple_Bss.Developer.UserMasterTable" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:Grid ID="Grid1" runat="server" DataSourceID="SqlDataSource1"></cc1:Grid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:INETBILLKOHIMAConnectionString %>" DeleteCommand="DELETE FROM [USERMASTER] WHERE [USERID] = @USERID AND [USERNAME] = @USERNAME" InsertCommand="INSERT INTO [USERMASTER] ([USERID], [USERNAME], [NAME], [Remarks], [STATUS]) VALUES (@USERID, @USERNAME, @NAME, @Remarks, @STATUS)" SelectCommand="SELECT top 100 [USERID], [USERNAME], [NAME], [Remarks], [STATUS] FROM [USERMASTER]" UpdateCommand="UPDATE [USERMASTER] SET [NAME] = @NAME, [Remarks] = @Remarks, [STATUS] = @STATUS WHERE [USERID] = @USERID AND [USERNAME] = @USERNAME">
            <DeleteParameters>
                <asp:Parameter Name="USERID" Type="String" />
                <asp:Parameter Name="USERNAME" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="USERID" Type="String" />
                <asp:Parameter Name="USERNAME" Type="String" />
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="Remarks" Type="String" />
                <asp:Parameter Name="STATUS" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="Remarks" Type="String" />
                <asp:Parameter Name="STATUS" Type="String" />
                <asp:Parameter Name="USERID" Type="String" />
                <asp:Parameter Name="USERNAME" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
