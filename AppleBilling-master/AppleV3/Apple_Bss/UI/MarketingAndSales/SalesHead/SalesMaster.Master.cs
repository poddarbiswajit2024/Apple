using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class SalesMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Priv"] == null || !Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.SALESHEAD))
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //check wheter browser supports cookies and remember me cookie exists
            if ((Request.Browser.Cookies) && (Request.Cookies["clntlddkfjfnv"] != null))
            {
                //delete the cookies when logging out            
                Response.Cookies["clntlddkfjfnv"].Expires = DateTime.Now.AddDays(-20);
            }

            try//write to log events
            {
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.LOGOUT);
            }
            catch
            {
                //what to do : throw exception or do something else
                //do nothing on write log event exception
            }

            Session.Abandon();
            Session.Clear();
            //clear the cache of the browser
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);  // set date for  clearing the cache
            Response.Cache.SetNoStore();

            Response.Redirect("~/Default.aspx", false);

        }
    }
}