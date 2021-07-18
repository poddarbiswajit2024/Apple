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
    public partial class PointOfPresence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _btnAddPop_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Pop addPop = new Pop();
                    addPop.RegisterPop(_tbPopName.Text, _tbPopAddress.Text, _tbContactPerson.Text, _tbMobileNo.Text, _tbLandLineNo.Text, Session["EmpID"].ToString(), tbGPDIP.Text, tbBPDIP.Text, ddlLocation.SelectedValue.ToString());
                    _lblSuccess.Text = "POP " + _tbPopName.Text + " Sucessfully Registered";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.ADD + LogEvents.POP + _tbPopName.Text);
                    ClearForm();
                }
                else
                {
                    _lblSuccess.Text = "Please enter all required fields first";
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

        protected void _btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            ClearForm();
        }
    }
}
