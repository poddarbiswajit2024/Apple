using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;
namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class CyclePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                 BindCollectionBoyExcec();
                _lblBc.Text = DBConn.GetBranchCode();
                 RequiredFieldValidator4.Enabled = false;
                _panelChequeDetails.Visible = false;
                _panelPaymentDetails.Visible = false;
            }
        }

        private void BindCollectionBoyExcec()
        {
            try
            {
                _ddlCollector.DataSource = SystemUsers.GetCollectionBoyExecPrivID().Tables[0];
                _ddlCollector.DataTextField = "NAME";
                _ddlCollector.DataValueField = "EMPID";
                _ddlCollector.DataBind();              
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _rbtnInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnInstrument.SelectedValue == "CASH" || _rbtnInstrument.SelectedValue == "ONLINEPAY")
            {
                _rbtnInstrument.Visible = true;
                _txtAmount.Visible = true;
                _txtChequeDetails.Visible = false;
                _panelChequeDetails.Visible = false;
            }
            else if (_rbtnInstrument.SelectedValue == "CHEQUE/DD")
            {
                _rbtnInstrument.Visible = true;
                _txtAmount.Visible = true;
                _txtChequeDetails.Visible = true;
                _panelChequeDetails.Visible = true;
                RequiredFieldValidator4.Enabled = true;
            }
            //else //for online payment
            //{
            //}
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
            _panelPaymentDetails.Visible = true;
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
            _txtChequeDetails.Text = String.Empty;
            _txtAmount.Text = String.Empty;
            _txtRemarks.Text = String.Empty;
            _txtPaymentDate.Text = String.Empty;
            _txtStatus.Text = String.Empty;
            _txtOutstandAmount.Text = String.Empty;
            _rbtnInstrument.SelectedIndex = -1;
            _lblExist.Text = "";
            _panelPaymentDetails.Visible = false;
        }

        #endregion


        //protected void _btnDuplicateEntry_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (CustomerPayments.PaymentEntryExists(_txtReceiptNumber.Text))
        //    {
        //        _lblExist.Text = "Entry for the Receipt Number: <b>"+_txtReceiptNumber.Text + "</b> already exists. Duplicate Entry not allowed.";             
        //        _panelPaymentDetails.Visible = false;
        //    }
        //    else
        //    {
        //        _lblExist.Text = String.Empty;
        //        _panelPaymentDetails.Visible = true;
        //    }
        //}
        
        #region Method to Post Cycle Payment Details

        protected void _btnPostPayment_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            _lblSuccess.Visible = true;
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String chequeDetails = String.Empty;           
            String receiptNum = _txtReceiptNumber.Text.ToString();   
            double amountPayment = Convert.ToDouble(_txtAmount.Text);
              bool receiptEntryStatus = false;


              if (_txtChequeDetails.Text == null)
              {
                  chequeDetails = "-";
              }
              else
              {
                  chequeDetails = _txtChequeDetails.Text;
              }
              CustomerPayments payDetails = new CustomerPayments();

              if (_chkBoxSelf.Checked) // Amount collected by Self
              {
                  try
                  {                   

                      receiptEntryStatus = payDetails.AddNewReceipt(strUserID, receiptNum, amountPayment, _rbtnInstrument.SelectedValue.ToString(), chequeDetails, "F", 0, _txtRemarks.Text, Session["EmpID"].ToString(), Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString());
                   
                  }
                  catch (Exception ex)
                  {
                      Session["ErrorMsg"] = ex.ToString();
                      Response.Redirect("~/Error.aspx", false);
                  }
              }
              else // amount collected by colection Boy Exec
              {

                  try
                  {                  
                     receiptEntryStatus = payDetails.AddNewReceipt(strUserID, receiptNum, amountPayment, _rbtnInstrument.SelectedValue.ToString(), chequeDetails, "F", 0, _txtRemarks.Text, _ddlCollector.SelectedValue.ToString(), Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString());
                    
                  }
                  catch (Exception ex)
                  {
                      Session["ErrorMsg"] = ex.ToString();
                      Response.Redirect("~/Error.aspx", false);
                  }

              }

              if (receiptEntryStatus == true) //receipt details entered in db
              {
                  //DISPLAY SUCCESS MESSAGE
                  _lblSuccess.Text = "Payment Details Succesfully posted against" + "<font color=Red>  " + _txtCustomerName.Text + "</font>";
              }
              else
              {
                  _lblExist.Text = "Entry for the Receipt Number: <b>" + _txtReceiptNumber.Text + "</b> already exists. Duplicate Entry not allowed.";

              }
              try
              {
                  //on click save log event assuming payment has actually been posted without any error
                  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PAYMENT + _txtUserName.Text, strUserID);
              }
              catch { }

              ClearForm();
           
        }
     


        #endregion

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        protected void _chkBoxSelf_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkBoxSelf.Checked)
            {
                _ddlCollector.Enabled = false;
            }
            else
            {
                _ddlCollector.Enabled = true;
            }
        }
                    
    }
}
