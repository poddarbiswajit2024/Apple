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
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Apple_Bss.CodeFile
{
    public class BroadbandUserConectivityDetails
    {
        #region Class Variables

        protected String _txtUserID;
        protected String _txtPopID;
        protected String _txtConectivityDetails;
        protected String _txtModBy;
        protected String _txtModOn;
        public string UserID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }

        public string PopID
        {
            get { return _txtPopID; }
            set { _txtPopID = value; }
        }

        public string ConnectivityDetails
        {
            get { return _txtConectivityDetails; }
            set { _txtConectivityDetails = value; }
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

        #region Class Constructors

        public BroadbandUserConectivityDetails()
        {
            //default Constructor
        }

        public BroadbandUserConectivityDetails(String pStrUserID) // constructor with one Parameter
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select  USERID,POPID,CONNECTIVITYDETAILS from USERCONNECTIVITYDETAILS where a.userid='" + pStrUserID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtPopID = dr["POPID"].ToString();
                    _txtConectivityDetails = dr["CONNECTIVITYDETAILS"].ToString();
                    _txtModBy = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();

                    dr.Close();
                    conn.Close();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    
        #region InSert Client Conenctivity Details
       
        public void RegisterUserConnectivityDetails(String pStrUserID, String pStrPopID, String pStrConnectivityDetails,String pStrModby)
        {

            SqlTransaction tr = null; 
            SqlConnection conn = null;
                     
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmdUserCon = conn.CreateCommand();
            SqlCommand cmdAllocation = conn.CreateCommand();
            
            //Updating the USERMASTER TABLE.
            cmdAllocation.CommandText = "Update USERMASTER set NETWORKALLOCATIONSTATUS='" + "Y" + "' where userid='" + pStrUserID + "'";
            //insert into POPMASTER table

            cmdUserCon.CommandText = "insert USERCONNECTIVITYDETAILS(USERID,POPID,CONNECTIVITYDETAILS,MODBY,MODON) values (@USERID,@POPID,@CONNECTIVITYDETAILS,@MODBY,@MODON)";
            cmdUserCon.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmdUserCon.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopID));
            cmdUserCon.Parameters.AddWithValue("@CONNECTIVITYDETAILS", Utilities.ValidSql(pStrConnectivityDetails));           
            cmdUserCon.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdUserCon.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdAllocation.Transaction = tr;
                cmdUserCon.Transaction = tr;
                cmdUserCon.ExecuteNonQuery(); //insert into USERCONNECTIVITYDETAILS
                cmdAllocation.ExecuteNonQuery();//update the NETWORKALLOCATIONSTATUS of USERMASTER TABLE TO 'Y'
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
    }
       
}
