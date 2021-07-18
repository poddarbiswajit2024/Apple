using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Apple_Bss.CodeFile
{
    public class BillDetails
    {
        #region Checking for First Bill

        public static bool IsFirstBill(string pStrBillNumber)
        {
            bool FIRSTBILL = true;
            string status = "";

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "SELECT FIRSTBILL from BILLDETAILS where BILLNUMBER='" + Utilities.ValidSql(pStrBillNumber) + "'";

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                status = cmdcheck.ExecuteScalar().ToString();
            }

            if (status == "F")
            {
                FIRSTBILL = false;
            }
            else
            {
                FIRSTBILL = true;
            }

            return (FIRSTBILL);
        }

        #endregion

        #region Listing of Bill Collection Summary
        public static DataSet getBillCollectionSummary(Int32 pStrBillCycleId,String pStrBillCycleStartDate,String pStrBillCycleEndDate)
        {
            DataSet dst = new DataSet();

            String strQueryString = "select a.userid,a.username,a.billnumber,cast(a.servicetax as decimal(10,2)) servicetax,cast(a.totaloutstanding as decimal(10,2)) billedamount, cast(isnull(b.amount,0) as decimal(10,2)) payment ";
            strQueryString += " from (select userid ,billnumber,username,servicetax,totaloutstanding from billdetails where billcycleid=" + pStrBillCycleId + ") a ";
            strQueryString += " left outer join receiptdetails b on a.userid=b.userid and b.paymentdate >='" + Utilities.ValidSql(pStrBillCycleStartDate) + "' and  b.paymentdate<='" + Utilities.ValidSql(pStrBillCycleEndDate) + "' order by a.userid";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);

        }

        #endregion
    }
}
