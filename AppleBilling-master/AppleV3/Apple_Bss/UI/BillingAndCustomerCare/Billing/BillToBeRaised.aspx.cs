using Apple_Bss.CodeFile;
using System;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class BillToBeRaised : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowPendingConnections();
            }
        }

        private void ShowPendingConnections()
        {
            try
            {
                _gvPendingConnections.DataSource = RegisteredBroadbandUsers.GetConnectedUsersForBilling().Tables[0];
                _gvPendingConnections.DataBind();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _gvPendingConnections_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvPendingConnections.PageIndex = e.NewPageIndex;
            ShowPendingConnections();

        }
    }
}
