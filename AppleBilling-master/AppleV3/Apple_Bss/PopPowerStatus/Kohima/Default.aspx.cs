using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple_Bss.CodeFile;

namespace Apple_Bss.PopPowerStatus.Kohima
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

            //come latest time on first page load also
            DisplayLatestTimeinGridview();
            PopulatePOPListingByStatus();

        }


        private void PopulatePOPListingByStatus()
        {
            try
            {
                gvPopList.DataSource = Pop.GetPOPPowerListByStatusKohimawithTime();
                gvPopList.DataBind();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Response.Write("There is an error connecting to or with the database. Re-trying in another minute...");
                Label1.ToolTip = ex.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("There is an error with the application. Re-trying in another minute...");
                Label1.ToolTip = ex.ToString();

            }
        }

        private void DisplayLatestTimeinGridview()
        {
            gvPopList.Columns[4].HeaderText = "STATUS on " + DateTime.Now.ToString("h:mm tt ") + DateTime.Now.DayOfWeek.ToString().Remove(3) + " " + DateTime.Now.ToString("d MMM yyyy");
        }




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //change timestamp
                DisplayLatestTimeinGridview();

                //fetch the current state value
                int currentstate = (int)DataBinder.Eval(e.Row.DataItem, "CURRSTATE");
                //1 = power and battery up -status up
                //2 = power down, battery up - status up
                //3 = power up, batttery down -status down
                //4 = power and battery down - status down
                Image imgPower = (Image)e.Row.FindControl("imgCurrentAvailable");
                Image imgBattery = (Image)e.Row.FindControl("imgBatteryAvailble");
                Image imgpopstatus = (Image)e.Row.FindControl("imgPopStatus");
                Label lblStatus = (Label)e.Row.FindControl("lblPopStatus");



                switch (currentstate)
                {
                    case 1:
                        lblStatus.Text = "RUNNING";
                        imgPower.ImageUrl = DBConn.GetIconsPath() + "current_available.png";
                        imgBattery.ImageUrl = DBConn.GetIconsPath() + "battery_available.png";
                        break;
                    case 2:
                        lblStatus.Text = "RUNNING";
                        imgPower.ImageUrl = DBConn.GetIconsPath() + "current_notavailable.png";
                        imgBattery.ImageUrl = DBConn.GetIconsPath() + "battery_available.png";

                        break;
                    case 3:

                        lblStatus.Visible = false;

                        imgPower.ImageUrl = DBConn.GetIconsPath() + "current_available.png";
                        imgBattery.ImageUrl = DBConn.GetIconsPath() + "battery_notavailable.png";
                        imgpopstatus.ImageUrl = DBConn.GetIconsPath() + "downanimated.gif";
                        imgpopstatus.Visible = true;
                        break;
                    case 4:

                        lblStatus.Visible = false;

                        imgPower.ImageUrl = DBConn.GetIconsPath() + "current_notavailable.png";
                        imgBattery.ImageUrl = DBConn.GetIconsPath() + "battery_notavailable.png";
                        imgpopstatus.ImageUrl = DBConn.GetIconsPath() + "downanimated.gif";
                        imgpopstatus.Visible = true;
                        break;
                    default:
                        break;
                }
            }


        }
    }
}