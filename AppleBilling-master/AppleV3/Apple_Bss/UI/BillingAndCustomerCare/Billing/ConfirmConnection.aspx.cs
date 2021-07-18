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

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ConfirmConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String bn = Request["bn"].ToString();
                    String link = String.Format("<strong><a href=javascript:openPopup('{0}')>{1}</a></strong>", "ViewSubscriberFirstBill.aspx?bn=" + bn, bn);
                    Literal1.Text = link;
                    //HyperLink1.NavigateUrl = link; 
 
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }
    }
}
