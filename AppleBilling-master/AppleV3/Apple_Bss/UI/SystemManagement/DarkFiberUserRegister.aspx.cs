using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.IO;
using System.Globalization;

namespace Apple_Bss.UI.SystemManagement
{
    public partial class DarkFiberUserRegister : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

        }

        protected void _btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (!AccountMaster.UsernameExists(_tbUserName.Text))
                    {
                        AccountMaster ac = new AccountMaster();
                        ac.RegisterUser(_tbCustomerName.Text, _tbUserName.Text, Encryption.encrypt(_tbPassword.Text, 20), _tbCorrespondenceAddress.Text, _tbMobileNumber.Text, _tbAltMobileNumber.Text, _tbLandlineNumber.Text, _tbEmailID.Text, _tbEmail2.Text, _tbEmailID3.Text, Session["EmpID"].ToString());
                        _lblStatus.Text = "Dark Fiber User : " + _tbCustomerName.Text + " successfully registered. ";
                        try
                        {
                            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), "Dark Fiber User Registered :" + _tbCustomerName.Text);
                        }
                        catch
                        {
                            //do nothing
                        }
                    }
                    else
                    {
                        _lblStatus.Text = " Username : " + _tbUserName.Text + " already exists. Please choose another username.";
                        
                    }
                }
                catch (Exception ex)
                {
                    // throw ex;
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
                ClearTextBoxes();

            }
        }

        #region Clear all data
        private void ClearTextBoxes()
        {
            _tbCustomerName.Text = String.Empty;
            _tbUserName.Text = String.Empty;
            _tbCorrespondenceAddress.Text = String.Empty;
            _tbMobileNumber.Text = String.Empty;
            _tbAltMobileNumber.Text = String.Empty;
            _tbLandlineNumber.Text = String.Empty;
            _tbEmailID.Text = String.Empty;
            _tbEmail2.Text = String.Empty;
            _tbEmailID3.Text = String.Empty;     
        }
        #endregion
  
        
    }
    
  
}
