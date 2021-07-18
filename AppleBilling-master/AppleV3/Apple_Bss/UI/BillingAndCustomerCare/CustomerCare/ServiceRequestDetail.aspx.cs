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

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class ServiceRequestDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           // if(IsPostBack)
          //  {
            String issueid = String.Empty;

            try
            {
                issueid = Request["issueid"].ToString();
                // _txtEndDate.Attributes.Add("onchange", "document.getElementById('" + hiddenEndDate.ClientID + "').value = this.value;");
                ShowActionHistory(issueid);
                PopulateServiceRequestCredentials(issueid);

              //  SetDateandTimeToNow();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

            if (!IsPostBack)
            {
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWSERVICEREQUESTDETAILS + issueid);
            }
       // }
    }
            

        private void ShowActionHistory(String pStrIssueID)
        {
            Repeater1.DataSource = ServiceRequestLogs.GetActionHistory(pStrIssueID).Tables[0];
            Repeater1.DataBind();
        }


        private void PopulateServiceRequestCredentials(String pStrSRN)
        {
            ServiceCalls srcall = new ServiceCalls(pStrSRN);
            _lblIssueReported.Text = srcall.Issue;

            lblUserId.Text = srcall.UserID;
            String status = srcall.Status;
            _lblSRN.Text = pStrSRN;

            if (status.ToUpper() == "P")
            {
                _lblStatus.Text = "PENDING";
                _lblStatus.ForeColor = System.Drawing.Color.Red;
                Panel1.Visible = false;
            }
            else if (status.ToUpper() == "R")
            {
                _lblStatus.Text = "RESOLVED";
                _lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
                Panel1.Visible = false;
              
            }
            else if (status.ToUpper() == "F")
            {
                _lblStatus.Text = "Fixed & Awaiting Validation ";
                _lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
              
            }

           

           
            
        }



        private void SetDateandTimeToNow()
        {
            //DateTime dateTimeNow = DateTime.Now;
            //_txtEndDate_CalendarExtender.SelectedDate = dateTimeNow.Date;
            //_ddlHours.SelectedValue = dateTimeNow.Hour.ToString();
            //_ddlMinutes.SelectedValue =dateTimeNow.Minute.ToString();

        }
      
       
        protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
        {
    
            CultureInfo ci = new CultureInfo("en-GB");
            //  String endDate = Convert.ToDateTime(_txtEndDate.Text).ToString("MM-dd-yyyy") + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";                             

            String verificationTime = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";
             
            try
            {
                ServiceCalls toverify = new ServiceCalls();
              toverify.UpdateServiceRequest(_lblSRN.Text, "Closed " + _tbActionTaken.Text, "R", Session["EmpID"].ToString(), verificationTime);
              ShowActionHistory(_lblSRN.Text);
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>window.opener.location.reload(true);self.close();</script>");
              PopulateServiceRequestCredentials(_lblSRN.Text);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
           // SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSERVICEREQUEST + _issueID + " to " + _radResolutionStatus.SelectedItem);
            _tbActionTaken.Text = String.Empty;

          string mobilenumber=  BroadbandUser.GetSubscriberMobileNumber(lblUserId.Text);
           // Utilities.SendSMS(DBConn.GetSMSMessageResolved() + _lblSRN.Text, "9164339498");
          try
          {
              Utilities.SendSMS(DBConn.GetSMSMessageResolved() + _lblSRN.Text, mobilenumber);
          }
          catch
          {
          }
        }

        protected void imgBtnPending_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            //  String endDate = Convert.ToDateTime(_txtEndDate.Text).ToString("MM-dd-yyyy") + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";                             

            String verificationTime = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";

            try
            {
                ServiceCalls toverify = new ServiceCalls();
                toverify.UpdateServiceRequest(_lblSRN.Text, "Reopened " + _tbActionTaken.Text, "P", Session["EmpID"].ToString(), verificationTime);
                ShowActionHistory(_lblSRN.Text);
                PopulateServiceRequestCredentials(_lblSRN.Text);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            // SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSERVICEREQUEST + _issueID + " to " + _radResolutionStatus.SelectedItem);
            _tbActionTaken.Text = String.Empty;
        }

      
        
    }
}
   