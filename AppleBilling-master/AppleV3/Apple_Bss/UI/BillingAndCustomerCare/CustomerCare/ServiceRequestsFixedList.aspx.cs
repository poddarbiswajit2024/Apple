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
    public partial class ServiceRequestsFixedList : System.Web.UI.Page
    {
        ServiceCalls toverify = new ServiceCalls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    ShowFixedServiceRequests();
                   
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
        }

        private void ShowFixedServiceRequests()
        {
            //display all fixed status from oldest to newest
            _gvViewServiceRequestReport.DataSource = toverify.GetFixedServiceRequestList().Tables[0];
            _gvViewServiceRequestReport.DataBind();
        }


       
       
        protected void _gvViewServiceRequestReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvViewServiceRequestReport.PageIndex = e.NewPageIndex;
            ShowFixedServiceRequests();

        }
       
    }
}
