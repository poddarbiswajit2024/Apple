using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class ServiceRequestSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbSRNo.Focus();
            if (!IsPostBack)
            {
                    // cal1.SelectedDate = System.DateTime.Now;
                    // cal2.SelectedDate = System.DateTime.Now;
            }
        }

       

  
        
        protected void imgBtnGetDetails_Click(object sender, ImageClickEventArgs e)
        {

            if (ServiceRequestLogs.ServiceRequestIDExists("SRV" + tbSRNo.Text))
            {
                ShowActionHistory("SRV" + tbSRNo.Text);
                PopulateServiceRequestCredentials("SRV" + tbSRNo.Text);
            }
            else
            {
                lblMessage.Text = "No such service request exists";
            }
        }

        private void ShowActionHistory(String pStrIssueID)
        {
            Repeater1.DataSource = ServiceRequestLogs.GetActionHistory(pStrIssueID).Tables[0];
            Repeater1.DataBind();
        }


        private void PopulateServiceRequestCredentials(String pStrSRN)
        {

            _lblSRN.Text = pStrSRN;
           

            ServiceCalls srcall = new ServiceCalls(pStrSRN);
            _lblIssueReported.Text = srcall.Issue;
            _lblUSERID.Text = srcall.UserID;

            String status = srcall.Status;

            if (status.ToUpper() == "P")
            {
                _lblStatus.Text = "PENDING";
                _lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else if (status.ToUpper() == "R")
            {
                _lblStatus.Text = "RESOLVED";
                _lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
                _panelNewAction.Visible = false;
            }

            SystemUsers sysuser = new SystemUsers(srcall.SystemUserID);
            _lblIssueFirstAttendedBy.Text = sysuser.EmployeeName;

        }

        protected void _btnUpdateSR_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            string _issueID = _lblSRN.Text;
            
            try
            {
                String endDate = Convert.ToDateTime(_txtEndDate.Text).ToString("MM-dd-yyyy") + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";                             
                
               // String endDate = Convert.ToDateTime(_txtEndDate.Text,ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";
                ServiceRequestLogs.AddNewServiceRequestLog(_issueID, _tbActionTaken.Text, Session["EmpID"].ToString(), endDate);
                if (_radResolutionStatus.SelectedValue.ToString() == "F")
                {
                    ServiceCalls.FixedIssueRegister(_issueID, endDate, "T");
                    ShowActionHistory(_issueID);
                    PopulateServiceRequestCredentials(_issueID);
                }
                else if (_radResolutionStatus.SelectedValue.ToString() == "P")
                {
                    ShowActionHistory(_issueID);
                } 
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSERVICEREQUEST + _issueID + " to " + _radResolutionStatus.SelectedItem);
            _tbActionTaken.Text = String.Empty;
            _txtEndDate.Text = String.Empty;

        
    
    }

       

          
      

     
        }
       
  
}
