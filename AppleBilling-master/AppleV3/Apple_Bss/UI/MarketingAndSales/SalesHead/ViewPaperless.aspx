<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="ViewPaperless.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.ViewPaperless" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
	 .col-lg-8{
		 padding-top:10px;
	 }
	 @media print {
		#printpagebtn {
			display:none;
		 }
		.hide-from-printer {
			height: 20px;
		}
		.hide-prt{
			display:none;
		}
     }
	</style>

	  <script type="text/javascript">
        function printPage() {
			window.print();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="page-container">
        <div class="content-wrapper">

				<!-- Page header -->
				<div class="page-header page-header-default hide-from-printer">
					<div class="page-header-content">
						<div class="page-title">
							<h4><span class="text-semibold">SymBios Broadband Paperless Registration</span></h4>
						</div>
					</div>

					<%--<div class="breadcrumb-line">
						<ul class="breadcrumb">
							<li><a href="DefaultPaperless.aspx"><i class="icon-home2 position-left"></i> Home</a></li>
							<li class="active">Sales Head Home > View Subscriber Details</li>
						</ul>

						<ul class="breadcrumb-elements">
							
						</ul>
					</div>--%>
				</div>
			<div class="content" style="padding-bottom:5px;">

					
					<div class="row">
						<!-- <div class="col-lg-7"> -->

							<!-- Traffic sources -->
							<div class="panel panel-flat">
								
								 <div class="panel-heading">
                               
										<div class="heading-elements not-collapsible">
											<button type="button" id="printpagebtn" class="btn btn-default btn-xs heading-btn" onclick="printPage()"><i class="icon-printer position-left" ></i> Save / Print</button>
                            
										</div>
							    </div>
								<%--<div class="panel-heading" style="padding-bottom:0px;">
									<h5 class="panel-title "><legend class="text-bold">Edit Subscriber Details</legend></h5>
									<asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
									<asp:Label ID="_lblSuccess" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
									<asp:Label ID="_lblMsg" runat="server"></asp:Label>
									</div>--%>
								<div class="container-fluid">
									
									<div class="panel-body" style="padding:5px; padding-left:20px; border-bottom:0px;">
										  
										<div class="row" style="display:none;">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">CAF Number:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
												<asp:Label ID="lblcafnumber" runat="server" Text=""></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Customer Name:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblCustomername" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-prt" style="padding-top:10px;">
													<%--<label style="padding-left:10px; ">User Photo:</label>--%>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<%--<asp:Label ID="lbluserphoto" runat="server" Text=""></asp:Label>--%>
													<asp:Image ID="ImageUser" Height="60px" runat="server" />
											</div>
										</div>

									     <div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Installation Address:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<%--<asp:TextBox ID="TextBox3" runat="server"
													 class="form-control" TextMode="MultiLine"></asp:TextBox>--%>
													<asp:Label ID="lblinstadd" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Corresspondence Address:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
												<asp:Label ID="lblcorradd" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
													<%--<asp:TextBox ID="TextBox4" runat="server"
													 class="form-control" TextMode="MultiLine"></asp:TextBox>--%>
											</div>
										</div>
										
										<%--<div class="row">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">Landline Number:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
												<asp:Label ID="lbllandnum" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
													<asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
											</div>
										</div>--%>
										
										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Mobile No. / Alternate No.:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
												        <asp:Label ID="lblmobnum" runat="server" Text="" ForeColor="#0066FF"></asp:Label> / 
												        <asp:Label ID="lblaltmobnum" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
													<%--<asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>--%>
											</div>
										</div>


										<%-- <div class="row">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">Alternate Mobile Number:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblaltmobnum" runat="server" Text=""></asp:Label>
											</div>
										</div>--%>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Email ID:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblemail" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Bill Plan:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblbillplan" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Rental Payment Mode:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblpaymode" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<%--<div class="row">
											<div class="col-lg-3" style="padding-top:10px;">
													<label style="padding-left:10px; ">Subscription Plan</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblsubsplan" runat="server" Text=""></asp:Label>
											</div>
										</div>--%>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Installation Connection Type:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblinstconnecttype" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">User GSTIN:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblgstn" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">ID Proof Type:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblidprooftype" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Installation Address Proof Type:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblinstaddprooftype" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row" style="padding-top:10px;">
														<div class="col-lg-3 hide-prt">
															
														</div>
														<div class="col-lg-8" style="margin-left:10px;">    
																The undersigned agrees to the <a href="https://symbiosbroadband.net/terms-conditions/" target="_blank">terms and conditions</a> for the purpose of the broadband connection.
														</div>
										 </div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Signature:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<%--<asp:Label ID="lblsign" runat="server" Text=""></asp:Label>--%>
												    <asp:Image ID="ImageSign" Height="60px" runat="server" />
											</div>
										</div>

                                        <div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">CEF No.</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lblCafNumberNew" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>

										<div class="row">
											<div class="col-lg-3 hide-from-printer" style="padding-top:10px;">
													<label style="padding-left:10px; ">Dated:</label>      
											</div>
											<div class="col-lg-8" style="margin-left:10px;">    
													<asp:Label ID="lbldate" runat="server" Text="" ForeColor="#0066FF"></asp:Label>
											</div>
										</div>
										 
										 <%--<div class="row" style="padding-top:20px;">
														<div class="col-lg-3 hide-prt">
															
														</div>
														<div class="col-lg-8" style="padding-bottom:20px; margin-left:10px;">    
																The undersigned agrees to the <a href="https://symbiosbroadband.net/terms-conditions/" target="_blank">terms and conditions</a> for the purpose of the broadband connection.
														</div>
										 </div>--%>
								</div>
								
								</div>
           
								
						

						
					</div>
				


					


				

				</div>
				<!-- /content area -->

			</div>

			</div>
		    
		</div>
</asp:Content>
