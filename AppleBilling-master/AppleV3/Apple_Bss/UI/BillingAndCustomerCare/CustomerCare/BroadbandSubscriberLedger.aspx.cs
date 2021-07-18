using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class BroadbandSubscriberLedger : System.Web.UI.Page
    {
        protected double totalCredit;
        protected double totalDebit;
        protected double OutstandingAmount;
        protected String _instAddress = String.Empty;
        protected String _mobileNumber = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        #region Subscriber Ledger Listing

        private void SubscriberLedgersListing(String strUserID) //Listing of Subscriber Ledger
        {
            BroadbandUser rgdUser = new BroadbandUser(strUserID);
            _instAddress = rgdUser.InstallationAddress.ToString();
            _mobileNumber = rgdUser.MobileNumber.ToString();

            BroadbandSubscriberLedgers bbLedger = new BroadbandSubscriberLedgers();
            _gvSubscriberLedger.DataSource = BroadbandSubscriberLedgers.GetSubcriberLedgers(strUserID).Tables[0];
            _gvSubscriberLedger.DataBind();

            //declaring double aray to hold the amounts that is brought from the database and each value is assigned correspondingly 16/03/10 -hopeto
            double[] LedgerAmounts = new double[3];
            LedgerAmounts = bbLedger.GetLedgerAmounts(strUserID);
            totalCredit = LedgerAmounts[0];
            totalDebit = LedgerAmounts[1];
            OutstandingAmount = LedgerAmounts[2];   
        }
        #endregion

        #region Function of Subscriber Ledger Listing for Selected User

        protected void _btnSelectedUser_Click(object sender, ImageClickEventArgs e)
        {
           
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());
            _lblName.Text = "<fieldset><legend style='color:#3b5889'>User Info.</legend><b>Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='Red'>" + _ddlUser.SelectedItem.Text.ToUpper() +
                "</font><br/>User-ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _ddlUser.SelectedValue.ToString() +
                "</font><br/>Installation Address:&nbsp;<font color='red'>" + _instAddress +
                "</font><br/>Contact Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _mobileNumber + "</font></b></fieldset>";
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSR + "Ledger for username : " + _ddlUser.SelectedItem, _ddlUser.SelectedValue);

        }
        #endregion

        #region Handle State of Connected Type

        protected void _btnUserType_Click(object sender, ImageClickEventArgs e) //handle type Select
        {
            if (_ddlUserType.SelectedValue.ToString() == "A") // active Users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.ACTIVE);
                _ddlUser.DataTextField = "USERNAME";
                _ddlUser.DataValueField = "USERID";
                _ddlUser.DataBind();
            }
            else if (_ddlUserType.SelectedValue.ToString() == "P") //permanent disconnected users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.PERMANENTLYDISCONNECTED);
                _ddlUser.DataTextField = "USERNAME";
                _ddlUser.DataValueField = "USERID";
                _ddlUser.DataBind();
            }
            else if (_ddlUserType.SelectedValue.ToString() == "T") // temporary disconnected users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.TEMPORARILYDISCONNECTED);
                _ddlUser.DataTextField = "USERNAME";
                _ddlUser.DataValueField = "USERID";
                _ddlUser.DataBind();
            }

            else if (_ddlUserType.SelectedValue.ToString() == "D") //Deactivated Users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.DEACTIVATED);
                _ddlUser.DataTextField = "USERNAME";
                _ddlUser.DataValueField = "USERID";
                _ddlUser.DataBind();
            }
        }

        #endregion

        protected void _gvSubscriberLedger_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvSubscriberLedger.PageIndex = e.NewPageIndex;
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());

        }
      
    }
}
