using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class SubscriberLedgers
    {

        #region Listing Functionality

        public DataSet GetLedgerDetails(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select userid,specifications,cr,dr,instrumentid,modon from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "' order by modon asc";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch
            {
                throw;
            }

            return (dst);
        }

        #endregion

        public double GetTotalCredit(String pStrUserID)
        {
            SqlConnection conn = null;
           // SqlDataReader dr = null;
            double dTotalCr = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select isnull(sum(cr),0) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            try
            {
                conn.Open();
                dTotalCr = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dTotalCr);
        }

        public double GetTotalDebit(String pStrUserID)
        {
            SqlConnection conn = null;
            //SqlDataReader dr = null;
            double dTotalDr = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select isnull(sum(dr),0) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            try
            {
                conn.Open();
                dTotalDr = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dTotalDr);
        }

        public double GetTotalOutstanding(String pStrUserID)
        {
            SqlConnection conn = null;
           // SqlDataReader dr = null;
            double dTotalDr = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select isnull((sum(Cr)-sum(dr)),0) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    dTotalDr = Convert.ToDouble(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dTotalDr);
        }

        public double GetTotalDebitWithoutEXDT(String pStrUserID)
        {
            SqlConnection conn = null;
           // SqlDataReader dr = null;
            double dTotalDr = 0;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select ISNULL(sum(dr),0) from subscriberledger where userid='" + Utilities.ValidSql(pStrUserID) + "' and exdtpayment='F'";

            try
            {
                conn.Open();
                dTotalDr = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dTotalDr);
        }

        public double GetTotalOutstandingWithoutEXDT(String pStrUserID, Int32 intCurrCycleID, String pStrPayMode)
        {

            SqlConnection conn = null;
           // SqlDataReader dr = null;
            double dTotal = 0;

            String strStartDate = "";
            String strEndDate = "";
            Int32 intPrevCycleID = 0;

            if (pStrPayMode == "M")
            {
                intPrevCycleID = intCurrCycleID - 1;
                strStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(intPrevCycleID)).ToString("MM-dd-yyyy");
                strEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(intPrevCycleID)).ToString("MM-dd-yyyy");
            }
            else if (pStrPayMode == "Q")
            {
                intPrevCycleID = intCurrCycleID - 3;
                strStartDate = Convert.ToDateTime(BillCycles.GetCycleStartDateOfQuarterlyCycle(intPrevCycleID)).ToString("MM-dd-yyyy");
                strEndDate = Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(intPrevCycleID)).ToString("MM-dd-yyyy");
            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select (select isnull((sum(Cr)-sum(dr)),0) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "')+(select isnull(sum(dr),0) from subscriberledger where userid='" + Utilities.ValidSql(pStrUserID) + "' and exdtpayment='T' and modon between '" + Utilities.ValidSql(strStartDate) + "' and '" + Utilities.ValidSql(strEndDate) + "')";

            try
            {
                conn.Open();
                dTotal = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dTotal);
        }



        #region Get RECIEPT DETAILS BASED ON INSTRUMENT ID
        public static DataSet GetInstrumentDetails(String pStrInstrID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid,a.specifications,b.receiptnumber,b.receiptid,cast(b.amount as decimal(10,2)) amount from subscriberledger a,receiptdetails b  where a.userid=b.userid and a.instrumentid=b.receiptid and a.instrumentid='" + Utilities.ValidSql(pStrInstrID) + "'";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion

        /*public double GetTotalOutstandingWithoutEXDT(String pStrUserID)
        {

            double dTotal = 0;
            try
            {
                dTotal = GetTotalCredit(pStrUserID) - GetTotalDebitWithoutEXDT(pStrUserID);
            }
            catch
            {
                throw;
            }

            return (dTotal);
        }*/
    }
}
