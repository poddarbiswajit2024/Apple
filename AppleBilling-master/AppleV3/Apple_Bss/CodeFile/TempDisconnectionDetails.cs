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
    public class TempDisconnectionDetails
    {

        #region VARIABLES,GETTERS AND SETTERS METHODS

        protected string _txtUserID;
        protected string _txtStartDate;
        protected string _txtEndDate;
        protected string _txtTillFurtherNotice;
        protected string _txtReactivationFlag;
        protected string _txtModBy;
        protected string _txtModOn;


        public string UserID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }
        
        public string StartDate
        {
            get { return _txtStartDate; }
            set { _txtStartDate = value; }
        }

        public string EndDate
        {
            get { return _txtEndDate; }
            set { _txtEndDate = value; }
        }

        public string TillFurtherNotice
        {
            get { return _txtTillFurtherNotice; }
            set { _txtTillFurtherNotice = value; }
        }

        public string ReactivationFlag
        {
            get { return _txtReactivationFlag; }
            set { _txtReactivationFlag = value; }
        }

        public string ModBy
        {
            get { return _txtModBy; }
            set { _txtModBy = value; }
        }
        
        public string ModOn
        {
            get { return _txtModOn; }
            set { _txtModOn = value; }
        }

        #endregion

        #region CLASS CONSTRUCTORS
        //Default Constructors
        public TempDisconnectionDetails()
        {
        }

        //Constructor with parameter

        public TempDisconnectionDetails(string pStrUserID)
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
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.CommandText = "Select USERID,STARTDATE,ENDDATE,TFN,REACTIVATIONFLAG,MODBY,MODON from TEMPORARYDISCONNECTIONDETAILS where USERID=@USERID";
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {                   
                    _txtUserID = dr["USERID"].ToString();
                    _txtStartDate = dr["STARTDATE"].ToString();
                    _txtEndDate = dr["ENDDATE"].ToString();
                    _txtTillFurtherNotice = dr["TFN"].ToString();
                    _txtReactivationFlag = dr["REACTIVATIONFLAG"].ToString();                   
                    _txtModBy = dr["MODBY"].ToString();
                    _txtModOn = Convert.ToDateTime(dr["MODON"].ToString()).ToString("MM-dd-yyyy");
                }
                dr.Close();
                conn.Close();
            }

            catch
            {
                throw;
            }
        }
        #endregion

        #region FUNTIONALITY TO REGISTER TEMPORARY DISCONNECTION DETAILS 
       
        public void RegisterTempDisconnectDetails(String pStrUserID, String pStrStartDate, String pStrEndDate, String pStrModBy, Char pcharstatus, String pscannedFormname, String premarks )
        {
            SqlConnection conn;
            SqlTransaction tr = null;
            

            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmduserStatusLog = conn.CreateCommand();
   

            cmd.CommandText = "Insert TEMPORARYDISCONNECTIONDETAILS(USERID,STARTDATE,ENDDATE,TFN,REACTIVATIONFLAG,MODON,MODBY)Values(@USERID,@STARTDATE,@ENDDATE,@TFN,@REACTIVATIONFLAG,@MODON,@MODBY)";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@STARTDATE", Utilities.ValidSql(pStrStartDate));
        
            cmd.Parameters.AddWithValue("@ENDDATE", Utilities.ValidSql(pStrEndDate));
            cmd.Parameters.AddWithValue("@TFN","F");
            cmd.Parameters.AddWithValue("@REACTIVATIONFLAG", "F");          
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModBy));
            cmd.Parameters.AddWithValue("@MODON", DateTime.Now);

            cmduserStatusLog.CommandType = CommandType.StoredProcedure;
            cmduserStatusLog.CommandText = "UPDATEUSERCONNECTIONSTATUSDETAILS";
            cmduserStatusLog.Parameters.AddWithValue("@USERID", pStrUserID);
            cmduserStatusLog.Parameters.AddWithValue("@STATUS",pcharstatus );
            cmduserStatusLog.Parameters.AddWithValue("DATE", pStrStartDate);
            cmduserStatusLog.Parameters.AddWithValue("@REMARKS", premarks);
            cmduserStatusLog.Parameters.AddWithValue("@MODBY", pStrModBy);
            cmduserStatusLog.Parameters.AddWithValue("@SCANNEDFORMNAME", pscannedFormname);
        
            try
            {               
                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmduserStatusLog.Transaction = tr;  
                cmd.ExecuteNonQuery();
                cmduserStatusLog.ExecuteNonQuery();      
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

        public  Int32 GetNumberofTempdisconnectionalreadytaken(String pStrUserID, int pAppliedyear)
        {
            Int32 days = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
                SqlCommand cmdcheck = conn.CreateCommand();
                cmdcheck.CommandType = CommandType.StoredProcedure;
                cmdcheck.CommandText = "GetTemporaryDisconnectedDaysForAYear";
                cmdcheck.Parameters.AddWithValue("@userid", pStrUserID);
                cmdcheck.Parameters.AddWithValue("@appliedyear", pAppliedyear);
               

                conn.Open();

                if (cmdcheck.ExecuteScalar() != DBNull.Value)
                {
                    days = Convert.ToInt32(cmdcheck.ExecuteScalar());

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

            return (days);

        }
    }
}
