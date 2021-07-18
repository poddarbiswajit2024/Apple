<%@ Page Title="Update User Registration" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true"
    CodeBehind="UpdateUserRegistrationDocumentsPaperless.aspx.cs"
    Inherits="Apple_Bss.UpdateUserRegistrationDocumentsPaperless" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/UploadPhoto.ascx" TagName="UploadPhoto" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <div class="content-wrapper">

            <!-- Page header -->
            <div class="page-header page-header-default">
                <div class="page-header-content">
                    <div class="page-title">
                        <h4><span class="text-semibold">Update User Documents One By One</span></h4>
                    </div>
                </div>

                <!-- may use a cloing div here-->

                <div class="breadcrumb-line">
                    <ul class="breadcrumb">
                        <li><a href="index.html"><i class="icon-home2 position-left"></i>Home</a></li>
                        <li class="active">Sales Head Home > Update User Documents One By One</li>
                    </ul>

                    <%--<ul class="breadcrumb-elements">
							
						</ul>--%>
                </div>
            </div>

            <div class="content">
                <div class="row">
                    <div class="panel panel-flat">
                        <div class="panel-heading">
                            <%--<h5 class="panel-title "><legend class="text-bold">  Update Broadband Subscriber Registration Documents</legend></h5>--%>
                            <%--<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>--%>

                            <div class="container-fluid">
                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="form-group">
                                        <asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
                                    </div>
                                    <%-- </div>

						<div class="panel-body" style="padding-bottom:0px;">--%>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">Name:</label>
                                        <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="Image221" Height="60px" runat="server" />
                                        <asp:Label ID="Label222" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>

                                    </div>

                                    <div class="form-group">

                                        <asp:Image ID="imgUserPhoto" Height="60px" runat="server" />
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0; margin: 0;">Upload New User Photo:</label>
                                        <uc1:UploadPhoto ID="UploadPhoto" runat="server" FileTypeRange="gif,png,jpg" />
                                    </div>
                                    <%--<div class="form-group" style="margin:0px; padding-bottom:11px;">
                                <label class="control-label col-lg-3" ></label>
                                		<asp:Button ID="btnUpdateUserPhoto"  runat="server" CssClass="btn btn-primary" OnClick="btnUpdateUserPhoto_Click" Text="Update User Photo" />
                            </div>--%>
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnUpdateUserPhoto" runat="server" CssClass="btn btn-primary" OnClick="btnUpdateUserPhoto_Click" Text="Update User Photo" />
                                        </div>
                                    </div>
                                </div>

                                <!-- Begining of  ID Proof -->
                                <div class="panel-body">
                                    <!-- for id proof-->
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">ID Proof Type:</label>
                                        <asp:Label ID="lblIDProofDocumentType" runat="server"></asp:Label>
                                    </div>


                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                            <label class="control-label col-lg-9" style="padding: 0; padding-left: 0px;">New ID Proof Type: </label>
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:DropDownList ID="_ddlIDProof" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_ddlIDProof_SelectedIndexChanged"
                                                DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value"
                                                Style="height: 22px" CssClass="select-search" Height="22px">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="_tbotherIDProof" runat="server" Visible="false" OnTextChanged="_tbotherIDProof_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group" style="padding: 0px;">
                                        <label class="control-label col-lg-3" style="padding: 0;">Uploaded ID Proof Document:</label>
                                        <asp:HyperLink ID="hlnkIDProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">Upload ID Proof Document:</label>
                                        <uc1:UploadPhoto ID="UploadIDProof" runat="server" FileTypeRange="gif,png,jpg,pdf" />
                                    </div>
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnUpdateIDProof" runat="server" CssClass="btn btn-primary" Text="Update ID Proof" OnClick="btnUpdateIDProof_Click1" />
                                        </div>
                                    </div>
                                </div>
                                <!--end for id proof-->

                                <!-- Begining of  ID Proof Back -->
                                <div class="panel-body">
                                    <!-- for id proof Back-->

                                    <div class="form-group" style="padding: 0px;">
                                        <label class="control-label col-lg-3" style="padding: 0;">Uploaded ID Proof Document Back Side:</label>
                                        <asp:HyperLink ID="hlnkIDProofBack" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">Upload ID Proof Document Back Side:</label>
                                        <uc1:UploadPhoto ID="UploadIDProofBack" runat="server" FileTypeRange="gif,png,jpg,pdf" />
                                    </div>
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnUpdateIDProofBack" runat="server" CssClass="btn btn-primary" Text="Update ID Proof Back Side" OnClick="btnUpdateIDProofBack_Click1" />
                                        </div>
                                    </div>
                                </div>
                                <!--end for id proof Back-->

                                <!-- START OF ADDRESS PROOF-->
                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0">Installation Address Proof Type:</label>
                                        <asp:Label ID="lblAddressProofDocumentType" runat="server"></asp:Label>
                                    </div>
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                            <label class="control-label col-lg-9" style="padding: 0; padding-left: 0px;">New Address Proof Type:</label>
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:DropDownList ID="_ddlAddressProof" runat="server" AutoPostBack="True" DataSourceID="XmlDataSource2"
                                                DataTextField="text" DataValueField="value"
                                                OnSelectedIndexChanged="_ddlAddressProof_SelectedIndexChanged"
                                                CssClass="select-search" Height="22px">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="_tbOtherAddrsProof" runat="server" Visible="False" OnTextChanged="_tbOtherAddrsProof_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0">Uploaded Address Proof:</label>
                                        <asp:HyperLink ID="hlnkAddressProof" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">Upload Address Proof Document:</label>
                                        <uc1:UploadPhoto ID="UploadAddressProof" runat="server" FileTypeRange="gif,png,jpg,pdf" Required="False" />
                                    </div>
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnAddressProof" runat="server" CssClass="btn btn-primary" Text="Update Address Proof" OnClick="btnAddressProof_Click1" />
                                        </div>
                                    </div>
                                </div>

                                <!-- END OF ADDRESS PROOF-->

                                <!-- START OF ADDRESS PROOF BACK -->
                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="form-group">
                                            <label class="control-label col-lg-3" style="padding: 0">Uploaded Address Proof Back Side:</label>
                                            <asp:HyperLink ID="hlnkAddressProofBack" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-lg-3" style="padding: 0;">Upload Address Proof Document (Back Side):</label>
                                            <uc1:UploadPhoto ID="UploadAddressProofBack" runat="server" FileTypeRange="gif,png,jpg,pdf" Required="False" />
                                        </div>
                                        <div class="row" style="padding-top: 20px;">
                                            <div class="col-lg-3">
                                            </div>
                                            <div class="col-lg-3" style="padding-bottom: 20px;">
                                                <asp:Button ID="btnAddressProofBack" runat="server" CssClass="btn btn-primary" Text="Update Address Proof Back Side" OnClick="btnAddressProofBack_Click1" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- END OF ADDRESS PROOF BACK-->

                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">Uploaded Signature:</label>
                                        <%--<asp:HyperLink ID="hlnkSignatureDocument" ForeColor="Blue" Target="_blank" runat="server"></asp:HyperLink>--%>
                                        <asp:Image ID="ImageSignature" Height="60px" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-lg-3" style="padding: 0;">New Signature:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                        <uc1:UploadPhoto ID="UploadCAFSignatureDoc" runat="server" FileTypeRange="gif,png,jpg"  />
                                    </div>
                                  
                                    <div class="row" style="padding-top: 20px;">
                                        <div class="col-lg-3">
                                        </div>
                                        <div class="col-lg-3" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnUpdateUserSignature" runat="server" CssClass="btn btn-primary" Text="Update User Signature" OnClick="btnUpdateUserSignature_Click" />
                                        </div>
                                    </div>
                                </div>
                                <!-- this is hidden and deleted-->
                                <div class="panel-body" style="padding-bottom: 0px; display: none;">
                                    <asp:TextBox ID="tbCAFNumber" ReadOnly="true" BorderColor="White" CssClass="TextBoxBorder" runat="server"></asp:TextBox>
                                </div>
                                <!-- end of hidden fields-->




                                <div class="panel-body" style="padding-bottom: 0px;">
                                    <div class="form-group">
                                        <asp:Panel ID="panelInstructions" runat="server" ScrollBars="Auto">
                                            <b>Instructions:</b><br />
                                            *Image format accepted for user&nbsp; photo and user signature are png, jpg or gif.<br />
                                            *Maximum allowed file size of each file is 400KB.<br />
                                            *ID Proof and Address Proof documents accepted format is png, jpg, gif or pdf.<br />
                                        </asp:Panel>
                                        <cc1:CollapsiblePanelExtender ID="cpe" runat="Server"
                                            TargetControlID="panelInstructions"
                                            CollapsedSize="0"
                                            ExpandedSize="200"
                                            Collapsed="false"
                                            ExpandControlID="LinkButton1"
                                            CollapseControlID="LinkButton1"
                                            AutoCollapse="False"
                                            AutoExpand="False"
                                            ScrollContents="True"
                                            TextLabelID="Label1"
                                            CollapsedText="Show Details..."
                                            ExpandedText="Hide Details"
                                            ImageControlID="Image1"
                                            ExpandedImage="~/images/collapse.jpg"
                                            CollapsedImage="~/images/expand.jpg"
                                            ExpandDirection="Vertical" />

                                        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
                                            XPath="root/IDProof/ProofDocument"></asp:XmlDataSource>
                                        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
                                            XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>

                                    </div>
                                </div>
    </div>
    </div>
                        </div>
                    </div>
                </div>
</asp:Content>
