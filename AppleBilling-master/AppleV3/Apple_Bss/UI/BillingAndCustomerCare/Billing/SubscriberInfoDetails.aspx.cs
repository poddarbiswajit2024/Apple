using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class SubscriberInfoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserInfoDetails();
              
            }
        }

        protected void _btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (_radBtnSearch.SelectedValue=="UNAME")
                {                   
                    _gvUsers.DataSource = BroadbandUser.SearchSubscribersByUsername(_tbSearchText.Text).Tables[0];
                }
                else if (_radBtnSearch.SelectedValue == "UID")
                {                   
                    _gvUsers.DataSource = BroadbandUser.SearchSubscribersByUserID(_tbSearchText.Text).Tables[0];
                }

                _gvUsers.DataBind();


            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SEARCH + _tbSearchText.Text);

        }

        private void UserInfoDetails()
        {
            try
            {
                _gvUsers.DataSource = BroadbandUser.GetSubscriberList(BroadbandUserStatus.ALL).Tables[0];
                _gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvUsers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                SetPagerButtonStates(_gvUsers, e.Row, this);
            }
        }

      
        protected void _gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvUsers.PageIndex = e.NewPageIndex;
            UserInfoDetails();
        }

        public static void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page)
        {


            int pageIndex = gridView.PageIndex;
            int pageCount = gridView.PageCount;

            DropDownList ddlPageSelector = (DropDownList)gvPagerRow.FindControl("ddlPageSelector");
              Label lblPage = (Label)gvPagerRow.FindControl("_lblCurrentPageNumber");
            ddlPageSelector.Items.Clear();

            for (int i = 1; i <= gridView.PageCount; i++)
            {
                ddlPageSelector.Items.Add(i.ToString());
            }

            lblPage.Text = "Showing page &nbsp;" + "<b>" + (gridView.PageIndex + 1).ToString() + "</b>&nbsp;&nbsp; of<b>&nbsp;&nbsp;" + gridView.PageCount + "<b/>";
            ddlPageSelector.SelectedIndex = pageIndex;

        }

        protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gvUsers.PageIndex = ((DropDownList)sender).SelectedIndex;
            UserInfoDetails();

        }
    }
}
