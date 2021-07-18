using System;
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
    public class SystemEventLog
    {
        #region Write Log with userid

        public static void WriteEventLog(String pStrEmpID, String pStrEvent, String pStrUserID)
        {
            SqlConnection conn = null;  

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmdlog = conn.CreateCommand();           

            //insert into table
            cmdlog.CommandText = "insert SYSEVENTLOG (USERID,EVENT,SYSTEMUSERID,MODON) values (@USERID,@EVENT,@SYSTEMUSERID,@MODON)";            
            cmdlog.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmdlog.Parameters.AddWithValue("@EVENT", Utilities.ValidSql(pStrEvent));
            cmdlog.Parameters.AddWithValue("@SYSTEMUSERID", Utilities.ValidSql(pStrEmpID));
            cmdlog.Parameters.AddWithValue("@MODON", System.DateTime.Now);
                                

            try
            {
                conn.Open();                
                cmdlog.ExecuteNonQuery();
            }
            catch
            {                
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        #endregion

        #region Write Log without userid

        public static void WriteEventLog(String pStrEmpID, String pStrEvent)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmdlog = conn.CreateCommand();

            //insert into  table
            cmdlog.CommandText = "insert SYSEVENTLOG (EVENT,SYSTEMUSERID,MODON) values (@EVENT,@SYSTEMUSERID,@MODON)";            
            cmdlog.Parameters.AddWithValue("@EVENT", Utilities.ValidSql(pStrEvent));
            cmdlog.Parameters.AddWithValue("@SYSTEMUSERID", Utilities.ValidSql(pStrEmpID));
            cmdlog.Parameters.AddWithValue("@MODON", System.DateTime.Now);


            try
            {
                conn.Open();
                cmdlog.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        #endregion

        #region LIST logged events by employeed id -added 26/04/2010 -hoeto

        /// <summary>        
        /// Function to display logged in events for employees
        /// </summary>
        /// <param name="pStrEmpID">Logged in Employee id in the session</param>
        /// <returns>dataset containing the logged events</returns>
        public static DataSet ListLoggedEvents(String pStrEmpID)
        {
            DataSet dst = new DataSet();
          //  string strQueryString = "select EVENT, USERID, MODON from SYSEVENTLOG WHERE SYSTEMUSERID='" + Utilities.ValidSql(pStrEmpID) + "'and DATEPART(dy, modon) >DATEPART(dy, DATEADD(dy,-1,getdate())) order by MODON DESC";
            string strQueryString = "EXEC dbo.ListLoggedEvents '" + Utilities.ValidSql(pStrEmpID) + "'";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
            try
            {
                conn.Open();
                dad.Fill(dst);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dst);
        }
        #endregion
    



    }
}
