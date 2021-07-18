using System;
using System.Collections;
using System.Collections.Specialized;
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
    public partial class OnlinePaymentsList : System.Web.UI.Page
    {
        static DataTable paymentTransactions = new DataTable();
        CustomerPayments eshan = new CustomerPayments();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  tbDate1.Text = DateTime.Now.Subtract(TimeSpan.FromDays(DateTime.Now.Day - 1)).ToString("MM/dd/yyyy");
                tbDate2.Text = tbDate1.Text = DateTime.Today.ToString("yyyy/MM/dd");//taking today's date to display 
                DateTime today = DateTime.Today;
                DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                //tbDate2.Text = endOfMonth.ToString("MM/dd/yyyy");
                LoadPaymentTransactions();
            }
        }
        /*
        #region  Multiple rows by seleting the CheckBox

        private void UpdatePaymentStatusNow()
        {
            //StringCollection strCheckedCollection = new StringCollection();
            string strChecked = string.Empty;
            string strChecks = "";
            foreach (GridViewRow row in gvOnlinepaymentsList.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
                if (chkSelect != null)
                {
                    if (chkSelect.Checked) //Check if the Checkbox is Selected
                    {
                        strChecked = "'" + gvOnlinepaymentsList.DataKeys[row.RowIndex].Value.ToString() + "'";                        
                        strChecks += strChecked.ToString() + ",";

                    }
                }
            }
            //deleting the alst comman
            strChecks = strChecks.Substring(0, strChecks.LastIndexOf(","));
            //Call the method to  records 
        //    eshan.UpdatePaymentStatus(ddlUpdatePaymentStatus.SelectedValue.ToString(), strChecks);
            // rebind the GridView
           // gvOnlinepaymentsList.DataBind();
        }


        protected void btnUpdatePaymentStatus_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                UpdatePaymentStatusNow();
                LoadPaymentTransactions();
            }
        }

  

        #endregion
        */
        protected void LoadPaymentTransactions()
        {
            string paymentStatusChecked = "";
            foreach (ListItem listitem in chkBoxListPaymentStatus.Items)
            {
                if (listitem.Selected)

                    paymentStatusChecked += "'" + listitem.Text + "',";
            }
            paymentStatusChecked = paymentStatusChecked.TrimEnd().Remove(paymentStatusChecked.Length - 1);//removing the last comma, 
            gvOnlinepaymentsList.DataSource = paymentTransactions = eshan.GetPaymentTransactionsLocalServer(paymentStatusChecked, tbDate1.Text, tbDate2.Text, chkboxVerifiedStatus.Checked);
            gvOnlinepaymentsList.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOnlinepaymentsList.PageIndex = e.NewPageIndex;
            gvOnlinepaymentsList.DataSource = paymentTransactions;
            gvOnlinepaymentsList.DataBind(); //bindgridview will get the data source and bind it again

        }



        protected void btnUserID_Click(object sender, ImageClickEventArgs e)
        {
            gvOnlinepaymentsList.DataSource = eshan.GetPaymentTransactionsForOneUser(ddlAccountPrefix.SelectedValue + tbUserid.Text.Trim());
            gvOnlinepaymentsList.DataBind();
        }

        protected void btnViewPayments_Click(object sender, ImageClickEventArgs e)
        {
            LoadPaymentTransactions();
        }

        protected void gvOnlinepaymentsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pagenum = gvOnlinepaymentsList.PageIndex;
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
             Label lblTransactionID = (Label)row.FindControl("lblTransactionID");
            if (e.CommandName == "Received")
            {             
                    
                       Label lblEmailID = (Label)row.FindControl("lblEmailID");
                       Label lblPhoneNumber = (Label)row.FindControl("lblPhoneNumber");
                       Label lblPaymentSubmittedTime = (Label)row.FindControl("lblPaymentSubmittedTime");
                       Label lblAccountNumber = (Label)row.FindControl("lblAccountNumber"); 
                       HiddenField hdnAmount = (HiddenField)row.FindControl("hdnAmount");
                    CultureInfo ci = new CultureInfo("en-GB");          
                    double amountPayment = Convert.ToDouble(hdnAmount.Value);
                    try
                    {
                        
                        bool receiptEntryStatus= false;
                        string DBLocationCode = lblAccountNumber.Text.Remove(3);
                        receiptEntryStatus = eshan.AddReceiptToSpecifiedDB(lblAccountNumber.Text, lblTransactionID.Text, amountPayment, "ONLINEPAY", "F", "ONLINE PAYMENT RECONCILATION",Convert.ToDateTime(lblPaymentSubmittedTime.Text, ci).ToShortDateString(), Session["EmpID"].ToString(), DBLocationCode);
                        //update payment status
                        if (receiptEntryStatus == true) //receipt details entered in db
                        {
                            eshan.UpdatePaymentStatusofOneTransactionLocalServer("SUCCESSFUL", lblTransactionID.Text, true);
                            lblMessage.Text = "Payment status of selected transaction marked as successful.";

                        }
                        else
                        {
                            //receipt not added error
                        }

                    }
                    catch (Exception ex)
                    {
                        Session["ErrorMsg"] = ex.ToString();
                        Response.Redirect("~/Error.aspx", false);
                    }
                }
            else if (e.CommandName == "Failed")
            {
                //Mark as Failed
                eshan.UpdatePaymentStatusofOneTransactionLocalServer("FAILURE",lblTransactionID.Text,true);
                lblMessage.Text = "Payment status of selected transaction marked as failed.";
            }
                gvOnlinepaymentsList.PageIndex = pagenum;
            }


        protected void gvOnlinepaymentsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //action image

                Label lblPaymentStatus = (Label)e.Row.FindControl("lblPaymentStatus");
                LinkButton linkbtnAcceptPayment = (LinkButton)e.Row.FindControl("linkbtnAcceptPayment");
                LinkButton linkbtnPaymentFailed = (LinkButton)e.Row.FindControl("linkbtnPaymentFailed");
                if (lblPaymentStatus.Text == "SUCCESSFUL")
                {
                    lblPaymentStatus.ForeColor = System.Drawing.Color.Green;
                  linkbtnPaymentFailed.Visible =  linkbtnAcceptPayment.Visible = false;
                }
                else
                {
                    lblPaymentStatus.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

      
  
    
        }
    }


