using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class BillPaymentDarkFiber : System.Web.UI.Page
    {
        protected void _rbtnInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnInstrument.SelectedValue == "CA")
            {
                _panelChequeDetails.Visible = false;
            }
            else if (_rbtnInstrument.SelectedValue == "CH")
            {
                //_rbtnInstrument.Visible = true;
                //_txtAmount.Visible = true;
                //_txtChequeDetails.Visible = true;
                _panelChequeDetails.Visible = true;
                RequiredFieldValidator4.Enabled = true;
            }
        }

        

        #region GET USER DETAILS

        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {
            string username = _tbUsername.Text;
            if (AccountMaster.UsernameExists(username))
            {
                _lblSuccess.Visible = false;
               
                try
                {
                   
                    AccountMaster ac = new AccountMaster(username, true);
                    lblAccountID.Text = ac.AccountID;
                    lblClientName.Text = ac.Name;      
                    string status = ac.Status;
                    if (status == "A")
                    {
                        lblStatus.Text = "ACTIVE";
                    }
                    else
                    {
                        lblStatus.Text = "INACTIVE";
                    }
                    lblMobileNumber.Text = ac.MobileNumber;
               
                    fielsetClientDetails.Visible  =trReceiptNumber.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
            else
            {
                _panelPaymentDetails.Visible = fielsetClientDetails.Visible = trReceiptNumber.Visible = false;
                _lblSuccess.Visible = true;
                _lblSuccess.Text = "<font color='red'>Invalid Username</font>";
            }
        }
        #endregion

        #region Functionality to Clear Form

        private void ClearForm()
        {
            _tbUsername.Text = String.Empty;                  
            _txtReceiptNumber.Text = String.Empty;
            _txtChequeDetails.Text = String.Empty;
            _txtAmount.Text = String.Empty;
            _txtRemarks.Text = String.Empty;
            _txtPaymentDate.Text = String.Empty;       
            _rbtnInstrument.SelectedIndex = -1;
            _lblExist.Text = "";
         
             _panelPaymentDetails.Visible = fielsetClientDetails.Visible = trReceiptNumber.Visible = false;

        }

        #endregion


        protected void _btnDuplicateEntry_Click(object sender, ImageClickEventArgs e)
        {
            if (DarkFiberPayments.PaymentEntryExists(_txtReceiptNumber.Text))
            {
                _lblExist.Text = "Receipt Number: <b>" + _txtReceiptNumber.Text + "</b> already exists. Duplicate Entry not allowed.";
             
            }
            else
            {
                
                _lblExist.Text = "Receipt Number: <b>" + _txtReceiptNumber.Text + "</b> is unique. Continue Payment...";
                _panelPaymentDetails.Visible = true;
            }
        }

        #region Method to Post Cycle Payment Details

        protected void _btnPostPayment_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            _lblSuccess.Visible = true;
           // String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            String chequeDetails = String.Empty;
            String receiptNum = _txtReceiptNumber.Text.ToString();
            double amountPayment = Convert.ToDouble(_txtAmount.Text);
            if (_txtChequeDetails.Text == null)
            {
                chequeDetails = "-";
            }
            else
            {
                chequeDetails = _txtChequeDetails.Text;
            }
                try
                {
                    DarkFiberPayments payDetails = new DarkFiberPayments();
                    payDetails.AddNewReceipt(lblAccountID.Text, receiptNum, amountPayment, _rbtnInstrument.SelectedItem.ToString(), chequeDetails,_txtRemarks.Text, Session["EmpID"].ToString(), Convert.ToDateTime(_txtPaymentDate.Text, ci).ToShortDateString()); 
                    ClearForm();
                    _lblSuccess.Text = "Payment Details Succesfully posted against" + "<font color=Red>  " + lblClientName.Text + "</font>";
                    
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
                       
            try
            {
                //on click save log event assuming payment has actually been posted without any error
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PAYMENT + _tbUsername.Text, lblAccountID.Text); 
            }
            catch { }


        }

        #endregion

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            _lblSuccess.Text = "";
            ClearForm();
        }


    }
}
