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
namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ViewDTUsageBreakUp : System.Web.UI.Page
    {
        protected static String totDownloadData = String.Empty;
        protected static String totUploadData = String.Empty;
        protected static String TotalDataTransfer = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bCycleID = Convert.ToInt32(Request["bcID"]);
                String _userID = Request["uid"].ToString();
                String currPayMode = Request["pm"].ToString();
                BroadbandUser buser = new BroadbandUser(_userID);
                String userName = buser.UserName;
                String name = buser.Name;
                _lblStatus.Text = "Name :<font color=red>&nbsp;" + name + "</font>&nbsp; &nbsp; UserName :<font color=red>&nbsp;"+userName+"</font>";
                try
                {
                    _gvDataTransferDetails.DataSource = SessionDetails.GetSessionDetailsByPaymentMode(bCycleID, currPayMode, _userID).Tables[0];
                    _gvDataTransferDetails.DataBind();

                    string[] datatransfers = new string[3];
                    datatransfers = SessionDetails.GetSumOfDataTransfer(bCycleID, currPayMode, _userID);

                    totUploadData = datatransfers[0];
                    totDownloadData = datatransfers[1];
                    TotalDataTransfer = datatransfers[2];
                }
                catch (NullReferenceException)
                {                   
                    _lblStatus.Text = "<font color='red'> An error has occured: please contact your admin...</font>";
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
