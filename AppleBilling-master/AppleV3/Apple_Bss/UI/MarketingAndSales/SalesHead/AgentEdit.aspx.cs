using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class AgentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String agentCode = Request["agentid"];
                BroadbandAgents bndAgent = new BroadbandAgents(agentCode);
                _tbAgentName.Text = bndAgent.AgentName;
                _tbAgentAddress.Text = bndAgent.Address;
                _tbContactNumber.Text = bndAgent.ContactNumber;
            }
        }

        protected void _btnAgentUpdate_Click(object sender, ImageClickEventArgs e)
        {
            String agentCode = Request["agentid"];
            try
            {              
                BroadbandAgents update = new BroadbandAgents();
                update.AgentUpdate(agentCode, _tbAgentName.Text, _tbAgentAddress.Text, _tbContactNumber.Text, Session["EmpID"].ToString());
                _lblSuccess.Text = "Agent Sucessfully Updated.";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.AGENT + _tbAgentName.Text, agentCode);

            ClearForm();
        }

        private void ClearForm()
        {
            _tbContactNumber.Text = String.Empty;
            _tbAgentAddress.Text = String.Empty;
            _tbAgentName.Text = String.Empty;
        }


    }
  
}
