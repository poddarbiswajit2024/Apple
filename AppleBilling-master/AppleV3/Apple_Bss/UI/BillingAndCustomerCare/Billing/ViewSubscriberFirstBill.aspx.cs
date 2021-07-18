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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Apple_Bss.CodeFile;
using System.IO;
using System.Threading;

namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class ViewSubscriberFirstBill : System.Web.UI.Page
    {
        private ReportDocument rep = new ReportDocument();
        private String billnumber = String.Empty;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                billnumber = Request["bn"].ToString();
                ShowSubscriberBill(billnumber);
            }

        }

        private void ShowSubscriberBill(String pStrBillNumber)
        {
            try
            {

                ReportDocument crReportDocument = new ReportDocument();
                Database crDatabase;
                Tables crTables;
                //CrystalDecisions.CrystalReports.Engine.Table crTable;
                //TableLogOnInfo crTableLogOnInfo;
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                //if billdate is before july use old format
                // if bill date is after july use gst format
                DataTable userBillDetails = new DataTable();
                userBillDetails = BroadbandUser.GetBillDetails(pStrBillNumber).Tables[0];
                //    if(userBillDetails.data)

                DateTime billdate = Convert.ToDateTime( userBillDetails.Rows[0]["BILLSTARTDATE"]);

                string reportpath;
                //get date when gst was implemented
                DateTime GSTDateTime = Convert.ToDateTime("2017-07-01");

                if (billdate >= GSTDateTime)
                {
                    reportpath = DBConn.GetReportsPath() + "FIRSTBILL-GST.rpt";
                    //for local testing
                   // reportpath =Server.MapPath(DBConn.GetReportsPath() + "FIRSTBILL-GST.rpt");
                }
                else //else it is old bill
                {
                reportpath = DBConn.GetReportsPath() + "FIRSTBILL.rpt";

                  //for local testing
                 // reportpath = Server.MapPath(DBConn.GetReportsPath() + "FIRSTBILL-GST.rpt");
                }


                    
                   crReportDocument.Load(reportpath);


                crConnectionInfo.ServerName = DBConn.GetServerAddress();
                crConnectionInfo.DatabaseName = DBConn.GetDatabaseName();
                crConnectionInfo.UserID = DBConn.GetUserName();
                crConnectionInfo.Password = DBConn.GetPassword();
                //Get the table information from the report 
                crDatabase = crReportDocument.Database;
                crTables = crDatabase.Tables;
           

                ParameterDiscreteValue param = new ParameterDiscreteValue();
                ParameterValues values = new ParameterValues();
              rep.Load(reportpath);
             
                param = new ParameterDiscreteValue();
                param.Value = pStrBillNumber;
                values.Add(param);

                rep.DataDefinition.ParameterFields[0].ApplyCurrentValues(values);
                rep.SetDataSource(userBillDetails);

                CrystalReportViewer1.ReportSource = rep;
                CrystalReportViewer1.DataBind();


                MemoryStream oStream; // using System.IO
                oStream = (MemoryStream)
                rep.ExportToStream(
                CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(oStream.ToArray());
                Response.End();


            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);

            }

        }





    }
}
