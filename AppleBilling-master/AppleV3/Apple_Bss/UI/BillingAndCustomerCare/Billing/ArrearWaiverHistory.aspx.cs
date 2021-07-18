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

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ArrearWaiverHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _panelArrear.Visible = false;
            _panelWaiver.Visible = false;           
            _lblBc.Text = DBConn.GetBranchCode();
        }
        
       
        protected void _btnViewHistory_Click(object sender, ImageClickEventArgs e)
        {
            String strUserID = _lblBc.Text + "-SCLX" + _txtUserID.Text;

           if(BroadbandUser.IsValidUserID(strUserID))
           {
                if (_rbtnArWaiv.SelectedValue == "A")
                {
                    _panelArrear.Visible = true;
                    _panelWaiver.Visible = false;
                    _gvArrearHistory.DataSource = ArrearsAndWaivers.GetArrearWaiverHistory(strUserID, "A");
                    _lblValidUser.Visible = false;
                    _gvArrearHistory.DataBind();
                }
                else if (_rbtnArWaiv.SelectedValue == "W")
                {
                    _panelWaiver.Visible = true;
                    _panelArrear.Visible = false;
                    _gvWaiverHistory.DataSource = ArrearsAndWaivers.GetArrearWaiverHistory(strUserID, "W");
                    _lblValidUser.Visible = false;
                    _gvWaiverHistory.DataBind();
                }
                SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEW + _rbtnArWaiv.SelectedItem + " for userid : " + strUserID, strUserID); 

           }
            else
           {
               _lblValidUser.Visible = true;
               _lblValidUser.Text="Invalid User ID:";
           }

        }

       
    }
}
