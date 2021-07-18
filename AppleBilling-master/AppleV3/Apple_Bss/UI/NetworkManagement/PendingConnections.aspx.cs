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
    public partial class PendingConnections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //_gvActiveBroadbandUsers.PageIndex = 0;
                ShowPendingConnections();
              //  SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VPENDINGC );


            }
        }


        private void ShowPendingConnections()
        {
            try
            {
                //_gvActiveBroadbandUsers.DataSource = BroadbandUser.BroadbandUserList(BroadbandUserStatus.ACTIVE).Tables[0];
                //_gvActiveBroadbandUsers.DataBind();

                _gvPendingConnections.DataSource = RegisteredBroadbandUsers.GetPendingConnections().Tables[0];
                _gvPendingConnections.DataBind();

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void _gvActiveBroadbandUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //_gvActiveBroadbandUsers.PageIndex = e.NewPageIndex;
            //ShowActiveBroadbandUsers();
        }

        protected void _gvActiveBroadbandUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Open")
            {
                String commentid = Convert.ToString(e.CommandArgument);
                //SubscriberComments.ReOpenComment(commentid);
                ShowPendingConnections();
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




        //page index changind for gridview Pending Connections
        protected void _gvPendingConnections_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvPendingConnections.PageIndex = e.NewPageIndex;
            ShowPendingConnections();

        }

    }      
}
