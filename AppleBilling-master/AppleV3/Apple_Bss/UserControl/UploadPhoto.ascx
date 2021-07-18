<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPhoto.ascx.cs" Inherits="Apple_Bss.UserControl.UploadPhoto" %>
<span style="float:left">
<asp:FileUpload ID="FilUpl" runat="server" ForeColor="#0066FF" /></span>
<span>
<asp:CustomValidator ID="ErrorMsg" runat="server" ForeColor="Red"
    ErrorMessage="CustomValidator" OnServerValidate="ErrorMsg_ServerValidate" 
    ></asp:CustomValidator></span>
