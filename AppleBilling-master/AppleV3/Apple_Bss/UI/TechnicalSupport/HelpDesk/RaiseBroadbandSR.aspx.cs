using System;
using System.Globalization;
using System.Web.UI;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class RaiseBroadbandSR : System.Web.UI.Page
    {

        static string mobilenumber;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                _tbUserName.Focus();
                //_ltrlSubscriberDetails.Visible = false;
                try
                {                    
                   SetStatusPending();
              
                   lblBranchCode.Text = DBConn.GetBranchCode();
                   SetDateandTimeToNow();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }

        private void SetDateandTimeToNow()
        {
            DateTime dateTimeNow = DateTime.Now;
            CalendarExtender1.SelectedDate = dateTimeNow.Date;
            _ddlHours.SelectedValue = dateTimeNow.Hour.ToString();
            _ddlMinutes.SelectedValue = dateTimeNow.Minute.ToString();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_radResolutionStatus.SelectedValue == "F")
            {
                SetStatusResolved();
            }
            else if (_radResolutionStatus.SelectedValue == "P")
            {
                SetStatusPending();
            }
        }

    

        private void SetStatusResolved()
        {
            _lblResTime.Visible = true;
            _lblResDateTime.Visible = true;
            _txtEndDate.Visible = true;
            _ddlEndHours.Visible = true;
            _ddlEndMinutes.Visible = true;          
            //_lblIssueAssignedTo.Visible = false;
            //_ddlIssueAssignedTo.Visible = false;
            ////enable the required validators
            rfvHours.Enabled = true;
            rfvminutes.Enabled = true;
            rfvEndDate.Enabled = true; ;
        }

        private void SetStatusPending()
        {
            _lblResTime.Visible = false;
            _lblResDateTime.Visible = false;
            _txtEndDate.Visible = false;
            _ddlEndHours.Visible = false;
            _ddlEndMinutes.Visible = false;            
            //_lblIssueAssignedTo.Visible = true;
            //_ddlIssueAssignedTo.Visible = true;            
            ////disable the not required validators
            rfvHours.Enabled = false;
            rfvminutes.Enabled = false;
            rfvEndDate.Enabled = false;

        }

        private void ClearFormForNewEntry()
        {
            SetStatusPending();
            _tbIssueReported.Text = String.Empty;
            _tbIssueCause.Text = String.Empty;
            _tbActionTaken.Text = String.Empty;
            _tbUserName.Text= String.Empty;

            _txtEndDate.Text = "";
            _txtStartDate.Text = "";
            _tbUserName.Focus();
        }

        protected void _btnRegisterSR_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");            
            string status = _radResolutionStatus.SelectedValue;
            string enddatetime = String.Empty;            
            string startdatetime = String.Empty;
            string issueassignedto = String.Empty;
            startdatetime = Convert.ToDateTime(_txtStartDate.Text).ToString("MM-dd-yyyy") + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";
            //startdatetime = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";

            string userid = HiddenFieldUserId.Value;
            if (userid != String.Empty)
            {
                if (status == "F")
                {
                    enddatetime = Convert.ToDateTime(_txtEndDate.Text).ToString("MM-dd-yyyy") + " " + _ddlEndHours.SelectedValue.ToString() + ":" + _ddlEndMinutes.SelectedValue.ToString() + ":00";                             
                  //  enddatetime = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString() + " " + _ddlEndHours.SelectedValue.ToString() + ":" + _ddlEndMinutes.SelectedValue.ToString() + ":00";
                    issueassignedto = Session["EmpID"].ToString();
                }
            
                try
                {    
                    //registering the support request details in db
                   string ticketNumber= ServiceCalls.AddNewServiceCallRecord(userid, "SPOP1001", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());
                    
                    if (status == "P")
                    {
                        //if pending then send sms to client with a affirmation that their problem is being resolved - 25/jan/2013
                   
                      
                        try
                        {

                             Utilities.SendSMS(DBConn.GetSMSMessagePending() + ticketNumber, mobilenumber); 

                           // ClearFormForNewEntry();                           
                        }
                        catch (Exception ex)
                        {
                            Session["ErrorMsg"] = ex.ToString();
                            Response.Redirect("~/Error.aspx", false);
                        } 
                        Response.Redirect("PendingSRConfirmation.aspx?id=" + Utilities.QueryStringEncode(userid) + "&dt=" + Utilities.QueryStringEncode(startdatetime), false);

                        
                    }
                    else if (status == "F")
                    {
                        try
                        {
                            //for "P" condition log added  is on the next page
                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST + " and Resolved",userid);
                        }
                        catch
                        {
                            //do nothing for now
                        }
                        ClearFormForNewEntry();
                        _lblStatus.Text = "Service Request Successfully Posted and sent to customer care for validation.";
                   
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
                _lblStatus.Text = "<font color='red'> Selected username does not exist.  </font>";
            }
            
        }

        protected void _tbUserName_TextChanged(object sender, EventArgs e)
        {
            _lblDetails.Visible = true;
            _ltrlSubscriberDetails.Visible = true;

                try
                {
                    string[] details = new string[3];
                    details = BroadbandUser.GetSubscriberDetails(_tbUserName.Text);
                    //for id only
                    HiddenFieldUserId.Value = details[1];
                    mobilenumber = details[2];
                    _ltrlSubscriberDetails.Text = "<b> UserID: " + details[1] + ", Name : " + details[0] + ", Mobile Number : " + details[2] + "</b>";
                   // _tbUserName.Focus();
                    tbUserId.Text = String.Empty;

                }
                catch (NullReferenceException)
                {
                    _ltrlSubscriberDetails.Text = "Selected username does not exist. ";
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            

        }
        /// <summary>
        /// Get minimum subscriber details to display and confirm by userid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbUserId_TextChanged(object sender, EventArgs e)
        {
            _lblDetails.Visible = true;
            _ltrlSubscriberDetails.Visible = true;

            try
            {
                string[] details = new string[3];
                HiddenFieldUserId.Value = lblBranchCode.Text + "-SCLX" + tbUserId.Text;

                details = BroadbandUser.GetSubscriberDetailsbyUserId(HiddenFieldUserId.Value);
                
                mobilenumber = details[2];
                _ltrlSubscriberDetails.Text = "<b> Username: " + details[1] + ", Name : " + details[0] +  ", Mobile Number : " + details[2] + "<b>";
                _tbUserName.Text = String.Empty;
             

            }
            catch (NullReferenceException)
            {
                _ltrlSubscriberDetails.Text = "Selected user id does not exist. ";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

    
    }
  
}
