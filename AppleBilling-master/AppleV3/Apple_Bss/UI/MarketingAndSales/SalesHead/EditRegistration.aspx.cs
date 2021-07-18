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

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class EditRegistration : System.Web.UI.Page
    {
        private static string regpendinguserid="";
      
        int lapid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {            
                //Load the pending connection user to edit
                if (Request["id"] != null)
                {
                    regpendinguserid = Request["id"];
                
                    PopulateBroadbandBillPlans();
                    PopulateRegOTRCPlans();
                    PopulateCableProviders();

                 RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
                 buser.GetRegisteredUserDetailsByIDandStatus(regpendinguserid, "'P', 'I','R'");
                _tbCustomerName.Text = buser.Name;
                _tbInstallationAddress.Text = Server.HtmlDecode(buser.InstallationAddress);
                _tbCorresspondenceAddress.Text = Server.HtmlDecode(buser.CorrespondenceAddress);
                _tbLandlineNumber.Text = buser.LandlineNumber;
                _tbMobileNumber.Text = buser.MobileNumber;
                _tbEmailID.Text = buser.EmailID;
                tbCAFNumber.Text = buser.CAFNumber.ToString();
                InstallationConnectionType.Text = buser.InstallationConnectionType;
                _txtUserGSTIN.Text = buser.UserGSTIN;

                if (InstallationConnectionType.Text == "Residential")
                {
                    ResidentialCheckBox.Checked = true;
                    CommercialCheckBox.Checked = false;
                    InstallationConnectionType.Visible = false;
                }
                else if (InstallationConnectionType.Text == "Commercial")
                {
                    ResidentialCheckBox.Checked = false;
                    CommercialCheckBox.Checked = true;
                    InstallationConnectionType.Visible = false;
                }

                   //checking access type is symbios or cable
                if (buser.LAPID != 0) //is not 0 = is not symbios
                {

                    chkboxCableProvider.Checked = true;
                    ddlCableOperator.Enabled = true;
                    ddlCableOperator.SelectedIndex = buser.LAPID;
                   
                }
                else //if it is cable provider
                {
                    
                    chkboxSymBiosNetwork.Checked = true;
                }
               
             string billplanID = buser.BillPlanID;
            string strOrtcID = buser.OTRCPaymentMode;
            RegOTRCPlans otrcId = new RegOTRCPlans(strOrtcID);
            BroadbandBillPlans bplan = new BroadbandBillPlans(billplanID);
            String bplanDisplay = "<fieldset><legend style='color:#3b5889'>Current Bill Plan</legend> <b> Bill Plan &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;: <font color=red>" + bplan.PackageName + "</font><br/>";
            bplanDisplay += "<b>  Payment Mode &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; : <font color=red>" + buser.RentalPaymentMode + "</font><br/>";
            bplanDisplay += "<b> ORTC Payment Mode :  <font color=red>" + otrcId.OTRCName + "</font></filedset>";
            _lblBillPlanInfo.Text = bplanDisplay;
                }              
            }
        }
        
        protected void PopulateCableProviders()
        {

            ddlCableOperator.DataSource = LAPMaster.GetCableProviders();
            ddlCableOperator.DataTextField = "LAPNAME";
            ddlCableOperator.DataValueField = "LAPID";
            ddlCableOperator.DataBind();
        }
      
        
        protected void PopulateBroadbandBillPlans()
        {

            _ddlBillPlan.DataSource = BroadbandBillPlans.GetBillPlanList().Tables[0];
            _ddlBillPlan.DataTextField = "PACKAGENAME";
            _ddlBillPlan.DataValueField = "BILLPLANID";
            _ddlBillPlan.DataBind();
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

        //Section to Update the Profile of the Customer

        protected void _imgBtnCustDetailUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();
                if(!buser.CheckCAFNumberExists(tbCAFNumber.Text,regpendinguserid))
                {
                    if (ResidentialCheckBox.Checked)
                    {
                        buser.UpdateCustProfileDetails(regpendinguserid, _tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorresspondenceAddress.Text, _tbLandlineNumber.Text,"", _tbMobileNumber.Text, _tbEmailID.Text, tbCAFNumber.Text, ResidentialCheckBox.Text,_txtUserGSTIN.Text);
                    }
                    else if (CommercialCheckBox.Checked)
                    {
                        buser.UpdateCustProfileDetails(regpendinguserid, _tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorresspondenceAddress.Text, _tbLandlineNumber.Text,"", _tbMobileNumber.Text, _tbEmailID.Text, tbCAFNumber.Text, CommercialCheckBox.Text,_txtUserGSTIN.Text);
                    }
                    }
                
                else
                {
                    _lblMsg.Text = "Error! CAF Number already exists";
                }
                _lblSuccess.Text = "Profile Successfully Updated...";
                _lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
          //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPREGISTERSUBSCRBRPROFILE, _ddListSubscriberName.SelectedValue);
            ClearForm();

        }

        //Section to Update the Bill Plan 
        protected void _imgBtnBillPlanUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                RegisteredBroadbandUsers buser = new RegisteredBroadbandUsers();

                //check which cable provider is being used default 0 for symbios and other dynamic
                if (chkboxCableProvider.Checked)
                {
                    lapid = Convert.ToInt32(ddlCableOperator.SelectedValue);
                }
                if (ResidentialCheckBox.Checked)
                {
                    buser.UpdateBillPlanDetails(regpendinguserid, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), lapid, ResidentialCheckBox.Text,_txtUserGSTIN.Text);
                }
                if (CommercialCheckBox.Checked)
                {
                    buser.UpdateBillPlanDetails(regpendinguserid, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), lapid, CommercialCheckBox.Text, _txtUserGSTIN.Text);
                }
                
                lblupdatebillmsg.Text = " Bill Plan Successfully Updated";
                _lblMsg.Text = "";
             
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
          //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPREGISTERSUBSCRBRBILL, _ddListSubscriberName.SelectedValue);

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

        //for allowing user to check whether symbios network or cable operator network
        protected void chkboxCableProvidee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxCableProvider.Checked)
            {
                ddlCableOperator.Enabled = true;
                rfvddlCableOperator.Enabled = true;
            }
            else
            {
                ddlCableOperator.SelectedIndex = -1;
                ddlCableOperator.Enabled = false;
                rfvddlCableOperator.Enabled = false;
            }
        }



        protected void chkboxResidential_CheckedChanged(object sender, EventArgs e)
        {
            CommercialCheckBox.Checked = false;
         //   InstallationConnectionType.Text = "Residential";
           
        }

        protected void chkboxCommercial_CheckedChanged(object sender, EventArgs e)
        {
            ResidentialCheckBox.Checked = false;
         //   InstallationConnectionType.Text = "Commercial";

        }

        protected void _ddlRegOTRCPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
