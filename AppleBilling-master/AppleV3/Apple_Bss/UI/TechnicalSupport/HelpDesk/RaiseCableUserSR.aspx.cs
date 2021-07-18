using System;
using System.Globalization;
using System.Web.UI;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class RaiseCableUserSR : System.Web.UI.Page
    {

        string mobilenumbers;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                _tbUserName.Focus();
                //_ltrlSubscriberDetails.Visible = false;
                try
                {                    
                   SetStatusPending();              
                   SetDateandTimeToNow();
                   PopulateCableProviders();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }
        protected void PopulateCableProviders()
        {

            ddlCableOperator.DataSource = LAPMaster.GetCableProviders();
            ddlCableOperator.DataTextField = "LAPNAME";
            ddlCableOperator.DataValueField = "LAPID";
            ddlCableOperator.DataBind();
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
            _tbMobileNumber.Text = "";
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
        
           
                if (status == "F")
                {
                    enddatetime = Convert.ToDateTime(_txtEndDate.Text).ToString("MM-dd-yyyy") + " " + _ddlEndHours.SelectedValue.ToString() + ":" + _ddlEndMinutes.SelectedValue.ToString() + ":00";                             
                       issueassignedto = Session["EmpID"].ToString();
                }
            
                try
                {    
                    //registering the support request details in db
                   string ticketNumber= ServiceCalls.AddNewServiceCallRecord(_tbUserName.Text, "", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());
                    
                    if (status == "P")
                    {
                        try
                        {
                            LAPMaster cableprovider = new LAPMaster(ddlCableOperator.SelectedValue);

                            mobilenumbers =_tbMobileNumber.Text + "," + cableprovider.LAPTechContactID1 + "," + cableprovider.LAPTechContactID2;
                            
                           Utilities.SendSMS(DBConn.GetSMSMessagePending() + ticketNumber, mobilenumbers);

                             string   strMsg =DBConn.GetCableNotification() + " Cable SR ALERT: " +ticketNumber + " Name : " + _tbUserName.Text + " Mobile: +" + _tbMobileNumber.Text;
                            string subject =  "Cable Service Request for  " + _tbUserName.Text;

                            //send mail to cable contact
                            string returnMessage = Utilities.Sendemail(strMsg, subject, cableprovider.LAPTechEmailID);
                            if (returnMessage != "true") //false
                            {
                                _lblStatus.Text = subject + " successfully placed with SR ID: " + ticketNumber + " Mail delivery to recipient failed.";
                                _lblStatus.ToolTip = returnMessage;
                            }
                            else
                            {
                            ClearFormForNewEntry();
                            //display the message in text
                            _lblStatus.Text = subject + " successfully placed with SR ID: " + ticketNumber;
                            }
                        
                        }
                        catch (Exception ex)
                        {
                            Session["ErrorMsg"] = ex.ToString();
                            Response.Redirect("~/Error.aspx", false);
                        } 
                      //  Response.Redirect("PendingSRConfirmation.aspx?id=" + Utilities.QueryStringEncode(userid) + "&dt=" + Utilities.QueryStringEncode(startdatetime), false);

                        
                    }
                    else if (status == "F")
                    {
                        try
                        {
                            //for "P" condition log added  is on the next page
                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST + " and Resolved",_tbUserName.Text);
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

     
    }
  
}
