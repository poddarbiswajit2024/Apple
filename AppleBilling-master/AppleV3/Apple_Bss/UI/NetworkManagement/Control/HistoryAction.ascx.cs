using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.NetworkManagement.Control
{
    public partial class HistoryAction : System.Web.UI.UserControl
    {
        private String _issueID;

        public String IssueID
        {
            get { return _issueID; }
            set { _issueID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // _txtEndDate.Attributes.Add("onchange", "document.getElementById('" + hiddenEndDate.ClientID + "').value = this.value;");
                ShowActionHistory(_issueID);
                PopulateServiceRequestCredentials(_issueID);
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            if (!IsPostBack)
            {
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWSERVICEREQUESTDETAILS + _issueID);
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


        protected void _btnRegisterSR_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                String endDate = Convert.ToDateTime(_txtEndDate.Text,ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";
               ServiceRequestLogs.AddNewServiceRequestLog(_issueID, _tbActionTaken.Text, Session["EmpID"].ToString(), endDate);
              
               if (_radResolutionStatus.SelectedValue.ToString() == "R")
                {
                    ServiceCalls.CloseIssue(_issueID, endDate);
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