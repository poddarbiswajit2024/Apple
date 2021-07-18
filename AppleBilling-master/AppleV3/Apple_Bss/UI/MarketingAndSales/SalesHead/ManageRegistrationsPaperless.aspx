<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true" CodeBehind="ManageRegistrationsPaperless.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.ManageRegistrationsPaperless" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    
     <script src="../../../Stylesheet2020/js/core/datatables.min.js"></script>   
    <script src="../../../Stylesheet2020/js/core/datatables.min.js"></script>
    <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/responsive.min.js"></script>
     <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/table_responsive.js"></script>
    <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/footable.min.js"></script>

  
    <script type="text/javascript">
        $(document).ready(function () {          
            $('#myTable').DataTable({
                "order": [],
                columns: [
                 
                   { 'data': 'Registered Name' },
                   { 'data': 'CEF Number' },
                   { 'data': 'Bill_Plan' },
                   { 'data': 'Mobile Number' },

                   {
                       'data': 'Uploaded Date',
                       "iDataSort": 7,
                   },
                  
                    
                    {
                        'data': 'View',
                        'searchable': false,
                        'sortable': false,
                    },
                   {
                       'data': 'Action',
                       'searchable': false,
                       'sortable': false,
                   },

                    {
                        'data': 'Uploaded Date2',
                        "bVisible": false,
                    }
               
                   ]
            
               
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
							<h4><span class="text-semibold">Manage Registrations</span></h4>
						</div>
					</div>

					<div class="breadcrumb-line">
						<ul class="breadcrumb">
							<li><a href="index.html"><i class="icon-home2 position-left"></i> Home</a></li>
							<li class="active">Sales Head Home > Manage Registrations</li>
						</ul>

						<ul class="breadcrumb-elements">
							
						</ul>
					</div>
				</div>
                <div class="content">
					
					<div class="row">
					
							<div class="panel panel-flat">
							
								<div class="panel-heading">						
									
								    <div class="container-fluid">
                                        <!-- repeater is used-->
                                         <div class="table-responsive">
                                            <div class="table table-responsive">
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                    <HeaderTemplate>
                                              
                                                        <table class="table table-responsive table-togglable table-hove " style="width:100%;" id="myTable">
                                                     

                                                          <thead> 
                                                            <tr>  
                                                                <th data-toggle="true">Name </th>            
                                                                <th data-hide="phone">CEF No. </th>            
                                     
                                                                <th data-hide="phone">Bill Plan</th>
                                                                <th data-hide="phone">Mobile</th>
                                                                <th style="max-width:20px;">Date</th>
                                                               
                                                                <th style="text-align:center; max-width:26px;">View</th>
                                                                <th data-hide="phone">Action</th>
                                                                 <th>Uploaded Date2</th>
                                                            </tr> 
                                                        </thead>  
                                                    </HeaderTemplate>                                        
                                                    <ItemTemplate>               
                                                        <tr>
                                                        <td>
                                                            <asp:Label ID="Amount" runat="server" Text='<%# Eval("NAME").ToString() %>' />
                                                        </td>   
                                                            
                                                     <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("cafnumber").ToString()%>' />
                                                        </td>                   
                                                  
                                                        <td>
                                                            <asp:Label ID="dop" runat="server" Text='<%# Eval("BILLPLAN") %>' />
                                                        </td>
                                                         <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("MOBILENUMBER") %>' />
                                                        </td>
                                                        <td>
                          
                                                            <asp:Label ID="Label3" runat="server" Text='<%#  Convert.ToDateTime(Eval("MODON")).ToString("dd MMM") %>' />
                                                        </td>

                                                       
                                               
                                                        
                                                        <td style="text-align:center;">
                                                              <a href='ViewPaperless.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                              <i class="icon-file-eye"></i></a>
                                                        </td>

                                                        <td >
                                                           
                                                             <a href='EditRegistrationPaperless.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                             <img alt="Edit" title="edit" src="../../../Images/Buttons/edit.png" height="20" width="20" style="border: 0;float:left; margin:3px;" /></a>
                                                           
                                                            
                                                             <a href='UserRegistrationDocumentsPaperless.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                              <img alt="Update documents" title="update documents" src="../../../Images/Buttons/documents.png"  height="20" width="20"  style="border: 0;float:left; margin:3px;" /></a>
                                                              
                                                       
                                                              <a href='UpdateUserRegistrationDocumentsPaperless.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                             
                                                                  <img alt="Update document one "  title="update document one by one" src="../../../Images/Buttons/doc-one.png"  height="20" width="20"  style="border: 0;float:left; margin:3px;" /></a>
                                                              
                                                            <asp:ImageButton ID="ImageButton_Delete" runat="server" AlternateText="Delete" style="border: 0;float:left; margin:3px;"  CausesValidation="false"
                                                               CommandArgument='<%# Eval("USERID") %>' CommandName="Delete" ImageUrl="~/Images/Buttons/delete.png"
                                                              OnClientClick="javascript:return confirm('This user will be permanently deleted.Are you sure?')"
                                                              ToolTip="Delete"  height="20" width="20" />
                                                        </td>

                                                          <td style="display:none;">
                                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("MODON2") %>' />
                                                        </td>
                                                    </tr>                  
                                                </ItemTemplate>
                                                 <FooterTemplate>
                                                </table>
                                                </FooterTemplate>
                
                                                </asp:Repeater>
                                               </div>   
                                           </div>

                                        <!-- after repeater is used-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
     
            </div>
         </div>
   
</asp:Content>
