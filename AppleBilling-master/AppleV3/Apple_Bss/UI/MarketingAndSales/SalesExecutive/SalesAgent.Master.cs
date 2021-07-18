﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.MarketingAndSales.SalesExecutive
{
    public partial class SalesAgent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Priv"] == null || !Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.SALESEXEC))
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }
    }
}
