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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Apple_Bss.CodeFile;
using System.IO;
using System.Threading;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ViewSubscriberBill : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();
        }
        
        protected void _btnGetBillNumber_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            if (BroadbandUser.IsValidUserID(strUserID))
            {              
                try
                {
                    _lblValidUser.Visible = false;
                    BroadbandUser buser = new BroadbandUser(strUserID);
                    _txtUserName.Text = buser.UserName;
                    String _mobileNumber = buser.MobileNumber.ToString();
                    String _name = buser.Name.ToString();
                    String _instAddress = Server.HtmlDecode(buser.InstallationAddress.ToString());
                    _lblName.Text = "<fieldset><legend style='color:#3b5889'>Bill Info.</legend><b>Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='Red'>" + _name.ToUpper() + "</font><br/>User-ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + strUserID + "</font><br/>Contact Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _mobileNumber + "</font></b></fieldset>";
                    _gvBillDetails.DataSource = BroadbandUser.GetCustomerBillNumber(strUserID).Tables[0];
                    _gvBillDetails.DataBind();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSR + LogEvents.BILL + _txtUserName.Text, strUserID);

            }
            else
            {
                _lblValidUser.Visible = true;
                _lblValidUser.Text = "<font color='red'> Invalid User ID:</font>";
            }
        }

      
    }
}
