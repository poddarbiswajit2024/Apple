using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Apple_Bss.CodeFile;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class PopMaintenance
    {
        #region Register DAILY POP MAINTENANCE  Functionality

        public void RegisterDailyPopMaintenanceReport(String pStrPopID,String pStrMeterCharge,String pStrBatStatus,String pStrInverterStatus,String pStrReplacement,String pStrDom,String pStrRemarks,String pStrModby)
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

            cmd.CommandText = "insert POPMAINTENANCE(POPID,MANUALMETERCHARGE,BATTERYSTATUS,INVERTERCHARGINGSTATUS,REPLACEMENT,DATEOFMAINTENANCE,REMARKS,MODBY,MODON)values(@POPID,@MANUALMETERCHARGE,@BATTERYSTATUS,@INVERTERCHARGINGSTATUS,@REPLACEMENT,@DATEOFMAINTENANCE,@REMARKS,@MODBY,@MODON)";

            cmd.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopID));
            cmd.Parameters.AddWithValue("@MANUALMETERCHARGE", Utilities.ValidSql(pStrMeterCharge));
            cmd.Parameters.AddWithValue("@BATTERYSTATUS", Utilities.ValidSql(pStrBatStatus));
            cmd.Parameters.AddWithValue("@INVERTERCHARGINGSTATUS", Utilities.ValidSql(pStrInverterStatus));
            cmd.Parameters.AddWithValue("@REPLACEMENT", Utilities.ValidSql(pStrReplacement));
            cmd.Parameters.AddWithValue("@DATEOFMAINTENANCE", Utilities.ValidSql(pStrDom));
            cmd.Parameters.AddWithValue("@REMARKS",Utilities.ValidSql(pStrRemarks));
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

        #region Listing DAILY POP MAINTENANCE
       
        public static DataSet GetPopMaintenanceReport()
        {

            DataSet dst = new DataSet();
            string strQueryString = "select b.popname,a.MANUALMETERCHARGE,a.BATTERYSTATUS,a.INVERTERCHARGINGSTATUS,a.REPLACEMENT,a.DATEOFMAINTENANCE ,a.REMARKS from POPMAINTENANCE a, POPMASTER b where a.popid=b.popid order by a.ModOn desc";
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

        public static DataSet GetPopMaintenanceReportByDateRange(String pStrStartDate,String pStrEndDate)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select b.popname,a.MANUALMETERCHARGE,a.BATTERYSTATUS,a.INVERTERCHARGINGSTATUS,a.DATEOFMAINTENANCE,a.REPLACEMENT,a.REMARKS from POPMAINTENANCE a,POPMASTER b where a.DATEOFMAINTENANCE >='"+pStrStartDate+"' and a.DATEOFMAINTENANCE<='"+pStrEndDate+"' and a.popid=b.popid order by a.ModOn desc";
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
