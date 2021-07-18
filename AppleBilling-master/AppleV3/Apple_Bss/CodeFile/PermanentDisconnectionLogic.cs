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
    public class PermanentDisconnectionLogic
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
        public PermanentDisconnectionLogic()
        {
        }

        //Constructor with parameter

        public PermanentDisconnectionLogic(string pStrUserID)
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

        #region FUNTIONALITY TO REGISTER Permanent DISCONNECTION DETAILS 
       
        public void RegisterPermanentDisconnectDetails(String pStrUserID, String pStrDisconnectionDate, String pStrModBy, Char pcharstatus, String pscannedFormname, String premarks )
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());           
            SqlCommand cmduserStatusLog = conn.CreateCommand();        

            cmduserStatusLog.CommandType = CommandType.StoredProcedure;
            cmduserStatusLog.CommandText = "UPDATEUSERCONNECTIONSTATUSDETAILS";
            cmduserStatusLog.Parameters.AddWithValue("@USERID", pStrUserID);
            cmduserStatusLog.Parameters.AddWithValue("@STATUS",pcharstatus );
            cmduserStatusLog.Parameters.AddWithValue("@DATE", pStrDisconnectionDate);
            cmduserStatusLog.Parameters.AddWithValue("@REMARKS", premarks);
            cmduserStatusLog.Parameters.AddWithValue("@MODBY", pStrModBy);
            cmduserStatusLog.Parameters.AddWithValue("@SCANNEDFORMNAME", pscannedFormname);
          
            try
            {              
                conn.Open();       
          cmduserStatusLog.ExecuteNonQuery();          
   
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
