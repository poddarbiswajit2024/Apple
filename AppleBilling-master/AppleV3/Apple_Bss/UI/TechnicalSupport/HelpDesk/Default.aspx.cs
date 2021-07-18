using System;
using System.Data;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;
namespace Apple_Bss.UI.TechnicalSupport.HelpDesk
{
    public partial class Default : System.Web.UI.Page
    {        
        private static DataTable dt = new DataTable();
        private static int pageno;
        SMS_SR sms = new SMS_SR();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //need to retrieve those sms sr that was sent by client but couldnt be saved in apple db


                     dt = sms.ListSMS_ServiceRequests();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        lblToday.Text = dt.Rows.Count.ToString();
                      
                    }
                    else
                    {
                        divnewnotice.Visible = false;
                        divNoSRNotice.Visible = true;
                        //CollapsiblePanelExtender1.Enabled = false;
                    }

                
                    if (GridView1.PageCount > 1)
                    {
                        lblPageNo.Text = "Page 1 of " + GridView1.PageCount;

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
                lblPageNo.Text = "Page " + pageno + " of " + GridView1.PageCount;

            }
            else if (GridView1.PageCount > 1)
                {
                    lblPageNo.Text = "Page 1 of " + GridView1.PageCount;

                }
            
            
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void lbSRNotice_Click(object sender, EventArgs e)
        {

            //GridView1.DataSource = dt;
           // GridView1.DataBind();
            //GridView1.Visible = true;
        }


        


      
        }
    }

