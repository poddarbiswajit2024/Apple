using System;
using System.Text;
using System.Data;
using System.Data.SqlClient; 
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace Apple_Bss.CodeFile
{
    public class BillCycles
    {
        #region Find Monthly Bill Cycle ID by Date -- Checked OK

        public static Int32 GetMonthlyBillCycleID(String pStrDate)
        {
            SqlConnection conn = null;
            Int32 intCycleID = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select billcycleid from BILLCYCLES where '" + Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy") + "' between cyclestartdate and cycleenddate";

            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    intCycleID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (intCycleID);
        }

        #endregion

        #region Find Quarterly Bill Cycle ID by Date

        public static Int32 GetQuarterlyBillCycleID(String pStrDate)
        {
            SqlConnection conn = null;
            Int32 intCycleID = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(billcycleid) quarterlybillcycleid from billcycles where billcycleid<=(select billcycleid from BILLCYCLES where '" + Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy") + "' between cyclestartdate and cycleenddate) and isquarterly='Y'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    intCycleID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (intCycleID);
        }

        #endregion

        #region Find HalfYearly Bill Cycle ID by Date

        public static Int32 GetHalfYearlyBillCycleID(String pStrDate)
        {
            SqlConnection conn = null;
            Int32 intCycleID = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(billcycleid) billcycleid from billcycles where billcycleid<=(select billcycleid from BILLCYCLES where '" + Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy") + "' between cyclestartdate and cycleenddate) and ishalfyearly='Y'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    intCycleID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (intCycleID);
        }

        #endregion

        #region Find Yearly Bill Cycle ID by Date

        public static Int32 GetYearlyBillCycleID(String pStrDate)
        {
            SqlConnection conn = null;
            Int32 intCycleID = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(billcycleid) billcycleid from billcycles where billcycleid<=(select billcycleid from BILLCYCLES where '" + Convert.ToDateTime(pStrDate).ToString("MM-dd-yyyy") + "' between cyclestartdate and cycleenddate) and isyearly='Y'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    intCycleID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (intCycleID);
        }

        #endregion

        #region Get BILLcycle Name by BillCycle ID
        public static string GetBillCycleName(String billcycleID)
        {
            SqlConnection conn = null;
            string pStrCycleName = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select BILLCYCLENAME from BILLCYCLES where billcycleid='"+ billcycleID +"'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrCycleName = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrCycleName);
        }
        #endregion

        public static string GetCycleEndDateOfMonthlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLEENDDATE from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleStartDateOfMonthlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLESTARTDATE from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleEndDateOfQuarterlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLEENDDATE from BILLCYCLES where billcycleid=" + (pIntCycleID + 2);
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleStartDateOfQuarterlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLESTARTDATE from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleStartDateOfHalfYearlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLESTARTDATE from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleEndDateOfHalfYearlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLEENDDATE from BILLCYCLES where billcycleid=" + (pIntCycleID + 5);
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleStartDateOfYearlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLESTARTDATE from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetCycleEndDateOfYearlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select CYCLEENDDATE from BILLCYCLES where billcycleid=" + (pIntCycleID + 11);
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetLastDateOfPaymentOfQuarterlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select LASTDATEOFPAYMENT from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetLastDateOfPaymentOfMonthlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStrDate = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select LASTDATEOFPAYMENT from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStrDate = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStrDate);
        }

        public static string GetDNPstatusOfQuarterlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStatus = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select DNPSTATUS from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStatus = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStatus);
        }

        public static string GetDNPstatusOfMonthlyCycle(Int32 pIntCycleID)
        {
            SqlConnection conn = null;
            string pStatus = "";

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select DNPSTATUS from BILLCYCLES where billcycleid=" + pIntCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    pStatus = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (pStatus);
        }
        
        #region Bill Cycle Listing Not greater than current date 
      
        public  DataSet GetBillCycleForListing(BillCycleType type, String pStrCurrDate)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLCYCLEID,BILLCYCLENAME from ";

            switch (type)
            {
                case BillCycleType.ALL:
                    strQueryString += " BILLCYCLES where CYCLESTARTDATE <='" + Utilities.ValidSql(pStrCurrDate) + "' order by billcycleid desc";
                    break;
                case BillCycleType.MONTHLY:
                    strQueryString += " BILLCYCLES where CYCLESTARTDATE <='" + Utilities.ValidSql(pStrCurrDate) + "' order by billcycleid desc";
                    break;
                case BillCycleType.QUARTERLY:
                    strQueryString += " BILLCYCLES where ISQUARTERLY='Y' and CYCLESTARTDATE <='" + Utilities.ValidSql(pStrCurrDate) + "' order by billcycleid desc";
                    break;
                case BillCycleType.HALFYEARLY:
                    strQueryString += " BILLCYCLES where ISHALFYEARLY='Y' and CYCLESTARTDATE <='" + Utilities.ValidSql(pStrCurrDate) + "' order by billcycleid desc";
                    break;
                case BillCycleType.ANNUALY:
                    strQueryString += " BILLCYCLES where ISYEARLY='Y' and  CYCLESTARTDATE <='" + Utilities.ValidSql(pStrCurrDate) + "' order by billcycleid desc";
                    break;

                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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


        #region Bill Cycle Listing

        public DataSet GetBillCycleList(BillCycleType type)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLCYCLEID,BILLCYCLENAME,CYCLESTARTDATE,CYCLEENDDATE,LASTDATEOFPAYMENT,BILLEDSTATUS,LATEFINEFIRED,REACTIVATIONCHARGESFIRED from ";

            switch (type)
            {
                case BillCycleType.ALL:
                    strQueryString += " BILLCYCLES order by billcycleid";
                    break;
                case BillCycleType.MONTHLY:
                    strQueryString += " BILLCYCLES order by billcycleid";
                    break;
                case BillCycleType.QUARTERLY:
                    strQueryString += " BILLCYCLES where ISQUARTERLY='Y' order by billcycleid";
                    break;

                case BillCycleType.HALFYEARLY:
                    strQueryString += " BILLCYCLES where ISHALFYEARLY='Y' order by billcycleid";
                    break;

                case BillCycleType.ANNUALY:
                    strQueryString += " BILLCYCLES where ISYEARLY='Y' order by billcycleid";
                    break;

                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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

        #region Bill Cycle Listing by Bill Cycle Type and Date

        public static DataSet GetBillCycleName(BillCycleType type, String pStrCycleEndDate)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLCYCLEID,BILLCYCLENAME from ";

            switch (type)
            {
               
                case BillCycleType.MONTHLY:
                    //strQueryString += " BILLCYCLES where CYCLESTARTDATE >'" + Utilities.ValidSql(pStrCycleEndDate) + "' order by billcycleid";
                    strQueryString += " BILLCYCLES where CYCLESTARTDATE >='" + Utilities.ValidSql(pStrCycleEndDate) + "' order by billcycleid";
                    break;
                case BillCycleType.QUARTERLY:
                    strQueryString += " BILLCYCLES where ISQUARTERLY='Y' and  CYCLESTARTDATE >='" + Utilities.ValidSql(pStrCycleEndDate) + "' order by billcycleid";
                    break;

                case BillCycleType.HALFYEARLY:
                    strQueryString += " BILLCYCLES where ISHALFYEARLY='Y'and CYCLESTARTDATE >='" + Utilities.ValidSql(pStrCycleEndDate) + "' order by billcycleid";
                    break;

                case BillCycleType.ANNUALY:
                    strQueryString += " BILLCYCLES where ISYEARLY='Y' and CYCLESTARTDATE >='" + Utilities.ValidSql(pStrCycleEndDate) + "' order by billcycleid";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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



        
        
        public static Int32 GetMaxMonthlyCycleID()
        {
            SqlConnection conn = null;
            Int32 max = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(billcycleid) from BILLCYCLES";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    max = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (max);
        }

        public static Int32 GetMaxQuarterlyCycleID()
        {
            SqlConnection conn = null;
            Int32 max = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select max(billcycleid) from BILLCYCLES where ISQUARTERLY='Y'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    max = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (max);
        }

        public static bool IsQuarterlyBillCycle(Int32 pInt32BillCycleID)
        {
            SqlConnection conn = null;
            string isquarterly = "";
            bool QUARTERLY = false;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select ISQUARTERLY from BILLCYCLES where BILLCYCLEID=" + pInt32BillCycleID;
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    isquarterly = cmd.ExecuteScalar().ToString();
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            if (isquarterly == "Y")
            {
                QUARTERLY = true;
            }

            return (QUARTERLY);
        }

        
        #region Unbilled Bill Cycle Listing

        public static DataSet GetUnbilledBillCycleList(BillCycleType type)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLCYCLEID,BILLCYCLENAME,CYCLESTARTDATE,CYCLEENDDATE,LASTDATEOFPAYMENT,BILLEDSTATUS,LATEFINEFIRED,REACTIVATIONCHARGESFIRED from ";

            switch (type)
            {
                case BillCycleType.ALL:
                    strQueryString += " BILLCYCLES where BILLEDSTATUS='N' order by billcycleid";
                    break;
                case BillCycleType.MONTHLY:
                    strQueryString += " BILLCYCLES where BILLEDSTATUS='N' order by billcycleid";
                    break;
                case BillCycleType.QUARTERLY:
                    strQueryString += " BILLCYCLES where BILLEDSTATUS='N' and ISQUARTERLY='Y' order by billcycleid";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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
       
    }
}
