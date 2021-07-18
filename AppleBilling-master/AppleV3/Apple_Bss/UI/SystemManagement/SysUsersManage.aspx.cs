using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.SystemManagement
{
    public partial class SysUsersManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SystemUsersList();
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEW + LogEvents.SYSUSER + "s");
            }
        }

        private void SystemUsersList()
        {
            try
            {
                _gvSUsers.DataSource = SystemUsers.GetSystemUsers().Tables[0];
                _gvSUsers.DataBind(); 
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }



        protected void _gvSUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvSUsers.PageIndex = e.NewPageIndex;
            SystemUsersList();
        }

        protected void _gvSUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string empID = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "DeAct")
            {
                SystemUsers.ChangeUserStatus(empID, Session["EmpID"].ToString(),"D");
                
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSYSUSER + LogEvents.ACTIVATE, empID);
            }
            else if (e.CommandName == "Act")
            {
                SystemUsers.ChangeUserStatus(empID, Session["EmpID"].ToString(), "A");
                
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSYSUSER + LogEvents.DEACTIVATE, empID);
            }
            else if (e.CommandName == "Delete")
            {
                SystemUsers.DeleteSUserByID(empID);
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSYSUSER + LogEvents.DELETE, empID);
            }
            SystemUsersList();
            
        }

        protected void _gvSUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //status image
                Image imgS = (Image)e.Row.FindControl("ImgStatus");
                //action image
                ImageButton imgBtn = (ImageButton)e.Row.FindControl("ImgBtnDeact");
                if (imgS.AlternateText == "D")
                {
                    //for status image   
                    imgS.ImageUrl = "~/Images/Buttons/deactivate.png";
                    //for action image
                    imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Activate this user?')");
                    imgBtn.AlternateText = "Activate";
                    imgBtn.ToolTip = "Activate";
                    imgBtn.ImageUrl = "~/Images/Buttons/activate.png";
                    imgBtn.CommandName = "Act";
                }
                //else if (imgS.AlternateText == "A")
                else
                {
                    //for action
                    imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Deactivate this user ?')");                    
                }
           
        }

        }

        protected void _gvSUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SystemUsersList();
            _gvSUsers.PageIndex = _gvSUsers.PageIndex;
        }



    }    
  
}
