using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.SystemManagement
{
    public partial class SystemManage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!Page.IsPostBack)
            //{
                //IF Priv not empty and if it is not authenticated then send to login page
                if (Session["Priv"] == null || !Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.SYSTEMADMIN))
                {
                    Response.Redirect("~/Default.aspx", false);
                }
           // }
        }
    }
}
