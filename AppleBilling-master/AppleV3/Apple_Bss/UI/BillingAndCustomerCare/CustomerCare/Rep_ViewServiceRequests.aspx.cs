using Apple_Bss.CodeFile;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class Rep_ViewServiceRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void ShowServiceRequests()
        {
            CultureInfo ci = new CultureInfo("en-GB");

            string _startdate =  Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
            string _enddate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
            try
            {
                ServiceCallStatus status = ServiceCallStatus.ALL;

                if (_ddlSupportType.SelectedValue == "P")
                {
                    status = ServiceCallStatus.PENDING;
                }
                else if (_ddlSupportType.SelectedValue == "R")
                {
                    status = ServiceCallStatus.RESOLVED;
                }
                else if(_ddlSupportType.SelectedValue =="F")
                {
                    status = ServiceCallStatus.FIXED;
                }
                //else default status is all

                _gvViewServiceRequestReport.DataSource = ServiceCalls.GetServiceRequestsForHelpDesk( _startdate, _enddate, status).Tables[0];
                _gvViewServiceRequestReport.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void _btnShowReport_Click(object sender, ImageClickEventArgs e)
        {
            ShowServiceRequests();
            //added here instead of inside showservicerequest method to avoid repeat logs on page index changing of the gridview
            //removed log 17 dec 2019 - to use only inserted updated logs only
           // SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VSERVICEREQUESTS + _ddlSupportType.SelectedItem + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

        }

        protected void _gvViewServiceRequestReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvViewServiceRequestReport.PageIndex = e.NewPageIndex;
            ShowServiceRequests();

        }

     
        }
       
  
}
