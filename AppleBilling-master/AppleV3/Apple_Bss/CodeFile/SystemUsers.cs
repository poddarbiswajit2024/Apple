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
     
    public class SystemUsers
    {
        protected String _txtEmpID;
        protected String _txtName;
        protected String _txtDesignation;
        protected String _txtDOB;        
        protected Int32 _Int32Priv;
        protected String _txtPassword;
        protected String _txtMobileNumber;
        protected String _txtLandlineNumber;
        protected String _txtStatus;
        protected String _txtModBy;
        protected String _txtModOn;

        public string EmpID
        {
            get { return _txtEmpID; }
            set { _txtEmpID = value; }
        }

        public string EmployeeName
        {
            get { return _txtName; }
            set { _txtName = value; }
        }

        public string Designation
        {
            get { return _txtDesignation; }
            set { _txtDesignation = value; }
        }

        public string DOB
        {
            get { return _txtDOB; }
            set { _txtDOB = value; }
        }

        public Int32 Priv
        {
            get { return _Int32Priv; }
            set { _Int32Priv = value; }
        }

        public string Password
        {
            get { return _txtPassword; }
            set { _txtPassword = value; }
        }

        public string MobileNumber
        {
            get { return _txtMobileNumber; }
            set { _txtMobileNumber = value; }
        }

        public string LandlineNumber
        {
            get { return _txtLandlineNumber; }
            set { _txtLandlineNumber = value; }
        }

        public string Status
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
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

        #region Class Constructors
        
        public SystemUsers()
        {
            _txtEmpID=String.Empty;
            _txtName=String.Empty;
            _txtDesignation=String.Empty;
            _txtDOB=String.Empty;        
            _Int32Priv=-3;
            _txtPassword=String.Empty;
            _txtMobileNumber=String.Empty;
            _txtLandlineNumber=String.Empty;
            _txtStatus = String.Empty;
            _txtModBy = String.Empty;
            _txtModOn=String.Empty;
        }


        public SystemUsers(String pStrEmpID)
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
            cmd.CommandText = "select empid,name,designation,dob,priv,password,mobilenum,landline,status,modby,modon from systemusermaster where empid ='"+ pStrEmpID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    _txtEmpID=dr["EMPID"].ToString();
                    _txtName=dr["NAME"].ToString();
                    _txtDesignation=dr["DESIGNATION"].ToString();
                    _txtDOB=dr["DOB"].ToString();        
                    _Int32Priv=Convert.ToInt32 (dr["PRIV"].ToString());
                    _txtPassword=dr["PASSWORD"].ToString();
                    _txtMobileNumber=dr["MOBILENUM"].ToString();
                    _txtLandlineNumber=dr["LANDLINE"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _txtModBy = dr["MODBY"].ToString();
                    _txtModOn=dr["MODON"].ToString();
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

        public static void UpdateForgotPasswordStatus(String pStrEmpID)
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
            cmd.CommandText = "Update SYSTEMUSERMASTER set FORGOTPASSWORD='True' where EMPID='" + Utilities.ValidSql(pStrEmpID) + "'";

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
        public static bool IsValidUser(String pStrUserID)
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
            cmdcheck.CommandText = "SELECT count(*) from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "'";
            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount == 1)
            {
                EXISTS = true;
            }
            else
            {
                EXISTS = false;
            }

            return (EXISTS);

        }

        public static String GetPassword(String pStrUserID)
        {
            string password = "";

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
            cmdcheck.CommandText = "SELECT password from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "'";
            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                password = cmdcheck.ExecuteScalar().ToString();
            }

            return (password);

        }

        public static String GetName(String pStrUserID)
        {
            string name = "";

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
            cmdcheck.CommandText = "SELECT name from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "'";

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                name = cmdcheck.ExecuteScalar().ToString();
            }

            return (name);

        }

        public static Int32 GetPrivilege(String pStrUserID)
        {
            Int32 priv = -1;

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
            cmdcheck.CommandText = "SELECT priv from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "'";

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                priv = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            return (priv);

        }

        #region Change Password Functionality - modified  29/03/2010 -hopeto

        public static bool ChangePassword(String pStrUserID, String pStrOldPassword, String pStrNewPassword)
        {
            bool status = false;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            String newpassword = Encryption.encrypt(pStrNewPassword, 20);
            String oldpassword = Encryption.encrypt(pStrOldPassword, 20);
 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update SYSTEMUSERMASTER set PASSWORD='" + Utilities.ValidSql(newpassword) + "' where EMPID='" + Utilities.ValidSql(pStrUserID) + "' and PASSWORD='" + oldpassword + "'";

            try
            {
                conn.Open();                 
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    status = true;
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
           
            
            return status;
        }

        #endregion

        #region Create New User Code Functionality

        private String GetNewSystemUserCode()
        {

            String strNewUserCode = "SEMP";
            SqlConnection conn;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
         //   cmd.CommandText = "Select cast((max(substring(EMPID,5,4)))+1 as varchar) code from SYSTEMUSERMASTER";
            cmd.CommandText = "Select cast((max(substring(EMPID,5,4)))+1 as varchar) code from SYSTEMUSERMASTER where MODBY !='DVLPR' or modby is null";

            


            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strNewUserCode += "1001";
                    }
                    else
                    {
                        strNewUserCode += dr["code"].ToString();
                    }
                }


                dr.Close();
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (strNewUserCode);
        }

        #endregion

        #region Listing Functionality

        public static DataSet GetActiveSystemUsers()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name,designation,dob,priv,password,mobilenum,landline,status,modby,modon from systemusermaster where STATUS='A'";


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

        #region Listing Functionality By Privilege

        public static DataSet GetActiveSystemUsersByPriv(Int32 pInt32Priv)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name,designation,dob,priv,password,mobilenum,landline,status,modby,modon from systemusermaster where STATUS='A' and priv="+pInt32Priv;

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

        //Code by Zeko
        #region Listing of Technical Assistant privilledge Level 3
        
        public static DataSet GetTechAssistantPrivID()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name from SYSTEMUSERMASTER where STATUS='A' and priv in('3','7')";


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

        #region Listing of Customer Care Executive Level -2 and Colelction Boy Priv = 9

        public static DataSet GetCustCareExecPrivID()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name from SYSTEMUSERMASTER where STATUS='A' and priv in('-2','9')";
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

        #region Listing of Colelction Boy Priv = 9

        public static DataSet GetCollectionBoyExecPrivID()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name from SYSTEMUSERMASTER where STATUS='A' and priv=9";
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


        #region Listing of Sales  Memebers - modified - 20/april/2010 -hopeto
        //this function take s data from two tables- systemusermaster and agentmaster
        public static DataSet GetAuthorizedRegisteringPersons()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name from SYSTEMUSERMASTER where STATUS='A' and priv in('4', '6')";
            string strQueryString2 = "select AGENTCODE,AGENTNAME from AGENTMASTER where STATUS='A'";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {                
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                SqlDataAdapter dad2 = new SqlDataAdapter(strQueryString2, conn);
                dad.Fill(dst,  "EMPLOYEES");
                dad2.Fill(dst, "AGENTS"); 
                                

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

        //hopeto
        #region Add new system users
        public void AddNewSysUsers(String strPriv, String strPass, String strName, String strDesig, String strDOB, String strMobile, String strLandline,  String strModBy)
        {
           // SqlTransaction tr = null;
            SqlConnection conn = null;
            string newSysUser = "";

            try
            {
                newSysUser += this.GetNewSystemUserCode();
            }
            catch
            {
                throw;
            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd = conn.CreateCommand();


            cmd.CommandText = "insert SYSTEMUSERMASTER (EMPID, PRIV, PASSWORD, NAME, DESIGNATION, DOB, MOBILENUM, LANDLINE, STATUS, MODBY, MODON) values (@EMPID, @PRIV, @PASSWORD, @NAME, @DESIGNATION, @DOB, @MOBILENUM, @LANDLINE, @STATUS, @MODBY, @MODON)";
            cmd.Parameters.AddWithValue("@EMPID", newSysUser);
            cmd.Parameters.AddWithValue("@PRIV", Utilities.ValidSql(strPriv));
            cmd.Parameters.AddWithValue("@PASSWORD", Utilities.ValidSql(Encryption.encrypt(strPass, 20)));
            cmd.Parameters.AddWithValue("@NAME", Utilities.ValidSql(strName));
            cmd.Parameters.AddWithValue("@DESIGNATION", Utilities.ValidSql(strDesig));
            cmd.Parameters.AddWithValue("@DOB", Utilities.ValidSql(strDOB));
            cmd.Parameters.AddWithValue("@MOBILENUM", Utilities.ValidSql(strMobile));
            cmd.Parameters.AddWithValue("@LANDLINE", Utilities.ValidSql(strLandline));
            cmd.Parameters.AddWithValue("@STATUS", "A");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(strModBy));
            cmd.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString());

            try
            {
                conn.Open();
              //  tr = conn.BeginTransaction();
              //  cmd.Transaction = tr;

                cmd.ExecuteNonQuery();
               // tr.Commit();
            }
            catch
            {
               // tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
#endregion

        #region Add new system users without dob
        public void AddNewSysUserPartial(String strPriv,  String strName, String strPass, String strDesig, String strMobile, String strLandline, String strModBy)
        {
           
            SqlConnection conn = null;
            string newSysUser = "";

            try
            {
                newSysUser += this.GetNewSystemUserCode();
            }
            catch
            {
                throw;
            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd = conn.CreateCommand();


            cmd.CommandText = "insert SYSTEMUSERMASTER (EMPID, PRIV,  NAME, PASSWORD, DESIGNATION, MOBILENUM, LANDLINE, STATUS, MODBY, MODON) values (@EMPID, @PRIV, @NAME,@PASSWORD, @DESIGNATION,  @MOBILENUM, @LANDLINE, @STATUS, @MODBY, @MODON)";
            cmd.Parameters.AddWithValue("@EMPID", newSysUser);
            cmd.Parameters.AddWithValue("@PRIV", Utilities.ValidSql(strPriv));
            cmd.Parameters.AddWithValue("@PASSWORD", Utilities.ValidSql(Encryption.encrypt(strPass, 20)));
            cmd.Parameters.AddWithValue("@NAME", Utilities.ValidSql(strName));
            cmd.Parameters.AddWithValue("@DESIGNATION", Utilities.ValidSql(strDesig));
           
            cmd.Parameters.AddWithValue("@MOBILENUM", Utilities.ValidSql(strMobile));
            cmd.Parameters.AddWithValue("@LANDLINE", Utilities.ValidSql(strLandline));
            cmd.Parameters.AddWithValue("@STATUS", "A");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(strModBy));
            cmd.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString());

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
       
        #region Listing Functionality of all system users

        public static DataSet GetSystemUsers()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name,priv,status from systemusermaster order by priv asc ";


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

        #region system User details in popup functionality
       
        public static DataSet GetSysUserDetails(String strempid)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select empid,name,designation,dob,priv,password,mobilenum,landline,status,modby,modon from systemusermaster where  empid ='" + strempid + "'";


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

        #region change  user status

        public static void ChangeUserStatus(String strEmpID, String strpresentEmpid, String pStrStatus)
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

            cmd.CommandText = "update SYSTEMUSERMASTER set STATUS =@STATUS, MODBY= @MODBY, MODON=@MODON where EMPID=@EMPID";

            cmd.Parameters.AddWithValue("@STATUS", Utilities.ValidSql(pStrStatus));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(strpresentEmpid));
            cmd.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmd.Parameters.AddWithValue("@EMPID", Utilities.ValidSql(strEmpID));
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


        #region update sys user details

        public void UpdateSUser(String strEmpID, String strName, String strPriv, String strDesig, String strdob, String strMobile, String strLandline, String strModby )
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

            cmd.CommandText = "update SYSTEMUSERMASTER set NAME=@NAME,  PRIV = @PRIV, DESIGNATION = @DESIGNATION, DOB= @DOB, MOBILENUM =@MOBILENUM, LANDLINE = @LANDLINE,  MODBY= @MODBY, MODON=@MODON where EMPID=@EMPID";

            cmd.Parameters.AddWithValue("@EMPID", Utilities.ValidSql(strEmpID));
            cmd.Parameters.AddWithValue("@PRIV", Utilities.ValidSql(strPriv));
            //cmd.Parameters.AddWithValue("@PASSWORD", Utilities.ValidSql(Encryption.encrypt(strPass, 20)));
            cmd.Parameters.AddWithValue("@NAME", Utilities.ValidSql(strName));
            cmd.Parameters.AddWithValue("@DOB",Utilities.ValidSql(strdob));
            cmd.Parameters.AddWithValue("@DESIGNATION", Utilities.ValidSql(strDesig));
            cmd.Parameters.AddWithValue("@MOBILENUM", Utilities.ValidSql(strMobile));
            cmd.Parameters.AddWithValue("@LANDLINE", Utilities.ValidSql(strLandline));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(strModby));
            cmd.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString());
           
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

        #region update sys user details without dob

        public void UpdateSUserPartial(String strEmpID, String strName, String strPriv, String strDesig, String strMobile, String strLandline, String strModby)
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

            cmd.CommandText = "update SYSTEMUSERMASTER set NAME=@NAME,  PRIV = @PRIV, DESIGNATION = @DESIGNATION, MOBILENUM =@MOBILENUM, LANDLINE = @LANDLINE,  MODBY= @MODBY, MODON=@MODON where EMPID=@EMPID";

            cmd.Parameters.AddWithValue("@EMPID", Utilities.ValidSql(strEmpID));
            cmd.Parameters.AddWithValue("@PRIV", Utilities.ValidSql(strPriv));
             cmd.Parameters.AddWithValue("@NAME", Utilities.ValidSql(strName));            
            cmd.Parameters.AddWithValue("@DESIGNATION", Utilities.ValidSql(strDesig));
            cmd.Parameters.AddWithValue("@MOBILENUM", Utilities.ValidSql(strMobile));
            cmd.Parameters.AddWithValue("@LANDLINE", Utilities.ValidSql(strLandline));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(strModby));
            cmd.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString());

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

        #region DELETESYSTEM USER PERMANENTLY
        public static void DeleteSUserByID(string strempId)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from SYSTEMUSERMASTER Where EMPID=@EMPID";
            cmd.Parameters.AddWithValue("@EMPID", Utilities.ValidSql(strempId));
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

        #region Validate User wen forgot password
        public static bool ValidUser(String pStrUserID, String strName)
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
            cmdcheck.CommandText = "SELECT count(*) from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "'" + "and NAME='" + Utilities.ValidSql(strName) + "'"; 

            conn.Open();

            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                usercount = Convert.ToInt32(cmdcheck.ExecuteScalar());
            }

            if (usercount == 1)
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

        

        #region Change Password Functionality when forgot

        public static void ChangePasswordonForgot(String pStrUserID, String strName, String pStrNewPassword)
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


            String newpassword = Utilities.ValidSql(Encryption.encrypt(pStrNewPassword, 20));
            

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update SYSTEMUSERMASTER set PASSWORD='" + newpassword + "' where EMPID='" + Utilities.ValidSql(pStrUserID) + "' and Name='" + Utilities.ValidSql(strName) + "'";

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

       
         
        #region Functionality to check user id and passwrod together  - 30/03/2010 - hopeto
        public  bool IsAuthorizedUser(String pStrUserID, String strEncryptedPassword)
        {
            bool AUTHORIZED = false;            
           
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            try
            {
                SqlCommand cmdcheck = conn.CreateCommand();
                cmdcheck.CommandText = "SELECT count(*) from SYSTEMUSERMASTER where status ='A' and  EMPID='" + Utilities.ValidSql(pStrUserID) + "' and Password = '" + strEncryptedPassword + "'";

                conn.Open();
                //if one user with the specifeis id as well as password is present
                if (Convert.ToInt32(cmdcheck.ExecuteScalar()) == 1)
                {
                    AUTHORIZED = true;
                    //if authorized then send back user data
                    cmdcheck.CommandText = "SELECT empid, name, priv from SYSTEMUSERMASTER where EMPID='" + Utilities.ValidSql(pStrUserID) + "' and Password = '" + strEncryptedPassword + "'";
                    SqlDataReader dr = cmdcheck.ExecuteReader();
                    while (dr.Read())
                    {
                        _txtEmpID = dr["EMPID"].ToString();
                        _txtName = dr["NAME"].ToString();
                        _Int32Priv = Convert.ToInt32(dr["PRIV"].ToString());

                    }
                    dr.Close();
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
            return (AUTHORIZED);
           

        }
#endregion



    }
}
