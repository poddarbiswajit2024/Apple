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
    public partial class PointOfPresenceEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String popID = Utilities.QueryStringDecode(Request["popid"]);
                Pop getPop = new Pop(popID);
                _tbPopName.Text = getPop.PopName;
                _tbPopAddress.Text = getPop.PopAddress;
                _tbContactPerson.Text = getPop.PopConatactPerson;
                _tbMobileNo.Text = getPop.MobileNumber;
                _tbLandLineNo.Text = getPop.LandlineNumber;
                tbGPDIP.Text = getPop.GBDIP;
                tbBPDIP.Text = getPop.BPDIP;
                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(getPop.LocationCode));
            }
        }


        protected void _btnUpdatePop_Click(object sender, ImageClickEventArgs e)
        {
            String popID = Utilities.QueryStringDecode(Request["popid"]);
            try
            {
                if (Page.IsValid)
                {
                    Pop update = new Pop();
                    update.PopUpdate(popID, _tbPopName.Text, _tbPopAddress.Text, _tbContactPerson.Text, _tbMobileNo.Text, _tbLandLineNo.Text, Session["EmpID"].ToString(), tbGPDIP.Text, tbBPDIP.Text, ddlLocation.SelectedValue.ToString());
                    _lblSuccess.Text = "POP Sucessfully Updated";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.UPDATE + LogEvents.POP + _tbPopName.Text, popID);
                    ClearForm();
                }
                else
                {
                    _lblSuccess.Text = "Error! Enter All required fields.";
                }

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx");
            }
        
        }

        private void ClearForm()
        {
            _tbPopName.Text = String.Empty;
            _tbPopAddress.Text = String.Empty;
            _tbContactPerson.Text = String.Empty;
            _tbMobileNo.Text = String.Empty;
            _tbLandLineNo.Text = String.Empty;
            tbBPDIP.Text = String.Empty;
            tbGPDIP.Text = String.Empty;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PointOfPresenceView.aspx");
        }
    }
}
