using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.SystemManagement
{
    public partial class PopUpUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if  (Session["Priv"] != null)
                {
                    if(Utilities.AunthenticatePriv(Session["Priv"].ToString(), UIModuleType.SYSTEMADMIN))
                    {
                    DisplayUserDetails();
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEW + LogEvents.SYSUSER, Request["EmpID"].ToString());
                    }
                }
                else
               {
                Session["ErrorMsg"] = "INVALID SESSION OR SESSION TIMEOUT. Either your session has timed out or you have not been authenticated.<br/> Please close this window and go to login page and enter your username and password.";
                Response.Redirect("~/Error.aspx");                       
               }
                    
            }
        }

        private void DisplayUserDetails()
        {
           // string employeeid = Utilities.QueryStringDecode(Request["EmpID"].ToString());
            string employeeid = Request["EmpID"].ToString();
            Label_empid.Text = employeeid;

            SystemUsers jai = new SystemUsers(employeeid);
            tbName.Text = jai.EmployeeName;
            tbDesignation.Text = jai.Designation;
            
            tbLandlineNo.Text = jai.LandlineNumber;
            tbMobileNumber.Text = jai.MobileNumber;

            if (jai.DOB != "")
            {
                Label_dob.Text = Convert.ToDateTime(jai.DOB).ToString("MM-dd-yyyy");
              
            }


            _ddlPriv.SelectedValue = Convert.ToInt32(jai.Priv).ToString();
            _ddlPriv.Enabled = false;
            Label_Status.Text = jai.Status;
            DOB1.Visible = false;
        }

        protected void ibeditmode_Click(object sender, ImageClickEventArgs e)
        {
            EditMode();
        }

        private void EditMode()
        {

            ibUpdate.Visible = true; ibUpdate.Enabled = true;
            ibCancel.Visible = true; ibCancel.Enabled = true;
            ibeditmode.Visible = false; ibeditmode.Enabled = false;
            tbName.ReadOnly = false;
            tbDesignation.ReadOnly = false;           
            tbLandlineNo.ReadOnly = false;
            tbMobileNumber.ReadOnly = false;
            _ddlPriv.Enabled = true;
            DOB1.Visible = true;
            Label_dob.Visible = false;
        }

        private void ViewMode()
    {

        ibeditmode.Visible = true; ibeditmode.Enabled = true;
        ibUpdate.Visible = false; ibUpdate.Enabled = false;
        ibCancel.Visible = false; ibCancel.Enabled = false;        
        tbName.ReadOnly = true;
        tbDesignation.ReadOnly = true;
        _ddlPriv.Enabled = false;
        tbLandlineNo.ReadOnly = true;
        tbMobileNumber.ReadOnly = true;
        DOB1.Visible = false;
        Label_dob.Visible = true;
                 
    }

        protected void ibUpdate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //checking the date of birth for 
                //1. if it is selected or not 
                //2. if selected valid or not
                string dateOfBirth = DOB1.getDob();

                //if it is not null it means it is selected
                if (dateOfBirth != null) 
                {
                    //if selcted and date is valid then add to databse
                    if (dateOfBirth != "invalid")
                    {                        
                        SystemUsers update = new SystemUsers();
                        update.UpdateSUser(Label_empid.Text, tbName.Text, _ddlPriv.SelectedValue.ToString(), tbDesignation.Text, dateOfBirth, tbMobileNumber.Text, tbLandlineNo.Text, Session["EmpID"].ToString());
                        DisplayUserDetails();
                        ViewMode();                        
                    } 
                }
                //if it is not selected at all in the first place,and label already has old non-empty string i.e the dob               
                //then update to databse with the existing dob

                else if (Label_dob.Text != String.Empty)
                {
                    SystemUsers newUser = new SystemUsers();
                    newUser.UpdateSUser(Label_empid.Text, tbName.Text, _ddlPriv.SelectedValue.ToString(), tbDesignation.Text, Label_dob.Text, tbMobileNumber.Text, tbLandlineNo.Text, Session["EmpID"].ToString());
                    DisplayUserDetails();
                    ViewMode();                   
                }
                    //else update without dob
                else
                {
                    SystemUsers newUser = new SystemUsers();
                    newUser.UpdateSUserPartial(Label_empid.Text, tbName.Text, _ddlPriv.SelectedValue.ToString(), tbDesignation.Text, tbMobileNumber.Text, tbLandlineNo.Text, Session["EmpID"].ToString());
                    DisplayUserDetails();
                    ViewMode();                    
                }
                Label1.Text = "System User details successfully updated.";
                    }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSYSUSER + "Details updated", Request["EmpID"].ToString());            
        }

      

        

        protected void ibCancel_Click(object sender, ImageClickEventArgs e)
        {
            ViewMode();
        }

      

       

  
       

    

        

        

    }
    
}
