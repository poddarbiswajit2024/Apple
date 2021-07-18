using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class AgentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            BroadbandAgents regAgent = new BroadbandAgents();
            try
            {
                regAgent.RegisterAgents(_tbAgentName.Text, _tbAgentAddress.Text, _tbContactNumber.Text, Session["EmpID"].ToString());
                _lblSuccess.Text = "Agent Sucessfully Registered:";                
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ADD + LogEvents.AGENT + _tbAgentName.Text);
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
