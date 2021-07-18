using Apple_Bss.CodeFile;
using System;
using System.Globalization;
using System.Web.UI;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class BillRaised : System.Web.UI.Page
    {
        protected String userid;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    userid = Utilities.QueryStringDecode(Request["id"].ToString());
                    _lblMsg.Visible = false;
                    ShowUserDetails(userid);
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }

        private void ShowUserDetails(String pStrUserID)
        {
            try
            {
                RegisteredBroadbandUsers penreguser = new RegisteredBroadbandUsers(pStrUserID);
                _tbCustomerName.Text = penreguser.Name;
                _tbUserName.Text = penreguser.UserName;
                _tbConnDate.Text = penreguser.ConnectionDate;
                _txtUserGSTIN.Text = penreguser.UserGSTIN;

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _btnConnect_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            try
            {

                BroadbandUser user = new BroadbandUser();
                //double securityDepositCollected =

                String billnumber = user.RaiseBill(Utilities.QueryStringDecode(Request["id"].ToString()), _tbUserName.Text, _tbConnDate.Text, Convert.ToDouble(_tbOTRCDiscount.Text), Convert.ToDouble(_tbSecuriityDepositWaiver.Text), Convert.ToDouble(_tbOtherWaivers.Text), Convert.ToDouble(_tbPersistentWaiver.Text), Convert.ToDouble(_tbExtraOFCLength.Text), Convert.ToDouble(_tbExtraCAT5Length.Text), Convert.ToDouble(_tbSecuriityDepositWaiver.Text), false, Session["EmpID"].ToString());              
                try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLRAISEDFIRST + _tbUserName.Text);
                }
                catch
                { }

                Response.Redirect("ConfirmConnection.aspx?bn=" + billnumber, false);

            }

            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }


        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
           
            _tbExtraCAT5Length.Text = "";
            _tbExtraOFCLength.Text = "";
            _tbOtherWaivers.Text = "";
            _tbOTRCDiscount.Text = "";
            _tbPersistentWaiver.Text = "";
            _tbSecuriityDepositWaiver.Text = "";
            _tbUserName.Text = "";
        }

    }
}
