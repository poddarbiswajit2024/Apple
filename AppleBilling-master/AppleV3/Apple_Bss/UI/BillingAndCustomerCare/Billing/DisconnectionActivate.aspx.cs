using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class DisconnectionActivate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["userID"] != null)
            {
                String userID = Apple_Bss.CodeFile.Utilities.QueryStringDecode(Request["userID"].ToString());
                try
                {
                    BroadbandSubscriberLedgers bbledger = new BroadbandSubscriberLedgers();
                    BroadbandUser buser = new BroadbandUser(userID);
                    _txtOutStanding.Text = bbledger.GetTotalOutstanding(userID).ToString();
                    _txtCustName.Text = buser.Name;
                    _txtUserName.Text = buser.UserName;

                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }

            else
            {
                _lblBc.Text = DBConn.GetBranchCode();
           
                _txtUserID.Focus();
            }
        }

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {

            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                // _lblFail.Visible = false;
              //  String pkgName = this.getBillPackageName();
               // String payMode = this.GetPaymentMode();
                String status = String.Empty;
                try
                {
                    BroadbandSubscriberLedgers bbledger = new BroadbandSubscriberLedgers();
                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    _txtCustName.Text = buser.Name;
                    _txtOutStanding.Text = bbledger.GetTotalOutstanding(strUserID).ToString();
                    status = buser.Status;
                //    _txtBillPlan.Text = pkgName.ToString();

                    //for Status
                    if (status == "A")
                    {
                        _txtStatus.Text = "ACTIVE";
                    }
                    else if (status == "P")
                    {
                        _txtStatus.Text = "INACTIVE PERMANENT";
                        lblMessage.Visible = true;

                    }
                    else
                    {
                        _txtStatus.Text = "INACTIVE TEMPORARY";
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
                // _lblFail.Visible = true;
                lblMessage.Text = "Invalid User ID";
            }
        }
        #endregion


        #region Functionality to get the PAYMENT MODE

        private String GetPaymentMode(string userID)
        {
           // String userID = Apple_Bss.CodeFile.Utilities.QueryStringDecode(Request["userID"].ToString());
            String payMode = String.Empty;
            try
            {
                payMode = BroadbandUserBillingInfo.PaymentModeListing(userID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            return (payMode);
        }
        #endregion

        #region Funtionality to Get BILL CYCLE ID

        private Int32 GetBillCycleID(string userID)
        {
            String payMode = this.GetPaymentMode(userID);
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            Int32 bc = -1;

            if (payMode == "M")
            {
                bc = BillCycles.GetMonthlyBillCycleID(currDate) + 1;

            }
            else if (payMode == "Q")
            {
                bc = BillCycles.GetQuarterlyBillCycleID(currDate) + 2;

            }
            else if (payMode == "H")
            {
                bc = BillCycles.GetHalfYearlyBillCycleID(currDate) + 5;

            }
            else if (payMode == "A")
            {
                bc = BillCycles.GetYearlyBillCycleID(currDate) + 11;

            }

            return (bc);

        }
        #endregion

        #region RE ACTIVATE TEMP DISCONNECTED USER

        protected void _btnReactivate_Click(object sender, ImageClickEventArgs e)
        {
            //  String userID = Apple_Bss.CodeFile.Utilities.QueryStringDecode(Request["userID"].ToString());
            String userID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            Int32 bc = -1;
            bc = this.GetBillCycleID(userID);
           
        
            try
            {
       
                ArrearsAndWaivers tempAct = new ArrearsAndWaivers();
                tempAct.AddArrearsAndWaivers(userID, bc, _txtWaiver.Text, _txtArrear.Text, _txtRemarks.Text, Session["EmpID"].ToString(), UpdateStatus.ACTIVATE, (Convert.ToDateTime(_txtStartDate.Text)).ToShortDateString());
 
                _lblSuccess.Text = " Re-Activation Succesfull for Subscriber:" + "<font color='Red' > " + _txtUserName.Text + "  </font>";                
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REACTIVATETEMPUSR, userID);
            ClearForm();
        }

        #endregion

        private void ClearForm()
        {
            _txtCustName.Text = String.Empty;
            _txtUserName.Text = String.Empty;
         //   _txtArrear.Text = String.Empty;
           // _txtWaiver.Text = String.Empty;
            _txtRemarks.Text = String.Empty;
            _txtOutStanding.Text = String.Empty;
            _txtStartDate.Text = String.Empty;
            _txtStatus.Text = String.Empty;
            _txtUserID.Text = String.Empty;
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        protected void _iBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DisconnectedUsersView.aspx", false);
        }
    }
}
