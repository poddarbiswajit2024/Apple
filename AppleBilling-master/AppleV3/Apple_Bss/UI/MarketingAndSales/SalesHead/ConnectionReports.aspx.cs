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

namespace Apple_Bss.UI.MarketingAndSales.SalesHead
{
    public partial class ConnectionReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayConnectionReports();
                MonthlyConnectionSummary();
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWCONNECTIONREPORTS);
            }
        }

        private void DisplayConnectionReports()
        {
            int[] Counts = new int[4];
            Counts = BroadbandUser.GetSubscribersCounts();
            lbConnectedUsers.Text = Counts[0].ToString();
            lblTempDisconnct.Text = Counts[1].ToString();
            lblDisconnected.Text = Counts[2].ToString();
            lblTotalUsrs.Text = Counts[3].ToString();

        }

        private void MonthlyConnectionSummary()
        {
            DataSet dst = new DataSet();
            dst = BroadbandUser.GetSubscribersByMonth();
            GridView1.DataSource = dst.Tables["TotalConnection"];
            GridView1.DataBind();
            GridView2.DataSource = dst.Tables["NewConnection"];
            GridView2.DataBind();

        }



        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            MonthlyConnectionSummary();
            GridView2.PageIndex = e.NewPageIndex;
            MonthlyConnectionSummary();
        }
    }
}
