using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Apple_Bss.CodeFile
{
    public class BroadbandSubscriberLedgers
    {
        #region Listing of Existing Ledgers Details based on ID
        
        public static DataSet GetSubcriberLedgers(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select transactionid,userid,specifications,cast(cr as decimal(10,2)) cr,cast(dr as decimal(10,2)) dr,instrumentid,modon from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'  order by modon desc";           
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString,conn);
                
                dad.Fill(dst);

            }
            catch
            {
                throw;
            }

            return (dst);
        }
        #endregion
        /*
        #region Listing Functionality of Ledger Details by User ID

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

        #region Listing Total Credit

        public double GetTotalCredit(String pStrUserID)
        {
            SqlConnection conn = null;
            SqlDataReader dr = null;
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
            cmd.CommandText = "select cast(isnull(sum(cr),0)as decimal(10,2)) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

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

        #endregion

        #region Listing Total Debit

        public double GetTotalDebit(String pStrUserID)
        {
            SqlConnection conn = null;
            SqlDataReader dr = null;
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
            cmd.CommandText = "select cast(isnull(sum(dr),0)as decimal(10,2)) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

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

        #endregion

        */
        #region Listing Total Outstanding

        public double GetTotalOutstanding(String pStrUserID)
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
            cmd.CommandText = "select cast(isnull((sum(Cr)-sum(dr)),0)as decimal(10,2)) from subscriberledger  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

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

        #endregion

        #region Listing Functionality of all ledger amounts -16/03/2010 - hopeto

        public double[] GetLedgerAmounts(String pStrUserID)
        {
            double[] amounts = new double[3];
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            //to get credit
            SqlCommand cmd1 = conn.CreateCommand();
            //debit
            SqlCommand cmd2 = conn.CreateCommand();
            //outstanding amount
            SqlCommand cmd3 = conn.CreateCommand();
            string userid = Utilities.ValidSql(pStrUserID);
            cmd1.CommandText = "select cast(isnull(sum(cr),0)as decimal(10,2)) from subscriberledger where userid='" + userid + "'";
            cmd2.CommandText = "select cast(isnull(sum(dr),0)as decimal(10,2)) from subscriberledger where userid='" + userid + "'";
            cmd3.CommandText = "select cast(isnull((sum(Cr)-sum(dr)),0)as decimal(10,2)) from subscriberledger where userid='" + userid + "'";

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmd1.Transaction = tr;
                cmd2.Transaction = tr;
                cmd3.Transaction = tr;
                if (cmd1.ExecuteScalar() != DBNull.Value)
                {
                    amounts[0] = Convert.ToDouble(cmd1.ExecuteScalar());
                }
                if (cmd2.ExecuteScalar() != DBNull.Value)
                {
                    amounts[1] = Convert.ToDouble(cmd2.ExecuteScalar());
                }
                if (cmd3.ExecuteScalar() != DBNull.Value)
                {
                    amounts[2] = Convert.ToDouble(cmd3.ExecuteScalar());
                }
                tr.Commit();

            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (amounts);
        }

        #endregion

        #region Listing Total Debit without Extension Date

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
        
        #endregion

        #region Listing Total Outstanding Without Extension Date

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

        #endregion

        #region Funtionality to Delete Multiple Records from SUBSCRIBERLEDGER TABLE
       
        public void DeleteBroadBandSubscriberLedgers(StringCollection strCheckedCollection)
        {
            //Create sql Connection and Sql Command
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlCommand cmd = conn.CreateCommand();
                SqlCommand cmdReceipts = conn.CreateCommand();
                SqlTransaction tr = null;

                 string strChecks= "";
                 
                 foreach (string chk in strCheckedCollection)
                 {
                    strChecks += chk.ToString() + ",";
                 }
                 try
                    {
                        string checkedBoxSelected= strChecks.Substring(0,strChecks.LastIndexOf(","));
                      //  cmd.CommandText = "Delete from SUBSCRIBERLEDGER WHERE TRANSACTIONID in (" + checkedBoxSelected + ")";
                        cmd.CommandText = "Delete from SUBSCRIBERLEDGER WHERE instrumentid in (" + checkedBoxSelected + ")";
                        cmdReceipts.CommandText = "Delete from RECEIPTDETAILS WHERE receiptid in (" + checkedBoxSelected + ")";
                        conn.Open();
                        tr = conn.BeginTransaction();
                        cmd.Transaction = tr;
                        cmdReceipts.Transaction = tr;

                    
                        cmd.ExecuteNonQuery();
                        cmdReceipts.ExecuteNonQuery();
                        tr.Commit();
                    }
                 catch 
                    {
                        tr.Rollback();
                        throw;
                    }
                finally
                    {
                        conn.Close();
                    }
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
