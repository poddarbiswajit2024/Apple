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

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class PaymentCycleChange : System.Web.UI.Page
    {
      protected  static String _userID = String.Empty;
      protected static String SubscriberName = String.Empty;
      protected static String currPayMode = String.Empty;
      protected static String currBillPlan = String.Empty;
      protected static String currBillPlanID = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _panelEditBillPlan.Visible = false;
            
                _panelGridView.Visible = false;                          
            }
        }

    

        #region POPULATE BILL CYCLES

        protected void PopulateBillCycles()
        {

            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");           
            try
            {
                if (currPayMode == "M")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.MONTHLY, currDate).Tables[0];
                }
                else if (currPayMode == "Q")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.QUARTERLY, currDate).Tables[0];
                }

                else if (currPayMode == "H")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.HALFYEARLY, currDate).Tables[0];
                }

                else if (currPayMode == "A")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.ANNUALY, currDate).Tables[0];
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

        #endregion

        #region GET USERDETAILS FOR DISPLAY

        //get the Details of the Subscriber for display 
        protected void _imgBtnGetDetails_Click(object sender, ImageClickEventArgs e)
        {
         
            _panelEditBillPlan.Visible = false;
            _gvBillPlanChangeRequest.Enabled = false;
            _panelGridView.Visible = false;
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
               userDetails += " Subscriber's Name  &nbsp; &nbsp;&nbsp;: <font color=red>" + SubscriberName.ToString().ToUpper() + "</font><br/>";
               userDetails += " Username  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; : <font color=red>" + _txtUserName.Text + "</font><br/>";
               //userDetails += " Payment Mode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;: <font color=red>" + currPayMode + "</font><br/>";
               userDetails += " Current Bill Plan &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <font color=red>" + currBillPlan + "</font>";
               userDetails += "</b></fieldset>";
              _ltrUserInfo.Text = userDetails;
              _txtUserName.Focus();

              lblPresentPaymentCylce.Text = currPayMode;

              //PopulateBillCycles();
              _panelEditBillPlan.Enabled = true;
              _panelEditBillPlan.Visible = true;

               //check fair access plan

              if (bplans.IsFAP)
              {
                  _ddlNewPaymentMode.Enabled = false;
                  _panelEditBillPlan.Visible = false;

                  _lblSuccess.Text = "<b><font color=red>Fair access plan payment plan cannot be changed.</b>";
              }
              

                       
              
            }
            catch (NullReferenceException)
            {
                _panelEditBillPlan.Visible = false;
               
                _panelGridView.Visible = false;      
                _ltrUserInfo.Text = "<font color='red'> Selected username does not exist...</font>";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

                      
        }

        #endregion


        // Plan Change Method
        #region Change payment pLan
       
        protected void _imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
        {
           
            String newPayMode = "";
                      
            try
            {

                if (lblPresentPaymentCylce.Text != _ddlNewPaymentMode.SelectedValue.ToString()) //new payment and old payment cycle should not be the same
                {


                    newPayMode = _ddlNewPaymentMode.SelectedValue.ToString();


                    BroadbandUser buser = new BroadbandUser();
                    buser.ChangePaymentCycle(_userID ,currBillPlanID,currPayMode, newPayMode, Convert.ToInt32(_ddlBillCycle.SelectedValue.ToString()), Session["EmpID"].ToString());
                    _lblSuccess.Text = "<b><font color=green>Payment Cycle Plan Change Successfully registered. </font>";

                    ShowPaymentCycelChangeRequests();
                   
                    try
                    {
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);
                    }
                    catch
                    { }

                    _panelEditBillPlan.Visible = false;
                }
                else
                {
                    _lblSuccess.Text = "<b><font color=red>New and Old Payment Cycle cannot be the same.</b>";
                }

                }
            

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #endregion

        private void ShowPaymentCycelChangeRequests()
        {
            _panelGridView.Visible = true;
            _gvBillPlanChangeRequest.Enabled = true;
            _gvBillPlanChangeRequest.DataSource = BroadbandUser.GetActivePaymentCycleChangeRequests().Tables[0];
            _gvBillPlanChangeRequest.DataBind();
        }

        protected void _lnkBtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ShowPaymentCycelChangeRequests();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEW + LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);

        }

        protected void _ddlNewPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");
            try
            {
                if (_ddlNewPaymentMode.SelectedValue.ToString() == "M")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.MONTHLY, currDate).Tables[0];
                }
                else if (_ddlNewPaymentMode.SelectedValue.ToString() == "Q")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.QUARTERLY, currDate).Tables[0];
                }

                else if (_ddlNewPaymentMode.SelectedValue.ToString() == "H")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.HALFYEARLY, currDate).Tables[0];
                }

                else if (_ddlNewPaymentMode.SelectedValue.ToString() == "A")
                {
                    _ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.ANNUALY, currDate).Tables[0];
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

        protected void _lnkBtnHide_Click(object sender, EventArgs e)
        {
            _panelGridView.Visible = false;
        }
    }
}
