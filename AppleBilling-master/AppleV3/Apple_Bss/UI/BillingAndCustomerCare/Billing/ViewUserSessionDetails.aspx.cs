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

namespace Symb_InetBill.UI.BillingAndCustomerCare.Billing
{
    public partial class ViewUserSessionDetails : System.Web.UI.Page
    {
        protected static String _userID = String.Empty;
        protected static String SubscriberName = String.Empty;
        protected static String currPayMode = String.Empty;
        protected static String currBillPlan = String.Empty;
        protected static String currBillPlanID = String.Empty;
        protected static String totDownloadData= String.Empty;
        protected static String totUploadData = String.Empty;
        protected static String TotalDataTransfer = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _lblBillCycle.Visible = false;
                _ddlBillCycle.Visible = false;
                ImgBtnView.Visible = false;
                _panelGridview.Visible = false;
            }
        }

        private void ShowDataTransferDetails()
        {
            try
            {
                _gvDataTransferDetails.DataSource = SessionDetails.GetSessionDetailsByPaymentMode(Convert.ToInt32(_ddlBillCycle.SelectedValue),currPayMode,_userID).Tables[0];
                _gvDataTransferDetails.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

      
        //Method to Bind Bill Cycle to Drop DownList 
        //Modified by Zeko
        //Date: 16th April 2010
        protected void PopulateBillCycles()
        {

            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            BillCycles bc = new BillCycles();
            try
            {
                if (currPayMode == "M")
                {
                    _ddlBillCycle.DataSource =bc.GetBillCycleForListing(BillCycleType.MONTHLY,currDate).Tables[0];
                }
                else if (currPayMode == "Q")
                {
                    _ddlBillCycle.DataSource = bc.GetBillCycleForListing(BillCycleType.QUARTERLY, currDate).Tables[0];
                }

                else if (currPayMode == "H")
                {
                    _ddlBillCycle.DataSource = bc.GetBillCycleForListing(BillCycleType.HALFYEARLY, currDate).Tables[0];
                }

                else if (currPayMode == "A")
                {
                    _ddlBillCycle.DataSource = bc.GetBillCycleForListing(BillCycleType.ANNUALY, currDate).Tables[0];
                }

                _ddlBillCycle.DataTextField = "billcyclename";
                _ddlBillCycle.DataValueField = "billcycleid";
                _ddlBillCycle.DataBind();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #region Populate UserDetails
        
        protected void _imgBtnGetDetails_Click(object sender, ImageClickEventArgs e)
        {
            _lblBillCycle.Visible = true; 
            _ddlBillCycle.Visible = true;
            ImgBtnView.Visible = true;
            _panelGridview.Visible = false;
            _ltrUserInfo.Visible = true;
            try
            {
                string[] details = new string[2];
                details = BroadbandUser.GetSubscriberDetails(_txtUserName.Text);

                //get the user id from the string array . Array position [0] holds= username and [1] holds = USERID 
                SubscriberName = details[0];
                _userID = details[1];

                BroadbandUser buser = new BroadbandUser(_userID);
                currBillPlanID = buser.BillPlanID;
                BroadbandBillPlans bplans = new BroadbandBillPlans(currBillPlanID);
                currBillPlan = bplans.PackageName;
                //get payment mode of Subscriber
                currPayMode = BroadbandUserBillingInfo.PaymentModeListing(_userID);
                String userDetails = "<fieldset><legend style='color:#3b5889'> Current Bill Plan Details</legend>";
                userDetails += "<b>UserID &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <font color=red> " + _userID.ToString().ToUpper() + "</font><br/>";
                userDetails += " Subscriber's Name  &nbsp;&nbsp;&nbsp; : <font color=red>" + SubscriberName.ToString().ToUpper() + "</font><br/>";
                userDetails += " Username  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; : <font color=red>" + _txtUserName.Text + "</font><br/>";
                userDetails += " Payment Mode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;: <font color=red>" + currPayMode + "</font><br/>";
                userDetails += " Current Bill Plan &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <font color=red>" + currBillPlan + "</font>";
                userDetails += "</b></fieldset>";
                _ltrUserInfo.Text = userDetails;
                _txtUserName.Focus();               
                PopulateBillCycles();
            }
            catch (NullReferenceException)
            {
                _lblBillCycle.Visible = false;
                _ddlBillCycle.Visible = false;
                ImgBtnView.Visible = false;
                _panelGridview.Visible = false;
                _ltrUserInfo.Text = "<font color='red'> Selected username does not exist...</font>";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
       
        #endregion

        #region Display the Datatransfer details on the Grid

        protected void ImgBtnView_Click(object sender, ImageClickEventArgs e)
        {
            _panelGridview.Visible = true;
            ShowDataTransferDetails();
            GetSumOfDataTransfers();
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VDATATRANSFER + SubscriberName, _userID);
        }


        protected void GetSumOfDataTransfers()
        {
            try
            {
                string[] datatransfers = new string[3];
                datatransfers = SessionDetails.GetSumOfDataTransfer(Convert.ToInt32(_ddlBillCycle.SelectedValue), currPayMode, _userID);
               
                totUploadData = datatransfers[0];
                totDownloadData = datatransfers[1];
                TotalDataTransfer = datatransfers[2];
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #endregion

      
    }
}
