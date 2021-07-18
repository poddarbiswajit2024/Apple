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
    public class SessionDetails
    {
        #region Listing Session Data Transfer Details 

        public static DataSet GetSessionDetailsByPaymentMode(Int32 pInt32CycleID, String pStrPaymentMode, String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select ClientIP, SnatIP,starttime,stoptime,usedtime,cast(uploadbytes/(1024*1024) as decimal(10,2)) uploadBytes, cast(downloadBytes/(1024*1024) as decimal(10,2)) downloadbytes, cast(totalBytes/(1024*1024)as decimal(10,2)) totalBytes from  SESSIONDETAILS  where BILLCYCLEID=" + pInt32CycleID + " and BILLCYCLETYPE='" + Utilities.ValidSql(pStrPaymentMode) + "' and userid='" + Utilities.ValidSql(pStrUserID) + "' order by stoptime desc";
            //(select sum(uploadBytes/(1024*1024)totUploadBytes,sum(downloadBytes/(1024*1024)totDownloadBytes,sum(totalbytes/(1024*1024) totDatatransferBytes from  a where a.BillcycleId="+pInt32CycleID+" and a.billcycletype='"+Utilities.ValidSql(pStrPaymentMode)+"' group by a.userID='"+Utilities.ValidSql(pStrUserID)+")' )a join
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

        #region To get DataTransfer Details Total based on UserID, paymentMode and BillCycle ID
        public static string[] GetSumOfDataTransfer(Int32 pInt32CycleID, String pStrPaymentMode, String pStrUserID)
        {
            string[] sumDataTransfer = new string[3];
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
            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();

            cmd1.CommandText = "select cast(sum(uploadBytes/(1024*1024))as decimal(10,2))  from SESSIONDETAILS  where BILLCYCLEID=" + pInt32CycleID + " and BILLCYCLETYPE ='" + Utilities.ValidSql(pStrPaymentMode) + "' and UserID ='" + Utilities.ValidSql(pStrUserID) + "' group by USERID";
            cmd2.CommandText = "select cast(sum(downloadBytes/(1024*1024))as decimal(10,2))from SESSIONDETAILS  where BILLCYCLEID=" + pInt32CycleID + " and BILLCYCLETYPE ='" + Utilities.ValidSql(pStrPaymentMode) + "' and UserID ='" + Utilities.ValidSql(pStrUserID) + "' group by USERID";
            cmd3.CommandText = "select cast(sum(totalbytes/(1024*1024))as decimal(10,2))   from SESSIONDETAILS  where BILLCYCLEID=" + pInt32CycleID + " and BILLCYCLETYPE ='" + Utilities.ValidSql(pStrPaymentMode) + "' and UserID ='" + Utilities.ValidSql(pStrUserID) + "' group by USERID";
            conn.Open();
          
                sumDataTransfer[0] = cmd1.ExecuteScalar().ToString();
                sumDataTransfer[1] = cmd2.ExecuteScalar().ToString();
                sumDataTransfer[2] = cmd3.ExecuteScalar().ToString();
                try
                {
                    tr = conn.BeginTransaction();
                    cmd1.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd3.Transaction = tr;
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
           
            return (sumDataTransfer);
        }
        #endregion



        #region Listing of Uploaded Data Transfer details by Month Start Date and Month End Date

        public static DataSet GetSessionUploadDetailsByMonth( String pstrMonthStartDate, String pStrMonthEndDate)
        {
            DataSet dst = new DataSet();
            //string strQueryString = "select convert(varchar,a.datename,107) UploadDate, isnull(count(b.rownum),0) NoOfsession";
            //strQueryString += " from (select datename from getdates('" + pstrMonthStartDate + "','" + pStrMonthEndDate+"')) a left outer join sessiondetails b";
            //strQueryString += " on  convert(varchar,b.starttime,107)=convert(varchar,a.datename,107) group by convert(varchar,a.datename,107)";
            //strQueryString += " order by convert(varchar,a.datename,107) asc";

           string strQueryString= "EXEC GetSessionDetails '" + pstrMonthStartDate + "','" + pStrMonthEndDate+"'";
         
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
