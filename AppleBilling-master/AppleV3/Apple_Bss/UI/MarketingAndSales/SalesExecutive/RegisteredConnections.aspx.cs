using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.MarketingAndSales.SalesExecutive
{
    public partial class RegisteredConnections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
               // CalendarExtender1.SelectedDate = DateTime.Now.AddMonths(-6);
                CalendarExtender2.SelectedDate = DateTime.Now;
            }
        }
       

        private void ShowRegistrationsByDateRange(String pStatus)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            string _startdate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
            string _enddate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
            try
            {
                _gvActiveConnection.DataSource = RegisteredBroadbandUsers.GetRegisteredSubscriberListByDateRange(Session["EmpID"].ToString(), _startdate, _enddate, pStatus).Tables[0];               
                _gvActiveConnection.DataBind();
                
            }
            catch (Exception ex)
            {               
                Session["ErrorMsg"] = ex.ToString();
               Response.Redirect("~/Error.aspx", false);
            }

        }

        protected void _gvActiveConnection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvActiveConnection.PageIndex = e.NewPageIndex;
            ShowRegistrationsByDateRange(_rbtnStatus.SelectedValue.ToString());

        }

        protected void _btnShowReport_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                _gvActiveConnection.PageIndex = 0;
                ShowRegistrationsByDateRange(_rbtnStatus.SelectedValue.ToString());   
                lblReportMsg.Text = "List of <font color=red> " + _rbtnStatus.SelectedItem.ToString().ToUpper() + "</font> registered broadband users " + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text;

            }
            catch
            {
                throw;
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnStatus.SelectedItem.ToString().ToUpper() + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);
        }
    }
   
}
