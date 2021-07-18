using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class PointOfPresenceView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PointOfPresenceListing();
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VPOP);

            }
        }

        private void PointOfPresenceListing()
        {
            try
            {
                _gvPop.DataSource = Pop.GetPointOfPresence();
                _gvPop.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvPop_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvPop.PageIndex = e.NewPageIndex;
            PointOfPresenceListing();
        }

        protected void _gvPop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String popID = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "DeAct")
            {                
                Pop.PopDeActivate(popID, Session["EmpID"].ToString());
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.POP + LogEvents.DEACTIVATE, popID);
             
            }
            else if (e.CommandName == "Act")
            {
                Pop.PopActivate(popID, Session["EmpID"].ToString());
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.POP + LogEvents.ACTIVATE, popID);
            }
            else if (e.CommandName == "Delete")
            {
                Pop.PopDeleteByID(popID);
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.POP + LogEvents.DELETE, popID);
            }
            PointOfPresenceListing();
        }

   

        protected void _gvPop_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvPop.PageIndex;
            //commented bcos already used in row command
            //PointOfPresenceListing();
            _gvPop.PageIndex = pagenum;
        }
    }
}
