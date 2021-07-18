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
using System.Xml.Linq;

namespace Symb_InetBill.UI.Management
{
    public partial class MgmtMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //session already checked from master page, now if that validated privilege is that of executive director then make extra feature visible 
                if (Session["Priv"]!=null && Session["Priv"].ToString() == "0")
                {
                   // SystemUserMenu1.Visible = true;
                }
            }

        }
    }
}