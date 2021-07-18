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
using Apple_Bss.CodeFile;
using System.Globalization;

namespace Apple_Bss.UI.TechnicalSupport.DirectSupport
{
    public partial class RaiseBroadbandSRDirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    //  _ltrlSubscriberDetails.Visible = false; 
                    _tbUserName.Focus(); 
                    SetStatusPending();
                    PopulateTechSupportExecutives();
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }
        private void PopulateTechSupportExecutives()
        {
            _ddlIssueAssignedTo.DataSource = SystemUsers.GetActiveSystemUsersByPriv(Convert.ToInt32(DBConn.GetTechSupportLevel())).Tables[0];
            _ddlIssueAssignedTo.DataTextField = "NAME";
            _ddlIssueAssignedTo.DataValueField = "EMPID";
            _ddlIssueAssignedTo.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_radResolutionStatus.SelectedValue == "R")
            {
                SetStatusResolved();
            }
            else if (_radResolutionStatus.SelectedValue == "P")
            {
                SetStatusPending();             
            }
        }

        private void SetStatusResolved()
        {
            _lblResTime.Visible = true;
            _lblResDateTime.Visible = true;
            _txtEndDate.Visible = true;
            _ddlEndHours.Visible = true;
            _ddlEndMinutes.Visible = true;
            _lblIssueAssignedTo.Visible = false;
            _ddlIssueAssignedTo.Visible = false;
            //enable the required validators
            rfvHours.Enabled = true;
            rfvminutes.Enabled = true;
            rfvEndDate.Enabled = true;
           
        }

        private void SetStatusPending()
        {
            _lblResTime.Visible = false;
            _lblResDateTime.Visible = false;
            _txtEndDate.Visible = false;
            _ddlEndHours.Visible = false;
            _ddlEndMinutes.Visible = false;
            _lblIssueAssignedTo.Visible = true;
            _ddlIssueAssignedTo.Visible = true;
            //disable the not required validators
            rfvHours.Enabled = false;
            rfvminutes.Enabled = false;
            rfvEndDate.Enabled = false;
           
        }

        private void ClearFormForNewEntry()
        {
            SetStatusPending();
            _tbIssueReported.Text = String.Empty;
            _tbIssueCause.Text = String.Empty;
            _tbActionTaken.Text = String.Empty;
            _tbUserName.Text = String.Empty;
            _tbUserName.Focus();
            _radResolutionStatus.SelectedValue="P";
        }

        //protected void _btnRegisterSR_Click(object sender, ImageClickEventArgs e)
        //{
        //    CultureInfo ci = new CultureInfo("en-GB");         
        //    string status = _radResolutionStatus.SelectedValue;
        //    string enddatetime = String.Empty;
        //    string startdatetime = String.Empty;
        //    string issueassignedto = String.Empty;
        //    startdatetime = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";

        //     string userid = HiddenFieldUserId.Value;
        //     if (userid != String.Empty)
        //     {
        //         try
        //         {
        //         if (status == "P")
        //         { 
        //             enddatetime = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString() + " " + _ddlEndHours.SelectedValue.ToString() + ":" + _ddlEndMinutes.SelectedValue.ToString() + ":00";
        //             issueassignedto = Session["EmpID"].ToString();
        //             ServiceCalls.AddNewServiceCallRecord(userid, "SPOP1001", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, issueassignedto, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());
        //             /* Temporarily commented out for now since its not being used - 17/04/2010
        //               String strMsg = String.Empty;                     
        //               BroadbandUser client = new BroadbandUser(userid);
        //               strMsg += "SR ALERT: U/N: " + client.UserName + " Name: " + client.Name + " M: +" + client.MobileNumber;
        //               SystemUsers assignedto = new SystemUsers(_ddlIssueAssignedTo.SelectedValue.ToString());
        //               try
        //               {
        //                   Utilities.SendSMS(assignedto.MobileNumber, strMsg);
        //                   ClearFormForNewEntry();                           
        //               }
        //               catch (Exception ex)
        //               {
        //                   Session["ErrorMsg"] = ex.ToString();
        //                   Response.Redirect("~/Error.aspx", false);
        //               } */
        //             Response.Redirect("PendingSRConfirmationDirect.aspx?id=" + Utilities.QueryStringEncode(userid) + "&dt=" + Utilities.QueryStringEncode(startdatetime), false);


        //         }
        //         else
        //         //if (status == "R")
        //         {
        //             issueassignedto = _ddlIssueAssignedTo.SelectedValue.ToString();
        //             ServiceCalls.AddNewServiceCallRecord(userid, "SPOP1001", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, issueassignedto, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());
        //             _lblStatus.Text = "Service Request Details Successfully Registered";
        //             try
        //                 {
        //                     //for "P" condition log added  is on the next page
        //                     SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST  + " and Resolved", userid);
        //                 }
        //                 catch
        //                 {
        //                     //do nothing for now
        //                 }
        //              _tbUserName.Focus();
        //              ClearFormForNewEntry();   
        //         }
        //     }
        //         catch (Exception ex)
        //         {
        //             Session["ErrorMsg"] = ex.ToString();
        //             Response.Redirect("~/Error.aspx", false);
        //         }
        //     }
        //     else
        //     {
        //         _lblStatus.Text = " Selected username does not exist.";
        //     }

        //}

        protected void _btnRegisterSR_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            string status = _radResolutionStatus.SelectedValue;
            string enddatetime = String.Empty;
            string startdatetime = String.Empty;
            string issueassignedto = String.Empty;
            //startdatetime = Convert.ToDateTime(_txtStartDate.Text).ToString("MM-dd-yyyy") + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";
            startdatetime = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString() + " " + _ddlHours.SelectedValue.ToString() + ":" + _ddlMinutes.SelectedValue.ToString() + ":00";

            string userid = HiddenFieldUserId.Value;
            if (userid != String.Empty)
            {
                if (status == "R")
                {
                    enddatetime = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString() + " " + _ddlEndHours.SelectedValue.ToString() + ":" + _ddlEndMinutes.SelectedValue.ToString() + ":00";
                    issueassignedto = Session["EmpID"].ToString();
                }
                else
                //if (status == "P")
                {
                    issueassignedto = _ddlIssueAssignedTo.SelectedValue.ToString();
                }

                try
                {
                    ServiceCalls.AddNewServiceCallRecord(userid, "SPOP1001", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());

                    if (status == "P")
                    {
                        /* Temporarily commented out for now since its not being used - 17/04/2010
                        String strMsg = String.Empty;                     
                        BroadbandUser client = new BroadbandUser(userid);
                        strMsg += "SR ALERT: U/N: " + client.UserName + " Name: " + client.Name + " M: +" + client.MobileNumber;
                        SystemUsers assignedto = new SystemUsers(_ddlIssueAssignedTo.SelectedValue.ToString());
                        try
                        {
                            Utilities.SendSMS(assignedto.MobileNumber, strMsg);
                            ClearFormForNewEntry();                           
                        }
                        catch (Exception ex)
                        {
                            Session["ErrorMsg"] = ex.ToString();
                            Response.Redirect("~/Error.aspx", false);
                        } */
                        Response.Redirect("PendingSRConfirmationDirect.aspx?id=" + Utilities.QueryStringEncode(userid) + "&dt=" + Utilities.QueryStringEncode(startdatetime), false);


                    }
                    else if (status == "R")
                    {
                        try
                        {
                            //for "P" condition log added  is on the next page
                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SRVCREQUEST + LogEvents.POST + " and Resolved", userid);
                        }
                        catch
                        {
                            //do nothing for now
                        }
                        ClearFormForNewEntry();
                        _lblStatus.Text = "Service Request Successfully Posted";

                    }
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);

                }
            }
            else
            {
                _lblStatus.Text = "<font color='red'> Selected username does not exist.  </font>";
            }

        }
      // method to handle the text change in _username TextBox
       protected void _tbUserName_TextChanged(object sender, EventArgs e)
        {
            _lblDetails.Visible = true;
            _ltrlSubscriberDetails.Visible = true;

                try
                {
                    string[] details = new string[2];
                    details = BroadbandUser.GetSubscriberDetails(_tbUserName.Text);
                    HiddenFieldUserId.Value = details[1];
                   // _ltrlSubscriberDetails.Text = "<b> Name: <font color='#EF9F05'>" + details[0] + "</font> User ID : <font color='#EF9F05'>" + details[1] + "</font></b>";
                    _ltrlSubscriberDetails.Text = "<b> UserID: " + details[1] + ", Name : " + details[0] + "</b>";
                    _tbUserName.Focus();

                }
                catch (NullReferenceException)
                {
                    _ltrlSubscriberDetails.Text = "<font color='red'> Selected username does not exist. </font>";
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            

        }
  
    }
}
