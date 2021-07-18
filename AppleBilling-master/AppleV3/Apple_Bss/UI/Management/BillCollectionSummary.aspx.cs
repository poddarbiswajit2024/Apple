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

namespace Apple_Bss.UI.Management
{
    public partial class BillCollectionSummary : System.Web.UI.Page
    {

        protected static String billCycleStartDate = String.Empty;
        protected static String billCycleEndDate = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBillCycles();
                _btnExportExcel.Visible = false;
            }
        }

        private void PopulateBillCycles()
        {
            String currDate = System.DateTime.Now.ToShortDateString();
            try
            {
                BillCycles bc = new BillCycles();
                _ddlBillCycle.DataSource = bc.GetBillCycleForListing(BillCycleType.ALL,currDate);
                _ddlBillCycle.DataTextField = "BILLCYCLENAME";
                _ddlBillCycle.DataValueField = "BILLCYCLEID";
                _ddlBillCycle.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        //Methhod to catch the cycle start date and cycle end date based on Bill Cycle ID
        // Mod Date :19th April 2010
       
        protected void _ddlBillCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                billCycleStartDate = BillCycles.GetCycleStartDateOfMonthlyCycle(Convert.ToInt32(_ddlBillCycle.SelectedValue));
                billCycleEndDate = BillCycles.GetCycleEndDateOfMonthlyCycle(Convert.ToInt32(_ddlBillCycle.SelectedValue));
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _imgBtnView_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                _btnExportExcel.Visible = true;
                _gvBillCollSummary.DataSource = BillDetails.getBillCollectionSummary(Convert.ToInt32(_ddlBillCycle.SelectedValue),billCycleStartDate,billCycleEndDate).Tables[0];
                _gvBillCollSummary.DataBind();
                _lblMsg.Text = "<b>Bill Collection Summary for the Month of : <font color=green>"+_ddlBillCycle.SelectedItem.ToString().ToUpper() +" </font></b>";
            }
            catch(Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void _btnExportExcel_Click(object sender, EventArgs e)
        {
  
          //  DisableControls(_gvBillCollSummary); comment out if there are any asp.net controls
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
           _gvBillCollSummary.RenderControl(htmlWrite);

            
           
            Response.Write(stringWrite.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }

       //find the asp.net controls on the gridview if any and remove it before exporting
       // private void DisableControls(Control gv)
       /* {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();

            string name = String.Empty;

            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }

                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }


                if (gv.Controls[i].HasControls())
                {
                    DisableControls(gv.Controls[i]);
                }
            }

        }
            */
        
    }
}
