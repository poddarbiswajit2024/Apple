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
    public class RegisteredBroadbandUsers
    {
        
        #region Variables & Accessor Methods
        protected String _txtUserID;       
        protected String _txtName;
        protected String _txtUserName;
        protected String _txtPassword;
        protected String _txtInsAdr;
        protected String _txtCorAdr;
        protected String _txtRegistrationDate;
        protected String _txtConnectionDate;
        protected String _txtMobileNumber;
        protected String _txtAltMobileNumber;
        protected String _txtLandlineNumber;
        protected String _txtEmailID;        
        protected String _txtBillPlanID;        
        protected String _txtRentalPaymentMode;
        protected String _txtOTRCPaymentMode;
        protected Int32 _intPriority;
        protected String _txtEmpID;
        protected String _txtAgentCode;
        protected String _txtIsAgentAccount;
        protected String _txtStatus;
        protected String _txtRemarks;
        protected String _txtModby;
        protected String _txtModOn;
        protected String _txtAddressProofType;
        protected String _txtIdProofType;
        protected String _txtPhotoFileName;
        protected String _txtIdProofName;
        protected String _txtAddressProofName;
        protected String _txtInstallationConnectionType;

        protected String _txtIdProofNameBack;
        protected String _txtAddressProofNameBack;
        


        public string AddressProofType
        {
            get { return _txtAddressProofType; }
            set { _txtAddressProofType = value; }
        }
                     
        public string IDProofType
        {
            get { return _txtIdProofType; }
            set { _txtIdProofType = value; }
        }
        public string PhotoThumbName
        {
            get { return _txtPhotoFileName; }
            set { _txtPhotoFileName = value; }
        }
        public string IDProofName
        {
            get { return _txtIdProofName; }
            set { _txtIdProofName = value; }
        }

        public string IDProofNameBack
        {
            get { return _txtIdProofNameBack; }
            set { _txtIdProofNameBack = value; }
        }


        public string AddressProofName
        {
            get { return _txtAddressProofName; }
            set { _txtAddressProofName = value; }
        }

        public string AddressProofNameBack
        {
            get { return _txtAddressProofNameBack; }
            set { _txtAddressProofNameBack = value; }
        }

        
        public string UserID
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
                
        public string InstallationAddress
        {
            get { return _txtInsAdr; }
            set { _txtInsAdr = value; }
        }

        public string CorrespondenceAddress
        {
            get { return _txtCorAdr; }
            set { _txtCorAdr = value; }
        }

        public string RegistrationDate
        {
            get { return _txtRegistrationDate; }
            set { _txtRegistrationDate = value; }
        }

        public string ConnectionDate
        {
            get { return _txtConnectionDate; }
            set { _txtConnectionDate = value; }
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

        public string BillPlanID
        {
            get { return _txtBillPlanID; }
            set { _txtBillPlanID = value; }
        }

        public string RentalPaymentMode
        {
            get { return _txtRentalPaymentMode; }
            set { _txtRentalPaymentMode = value; }
        }

        public string OTRCPaymentMode
        {
            get { return _txtOTRCPaymentMode; }
            set { _txtOTRCPaymentMode = value; }
        }

        public Int32 Priority
        {
            get { return _intPriority; }
            set { _intPriority = value; }
        }

        public string EmployeeID
        {
            get { return _txtEmpID; }
            set { _txtEmpID = value; }
        }

        public string AgentCode
        {
            get { return _txtAgentCode; }
            set { _txtAgentCode = value; }
        }

        public string IsAgentAccount
        {
            get { return _txtIsAgentAccount; }
            set { _txtIsAgentAccount = value; }
        }
                        
        public string Status
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
        }

        public string ModBy
        {
            get { return _txtModby; }
            set { _txtModby = value; }
        }

        public string ModOn
        {
            get { return _txtModOn; }
            set { _txtModOn = value; }
        }

        #endregion

        protected String _ReturnMessage;
        public string ReturnMessage
        {
            get { return _ReturnMessage; }
            set { _ReturnMessage = value; }
        }
        protected string _txtcafnumber;
        public string CAFNumber
        {
            get { return _txtcafnumber; }
            set { _txtcafnumber = value; }
        }

        protected string _txtCAFDocument;
        public string CAFDocumentName
        {
            get { return _txtCAFDocument; }
            set { _txtCAFDocument = value; }
        }

        protected string _txtcafAnnexure;
        public string CAFAnnxureDoc
        {
            get { return _txtcafAnnexure; }
            set { _txtcafAnnexure = value; }
        }

        protected string _txtcafSignature;
        public string CAFSignatureDoc
        {
            get { return _txtcafSignature; }
            set { _txtcafSignature = value; }
        }


        protected int _intLAPID;
        public int LAPID
        {
            get { return _intLAPID; }
            set { _intLAPID = value; }
        }
        public string InstallationConnectionType
        {
            get { return _txtInstallationConnectionType; }
            set { _txtInstallationConnectionType = value; }
        }

        protected string _txtUserGSTIN;
        public string UserGSTIN
        {
            get { return _txtUserGSTIN; }
            set { _txtUserGSTIN = value; }
        }




        #region Class Constructors

        public RegisteredBroadbandUsers()
        {
          
            _txtUserID = String.Empty;
            _txtName = String.Empty;
            _txtUserName = String.Empty;
            _txtInsAdr = String.Empty;
            _txtCorAdr = String.Empty;
            _txtRegistrationDate = String.Empty;
            _txtConnectionDate = String.Empty;
            _txtMobileNumber = String.Empty;
            _txtAltMobileNumber = String.Empty;
            _txtLandlineNumber = String.Empty;
            _txtEmailID = String.Empty;
            _txtBillPlanID = String.Empty;
            _txtRentalPaymentMode = String.Empty;
            _txtOTRCPaymentMode = String.Empty;
            _intPriority = 0;
            _txtEmpID = String.Empty;
            _txtAgentCode = String.Empty;
            _txtIsAgentAccount = String.Empty;
            _txtStatus = String.Empty;
            _txtRemarks = String.Empty;
            _txtModby = String.Empty;
            _txtModOn = String.Empty;
            _txtAddressProofType = String.Empty;
            _txtAddressProofName = String.Empty;
            _txtIdProofType = String.Empty;
            _txtIdProofName = String.Empty;
            _txtPhotoFileName = String.Empty;
            _txtInstallationConnectionType = String.Empty;
            _txtUserGSTIN = String.Empty;
        }


     
        public RegisteredBroadbandUsers(String pStrUserID)
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
            cmd.CommandText = "SELECT USERID,NAME,USERNAME,PASSWORD,INSADR,CORADR,REGISTRATIONDATE,CONNECTIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON,IDPROOFTYPE,IDPROOFNAME,ADDRESSPROOFTYPE,ADDPROOFNAME,PHOTOFILENAME, CAFNUMBER, CAFDOCUMENTNAME, CAFANNEXURENAME, LAPID,INSTALLATIONCONNECTIONTYPE, USERGSTIN from REGISTEREDUSERS where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtName = dr["NAME"].ToString();                  
                    _txtUserName=dr["USERNAME"].ToString();
                    _txtPassword=dr["PASSWORD"].ToString();
                    _txtInsAdr = dr["INSADR"].ToString();
                    _txtCorAdr = dr["CORADR"].ToString();
                    _txtRegistrationDate = dr["REGISTRATIONDATE"].ToString();
                    _txtConnectionDate = dr["CONNECTIONDATE"].ToString();
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtAltMobileNumber = dr["ALTMOBILENUMBER"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtEmailID = dr["EMAILID"].ToString();
                    _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtRentalPaymentMode = dr["RENTALPAYMODE"].ToString();
                    _txtOTRCPaymentMode = dr["OTRCID"].ToString();
                    _intPriority = Convert.ToInt32(dr["PRIORITY"]);
                    _txtEmpID = dr["EMPID"].ToString();
                    _txtAgentCode = dr["AGENTCODE"].ToString();
                    _txtIsAgentAccount = dr["ISAGENTACCOUNT"].ToString();
                    _txtRemarks = dr["REMARKS"].ToString();
                    _txtModby = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _txtAddressProofType = dr["ADDRESSPROOFTYPE"].ToString();
                    _txtAddressProofName=dr["ADDPROOFNAME"].ToString();
                    _txtIdProofType=dr["IDPROOFTYPE"].ToString();
                    _txtIdProofName=dr["IDPROOFNAME"].ToString();
                    _txtPhotoFileName=dr["PHOTOFILENAME"].ToString();

                    _txtcafnumber = dr["CAFNUMBER"].ToString();
                    _txtCAFDocument = dr["CAFDOCUMENTNAME"].ToString();
                    _txtcafAnnexure = dr["CAFANNEXURENAME"].ToString();
                    _intLAPID = Convert.ToInt32(dr["LAPID"]);
                    _txtInstallationConnectionType = dr["INSTALLATIONCONNECTIONTYPE"].ToString();
                    _txtUserGSTIN = dr["USERGSTIN"].ToString();

                }
                dr.Close();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }
        public void GetInstallationConnectionType(String pCafNumber)
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
            cmd.CommandText = "SELECT INSTALLATIONCONNECTIONTYPE from REGISTEREDUSERS where CAFNUMBER='" + Utilities.ValidSql(pCafNumber) + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtcafnumber = dr["CAFNUMBER"].ToString();
                    _txtInstallationConnectionType = dr["INSTALLATIONCONNECTIONTYPE"].ToString();
                    
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

        /*

        
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch (Exception ex)
            {
                throw ex;
            }                
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =           
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
        */


        /// <summary>
        /// It will fetch the registerd user details from registeredusers db table as well as 
        /// fetch new userid from usermaster db table
        /// </summary>
        /// <param name="pStrRegisteredUserID">dynamically generated registered userid at sales module</param>
     /// <returns>the new generated userid of subcriber</returns>
        public string FetchUserDetailsForNewUser(String pStrRegisteredUserID)
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
            cmd.CommandText = "SELECT NAME,PASSWORD from REGISTEREDUSERS where userid=@USERID";
            cmd.Parameters.AddWithValue("@USERID", pStrRegisteredUserID);
            SqlCommand cmdUMUserID = conn.CreateCommand();
            //allowing multiple connect users 
            cmdUMUserID.CommandText = "Select cast((max(substring(USERID,9,4)))+1 as varchar) code from USERMASTER";
            string strNewUserCode = DBConn.GetBranchCode() + "-SCLX";
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtName = dr["NAME"].ToString();
                  
                    _txtPassword = dr["PASSWORD"].ToString();
                }
                dr.Close();
                dr = cmdUMUserID.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["code"] != DBNull.Value)
                    {
                        strNewUserCode += dr["code"].ToString();                  
                    }
                    else
                    {
                        strNewUserCode += "1001";
                    }
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
            return strNewUserCode;
        }


        public void GetRegisteredBroadbandUserDetails(string pCafNumber, String pStatus)
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
            cmd.CommandText = "SELECT USERID,NAME,USERNAME,PASSWORD,INSADR,CORADR,REGISTRATIONDATE,CONNECTIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON,IDPROOFTYPE,IDPROOFNAME,ADDRESSPROOFTYPE,ADDPROOFNAME,PHOTOFILENAME,CAFDOCUMENTNAME,CAFANNEXURENAME,SignatureFileName,IDPROOFNAME_BACK,ADDPROOFNAME_BACK from REGISTEREDUSERS where status='" + pStatus + "' and cafnumber='" + pCafNumber + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _txtUserName = dr["USERNAME"].ToString();
                    _txtPassword = dr["PASSWORD"].ToString();
                    _txtInsAdr = dr["INSADR"].ToString();
                    _txtCorAdr = dr["CORADR"].ToString();
                    _txtRegistrationDate = dr["REGISTRATIONDATE"].ToString();
                    _txtConnectionDate = dr["CONNECTIONDATE"].ToString();
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtAltMobileNumber = dr["ALTMOBILENUMBER"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtEmailID = dr["EMAILID"].ToString();
                    _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtRentalPaymentMode = dr["RENTALPAYMODE"].ToString();
                    _txtOTRCPaymentMode = dr["OTRCID"].ToString();
                    _intPriority = Convert.ToInt32(dr["PRIORITY"]);
                    _txtEmpID = dr["EMPID"].ToString();
                    _txtAgentCode = dr["AGENTCODE"].ToString();
                    _txtIsAgentAccount = dr["ISAGENTACCOUNT"].ToString();
                    _txtRemarks = dr["REMARKS"].ToString();
                    _txtModby = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _txtAddressProofType = dr["ADDRESSPROOFTYPE"].ToString();
                    _txtAddressProofName = dr["ADDPROOFNAME"].ToString();
                    _txtIdProofType = dr["IDPROOFTYPE"].ToString();
                    _txtIdProofName = dr["IDPROOFNAME"].ToString();
                    _txtPhotoFileName = dr["PHOTOFILENAME"].ToString();
                    _txtCAFDocument = dr["CAFDOCUMENTNAME"].ToString();
                    _txtcafAnnexure = dr["CAFANNEXURENAME"].ToString();
                    _txtcafSignature = dr["SignatureFileName"].ToString();
                    _txtIdProofNameBack = dr["IDPROOFNAME_BACK"].ToString();
                    _txtAddressProofNameBack = dr["ADDPROOFNAME_BACK"].ToString();
                   // _txtUserGSTIN = dr["USERGSTIN"].ToString(); 


                }
                dr.Close();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// get pending registered user details for displaying purpose
        /// </summary>
        /// <param name="pCafNumber"></param>
        /// <param name="pStatus"></param>
        public void GetRegisteredUserDetailsByIDandStatus(string registereduserID, String pStatus)
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
            cmd.CommandText = "SELECT USERID,NAME,USERNAME,PASSWORD,INSADR,CORADR,REGISTRATIONDATE,CONNECTIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON,IDPROOFTYPE,IDPROOFNAME,ADDRESSPROOFTYPE,ADDPROOFNAME,PHOTOFILENAME, cafnumber,CAFDOCUMENTNAME,CAFANNEXURENAME, LAPID,INSTALLATIONCONNECTIONTYPE,USERGSTIN,SignatureFileName,IDPROOFNAME_BACK,ADDPROOFNAME_BACK from REGISTEREDUSERS where status in(" + pStatus + ") and userid=@REGISTEREDID";
            cmd.Parameters.AddWithValue("@REGISTEREDID", registereduserID);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _txtUserName = dr["USERNAME"].ToString();
                    _txtPassword = dr["PASSWORD"].ToString();
                    _txtInsAdr = dr["INSADR"].ToString();
                    _txtCorAdr = dr["CORADR"].ToString();
                    _txtRegistrationDate = dr["REGISTRATIONDATE"].ToString();
                    _txtConnectionDate = dr["CONNECTIONDATE"].ToString();
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtAltMobileNumber = dr["ALTMOBILENUMBER"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtEmailID = dr["EMAILID"].ToString();
                    _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtRentalPaymentMode = dr["RENTALPAYMODE"].ToString();
                    _txtOTRCPaymentMode = dr["OTRCID"].ToString();
                    _intPriority = Convert.ToInt32(dr["PRIORITY"]);
                    _txtEmpID = dr["EMPID"].ToString();
                    _txtAgentCode = dr["AGENTCODE"].ToString();
                    _txtIsAgentAccount = dr["ISAGENTACCOUNT"].ToString();
                    _txtRemarks = dr["REMARKS"].ToString();
                    _txtModby = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _txtAddressProofType = dr["ADDRESSPROOFTYPE"].ToString();
                    _txtAddressProofName = dr["ADDPROOFNAME"].ToString();
                    _txtIdProofType = dr["IDPROOFTYPE"].ToString();
                    _txtIdProofName = dr["IDPROOFNAME"].ToString();
                    _txtPhotoFileName = dr["PHOTOFILENAME"].ToString();
                    _txtcafnumber =dr["CAFNumber"].ToString();
                    _txtCAFDocument = dr["CAFDOCUMENTNAME"].ToString();
                    _txtcafAnnexure = dr["CAFANNEXURENAME"].ToString();
                    _intLAPID = Convert.ToInt32(dr["LAPID"]);
                    _txtInstallationConnectionType = dr["INSTALLATIONCONNECTIONTYPE"].ToString();
                    _txtUserGSTIN = dr["USERGSTIN"].ToString();

                    _txtcafSignature = dr["SignatureFileName"].ToString();
                    _txtIdProofNameBack = dr["IDPROOFNAME_BACK"].ToString();
                    _txtAddressProofNameBack = dr["ADDPROOFNAME_BACK"].ToString();

                }
                dr.Close();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }
        
        
         
        #region Listing Of Subscriber by ID
        public static DataSet GetRegisteredSubscriberByID(String pStrUserID)
        {
            DataSet dst = new DataSet();

            string strQueryString = "select A.NAME,A.USERNAME,A.INSADR,A.CORADR,A.REGISTRATIONDATE,A.MOBILENUMBER,A.ALTMOBILENUMBER,A.LANDLINENUMBER,A.EMAILID,A.EMPID,B.PACKAGENAME BILLPLAN, RENTALPAYMODE,A.STATUS STATUS,A.ADDRESSPROOFTYPE,A.IDPROOFTYPE,A.MODBY from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID and USERID='" + Utilities.ValidSql(pStrUserID) + "'";
           
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        #endregion

        #region Listing Of All Registered Subscribers
        public static DataSet GetMonthWiseRegistation(string pStrBillCycleID)
        {
            DataSet dst = new DataSet();

            string strQueryString = "";
            strQueryString = "select c.name, count(*)Registrations from registeredusers a,billcycles b,systemusermaster c where a.registrationdate >= b.cyclestartdate and ";
            strQueryString += "a.registrationdate <= b.cycleenddate and b.billcycleid='" + pStrBillCycleID + "' and a.Empid=c.empid group by c.name ";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        #endregion

        #region Listing Of All Registered Subscribers By MONTH
        public static DataSet GetSubscriberRegistrationByMonth()
        {
            DataSet dst = new DataSet();

            string strQueryString = "select  b.billcyclename Month,b.billcycleid billcycleid, count(*) Registrations from registeredusers a, billcycles b where a.registrationdate >=b.cyclestartdate and a.registrationdate<=b.cycleenddate group by b.billcycleid, b.billcyclename order by b.billcycleid desc";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        #endregion


        
        #region Listing Functionality

        public static DataSet GetRegisteredSubscriberList(String pStrStatus,bool AgentRegistered,String pStrRegistrarCode, String pStrStartDate, String pStrEndDate)
        {
            DataSet dst = new DataSet();

            string strQueryString = "select USERID,NAME,INSADR,CORADR,REGISTRATIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, A.BILLPLANID,B.PACKAGENAME BILLPLAN, RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,A.STATUS STATUS,REMARKS,A.MODBY,A.MODON from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID";

            if (pStrStatus == "P")
            { 
                strQueryString +=" and A.STATUS='P' ";
            }
            else if (pStrStatus == "A")
            {
                strQueryString += " AND A.STATUS='A' ";
            }
            else if (pStrStatus == "N")
            {
                strQueryString += " AND A.STATUS in ('A','P') ";
            } 
        
            if(AgentRegistered)
            {
                strQueryString +=" and A.AGENTCODE='"+ Utilities.ValidSql(pStrRegistrarCode) +"'";
            }
            else
            {
                strQueryString +=" and A.EMPID='"+ Utilities.ValidSql(pStrRegistrarCode) +"'";
            }
                        

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        
        #endregion

        #region Listing Functionality by Date Range

        public static DataSet GetRegisteredSubscriberListByDateRange(String pStrModBy,String pStrStartDate,String pStrEndDate,String pStrStatus)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select A.NAME,A.MOBILENUMBER,A.EMAILID,B.PACKAGENAME BILLPLAN from REGISTEREDUSERS A, BILLPLANS B where A.BILLPLANID=B.BILLPLANID and A.REGISTRATIONDATE between '" + Utilities.ValidSql(pStrStartDate) + "'and'" + Utilities.ValidSql(pStrEndDate) + "'and A.EMPID='" + Utilities.ValidSql(pStrModBy) + "'";
            

            if (pStrStatus == "ALL")
            {
                strQueryString += " AND A.STATUS in ('A','P','D','C') ";
            }
            else
            {
                strQueryString += " AND A.STATUS= '" + pStrStatus + "'";
            }

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }
        #endregion

        #region Listing Funtionality by Date Range for Sales Head

        public static DataSet GetRegisteredSubscriberListByDateRangeForSalesHead(String pStrStartDate, String pStrEndDate, String pStrStatus,String pStrSPersonType, String pStrSPersonID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select A.USERID,A.NAME,A.MOBILENUMBER,A.EMAILID, B.PACKAGENAME BILLPLAN from REGISTEREDUSERS A, BILLPLANS B where A.BILLPLANID=B.BILLPLANID and A.REGISTRATIONDATE between '" + Utilities.ValidSql(pStrStartDate) + "'and'" + Utilities.ValidSql(pStrEndDate) + "'";

           if (pStrStatus == "ALL")
            {
                strQueryString += " AND A.STATUS in ('A','P','D','C') ";
            }
            else 
            {
                strQueryString += "AND A.STATUS= '" + pStrStatus +"'";
            }

            if (pStrSPersonType == "E") //if it is executive
            {
                    strQueryString += "and A.ISAGENTACCOUNT ='F'";
                   //only particular executive is selected
                    if (pStrSPersonID != "A") 
                {
                    strQueryString += " and A.EMPID ='" + Utilities.ValidSql(pStrSPersonID) + "'";
                }
            }
            else if (pStrSPersonType == "A") //if it is agent
            {
                    strQueryString += "and A.ISAGENTACCOUNT ='T'";
             
                 //only particular agent is selected
                if (pStrSPersonID != "A") //if all agents are selected
                {
                    strQueryString += " and A.AGENTCODE ='" + Utilities.ValidSql(pStrSPersonID) + "'";
                }
            }
            //if it is both, then automatically it takes the necessary data
          

          

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return (dst);
        }

        #endregion

        #region Listing Funtionality to fetch all pending registered users
        /// <summary>
        /// this will bring only pending registrations for edit purpose. sales users is given the right to edit the user details as long as he is not connected (internet connection not provided) once he is connected. the user will not be editable by the sales head
        /// will fetch status with P and I
        /// </summary>
        /// <param name="pStrStartDate"></param>
        /// <param name="pStrEndDate"></param>
        /// <param name="pStrStatus"></param>
        /// <param name="pStrSPersonType"></param>
        /// <param name="pStrSPersonID"></param>
        /// <returns></returns>
        public static DataSet GetPendingRegisteredUsers()
        {
            DataSet dst = new DataSet();
         
            string strQueryString = "exec GetPendingRegisteredUsersPaper";
              
             try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
               
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                 
                dad.Fill(dst);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return (dst);          
        }

        public static DataSet GetRejectedRegisteredUsers()
        {
            DataSet dst = new DataSet();

            string strQueryString = "exec GetRejectedRegisteredUsersPaper";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());

                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return (dst);
        }


        public static DataSet GetPendingRegisteredUsersNew()
        {
            DataSet dst = new DataSet();
            string strQueryString = "exec GetPendingRegisteredUsersPaperless";

         
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());

                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return (dst);

        }


        public static DataSet GetRejectedRegisteredUsersNew()
        {
            DataSet dst = new DataSet();
            string strQueryString = "exec GetRejectedRegisteredUsersPaperless";


            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());

                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return (dst);

        }


        #endregion

        #region Listing Functionality pending Connections

        public static DataSet GetPendingConnections()
        {
            DataSet dst = new DataSet();

            string strQueryString = "select USERID,NAME,INSADR,CORADR,REGISTRATIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID,ADDRESSPROOFTYPE,IDPROOFTYPE,PHOTOFILENAME,IDPROOFNAME,ADDPROOFNAME, A.BILLPLANID,B.PACKAGENAME BILLPLAN, RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,A.STATUS STATUS,REMARKS,A.MODBY,A.MODON from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID AND A.STATUS='P' order by A.modon desc";


            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }

        #endregion

        #region Listing Functionality of Pending Customer Names and Registartion ID for Editing

        public static DataSet GetPendingConnectionsForEdit(String pStrModBy)
        {
            DataSet dst = new DataSet();

            string strQueryString = "select USERID,NAME from REGISTEREDUSERS where STATUS='P' and EMPID='"+Utilities.ValidSql(pStrModBy)+"' order by REGISTRATIONDATE desc";

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }

        #endregion

        #region Listing Functionality of Pending Customers for sales head n agents

        public static DataSet GetPendingConnectionsSalesHead(String pStrModBy)
        {
            DataSet dst = new DataSet();

         //   string strQueryString = "select USERID,NAME from REGISTEREDUSERS where STATUS='P' and MODBY='" + Utilities.ValidSql(pStrModBy) + "' order by REGISTRATIONDATE desc";
            //removing mody by so that registered users can be editied
            string strQueryString = "select USERID,NAME from REGISTEREDUSERS where STATUS='P'  order by REGISTRATIONDATE desc";
            

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (dst);
        }

        #endregion

        #region Listing Functionality of COnnected Users for Raising Bill
        
        public static DataSet GetConnectedUsersForBilling()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select A.USERID,A.NAME,A.MOBILENUMBER,A.EMAILID,A.BILLPLANID,B.PACKAGENAME BILLPLAN,A.STATUS STATUS from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID and A.STATUS='C' and A.ISBILLRAISED='F'";
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

        #region Update Bill Raised Status For Connected Client
        public void UpdateBillRaisedStatus(String pstrUserID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set ISBILLRAISED=@ISBILLRAISED where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@ISBILLRAISED", "T");
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

        #region Update Customer Profile Based on Registration ID
        public void UpdateCustProfileDetails(String pstrUserID,String pStrName,String pStrInsAdr,String pStrCorAdr, String pStrLandlineNo, String pStrAternateNo, String pStrMobileNo, String pStrEmailID, string pCAFNumber,string pInstallationConnectionType, string pUserGSTIN)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set NAME=@NAME,CORADR=@CORADR,INSADR=@INSADR,LANDLINENUMBER=@LANDLINENUMBER,ALTMOBILENUMBER=@ALTMOBILENUMBER, MOBILENUMBER=@MOBILENUMBER, EMAILID=@EMAILID, CAFNUMBER=@CAFNUMBER ,INSTALLATIONCONNECTIONTYPE=@INSTALLATIONCONNECTIONTYPE, USERGSTIN=@USERGSTIN where USERID=@USERID";
           
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@NAME",Utilities.ValidSql(pStrName));
            cmd.Parameters.AddWithValue("CORADR", Utilities.ValidSql(pStrCorAdr));
            cmd.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(pStrInsAdr));
            cmd.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNo));
            cmd.Parameters.AddWithValue("@ALTMOBILENUMBER", Utilities.ValidSql(pStrAternateNo));
            cmd.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNo));
            cmd.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(pStrEmailID));
            cmd.Parameters.AddWithValue("@CAFNUMBER", pCAFNumber);
            cmd.Parameters.AddWithValue("@INSTALLATIONCONNECTIONTYPE", Utilities.ValidSql(pInstallationConnectionType));
            cmd.Parameters.AddWithValue("@USERGSTIN", pUserGSTIN);


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

        #region Update Customer document details along with CAF           
        
        public void UpdateDocumentsOfRegiseteredUser(string pUserid, string pCAFnumber, String pCAFDocumentName, String pPhotoName, String pIDProofFileName, String pAddressProofFileName, string pCAFAnnexureName, string pSignFileName, string pIDProofFileNameBack, string pAddressProofFileNameBack)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE REGISTEREDUSERS set  CAFDocumentName=@CAFDocumentName,PHOTOFILENAME=@PHOTOFILENAME," +
                "IDPROOFNAME=@IDPROOFNAME,ADDPROOFNAME=@ADDPROOFNAME, status='P', CAFNumber=@CAFNUMBER, CAFANNEXURENAME=@CAFANNEXURENAME, " +
                "SignatureFileName=@SignFileName,IDPROOFNAME_back=@IDPROOFNAME_BACK,ADDPROOFNAME_BACK=@ADDPROOFNAME_BACK where USERID=@USERID";
            cmd.Parameters.AddWithValue("@CAFDocumentName", Utilities.ValidSql(pCAFDocumentName));
            cmd.Parameters.AddWithValue("@PHOTOFILENAME", Utilities.ValidSql(pPhotoName));
            cmd.Parameters.AddWithValue("@IDPROOFNAME", Utilities.ValidSql(pIDProofFileName));
            cmd.Parameters.AddWithValue("@ADDPROOFNAME", Utilities.ValidSql(pAddressProofFileName));
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pUserid));
            cmd.Parameters.AddWithValue("@CAFNumber", pCAFnumber);
            cmd.Parameters.AddWithValue("@CAFANNEXURENAME", Utilities.ValidSql(pCAFAnnexureName));
            cmd.Parameters.AddWithValue("@SignFileName", Utilities.ValidSql(pSignFileName));
            cmd.Parameters.AddWithValue("@IDPROOFNAME_BACK", Utilities.ValidSql(pIDProofFileNameBack));
            cmd.Parameters.AddWithValue("@ADDPROOFNAME_BACK", Utilities.ValidSql(pAddressProofFileNameBack));
            

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

        #region delete selective record

        public void DeleteRegiseteredUser(string pUserid)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM REGISTEREDUSERS where USERID=@USERID";            
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pUserid));
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

        public void BackForVarification(string pUserid)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update REGISTEREDUSERS set status='P',ReasonForRejection=NULL  where USERID=@USERID";            
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pUserid));
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





        #region update selective documents of registered user
        /// <summary>
        /// update selective uploaded docuements of registered user to db
        /// hopeto - 12 feb 2016
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="fileType"></param>
        /// <param name="updatedFileName"></param>
        /// <param name="FileType"></param>
        public void UpdateSelectiveDocumentsOfRegiseteredUser(string userid, FILETYPE fileType, String updatedFileName, string FileTypeorCAFNo)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
 

            switch (fileType)
            {
                case FILETYPE.USERPHOTO:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set PHOTOFILENAME=@PHOTOFILENAME  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@PHOTOFILENAME", updatedFileName);
                    break;
                case FILETYPE.IDPROOF:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set IDPROOFNAME=@IDPROOFNAME, IDPROOFTYPE=@IDPROOFTYPE where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@IDPROOFTYPE", FileTypeorCAFNo);
                    cmd.Parameters.AddWithValue("@IDPROOFNAME", updatedFileName);
                    break;
                case FILETYPE.IDPROOFBACK:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set IDPROOFNAME_BACK=@IDPROOFNAMEBACK, IDPROOFTYPE=@IDPROOFTYPE where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@IDPROOFTYPE", FileTypeorCAFNo);
                    cmd.Parameters.AddWithValue("@IDPROOFNAMEBACK", updatedFileName);
                    break;

                case FILETYPE.ADDRESSPROOF:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set ADDPROOFNAME=@ADDPROOFNAME, ADDRESSPROOFTYPE=@ADDRESSPROOFTYPE  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@ADDPROOFNAME", updatedFileName);
                    cmd.Parameters.AddWithValue("@ADDRESSPROOFTYPE", FileTypeorCAFNo);                    
                    break;

                case FILETYPE.ADDRESSPROOFBACK:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set ADDPROOFNAME_BACK=@ADDPROOFNAMEBACK, ADDRESSPROOFTYPE=@ADDRESSPROOFTYPE  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@ADDPROOFNAMEBACK", updatedFileName);
                    cmd.Parameters.AddWithValue("@ADDRESSPROOFTYPE", FileTypeorCAFNo);
                    break;

                case FILETYPE.CAFDOCUMENT:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set CAFDOCUMENTNAME=@CAFDOCUMENTNAME, CAFNUMBER=@CAFNUMBER  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@CAFDOCUMENTNAME", updatedFileName);
                    cmd.Parameters.AddWithValue("@CAFNUMBER", FileTypeorCAFNo);
                   
                    break;
                case FILETYPE.CAFANNEXURE:
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set CAFANNEXURENAME=@CAFANNEXURENAME  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@CAFANNEXURENAME", updatedFileName);
                    break;               

                case FILETYPE.CAFSIGNATURE :
                    cmd.CommandText = "UPDATE REGISTEREDUSERS set SignatureFileName=@CAFSIGNATURENAME  where userid=@USERID and status in ('I', 'P')";
                    cmd.Parameters.AddWithValue("@CAFSIGNATURENAME", updatedFileName);
                    break;
                default:
                  //nothing to update
                    return;                    
            }
           
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(userid));

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

        

        #region Update Bill Plan Based on Registration ID
        public void UpdateBillPlanDetails(String pstrUserID, String pStrBillPlanID, String pStrRentalPayMode,String pStrORTCID, int pLAPID,String pInstallationConnectionType,String pUserGSTIN)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set OTRCID=@OTRCID,BILLPLANID=@BILLPLANID,RENTALPAYMODE=@RENTALPAYMODE, LAPID=@LAPID,INSTALLATIONCONNECTIONTYPE=@INSTALLATIONCONNECTIONTYPE,USERGSTIN=@UserGSTIN  where USERID=@USERID";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@BILLPLANID", Utilities.ValidSql(pStrBillPlanID));
            cmd.Parameters.AddWithValue("@RENTALPAYMODE", Utilities.ValidSql(pStrRentalPayMode));
            cmd.Parameters.AddWithValue("@OTRCID", Utilities.ValidSql(pStrORTCID));
            cmd.Parameters.AddWithValue("@LAPID", pLAPID);
            cmd.Parameters.AddWithValue("@INSTALLATIONCONNECTIONTYPE", pInstallationConnectionType);
            cmd.Parameters.AddWithValue("@USERGSTIN", pUserGSTIN);
            
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

        #region Create New User Code Functionality

        private String GetNewUserID()
        {

            String strNewUserCode = "REGS";
            SqlConnection conn;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw ;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select cast((max(substring(USERID,5,4)))+1 as varchar) code from REGISTEREDUSERS";

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

        #region Register Client Functionality
        /// <summary>
        /// set to status I for first time as Incomplete to allow uploading of documents
        /// </summary>
        /// <param name="pStrCustomerName"></param>
        /// <param name="pStrInstallationAddress"></param>
        /// <param name="pStrCorrespondenceAddress"></param>
        /// <param name="pStrRegistrationDate"></param>
        /// <param name="pStrMobileNumber"></param>
        /// <param name="pStrAltMobileNumber"></param>
        /// <param name="pStrLandlineNumber"></param>
        /// <param name="pStrEmail"></param>
        /// <param name="pStrbillplanid"></param>
        /// <param name="pStrRentalPaymentmode"></param>
        /// <param name="pStrOTRCPaymentmode"></param>
        /// <param name="pInt32Priority"></param>
        /// <param name="pStrRegisteredByEmpID"></param>
        /// <param name="pStrAgentCode"></param>
        /// <param name="pStrIsAgentAccount"></param>
        /// <param name="pStrRemarks"></param>
        /// <param name="pStrModby"></param>
        /// <param name="pStrAddrsProof"></param>
        /// <param name="pStrIDProof"></param>
        /// 

        public void RegisterSubscriber(String pStrCustomerName, String pStrInstallationAddress, String pStrCorrespondenceAddress, String pStrRegistrationDate, String pStrMobileNumber, String pStrAltMobileNumber, String pStrLandlineNumber, String pStrEmail, String pStrbillplanid, String pStrRentalPaymentmode, String pStrOTRCPaymentmode, Int32 pInt32Priority, String pStrRegisteredByEmpID, String pStrAgentCode, String pStrIsAgentAccount, String pStrRemarks, String pStrModby, String pStrAddrsProofType, String pStrIDProofType, string pCAFNumber, Int32 pLAPID, String pInstallationConnectionType, String pUserGSTIN)
        {
            SqlConnection conn = null;
            string strNewRegisteredUserCode = "";
            try
            {
                strNewRegisteredUserCode += this.GetNewUserID();
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            bool CAFExists = true;
            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText ="select 'true' where EXISTS(SELECT Cafnumber from REGISTEREDUSERS where CAFNUMBER=@CAFNUMBER)";
            cmdcheck.Parameters.AddWithValue("@CAFNUMBER", pCAFNumber);
                SqlCommand cmduser = conn.CreateCommand();
                //insert into registered subscriber table
                cmduser.CommandText = "insert REGISTEREDUSERS (USERID,NAME,INSADR,CORADR,REGISTRATIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON,ADDRESSPROOFTYPE, IDPROOFTYPE, CAFNUMBER, LAPID, INSTALLATIONCONNECTIONTYPE,USERGSTIN) values (@USERID,@NAME,@INSADR,@CORADR,@REGISTRATIONDATE,@MOBILENUMBER,@ALTMOBILENUMBER,@LANDLINENUMBER,@EMAILID,@BILLPLANID,@RENTALPAYMODE,@OTRCID,@PRIORITY,@EMPID,@AGENTCODE,@ISAGENTACCOUNT,@STATUS,@REMARKS,@MODBY,@MODON, @ADDRESSPROOFTYPE, @IDPROOFTYPE, @CAFNUMBER, @LAPID,@INSTALLATIONCONNECTIONTYPE,@USERGSTIN)";

                cmduser.Parameters.AddWithValue("@USERID", Utilities.ValidSql(strNewRegisteredUserCode));
                cmduser.Parameters.AddWithValue("@NAME", Utilities.ValidSql(pStrCustomerName));
                cmduser.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(pStrInstallationAddress));
                cmduser.Parameters.AddWithValue("@CORADR", Utilities.ValidSql(pStrCorrespondenceAddress));
                cmduser.Parameters.AddWithValue("@REGISTRATIONDATE", Utilities.ValidSql(pStrRegistrationDate));
                cmduser.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNumber));
                cmduser.Parameters.AddWithValue("@ALTMOBILENUMBER", Utilities.ValidSql(pStrAltMobileNumber));
                cmduser.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNumber));
                cmduser.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(pStrEmail));
                cmduser.Parameters.AddWithValue("@BILLPLANID", Utilities.ValidSql(pStrbillplanid));
                cmduser.Parameters.AddWithValue("@RENTALPAYMODE", Utilities.ValidSql(pStrRentalPaymentmode));
                cmduser.Parameters.AddWithValue("@OTRCID", Utilities.ValidSql(pStrOTRCPaymentmode));
                cmduser.Parameters.AddWithValue("@PRIORITY", pInt32Priority);
                cmduser.Parameters.AddWithValue("@EMPID", pStrRegisteredByEmpID);
                cmduser.Parameters.AddWithValue("@AGENTCODE", pStrAgentCode);
                cmduser.Parameters.AddWithValue("@ISAGENTACCOUNT", pStrIsAgentAccount);
                cmduser.Parameters.AddWithValue("@STATUS", "I");
                cmduser.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
                cmduser.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
                cmduser.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
                cmduser.Parameters.AddWithValue("@ADDRESSPROOFTYPE", Utilities.ValidSql(pStrAddrsProofType));             
                cmduser.Parameters.AddWithValue("@IDPROOFTYPE", Utilities.ValidSql(pStrIDProofType));           
                cmduser.Parameters.AddWithValue("@CAFNUMBER", pCAFNumber);
                cmduser.Parameters.AddWithValue("@LAPID", pLAPID);
                cmduser.Parameters.AddWithValue("@INSTALLATIONCONNECTIONTYPE", Utilities.ValidSql(pInstallationConnectionType));
                cmduser.Parameters.AddWithValue("@USERGSTIN", Utilities.ValidSql(pUserGSTIN));

                try
                {
                    conn.Open();
                    
            if (cmdcheck.ExecuteScalar() != DBNull.Value)
            {
                CAFExists= Convert.ToBoolean((cmdcheck.ExecuteScalar()));
            }
            if (CAFExists)
            {
                //return error message
                ReturnMessage = "ERROR! CAF Number already exists in the application.";
                               return;
            }
            else
            {

                    
                    cmduser.ExecuteNonQuery();
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
            }

        

        #endregion

        #region Connect Client Funtionality Update REGISTEREDUSERS TABLE by Network Manager
        //adding pop and connection type to user 
        public void ConnectClientUser(String pstrRegisteredUserID, String pStrCustName, String pStrConnDate, String pStrUserName, String pStrPassword,String pStrModby, String pStrPOPID, String pStrConnectionType, String pStrConnectionDetails, String pStrLatitudeInstallation, String pStrLongitudeInstallation)
        {
            SqlConnection conn;
            SqlTransaction tr = null;

            conn = new SqlConnection(DBConn.GetConString());
            string encryptedpass = Encryption.encrypt(pStrPassword, 20);

            SqlCommand cmd = conn.CreateCommand();        
            cmd.CommandText = "UPDATE REGISTEREDUSERS set USERNAME=@USERNAME,PASSWORD=@PASSWORD,CONNECTIONDATE=@CONNECTIONDATE,STATUS=@STATUS,ISBILLRAISED=@ISBILLRAISED,MODBY=@MODBY,MODON=@MODON where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrRegisteredUserID));
            cmd.Parameters.AddWithValue("@USERNAME", Utilities.ValidSql(pStrUserName));
            cmd.Parameters.AddWithValue("@PASSWORD", encryptedpass);
            cmd.Parameters.AddWithValue("@CONNECTIONDATE", Utilities.ValidSql(pStrConnDate));
            cmd.Parameters.AddWithValue("@STATUS", "C");
            cmd.Parameters.AddWithValue("@ISBILLRAISED", "F");
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmd.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));



            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers(pstrRegisteredUserID);
            //1
            SqlCommand cmduser = conn.CreateCommand();
            string userid = pStrUserName.ToUpper().Replace("SCLX", "-SCLX");

            cmduser.CommandText = "insert USERMASTER (userid,registrationid,username,password,branchid,name,insadr,coradr,registrationdate,connectiondate,mobilenumber, landlinenumber,emailid,status,NETWORKALLOCATIONSTATUS,PHOTOFILENAME,IdProofName,AddProofName,IdProofType,AddressProofType,modby,modon, CAFDOCUMENTNAME, CAFANNEXURENAME, LAPID, CAFNUMBER, POPID, CONNECTIONTYPE, CONNECTIONDETAILS,INSTALLATIONCONNECTIONTYPE, USERGSTIN) values (@userid,@registrationID,@username,@password,@branchid,@name,@insadr,@coradr,@registrationdate,@connectiondate,@mobilenumber, @landlinenumber,@emailid, @status,@NETWORKALLOCATIONSTATUS,@PHOTOFILENAME,@IdProofName,@AddProofName,@IdProofType,@AddressProofType,@modby,@modon, @CAFDOCUMENTNAME, @CAFANNEXURENAME, @LAPID, @CAFNUMBER,@POPID, @CONNECTIONTYPE, @CONNECTIONDETAILS, @INSTALLATIONCONNECTIONTYPE,@USERGSTIN )";
            cmduser.Parameters.AddWithValue("@userid", userid);
            cmduser.Parameters.AddWithValue("@registrationID", reguser.UserID);
            cmduser.Parameters.AddWithValue("@username", pStrUserName);
            cmduser.Parameters.AddWithValue("@branchid", DBConn.GetBranchCode());
            cmduser.Parameters.AddWithValue("@name", Utilities.ValidSql(reguser.Name));
            cmduser.Parameters.AddWithValue("@password", encryptedpass);
            cmduser.Parameters.AddWithValue("@insadr", Utilities.ValidSql(reguser.InstallationAddress));
            cmduser.Parameters.AddWithValue("@coradr", Utilities.ValidSql(reguser.CorrespondenceAddress));
            cmduser.Parameters.AddWithValue("@registrationdate", Utilities.ValidSql(reguser.RegistrationDate));
            cmduser.Parameters.AddWithValue("@connectiondate", Utilities.ValidSql(pStrConnDate));
            cmduser.Parameters.AddWithValue("@mobilenumber", Utilities.ValidSql(reguser.MobileNumber));
            cmduser.Parameters.AddWithValue("@landlinenumber", Utilities.ValidSql(reguser.LandlineNumber));
            cmduser.Parameters.AddWithValue("@emailid", Utilities.ValidSql(reguser.EmailID));
            cmduser.Parameters.AddWithValue("@status", "A");
            cmduser.Parameters.AddWithValue("@PHOTOFILENAME", Utilities.ValidSql(reguser.PhotoThumbName));
            cmduser.Parameters.AddWithValue("@IdProofName", Utilities.ValidSql(reguser.IDProofName));
            cmduser.Parameters.AddWithValue("@AddProofName", Utilities.ValidSql(reguser.AddressProofName));
            cmduser.Parameters.AddWithValue("@IdProofType", Utilities.ValidSql(reguser.IDProofType));
            cmduser.Parameters.AddWithValue("@AddressProofType", Utilities.ValidSql(reguser.AddressProofType));
            cmduser.Parameters.AddWithValue("@NETWORKALLOCATIONSTATUS", "N");
            cmduser.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmduser.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            cmduser.Parameters.AddWithValue("@CAFDOCUMENTNAME", reguser.CAFDocumentName);
            cmduser.Parameters.AddWithValue("@CAFANNEXURENAME", reguser.CAFAnnxureDoc);
            cmduser.Parameters.AddWithValue("@CAFNUMBER", reguser.CAFNumber);
            cmduser.Parameters.AddWithValue("@LAPID", reguser.LAPID);
            cmduser.Parameters.AddWithValue("@POPID", pStrPOPID);
              cmduser.Parameters.AddWithValue("@CONNECTIONTYPE", pStrConnectionType);
              cmduser.Parameters.AddWithValue("@INSTALLATIONCONNECTIONTYPE", Utilities.ValidSql(reguser.InstallationConnectionType));
              cmduser.Parameters.AddWithValue("@CONNECTIONDETAILS", Utilities.ValidSql(pStrConnectionDetails));
            cmduser.Parameters.AddWithValue("@USERGSTIN", reguser.UserGSTIN);


            SqlCommand cmduserdetaials = conn.CreateCommand();

              cmduserdetaials.CommandText = "insert USERDETAILS (userid,LatitudeInstallation,LongitudeInstallation,ModifiedOn,ModifiedBy) values (@userid,@LatitudeInstallation,@LongitudeInstallation,@ModifiedOn,@ModifiedBy)";
              cmduserdetaials.Parameters.AddWithValue("@userid", userid);
              cmduserdetaials.Parameters.AddWithValue("@LatitudeInstallation", pStrLatitudeInstallation);
              cmduserdetaials.Parameters.AddWithValue("@LongitudeInstallation", pStrLongitudeInstallation);
              cmduserdetaials.Parameters.AddWithValue("@ModifiedBy", Utilities.ValidSql(pStrModby));
              cmduserdetaials.Parameters.AddWithValue("@ModifiedOn", System.DateTime.Now);
          



            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmd.Transaction = tr;
                cmduser.Transaction = tr;

                cmduserdetaials.Transaction = tr;
                cmd.ExecuteNonQuery();
                cmduser.ExecuteNonQuery();
                cmduserdetaials.ExecuteNonQuery();
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

        #region DeActivate Registered Broadband USer Funtionality

        public static void RegisteredBroadBandUserDeActivate(String pStrUserID, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdUser = conn.CreateCommand();
            //UPDATE NEWS
            cmdUser.CommandText = "UPDATE REGISTEREDUSERS set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where USERID=@USERID";
            cmdUser.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmdUser.Parameters.AddWithValue("@STATUS", "D");
            cmdUser.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdUser.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdUser.ExecuteNonQuery();
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

        #region Activate Registered Braodband User Funtionality

        public static void RegisteredBroadbandUserActivate(String pStrUserID, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdUser = conn.CreateCommand();
            //UPDATE NEWS
            cmdUser.CommandText = "update REGISTEREDUSERS set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where USERID=@USERID";
            cmdUser.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmdUser.Parameters.AddWithValue("@STATUS", "A");
            cmdUser.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdUser.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdUser.ExecuteNonQuery();
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

        #region Delete Registered Broadband User Permanently

        public static void RegisteredBroadbandUserDeleteByUserID(string pStrUserID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmdUser = conn.CreateCommand();
            cmdUser.CommandText = "Delete from REGISTEREDUSERS Where USERID=@USERID";
            cmdUser.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            try
            {
                conn.Open();
                cmdUser.ExecuteNonQuery();
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

        #region Registered Users Count

        public int GetRegisteredUsersCount()
        {

            int iCount = 0;
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
            cmd.CommandText = "Select count(*) from REGISTEREDUSERS";

            try
            {
                conn.Open();
                iCount = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (iCount);
        }

        #endregion
        /// <summary>
        /// to check whether a cafnumber exists for other users other than the supplied userid
        /// </summary>
        /// <param name="pCAFNumber"></param>
        /// <param name="userid">userid whose caf will be checked for</param>
        /// <returns></returns>
        
        public bool CheckCAFNumberExists(string pCAFNumber, string userid)
        {
            SqlConnection conn = new SqlConnection(DBConn.GetConString());        
            bool CAFExists = true;
            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "select 'true' where EXISTS(SELECT Cafnumber from REGISTEREDUSERS where CAFNUMBER=@CAFNUMBER and userid <> @USERID )";
     

            cmdcheck.Parameters.AddWithValue("@USERID", userid);
            cmdcheck.Parameters.AddWithValue("@CAFNUMBER", pCAFNumber);
            try
            {
                conn.Open();

                if (cmdcheck.ExecuteScalar() != DBNull.Value)
                {
                    CAFExists = Convert.ToBoolean((cmdcheck.ExecuteScalar()));
                }
                if (CAFExists)
                {
                    return true;
                }
                else
                {
                    return false;
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
        }

        #region Registered Users Count by Date Range

        public int GetRegisteredUsersCountByDateRange(String pStrStartDate,String pStrEndDate)
        {

            int iCount = 0;
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
            cmd.CommandText = "Select count(*) from REGISTEREDUSERS where REGISTRATIONDATE between '" +pStrStartDate + "'and'" + pStrEndDate + "'";

            try
            {
                conn.Open();
                iCount = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (iCount);
        }

        #endregion

        public void updatePendingConnections(String pendinguserid,string newStatus,String Remarks)
        {
            string x = pendinguserid;
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
          
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update REGISTEREDUSERS set status=@NEWSTATUS, ReasonForRejection=@REMARKS where  userid = @USERID";


            cmd.Parameters.AddWithValue("@USERID", pendinguserid);
            cmd.Parameters.AddWithValue("@NEWSTATUS", newStatus);
            cmd.Parameters.AddWithValue("@REMARKS", Remarks);
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


    }
}
