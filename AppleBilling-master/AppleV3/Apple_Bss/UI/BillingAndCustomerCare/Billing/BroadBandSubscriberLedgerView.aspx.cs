using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class BroadBandSubscriberLedgerView : System.Web.UI.Page
    {
        //protected String totalCredit = String.Empty;
       // protected String totalDebit = String.Empty;
       // protected String OutstandingAmount = String.Empty;
        protected double totalCredit;
        protected double totalDebit;
        protected double OutstandingAmount;
        protected String _instAddress=String.Empty;
        protected String _mobileNumber=String.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            _btnSelectedDelete.Visible = false;
        }

        #region Subscriber Ledger Listing

        private void SubscriberLedgersListing(String strUserID) //Listing of Subscriber Ledger
        {
             BroadbandUser rgdUser = new BroadbandUser (strUserID);
            _instAddress = rgdUser.InstallationAddress.ToString();
            _mobileNumber = rgdUser.MobileNumber.ToString();

            BroadbandSubscriberLedgers bbLedger=new BroadbandSubscriberLedgers();
            _gvSubscriberLedger.DataSource = BroadbandSubscriberLedgers.GetSubcriberLedgers(strUserID).Tables[0];
            _gvSubscriberLedger.DataBind();
            _btnSelectedDelete.Visible = true;
            /*
            totalCredit = bbLedger.GetTotalCredit(strUserID).ToString();
            totalDebit = bbLedger.GetTotalDebit(strUserID).ToString();
           OutstandingAmount=bbLedger.GetTotalOutstanding(strUserID).ToString(); 
             */

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
            _btnSelectedDelete.Visible = true;           
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());
            _lblName.Text = "<fieldset><legend style='color:#3b5889'>User Info.</legend><b>Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='Red'>" + _ddlUser.SelectedItem.Text.ToUpper() +
                "</font><br/>User-ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _ddlUser.SelectedValue.ToString() +
                "</font><br/>Installation Address&nbsp;:&nbsp;<font color='red'>" + _instAddress + "</font><br/>Contact Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _mobileNumber + "</font></b> </fieldset>";
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSR + "Ledger for username : " + _ddlUser.SelectedItem, _ddlUser.SelectedValue);

        }
        #endregion

        #region Handle State of Connected Type

        protected void _btnUserType_Click(object sender, ImageClickEventArgs e) //handle type Select
        {
            if (_ddlUserType.SelectedValue.ToString() == "A") // active Users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.ACTIVE);                
            }
            else if (_ddlUserType.SelectedValue.ToString() == "P") //permanent disconnected users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.PERMANENTLYDISCONNECTED);
           }
            else if (_ddlUserType.SelectedValue.ToString() == "T") // temporary disconnected users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.TEMPORARILYDISCONNECTED);
           }
            // this option not being used now 
                 else if (_ddlUserType.SelectedValue.ToString() == "D") //Deactivated Users
                {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.DEACTIVATED);
                     
                }

            else if (_ddlUserType.SelectedValue.ToString() == "N") //Deactivated Users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.FORCEDDISCONNECTION);

            }
            else if (_ddlUserType.SelectedValue.ToString() == "Z") //Deactivated Users
            {
                _ddlUser.DataSource = BroadbandUser.GetSubscribers(BroadbandUserStatus.ALLDISCONNECTED);

            } 
            _ddlUser.DataTextField = "USERNAME";
            _ddlUser.DataValueField = "USERID";
            _ddlUser.DataBind();
        }

        #endregion

        #region To Delete Multiple rows by seleting the CheckBox

        private void DeleteSelectedRows()
        {
            //Create String Collection to store UserId's Of Records to Delete 

            StringCollection strCheckedCollection = new StringCollection();
            string strChecked = string.Empty;

            //Loop through GridView rows to find checked rows 

            foreach (GridViewRow row in _gvSubscriberLedger.Rows)
            {
                CheckBox chkDelete = (CheckBox)row.FindControl("chkSelect");
                if (chkDelete != null)
                {
                    if (chkDelete.Checked) //Check if the Checkbox is Selected
                    {
                        strChecked ="'" + _gvSubscriberLedger.DataKeys[row.RowIndex].Value.ToString() + "'";//gets the Id of the field to Be Deleted                    
                        strCheckedCollection.Add(strChecked);  //Add the selected checkbox value to Collection 
                    }

                }
            }
             
            //Call the method to Delete records 
            BroadbandSubscriberLedgers delCheck = new BroadbandSubscriberLedgers();
            delCheck.DeleteBroadBandSubscriberLedgers(strCheckedCollection);

            // rebind the GridView
            _gvSubscriberLedger.DataBind();
        }


        protected void btnDelete_Click(object sender, ImageClickEventArgs e) //delete button inside gridview
        {
            DeleteSelectedRows();
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());
        }

        protected void _btnSelectedDelete_Click(object sender, ImageClickEventArgs e) //Delete Button outside of GridView
        {
            DeleteSelectedRows();
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());
        }

        #endregion

        //gridview page index changing
        protected void _gvSubscriberLedger_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            _gvSubscriberLedger.PageIndex = e.NewPageIndex;
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());

        }

        //GridView Row Deleting
        protected void _gvSubscriberLedger_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvSubscriberLedger.PageIndex;
            SubscriberLedgersListing(_ddlUser.SelectedValue.ToString());
            _gvSubscriberLedger.PageIndex = pagenum;
        }

       
       
    }
}

