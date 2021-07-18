using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        private static string IDProofdocumentType = "";
        private static string AddrsProofdocumentType = "";
        //  private static string idproof = "";
        //  private static string addproof = "";
        private static string idstatus = "";
        private static string addstatus = "";
        int lapid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //ready to start type
                    tbCAFNumber.Focus();
                    _lblOTRCPaymentMode.Enabled = false;
                  //  cafnum();
                    _chkSameAddress.Checked = true;
                    _tbCorrespondenceAddress.Enabled = false;
                    _tbRegistrationDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");

                   // tbCAFNumber.Enabled = false;

                    //_ddlRegOTRCPlan.Enabled = false;
                    PopulateBroadbandBillPlans();
                    PopulateRegOTRCPlans();
                    PopulateAgents();
                    PopulateCableProviders();
                   // CalendarExtender1.SelectedDate = DateTime.Now;
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }
           
            if (_chkSameAddress.Checked == false)
            {
                _tbCorrespondenceAddress.Visible = true;
            }
            else
            {
                _tbCorrespondenceAddress.Visible = false;
                _tbCorrespondenceAddress.Text = _tbInstallationAddress.Text;
                _chkSameAddress.Focus();
            }
        }

        protected void PopulateBroadbandBillPlans()
        {
            _ddlBillPlan.DataSource = BroadbandBillPlans.GetBillPlanList().Tables[0];
            _ddlBillPlan.DataTextField = "PACKAGENAME";
            _ddlBillPlan.DataValueField = "BILLPLANID";
            _ddlBillPlan.DataBind();
        }


        protected void PopulateCableProviders()
        {

            ddlCableOperator.DataSource = LAPMaster.GetCableProviders();
            ddlCableOperator.DataTextField = "LAPNAME";
            ddlCableOperator.DataValueField = "LAPID";
            ddlCableOperator.DataBind();
        }

        protected void PopulateRegOTRCPlans()
        {
            _ddlRegOTRCPlan.DataSource = RegOTRCPlans.GetActiveRegOTRCPlans().Tables[0];
            _ddlRegOTRCPlan.DataTextField = "OTRCNAME";
            _ddlRegOTRCPlan.DataValueField = "OTRCID";
            _ddlRegOTRCPlan.DataBind();

        }

        protected void PopulateAgents()
        {
            _ddlAgent.DataSource = BroadbandAgents.GetActiveAgents().Tables[0];
            _ddlAgent.DataTextField = "AGENTNAME";
            _ddlAgent.DataValueField = "AGENTCODE";
            _ddlAgent.DataBind();
        }

        private void cafnum()
        {
            String cafquery = "select MAX(CAFNUMBER) FROM REGISTEREDUSERS";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(cafquery, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int cafval = int.Parse(dr[0].ToString()) + 1;
                    tbCAFNumber.Text = cafval.ToString();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
           
        }

        protected void _chkSameAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkSameAddress.Checked == true)
            {
                _tbCorrespondenceAddress.Enabled = false;
                _tbCorrespondenceAddress.Text = _tbInstallationAddress.Text;
                _chkSameAddress.Focus();
            }
            else
            {
                _tbCorrespondenceAddress.Text = String.Empty;
                _tbCorrespondenceAddress.Enabled = true;
            }
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




        protected void _ddlAddressProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddlAddressProof.SelectedValue == "O")
            {
                _tbOtherAddrsProof.Visible = true;
                _rfvAddrsProof.ControlToValidate = "_tbOtherAddrsProof";
                _tbOtherAddrsProof.Focus();

            }
            else
            {
                AddrsProofdocumentType = _ddlAddressProof.SelectedValue;
                _tbOtherAddrsProof.Visible = false;
                _rfvAddrsProof.ControlToValidate = "_ddlAddressProof";
                _ddlAddressProof.Focus();
            }

        }

        protected void _tbotherIDProof_TextChanged(object sender, EventArgs e)
        {
            IDProofdocumentType = _tbotherIDProof.Text;
        }

        protected void _tbOtherAddrsProof_TextChanged(object sender, EventArgs e)
        {
            AddrsProofdocumentType = _tbOtherAddrsProof.Text;
        }

        protected void _ddlIDProof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddlIDProof.SelectedValue == "O")
            {
                _tbotherIDProof.Visible = true;
                _rfvIDProof.ControlToValidate = "_tbotherIDProof";
                _tbotherIDProof.Focus();

            }
            else
            {
                IDProofdocumentType = _ddlIDProof.SelectedValue;
                _tbotherIDProof.Visible = false;
                _rfvIDProof.ControlToValidate = "_ddlIDProof";
                _ddlIDProof.Focus();
            }


        }

        protected void _btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {
                    //save 

                    CultureInfo ci = new CultureInfo("en-GB");
                    String IsRegisteredBy = String.Empty;
                    String AgentCode = String.Empty;
                    String IsAgentAccount = "F";


                    if (!_chkbIsAgent.Checked)
                    {
                        IsRegisteredBy = Session["EmpID"].ToString();
                    }
                    else
                    {
                        IsAgentAccount = "T";
                        if (_ddlAgent.SelectedValue != "")
                        {
                            AgentCode = _ddlAgent.SelectedValue.ToString();
                        }
                        //this means it is registered by agent but no agent is selected and required field  validation has failed
                        else
                        {
                            _rfvAgentSelect.Enabled = true;
                            _rfvAgentSelect.SetFocusOnError = true;
                        }
                    }

                    //check which cable provider is being used default 0 for symbios and other dynamic
                    if (chkboxCableProvider.Checked)
                    {
                        lapid = Convert.ToInt32(ddlCableOperator.SelectedValue);
                    }



                    RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers();
                    if (ChkBoxResidential.Checked)
                    {
                       // reguser.RegisterSubscriber(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorrespondenceAddress.Text, Convert.ToDateTime(_tbRegistrationDate.Text, ci).ToShortDateString(), _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), Convert.ToInt32(_ddlPriority.SelectedValue), IsRegisteredBy, AgentCode, IsAgentAccount, _tbRemarks.Text, Session["EmpID"].ToString(), AddrsProofdocumentType, IDProofdocumentType, tbCAFNumber.Text, lapid, ChkBoxResidential.Text, _txtUserGSTIN.Text);
                        reguser.RegisterSubscriber(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorrespondenceAddress.Text, DateTime.Today.ToShortDateString(), _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), Convert.ToInt32(_ddlPriority.SelectedValue), IsRegisteredBy, AgentCode, IsAgentAccount, _tbRemarks.Text, Session["EmpID"].ToString(), AddrsProofdocumentType, IDProofdocumentType, tbCAFNumber.Text, lapid, ChkBoxResidential.Text, _txtUserGSTIN.Text);

                      
                    }
                    else if (ChkBoxCommercial.Checked)
                    {
                       // reguser.RegisterSubscriber(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorrespondenceAddress.Text, Convert.ToDateTime(_tbRegistrationDate.Text, ci).ToShortDateString(), _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), Convert.ToInt32(_ddlPriority.SelectedValue), IsRegisteredBy, AgentCode, IsAgentAccount, _tbRemarks.Text, Session["EmpID"].ToString(), AddrsProofdocumentType, IDProofdocumentType, tbCAFNumber.Text, lapid, ChkBoxCommercial.Text, _txtUserGSTIN.Text);
                        reguser.RegisterSubscriber(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorrespondenceAddress.Text, DateTime.Today.ToShortDateString(), _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), Convert.ToInt32(_ddlPriority.SelectedValue), IsRegisteredBy, AgentCode, IsAgentAccount, _tbRemarks.Text, Session["EmpID"].ToString(), AddrsProofdocumentType, IDProofdocumentType, tbCAFNumber.Text, lapid, ChkBoxCommercial.Text, _txtUserGSTIN.Text);
                       
                    }
                    //check whether successfully saved in database or not
                    if (reguser.ReturnMessage != null && reguser.ReturnMessage.Contains("ERROR"))
                    {
                        _lblStatus.Text = reguser.ReturnMessage;
                    }
                    else//success
                    {
                        //_lblStatus.Text = "User " + _tbCustomerName.Text + " successfully registered. "  + idstatus + addstatus;
                        //Now instead of showing success message, will send the user to upload documents page for completing the registration
                        Response.Redirect("UserRegistrationDocuments.aspx?CAFNumber=" + tbCAFNumber.Text);
                    }

                }
                catch (ThreadAbortException)
                { }
                catch (Exception ex)
                {
                    // throw ex;
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }

            }
        }

        #region Clear all data
        private void ClearTextBoxes()
        {
            _tbCustomerName.Text = String.Empty;
            _tbInstallationAddress.Text = String.Empty;
            _tbCorrespondenceAddress.Text = String.Empty;
            _tbMobileNumber.Text = String.Empty;
            _tbAltMobileNumber.Text = String.Empty;
            _tbLandlineNumber.Text = String.Empty;
            _tbEmailID.Text = String.Empty;
            _tbRemarks.Text = String.Empty;
            _ddlAddressProof.SelectedIndex = 0;
            _ddlIDProof.SelectedIndex = 0;

            _tbotherIDProof.Visible = false;
            _tbOtherAddrsProof.Visible = false;
            _chkSameAddress.Checked = false;

        }
        #endregion







        #region Is the user registered by an egent
        protected void _chkbIsAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkbIsAgent.Checked)
            {
                _ddlAgent.Visible = true;
                _rfvAgentSelect.Enabled = true;
            }
            else
            {
                _ddlAgent.Visible = false;
                _rfvAgentSelect.Enabled = false;
            }
        }
        #endregion

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

       
        protected void ChkBoxResidential_CheckChanged(object sender, EventArgs e)
        {
            if (ChkBoxResidential.Checked)
            {
                ChkBoxCommercial.Checked = false;
            }
            else
            {
                ChkBoxCommercial.Checked = true;
            }
        }

        protected void ChkBoxCommercial_CheckChanged(object sender, EventArgs e)
        {
            if (ChkBoxCommercial.Checked)
            {
                ChkBoxResidential.Checked = false;
            }
            else
            {
                ChkBoxResidential.Checked = true;
            }
        }

        protected void Chkgst_CheckedChanged(object sender, EventArgs e)
        {
            if(Chkgst.Checked)
            {
                _txtUserGSTIN.Enabled = false;
                RequiredFieldValidator11.Enabled = _txtUserGSTIN.Enabled;
                
            }
            else
            {
                _txtUserGSTIN.Text = "";
                _txtUserGSTIN.Enabled = true;
                RequiredFieldValidator11.Enabled = _txtUserGSTIN.Enabled;
            }
        }

        protected void XmlDataSource1_Transforming(object sender, EventArgs e)
        {

        }
    }
}

      
 
