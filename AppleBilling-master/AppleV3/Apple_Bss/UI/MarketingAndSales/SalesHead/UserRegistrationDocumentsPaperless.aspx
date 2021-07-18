<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="UserRegistrationDocumentsPaperless.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.UserRegistrationDocumentsPaperless" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <div class="content-wrapper">
            <div class="page-header page-header-default">
                <div class="page-header-content">
                    <div class="page-title">
                        <h4><span class="text-semibold">Update User Documents</span></h4>
                    </div>
                </div>
                <div class="breadcrumb-line">
                    <ul class="breadcrumb">
                        <li><a href="index.html"><i class="icon-home2 position-left"></i>Home</a></li>
                        <li class="active">Sales Head Home > Update User Documents</li>
                    </ul>

                    <%--<ul class="breadcrumb-elements">
							
						</ul>--%>
                </div>
            </div>
            <div class="content">
                <div class="row">
                    <div class="panel panel-flat">
                        <div class="panel-heading">
                            <%-- <div class="content">
                        <div class="row">
                            <div class="panel panel-flat">	
                                <div class="panel-heading">--%>
                            <%--<h5 class="panel-title "><legend class="text-bold">  Update Broadband Subscriber Registration Documents</legend></h5>--%>
                        </div>




                        <div class="container-fluid">

                            <div class="panel-body" style="padding-bottom: 0px;">
                                <div class="form-group ">
                                    <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Customer Name:</label>
                                    <div class="col-xs-7">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload User Photo <span class="text-danger">*</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadUserPhoto" runat="server" FileTypeRange="jpg,gif,png" />
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">ID Proof Type:</label>
                                    <div class="col-xs-7">
                                        <asp:Label ID="lblIDProofDocumentType" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload ID Proof Document<span class="text-danger">*</span></label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadIDProof" runat="server" FileTypeRange="pdf,jpg,png,gif" />
                                    </div>
                                </div>

                                 <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload ID Proof Back Side</label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadIDProofBack" runat="server" FileTypeRange="pdf,jpg,png,gif"  />
                                    </div>
                                </div>


                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Installation Address Proof Type:</label>
                                    <div class="col-xs-7">
                                        <asp:Label ID="lblAddressProofDocumentType" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload Address Proof Document<span class="text-danger">*</span></label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadAddressProof" runat="server" FileTypeRange="pdf,jpg,png,gif"  />
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload Address Proof Back Side</label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadAddressProofBack" runat="server" FileTypeRange="pdf,jpg,png,gif" />
                                    </div>
                                </div>

                                <%-- </div>--%>
                                <div class="panel-body" style="padding-bottom: 0px; display: none">
                                    <div class="form-group row">
                                        <label class="col-xs-5 col-form-label" style="padding: 0;">CAF Number:</label>
                                        <div class="col-xs-7">
                                            <asp:TextBox ID="tbCAFNumber" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <%--<div class="panel-body" style="padding-bottom:0px;">--%>
                                <div class="form-group row">
                                    <label class="col-xs-5 col-form-label" style="padding: 0;">Upload Signature<span class="text-danger">*</span></label>
                                    <div class="col-xs-7">
                                        <uc1:UploadPhoto ID="UploadSignature" runat="server" FileTypeRange="pdf,jpg,png,gif" />
                                    </div>
                                </div>
                                <%--</div>--%>

                                <div class="panel-body" style="padding-bottom: 0px; display: none">
                                    <div class="form-group" style="display: none">
                                        <label class="control-label col-lg-3" style="padding: 0;">Annexure Document:</label>
                                        <uc1:UploadPhoto ID="UploadCAFAnnexureDoc" runat="server" FileTypeRange="pdf" />
                                    </div>
                                </div>
                                <%--<div class="panel-body" style="padding-bottom:0px; ">--%>
                                <div class="form-group row">
                                    <%--<label class="col-xs-5 col-form-label" style="padding: 0;"></label>
                                    <div class="col-xs-7">--%>
                                        <asp:Button ID="Submit" runat="server" CssClass="btn btn-primary col-xs-5" Text="Upload Files" OnClick="_btnRegister_Click" />
                                    <%--</div>--%>
                                </div>
                                <%--</div>--%>
                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="form-group">
                                        <b>Instructions:</b><br />
                                        *Image format accepted for user&nbsp; photo and user signature are png, jpg or gif.<br />
                                        *Maximum allowed file size of each file is 400KB.<br />
                                        *ID Proof and Address Proof documents accepted format is png, jpg, gif or pdf.<br />

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
