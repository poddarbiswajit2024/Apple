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
using System.Globalization;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class BillPlanChangeWithoutCharges : System.Web.UI.Page
    {
      protected  static String _userID = String.Empty;
      protected static String SubscriberName = String.Empty;
      protected static String currPayMode = String.Empty;
      protected static String newPayMode = String.Empty;
      protected static String currBillPlan = String.Empty;
      protected static String currBillPlanID = String.Empty;
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                _panelEditBillPlan.Visible = false;           
                _panelGridView.Visible = false;
                _txtUserName.Focus();
                _lblArrear.Visible = false;
                _lblWaiver.Visible = false;
                _lblTotalArrear.Visible = false;
                _lblTotalWaiver.Visible = false;
               
            }
        }

 
        /*
        #region POPULATE BILL CYCLES
        //bringing only monthly bill cycles only
        protected void PopulateBillCycles()
        {

            String currDate = System.DateTime.Now.ToString("MM-dd-yyyy");           
            try
            {
                //if (currPayMode == "M")
                //{
                    //_ddlBillCycle.DataSource = BillCycles.GetBillCycleName(BillCycleType.MONTHLY, currDate).Tables[0];
                    _ddlBillCycle.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.MONTHLY).Tables[0];
                 
               // }
                //else if (currPayMode == "Q")
                //{
                //    _ddlBillCycle.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.QUARTERLY).Tables[0];
                //}

                //else if (currPayMode == "H")
                //{
                //    _ddlBillCycle.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.HALFYEARLY).Tables[0];
                //}

                //else if (currPayMode == "A")
                //{
                //    _ddlBillCycle.DataSource = BillCycles.GetUnbilledBillCycleList(BillCycleType.ANNUALY).Tables[0];
                //}

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
        */
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
                   userDetails += " Payment Mode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;: <font color=red>" + currPayMode + "</font><br/>";
             
                   userDetails += "</b></fieldset>";
                  _ltrUserInfo.Text = userDetails;
                  _txtUserName.Focus();             
                     
                  //  PopulateBillCycles();
                    lblPresentBillPlan.Text = currBillPlan;
                    //get current payment mode - M, Q, H, A
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

                _panelEditBillPlan.Enabled = true;
                _panelEditBillPlan.Visible = true;

                //show previous plan bill plan change request
                ShowBillPlanChangeRequests(_txtUserName.Text);
                //show fairaccess bill plans by default
                DisplayFairAccessBillplans();
            
            }

            #endregion
        //Bill Plan Change Method
            #region Change Bill pLan
       
            protected void _imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
            {
                CultureInfo ci = new CultureInfo("en-GB");
                Int32  currentbillcycle = -1;
                TariffPlanChange buser = new TariffPlanChange();
           
                try
                {
                    //ccurrent billplanID and new billplanID || currrent Payment Mode and New PaymentMode should not match on Plan Change

                    //initial validations
                    if (currBillPlanID != _ddlNewBillPlans.SelectedValue.ToString())
                    {
                        if (Convert.ToInt32(_ddlBillCycle.SelectedValue) >= currentbillcycle)
                        {

                            #region For exisitng monthly plan users
                            if (currPayMode == "M")//for all cycles other than monthly
                            {
                                //check whether bill plan change is scheduling or imediate - next month selection 1st date means scheduling, else all other immdeiate
                                if (chkBoxChangeNextBillCycle.Checked) //then plan change to take effect only next month
                                {
                                    buser.ScheduleChangeBillPlanForNextBillCycleWithoutCharges(_userID, currBillPlanID, _ddlNewBillPlans.SelectedValue.ToString(), currPayMode, newPayMode, Convert.ToInt32(_ddlBillCycle.SelectedValue.ToString()), Session["EmpID"].ToString());
                                    _lblSuccess.Text = "<b><font color=green>Bill plan change request successfully registered.It will be changed in the next billing cycle</font></b>";
                                }

                                else
                                {
                                    //CHANGE THE BILL PLAN
                                    buser.ChangeBillPlanWithoutCharges(_userID, currBillPlanID, _ddlNewBillPlans.SelectedValue.ToString(), currPayMode, newPayMode, Convert.ToInt32(_ddlBillCycle.SelectedValue.ToString()), Session["EmpID"].ToString(), Convert.ToDateTime(datepicker.Value, ci).ToShortDateString());
                                    _lblSuccess.Text = "<b><font color=green>Bill plan successfully changed.</font></b>";

                                  


                                }


                            }
                            #endregion

                        }
                    }
                }



                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY"))
                    {
                        _lblSuccess.Text = "<b><font color=Red> Bill plan change request not allowed! It has already been put up for the same user and billing cycle.</font>";

                    }
                    else
                    {
                        Session["ErrorMsg"] = ex.ToString();
                        Response.Redirect("~/Error.aspx", false);
                    }

                }

                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
        

            
                                                    try
                                    {
                                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);
                                        //by default username is selected na
                                        ShowBillPlanChangeRequests(_txtUserName.Text);
                                    }
                                    catch
                                    { }

                                    _panelEditBillPlan.Visible = false;
            }


            #endregion


        private void ShowBillPlanChangeRequests(string pusername)
        {
            _panelGridView.Visible = true;
            _gvBillPlanChangeRequest.Enabled = true;
            _gvBillPlanChangeRequest.DataSource = BroadbandUser.GetBillPlanChangeRequests(pusername).Tables[0];
            _gvBillPlanChangeRequest.DataBind();
        }

        private void ShowBillPlanChangeRequests()
        {
            _panelGridView.Visible = true;
            _gvBillPlanChangeRequest.Enabled = true;
            _gvBillPlanChangeRequest.DataSource = BroadbandUser.GetActiveBillPlanChangeRequests().Tables[0];
            _gvBillPlanChangeRequest.DataBind();
        }

        protected void _lnkBtnShow_Click(object sender, EventArgs e)
        {
            try
            {

                ShowBillPlanChangeRequests();
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

        protected void _lnkBtnHide_Click(object sender, EventArgs e)
        {
            _panelGridView.Visible = false;
        }
        
        private void DisplayFairAccessBillplans()
        {
            if (chkboxPlanFairAccess.Checked)
            {
                newPayMode = "M";
            }
            else
            {
                newPayMode = currPayMode;

            }
            _ddlNewBillPlans.DataSource = BroadbandBillPlans.GetBillPlanList(chkboxPlanFairAccess.Checked).Tables[0];
            _ddlNewBillPlans.DataTextField = "PACKAGENAME";
            _ddlNewBillPlans.DataValueField = "BILLPLANID";
            _ddlNewBillPlans.DataBind();
        }

        protected void chkboxPlanFairAccess_CheckedChanged(object sender, EventArgs e)
        {
            DisplayFairAccessBillplans();
        }


        protected void chkboxPlanNormal_CheckedChanged(object sender, EventArgs e)
        {

            if (chkboxPlanNormal.Checked)
            {
                newPayMode = currPayMode;
            }

            _ddlNewBillPlans.DataSource = BroadbandBillPlans.GetBillPlanList(!chkboxPlanNormal.Checked).Tables[0];
            _ddlNewBillPlans.DataTextField = "PACKAGENAME";
            _ddlNewBillPlans.DataValueField = "BILLPLANID";
            _ddlNewBillPlans.DataBind();

        }

        protected void _gvBillPlanChangeRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvBillPlanChangeRequest.PageIndex = e.NewPageIndex;
            //if it is for a particular usernaem
            if (_txtUserName.Text != "")
            {
                ShowBillPlanChangeRequests(_txtUserName.Text);

            }
            else//for all users
            {
                ShowBillPlanChangeRequests();
            }
           
        }

        protected void chkBoxChangeNextBillCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxChangeNextBillCycle.Checked)
            {
                datepicker.Value = "";
                datepicker.Disabled = true;
            }
            else
            {
                datepicker.Disabled = false;
            }
        }


    }
}
