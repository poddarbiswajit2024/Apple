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

namespace Apple_Bss.UI.NetworkManagement
{
    public partial class BroadbandUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateActiveBroadbandUsers();
                try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSRS);
                }
                catch
                {
                }

            }
        }

        private void PopulateActiveBroadbandUsers()
        {
            try
            {
                if (_rbtnListStatus.SelectedValue == "AL")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.ALL);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</b>&nbsp;Subscriber&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.ALL) + "</font></b>";
                }
                else if (_rbtnListStatus.SelectedValue == "A")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.ACTIVE);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=green><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.ACTIVE) + "</font></b>";
                }
                else if(_rbtnListStatus.SelectedValue=="D")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.DEACTIVATED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=red><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.DEACTIVATED) + "</font></b>";
                }
                else if (_rbtnListStatus.SelectedValue== "T")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.TEMPORARILYDISCONNECTED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=Orange><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.TEMPORARILYDISCONNECTED) + "</font></b>";
                }
               
                else if (_rbtnListStatus.SelectedValue == "P")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.PERMANENTLYDISCONNECTED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=Red><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.PERMANENTLYDISCONNECTED) + "</font></b>";
                }
                else
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.ALL);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.ALL) + "</font></b>";
                }

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _gvActiveBroadBandUsers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                SetPagerButtonStates(_gvActiveBroadBandUsers, e.Row, this);
            }

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
              //  lblPage.Text = "Showing page &nbsp;" + i.ToString() + "&nbsp;of" + gridView.PageCount;
            }
            lblPage.Text = "Showing page &nbsp;" + "<b>"+(gridView.PageIndex +1).ToString() + "</b>&nbsp;&nbsp; of<b>&nbsp;&nbsp;" + gridView.PageCount+"<b/>";
            ddlPageSelector.SelectedIndex = pageIndex;

        }

        
        protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gvActiveBroadBandUsers.PageIndex = ((DropDownList)sender).SelectedIndex;
            PopulateActiveBroadbandUsers();
           
        }

        protected void _gvActiveBroadBandUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvActiveBroadBandUsers.PageIndex = e.NewPageIndex;
            PopulateActiveBroadbandUsers();
        }

        protected void _btnViewUsers_Click(object sender, ImageClickEventArgs e)
        {
            _gvActiveBroadBandUsers.PageIndex = 0;
            PopulateActiveBroadbandUsers();
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VBROADBANDUSRS + _rbtnListStatus.SelectedItem);
           
        }

  
        protected void _btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchUsers();
            SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SEARCH + _tbUserName.Text);
            _lblTotalUsers.Visible = false;
              
        }

        private void SearchUsers()
        {
            try
            {
                _gvActiveBroadBandUsers.DataSource = BroadbandUser.SearchSubscribersByUsername(_tbUserName.Text);
                _gvActiveBroadBandUsers.DataBind();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }

        }

        protected void _gvActiveBroadBandUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
             
                //action image
                string strStatus = GridViewBoundFieldAccess.GetText(e.Row, "STATUS");
                ImageButton imgBtn = (ImageButton)e.Row.FindControl("ImgBtnDeact");
                if (strStatus == "A")
                {                    
                    //for action image
                    imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Deactivate this user?')");
                                      
                }                
                else
                {//if not active
                    //for action
                    imgBtn.Visible = false;
                    //commented bcos no activate functionality for network manager
                    //imgBtn.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to Activate this user ?')");                    
                  //  imgBtn.AlternateText = "Activate";
                   // imgBtn.ToolTip = "Activate";
                   // imgBtn.ImageUrl = "~/Images/Buttons/activate.png";
                  //  imgBtn.CommandName = "Act";
                }
           
        }
        }

        protected void _gvActiveBroadBandUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        
            string name = e.CommandName;
            string sid = e.CommandArgument.ToString();
           
            BroadbandUser buser = new BroadbandUser();
            if(name == "Dea")
            {
                    buser.UpdateSubscriberStatus(sid, UpdateStatus.DEACTIVATE);
                    SearchUsers();
                   SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPSUBSCRIBER + LogEvents.DEACTIVATE, sid);
            }
            }
        }
}       
