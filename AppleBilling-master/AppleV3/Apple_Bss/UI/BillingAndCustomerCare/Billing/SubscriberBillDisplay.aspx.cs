using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Threading;


namespace Apple_Bss.UI.BillingAndCustomerCare.Billing
{
    public partial class SubscriberBillDisplay : System.Web.UI.Page
    {

        private string reportpath = String.Empty;
        private string instNo=String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            instNo = Request["bnum"].ToString();
            if (instNo.Substring(0, 4) == "301-")
            {
                ShowSubscriberBill(Request["bnum"].ToString());
                _dvReceiptDetails.Visible = false;
            }
            else if (instNo.Substring(0,4) == "RCX-")
            {
                ShowRecieptDetails(Request["bnum"].ToString());
                CrystalReportViewer1.Visible = false;
            }
            
                
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //if (crReportDocument != null)
            //{
            //    crReportDocument.Close();
            //    crReportDocument.Dispose();
            //}
        }

        private void ShowRecieptDetails(string instNumber)
        {
            try
            {
                _dvReceiptDetails.DataSource = SubscriberLedgers.GetInstrumentDetails(instNumber);
                _dvReceiptDetails.DataBind();
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
            }
        }
        
        private void ShowSubscriberBill(String pStrBillNumber)
        {
            try
            {
                
                DataTable userBillDetails = new DataTable();
                userBillDetails = BroadbandUser.GetBillDetails(pStrBillNumber).Tables[0];

                DateTime billdate = Convert.ToDateTime(userBillDetails.Rows[0]["BILLSTARTDATE"]);
                string reportpath;
                //get date when gst was implemented
                DateTime GSTDateTime = Convert.ToDateTime("2017-07-01");


             // if (BillDetails.IsFirstBill(instNo)) instead of getting from db here, its already fetched so use that value
             if(userBillDetails.Rows[0]["FIRSTBILL"].ToString() =="T")
                {   
                   // reportpath = DBConn.GetReportsPath()  + "FIRSTBILL.rpt";
                       if (billdate >= GSTDateTime)
                       {
                    reportpath = DBConn.GetReportsPath() + "FIRSTBILL-GST.rpt";
                    //for local testing
                   // reportpath = Server.MapPath(DBConn.GetReportsPath() + "FIRSTBILL-GST.rpt");
                       }
                       else //else it is old bill
                       {
                    reportpath = DBConn.GetReportsPath() + "FIRSTBILL.rpt";
                    //for local testing
                   // reportpath = Server.MapPath(DBConn.GetReportsPath() + "FIRSTBILL.rpt");
                       }               
                }               
                else //it is not first bill
                {
                    if (billdate >= GSTDateTime)
                    {
               reportpath = DBConn.GetReportsPath() + "NOTFIRSTBILL-GST.rpt";
                    //for local testing
                 //   reportpath = Server.MapPath(DBConn.GetReportsPath() + "NOTFIRSTBILL-GST.rpt");
                    }
                    else //else it is old bill
                    {
                     reportpath = DBConn.GetReportsPath() + "NOTFIRSTBILL.rpt";
                    //for local testing
                //  reportpath = Server.MapPath(DBConn.GetReportsPath() + "NOTFIRSTBILL.rpt");
                }
                  
                }

             ReportDocument crReportDocument = new ReportDocument();
             Database crDatabase;
             Tables crTables;
             // CrystalDecisions.CrystalReports.Engine.Table crTable;
             // TableLogOnInfo crTableLogOnInfo;
             ConnectionInfo crConnectionInfo = new ConnectionInfo();
                
            //  crReportDocument.Load(Server.MapPath(reportpath));            
                //no need to map path anymore
                crReportDocument.Load(reportpath);
                crConnectionInfo.ServerName = DBConn.GetServerAddress();
                crConnectionInfo.DatabaseName = DBConn.GetDatabaseName();
                crConnectionInfo.UserID = DBConn.GetUserName();
                crConnectionInfo.Password = DBConn.GetPassword();

                //crReportDocument.SetDatabaseLogon(DBConn.GetUserName(), DBConn.GetPassword(), DBConn.GetServerAddress(), DBConn.GetDatabaseName(),true);
                // This code works for both user tables and stored 
                //procedures 

                //Get the table information from the report 
                crDatabase = crReportDocument.Database;
                crTables = crDatabase.Tables;

                //Loop through all tables in the report and apply the 
                //connection information for each table. 

                /*for (int i = 0; i < crTables.Count; i++)
                {
                    crTable = crTables[i];
                    crTableLogOnInfo = crTable.LogOnInfo;
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                    crTable.ApplyLogOnInfo(crTableLogOnInfo);

                    //If your DatabaseName is changing at runtime, specify 
                    //the table location. For example, when you are reporting 
                    //off of a Northwind database on SQL server 
                    //you should have the following line of code: 

                    crTable.Location = "INETBILLNEWDB.dbo." + crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
                }*/

                ParameterDiscreteValue param = new ParameterDiscreteValue();
                ParameterValues values = new ParameterValues();
                ReportDocument rep = new ReportDocument();
               // rep.Load(Server.MapPath(reportpath));
               //same here
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

                crReportDocument.Close();
                crReportDocument.Dispose();
            }
            catch (ThreadAbortException)
            {

            }
            catch (FileNotFoundException fnf)
            {
                Session["ErrorMsg"] = fnf.ToString();
                Response.Redirect("~/Error.aspx", false);
            
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.ToString();
                Response.Redirect("~/Error.aspx", false);
                //Response.Write(strRep);
            }

        }
    }
}
