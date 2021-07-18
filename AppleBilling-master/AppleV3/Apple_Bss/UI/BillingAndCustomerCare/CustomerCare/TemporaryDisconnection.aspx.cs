using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;
using System.IO;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class TemporaryDisconnection : System.Web.UI.Page
    {
        private static string scannedFormName = "";
        char statustoupdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();
            _txtUserID.Focus();
        }

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {
            
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                _lblFail.Visible = false;
                String pkgName = this.getBillPackageName();
                String payMode = this.GetPaymentMode();
                String status = String.Empty;
                try
                {
                    BroadbandSubscriberLedgers bbledger = new BroadbandSubscriberLedgers();
                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    _txtCustomerName.Text = buser.Name;
                    _txtOutStanding.Text = bbledger.GetTotalOutstanding(strUserID).ToString();
                    status = buser.Status;
                    _txtBillPlan.Text = pkgName.ToString();

                    //for Status
                    if (status == "A")
                    {
                        _txtStatus.Text = "ACTIVE";
                    }
                    else
                    {
                        _txtStatus.Text = "INACTIVE";
                        //_lblFail.Text = "Subscriber is already inactive and cannot be disconnected.";
                        //_btnTempDisconect.Visible = false;
                        //_lblFail.Visible = true;
                    }

                    //for Payment Mode
                    if (payMode == "M")
                    {
                        _txtPaymentMode.Text = "MONTHLY";
                    }
                    else if (payMode == "Q")
                    {
                        _txtPaymentMode.Text = "QUARTERLY";
                    }
                    else if (payMode == "H")
                    {
                        _txtPaymentMode.Text = "HALFYEARLY";
                    }
                    else if (payMode == "A")
                    {
                        _txtPaymentMode.Text = "YEARLY";
                    }
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
            else
            {
                _lblFail.Visible = true;
                _lblFail.Text = "Invalid User ID";
            }
        }
        #endregion

        #region Functionality to get the PAYMENT MODE

        private String GetPaymentMode()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String payMode = String.Empty;
            try
            {
                payMode = BroadbandUserBillingInfo.PaymentModeListing(strUserID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            return (payMode);
        }

        #endregion

        #region Funtionality to get PACKAGE NAME (BILLPLAN NAME)

        private String getBillPackageName()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String billID = String.Empty;
            String pkgName = String.Empty;
            try
            {
                BroadbandUserBillingInfo billInfo = new BroadbandUserBillingInfo(strUserID);
                billID = billInfo.BillPlanID;
                pkgName = BroadbandBillPlans.GetPackageName(billID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            return (pkgName);
        }

        #endregion


        private void SaveScannedTempDisconnectForm()
        {
          //  string fileextension=Path.GetExtension(FileUpload1.FileName);
          //  if (fileextension )
       
                //save it to server now
                string imagename = FileUpload1.FileName;
                string serverpath = DBConn.GetDisconnectFormPath();
                FileUpload1.PostedFile.SaveAs(Page.Server.MapPath(serverpath + imagename));
                //can resize according to original pic or a standard width one...going for second option now
                scannedFormName = ImageManage.ResizeAndSaveImage(imagename, "_optimized_tempdisconn", 550, serverpath);
               
            
        }

        //#region TEMPORARY DISCONNECTION with validation

        //protected void _btnTempDisconect_Click(object sender, ImageClickEventArgs e)
        //{
        //    //CultureInfo ci = new CultureInfo("en-GB");
        //    String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
           
        //        TempDisconnectionDetails tDisconnect = new TempDisconnectionDetails();
        //        DateTime startDateApplied = Convert.ToDateTime(_txtStartDate.Text);
        //        DateTime endDateApplied = Convert.ToDateTime(_txtEndDate.Text);

        //        TimeSpan timespan;
        //        int noOfDaysapplied;
        //        int noofDaysappliedActual;
        //        timespan = endDateApplied - startDateApplied;
        //        noofDaysappliedActual = Convert.ToInt32(timespan.TotalDays) + 1;

        //        int appliedStartYear = startDateApplied.Year;
        //        int appliedEndDateYear = endDateApplied.Year;
        //     int availableDays=0;
        //    try
        //    {
        //        //no.of available days for the applied start date year ...does not take into account for the end date cos not needed
        //        availableDays = 60 - tDisconnect.GetNumberofTempdisconnectionalreadytaken(strUserID, appliedStartYear);
        //    }
        //     catch (Exception ex)
        //    {
        //        Session["ErrorMsg"] = ex.ToString();
        //        Response.Redirect("~/Error.aspx", false);
        //    }

        //        if (endDateApplied > startDateApplied || appliedEndDateYear > appliedStartYear)//this should be the normal data entry that end date is always greater than the start date
        //        {
        //            if (appliedStartYear == appliedEndDateYear)//eg 2010 and 2010 or 2011 and 2011 or 2012 and 2012 etc
        //            {
        //                noOfDaysapplied = noofDaysappliedActual;//need to take out for only current apllied year     
        //                //noofDaysappliedActual can be 60 or less than that
        //            }
        //                //eg. 2011 and 2012 etc
        //            else if (endDateApplied.DayOfYear < 60) //(appliedEndDateYear > DateTime.Today.Year) 
        //            {
        //                //if both start date year and end date year  differrent
        //                //plus end year  greater than the current year for this condition to apply
        //                //then get the no of days applied for this year only making dec 31 as the end date for temp. disconnection
        //                int daysInYear = DateTime.IsLeapYear(startDateApplied.Year) ? 366 : 365;
        //                noOfDaysapplied = daysInYear - startDateApplied.DayOfYear; // Result is in range 0-365.the number od days left for this year becomes the number od days applied

        //            }
        //            else
        //            {
        //                noOfDaysapplied = endDateApplied.DayOfYear; //this will result in the number of days surely more than 60 days
        //                availableDays = 60;//this is need to display the correct no. of availble days in the error message below
        //                //these above two lines can be removed and instead a warning message can be shown here only if the following below codes are stopped from being executed
        //            }
               
        //            //now that we have got the number of days applied for, be it for current year or two years, do the validation for only 60 days in a year
        //            if (noOfDaysapplied > availableDays) //available days can be 60 or less depending on already used days
        //            {
        //                _lblFail.Visible = true;
        //                _lblFail.Text = "Sorry! Disconnection for more than " + availableDays + " days in a year is not allowed.";
        //            }
        //            else
        //            {
        //                if (rblistTempDiscReason.SelectedValue == "U") //U refers to temp. disconnection requested by user
        //                {
        //                    statustoupdate = UpdateStatusEnumValue.enumValue(UpdateStatus.TEMPORARYDISCONNECTION);
        //                    if (FileUpload1.HasFile)
        //                    {
        //                        SaveScannedTempDisconnectForm();
                                
        //                    }
        //                }
        //                else
        //                {
        //                    statustoupdate = UpdateStatusEnumValue.enumValue(UpdateStatus.DEACTIVATEDONNONPAYMENT);
        //                }
        //                try
        //                {
        //                    //tDisconnect.RegisterTempDisconnectDetails(strUserID, (Convert.ToDateTime(_txtStartDate.Text,ci)).ToShortDateString(), (Convert.ToDateTime(_txtEndDate.Text,ci)).ToShortDateString(), Session["EmpID"].ToString());
        //                    tDisconnect.RegisterTempDisconnectDetails(strUserID, startDateApplied.ToShortDateString(), endDateApplied.ToShortDateString(), Session["EmpID"].ToString(), statustoupdate, scannedFormName, tbReasons.Text);
        //                    _lblSuccess.Visible = true;
        //                    _lblFail.Visible = false;
        //                    _lblSuccess.Text = "<font color=Red> " + _txtCustomerName.Text + "  </font>  " + "has been Temporarily disconnected for" + "<font color=Red> " + noofDaysappliedActual + " </font>" + " days.";
        //                }
        //                catch (Exception ex)
        //                {
        //                    Session["ErrorMsg"] = ex.ToString();
        //                    Response.Redirect("~/Error.aspx", false);
        //                }
        //                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.TEMPDEACTIVATETEMPUSR, strUserID);
        //                ClearForm();


        //            }
        //        }
        //        else//this is abnormal and shouldnt be done by the user.nevertheless if he/she does, then show him this warning no other execution takes place
        //        {
        //            _lblFail.Visible = true;
        //            _lblFail.Text = "Temporary disconnection start date cannot be greater than the end date.";
        //        }
        //    }

           
           
        

        //#endregion


        #region TEMPORARY DISCONNECTION without validation

        protected void _btnTempDisconect_Click(object sender, ImageClickEventArgs e)
        {
            //CultureInfo ci = new CultureInfo("en-GB");
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;

            TempDisconnectionDetails tDisconnect = new TempDisconnectionDetails();
            DateTime startDateApplied = Convert.ToDateTime(_txtStartDate.Text);
             DateTime endDateApplied;
             if (_txtEndDate.Text != "")
             {
                 endDateApplied = Convert.ToDateTime(_txtEndDate.Text);
             }
             else//no end date
             {
                 endDateApplied = Convert.ToDateTime("0001/01/01");
             }


           // TimeSpan timespan;
           // int noOfDaysapplied;
          //  int noofDaysappliedActual;
          //  timespan = endDateApplied - startDateApplied;
          //  noofDaysappliedActual = Convert.ToInt32(timespan.TotalDays) + 1;
       
              if (rblistTempDiscReason.SelectedValue == "U") //U refers to temp. disconnection requested by user
                    {
                        statustoupdate = UpdateStatusEnumValue.enumValue(UpdateStatus.TEMPORARYDISCONNECTION);
                        if (FileUpload1.HasFile)
                        {
                            SaveScannedTempDisconnectForm();

                        }
                    }
                    else
                    {
                        statustoupdate = UpdateStatusEnumValue.enumValue(UpdateStatus.DEACTIVATEDONNONPAYMENT);
                    }
                    try
                    {
                        tDisconnect.RegisterTempDisconnectDetails(strUserID, startDateApplied.ToShortDateString(), endDateApplied.ToShortDateString(), Session["EmpID"].ToString(), statustoupdate, scannedFormName, tbReasons.Text);
                        _lblSuccess.Visible = true;
                        _lblFail.Visible = false;
                        _lblSuccess.Text = "<font color=Red> " + _txtCustomerName.Text + "  </font>  " + "has been Temporarily disconnected.";
                    }
                    catch (Exception ex)
                    {
                        Session["ErrorMsg"] = ex.ToString();
                        Response.Redirect("~/Error.aspx", false);
                    }
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.TEMPDEACTIVATETEMPUSR, strUserID);
                    ClearForm();


                }
         
        





        #endregion


        private void ClearForm()
        {
            _txtUserID.Text = String.Empty;
            _txtUserName.Text = String.Empty; 
            _txtCustomerName.Text = String.Empty;
            _txtBillPlan.Text = String.Empty; 
            _txtPaymentMode.Text = String.Empty;
            _txtStatus.Text = String.Empty;
            _txtStartDate.Text = String.Empty;
            _txtEndDate.Text = String.Empty;
            _txtOutStanding.Text = String.Empty;
            tbReasons.Text = String.Empty;
            scannedFormName = "";
            
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
            _btnTempDisconect.Visible = true;
            _lblSuccess.Text = "";
            _lblFail.Text = "";
        }

    }
}
