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
    public partial class SearchUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _tbSearchText.Focus();
                _gvUsers.Visible = false;
            }
        }

        private void SearchUsers()
        {
            try
            {
                if (_radBtnSearchByUsername.Checked == true)
                {
                    _gvUsers.DataSource = BroadbandUser.SearchSubscribersByUsername(_tbSearchText.Text).Tables[0];
                }
                else if (_radBtnSearchByUserID.Checked == true)
                {
                    _gvUsers.DataSource = BroadbandUser.SearchSubscribersByUserID(_tbSearchText.Text).Tables[0];
                }

                _gvUsers.DataBind();
                _gvUsers.Visible = true;

            }
           
               catch (Exception ex)
                {
                    Session["ErrorMsg"] = ex.ToString();
                    Response.Redirect("~/Error.aspx", false);
                }
            
        }

        private void SearchUsersByUserID()
        {
            try
            {
                _gvUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.ACTIVE).Tables[0];
                _gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvUsers.PageIndex = e.NewPageIndex;
            SearchUsers();
        }

        protected void _gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string name = e.CommandName;
            string sid = e.CommandArgument.ToString();
           
            BroadbandUser buser = new BroadbandUser();
            switch (name)
            {
                   
                case "Act" :              
                    buser.UpdateSubscriberStatus(sid, UpdateStatus.ACTIVATE);
                    SearchUsers();
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSUBSCRIBER + LogEvents.ACTIVATE, sid);
                    break;
                case "Dea" :
                    buser.UpdateSubscriberStatus(sid, UpdateStatus.DEACTIVATE);
                    SearchUsers();
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSUBSCRIBER + LogEvents.DEACTIVATE, sid);
                    break;               
                default:
                    throw new Exception("Error: Invalid action");

            }
            


        }


        protected void _gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pagenum = _gvUsers.PageIndex;
            SearchUsers();
            _gvUsers.PageIndex = pagenum;
        }

        protected void _btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchUsers();
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SEARCH + _tbSearchText.Text);
        }

        protected void _gvUsers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                SetPagerButtonStates(_gvUsers, e.Row, this);
            }

        }
        protected void _gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string text = GridViewBoundFieldAccess.GetText(e.Row, "STATUS");
                if (text == "A")
                {
                    ImageButton imgBtn = (ImageButton)e.Row.FindControl("ImageButton_Activate");
                    imgBtn.Visible = false;
                                       
                }
                else if ((text == "D") || (text == "P") || (text == "T"))
                {
                    ImageButton imgBtn = (ImageButton)e.Row.FindControl("ImageButton_DeActivate");
                    imgBtn.Visible = false;
                }

            }
        }


        public static void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page)
        {
            int pageIndex = gridView.PageIndex;
            int pageCount = gridView.PageCount;

            /*Button btnFirst = (Button)gvPagerRow.FindControl("btnFirst");
            Button btnPrevious = (Button)gvPagerRow.FindControl("btnPrevious");
            Button btnNext = (Button)gvPagerRow.FindControl("btnNext");
            Button btnLast = (Button)gvPagerRow.FindControl("btnLast");



            btnFirst.Enabled = btnPrevious.Enabled = (pageIndex != 0);
            btnNext.Enabled = btnLast.Enabled = (pageIndex < (pageCount - 1));*/

            DropDownList ddlPageSelector = (DropDownList)gvPagerRow.FindControl("ddlPageSelector");

            ddlPageSelector.Items.Clear();

            for (int i = 1; i <= gridView.PageCount; i++)
            {
                ddlPageSelector.Items.Add(i.ToString());
            }

            ddlPageSelector.SelectedIndex = pageIndex;

        }

        protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gvUsers.PageIndex = ((DropDownList)sender).SelectedIndex;
            SearchUsers();
            
        }
    }
}
