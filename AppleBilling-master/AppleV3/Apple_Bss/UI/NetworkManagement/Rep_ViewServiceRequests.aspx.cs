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
using System.Globalization;

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class Rep_ViewServiceRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTechSupportUsers();
            }
        }

        //get the Priviledge Level 3 and 7 users and bind it to dropdownlist _ddlSupportName
        private void BindTechSupportUsers()
        {
            _ddlSupportName.DataSource = SystemUsers.GetTechAssistantPrivID().Tables[0];
            _ddlSupportName.DataTextField = "NAME";
            _ddlSupportName.DataValueField = "EMPID";
            _ddlSupportName.DataBind();
            
        }

        // Get Service call records depending on the status 
        private void ShowNmServiceRequest()
        {

            CultureInfo ci = new CultureInfo("en-GB");
            try
            {
                ServiceCallStatus status;

                if (_rbtnSupportType.SelectedValue == "P")
                {
                    status = ServiceCallStatus.PENDING;
                    _gvNmViewPendingServiceRequest.DataSource = ServiceCalls.GetNmServiceRequests(Convert.ToDateTime(_txtStartDate.Text,ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text,ci).ToShortDateString(), status, _ddlSupportName.SelectedValue).Tables[0];

                    _gvNmViewPendingServiceRequest.DataBind();

                    _gvNmViewPendingServiceRequest.Visible = true;
                    _gvNmViewResolvedServiceRequest.Visible = false;
                    _gvNmViewAllServiceRequest.Visible = false;

                }


                else if (_rbtnSupportType.SelectedValue == "R")
                {
                    status = ServiceCallStatus.RESOLVED;
                    _gvNmViewResolvedServiceRequest.DataSource = ServiceCalls.GetNmServiceRequests(Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString(), status, _ddlSupportName.SelectedValue.ToString()).Tables[0];
                    _gvNmViewResolvedServiceRequest.DataBind();

                    _gvNmViewResolvedServiceRequest.Visible = true;
                    _gvNmViewPendingServiceRequest.Visible = false;
                    _gvNmViewAllServiceRequest.Visible = false;
                }
                else if (_rbtnSupportType.SelectedValue == "A")
                {
                    status = ServiceCallStatus.ALL;
                    _gvNmViewAllServiceRequest.DataSource = ServiceCalls.GetNmServiceRequests(Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString(), Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString(), status, _ddlSupportName.SelectedValue.ToString()).Tables[0];
                    _gvNmViewAllServiceRequest.DataBind();

                    _gvNmViewAllServiceRequest.Visible = true;
                    _gvNmViewResolvedServiceRequest.Visible = false;
                    _gvNmViewPendingServiceRequest.Visible = false;

                }


            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _btnShowReport_Click(object sender, ImageClickEventArgs e)
        {
            ShowNmServiceRequest();
            _lblInfo.Text = "<fieldset><legend style='color:#3b5889'>Report Info.</legend>Reporter Name &nbsp;: <font color=red>" + _ddlSupportName.SelectedItem.Text.ToString().ToUpper() + "</font><br/>From Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : <font color=red>" + Convert.ToDateTime(_txtStartDate.Text).ToString("dd-MMMM-yyyy") + " </font><br/>To Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : <font color=red>" + Convert.ToDateTime(_txtEndDate.Text).ToString("dd-MMMM-yyyy") + "</font></fieldset>";

            if (_rbtnSupportType.SelectedValue == "P")
            {
                _lblRequestType.Text = "Pending Request".ToUpper(); ;
            }
            else if (_rbtnSupportType.SelectedValue == "R")
            {
                _lblRequestType.Text = "Resolved Request".ToUpper(); ;
            }
            else if (_rbtnSupportType.SelectedValue == "A")
            {
                _lblRequestType.Text = "All Request".ToUpper(); ;
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VSERVICEREQUESTS + _lblRequestType.Text + " from " + _txtStartDate.Text + " to " + _txtEndDate.Text, _ddlSupportName.SelectedValue);

        }

        protected void _gvNmViewPendingServiceRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
              
                _gvNmViewPendingServiceRequest.PageIndex = e.NewPageIndex;              
                ShowNmServiceRequest();
               
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvNmViewResolvedServiceRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _gvNmViewResolvedServiceRequest.PageIndex = e.NewPageIndex;
                ShowNmServiceRequest();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvNmViewAllServiceRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
              
                _gvNmViewAllServiceRequest.PageIndex = e.NewPageIndex;
                ShowNmServiceRequest();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvNmViewPendingServiceRequest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
