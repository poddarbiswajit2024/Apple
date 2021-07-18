using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;
namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class OnlinePaymentCorrection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                _lblBc.Text = DBConn.GetBranchCode();
                _panelPaymentDetails.Visible = false;
               
            }
        }

     
  
        #region GET PAYMENT MODE

        private String GetPaymentMode()
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String payMode = String.Empty;
            payMode = BroadbandUserBillingInfo.PaymentModeListing(strUserID);
            return (payMode);
        }

        #endregion

        #region Funtionality to Get BILL CYCLE ID

        private Int32 GetBillCycleID()
        {
            String payMode = this.GetPaymentMode();
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            Int32 bc = -1;

            if (payMode == "M")
            {
                bc = BillCycles.GetMonthlyBillCycleID(currDate);

            }
            else if (payMode == "Q")
            {
                bc = BillCycles.GetQuarterlyBillCycleID(currDate);

            }
            else if (payMode == "H")
            {
                bc = BillCycles.GetHalfYearlyBillCycleID(currDate);

            }
            else if (payMode == "A")
            {
                bc = BillCycles.GetYearlyBillCycleID(currDate);

            }

            return (bc);

        }
        #endregion

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            // Int32 bc = -1;
            // String strPayMode = String.Empty;
            // strPayMode = this.GetPaymentMode();
            // bc = this.GetBillCycleID();
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                _lblSuccess.Visible = false;
                String status = String.Empty;
                double outAmount = 0f;
                try
                {
                    SubscriberLedgers ledger = new SubscriberLedgers();
                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    _txtCustomerName.Text = buser.Name;
                    outAmount = Math.Round(ledger.GetTotalOutstanding(strUserID), 2);
                    _txtOutstandAmount.Text = outAmount.ToString();
                    status = buser.Status;
                    if (status == "A")
                    {
                        _txtStatus.Text = "ACTIVE";
                    }
                    else
                    {
                        _txtStatus.Text = "INACTIVE";
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
                _lblSuccess.Visible = true;
                _lblSuccess.Text = "<font color='red'>Invalid User ID</font>";
            }
        }
        #endregion

        #region Functionality to Clear Form

        private void ClearForm()
        {
            _txtUserID.Text = String.Empty;
            _txtUserName.Text = String.Empty;
            _txtCustomerName.Text = String.Empty;
            _txtReceiptNumber.Text = String.Empty;
       
            _txtAmount.Text = String.Empty;
            _txtRemarks.Text = String.Empty;
            _txtPaymentDate.Text = String.Empty;
            _txtStatus.Text = String.Empty;
            _txtOutstandAmount.Text = String.Empty;
          
            _lblExist.Text = "";
            _panelPaymentDetails.Visible = false;
        }

        #endregion


        protected void _btnDuplicateEntry_Click(object sender, ImageClickEventArgs e)
        {
            if (CustomerPayments.PaymentEntryExists(_txtReceiptNumber.Text.ToString().Trim()))
            {
                _lblExist.Text = "Entry for the Receipt Number: <b>" + _txtReceiptNumber.Text.Trim() + "</b> already exists. Duplicate Entry not allowed.";
                _panelPaymentDetails.Visible = false;
            }
            else
            {
                _lblExist.Text = String.Empty;
                _panelPaymentDetails.Visible = true;
            }
        }

        #region Method to Post Cycle Payment Details

        protected void _btnPostPayment_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            _lblSuccess.Visible = true;
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
           
            String receiptNum = _txtReceiptNumber.Text.ToString().Trim();
            double amountPayment = Convert.ToDouble(_txtAmount.Text);
    

                try
                {
                    CustomerPayments payDetails = new CustomerPayments();
                    payDetails.AddNewReceipt(strUserID, receiptNum, amountPayment, "ONLINEPAY",  "", "F", 0, _txtRemarks.Text, Session["EmpID"].ToString(), Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString());
                    _lblSuccess.Text = "Payment Details Succesfully posted against" + "<font color=Red>  " + _txtCustomerName.Text + "</font>";

                    //update payment status

                    payDetails.UpdatePaymentStatusofOneTransactionLocalServer("SUCCESSFUL", _txtReceiptNumber.Text, true);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
          
            
            try
            {
                //on click save log event assuming payment has actually been posted without any error
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PAYMENT + _txtUserName.Text, strUserID);
                ClearForm();
            }
            catch { }


        }

        #endregion

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

    }
}
