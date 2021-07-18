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
    //db tables df_linkmaster, df_ledger
    public class DarkFiber
    {
        
        #region Variables & Accessor Methods
        protected String _txtUserID;       
        protected String _txtName;
        protected String _txtUserName;
        protected String _txtPassword;       
        protected String _txtCorAdr;  
        protected String _txtMobileNumber;
        protected String _txtAltMobileNumber;
        protected String _txtLandlineNumber;
        protected String _txtEmailID;  
        protected String _txtStatus;
        protected String _txtModOn;



        
        public string AccountID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }
        
        public string Password
        {
            get { return _txtPassword; }
            set { _txtPassword = value; }
        }
       
        public string Name
        {
            get { return _txtName; }
            set { _txtName = value; }
        }

        public string UserName
        {
            get { return _txtUserName; }
            set { _txtUserName = value; }
        }      


        public string CorrespondenceAddress
        {
            get { return _txtCorAdr; }
            set { _txtCorAdr = value; }
        }
        public string MobileNumber
        {
            get { return _txtMobileNumber; }
            set { _txtMobileNumber = value; }
        }

        public string AlternativeMobileNumber
        {
            get { return _txtAltMobileNumber; }
            set { _txtAltMobileNumber = value; }
        }

        public string LandlineNumber
        {
            get { return _txtLandlineNumber; }
            set { _txtLandlineNumber = value; }
        }
        
        public string EmailID
        {
            get { return _txtEmailID; }
            set { _txtEmailID = value; }
        }
          
        public string Status
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
        }

        public string ModOn
        {
            get { return _txtModOn; }
            set { _txtModOn = value; }
        }

        #endregion

        #region Class Constructors
        
        public DarkFiber()
        {
        }


        public DarkFiber(String pStrUserID)
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
            cmd.CommandText = "SELECT ACCOUNTID,NAME,USERNAME,PASSWORD,CORADR,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID1,STATUS,MODON from DF_ACCOUNTMASTER where ACCOUNTID='" + pStrUserID + "'";
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["ACCOUNTID"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _txtUserName = dr["USERNAME"].ToString();
                    _txtPassword = dr["PASSWORD"].ToString();                
                    _txtCorAdr = dr["CORADR"].ToString();                
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtAltMobileNumber = dr["ALTMOBILENUMBER"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtEmailID = dr["EMAILID1"].ToString();           
                    _txtModOn = dr["MODON"].ToString();
                    _txtStatus = dr["STATUS"].ToString();                
                    
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

        #region Create New User Code Functionality

        public void RegisterUser(String pStrCustomerName, String psUsername, String psPassword, String pStrCorrespondenceAddress, String pStrMobileNumber, String pStrAltMobileNumber, String pStrLandlineNumber, String pStrEmail1, String pStrEmail2, String pStrEmail3, String pStrModby, String pUserGSTIN)
        {          
            String strCode = DBConn.GetBranchCode() + "-SCAX";
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmduser = conn.CreateCommand();
            SqlCommand cmduserdetails = conn.CreateCommand();
            cmduser.CommandText = "Select cast((max(substring(ACCOUNTID,9,4)))+1 as varchar) code from DF_ACCOUNTMASTER";

            cmduserdetails.CommandText = "insert DF_ACCOUNTMASTER (accountid,NAME,USERNAME, PASSWORD, CORADR,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID1,EMAILID2,EMAILID3, STATUS,MODBY,MODON,USERGSTIN) values (@ACCOUNTID,@NAME,@USERNAME,@PASSWORD, @CORADR,@MOBILENUMBER,@ALTMOBILENUMBER,@LANDLINENUMBER,@EMAILID1, @EMAILID2,@EMAILID3, @STATUS,@MODBY,@MODON)";
            cmduserdetails.Parameters.AddWithValue("@NAME", Utilities.ValidSql(pStrCustomerName));
            cmduserdetails.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 100).Value = psUsername;
            cmduserdetails.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 20).Value = psPassword;
            cmduserdetails.Parameters.AddWithValue("@CORADR", Utilities.ValidSql(pStrCorrespondenceAddress));
            cmduserdetails.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNumber));
            cmduserdetails.Parameters.AddWithValue("@ALTMOBILENUMBER", Utilities.ValidSql(pStrAltMobileNumber));
            cmduserdetails.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNumber));
            cmduserdetails.Parameters.AddWithValue("@EMAILID1", Utilities.ValidSql(pStrEmail1));
            cmduserdetails.Parameters.Add("@EMAILID2", SqlDbType.NVarChar, 100).Value = pStrEmail2;
            cmduserdetails.Parameters.Add("@EMAILID3", SqlDbType.NVarChar, 100).Value = pStrEmail3;
            cmduserdetails.Parameters.AddWithValue("@STATUS", "A");
            cmduserdetails.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmduserdetails.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            cmduserdetails.Parameters.AddWithValue("@USERGSTIN", Utilities.ValidSql(pUserGSTIN));

            try
            {
                conn.Open();
                SqlDataReader dr = cmduser.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["code"] != DBNull.Value)
                    {
                        strCode += dr["code"].ToString();                        
                    }
                    else
                    {
                        strCode += "1001";
                    }
                }

                dr.Close();
                //add retrieved accountid
                cmduserdetails.Parameters.Add("@ACCOUNTID", SqlDbType.VarChar, 12).Value = strCode;
                cmduserdetails.ExecuteNonQuery();             

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

        #region Checking for duplicate username

        public static bool UsernameExists(string pStrUserName)
        {
            bool EXISTS = true;
            Int32 usercount = 0;

            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "SELECT count(USERNAME) from DF_ACCOUNTMASTER where USERNAME='" + Utilities.ValidSql(pStrUserName) + "'";

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount >= 1)
            {
                EXISTS = true;
            }
            else
            {
                EXISTS = false;
            }

            return (EXISTS);
        }

        #endregion

        public static DataTable GetFiberAccoutns()
        {
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                DataTable dt = new DataTable();
                SqlCommand cmd = conn.CreateCommand();
               // cmd.CommandType = CommandType.StoredProcedure;
                //DISPLAY OF USERS: FIRST IN FIRST OUT
                cmd.CommandText = "SELECT ACCOUNTID, USERNAME, CORADR, MOBILENUMBER, EMAILID1, NAME FROM DF_ACCOUNTMASTER ORDER BY MODON ASC";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr); dr.Close();
                return (dt);

            }
            catch
            {
                throw;
            }

        }

        public static DataTable GetAllAccounts()
        {
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                DataTable dt = new DataTable();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GETALLACCOUNTIDS";
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr); dr.Close();
                return (dt);

            }
            catch
            {
                throw;
            }

        }

        #region Add Link Details

        public void AddLinkDetails(String psName, String psInstalllationAdd, String psConnectionDate, Int32 pAerialLength, Int32 pUndergroundLength, String psJMC, String psOTDR, String psModby,String psAccountID)
        {            
            SqlConnection conn = null;
          
           conn = new SqlConnection(DBConn.GetConString());
           SqlCommand cmdlnk = conn.CreateCommand();  
           SqlCommand cmdlnkmaster = conn.CreateCommand(); 
        

            string branchid = DBConn.GetBranchCode();
           string strnewID = "LNK";
            string datetoday = System.DateTime.Now.ToString("MM-dd-yyyy");

            cmdlnk.CommandText = "Select cast((max(substring(LINKID,4,4)))+1 as varchar) code from DF_LINKMASTER";                         
            cmdlnkmaster.CommandType = CommandType.StoredProcedure;
            cmdlnkmaster.CommandText = "INSERTLINKMASTER";
           
           cmdlnkmaster.Parameters.AddWithValue("@BRANCHID", Utilities.ValidSql(branchid));
           cmdlnkmaster.Parameters.AddWithValue("@NAME", Utilities.ValidSql(psName));
            cmdlnkmaster.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(psInstalllationAdd));          
            cmdlnkmaster.Parameters.AddWithValue("@CONNECTIONDATE", Utilities.ValidSql(psConnectionDate));
            cmdlnkmaster.Parameters.AddWithValue("@ALENGTH",pAerialLength );
            cmdlnkmaster.Parameters.AddWithValue("@ULENGTH", pUndergroundLength);
            cmdlnkmaster.Parameters.AddWithValue("@JMC", Utilities.ValidSql(psJMC));
            cmdlnkmaster.Parameters.AddWithValue("@OTDR", Utilities.ValidSql(psOTDR));           
            cmdlnkmaster.Parameters.AddWithValue("@STATUS", "A");
            cmdlnkmaster.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(psModby));
            cmdlnkmaster.Parameters.AddWithValue("@MODON",datetoday);
            cmdlnkmaster.Parameters.AddWithValue("@ACCOUNTID", Utilities.ValidSql(psAccountID));

    
            try
            {
                conn.Open();
                SqlDataReader dr = cmdlnk.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["code"] != DBNull.Value)
                    {
                        strnewID += dr["code"].ToString();
                    }
                    else
                    {
                        strnewID += "1001";
                    }
                }

                dr.Close();
                //add retrieved LINK ID
                cmdlnkmaster.Parameters.AddWithValue("@LINKID", strnewID);                 
                cmdlnkmaster.ExecuteNonQuery();  
              
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
