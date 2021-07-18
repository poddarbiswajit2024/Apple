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
    public partial class MonthRegDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String bCycleID = Request["cid"].ToString();
                String bCycleName = BillCycles.GetBillCycleName(bCycleID).ToUpper();               
                try
                {
                    _gvMonthRegDisplay.DataSource = RegisteredBroadbandUsers.GetMonthWiseRegistation(bCycleID).Tables[0];
                    _gvMonthRegDisplay.DataBind();
                    _lblStatus.Text = bCycleName;
                }
                catch(Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false); 
                }
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWMONTHLYREGISTRATION + bCycleName);
            }
        }
    }
}
