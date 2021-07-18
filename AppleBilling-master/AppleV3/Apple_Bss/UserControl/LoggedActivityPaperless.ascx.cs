using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
using System.Data;

namespace Apple_Bss.UserControl
{
    public partial class LoggedActivityPaperless : System.Web.UI.UserControl
    {
        private static DataSet dsMain = new DataSet();
        private static int pageno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["EmpID"] != null)
                    {
                        dsMain = SystemEventLog.ListLoggedEvents(Session["EmpID"].ToString());
                        GridView1.DataSource = dsMain.Tables[0];
                        GridView1.DataBind();
                        //lblToday.Text = "My Latest Activity ";
                    }
                }
                catch
                {
                    throw;
                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            pageno = GridView1.PageIndex + 1;

            if (pageno > 1)
            {
                lblToday.Text = "My Older Activity (" + pageno + " of " + GridView1.PageCount + ")";

            }
            else
            {
                lblToday.Text = "My Latest Activity";
            }
            GridView1.DataSource = dsMain.Tables[0];
            GridView1.DataBind();
        }
    }
}