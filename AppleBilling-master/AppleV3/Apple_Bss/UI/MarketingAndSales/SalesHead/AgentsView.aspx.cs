using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class AgentsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAgentList();
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VAGENTS);

            }
        }

        private void ShowAgentList()
        {
            try
            {
                _gvAgentList.DataSource = BroadbandAgents.GetAllAgents().Tables[0];
                _gvAgentList.DataBind();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _gvAgentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvAgentList.PageIndex = e.NewPageIndex;
            ShowAgentList();
        }

        protected void _gvAgentList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Activate this agent?')");
                    imgBtn.AlternateText = "Activate";
                    imgBtn.ToolTip = "Activate";
                    imgBtn.ImageUrl = "~/Images/Buttons/activate.png";
                    imgBtn.CommandName = "Act";
                }
                //else if (imgS.AlternateText == "A")
                else
                {
                    //for action
                    imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Deactivate this agent?')");
                }
            }
        }

        protected void _gvAgentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String agentCode = Convert.ToString(e.CommandArgument);
            string actionPerformed = String.Empty;
            if (e.CommandName == "DeAct")
            {
                BroadbandAgents.AgentDeActivate(agentCode, Session["EmpID"].ToString());
                actionPerformed = " Deactivated"; 
                ShowAgentList();
            }
            else if (e.CommandName == "Act")
            {
                BroadbandAgents.AgentActivate(agentCode, Session["EmpID"].ToString());
                actionPerformed = " Activated";
                ShowAgentList();
            }
            else if (e.CommandName == "Delete")
            {
                BroadbandAgents.AgentDeleteByAgentCode(agentCode);
                actionPerformed = " Deleted";
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.AGENT + actionPerformed, agentCode);

        }


        protected void _gvAgentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvAgentList.PageIndex;
            ShowAgentList();
            _gvAgentList.PageIndex = pagenum;
            
        }
    }
   
}
