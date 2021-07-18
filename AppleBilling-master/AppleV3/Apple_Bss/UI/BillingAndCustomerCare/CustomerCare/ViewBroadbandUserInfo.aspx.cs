using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare

{
    public partial class ViewBroadbandUserInfo : System.Web.UI.Page
    {
        protected String photo = String.Empty;
        protected String idproof = String.Empty;
        protected String addrressproof = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Request["userid"].ToString();
              try
            {
                BroadbandUser busr = new BroadbandUser();
                _dvBroadbandInfoDetails.DataSource = busr.GetConnectedSubscriberByID(userID);
                _dvBroadbandInfoDetails.DataBind();
                photo = busr.PhotoThumbName;
                idproof = busr.IDProof;
                addrressproof = busr.AddressProof;
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");                
            }
              SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSR, userID);
        }        
    }

     
}
