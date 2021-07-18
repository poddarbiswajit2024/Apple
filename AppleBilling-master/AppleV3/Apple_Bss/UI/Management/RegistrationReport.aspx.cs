using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;
using System.Globalization;
namespace Apple_Bss.UI.Management
{
    public partial class RegistrationReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
                PopulateRegistrationDetails();
                _gvReportByMonth.Visible = false;               
            }
        }

        private void PopulateRegistrationDetails()
        {
            RegisteredBroadbandUsers regBuser = new RegisteredBroadbandUsers();
            String total = "";
            CultureInfo ci=new CultureInfo("en-GB");            
          
            try
            {
                if (_rbtnRegReport.SelectedValue == "ALL")
                {
                    _gvReportByMonth.Visible = false;
                    total = regBuser.GetRegisteredUsersCount().ToString();
                    _lblMsg.Text = "<b>Registered Subscribers Selected By<font color='green'> ALL </font><br/>Total &nbsp;&nbsp;&nbsp; :&nbsp;<font color='red'>" + total + "</b>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnRegReport.SelectedItem);

                     

                }
                else if (_rbtnRegReport.SelectedValue == "DTR")
                {
                    string _startdate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
                    string _enddate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
                    _gvReportByMonth.Visible = false;
                    _panelDateRange.Enabled = true;
                    _panelDateRange.Visible = true;
                    total = regBuser.GetRegisteredUsersCountByDateRange(_startdate, _enddate).ToString();
                    _lblMsg.Text = "<b>Registered Subscribers Selected By <font color='green'> DATE RANGE </font><br/>From &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _txtStartDate.Text + "</font><br/> To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _txtEndDate.Text + "</font> <br/>Total &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + total + "</b>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnRegReport.SelectedItem + " from " + _startdate + " to " + _enddate);

                }
                else if (_rbtnRegReport.SelectedValue == "MTH")
                {
                    _gvReportByMonth.Visible = true;
                    _gvReportByMonth.DataSource = RegisteredBroadbandUsers.GetSubscriberRegistrationByMonth().Tables[0];
                    _gvReportByMonth.DataBind();
                    total = regBuser.GetRegisteredUsersCount().ToString();
                    _lblMsg.Text = "<b>Registered Subscribers Selected By<font color='green'> MONTH </font><br/>Total &nbsp;&nbsp;&nbsp; :&nbsp;<font color='red'>" + total + "</b>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnRegReport.SelectedItem);

                }                
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false); 
            }
        }
        
        
        protected void _rbtnRegReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnRegReport.SelectedValue == "DTR")
            {
                _panelDateRange.Enabled = true;
                _panelDateRange.Visible = true;
            }
            else
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
            }
        }

        protected void _imgBtnView_Click(object sender, ImageClickEventArgs e)
        {
            PopulateRegistrationDetails(); 
        }

        protected void _gvReportByMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvReportByMonth.PageIndex = e.NewPageIndex;
            PopulateRegistrationDetails();
        }

      
    }
}
