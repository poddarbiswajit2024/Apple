using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class UpdateSubscriberDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _lblBc.Text = DBConn.GetBranchCode();

        }

      
        protected void _btnGetUserDetails_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            try
            {
                BroadbandUser buser = new BroadbandUser(strUserID);
                _txtUserName.Text = buser.UserName;
                _txtName.Text =buser.Name;
                _txtName.ReadOnly = true;
                _txtEmailID.Text = buser.EmailID;
                _txtLandlineNumber.Text = buser.LandlineNumer;
                _txtMobileNumber.Text = buser.MobileNumber;
                //_txtInstAddress.Text = buser.InstallationAddress;
                //_txtCorresAddress.Text = buser.CorrespondenceAddress;

                _txtInstAddress.Text = Utilities.DeHtmlize(buser.InstallationAddress);
                _txtCorresAddress.Text = Utilities.DeHtmlize(buser.CorrespondenceAddress);
                _txtCustomerGSTIN.Text = buser.CustomerGSTIN;
                _btnUpdateUser.Enabled = true;
               
                //rfvusername.ValidationGroup = null;
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

        }

        private void ClearForm()
        {
            _txtUserID.Text = String.Empty;
            _txtUserName.Text = String.Empty;
            _txtName.Text = String.Empty;
            _txtEmailID.Text = String.Empty;
            _txtLandlineNumber.Text = String.Empty;
            _txtMobileNumber.Text = String.Empty;
            _txtInstAddress.Text = String.Empty;
            _txtCorresAddress.Text = String.Empty;
            _txtCustomerGSTIN.Text = String.Empty;
           
            _btnUpdateUser.Enabled = false;
        }

        protected void _btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }

        protected void _btnUpdateUser_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            { 
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;
            try
            {
                BroadbandUser buser = new BroadbandUser();
                buser.SubscriberDetailsUpdate(strUserID, _txtEmailID.Text, _txtLandlineNumber.Text, _txtMobileNumber.Text, _txtInstAddress.Text, _txtCorresAddress.Text, Session["EmpID"].ToString(), _txtCustomerGSTIN.Text);
                _lblSuccess.Text = "User" + "<font color=Red>  " + _txtUserName.Text.ToString().ToUpper() + "</font>  " + "Details Successfully Updated";
                
            }
            catch (Exception ex)
            {                            
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSUBSCRIBER + "Details", strUserID);

            ClearForm();
        }
        }

       
    }
   
}
