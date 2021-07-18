<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MarketingAndSales/SalesHead/SalesMaster.Master" AutoEventWireup="true"
     CodeBehind="ManagePendingUserRegistrations2020.aspx.cs" Inherits="Apple_Bss.UI.MarketingAndSales.SalesHead.ManagePendingUserRegistrations2020" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

       	<!---This is for RS icon link-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .table-responsive th{
            font-size:13px;
            text-transform: capitalize;
             font-weight: 600;
        }
    </style>

      <%--<script type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.10.20/datatables.min.js"></script>--%>

           <%-- <script
			  src="https://code.jquery.com/jquery-3.4.1.js"
			  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU="
			  crossorigin="anonymous">
    </script>--%>

   <%--<script src="../../../Stylesheet2020/js/core/jquery-3.4.1.min.js"></script>--%>    	
    <script src="../../../Stylesheet2020/js/core/datatables.min.js"></script>

    <%--<script src="../../../Stylesheet2020/js/core/jquery-3.4.1.min.js"></script>--%>
    <script src="../../../Stylesheet2020/js/core/datatables.min.js"></script>

    <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/responsive.min.js"></script>
     <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/table_responsive.js"></script>
    <script src="../../../Stylesheet2020/js/plugins/tables/datatables/extensions/footable.min.js"></script>
    
     <script type="text/javascript">
           $(document).ready(function () {        
                $('#myTable').DataTable({
                columns: [
                { 'data': 'Registered Name' },
                { 'data': 'Email ID' },
                { 'data': 'Bill_Plan' },
                { 'data': 'Mobile Number' },
                {
                    'data': 'Uploaded Date',
                    "iDataSort": 5,
                },
                {
                    'data': 'Uploaded Date2',
                    "bVisible": false,
                },
                {
                    'data': 'Action',
                    'searchable': false,
                    'sortable': false,
                }
             ]
         });
      });
      </script>


    
	
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="panel panel-success">
        <div class="panel-heading">
            <h5 class="panel-title"> Manage Pending User Registrations</h5>
        </div>
     </div>
    

         <div class=" container-fluid table-responsive">
          <div class="table table-responsive">
               <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-togglable table-hover" id="myTable" style="width:100%" >
                                              <col style="width:12%">
	                                          <col style="width:18%">
	                                          <col style="width:23%">
                                             <col style="width:12%">
                                             <col style="width:13%">
                                             <col style="width:22%">

                                              <thead> 
                                                <tr>  
                                                    <th data-toggle="true">Registered Name </th>            
                                                    <th data-hide="phone,tablet">Email ID</th>
                                                    <th data-hide="phone,tablet">Bill_Plan</th>
                                                    <th data-hide="phone">Mobile Number</th>
                                                    <th >Uploaded Date</th>
                                                    <th >Uploaded Date2</th>
                                                    <th data-hide="phone">Action</th>
                                                </tr> 
                                            </thead>  
                                        </HeaderTemplate>
                                        
                                         <ItemTemplate>               
                                                <tr>
                                                <td>
                                                    <asp:Label ID="Amount" runat="server" Text='<%# Eval("NAME") %>' />
                                                </td>                    
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EMAILID") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="dop" runat="server" Text='<%# Eval("BILLPLAN") %>' />
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MOBILENUMBER") %>' />
                                                </td>
                                                <td>
                                                     <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(Eval("MODON")).ToString("dd MMMM yyyy") %>' />
                                                </td>

                                                 <td>
                                                     <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToDateTime(Eval("MODON")).ToString("yyyy MMMM dd") %>' />
                                                </td>
                                               
                                                <td>
                                                     <a href='EditRegistration.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                     <img alt="Edit" title="edit" src="../../../Images/Buttons/edit.png" height="25" width="25" style="border: 0;float:left; display:inline" /></a>
                                                       &nbsp;&nbsp;
                                                            
                                                     <a href='UserRegistrationDocuments2020.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                      <img alt="Update documents" title="update documents" src="../../../Images/Buttons/documents.png"  height="25" width="25"  style="border: 0;float:left; display:inline" /></a>
                                                        &nbsp;&nbsp;
                                                       
                                                      <a href='UpdateUserRegistrationDocuments2020.aspx?id=<%#Eval("USERID").ToString()%>'>
                                                     <img alt="Update document one "  title="update document one by one" src="../../../Images/Buttons/doc-one.png"  height="25" width="25"  style="border: 0;float:left; display:inline" /></a>
                                                         &nbsp;&nbsp;
                                                   
                                                      <asp:ImageButton ID="ImageButton_Delete" runat="server" AlternateText="Delete" style="border: 0;float:left; display:inline"  CausesValidation="false"
                                                       CommandArgument='<%# Eval("USERID") %>' CommandName="Delete" ImageUrl="~/Images/Buttons/delete.png"
                                                      OnClientClick="javascript:return confirm('This user will be permanently deleted.Are you sure?')"
                                                      ToolTip="Delete"  height="25" width="25" />
                                                </td>
                                            </tr>                  
                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                
        </asp:Repeater>
       </div>
   
   </div>
    
</asp:Content>
