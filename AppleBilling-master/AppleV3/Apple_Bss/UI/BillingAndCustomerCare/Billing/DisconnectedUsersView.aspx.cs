using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class DisconnectedUsersView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisconnectionListing();

                try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEW + LogEvents.TEMPDISCONNECTEDUSR + "s");
                }
                catch
                {
                }
            }
        }


        private void DisconnectionListing()
        {
             try
            {
            if (_rbtnListStatus.SelectedValue == "T")
            {
                _gvTempDisconnectUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.TEMPORARILYDISCONNECTED).Tables[0];
                _gvTempDisconnectUsers.DataBind();
            }
            else if (_rbtnListStatus.SelectedValue == "P")
            {
                _gvTempDisconnectUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.PERMANENTLYDISCONNECTED).Tables[0];
                _gvTempDisconnectUsers.DataBind();
            }
            else
            {
                _gvTempDisconnectUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.DEACTIVATED).Tables[0];
                _gvTempDisconnectUsers.DataBind();
            }

           
                

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _gvTempDisconnectUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _gvTempDisconnectUsers.PageIndex = e.NewPageIndex;
                DisconnectionListing();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _btnViewUsers_Click(object sender, ImageClickEventArgs e)
        {
            _gvTempDisconnectUsers.PageIndex = 0;
            DisconnectionListing();
           // SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSRS + _rbtnListStatus.SelectedItem);
        }
    }
  
}
