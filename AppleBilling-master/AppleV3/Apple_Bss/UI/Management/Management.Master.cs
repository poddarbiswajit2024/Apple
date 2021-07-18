using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.Management
{
    public partial class Management : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Priv"] == null ||!Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.MANAGEMENT))
                {
                    Response.Redirect("~/Default.aspx", false);                    
                }
                
            }
        }
    }
}
