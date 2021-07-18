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
    public partial class DarkFiberConnections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowDarkFiberConnections();
                try
                {
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VPENDINGC);
                }
                catch { }

            }
        }


        private void ShowDarkFiberConnections()
        {
            try
            {
              

                _gvPendingConnections.DataSource = AccountMaster.GetFiberAccoutns();
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
          
        }

        protected void _gvActiveBroadbandUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Open")
            {
                String commentid = Convert.ToString(e.CommandArgument);
               
                ShowDarkFiberConnections();
            }
        }    



        public static void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page)
        {


            int pageIndex = gridView.PageIndex;
            int pageCount = gridView.PageCount;


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
            ShowDarkFiberConnections();

        }

    }      
}
