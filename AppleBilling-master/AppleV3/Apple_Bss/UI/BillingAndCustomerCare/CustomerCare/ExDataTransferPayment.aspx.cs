using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class ExDataTransferPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCollectionBoyExcec();
                _lblBc.Text = DBConn.GetBranchCode();
                _panelPaymentDetails.Visible = false;
                RequiredFieldValidator4.Enabled = false;
                _panelChequeDetails.Visible = false;
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
            if (_rbtnInstrument.SelectedValue == "CASH")
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
        }

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {

            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {
                _lblSuccess.Visible = false;
                try
                {

                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    _txtCustomerName.Text = buser.Name;

                    string currentCycleStartDate = "";
                    string currentCycleEndDate = "";
                    String paymentMode = this.GetPaymentMode().ToString();

                    if (paymentMode == "M")
                    {
                        paymentMode = "Monthly";
                        currentCycleStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                        currentCycleEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                    }
                    else if (paymentMode == "Q")
                    {
                        paymentMode = "Quarterly";
                        currentCycleStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfQuarterlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                        currentCycleEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                    }
                    if (paymentMode == "H")
                    {
                        paymentMode = "Half-Yearly";
                        currentCycleStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfHalfYearlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                        currentCycleEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfHalfYearlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");

                    }
                    if (paymentMode == "Y")
                    {
                        paymentMode = "Yearly";
                        currentCycleStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfYearlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");
                        currentCycleEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfYearlyCycle(this.GetBillCycleID())).ToString("dd-MMM-yyyy");

                    }

                    _lblBillCycleDetails.Text = "Payment Mode: <font color=Red><b>" + paymentMode + "</b></font> Current Bill Cycle: <font color=Red><b>" + currentCycleStartDate + " to " + currentCycleEndDate + "</b></font>";




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
            _rbtnInstrument.SelectedIndex = -1;
            _lblBillCycleDetails.Text = String.Empty;
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

        #region Funtionality to Get BILL CYCLE ID

        private Int32 GetBillCycleID()
        {
            String payMode = this.GetPaymentMode();
            String currDate = System.DateTime.Now.ToString("dd-MMM-yyyy");
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

        #region Funtionality to check Duplicate Entry
        protected void _btnDuplicateEntry_Click(object sender, ImageClickEventArgs e)
        {
            if (CustomerPayments.PaymentEntryExists(_txtReceiptNumber.Text))
            {
                _lblExist.Text = "Entry for the Receipt Number: <b>" + _txtReceiptNumber.Text + "</b> already exists. Duplicate Entry not allowed.";
                _panelPaymentDetails.Visible = false;
            }
            else
            {
                _lblExist.Text = String.Empty;
                _panelPaymentDetails.Visible = true;
            }
        }
        #endregion

        #region Method to Post Extra Data Transfer Payment Details

        protected void _btnPostPayment_Click(object sender, ImageClickEventArgs e)
        {


            CultureInfo ci = new CultureInfo("en-GB");
            String strUserID = String.Empty;
            Int32 bcID = 0;
            String chequeDetails = String.Empty;
            _lblSuccess.Visible = true;
            if (_txtChequeDetails.Text == null)
            {
                chequeDetails = "-";
            }
            else
            {
                chequeDetails = _txtChequeDetails.Text;
            }

            if (_chkBoxSelf.Checked) // Self Collection
            {
                try
                {
                    strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
                    bcID = this.GetBillCycleID();

                    CustomerPayments payDetails = new CustomerPayments();
                    payDetails.AddNewReceipt(strUserID, _txtReceiptNumber.Text.ToString(), Convert.ToDouble(_txtAmount.Text), _rbtnInstrument.SelectedValue.ToString(), chequeDetails, "T", bcID, _txtRemarks.Text, Session["EmpID"].ToString(), Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString());


                    _lblSuccess.Text = "Extra Data Transfer Payment Details Succesfully posted against" + "<font color=Red>  " + _txtCustomerName.Text + "</font>";
                    ClearForm();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
            else //Collection Boy
            {
                try
                {
                    strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
                    bcID = this.GetBillCycleID();

                    CustomerPayments payDetails = new CustomerPayments();
                    payDetails.AddNewReceipt(strUserID, _txtReceiptNumber.Text.ToString(), Convert.ToDouble(_txtAmount.Text), _rbtnInstrument.SelectedValue.ToString(), chequeDetails, "T", bcID, _txtRemarks.Text,_ddlCollector.SelectedValue.ToString(),Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString());


                    _lblSuccess.Text = "Extra Data Transfer Payment Details Succesfully posted against" + "<font color=Red>  " + _txtCustomerName.Text + "</font>";
                    
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PAYMENTEDT, strUserID);
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

