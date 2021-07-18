<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="DefaultPaperless.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.HomeQuick" %>
<%@ Register src="../../../UserControl/LoggedActivityPaperless.ascx" tagname="LoggedActivity" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../../../CSS/InetBill.css" rel="stylesheet" type="text/css">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <div class="content-wrapper">
           
            <div class="page-header page-header-default">
					<div class="page-header-content">
						<div class="page-title">
							<h4><span class="text-semibold">Home</span></h4>
						</div>
					</div>

					<div class="breadcrumb-line">
						<ul class="breadcrumb">
							<li><a href="Default.aspx"><i class="icon-home2 position-left"></i> Home</a></li>
							<li class="active">Sales Head Home</li>
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
							
								<%--<div class="panel-heading" style="padding-bottom:0px;">
									<h5 class="panel-title "><legend class="text-bold">Edit Subscriber Details</legend></h5>
									</div>--%>
								<div class="container-fluid" style="padding:0px;">
									
									<%--<div class="panel-body" style="padding:5px; padding-left:20px; border-bottom:0px;">--%>
										

									  <%--<div class="row" style="vertical-align: top;">--%>
												<%--<div class="col-lg-3" style="padding-top:40px;">
													 <img src="../../../Images/Pictures/marketing&sales.jpg" alt="" /> 
												</div>--%>
												<div class="col-lg-12" style="vertical-align:top; padding:0px;">    
														<uc1:LoggedActivity ID="LoggedActivityPaperless" runat="server" />
												</div>
										<%--</div>--%>

				
								<%--</div>--%>
								
								</div>
           
								
						

						
					</div>
				


					


				

				</div>
				<!-- /content area -->

			</div>

         </div>
     </div>


</asp:Content>
