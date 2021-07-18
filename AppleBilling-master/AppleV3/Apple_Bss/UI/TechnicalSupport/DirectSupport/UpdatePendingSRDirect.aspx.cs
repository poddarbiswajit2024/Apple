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

namespace Apple_Bss.UI.TechnicalSupport.DirectSupport
{
    public partial class UpdatePendingSRDirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String issueid = String.Empty;

            try
            {
                issueid = Request["issueid"].ToString();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            _actionHistory.IssueID = issueid;
        }
    }
}
