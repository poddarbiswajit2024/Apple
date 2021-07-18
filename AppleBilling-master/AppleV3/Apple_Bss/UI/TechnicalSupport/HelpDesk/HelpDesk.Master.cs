using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class HelpDesk : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Priv"] == null ||!Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.HELPDESK))
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }
    }
}
