using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Data;

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class ViewRegisteredConnections : System.Web.UI.Page
    {
        //sales executive or sales head id name or agentcode
        private static string strSalesPesonID = "A";
        //also name to display on label message
        //this is the default value
        private static string strSalesPesonName;
        //to store registered users for the grid view
        private static DataSet regUsers = new DataSet();
        //
        private static string strLabelMsg;
        private static int countUsers;
     
                    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-GB");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PopulateAuthorizedRegisteringPersons();

                    //_txtStartDate.Text =_txtEndDate.Text =  DateTime.Today.ToShortDateString();


                    //String _startDate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
                    //String _endDate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
                    //ShowRegistrationByDateRange(_startDate, _endDate, _rbtnStatus.SelectedValue.ToString());
                    //strLabelMsg = "List of <font color=red> " + _rbtnStatus.SelectedItem.ToString().ToUpper() + " </font>registered broadband users from " + Convert.ToDateTime(_txtStartDate.Text).ToString("dd-MMMM-yyyy") + " to " + Convert.ToDateTime(_txtEndDate.Text).ToString("dd-MMMM-yyyy") + ". <font color='red'>  Selected users count : </font>";
                    //lblReportMsg.Text = strLabelMsg + countUsers;
                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        

        //Method to get the list of Pending Connection Subscriber List by Date Range for Sales Head
        private void ShowPendingRegistrationsByDateRange(String pStartDate, String pEndDate, String pStatus)
        {
            try
            {
                regUsers = RegisteredBroadbandUsers.GetRegisteredSubscriberListByDateRangeForSalesHead(pStartDate, pEndDate, pStatus, rblSalesPpl.SelectedValue, strSalesPesonID);
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

        private void ShowRegistrationByDateRange(String pStartDate, String pEndDate, String pStatus)
        {
            try
            {
                _gvRegReport.PageIndex = 0;                
                 regUsers = RegisteredBroadbandUsers.GetRegisteredSubscriberListByDateRangeForSalesHead(pStartDate, pEndDate, pStatus, rblSalesPpl.SelectedValue, strSalesPesonID);
                 _gvRegReport.DataSource = regUsers.Tables[0];
                _gvRegReport.DataBind();
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
    

                String _startDate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
                String _endDate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
                if (_rbtnStatus.SelectedValue == "P")
                {
                    _gvPendingConnection.Visible = true;
                    _gvRegReport.Visible = false;
                    ShowPendingRegistrationsByDateRange(_startDate, _endDate, _rbtnStatus.SelectedValue.ToString());
                }

                else
                {
                    _gvRegReport.Visible = true;
                    _gvPendingConnection.Visible = false;
                    ShowRegistrationByDateRange(_startDate, _endDate, _rbtnStatus.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

            strLabelMsg = "List of <font color=red> " + _rbtnStatus.SelectedItem.ToString().ToUpper() + " </font>registered broadband users for <font color=red>" + rblSalesPpl.SelectedItem.ToString().ToUpper() + " - " + strSalesPesonName.ToUpper() + "</font> from " + Convert.ToDateTime(_txtStartDate.Text).ToString("dd-MMMM-yyyy") + " to " + Convert.ToDateTime(_txtEndDate.Text).ToString("dd-MMMM-yyyy") + ". <font color='red'>  Selected users count : </font>";
            lblReportMsg.Text = strLabelMsg +  countUsers;
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWREGISTRATION + _rbtnStatus.SelectedItem.ToString().ToUpper() + " status. Registered by " + strSalesPesonName + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text);

        }
        protected void _gvPendingConnection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                String strUserId = Convert.ToString(e.CommandArgument);
                RegisteredBroadbandUsers.RegisteredBroadbandUserDeleteByUserID(strUserId);
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.AGENT + e.CommandName, strUserId);

            }
        }



        protected void _gvPendingConnection_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvPendingConnection.PageIndex;
            ShowPendingRegistrationsByDateRange(_txtStartDate.Text, _txtEndDate.Text, _rbtnStatus.SelectedValue.ToString());
            _gvPendingConnection.PageIndex = pagenum;
            countUsers = regUsers.Tables[0].Rows.Count;
            lblReportMsg.Text = strLabelMsg + countUsers;
        }

        protected void PopulateAuthorizedRegisteringPersons()
        {
            //container declartion
            DataSet sales = new DataSet();
            //filling container
            sales = SystemUsers.GetAuthorizedRegisteringPersons();
            //taking the necessary tables from the container
            _ddlSalesExecutive.DataSource = sales.Tables["EMPLOYEES"];
           _ddlSalesExecutive.DataTextField = "NAME";
           _ddlSalesExecutive.DataValueField = "EMPID";
           _ddlSalesExecutive.DataBind();
            //another table, agentstaken from the container
           _ddlAgents.DataSource = sales.Tables["AGENTS"];
           _ddlAgents.DataTextField = "AGENTNAME";
           _ddlAgents.DataValueField = "AGENTCODE";
           _ddlAgents.DataBind();
            
        }
       
        //Grid page Index changinn for _gvRegReport
        protected void _gvRegReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvRegReport.PageIndex = e.NewPageIndex;
            _gvRegReport.DataSource = regUsers.Tables[0];
            _gvRegReport.DataBind();
        }

        protected void _gvPendingConnection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvPendingConnection.PageIndex = e.NewPageIndex;
            _gvPendingConnection.DataSource = regUsers.Tables[0];
            _gvPendingConnection.DataBind();


        }
      

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strSalesPesonID = "A";
            switch (rblSalesPpl.SelectedValue)
            {    
                case "B"://both
                    //set the selected index to all executives and all agents
                    _ddlSalesExecutive.SelectedIndex = 1;
                    _ddlAgents.SelectedIndex = 1;
                    //only all agents and all executives togehter are to be viewed
                    _ddlSalesExecutive.Enabled = false;
                    _ddlAgents.Enabled = false;
                    //to display
                    strSalesPesonName = "ALL EXECUTIVES & AGENTS";                    
                    break;

                case "A"://agents selected 
                    _ddlAgents.Enabled = true;
                    _ddlSalesExecutive.Enabled = false;
                    //default value for agents
                    strSalesPesonName = "ALL AGENTS";
                    //set the selected agent to all agenes
                    _ddlAgents.SelectedIndex = 1;
                    //set the selected value of the other- executives to  null
                    _ddlSalesExecutive.SelectedIndex = 0;
                    //enable required field validator for agent dropdownlist
                    rfvAgent.Enabled = true;
                    //disable for exec
                    rfvExec.Enabled = false;
                    break;

                case "E": //executives selected  
                    _ddlAgents.Enabled = false;
                    _ddlSalesExecutive.Enabled = true;
                    //default value for executives
                    strSalesPesonName = "ALL EXECUTIVES";
                    //set the seleceted value to all executives
                    _ddlSalesExecutive.SelectedIndex = 1;
                    //set the selected value of the other- agents to  null
                    _ddlAgents.SelectedIndex = 0;
                    rfvExec.Enabled = true;
                    //disable for agents
                    rfvAgent.Enabled = false;
                    break;
                default:               
                    break;    
            }
            //button show report is enabled only now after all update panel events occur
            _btnShowReport.Enabled = true;
        }
        //on selection of the sales executive , the id of the executive is stored
        protected void _ddlSalesExecutive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddlSalesExecutive.SelectedValue != "")
            {
                strSalesPesonID = _ddlSalesExecutive.SelectedValue;
                strSalesPesonName = _ddlSalesExecutive.SelectedItem.ToString();
            }
        }
        //on selection of the sales agent , the code of the agent is stored
        protected void _ddlAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ddlAgents.SelectedValue != "")
            {
            strSalesPesonID = _ddlAgents.SelectedValue;
            strSalesPesonName = _ddlAgents.SelectedItem.ToString();           
            }
        }

        
    }
    
}
