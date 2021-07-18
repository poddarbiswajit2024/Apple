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

namespace Apple_Bss.UI.TechnicalSupport.DirectSupport
{
    public partial class ServiceRequestsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    
                    ShowPendingServiceRequests();
                   
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
        }

        private void ShowPendingServiceRequests()
        {
            //display all pending status from oldest to newest
            //changing it to newest to oldest 25/04/2017
            _gvViewServiceRequestReport.DataSource = ServiceCalls.GetPendingServiceRequests().Tables[0];
            _gvViewServiceRequestReport.DataBind();
        }


       
       
        protected void _gvViewServiceRequestReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvViewServiceRequestReport.PageIndex = e.NewPageIndex;
            ShowPendingServiceRequests();

        }
       
    }
}
