using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.SystemManagement
{
    public partial class RegisterSysUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCreateSysUser_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //checking the date of birth for 1. if it is selected or not 2. if selected valid or not
                string dateOfBirth = DOB1.getDob();
               //if it is not null it means it is selected
               if (dateOfBirth != null)
                {
                   //if selected and date is valid then add to databse
                    if (dateOfBirth != "invalid")
                    {
                        SystemUsers newUser = new SystemUsers();
                        newUser.AddNewSysUsers(_ddlPriv.SelectedValue.ToString(), tbPasswrd.Text, tbName.Text, tbDesignation.Text, dateOfBirth, tbMobileNumber.Text, tbLandlineNo.Text, Session["EmpID"].ToString());
                        Label1.Text = "System User has been successfully registered.";
                        ClearForm();
                    }
               }
                   //if it is not selected at all in the first place, then add to databse without the date of birth
                else
                {
                    SystemUsers newUser = new SystemUsers();
                    newUser.AddNewSysUserPartial(_ddlPriv.SelectedValue.ToString(), tbName.Text, tbPasswrd.Text, tbDesignation.Text, tbMobileNumber.Text, tbLandlineNo.Text, Session["EmpID"].ToString());                    
              }
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ADDSYSUSER + tbName.Text);
            Label1.Text = "System User has been successfully registered.";
            ClearForm();
        }
        private void ClearForm()
        {
            tbName.Text = String.Empty;
            tbPasswrd.Text = String.Empty;
            tbDesignation.Text = String.Empty;
            tbMobileNumber.Text = String.Empty;
            tbLandlineNo.Text = String.Empty;

           _ddlPriv.SelectedIndex = 0;

            DropDownList ddl1 = (DropDownList)DOB1.FindControl("_ddlYear");
            DropDownList ddl2 = (DropDownList)DOB1.FindControl("_ddlDay");
            DropDownList ddl3 = (DropDownList)DOB1.FindControl("_ddlMonth");
            ddl1.SelectedIndex = 0;
            ddl2.SelectedIndex = 0;
            ddl3.SelectedIndex = 0;

        }


       
    }
}
