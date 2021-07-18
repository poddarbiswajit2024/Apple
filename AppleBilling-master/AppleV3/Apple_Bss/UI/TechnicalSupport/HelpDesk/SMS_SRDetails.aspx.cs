using System;
using System.Globalization;
using System.Web.UI;
using Apple_Bss.CodeFile;
using System.Text;

namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class SMS_SRDetails : System.Web.UI.Page
    {
        private static string username;
       private static string issueid;
        BroadbandUser buser = new BroadbandUser();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((Request["username"] != null) && (Request["srid"] != null))
                {               
                     username = Request["username"].ToString();
                     issueid = Request["srid"].ToString();
                    PopulateUserDetails();
                
                    try
                    {
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

        private void PopulateTechSupportExecutives()
        {
            _ddlIssueAssignedTo.DataSource = SystemUsers.GetActiveSystemUsersByPriv(Convert.ToInt32(DBConn.GetTechSupportLevel())).Tables[0];
            _ddlIssueAssignedTo.DataTextField = "NAME";
            _ddlIssueAssignedTo.DataValueField = "EMPID";
            _ddlIssueAssignedTo.DataBind();
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
            rfvEndDate.Enabled = true; ;
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
       

            _txtEndDate.Text = "";
            _txtStartDate.Text = "";

        }

        protected void _btnRegisterSR_Click(object sender, ImageClickEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            string status = _radResolutionStatus.SelectedValue;
            string enddatetime = String.Empty;
            string startdatetime = String.Empty;
            string issueassignedto = String.Empty;

            startdatetime = _txtStartDate.Text;
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
                    ServiceCalls.updateServiceCallRecord(issueid, userid, "SPOP1001", enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, issueassignedto, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());

                    //ServiceCalls.AddNewServiceCallRecord(userid, "SPOP1001", startdatetime, enddatetime, _ddlIssueType.SelectedValue.ToString(), _tbIssueReported.Text, issueassignedto, _tbIssueCause.Text, _tbActionTaken.Text, status, _ddlSupportType.SelectedValue.ToString(), Session["EmpID"].ToString());

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

                        //from the pending page(or even from this page) send another sms if need be with the srno like SRV11805 
                        Response.Redirect("Default.aspx?msg=SR has been updated with pending status.");
                        //_lblStatus.Text = "SR has been updated with pending status";
                       // ClearFormForNewEntry();
                        
                        



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


                        Response.Redirect("Default.aspx?msg=Resolved Service Request Successfully Posted");
                      //  _lblStatus.Text = "Resolved Service Request successfully saved.";

                    }
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
            else
            {
                _lblStatus.Text = "<font color='red'> Selected username does not exist.  </font>";
            }

        }


        private void PopulateUserDetails()
        {
            try
            {
                buser.GeClientDetails(username);
                HiddenFieldUserId.Value = buser.UserID;
                StringBuilder sb = new StringBuilder();
                sb.Append("<span style='padding-right:15px'><b>Username :</b> ").Append(username).Append("</span>").Append("<span style='padding-right:15px'><b>UserID :</b> ").Append(buser.UserID).Append("</span>").Append("<span style='padding-right:15px'><b>Name : </b>").Append(buser.Name).Append("</span>");
                lblSRID.Text = issueid;
               
                _ltrlSubscriberDetails.Text = sb.ToString();
                _txtStartDate.Text = buser.Strng2;
                _txtStartDate.ReadOnly = true;
                _tbIssueReported.Text = buser.Strng1;
                _tbIssueReported.ReadOnly = true;
             

            }
            catch (NullReferenceException)
            {
                _ltrlSubscriberDetails.Text = "Selected username does not exist. ";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
     
        }
    }

