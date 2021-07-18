using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.TechnicalSupport
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            _tbCurrentPassword.Text = String.Empty;
            _tbNewPassword.Text = String.Empty;
            _tbConfirmNewPassword.Text = String.Empty;
        }

        protected void _btnChangePassword_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (SystemUsers.ChangePassword(Session["EmpID"].ToString(), _tbCurrentPassword.Text, _tbConfirmNewPassword.Text))
                {
                    _lblStatus.Text = "Password changed successfully.";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.PASSWRDCHANGE);
                    ClearForm();
                }
                else
                {
                    _lblStatus.Text = "Password not changed. Please enter the correct old password.";
                }


            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

    }
}
