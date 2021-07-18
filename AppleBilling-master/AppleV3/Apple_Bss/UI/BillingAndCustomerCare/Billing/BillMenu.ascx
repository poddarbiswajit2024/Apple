<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BillMenu.ascx.cs" Inherits="Apple_Bss.UI.BillingAndCustomerCare.Billing.BillMenu" %>



       <link rel="stylesheet" runat="server" href="~/menuwithicons/css/menu.css" type="text/css" media="screen" />
  <link id="Link1" rel="stylesheet"  href="../../../menuwithicons/css/menu.css" type="text/css" media="screen" />

<body>
    <div class="container">
        <ul id="nav">
            <li><a href="Default.aspx">
                <img runat="server" src="~/menuwithicons/images/home.png" />
                Home</a></li>
            <li><a href="#"><span>
                <img runat="server" src="~/menuwithicons/images/user1.png" />
                Broadband User</span></a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="BillToBeRaised.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Raise Bill</a></li>
                            <li><a href="BroadBandSubscriberLedgerView.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Subscriber Ledger</a></li>
                            <li><a href="BillPlanChange.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Bill Plan Change</a></li>
             <%--                   <li><a href="BillPlanChangeWithoutCharges.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Bill Plan Change no SD</a></li>--%>

                            <li><a href="PaymentCycleChange.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Change Payment Cycle</a></li>
                            <li><a href="ViewSubscriberBill.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />View Subscriber Bill</a></li>
                            <li><a href="SubscriberInfoDetails.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Subscriber List</a></li>
                        </ul>
                    </div>
                </div>
            </li>
            <li><a href="#"><span>
                <img runat="server" src="~/menuwithicons/images/payments.png" />
                Payments</span></a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="PostArrears.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Post Arrear</a></li>
                            <li><a href="PostWaivers.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Post Waiver</a></li>

                              <li><a href="OnlinePaymentsList.aspx">
                                <img id="Img9" runat="server" src="~/menuwithicons/images/rightarrow.png" />Online Payments List</a></li>
                                  <li><a href="OnlinePaymentCorrection.aspx">
                                <img id="Img8" runat="server" src="~/menuwithicons/images/rightarrow.png" />Online Payment Update</a></li>
                    </div>
                </div>
            </li>
            <li><a href="#">
                <img runat="server" src="~/menuwithicons/images/datatrasfer.png" />
                Data Transfers</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="ViewDataUsageDetails.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Data Usage Details</a></li>
                            <li><a href="ViewDTTFUploadDetails.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />Session Data Upload</a></li>
                            <li><a href="ViewUserSessionDetails.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />DTTF Search By Username</a></li>
                        </ul>
                    </div>
                </div>
            </li>
            
            <li><a href="#">
                <img runat="server" src="~/menuwithicons/images/dark.png" />
                Dark Fiber</a>
                <div class="subs">
                    <div class="col" >
                        <ul>
                            <li><a href="BillPaymentDarkFiber.aspx">
                                <img runat="server" src="~/menuwithicons/images/rightarrow.png" />DF Bill Payment</a></li>
                        </ul>
    </div>
    </div> 
    </li>
<%--        <li><a href="#">
                <img id="Img6" runat="server" src="~/menuwithicons/images/trafficplan.png" />
                Tariff Plans</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="DailyCollectionReport.aspx">
                                <img id="Img7" runat="server" src="~/menuwithicons/images/rightarrow.png" />Add Tariff Plan</a></li>
                            <li><a href="ArrearWaiverHistory.aspx">
                                <img id="Img8" runat="server" src="~/menuwithicons/images/rightarrow.png" />Manage Tariff Plans</a></li>
                                </ul>
                    </div>
                </div>
            </li>--%>
    <li><a href="#">
                <img id="Img1" runat="server" src="~/menuwithicons/images/report2.png" />
                Reports</a>
                <div class="subs">
                    <div class="col">
                        <ul>
                            <li><a href="CollectionReportDayWise.aspx">
                                <img id="Img2" runat="server" src="~/menuwithicons/images/rightarrow.png" />Daily Collection Report</a></li>
                              <li><a href="CollectionReport.aspx">
                                <img id="Img7" runat="server" src="~/menuwithicons/images/rightarrow.png" />Collection Report</a></li>
                            <li><a href="ArrearWaiverHistory.aspx">
                                <img id="Img3" runat="server" src="~/menuwithicons/images/rightarrow.png" />View History</a></li>
                            <li><a href="CSVFileUpload.aspx">
                                <img id="Img4" runat="server" src="~/menuwithicons/images/rightarrow.png" />Upload CSV File</a></li>
                            <li><a href="DisconnectedUsersView.aspx">
                                <img id="Img5" runat="server" src="~/menuwithicons/images/rightarrow.png" />Disconnected Users</a> </li>
                        </ul>
                    </div>
                </div>
            </li>
                 <li><a href="DisconnectionActivate.aspx">
                <img id="Img6" runat="server" src="~/menuwithicons/images/pending.png" />
                Activate User</a></li>
            
    
     <li style="padding-right: 450px;">
              
                &nbsp;
      </li>
    
     </ul> </div>
</body>
