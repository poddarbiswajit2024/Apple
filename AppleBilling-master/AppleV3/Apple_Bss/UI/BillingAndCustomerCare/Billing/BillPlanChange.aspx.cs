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
    public partial class BillPlanChange : System.Web.UI.Page
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
                //_ddlNewBillPlans.Items.Insert(0, new ListItem("Select New Bill Plan", "NA"));

            }
        //    _ddlNewBillPlans.Items[0].Attributes.Add("disabled", "disabled");


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
                 _lblSuccess.Text = _lblArrear.Text = _lblTotalArrear.Text = _lblTotalWaiver.Text = _lblWaiver.Text = "";
                try
                {
                    string[] details = new string[2];
                    details = BroadbandUser.GetSubscriberDetailsandNextBillingCycle(_txtUserName.Text);

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
                
                lblNextBillCycle.Text = details[4];//cycle name
                lblNextBillCycle.ToolTip = details[3];//cycleid
                hdnFieldNextBillCycleStartDate.Value = details[5];                     
                  //  PopulateBillCycles();
                    lblPresentBillPlan.Text = currBillPlan;
                //get current payment mode - M, Q, H, A   
                if (currPayMode == "M")
                {
                    _rbBILLCYCLE.SelectedValue = "M";
                    datepicker.Disabled = false;
                    chkBoxChangeNextBillCycle.Checked = false;                 
                }
                else
                {
                    _rbBILLCYCLE.SelectedValue = currPayMode;
                    datepicker.Disabled = true;
                    chkBoxChangeNextBillCycle.Checked = true;
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
          //  Int32 currentbillcycle = -1;
            TariffPlanChange buser = new TariffPlanChange();
            _lblArrear.Visible = true;
            _lblWaiver.Visible = true;
            _lblTotalArrear.Visible = true;
            _lblTotalWaiver.Visible = true;
            Int32 nextBillCycleID = Convert.ToInt32(lblNextBillCycle.ToolTip);
                try
                {
                if (Page.IsValid)
                {
                    //current billplanID and new billplanID || currrent Payment Mode and New PaymentMode should not match on Plan Change
                    //initial validations
                    if ((((currBillPlanID != _ddlNewBillPlans.SelectedValue.ToString())  && _ddlNewBillPlans.SelectedValue !="")) || currPayMode != _rbBILLCYCLE.SelectedValue)
                    {
                        //   if (Convert.ToInt32(lblNextBillCycle.ToolTip) >= currentbillcycle)
                        if (datepicker.Value != "" || chkBoxChangeNextBillCycle.Checked)
                        {
                            if (_rbBILLCYCLE.SelectedItem.Value == "M")
                            {
                                try
                                {
                                    //check whether bill plan change is scheduling or imediate - next month selection 1st date means scheduling, else all other immdeiate
                                    if (chkBoxChangeNextBillCycle.Checked) //then plan change to take effect only next month
                                    {
                                        if (buser.CheckBillPlanChangeRequestExists(_userID, nextBillCycleID) == false)
                                        {
                                            buser.ScheduleChangeBillPlanForNextBillCycle(_userID, currBillPlanID, _ddlNewBillPlans.SelectedValue.ToString(), currPayMode, newPayMode, Convert.ToInt32(lblNextBillCycle.ToolTip), rblSecurityDepositType.SelectedValue, Session["EmpID"].ToString());
                                            _lblSuccess.Text = "<b><font color=green>Bill plan change request successfully registered.It will be changed in the next billing cycle</font></b>";

                                            try
                                            {
                                                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);
                                                //by default username is selected na
                                                ShowBillPlanChangeRequests(_txtUserName.Text);
                                                //_lblSuccess.Text = "<b><font color=Red> Bill plan change request not allowed! Please Select New Plan Or Bill Cycle</font>";
                                            }
                                            catch
                                            { }
                                        }
                                        else
                                        {
                                            _lblSuccess.Text = "<b><font color=Red> Error: Bill plan change already exists for this user from next bill month!</font></b>";
                                        }
                                    }
                                    else
                                    {
                                        //CHANGE BILL FUNCTION
                                        buser.ChangeBillPlan(_userID, currBillPlanID, _ddlNewBillPlans.SelectedValue.ToString(), currPayMode, newPayMode, Convert.ToInt32(lblNextBillCycle.ToolTip), rblSecurityDepositType.SelectedValue, Session["EmpID"].ToString(), Convert.ToDateTime(datepicker.Value, ci).ToString("yyyy-MM-dd"));
                                        _lblSuccess.Text = "<b><font color=green>Bill plan successfully changed.</font></b>";                                    
                                    }

                                    _lblArrear.Text = buser.STRRemarks;
                                    _lblWaiver.Text = buser.STRRemarks2;

                                    if (buser.TotalArear > 0)
                                    {
                                        _lblTotalArrear.Text = "Total arrear = " + (buser.TotalArear).ToString();
                                    }
                                    else if (buser.TotalArear < 0)
                                    {
                                        _lblTotalWaiver.Text = "Total waiver = " + (buser.TotalWaiver).ToString();
                                    }
                                    try
                                    {
                                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);
                                        //by default username is selected na
                                        ShowBillPlanChangeRequests(_txtUserName.Text);
                                        //_lblSuccess.Text = "<b><font color=Red> Bill plan change request not allowed! Please Select New Plan Or Bill Cycle</font>";
                                    }
                                    catch
                                    { }

                                }
                                catch (Exception ex)
                                {
                                    Session["ErrorMsg"] = _lblSuccess.ToolTip = ex.ToString();
                                    _lblSuccess.Text = "<b><font color= red>Error! An exception occured! </font></b>";
                                }
                            }
                            else//NON-Monthly
                            {
                                newPayMode = _rbBILLCYCLE.SelectedValue;
                                if (chkBoxChangeNextBillCycle.Checked) //then plan change to take effect only next month
                                {
                                    if (buser.CheckBillPlanChangeRequestExists(_userID, nextBillCycleID) == false)
                                    {
                                        string newbillplanid;
                                        if (_ddlNewBillPlans.SelectedValue !="")
                                        {
                                            newbillplanid = _ddlNewBillPlans.SelectedValue.ToString();
                                        }
                                        else
                                        {
                                            newbillplanid = currBillPlanID;
                                        }

                                        buser.ScheduleChangeBillPlanForNextBillCycleForNonMonthlyUsers(_userID, currBillPlanID, newbillplanid, currPayMode, newPayMode, nextBillCycleID, rblSecurityDepositType.SelectedValue, hdnFieldNextBillCycleStartDate.Value, Session["EmpID"].ToString());
                                        _lblSuccess.Text = "<b><font color=green>Bill plan change request successfully registered. It will be changed in the next billing cycle.</font></b>";

                                        _lblArrear.Text = buser.STRRemarks;
                                        _lblWaiver.Text = buser.STRRemarks2;

                                        if (buser.TotalArear > 0)
                                        {
                                            _lblTotalArrear.Text = "Total arrear = " + (buser.TotalArear).ToString();
                                        }
                                        else if (buser.TotalArear < 0)
                                        {
                                            _lblTotalWaiver.Text = "Total waiver = " + (buser.TotalWaiver).ToString();
                                        }

                                        try
                                        {
                                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.BILLPLANCHANGE + _txtUserName.Text, _userID);
                                            //by default username is selected na
                                            ShowBillPlanChangeRequests(_txtUserName.Text);
                                            //_lblSuccess.Text = "<b><font color=Red> Bill plan change request not allowed! Please Select New Plan Or Bill Cycle</font>";
                                        }
                                        catch
                                        { }

                                    }
                                    else
                                    {
                                        _lblSuccess.Text = "<b><font color=Red> Error: Bill plan change already exists for this user from next bill month!</font></b>";
                                    }
                                }
                                           
                            }
                        }
                        else
                        {
                            _lblSuccess.Text = "<b><font color=Red>Error: Either the next billing cycle checkbox or the w.e.f. date should be selected.</font>";
                        }
                    }
                    else
                    {
                        _lblSuccess.Text = "<b><font color=Red> Bill plan change request not allowed! Please either select new plan Or new  payment Cycle</font>";
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
        

            
                            

                                    _panelEditBillPlan.Visible = true;
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
            _ddlNewBillPlans.Items.Insert(0, new ListItem("-- Select New Bill plan --", ""));
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
            _ddlNewBillPlans.Items.Insert(0, new ListItem("-- Select New Bill Plan --", ""));

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
                chkBoxChangeNextBillCycle.Enabled = true;
            }
            else
            {
                datepicker.Disabled = false;
                chkBoxChangeNextBillCycle.Enabled = true;
            }
        }

        protected void _rbBILLCYCLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            datepicker.Value = "";
            if (_rbBILLCYCLE.SelectedValue == "A" || _rbBILLCYCLE.SelectedValue == "H" || _rbBILLCYCLE.SelectedValue == "Q")
            {                
                datepicker.Disabled = true;
                chkBoxChangeNextBillCycle.Checked = true;
                chkBoxChangeNextBillCycle.Enabled = false;
            }
            else
            {             
                datepicker.Disabled = false;
                chkBoxChangeNextBillCycle.Checked =false;
            }

            //if (currPayMode == _rbBILLCYCLE.SelectedValue)
            //{
            //    datepicker.Disabled = true;
            //    chkBoxChangeNextBillCycle.Visible = false;
            //}
            //else
            //{
            //    datepicker.Disabled = false;
            //    chkBoxChangeNextBillCycle.Visible = true;
            //}

        }

  
    }
}
