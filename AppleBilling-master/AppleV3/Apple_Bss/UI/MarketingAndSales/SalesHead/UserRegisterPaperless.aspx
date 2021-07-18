 <%@ Page Title="User Register Paperless" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="UserRegisterPaperless.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.UserRegistrationQuick" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	
	<script src="../../../Stylesheet2020/ThemeJS/jquery-ui.min.js"></script>

  <script>
      $(function () {
          $("#<%= _tbRegistrationDate.ClientID  %>").datepicker({
              dateFormat: "dd-mm-yy",
              minDate: 0,
              maxDate: '+3m',
              yearRange: "1900:2050"
          });
      });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="page-container">
        <div class="content-wrapper">

				<!-- Page header -->
				<div class="page-header page-header-default">
					<div class="page-header-content">
						<div class="page-title">
							<h5><span class="text-semibold">Broadband Subscriber Registration</span></h5>
						</div>
					</div>

					<div class="breadcrumb-line">
						<ul class="breadcrumb">
							<li><a href="DefaultPaperless.aspx"><i class="icon-home2 position-left"></i> Home</a></li>
							<li class="active"> Register Applicant</li>
						</ul>

						<ul class="breadcrumb-elements">
							
						</ul>
					</div>
				</div>

			<div class="content">

					<!-- Main charts -->
					<div class="row">
						<!-- <div class="col-lg-7"> -->

							<!-- Traffic sources -->
							<div class="panel panel-flat">
							
								<%--<div class="panel-heading">
									<h5 class="panel-title "><legend class="text-bold">Customer Information</legend></h5>
									<asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
								--%>
								

								<asp:Label ID="_lblStatus" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"> </asp:Label>
								    <div class="container-fluid">
									
									
									    <div class="panel-body" style="padding-bottom:0px;">
										
										    <div class="form-group" style="display:none;" >
                                                <label class="control-label-required col-lg-3" style="padding-top:10px;">CAF Number:</label>
										
                                                 <div class="col-lg-9" style="margin-top:10px;">	
                                                <input type="text" class="form-control" placeholder="Enter CAF Number" ID="tbCAFNumber" readonly="readonly" runat="server">
                                                     </div>
											    </div>
											    <div class="form-group">
												    <label class="control-label-required col-lg-3" style="padding-top:10px;">Customer Name:</label>
												    <div class="col-lg-9" style="margin-top:10px;">													
													    <input type="text" class="form-control" placeholder="Enter Customer Name" ID="_tbCustomerName" runat="server">
													    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="_tbCustomerName"
                                                        Display="Dynamic" ErrorMessage="Customer name required" ForeColor="red"></asp:RequiredFieldValidator>
												    </div>
											    </div>
													
											    <div class="form-group">
												    <label class="control-label col-lg-3" style="padding-top:10px;">ID Proof:</label>
												
												    <div class="col-lg-9">
													    <div class="form-group" style="margin-top:10px;">
														    <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
															    <ContentTemplate>--%>
																<asp:DropDownList ID="_ddlIDProof" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_ddlIDProof_SelectedIndexChanged" cssclass="select-search">
																	<asp:ListItem Value="" Text="-- select --"></asp:ListItem>
																	<asp:ListItem Value="Aadhaar" Text="Aadhaar"></asp:ListItem>
																	<asp:ListItem Value="Bank Pass Book" Text="Bank Pass Book(with photo)"></asp:ListItem>
																	<asp:ListItem Value="Driving License" Text="Driving License(with photo)"></asp:ListItem>
																	<asp:ListItem Value="Govt. Employee ID Card" Text="Govt. Employee ID Card"></asp:ListItem>
																	<asp:ListItem Value="PAN Card" Text="PAN Card"></asp:ListItem>
																	<asp:ListItem Value="Passport" Text="Passport"></asp:ListItem>
																	<asp:ListItem Value="Student ID Card" Text="Student ID Card(for students)"></asp:ListItem>
																	<asp:ListItem Value="Voter ID Card" Text="Voter ID Card"></asp:ListItem>
																	<asp:ListItem Value="O" Text="Other (please specify)"></asp:ListItem>
																</asp:DropDownList> <br />
																<asp:TextBox ID="_tbotherIDProof" runat="server" class="form-control" Visible="False" OnTextChanged="_tbotherIDProof_TextChanged"></asp:TextBox>
																<asp:RequiredFieldValidator ID="_rfvIDProof" runat="server" ControlToValidate="_ddlIDProof"
																	Display="Dynamic" ErrorMessage="ID proof required" ForeColor="red"></asp:RequiredFieldValidator>
															   <%-- </ContentTemplate>
															    <Triggers>
																    <asp:AsyncPostBackTrigger ControlID="_ddlIDProof" />
															    </Triggers>
														    </asp:UpdatePanel>--%>
													    </div>
												</div>
											</div>


							               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
								            <ContentTemplate>--%>
											<div class="form-group" style="padding-top:10px;">
												
												<label class="control-label col-lg-3" style="padding-top:10px;">Installation Address:</label>
												<div class="col-lg-9" style="margin-top:10px;">
													 <asp:TextBox ID="_tbInstallationAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="2" TextMode="MultiLine" CssClass="form-control" 
                                                    Height="35px"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_tbInstallationAddress"
                                                    Display="Dynamic" ErrorMessage="Installation address required" ForeColor="red"></asp:RequiredFieldValidator>
												</div>
											</div>

											<div class="form-group" style="padding-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Installation Address Proof:</label>
												<div class="col-lg-9">
													<asp:DropDownList ID="_ddlAddressProof" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddlAddressProof_SelectedIndexChanged" CssClass="select-search" Height="22px">
														<asp:ListItem Value="" Text="-- select --"></asp:ListItem>
																	<asp:ListItem Value="Aadhaar" Text="Aadhaar"></asp:ListItem>
																	<asp:ListItem Value="Bank Pass Book" Text="Bank Pass Book(with photo)"></asp:ListItem>
																	<asp:ListItem Value="Driving License" Text="Driving License(with photo)"></asp:ListItem>
																	<asp:ListItem Value="Govt. Employee ID Card" Text="Govt. Employee ID Card"></asp:ListItem>
																	<asp:ListItem Value="PAN Card" Text="PAN Card"></asp:ListItem>
																	<asp:ListItem Value="Passport" Text="Passport"></asp:ListItem>
																	<asp:ListItem Value="Student ID Card" Text="Student ID Card(for students)"></asp:ListItem>
																	<asp:ListItem Value="Voter ID Card" Text="Voter ID Card"></asp:ListItem>
																	<asp:ListItem Value="O" Text="Other (please specify)"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="_tbOtherAddrsProof" runat="server" Visible="False" OnTextChanged="_tbOtherAddrsProof_TextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="_rfvAddrsProof" runat="server" ControlToValidate="_ddlAddressProof"
                                                        Display="Dynamic" ErrorMessage="Address proof required" ForeColor="red"></asp:RequiredFieldValidator>
												</div>
											</div>

											<div class="form-group" style="padding-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;" >Correspondence Address:</label>
												<div class="col-lg-9">
													 <asp:TextBox ID="_tbCorrespondenceAddress" runat="server" Font-Names="Arial" MaxLength="50"
                                                    Rows="3" TextMode="MultiLine" CssClass="form-control"  AutoPostBack ="true"
                                                    Height="35px"></asp:TextBox><br />
                                                    <asp:CheckBox ID="_chkSameAddress" runat="server" AutoPostBack="True" OnCheckedChanged="_chkSameAddress_CheckedChanged"
                                                    Text="Same as installation address" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_tbCorrespondenceAddress"
                                                    Display="Dynamic" ErrorMessage="Correspondence address required" ForeColor="red"></asp:RequiredFieldValidator>
												</div>
											</div>

								 <%--   </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="_chkSameAddress" />
                                    <asp:AsyncPostBackTrigger ControlID="_ddlAddressProof" />
                                    <asp:AsyncPostBackTrigger ControlID="_tbOtherAddrsProof" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
										<div class="form-group" style="padding-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Email ID:</label>
												<div class="col-lg-9" style="padding-top:10px;">
													  <asp:TextBox ID="_tbEmailID" runat="server" AutoCompleteType="FirstName" Height="18px"
														MaxLength="50" CssClass="form-control"></asp:TextBox>
														&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="_tbEmailID"
														Display="Dynamic" ErrorMessage="Email ID required" ForeColor="red"></asp:RequiredFieldValidator>
														&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
														ControlToValidate="_tbEmailID" Display="Dynamic" ErrorMessage="Invalid Email ID"
														ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
												</div>
											</div>
											

										  <div class="form-group" style="padding-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Mobile Number:</label>
												<div class="col-lg-3" style="margin-top:15px;">
													<asp:TextBox ID="_tbMobileNumber" runat="server" Height="18px" MaxLength="12" 
												      CssClass="form-control"></asp:TextBox>
													<%--<cc1:FilteredTextBoxExtender ID="_tbMobileNumber_FilteredTextBoxExtender" runat="server"
													Enabled="True" FilterType="Numbers" TargetControlID="_tbMobileNumber">
													</cc1:FilteredTextBoxExtender>--%>
													&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_tbMobileNumber"
													Display="Dynamic" ErrorMessage="Mobile number required" ForeColor="red"></asp:RequiredFieldValidator>
												</div>
													
											   </div>
											
										      <div class="form-group" style="padding-top:10px;">
											
												<label class="control-label-required col-lg-3" style="padding-top:10px;">Alternative Mobile Number:</label>
												<div class="col-lg-3" style="margin-top:10px;">	
													 <asp:TextBox ID="_tbAltMobileNumber" runat="server" AutoCompleteType="FirstName"
													 Height="18px" MaxLength="12" CssClass="form-control"></asp:TextBox>
													<%-- <cc1:FilteredTextBoxExtender ID="_tbAltMobileNumber_FilteredTextBoxExtender" runat="server"
													 Enabled="True" FilterType="Numbers" TargetControlID="_tbAltMobileNumber">
													 </cc1:FilteredTextBoxExtender>--%>
												</div>
                                            </div>


									</div>	
								

								
									<div class="panel-default" style="margin-left:20px;">
											 <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
											 <ContentTemplate>	--%>																			
											<div class="form-group" style="margin-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Bill Plan:</label>
												
												<div class="col-lg-9">
													<asp:DropDownList ID="_ddlBillPlan" runat="server" 
                                                     CssClass="select-search">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlCableOperator0" runat="server" ControlToValidate="_ddlBillPlan" Enabled="true" ErrorMessage="*" ForeColor="red" Text="Bill Plan required"></asp:RequiredFieldValidator>
												</div>
											</div>

											<div class="form-group" style="margin-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Rental Payment Mode:</label>
												
												<div class="col-lg-9">
													  <asp:DropDownList ID="_ddlPaymentMode" runat="server"
                                                    CssClass="select-search">
                                                    <asp:ListItem Selected="True" Value="M">MONTHLY</asp:ListItem>
                                                   <asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                                    <asp:ListItem Value="H">HALF-YEARLY</asp:ListItem>
                                                    <asp:ListItem Value="A">ANNUALY</asp:ListItem>
                                                </asp:DropDownList>
												</div>
											</div>

												<%-- <div class="row">
														<div class="col-lg-3" style="padding-right:10px;">
															<label class="control-label col-lg-8" style="padding-top:10px;">Rental Payment Mode:</label> 
														</div>
														<div class="col-lg-9" style="margin-left: 10px; margin-right: 10px;">    
																 <asp:DropDownList ID="_ddlPaymentMode" runat="server"
                                                    class="select-search">
                                                    <asp:ListItem Selected="True" Value="M">MONTHLY</asp:ListItem>
													<asp:ListItem Value="Q">QUARTERLY</asp:ListItem>
                                                    <asp:ListItem Value="H">HALF-YEARLY</asp:ListItem>
                                                    <asp:ListItem Value="A">ANNUALY</asp:ListItem>
                                                </asp:DropDownList>
														</div>
										        </div>--%>

											<div class="form-group" style="margin-top:10px;">
												<asp:Label ID="_lblOTRCPaymentMode" runat="server" Enabled="False" Text="Subscription Plan" CssClass="control-label col-lg-3" style="padding-top:10px;">
                                                </asp:Label>
												<div class="col-lg-9">
													 <asp:DropDownList ID="_ddlRegOTRCPlan" runat="server" Width="500px" 
                                                    CssClass="select-search" Height="22px">
                                                </asp:DropDownList>
												</div>
											</div>


								<%--<asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>--%>
											<div class="form-group" style="padding-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">Installation Connection Type:</label>
												<div class="col-lg-9" style="padding-top:10px;">
													 <asp:CheckBox ID="ChkBoxResidential"  Text="Residential" runat="server" Checked="true" oncheckedchanged="ChkBoxResidential_CheckChanged" />    

                                                  <%--<cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender5" 
                                                      runat="server" Enabled="True" Key="5" TargetControlID="ChkBoxResidential">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>--%>
												  <asp:CheckBox ID="ChkBoxCommercial" Text="Commercial" runat="server"  oncheckedchanged="ChkBoxCommercial_CheckChanged"/> 
                                                 <%-- <cc1:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender6" 
                                                      runat="server" Enabled="True" Key="5" 
                                                      TargetControlID="ChkBoxCommercial">
                                                  </cc1:MutuallyExclusiveCheckBoxExtender>--%>
												</div>
											</div>


								
											<div class="form-group" style="margin-top:10px;">
												<label class="control-label col-lg-3" style="padding-top:10px;">User GSTIN</label>
												<div class="col-lg-9">
													<%--<input type="text" class="form-group" placeholder="GSTIN">--%>
													
													 <asp:TextBox ID="_txtUserGSTIN" runat="server" class="form-control"></asp:TextBox>
                                               
                                                    <%--<asp:CheckBox ID="Chkgst" runat="server" Text="GSTIN not provided" OnCheckedChanged="Chkgst_CheckedChanged" AutoPostBack="true" />
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Required GSTIN" ControlToValidate="_txtUserGSTIN"></asp:RequiredFieldValidator>--%>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="_txtUserGSTIN" ErrorMessage="Please Enter a valid Gst number" ValidationExpression="^([0]{1}[1-9]{1}|[1-2]{1}[0-9]{1}|[3]{1}[0-7]{1})([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})+$"></asp:RegularExpressionValidator>
													
												</div>
											</div>
											<div class="form-group" style="display:none;">
												<label class="control-label col-lg-2" style="padding-top:10px;">Date of Registration</label>
													<div class="col-lg-4">
													<asp:TextBox ID="_tbRegistrationDate" runat="server" BackColor="#F6F6F6" 
													class="form-control"></asp:TextBox>
													<%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"
													TargetControlID="_tbRegistrationDate" DaysModeTitleFormat="MMMM,yyyy"  
													Format="dd-MM-yyyy">
													</cc1:CalendarExtender>--%>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="_tbRegistrationDate"
													ErrorMessage="Select registration date" ForeColor="red"></asp:RequiredFieldValidator>
												</div>
											</div>

												<%--<div class="col-lg-7">
												<div class ="col-lg-3" style="margin-top: 20px;">
												<asp:Button ID="_btnRegister" style="margin-left:230px;" runat="server" CssClass="btn btn-primary" OnClick="_btnRegister_Click" Text="Submit" OnClientClick="javascript:window.scrollTo(0, 0);" />
													

									   <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
													XPath="root/IDProof/ProofDocument" OnTransforming="XmlDataSource1_Transforming" ></asp:XmlDataSource>
												<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
													XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>
											</div>
													</div>--%>
									

									<div class="row" style="padding-top:20px;">
														<div class="col-lg-3">
															
														</div>
														<div class="col-lg-9">
															<asp:CheckBox ID="Chktnc" runat="server" AutoPostBack="true" />
															Applicant is made aware & agrees to the <a href="https://symbiosbroadband.net/terms-conditions/" target="_blank"> terms & conditions </a> for the purpose of the broadband connection.<br />
													    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Required" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
														</div>
										         </div>
												<div class="row" style="padding-top:20px;">
														<div class="col-lg-3">
															
														</div>
														<div class="col-lg-9" style="padding-bottom:20px;">    
																<asp:Button ID="_btnRegister" runat="server" CssClass="btn btn-primary" OnClick="_btnRegister_Click" Text="Submit" OnClientClick="javascript:window.scrollTo(0, 0);" CausesValidation=true />
													

												                 <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/data.xml"
																 XPath="root/IDProof/ProofDocument" OnTransforming="XmlDataSource1_Transforming" ></asp:XmlDataSource>
															     <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/App_Data/data.xml"
																 XPath="root/AddressProof/ProofDocument"></asp:XmlDataSource>
														</div>
										         </div>
											</div>
												<%--</ContentTemplate>
											</asp:UpdatePanel>
									  </ContentTemplate>
                                 <Triggers>
                                       <asp:AsyncPostBackTrigger ControlID="Chkgst" />
                                 </Triggers>
                            </asp:UpdatePanel>--%>
									</div>	
								</div>
									</div>
								
							    </div>
					

						<!-- </div> -->

						
					</div>
					<!-- /main charts -->


					


					<!-- Footer -->
					<div class="footer text-muted">
						
					</div>
					<!-- /footer -->

				</div>
				<!-- /content area -->

			</div>
			</div>
			
		</div>
</asp:Content>
