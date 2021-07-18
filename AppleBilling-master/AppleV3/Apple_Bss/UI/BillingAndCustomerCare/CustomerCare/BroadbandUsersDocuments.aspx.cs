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


namespace Apple_Bss.UI.BillingAndCustomerCare.CustomerCare
{
    public partial class BroadbandUsersDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                Label2.Text = DBConn.GetBranchCode();
                
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
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.ALL);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</b>&nbsp;Subscriber&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.ALL) + "</font></b>";
                }
                else if (_rbtnListStatus.SelectedValue == "A")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.ACTIVE);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=green><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.ACTIVE) + "</font></b>";
                }
                else if (_rbtnListStatus.SelectedValue == "D")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.DEACTIVATED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=red><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.DEACTIVATED) + "</font></b>";
                }
                else if (_rbtnListStatus.SelectedValue == "T")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.TEMPORARILYDISCONNECTED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=Orange><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.TEMPORARILYDISCONNECTED) + "</font></b>";
                }

                else if (_rbtnListStatus.SelectedValue == "P")
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.PERMANENTLYDISCONNECTED);
                    _gvActiveBroadBandUsers.DataBind();
                    _lblTotalUsers.Text = "Number of &nbsp;<font color=Red><b>" + _rbtnListStatus.SelectedItem.ToString().ToUpper() + "</font></b>&nbsp;Subscribers&nbsp;=&nbsp;<b><font color=red>" + BroadbandUser.GetNumberOfUsers(BroadbandUserStatus.PERMANENTLYDISCONNECTED) + "</font></b>";
                }
                else
                {
                    _gvActiveBroadBandUsers.DataSource = BroadbandUser.BroadbandUsersDocuments(BroadbandUserStatus.ALL);
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
            lblPage.Text = "Showing page &nbsp;" + "<b>" + (gridView.PageIndex + 1).ToString() + "</b>&nbsp;&nbsp; of<b>&nbsp;&nbsp;" + gridView.PageCount + "<b/>";
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
                //modify the function name
                _gvActiveBroadBandUsers.DataSource = BroadbandUser.SearchUserByUsername(_tbUserName.Text);
                
                _gvActiveBroadBandUsers.DataBind();
            }

            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        
           



           

        


     
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }
        //find the asp.net controls on the gridview if any and remove it before exporting
         private void DisableControls(Control gv)
        {
          
             UpdateProgress up = new UpdateProgress();

             string name = String.Empty;

             for (int i = 0; i < gv.Controls.Count; i++)
             {
                 if (gv.Controls[i].GetType() == typeof(UpdateProgress))
                 {
                     up.ID = (gv.Controls[i] as UpdateProgress).ID;
                     gv.Controls.Remove(gv.Controls[i]);
                   //  gv.Controls.AddAt(i, up);
                 }

             

                 if (gv.Controls[i].HasControls())
                 {
                     DisableControls(gv.Controls[i]);
                 }
             }

         }

         protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
         {
             string strUserid = "";
             strUserid = DBConn.GetBranchCode() + "-SCLX" + _tbUserID.Text;
             SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SEARCH + strUserid);
             //SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.SEARCH + _tbUserID.Text);
             _lblTotalUsers.Visible = false;
             //string strUserid = "";
             //strUserid = DBConn.GetBranchCode() + "-SCLX" + _tbUserID.Text;

         //}
         //private void SearchUsersbyId()
         //{
           
            
             try
             {

                 _gvActiveBroadBandUsers.DataSource = BroadbandUser.SearchUserByUserID(strUserid);
                 //_gvActiveBroadBandUsers.DataSource = BroadbandUser.SearchUserByUserID(_tbUserID.Text);

                 _gvActiveBroadBandUsers.DataBind();
             }

             catch (Exception ex)
             {
                 Session["ErrorMsg"] = ex.ToString();
                 Response.Redirect("~/Error.aspx", false);
             }
         }

         
             
    }
}