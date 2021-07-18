<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideMenu.ascx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.CustomarCare.SideMenu" %>
<link rel="stylesheet" type="text/css" href="../Menu/ddlevelsmenu-base.css" />
<link id="Link1" rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link2" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />



<div class="container">
        <ul id="nav">

                 


            <li><a href="Default.aspx">
                <img id="Img1" runat="server" src="~/menuwithicons/images/home.png" />
                Home</a></li>

              <li><a href="ClientSearchView.aspx">
                <img id="Img11" runat="server" src="~/menuwithicons/images/user1.png" />Client Search View</a></li> 

            <li><a href="ServiceRequestsFixedList.aspx"><span>
                <img id="Img2" runat="server" src="~/menuwithicons/images/srfix.png" />SR Fixed List</span></a></li>
       
            <li><a href="#">
                <img id="Img12" runat="server" src="~/menuwithicons/images/paycollection.png" />Payment Collection</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="CyclePayment.aspx">
                                <img id="Img13" runat="server" src="~/menuwithicons/images/rightarrow.png" />Cycle Payment</a></li>
                            <li><a href="ExDataTransferPayment.aspx">
                                <img id="Img14" runat="server" src="~/menuwithicons/images/rightarrow.png" />Extra D.T Payment</a></li>

                                 <li><a href="BroadbandSubscriberLedger.aspx">
                <img id="Img9" runat="server" src="~/menuwithicons/images/rightarrow.png" />Subscriber Ledger</a></li>
                            
                        </ul>
                    </div>
                </div>
            </li>
            
            <li><a href="#">
                <img id="Img16" runat="server" src="~/menuwithicons/images/dark.png" />BroadBand Subscriber</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="ConnectionShifting.aspx">
                                <img id="Img17" runat="server" src="~/menuwithicons/images/rightarrow.png" />Connection Shifting</a></li>
                                <li><a href="UpdateSubscriberDetails.aspx">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />Update Subscriber Details</a></li>
                              <li><a href="UpdateUserPOPDetails.aspx">
                                <img id="Img15" runat="server" src="~/menuwithicons/images/rightarrow.png" />Update User POP Details</a></li>
                                <li><a href="UploadSubscriberFiles.aspx">
                                <img id="Img4" runat="server" src="~/menuwithicons/images/rightarrow.png" />Update All Documents </a></li>

                                          <li><a href="UploadSubscriberFilesOnebyOne.aspx">
                                <img id="Img8" runat="server" src="~/menuwithicons/images/rightarrow.png" />Update a Document </a></li>
                            <!--new addition Akum-->
                            <li><a href="BroadbandUsersDocuments.aspx">
                                <img id="Img10" runat="server" src="~/menuwithicons/images/rightarrow.png" />Users Documents </a></li>
                        </ul>
    </div>
    </div> 
    </li>

        <li><a href="#">
                <img id="Img18" runat="server" src="~/menuwithicons/images/disconnection.png" />Disconnection</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="TemporaryDisconnection.aspx">
                                <img id="Img19" runat="server" src="~/menuwithicons/images/rightarrow.png" />Temporary Disconnection</a></li>
                            <li><a href="PermanentDisconnection.aspx">
                                <img id="Img20" runat="server" src="~/menuwithicons/images/rightarrow.png" />Permanent Disconnection</a></li>
                                </ul>
                    </div>
                </div>
            </li>

  

              
                              <li><a href="#">
                <img id="Img5" runat="server" src="~/menuwithicons/images/report2.png" />Reports</a>

              <div class="subs">
                    <div class="col">
                        <ul>
            
                             <li><a href="Rep_ViewServiceRequests.aspx">
                                <img id="Img21" runat="server" src="~/menuwithicons/images/rightarrow.png" />Service Requests Report</a></li>
                            <li><a href="CollectionReportDayWise.aspx">
                                <img id="Img6" runat="server" src="~/menuwithicons/images/rightarrow.png" />Daily Collection Report</a></li>
                              <li><a href="CollectionReport.aspx">
                                <img id="Img7" runat="server" src="~/menuwithicons/images/rightarrow.png" />Collection Report</a></li>
                  
                        </ul>
                    </div>
                </div>
            </li>

         <li style="padding-right: 450px;">

              
                &nbsp;
      </li>
    
     </ul> </div>