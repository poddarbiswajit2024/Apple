using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Data;
using System;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class ManageRejectedRegistrationsAll : System.Web.UI.Page
    {
        //to store registered users for the grid view
        private static DataSet regUsers = new DataSet();
        //
        private static string strLabelMsg;
        private static int countUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ShowPendingRegistrations();

                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }


        private void ShowPendingRegistrations()
        {
            try
            {
                regUsers = RegisteredBroadbandUsers.GetRejectedRegisteredUsers();
                _gvPendingConnection.DataSource = regUsers.Tables[0];
                _gvPendingConnection.DataBind();
                countUsers = regUsers.Tables[0].Rows.Count;


            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }


        protected void _btnShowReport_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                ShowPendingRegistrations();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }


            lblReportMsg.Text = "Number of Pending Registered Users: " + countUsers;
            //SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnStatus.SelectedItem.ToString().ToUpper() + " status. Registered by " + strSalesPesonName + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

        }
        protected void _gvPendingConnection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                RegisteredBroadbandUsers rd = new RegisteredBroadbandUsers();
                String strUserId = Convert.ToString(e.CommandArgument);
               // RegisteredBroadbandUsers.RegisteredBroadbandUserDeleteByUserID(strUserId);
                //SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.AGENT + e.CommandName, strUserId);
                rd.BackForVarification(strUserId);               
                ShowPendingRegistrations();

            }
        }



        protected void _gvPendingConnection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvPendingConnection.PageIndex;
            ShowPendingRegistrations();
            _gvPendingConnection.PageIndex = pagenum;
            countUsers = regUsers.Tables[0].Rows.Count;
            lblReportMsg.Text = strLabelMsg + countUsers;
        }



        protected void _gvPendingConnection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvPendingConnection.PageIndex = e.NewPageIndex;
            _gvPendingConnection.DataSource = regUsers.Tables[0];
            _gvPendingConnection.DataBind();


        }
    }
}