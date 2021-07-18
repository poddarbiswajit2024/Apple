using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class FiberMaintenance
    {
        #region Register DAILY POP MAINTENANCE  Functionality

        public void RegisterFiberMaintenanceReport(String pStrTeamMembers, String pStrStartLocation, String pStrEndLocation,String pStrDom, String pStrWorkStatus, String pStrModby)
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

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "insert FIBERMAINTENANCE(TEAMMEMBERS,STARTLOCATION,ENDLOCATION,DATEOFMAINTENANCE,STATUS,MODBY,MODON)values(@TEAMMEMBERS,@STARTLOCATION,@ENDLOCATION,@DATEOFMAINTENANCE,@STATUS,@MODBY,@MODON)";

            cmd.Parameters.AddWithValue("@TEAMMEMBERS", Utilities.ValidSql(pStrTeamMembers));
            cmd.Parameters.AddWithValue("@STARTLOCATION", Utilities.ValidSql(pStrStartLocation));
            cmd.Parameters.AddWithValue("@ENDLOCATION", Utilities.ValidSql(pStrEndLocation));
            cmd.Parameters.AddWithValue("@DATEOFMAINTENANCE", Utilities.ValidSql(pStrDom));
            cmd.Parameters.AddWithValue("@STATUS", Utilities.ValidSql(pStrWorkStatus));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmd.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        #region Listing of FIBER MAINTENANCE REPORT


        public static DataSet GetFiberMaintenanceReport()
        {

            DataSet dst = new DataSet();
            string strQueryString = "select TEAMMEMBERS,STARTLOCATION,ENDLOCATION,DATEOFMAINTENANCE,STATUS from FIBERMAINTENANCE order by ModOn desc";
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

        #region Listing of POP Maintenance By Date Range

        public static DataSet GetFiberMaintenanceReportByDateRange(String pStrStartDate, String pStrEndDate)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select TEAMMEMBERS,STARTLOCATION,ENDLOCATION,DATEOFMAINTENANCE,STATUS from FIBERMAINTENANCE where DATEOFMAINTENANCE >='" + pStrStartDate + "' and DATEOFMAINTENANCE<='" + pStrEndDate + "' order by ModOn desc";
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
