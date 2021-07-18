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

namespace Apple_Bss.UI.MarketingAndSales.SalesExecutive
{
    public partial class EditRegistration : System.Web.UI.Page
    {
        int lapid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _panelCustDetails.Visible = false;
                _panelBillDetails.Visible = false;
                PopulatePendingConnections();
               // PopulateBroadbandBillPlans();
                PopulateRegOTRCPlans();
                if (_ddListSubscriberName.SelectedItem != null)
                {
                    _lblMsg.Text = "<b>Customer Name :  <font color=Red >  " + _ddListSubscriberName.SelectedItem.ToString().ToUpper() + " </font></b>";
                   
                }
                else
                {
                    _lblMsg.Text = "<b><font color=red>No Pending Subscriber for Editing</font></b>";
                    _lnkBtnEditBillPlan.Enabled = false;
                    _lnkBtnEditProfile.Enabled = false;
                }
            }
        }

        protected void PopulatePendingConnections()
        {
            _ddListSubscriberName.DataSource = RegisteredBroadbandUsers.GetPendingConnectionsForEdit(Session["EmpID"].ToString()).Tables[0];
            _ddListSubscriberName.DataTextField = "NAME";
            _ddListSubscriberName.DataValueField = "USERID";
            _ddListSubscriberName.DataBind();
        }
        
        protected void PopulateBroadbandBillPlans()
        {

            //_ddlBillPlan.DataSource = BroadbandBillPlans.GetBillPlanList().Tables[0];
            //_ddlBillPlan.DataTextField = "PACKAGENAME";
            //_ddlBillPlan.DataValueField = "BILLPLANID";
            //_ddlBillPlan.DataBind();
        }

        protected void PopulateRegOTRCPlans()
        {
            _ddlRegOTRCPlan.DataSource = RegOTRCPlans.GetActiveRegOTRCPlans().Tables[0];
            _ddlRegOTRCPlan.DataTextField = "OTRCNAME";
            _ddlRegOTRCPlan.DataValueField = "OTRCID";
            _ddlRegOTRCPlan.DataBind();

        }
        
        protected void _ddlBillPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BroadbandBillPlans plan = new BroadbandBillPlans(_ddlBillPlan.SelectedValue);

            if (plan.MediaType == "W")
            {
                _lblOTRCPaymentMode.Enabled = true;
                _ddlRegOTRCPlan.Enabled = true;
            }
            else if (plan.MediaType == "C")
            {
                _lblOTRCPaymentMode.Enabled = false;
                _ddlRegOTRCPlan.Enabled = false;
            }
        }

        protected void _lnkBtnEditProfile_Click(object sender, EventArgs e)
        {           
            _panelCustDetails.Visible = true;
            _panelCustDetails.Enabled = true;
            _panelBillDetails.Enabled = false;
            _panelBillDetails.Visible = false;

            RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers(_ddListSubscriberName.SelectedValue.ToString());
            _tbCustomerName.Text = buser.Name;
            _tbInstallationAddress.Text = Server.HtmlDecode(buser.InstallationAddress);
            _tbCorresspondenceAddress.Text = Server.HtmlDecode(buser.CorrespondenceAddress);
            _tbLandlineNumber.Text = buser.LandlineNumber;
            _tbMobileNumber.Text = buser.MobileNumber;
            _tbEmailID.Text = buser.EmailID;
        }

        protected void _lnkBtnEditBillPlan_Click(object sender, EventArgs e)
        {
            _panelBillDetails.Enabled = true;
            _panelBillDetails.Visible = true;
            _panelCustDetails.Visible = false;
            _panelCustDetails.Enabled = false;
           
            RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers(_ddListSubscriberName.SelectedValue.ToString());
            string billplanID = buser.BillPlanID;
            string strOrtcID = buser.OTRCPaymentMode;
            RegOTRCPlans otrcId = new RegOTRCPlans(strOrtcID);
            BroadbandBillPlans bplan = new BroadbandBillPlans(billplanID);
            String bplanDisplay = "<fieldset><legend style='color:#3b5889'>Current Bill Plan</legend> <b> Bill Plan &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;: <font color=red>" + bplan.PackageName + "</font><br/>";
            bplanDisplay += "<b>  Payment Mode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <font color=red>" + buser.RentalPaymentMode + "</font><br/>";
            bplanDisplay += "<b> ORTC Payment Mode :  <font color=red>" + otrcId.OTRCName + "</font></filedset>";
            _lblBillPlanInfo.Text = bplanDisplay;
        }
        
        protected void _imgBtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            _lblMsg.Text = "<b>Customer Name :  <font color=Red >  "+_ddListSubscriberName.SelectedItem.ToString().ToUpper()+" </font></b>";
            _panelCustDetails.Visible = false;
            _panelCustDetails.Enabled = false;
            _panelBillDetails.Enabled = false;
            _panelBillDetails.Visible = false;
            _lblSuccess.Text = "";
        }

        //Section to Update the Profile of the Customer
       
        protected void _imgBtnCustDetailUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
               // buser.UpdateCustProfileDetails(_ddListSubscriberName.SelectedValue.ToString(),_tbCustomerName.Text,_tbInstallationAddress.Text,_tbCorresspondenceAddress.Text,_tbLandlineNumber.Text,_tbMobileNumber.Text,_tbEmailID.Text);
                _lblSuccess.Text = "Profile Successfully Updated...";
                _lblMsg.Text = "";
                
                _panelCustDetails.Visible = false;
                PopulatePendingConnections();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPREGISTERSUBSCRBRPROFILE, _ddListSubscriberName.SelectedValue);
                ClearForm();
        }

        //Section to Update the Bill Plan 
       
        protected void _imgBtnBillPlanUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
               
                    

            RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
         //   buser.UpdateBillPlanDetails(_ddListSubscriberName.SelectedValue.ToString(), _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), lapid);
            lblupdatebillmsg.Text = " Bill Plan Successfully Updated";
            _lblMsg.Text = "";
            _panelBillDetails.Visible = false;
            PopulatePendingConnections();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPREGISTERSUBSCRBRBILL, _ddListSubscriberName.SelectedValue);

        }

        private void ClearForm()
        {
            _tbCustomerName.Text = String.Empty;
            _tbCorresspondenceAddress.Text = String.Empty;
            _tbInstallationAddress.Text = String.Empty;
            _tbEmailID.Text = String.Empty;
            _tbMobileNumber.Text = String.Empty;
            _tbLandlineNumber.Text = String.Empty;         
        }
        protected void chkboxPlanFairAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxPlanFairAccess.Checked)
            {
                _ddlPaymentMode.SelectedIndex = 0;
                _ddlPaymentMode.Enabled = false;//default monthly is displayed
                //enable only monthly payment plan only rental
            }
            else
            {

                _ddlPaymentMode.Enabled = true;//default monthly is displayed
            }
            _ddlBillPlan.DataSource = BroadbandBillPlans.GetBillPlanList(chkboxPlanFairAccess.Checked).Tables[0];
            _ddlBillPlan.DataTextField = "PACKAGENAME";
            _ddlBillPlan.DataValueField = "BILLPLANID";
            _ddlBillPlan.DataBind();
        }


        protected void chkboxPlanNormal_CheckedChanged(object sender, EventArgs e)
        {

            if (chkboxPlanNormal.Checked)
            {
                _ddlPaymentMode.Enabled = true;
            }
            else
            {
                _ddlPaymentMode.SelectedIndex = 0;
                _ddlPaymentMode.Enabled = false;//default monthly is displayed
                //enable only monthly payment plan only rental
            }
            _ddlBillPlan.DataSource = BroadbandBillPlans.GetBillPlanList(!chkboxPlanNormal.Checked).Tables[0];
            _ddlBillPlan.DataTextField = "PACKAGENAME";
            _ddlBillPlan.DataValueField = "BILLPLANID";
            _ddlBillPlan.DataBind();

        }
       
    }
}
