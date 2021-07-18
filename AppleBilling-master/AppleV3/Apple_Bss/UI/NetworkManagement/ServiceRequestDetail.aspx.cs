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

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class ServiceRequestDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String _issueid = String.Empty;
            try
            {
                _issueid = Request["issueid"];
                _dvServiceRequestDetail.DataSource = ServiceCalls.GetNmServiceRequestDetail(_issueid).Tables[0];
                _dvServiceRequestDetail.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }

        }


    }
}
