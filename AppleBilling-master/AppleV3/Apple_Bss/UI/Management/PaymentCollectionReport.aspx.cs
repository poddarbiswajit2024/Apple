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
using System.Globalization;

namespace Apple_Bss.UI.Management
{
    public partial class PaymentCollectionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
                _gvAmtByMonth.Visible = false;
                _gvAmtByDateRange.Visible = false;
                
            }
        }
             
        private void PaymentAmountDisplay()
        {
           
            CultureInfo ci = new CultureInfo("en-GB");

            try
            {
                if (_rbtnPaymentColln.SelectedValue == "DTR")
                {
                    string _startdate = Convert.ToDateTime(_txtStartDate.Text, ci).ToShortDateString();
                    string _enddate = Convert.ToDateTime(_txtEndDate.Text, ci).ToShortDateString();
                    _panelDateRange.Enabled = true;
                    _panelDateRange.Visible = true;
                    _gvAmtByMonth.Visible = false;
                    _gvAmtByDateRange.Visible = true;
                    _gvAmtByDateRange.DataSource = CustomerPayments.GetPaymentCollByDateRange(_startdate, _enddate).Tables[0];
                    _gvAmtByDateRange.DataBind();
                    _lblMsg.Text = "<b>Amount Collected <br/>From &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _txtStartDate.Text + "</font><br/> To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<font color='red'>" + _txtEndDate.Text + "</font></b>";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWPAYMENTR + _rbtnPaymentColln.SelectedItem + " from " + _startdate + " to " + _enddate);

                }
                else if (_rbtnPaymentColln.SelectedValue == "MTH")
                {
                    _panelDateRange.Enabled = false;
                    _panelDateRange.Visible = false;
                    _gvAmtByMonth.Visible = true;
                    _gvAmtByDateRange.Visible = false;
                    _gvAmtByMonth.DataSource = CustomerPayments.GetPaymentCollByMonth().Tables[0];
                    _gvAmtByMonth.DataBind();
                    _lblMsg.Text = "<b>Month Wise Amount Collection";
                    SystemEventLog.WriteEventLog(Session["EmpID"].ToString(), LogEvents.VIEWPAYMENTR + _rbtnPaymentColln.SelectedItem); 
                }
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }


        protected void _imgBtnView_Click(object sender, ImageClickEventArgs e)
        {
            PaymentAmountDisplay();
        }

        protected void _rbtnPaymentColln_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_rbtnPaymentColln.SelectedValue == "DTR")
            {
                _panelDateRange.Enabled = true;
                _panelDateRange.Visible = true;
            }
            else
            {
                _panelDateRange.Enabled = false;
                _panelDateRange.Visible = false;
            }
        }

        protected void _gvAmtByMonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvAmtByMonth.PageIndex = e.NewPageIndex;
            PaymentAmountDisplay();
        }
    }
}
