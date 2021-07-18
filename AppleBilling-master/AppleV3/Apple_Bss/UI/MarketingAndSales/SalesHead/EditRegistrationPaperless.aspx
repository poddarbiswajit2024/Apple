<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="EditRegistrationQuick.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.EditRegistrationQuick" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <div class="content-wrapper">

				<!-- Page header -->
				<div class="page-header page-header-default">
					<div class="page-header-content">
						<div class="page-title">
							<h4><span class="text-semibold">Edit Registered User</span></h4>
						</div>
					</div>

					<div class="breadcrumb-line">
						<ul class="breadcrumb">
							<li><a href="index.html"><i class="icon-home2 position-left"></i> Home</a></li>
							<li class="active">Sales Head Home > Edit Subscriber Details</li>
						</ul>

						<ul class="breadcrumb-elements">
							
						</ul>
					</div>
				</div>
			<div class="content" style="padding-bottom:5px;">

					
					<div class="row">
						<!-- <div class="col-lg-7"> -->

							<!-- Traffic sources -->
							<div class="panel panel-flat">
							
								<div class="panel-heading" style="padding-bottom:0px;">
									<h5 class="panel-title "><legend class="text-bold">Edit Subscriber Details</legend></h5>
									<asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
									<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
									<asp:Label ID="_lblMsg" runat="server"></asp:Label>
									</div>
								<div class="container-fluid">
									
									<div class="panel-body" style="padding:5px; padding-left:20px; border-bottom:0px;">
										   <div class="form-group" style="margin-bottom:0px; display:none;">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">CAF Number:</label>
												<div class="col-lg-8" style="margin-top:10px;">													
													<asp:TextBox ID="tbCAFNumber" runat="server" MaxLength="12"
													class="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbCAFNumber"
													Display="Dynamic" ErrorMessage="CAF number required" ForeColor="#0066FF"></asp:RequiredFieldValidator>
												</div>
											</div>

									      <div class="form-group" style="margin-bottom:0px;">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Customer Name:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbCustomerName" runat="server" class="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
													ControlToValidate="_tbCustomerName"
													ErrorMessage="* customer Name field cannot be left empty"></asp:RequiredFieldValidator>
												</div>
											</div>

										 <div class="form-group">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Installation Address:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbInstallationAddress" runat="server"
													 class="form-control" TextMode="MultiLine"></asp:TextBox>
												    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
													ControlToValidate="_tbInstallationAddress"
													ErrorMessage="* Installation Address required"></asp:RequiredFieldValidator>
												</div>
											</div>

										 <div class="form-group">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Corresspondence Address:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbCorresspondenceAddress" runat="server"
													class="form-control" TextMode="MultiLine"></asp:TextBox>
												    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
													ControlToValidate="_tbCorresspondenceAddress"
													ErrorMessage="* Correspondence Address required"></asp:RequiredFieldValidator>
												</div>
											</div>

										 <div class="form-group">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Alternative Number:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbAltNumber" runat="server" class="form-control"></asp:TextBox>
												</div>
											</div>

										 <div class="form-group">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Mobile Number:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbMobileNumber" runat="server" class="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
													ControlToValidate="_tbMobileNumber" ErrorMessage="* Mobile Number Required"></asp:RequiredFieldValidator>
												</div>
										</div>

										 <div class="form-group">
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Email ID:</label>
												<div class="col-lg-8">													
													<asp:TextBox ID="_tbEmailID" runat="server" class="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
													ControlToValidate="_tbEmailID" ErrorMessage="* Email Required"></asp:RequiredFieldValidator>
												    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
													ControlToValidate="_tbEmailID" ErrorMessage="* Invalid email ID"
													ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
												</div>
											</div>

										<%--<div class="col-lg-7">
												<div class ="col-lg-3" style="margin-top: 10px;">
												<asp:Button ID="_imgBtnCustDetailUpdate" style="margin-left:240px; margin-bottom:20px;" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="_imgBtnCustDetailUpdate_Click" />
												</div>
										</div>--%>
										 <div class="row" style="padding-top:20px;">
														<div class="col-lg-3">
															
														</div>
														<div class="col-lg-9" style="padding-bottom:20px;">    
																<asp:Button ID="_imgBtnCustDetailUpdate" style="margin-bottom:20px;" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="_imgBtnCustDetailUpdate_Click" />
														</div>
										 </div>
								</div>
								
								</div>
           
								
						

						
					</div>
				


					


				

				</div>
				<!-- /content area -->

			</div>

			
			<div class="content">

					
					<div class="row">
						<!-- <div class="col-lg-7"> -->
						
							<!-- Traffic sources -->
							<div class="panel panel-flat">
							
								<div class="panel-heading" style="padding-bottom:0px;">
									<h5 class="panel-title "><legend class="text-bold">Edit Bill Plan Details</legend></h5>
									<asp:Label ID="lblupdatebillmsg" runat="server" Font-Bold="True"
									ForeColor="#009933"></asp:Label>
									<%--<asp:Label ID="_lblBillPlanInfo" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>--%>
									
									</div>
								
								<div class="container-fluid">
									<div class="content-wrapper" style="padding-left:50px;padding-bottom:25px;">
                                            <asp:Label ID="_lblBillPlanInfo" runat="server"></asp:Label>
										
                                      </div>
                                     
									
									<div class="panel-body" style="padding:0px; padding-left:20px; border-bottom:0px;">

                                        
										

									<%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>--%>

										<div class="row">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">Bill Plan:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:DropDownList ID="_ddlBillPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddlBillPlan_SelectedIndexChanged" CssClass="select-search" >
													</asp:DropDownList>
											</div>
										</div>
												
										<div class="row">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">Rental Payment Mode:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:DropDownList ID="_ddlPaymentMode" runat="server"
																	CssClass="select-search" style="padding-left:10px; ">
																	<asp:ListItem Selected="True" Value="M">MONTHLY
    																		

																	</asp:ListItem>
																	<asp:ListItem Value="Q">QUARTERLY
    																		

																	</asp:ListItem>
																	<asp:ListItem Value="H">HALF-YEARLY
    																		

																	</asp:ListItem>
																	<asp:ListItem Value="A">ANNUALY
    																		

																	</asp:ListItem>
																</asp:DropDownList>
											</div>
										</div>
											
										<div class="row">
												<div class="col-lg-3">
													<asp:Label ID="_lblOTRCPaymentMode" runat="server" Enabled="False" Text="OTRC Payment Mode" style="padding-left:10px; padding-top:10px; font-weight:normal;"> </asp:Label>    
												</div>
												<div class="col-lg-8" style="margin-left:10px;">    
														<asp:DropDownList ID="_ddlRegOTRCPlan" runat="server"
																CssClass="select-search" style="padding-left:10px; " OnSelectedIndexChanged="_ddlRegOTRCPlan_SelectedIndexChanged">
															</asp:DropDownList>
												</div>
										</div>

								<%--		<asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
											 <ContentTemplate>--%>

												<div class="row">
														<div class="col-lg-3">
															<label class="control-label-required col-lg-10" style="padding-top:10px;">Installation Connection Type:</label> 
														</div>
														<div class="col-lg-8" style="padding-top:10px; margin-left:10px;">    
																<asp:CheckBox ID="ResidentialCheckBox" AutoPostBack="true" Text="Residential" runat="server" oncheckedchanged="chkboxResidential_CheckedChanged" />

															<asp:CheckBox ID="CommercialCheckBox" AutoPostBack="true" Text="Commercial" runat="server" oncheckedchanged="chkboxCommercial_CheckedChanged"/><br />
															<asp:Label ID="InstallationConnectionType" runat="server" Text=""></asp:Label>
														</div>
										        </div>
											`
												<div class="row">
														<div class="col-lg-3">
															<label class="control-label-required col-lg-6" style="padding-top:10px;">User GSTIN:</label> 
														</div>
														<div class="col-lg-8" style="margin-left:10px;">    
																<asp:TextBox ID="_txtUserGSTIN" class="form-control" runat="server" ></asp:TextBox>
														</div>
										        </div>
												
												 <div class="row" style="padding-top:20px;">
														<div class="col-lg-3">
															
														</div>
														<div class="col-lg-9" style="padding-bottom:20px;">    
																<asp:Button ID="_imgBtnBillPlanUpdate" runat="server" CssClass="btn btn-primary" OnClick="_imgBtnBillPlanUpdate_Click" Text="Update" />
														</div>
										        </div>
												
							<%--			 </ContentTemplate>
									 </asp:UpdatePanel>
								</ContentTemplate>
						 </asp:UpdatePanel>--%>
								</div>
								
									
								</div>
           
								
						

						
					</div>
				


					


				

				</div>
				<!-- /content area -->

			</div>
			</div>
		    
		</div>
			
</asp:Content>
