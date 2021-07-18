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
    public class ArrearsAndWaivers
    {

        #region Add Waivers to WAD Table
        public void AddWaivers(String pStrUserID, String pStrBillCycleID, String pStrWaiverAmount, String pStrRemarks, String pStrModBy)
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

            //insert into WAD (Waivers And Arrears) table

            cmd.CommandText = "Insert WAD(USERID,WAIVER,ARREAR,DNB,CYCLEID,REMARKS,MODON,MODBY)Values(@USERID,@WAIVERAMOUNT,@ARREAR,@DNB,@CYCLEID,@REMARKS,@MODON,@MODBY)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@CYCLEID", Utilities.ValidSql(pStrBillCycleID));
            cmd.Parameters.AddWithValue("@WAIVERAMOUNT", Convert.ToDouble(pStrWaiverAmount));
            cmd.Parameters.AddWithValue("@ARREAR", 0);
            cmd.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmd.Parameters.AddWithValue("@DNB", "F");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
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

        #region Add Arrears to WAD Table
        public void AddArrears(String pStrUserID, String pStrBillCycleID, String pStrArrearAmount, String pStrRemarks, String pStrModBy)
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

            //insert into WAD (Waivers And Arrears) table

            cmd.CommandText = "Insert WAD(USERID,WAIVER,ARREAR,DNB,CYCLEID,REMARKS,MODON,MODBY)Values(@USERID,@WAIVERAMOUNT,@ARREAR,@DNB,@CYCLEID,@REMARKS,@MODON,@MODBY)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@CYCLEID", Utilities.ValidSql(pStrBillCycleID));
            cmd.Parameters.AddWithValue("@WAIVERAMOUNT", 0);
            cmd.Parameters.AddWithValue("@ARREAR", Convert.ToDouble(pStrArrearAmount));
            cmd.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmd.Parameters.AddWithValue("@DNB", "F");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
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

        #region Connection Shifting Charge Functionality

        public void ShiftingArrearCharge(String pStrUserID, String pStrArrearAmount, Int32 billCycleId, String pStrModBy)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert WAD(USERID,WAIVER,ARREAR,DNB,CYCLEID,REMARKS,MODON,MODBY)Values(@USERID,@WAIVERAMOUNT,@ARREAR,@DNB,@CYCLEID,@REMARKS,@MODON,@MODBY)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@CYCLEID", billCycleId);
            cmd.Parameters.AddWithValue("@WAIVERAMOUNT", 0);
            cmd.Parameters.AddWithValue("@ARREAR", Convert.ToDouble(pStrArrearAmount));
            cmd.Parameters.AddWithValue("@REMARKS", "Connection Shifting Charge");
            cmd.Parameters.AddWithValue("@DNB", "F");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
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

        #region Add Arrears and Waivers to Reactivate Temporary Disconnection

        public void AddArrearsAndWaivers(String pStrUserID, Int32 billCycleID, String pStrWaiverAmount, String pStrArrearAmount, String pStrRemarks, String pStrModBy, UpdateStatus status, String preactivationdate)
        {
            SqlConnection conn;
            SqlTransaction tr = null;

            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmduserStatusLog = conn.CreateCommand();
            SqlCommand cmduserMaster = conn.CreateCommand();

            //insert into WAD (Waivers And Arrears) table

            cmd.CommandText = "Insert WAD(USERID,WAIVER,ARREAR,DNB,CYCLEID,REMARKS,MODON,MODBY)Values(@USERID,@WAIVERAMOUNT,@ARREAR,@DNB,@CYCLEID,@REMARKS,@MODON,@MODBY)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@CYCLEID", billCycleID);
            cmd.Parameters.AddWithValue("@WAIVERAMOUNT", Convert.ToDouble(pStrWaiverAmount));
            cmd.Parameters.AddWithValue("@ARREAR", Convert.ToDouble(pStrArrearAmount));
            cmd.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmd.Parameters.AddWithValue("@DNB", "F");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
            cmd.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            cmduserStatusLog.CommandType = CommandType.StoredProcedure;
            cmduserStatusLog.CommandText = "INSERTUSERSTATUSLOG";
            cmduserStatusLog.Parameters.AddWithValue("@USERID", pStrUserID);
            cmduserStatusLog.Parameters.AddWithValue("@STATUS", "A");
            cmduserStatusLog.Parameters.AddWithValue("DATE", preactivationdate);
            cmduserStatusLog.Parameters.AddWithValue("@REMARKS", pStrRemarks);
            cmduserStatusLog.Parameters.AddWithValue("@MODBY", pStrModBy);  

           // cmduserMaster.CommandText = "Update USERMASTER set STATUS='" + UpdateStatusEnumValue.enumValue(UpdateStatus.ACTIVATE) + "' where userid='" + pStrUserID + "'"; ;
            cmduserMaster.CommandText = "Update USERMASTER set STATUS='A' where userid='" + pStrUserID + "'"; ;

            try
            {

                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmduserStatusLog.Transaction = tr;
                cmduserMaster.Transaction = tr;

                cmd.ExecuteNonQuery();
                cmduserStatusLog.ExecuteNonQuery();
                cmduserMaster.ExecuteNonQuery();
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

        #region Arrear and waiver History Listing
        
        public static DataSet GetArrearWaiverHistory(String pStrUserID,String pStrStatus)
        {
            DataSet dst = new DataSet();
            SqlConnection conn=null;
            SqlDataAdapter dad=null;
             String strQueryString=String.Empty;
             
            if (pStrStatus == "A")
             {
                 strQueryString = "Select cast(ARREAR as decimal(10,2))Arrear,CYCLEID,MODON,REMARKS from WAD where USERID='" + Utilities.ValidSql(pStrUserID) + "' and DNB='F'";
             }
             else if(pStrStatus=="W")
             {
                 strQueryString = "Select cast(WAIVER as decimal(10,2))Waiver,CYCLEID,MODON,REMARKS from WAD where USERID='" + Utilities.ValidSql(pStrUserID) + "' and DNB='F'";
             }
            try
            {
               conn = new SqlConnection(DBConn.GetConString());
                dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        #endregion




        #region Add morebytes details 
        public void AddMoreBytes(String pStrUserID,String psUsername, String psLocation, String psTopupGB,  int pStrBillCycleID, double psAmount, String psMorebytesPackage, String pStrModBy)
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
            cmd.CommandText = "Insert MOREBYTES(USERID,USERNAME, LOCATION,TOPUPGB,AMOUNT,ACTIVATEDON,CYCLEID,MOREBYTESPACKAGENAME,MODBY)Values(@USERID,@USERNAME,@LOCATION,@TOPUPGB,@AMOUNT, @ACTIVATEDON, @CYCLEID,@MOREBYTESPACKAGENAME,@MODBY)";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@USERNAME", Utilities.ValidSql(psUsername));
            cmd.Parameters.AddWithValue("@LOCATION", Utilities.ValidSql(psLocation));
            cmd.Parameters.AddWithValue("@TOPUPGB", Utilities.ValidSql(psTopupGB));
            cmd.Parameters.AddWithValue("@AMOUNT", Convert.ToDouble(psAmount));
            cmd.Parameters.AddWithValue("@ACTIVATEDON", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@CYCLEID", pStrBillCycleID);
            cmd.Parameters.AddWithValue("@MOREBYTESPACKAGENAME", Utilities.ValidSql(psMorebytesPackage));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
          

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
    }
}
