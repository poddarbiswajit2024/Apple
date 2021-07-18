using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;
using System.Globalization;

namespace Apple_Bss.UI.MarketingAndSales.SalesExecutive
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        private static string IDProofdocumentType = "";
        private static string AddrsProofdocumentType = "";
        private static string ThumbName = "";
        private static string userphotostatus = "";
        private static string idproof = "";
        private static string addproof = "";
        private static string idstatus = "";
        private static string addstatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                try
                {
                    //ready to start type
                    _tbCustomerName.Focus();

                    _lblOTRCPaymentMode.Enabled = false;
                   // _ddlRegOTRCPlan.Enabled = false;
                    PopulateBroadbandBillPlans();
                    PopulateRegOTRCPlans();
                    PopulateAgents();
                    CalendarExtender1.SelectedDate = DateTime.Now;  
                }
                catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            }   

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

        protected void PopulateAgents()
        {
            _ddlAgent.DataSource = BroadbandAgents.GetActiveAgents().Tables[0];
            _ddlAgent.DataTextField = "AGENTNAME";
            _ddlAgent.DataValueField = "AGENTCODE";
            _ddlAgent.DataBind();
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

            //if plan is FAP  _ddlBillPlan
            //_ddlPaymentMode  is disabled
            //else

            //enabled


        }

        private void SaveRegisteredUser()
        {
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
            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers();
            reguser.RegisterSubscriber(_tbCustomerName.Text, _tbInstallationAddress.Text, _tbCorrespondenceAddress.Text, Convert.ToDateTime(_tbRegistrationDate.Text, ci).ToShortDateString(), _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _ddlBillPlan.SelectedValue.ToString(), _ddlPaymentMode.SelectedValue.ToString(), _ddlRegOTRCPlan.SelectedValue.ToString(), Convert.ToInt32(_ddlPriority.SelectedValue), IsRegisteredBy, AgentCode, IsAgentAccount, _tbRemarks.Text, Session["EmpID"].ToString(), AddrsProofdocumentType, IDProofdocumentType,1);            
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

                try
                {
                    SaveRegisteredUser();
                    _lblStatus.Text = "User " + _tbCustomerName.Text + " successfully registered. " + userphotostatus + idstatus + addstatus;
                    try
                    {                        
                        SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.REGISTERSUBSCRBR + _tbCustomerName.Text);                     
                    }
                    catch
                    {
                        //do nothing
                    }
                    ClearTextBoxes();
                    
                }
                catch (Exception ex)
                {
                    // throw ex;
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
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


        /// <summary>
        /// asynchronous uploading of subscriber photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AsyncFileUpload1_doUpload(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                //first checking the file extension for allowed extension
                string fe = Path.GetExtension(AsyncFileUpload1.FileName).ToLower();
                if ((fe == ".jpg") || (fe == ".gif") || (fe == ".png"))
                {
                    string serverfolder = DBConn.GetUploadedImageFolderPath() + "Subscribers//";
                    string filename = AsyncFileUpload1.FileName;
                    AsyncFileUpload1.SaveAs(Server.MapPath(serverfolder + filename));
                    ThumbName = ImageManage.ResizeAndSaveImage(filename, "_thumb", 80,  serverfolder);
                    userphotostatus = "User photo saved. ";
                }
                else
                {
                    ///to show custom error message , let the person know that whta he has uploaded was not done due to unaccepted extension                   
                    userphotostatus = "User photo not saved because it is not in accepted image format. ";
                }
            }
            catch
            {
                userphotostatus = "User photo not saved. ";

            }
        }

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


    }
   
 
}
