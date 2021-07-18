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
    public partial class PendingSRConfirmationDirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String userid = Utilities.QueryStringDecode(Request["id"].ToString());
                    String datetime = Utilities.QueryStringDecode(Request["dt"].ToString());
                    Label1.Text = ServiceCalls.GetSRNumber(userid, datetime);
                    try
                    {
                        //for "P" condition log added
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST , userid);
                    }
                    catch
                    {
                        //do nothing for now
                    }
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
