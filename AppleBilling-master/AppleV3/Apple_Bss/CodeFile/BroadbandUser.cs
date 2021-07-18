using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace Apple_Bss.CodeFile
{
    public class BroadbandUser
    {
        #region Variables & Accessor Methods

        protected String _txtUserID;
        protected String _txtRegistrationID;
        protected String _txtBranchCode;
        protected String _txtUserName;
        protected String _txtBillPlanID;
        protected String _txtName;
        protected String _txtInsAdr;
        protected String _txtCorAdr;
        protected String _txtConnectionDate;
        protected String _txtRegistrationDate;
        protected String _txtEmailID;
        protected String _txtLandlineNumber;
        protected String _txtMobileNumber;       
        protected string _txtStatus;
        protected string _photoThumbName;
        protected string _PoPID;
        protected string _ConnectionType;
        protected string _ConnectionDetails;
        protected string _InstallationConnectionType;
        protected string _idProof;
        protected string _addrsProof;
        protected string _idProofType;
        protected string _addrsProofType;


         string _string1;
         string _string2;
         string _string3;
         string _string4;

         public string POPID
         {
             get { return _PoPID; }
             set { _PoPID = value; }
         }

         public string CONNECTIONTYPE
         {
             get { return _ConnectionType; }
             set { _ConnectionType = value; }
         }
         public string CONNECTIONDETAILS
         {
             get { return _ConnectionDetails; }
             set { _ConnectionDetails = value; }
         }
         public string INSTALLATIONCONNECTIONTYPE
         {
             get { return _InstallationConnectionType; }
             set { _InstallationConnectionType = value; }
         }
       public  string UserID
        {
            get { return _txtUserID; }
            set { _txtUserID = value; }
        }

        public string RegistrationID
        {
            get { return _txtRegistrationID; }
            set { _txtRegistrationID = value; }
        }
        public string BranchCode
        {
            get { return _txtBranchCode; }
            set { _txtBranchCode = value; }
        }

        public string UserName
        {
            get { return _txtUserName; }
            set { _txtUserName = value; }
        }

        public string BillPlanID
        {
            get { return _txtBillPlanID; }
            set { _txtBillPlanID = value; }
        }

        public string Name
        {
            get { return _txtName; }
            set { _txtName = value; }
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

        public string ConnectionDate
        {
            get { return _txtConnectionDate; }
            set { _txtConnectionDate = value; }
        }

        public string RegistrationDate
        {
            get { return _txtRegistrationDate; }
            set { _txtRegistrationDate = value; }
        }

        public string EmailID
        {
            get { return _txtEmailID; }
            set { _txtEmailID = value; }
        }

        public string LandlineNumer
        {
            get { return _txtLandlineNumber; }
            set { _txtLandlineNumber = value; }
        }

        public string MobileNumber
        {
            get { return _txtMobileNumber; }
            set { _txtMobileNumber = value; }
        }

        public string Status
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
        }

        public string PhotoThumbName
        {
            get { return _photoThumbName; }
            set { _photoThumbName = value; }
        }
        public string IDProof
        {
            get { return _idProof; }
            set { _idProof = value; }
        }

        public string AddressProof
        {
            get { return _addrsProof; }
            set { _addrsProof = value; }
        }
        public string IDProofType
        {
            get { return _idProofType; }
            set { _idProofType = value; }
        }

        public string AddressProofType
        {
            get { return _addrsProofType; }
            set { _addrsProofType = value; }
        }

        public string Strng1
        {
            get { return _string1; }
        }
        public string Strng2
        {
            get { return _string2; }
        }
        public string Strng3
        {
            get { return _string3; }
        }
        public string Strng4
        {
            get { return _string4; }
        }
        protected String _ReturnMessage;
        public string ReturnMessage
        {
            get { return _ReturnMessage; }
            set { _ReturnMessage = value; }
        }

        protected string _cafnumber;
        public string CAFNumber
        {
            get { return _cafnumber; }
            set { _cafnumber = value; }
        }

        protected string _cafDocumentName;
        public string CAFDocumentName
        {
            get { return _cafDocumentName; }
            set { _cafDocumentName = value; }
        }

        protected string _cafAnnexureName;
        public string CAFAnnexureName
        {
            get { return _cafAnnexureName; }
            set { _cafAnnexureName = value; }
        }

        protected string _popName;
        public string POPName
        {
            get { return _popName; }
            set { _popName = value; }
        }

        protected string _connectionType;
        public string ConnectionType
        {
            get { return _connectionType; }
            set { _connectionType = value; }
        }

        protected string _connectionDetails;
        public string ConnectionDetails
        {
            get { return _connectionDetails; }
            set { _connectionDetails = value; }
        }

        protected string _passwordCreated;
        public string PasswordCreated
        {
            get { return _passwordCreated; }
            set { _passwordCreated = value; }
        }

        protected string _forgotPassword;
        public string ForgotPassword
        {
            get { return _forgotPassword; }
            set { _forgotPassword = value; }
        }
        protected string _billplanname;
        public string BillPlanName
        {
            get { return _billplanname; }
            set { _billplanname = value; }
        }

        protected string _monthlyRental;
        public string MonthlyRental
        {
            get { return _monthlyRental; }
            set { _monthlyRental = value; }
        }

        protected string _totalOutstanding;
        public string TotalOutstanding
        {
            get { return _totalOutstanding; }
            set { _totalOutstanding = value; }
        }

        protected string _customerGSTIN;
        public string CustomerGSTIN
        {
            get { return _customerGSTIN; }
            set { _customerGSTIN = value; }
        }


        
        #endregion

        #region Class Constructors
        
        public BroadbandUser()
        {          

        }
        public DataTable CheckIfEmailExists(string pstrEmail, string pstrUserId)
        {
            DataTable dts = new DataTable();
            string str = "SELECT * from SYSTEMUSERMASTER where EMAILID= '" + Utilities.ValidSql(pstrEmail) + "'and EMPID='" + Utilities.ValidSql(pstrUserId) + "' and STATUS='A'";
            try
            {

                SqlConnection conn = null;
                conn = new SqlConnection(DBConn.GetConString());
                conn.Open();
                SqlDataAdapter dad = new SqlDataAdapter(str, conn);
                dad.Fill(dts);
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (dts);
        }

      

          public static DataSet GetForgotPasswordStatus(String pstrEmail, String pstrEmpId)
          {
            DataSet dst = new DataSet();
            string strQueryString = "select FORGOTPASSWORD from SYSTEMUSERMASTER where EMAILID= '" + Utilities.ValidSql(pstrEmail) + "'and EMPID='" + Utilities.ValidSql(pstrEmpId) +"'";
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
        
       
       

        public BroadbandUser(String pStrUserID)
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
            cmd.CommandText = "select a.userid USERID, a.RegistrationID REGISTRATIONID,a.branchid BRANCHID, a.username USERNAME, a.name NAME, a.insadr INSADR, a.coradr CORADR, a.connectiondate CONNECTIONDATE, a.registrationdate CONNECTIONDATE, b.billplanid BILLPLANID, b.paymentmode PAYMENTMODE, a.status STATUS, a.emailid EMAILID, a.landlinenumber LANDLINENUMBER, a.mobilenumber MOBILENUMBER, a.popid POPID, a.connectiontype CONNECTIONTYPE,a.connectiondetails CONNECTIONDETAILS, a.USERGSTIN  from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and a.userid='" + pStrUserID + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtRegistrationID=dr["REGISTRATIONID"].ToString();
                    _txtBranchCode = dr["BRANCHID"].ToString();
                    _txtUserName = dr["USERNAME"].ToString();
                    _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _txtInsAdr = dr["INSADR"].ToString();
                    _txtCorAdr = dr["CORADR"].ToString();
                    _txtConnectionDate = dr["CONNECTIONDATE"].ToString();
                    _txtRegistrationDate = dr["CONNECTIONDATE"].ToString();
                    _txtEmailID = dr["EMAILID"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _PoPID = dr["POPID"].ToString();
                    _ConnectionDetails = dr["CONNECTIONDETAILS"].ToString();
                    _connectionType = dr["CONNECTIONTYPE"].ToString();
                    _customerGSTIN = dr["USERGSTIN"].ToString();
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

        public static void UpdatePassword(string psEmailID, string psPassword, string pstrEMPID)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch(Exception ex)
            {
                throw ex;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update SYSTEMUSERMASTER set Password =@PASSWORD, FORGOTPASSWORD='False' where  EMAILID=@EMAILID and STATUS='A' and EMPID=@EMPID and (FORGOTPASSWORD='True')";
            cmd.Parameters.AddWithValue("@PASSWORD", Utilities.ValidSql(Encryption.encrypt(psPassword, 20)));
            cmd.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(psEmailID));
            cmd.Parameters.AddWithValue("@EMPID", pstrEMPID);
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


        //2017 july 6 get subcriber details for helpdesk user by userid
        public DataSet GetClientDetails(String pStrUserID, String pStrUserName)
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
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            if(pStrUserID !="")//userid is supplied
            {
           // cmd.CommandText = "select a.userid, a.username , a.name , a.insadr , a.coradr , a.connectiondate , a.status, a.emailid, a.landlinenumber, a.mobilenumber, pm.POPNAME, a.connectiontype, a.connectiondetails, a.passwordcreated, a.forgotpassword from USERMASTER a, USERBILLINGINFO b, POPMASTER pm where a.userid=b.userid and a.popid = pm.popid and a.userid='" + pStrUserID + "'";

                cmd.CommandText = "GetClientDetailsByUserid";
                cmd.Parameters.AddWithValue("@userid", pStrUserID);
            }
            else //assuming username is supplied if userid not suplloie
            {
                cmd.CommandText = "GetClientDetailsByUsername";
                cmd.Parameters.AddWithValue("@username", pStrUserName);
            }

            
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _txtUserID = dr["USERID"].ToString();
                    _txtUserName = dr["USERNAME"].ToString();
                   // _txtBillPlanID = dr["BILLPLANID"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _txtInsAdr = dr["INSADR"].ToString();
                    _txtCorAdr = dr["CORADR"].ToString();
                    _txtConnectionDate = dr["CONNECTIONDATE"].ToString();                 
                    _txtEmailID = dr["EMAILID"].ToString();
                    _txtLandlineNumber = dr["LANDLINENUMBER"].ToString();
                    _txtMobileNumber = dr["MOBILENUMBER"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _popName = dr["POPNAME"].ToString();
                    _connectionType = dr["CONNECTIONTYPE"].ToString();
                    _connectionDetails = dr["CONNECTIONDETAILS"].ToString();
                    _InstallationConnectionType = dr["INSTALLATIONCONNECTIONTYPE"].ToString();
                    _passwordCreated = dr["PASSWORDCREATED"].ToString();
                  _forgotPassword=  dr["FORGOTPASSWORD"].ToString();
                    _billplanname = dr["PACKAGENAME"].ToString();
                  _monthlyRental = dr["MRATE"].ToString();
               //   _totalOutstanding = dr["TOTALOUTSTANDING"].ToString();

                }
                dr.Close();

            

           
                adapter.Fill(ds);


                conn.Close();
            }
            catch
            {
                throw;
            }
            return ds;
        }
      
        #region Create New User Code Functionality

        private String GetNewUserID()
        {
            
            String strNewUserCode = DBConn.GetBranchCode()+"-SCLX";
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
            cmd.CommandText = "Select cast((max(substring(USERID,9,4)))+1 as varchar) code from USERMASTER";            
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

        #region Listing Functionality BASED ON STATUS( Selection from Two Tables)

        public static DataSet GetSubscriberList(BroadbandUserStatus status)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.insadr INSADR, a.coradr CORADR, a.connectiondate CONNECTIONDATE, a.registrationdate REGISTRATIONDATE, b.billplanid BILLPLANID, b.paymentmode PAYMENTMODE, a.status STATUS, a.emailid EMAILID, a.mobilenumber MOBILENUMBER, a.landlinenumber LANDLINENUMBER,c.packagename BILLPLAN from USERMASTER a, USERBILLINGINFO b, BILLPLANS c where a.userid=b.userid and b.BillplanID=c.BillPlanID";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString += " order by USERNAME";
                    break;
                case BroadbandUserStatus.ALLEXCEPTPERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status!='D' order by USERNAME";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " and a.status='" + "A" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " and a.status='" + "D" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " and a.status='" + "T" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status='" + "P" + "' order by USERNAME";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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

        #region Listing Functionality of username (with userid) BASED ON STATUS( Selection from Two Tables) -16/03/10 - hopeto

        public static DataSet GetSubscribers(BroadbandUserStatus status)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString += " order by USERNAME";
                    break;
                case BroadbandUserStatus.ALLEXCEPTPERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status!='D' order by USERNAME";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " and a.status='" + "A" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " and a.status='" + "D" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " and a.status='" + "T" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status='" + "P" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.FORCEDDISCONNECTION:
                    strQueryString += " and a.status='" + "N" + "' order by USERNAME";
                    break;
                case BroadbandUserStatus.ALLDISCONNECTED:
                    strQueryString += " and a.status <>'" + "A" + "' order by USERNAME";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }
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

        #region Listing Functionality of Unallocated Subscribers by Branch Code

        public DataSet GetUnallocatedSubscriberList(String pStrBranchCode)
        {
            DataSet dst = new DataSet();

            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.insadr INSADR, a.coradr CORADR, a.connectiondate CONNECTIONDATE, a.registrationdate CONNECTIONDATE, b.billplanid BILLPLANID, b.paymentmode PAYMENTMODE, a.status STATUS, a.emailid EMAILID, a.mobilenumber MOBILENUMBER, a.landlinenumber LANDLINENUMBER from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and a.branchid='" + Utilities.ValidSql(pStrBranchCode) + "' and NETWORKALLOCATIONSTATUS='N'";
                        
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


        public DataSet GetPoPWiseSubscriberList(String pStrCity,String pStrPoPCode)
        {
            DataSet dst = new DataSet();
            string strQueryString = "";

            

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

        #region Listing Funtionality of Unallocated Subscribers 
        public static DataSet ListUnAllocatedSubscibers()
        {
            DataSet dst = new DataSet();

            string strQueryString = "select USERID,USERNAME from USERMASTER where NETWORKALLOCATIONSTATUS='N'";
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

        #region Register Client Functionality
        //, String pSecuirtyAmount

        public String RaiseBill(String pStrRegistrationID, String pStrUserName, String pStrConnectionDate, double pFloatOTRCDiscount, double pFloatSecurityDiscount, double pFloatWaiver, double pFloatPersistentWaiver, double pFloatExtraOFCLength, double pFLoatExtraCAT5Length, double pSecurityDepositWaiver, bool pBoolSendSMS, String pStrSystemUserID)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;
            //generate userid using username for other tables, userid in usermaster is already there
            string strNewSubscriberCode = pStrUserName.ToUpper().Replace("SCLX", "-SCLX");
          
            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

         //   String userid = Utilities.ValidSql(strNewSubscriberCode);         
            //2
            SqlCommand cmduserbillinginfo = conn.CreateCommand();
            //3
            SqlCommand cmddiscountsandwaivers = conn.CreateCommand();
            //4
            SqlCommand cmdbilldetails = conn.CreateCommand();
            //5
            SqlCommand cmdledger = conn.CreateCommand();
            //6
            SqlCommand cmdwad = conn.CreateCommand();
            //7
            SqlCommand cmdreguser = conn.CreateCommand();
           
            //9
            SqlCommand cmduserStatusLog = conn.CreateCommand();

           
            //get details from registered users table
            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers(pStrRegistrationID);
            
            //3
            cmddiscountsandwaivers.CommandText = "insert DISCOUNTSANDWAIVERS (userid,otrcdiscount,securitydepositdiscount,waiver,persistentwaiver) values (@userid,@otrcdiscount,@securitydepositdiscount,@waiver,@persistentwaiver)";
            cmddiscountsandwaivers.Parameters.AddWithValue("@userid", strNewSubscriberCode);
            cmddiscountsandwaivers.Parameters.AddWithValue("@otrcdiscount", pFloatOTRCDiscount);
            cmddiscountsandwaivers.Parameters.AddWithValue("@securitydepositdiscount", pFloatSecurityDiscount);
            cmddiscountsandwaivers.Parameters.AddWithValue("@waiver", pFloatWaiver);
            cmddiscountsandwaivers.Parameters.AddWithValue("@persistentwaiver", pFloatPersistentWaiver);


            BroadbandBillPlans plan = new BroadbandBillPlans(Utilities.ValidSql(reguser.BillPlanID));

            RegOTRCPlans otrcplan = new RegOTRCPlans(reguser.OTRCPaymentMode);//otrcid
            //4
            cmdbilldetails.CommandText = "insert BILLDETAILS (USERID,USERNAME,CONNECTIONDATE,NAME,CORADR,MOBILENUMBER,EMAILID,PAYMENTMODE,BILLNUMBER,BILLDATE,BILLCYCLEID,BILLSTARTDATE,BILLENDDATE,BILLPLANID,PACKAGENAME,EXTRACHARGESPERMB,CYCLECHARGES, DAYSBILLED,OTRC,SECURITYDEPOSIT,EXTRAOFCLENGTH,EXTRAOFCCHARGES,EXTRACAT5LENGTH,EXTRACAT5CHARGES,DTA,ALLOWEDDTA, ACTUALDATATRANSFER,EXTRADATATRANSFER,EXTRADATATRANSFERCHARGES,PRORATEDCYCLECHARGES,ARREARS,OTRCDISCOUNT,SECURITYDEPOSITDISCOUNT,WAIVERS,PERSISTENTWAIVER,TOTALCHARGES,PAYMENTS,NETPAYABLE,CGST, SGST,TOTALOUTSTANDING,LASTDATEOFPAYMENT,FIRSTBILL, USERGSTIN) values (@USERID,@USERNAME,@CONNECTIONDATE,@NAME,@CORADR,@MOBILENUMBER,@EMAILID,@PAYMENTMODE,@BILLNUMBER,@BILLDATE,@BILLCYCLEID,@BILLSTARTDATE,@BILLENDDATE,@BILLPLANID,@PACKAGENAME,@EXTRACHARGESPERMB,@CYCLECHARGES, @DAYSBILLED,@OTRC,@SECURITYDEPOSIT,@EXTRAOFCLENGTH,@EXTRAOFCCHARGES,@EXTRACAT5LENGTH,@EXTRACAT5CHARGES,@DTA,@ALLOWEDDTA, @ACTUALDATATRANSFER,@EXTRADATATRANSFER,@EXTRADATATRANSFERCHARGES,@PRORATEDCYCLECHARGES,@ARREARS,@OTRCDISCOUNT,@SECURITYDEPOSITDISCOUNT,@WAIVERS,@PERSISTENTWAIVER,@TOTALCHARGES,@PAYMENTS,@NETPAYABLE,@CGST,@SGST, @TOTALOUTSTANDING,@LASTDATEOFPAYMENT,@FIRSTBILL, @USERGSTIN)";

            cmdbilldetails.Parameters.AddWithValue("@USERID", strNewSubscriberCode);
            cmdbilldetails.Parameters.AddWithValue("@USERNAME", Utilities.ValidSql(pStrUserName));
            cmdbilldetails.Parameters.AddWithValue("@CONNECTIONDATE", Utilities.ValidSql(pStrConnectionDate));
            cmdbilldetails.Parameters.AddWithValue("@NAME", Utilities.ValidSql(reguser.Name));
            cmdbilldetails.Parameters.AddWithValue("@CORADR", Utilities.ValidSql(reguser.CorrespondenceAddress));
            cmdbilldetails.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(reguser.MobileNumber));
            cmdbilldetails.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(reguser.EmailID));
            cmdbilldetails.Parameters.AddWithValue("@PAYMENTMODE", Utilities.ValidSql(reguser.RentalPaymentMode));
            cmdbilldetails.Parameters.AddWithValue("@OTRC", otrcplan.DownPayment);
            // cmdbilldetails.Parameters.AddWithValue("@SECURITYDEPOSIT", plan.SecurityDeposit);
            cmdbilldetails.Parameters.AddWithValue("@SECURITYDEPOSIT", otrcplan.SecurityDeposit);

            cmdbilldetails.Parameters.AddWithValue("@EXTRAOFCLENGTH", pFloatExtraOFCLength);
            cmdbilldetails.Parameters.AddWithValue("@EXTRAOFCCHARGES", (pFloatExtraOFCLength * (plan.ExtraOFCRate)));
            cmdbilldetails.Parameters.AddWithValue("@EXTRACAT5LENGTH", pFLoatExtraCAT5Length);
            cmdbilldetails.Parameters.AddWithValue("@EXTRACAT5CHARGES", (pFLoatExtraCAT5Length * (plan.ExtraCAT5Rate)));
            cmdbilldetails.Parameters.AddWithValue("@BILLPLANID", Utilities.ValidSql(reguser.BillPlanID));
            cmdbilldetails.Parameters.AddWithValue("@PACKAGENAME", Utilities.ValidSql(plan.PackageName));
            cmdbilldetails.Parameters.AddWithValue("@EXTRACHARGESPERMB", plan.ExtraChargesPerMB);
            cmdbilldetails.Parameters.AddWithValue("@ACTUALDATATRANSFER", 0);
            cmdbilldetails.Parameters.AddWithValue("@EXTRADATATRANSFER", 0);
            cmdbilldetails.Parameters.AddWithValue("@EXTRADATATRANSFERCHARGES", 0);
            cmdbilldetails.Parameters.AddWithValue("@ARREARS", 0);
            cmdbilldetails.Parameters.AddWithValue("@OTRCDISCOUNT", pFloatOTRCDiscount);
            cmdbilldetails.Parameters.AddWithValue("@SECURITYDEPOSITDISCOUNT", pFloatSecurityDiscount);
            cmdbilldetails.Parameters.AddWithValue("@WAIVERS", pFloatWaiver);
            cmdbilldetails.Parameters.AddWithValue("@PERSISTENTWAIVER", pFloatPersistentWaiver);
            cmdbilldetails.Parameters.AddWithValue("@PAYMENTS", 0);
            cmdbilldetails.Parameters.AddWithValue("@USERGSTIN", reguser.UserGSTIN);



            //get the actual securit deposit after waiver if any
            // double securityDepositActual = plan.SecurityDeposit - pSecurityDepositWaiver;
            double securityDepositActual = otrcplan.SecurityDeposit - pSecurityDepositWaiver;


            //2
            cmduserbillinginfo.CommandText = "insert USERBILLINGINFO (userid,billplanid,paymentmode,extraofclength,extracat5length,BILLFLAG,billstartdate,billenddate, securityamount) values (@userid,@billplanid,@paymentmode,@extraofclength,@extracat5length,@BILLFLAG,@Billstartdate,@Billenddate,@SECURITYAMOUNT )";
            cmduserbillinginfo.Parameters.AddWithValue("@userid", strNewSubscriberCode);
            cmduserbillinginfo.Parameters.AddWithValue("@billplanid", Utilities.ValidSql(reguser.BillPlanID));
            cmduserbillinginfo.Parameters.AddWithValue("@paymentmode", Utilities.ValidSql(reguser.RentalPaymentMode));
            cmduserbillinginfo.Parameters.AddWithValue("@extraofclength", pFloatExtraOFCLength);
            cmduserbillinginfo.Parameters.AddWithValue("@extracat5length", pFLoatExtraCAT5Length);
            cmduserbillinginfo.Parameters.AddWithValue("@BILLFLAG", "T");
            cmduserbillinginfo.Parameters.AddWithValue("@SECURITYAMOUNT", securityDepositActual);

            Int32 cycleid = -1;
            Int32 daysconnected = -1;
            string billstartdate = "";
            string billenddate = "";
            string billdate = pStrConnectionDate;
            double cyclecharges = -1;
            double datatransferredallowed = -1;
            double datatransferredallowedforthecycle = -1;
            double proratedcyclecharges = -1;
            double totalcharges = -1;
            double netpayable = -1;
            //double servicetax = -1;
            double totaloutstanding = -1;
            string billnumber = "";
            string lastdateofpayment = "";

            double cgst = -1;
            double sgst = -1;
            double registrationCharges = otrcplan.DownPayment;

            Int32 totalDaysinConnectedMonth = -1;

            if (reguser.RentalPaymentMode == "M")
            {
                //  DateTime endDate = Convert.ToDateTime(reguser.ConnectionDate);
                //  Int64 addedDays = Convert.ToInt64(30);
                //  endDate = endDate.AddDays(addedDays);
                //  DateTime end = endDate;               

                cycleid = BillCycles.GetMonthlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));
                billstartdate = BillCycles.GetCycleStartDateOfMonthlyCycle(cycleid);
                billenddate = BillCycles.GetCycleEndDateOfMonthlyCycle(cycleid);
                cmduserbillinginfo.Parameters.AddWithValue("@Billstartdate", reguser.ConnectionDate);
                cmduserbillinginfo.Parameters.AddWithValue("@Billenddate", billenddate);
                //  billstartdate = reguser.ConnectionDate
                //  billenddate = Convert.ToDateTime(end).ToString("MM-dd-yyyy");
                //    TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));

                TimeSpan dc = (Convert.ToDateTime(billenddate).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));        
                //get total days in connected month
                TimeSpan totalmonthdays = (Convert.ToDateTime(billenddate).Subtract(Convert.ToDateTime(billstartdate)));

                daysconnected = dc.Days + 1;

                totalDaysinConnectedMonth = totalmonthdays.Days + 1;
               cyclecharges = plan.MonthlyUsageCharges;
                datatransferredallowed = plan.MonthlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedMonthlyDataTransferAllowed(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth);

                proratedcyclecharges = plan.GetProratedMonthlyUsageCharges(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth);

                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");
                


            }
            else if (reguser.RentalPaymentMode == "Q")
            {

                cmduserbillinginfo.Parameters.AddWithValue("@Billstartdate", reguser.ConnectionDate);

                DateTime endDate = Convert.ToDateTime(reguser.ConnectionDate);
                Int64 addedDays = Convert.ToInt64(90);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;

                cmduserbillinginfo.Parameters.AddWithValue("@Billenddate", end);

                cycleid = BillCycles.GetQuarterlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                //billstartdate = BillCycles.GetCycleStartDateOfQuarterlyCycle(cycleid);
                //billenddate = BillCycles.GetCycleEndDateOfQuarterlyCycle(cycleid);
                billstartdate = reguser.ConnectionDate;

                //billenddate = end.ToLongDateString();
                billenddate = Convert.ToDateTime(end).ToString("MM-dd-yyyy");


                //TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                TimeSpan dc = (Convert.ToDateTime(end).Subtract(Convert.ToDateTime(reguser.ConnectionDate)));
                daysconnected = dc.Days + 1;

                cyclecharges = plan.QuarterlyUsageCharges;

                datatransferredallowed = plan.QuarterlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedQuarterlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                // proratedcyclecharges = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                proratedcyclecharges = 0;
                 lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");

            }
            else if (reguser.RentalPaymentMode == "H")
            {

                cmduserbillinginfo.Parameters.AddWithValue("@Billstartdate", reguser.ConnectionDate);

                DateTime endDate = Convert.ToDateTime(reguser.ConnectionDate);
                Int64 addedDays = Convert.ToInt64(180);
                endDate = endDate.AddDays(addedDays);
                DateTime end = endDate;

                cmduserbillinginfo.Parameters.AddWithValue("@Billenddate", end);

                cycleid = BillCycles.GetHalfYearlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                //billstartdate = BillCycles.GetCycleStartDateOfHalfYearlyCycle(cycleid);

                // billenddate = BillCycles.GetCycleEndDateOfHalfYearlyCycle(cycleid);
                billstartdate = reguser.ConnectionDate;

                //billenddate = end.ToLongDateString();
                billenddate = Convert.ToDateTime(end).ToString("MM-dd-yyyy");

                // TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfHalfYearlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));

                TimeSpan dc = (Convert.ToDateTime(end).Subtract(Convert.ToDateTime(reguser.ConnectionDate)));

                daysconnected = dc.Days + 1;

                cyclecharges = plan.HalfYearlyUsageCharges;

                datatransferredallowed = plan.HalfYearlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedHalfYearlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                // proratedcyclecharges = plan.GetProratedHalfYearlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                proratedcyclecharges = 0;
                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");


            }

            else if (reguser.RentalPaymentMode == "A")
            {

               

                DateTime endDate = Convert.ToDateTime(reguser.ConnectionDate);
                //  Int64 addedDays = Convert.ToInt64(365);

                Int32 addedMonths = 12;

                endDate = endDate.AddMonths(addedMonths);
                // DateTime end = endDate;

           

                cycleid = BillCycles.GetYearlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                //billstartdate = BillCycles.GetCycleStartDateOfYearlyCycle(cycleid);
                billstartdate = reguser.ConnectionDate;

                //billenddate = BillCycles.GetCycleEndDateOfYearlyCycle(cycleid);
                //billenddate = end.ToLongDateString();
                billenddate = endDate.ToString("MM-dd-yyyy");

                cmduserbillinginfo.Parameters.AddWithValue("@Billstartdate",billstartdate);
                cmduserbillinginfo.Parameters.AddWithValue("@Billenddate", billenddate);

                //TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfYearlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                // TimeSpan dc = (Convert.ToDateTime(end).Subtract(Convert.ToDateTime(end)));
                //  daysconnected = dc.Days + 1;

                daysconnected = 365;

                cyclecharges = plan.YearlyUsageCharges;

                datatransferredallowed = plan.YearlyDataTransferLimit;

                // datatransferredallowedforthecycle = plan.GetProratedYearlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                datatransferredallowedforthecycle = 0; //unlimited for all new plans

                 //proratedcyclecharges = plan.GetProratedYearlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                 proratedcyclecharges = plan.YearlyUsageCharges;

                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");

                

            }

           

            totalcharges = otrcplan.DownPayment + otrcplan.SecurityDeposit + proratedcyclecharges + (pFloatExtraOFCLength * (plan.ExtraOFCRate)) + (pFLoatExtraCAT5Length * (plan.ExtraCAT5Rate)); //now using otrc table for secuirty deposit and not the plan

            netpayable = totalcharges - pFloatOTRCDiscount - pFloatSecurityDiscount - pFloatWaiver - pFloatPersistentWaiver;

          //  servicetax = (Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ServiceTax"].ToString())) * (proratedcyclecharges - pFloatPersistentWaiver);
          //not using service tax anymore all bills raised will reflect cgst and sgst 
            //adding tax to registration charges
            //removing tax component to refundable Subscription charges
          cgst =  sgst = (Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["cgst"].ToString())) * (proratedcyclecharges + otrcplan.DownPayment - pFloatPersistentWaiver);

            totaloutstanding = netpayable + cgst + sgst;

            billnumber = Utilities.ValidSql(BroadbandSubscriberBills.GetNewBillNumber());

            cmdbilldetails.Parameters.AddWithValue("@BILLCYCLEID", cycleid);
            cmdbilldetails.Parameters.AddWithValue("@CYCLECHARGES", cyclecharges);
            cmdbilldetails.Parameters.AddWithValue("@DAYSBILLED", daysconnected);
            cmdbilldetails.Parameters.AddWithValue("@BILLNUMBER", billnumber);
            cmdbilldetails.Parameters.AddWithValue("@BILLDATE", billdate);
            cmdbilldetails.Parameters.AddWithValue("@BILLSTARTDATE", billstartdate);//1
            cmdbilldetails.Parameters.AddWithValue("@BILLENDDATE", billenddate);//2
            cmdbilldetails.Parameters.AddWithValue("@DTA", datatransferredallowed);
            cmdbilldetails.Parameters.AddWithValue("@ALLOWEDDTA", datatransferredallowedforthecycle);
            cmdbilldetails.Parameters.AddWithValue("@PRORATEDCYCLECHARGES", proratedcyclecharges);//3
            cmdbilldetails.Parameters.AddWithValue("@TOTALCHARGES", totalcharges);//4
            cmdbilldetails.Parameters.AddWithValue("@NETPAYABLE", netpayable);           //5
            cmdbilldetails.Parameters.AddWithValue("@CGST", cgst);
            cmdbilldetails.Parameters.AddWithValue("@SGST", sgst);
            cmdbilldetails.Parameters.AddWithValue("@TOTALOUTSTANDING", totaloutstanding);//6
            cmdbilldetails.Parameters.AddWithValue("@LASTDATEOFPAYMENT", Utilities.ValidSql(lastdateofpayment));
            cmdbilldetails.Parameters.AddWithValue("@FIRSTBILL", "T");


            //5
            cmdledger.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,exdtpayment,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@exdtpayment,@instrumentid,@modby,@modon)";
            cmdledger.Parameters.AddWithValue("@userid", strNewSubscriberCode);
            cmdledger.Parameters.AddWithValue("@specifications", "SymBios Broadband Services Bill:");
            cmdledger.Parameters.AddWithValue("@cr", totaloutstanding);//7
            cmdledger.Parameters.AddWithValue("@dr", 0);
            cmdledger.Parameters.AddWithValue("@EXDTPAYMENT", "F");
            cmdledger.Parameters.AddWithValue("@instrumentid", billnumber);
            cmdledger.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdledger.Parameters.AddWithValue("@modon", Utilities.ValidSql(billdate));


            String strQuery = String.Empty;

            if (reguser.RentalPaymentMode == "M")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month2 + ",'F'," + (cycleid + 1) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month3 + ",'F'," + (cycleid + 2) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month4 + ",'F'," + (cycleid + 3) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month5 + ",'F'," + (cycleid + 4) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month6 + ",'F'," + (cycleid + 5) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month7 + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month8 + ",'F'," + (cycleid + 7) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month9 + ",'F'," + (cycleid + 8) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month10 + ",'F'," + (cycleid + 9) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month11 + ",'F'," + (cycleid + 10) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + otrcplan.Month12 + ",'F'," + (cycleid + 11) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "Q")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4) + ",'F'," + (cycleid + 3) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7) + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10) + ",'F'," + (cycleid + 9) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "H")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4 + otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7) + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10 + otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "A")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + strNewSubscriberCode + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4 + otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7 + otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10 + otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            //6
            cmdwad.CommandText = strQuery;
            //7
            cmdreguser.CommandText = "update Registeredusers set connectiondate='" + Utilities.ValidSql(billdate) + "', ISBILLRAISED='T', status='A' where userid='" + Utilities.ValidSql(pStrRegistrationID) + "'";
        
            cmduserStatusLog.CommandType = CommandType.StoredProcedure;
            //9
            cmduserStatusLog.CommandText = "INSERTUSERSTATUSLOG";
            //INSERT INTO USERSTATUSLOG VALUES(@USERID,@DATE,@REMARKS,  @STATUS, @MODBY)
            cmduserStatusLog.Parameters.AddWithValue("@USERID", strNewSubscriberCode);
            cmduserStatusLog.Parameters.AddWithValue("@STATUS", "A");
            cmduserStatusLog.Parameters.AddWithValue("DATE", DateTime.Now);
            cmduserStatusLog.Parameters.AddWithValue("@REMARKS", "New Connection");
            cmduserStatusLog.Parameters.AddWithValue("@MODBY", pStrSystemUserID);


            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
              
                //2
                cmduserbillinginfo.Transaction = tr;
                //3
                cmddiscountsandwaivers.Transaction = tr;
                //4
                cmdbilldetails.Transaction = tr;
                //5
                cmdledger.Transaction = tr;
                //6
                cmdwad.Transaction = tr;
                //7
                cmdreguser.Transaction = tr;
               
                //9
                cmduserStatusLog.Transaction = tr;

              
                cmduserbillinginfo.ExecuteNonQuery();
                cmddiscountsandwaivers.ExecuteNonQuery();
                cmdbilldetails.ExecuteNonQuery();
                cmdledger.ExecuteNonQuery();
                cmdwad.ExecuteNonQuery();
                cmdreguser.ExecuteNonQuery();
                
                cmduserStatusLog.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                billnumber = "-1";
                tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (billnumber);
        }

        #endregion


        /*
        #region Register Client Functionality

        public String AddNewSubscriber(String pStrRegistrationID, String pStrUserName, String pStrConnectionDate, double pFloatOTRCDiscount, double pFloatSecurityDiscount, double pFloatWaiver, double pFloatPersistentWaiver, double pFloatExtraOFCLength, double pFLoatExtraCAT5Length, bool pBoolSendSMS, String pStrSystemUserID)
        {
            SqlTransaction tr = null;
            SqlConnection conn = null;
            string strNewSubscriberCode = "";

            try
            {
                strNewSubscriberCode += this.GetNewUserID();
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

            String userid = Utilities.ValidSql(strNewSubscriberCode);
            //1
            SqlCommand cmduser = conn.CreateCommand();
            //2
            SqlCommand cmduserbillinginfo = conn.CreateCommand();
            //3
            SqlCommand cmddiscountsandwaivers = conn.CreateCommand();
            //4
            SqlCommand cmdbilldetails = conn.CreateCommand();
            //5
            SqlCommand cmdledger = conn.CreateCommand();
            //6
            SqlCommand cmdwad = conn.CreateCommand();
            //7
            SqlCommand cmdreguser = conn.CreateCommand();
            //8
            SqlCommand cmdreguserUpdateBillFlag = conn.CreateCommand();
            //9
            SqlCommand cmduserStatusLog = conn.CreateCommand();

            //insert into subscriber table

            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers(pStrRegistrationID);
            //1
            cmduser.CommandText = "insert USERMASTER (userid,registrationid,username,password,branchid,name,insadr,coradr,registrationdate,connectiondate,mobilenumber, landlinenumber,emailid,status,NETWORKALLOCATIONSTATUS,PHOTOFILENAME,IdProofName,AddProofName,IdProofType,AddressProofType,modby,modon, CAFDOCUMENTNAME, CAFANNEXURENAME, LAPID, CAFNUMBER) values (@userid,@registrationID,@username,@password,@branchid,@name,@insadr,@coradr,@registrationdate,@connectiondate,@mobilenumber, @landlinenumber,@emailid, @status,@NETWORKALLOCATIONSTATUS,@PHOTOFILENAME,@IdProofName,@AddProofName,@IdProofType,@AddressProofType,@modby,@modon, @CAFDOCUMENTNAME, @CAFANNEXURENAME, @LAPID, @CAFNUMBER)";
            cmduser.Parameters.AddWithValue("@userid", userid);
            cmduser.Parameters.AddWithValue("@registrationID", Utilities.ValidSql(reguser.UserID));
            cmduser.Parameters.AddWithValue("@username", Utilities.ValidSql(pStrUserName));
            cmduser.Parameters.AddWithValue("@branchid", DBConn.GetBranchCode());
            cmduser.Parameters.AddWithValue("@name", Utilities.ValidSql(reguser.Name));
            cmduser.Parameters.AddWithValue("@password", Utilities.ValidSql(reguser.Password));
            cmduser.Parameters.AddWithValue("@insadr", Utilities.ValidSql(reguser.InstallationAddress));
            cmduser.Parameters.AddWithValue("@coradr", Utilities.ValidSql(reguser.CorrespondenceAddress));
            cmduser.Parameters.AddWithValue("@registrationdate", Utilities.ValidSql(reguser.RegistrationDate));
            cmduser.Parameters.AddWithValue("@connectiondate", Utilities.ValidSql(pStrConnectionDate));
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
            cmduser.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmduser.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            cmduser.Parameters.AddWithValue("@CAFDOCUMENTNAME", reguser.CAFDocumentName);
            cmduser.Parameters.AddWithValue("@CAFANNEXURENAME", reguser.CAFAnnxureDoc);
            cmduser.Parameters.AddWithValue("@CAFNUMBER", reguser.CAFNumber);
            cmduser.Parameters.AddWithValue("@LAPID", reguser.LAPID);



            //insert into subscribercredentials table
            //2
            cmduserbillinginfo.CommandText = "insert USERBILLINGINFO (userid,billplanid,paymentmode,extraofclength,extracat5length,BILLFLAG) values (@userid,@billplanid,@paymentmode,@extraofclength,@extracat5length,@BILLFLAG)";
            cmduserbillinginfo.Parameters.AddWithValue("@userid", Utilities.ValidSql(strNewSubscriberCode));
            cmduserbillinginfo.Parameters.AddWithValue("@billplanid", Utilities.ValidSql(reguser.BillPlanID));
            cmduserbillinginfo.Parameters.AddWithValue("@paymentmode", Utilities.ValidSql(reguser.RentalPaymentMode));
            cmduserbillinginfo.Parameters.AddWithValue("@extraofclength", pFloatExtraOFCLength);
            cmduserbillinginfo.Parameters.AddWithValue("@extracat5length", pFLoatExtraCAT5Length);
            cmduserbillinginfo.Parameters.AddWithValue("@BILLFLAG", "T");

            //3
            cmddiscountsandwaivers.CommandText = "insert DISCOUNTSANDWAIVERS (userid,otrcdiscount,securitydepositdiscount,waiver,persistentwaiver) values (@userid,@otrcdiscount,@securitydepositdiscount,@waiver,@persistentwaiver)";
            cmddiscountsandwaivers.Parameters.AddWithValue("@userid", Utilities.ValidSql(strNewSubscriberCode));
            cmddiscountsandwaivers.Parameters.AddWithValue("@otrcdiscount", pFloatOTRCDiscount);
            cmddiscountsandwaivers.Parameters.AddWithValue("@securitydepositdiscount", pFloatSecurityDiscount);
            cmddiscountsandwaivers.Parameters.AddWithValue("@waiver", pFloatWaiver);
            cmddiscountsandwaivers.Parameters.AddWithValue("@persistentwaiver", pFloatPersistentWaiver);


            BroadbandBillPlans plan = new BroadbandBillPlans(Utilities.ValidSql(reguser.BillPlanID));

            RegOTRCPlans otrcplan = new RegOTRCPlans(reguser.OTRCPaymentMode);
            //4
            cmdbilldetails.CommandText = "insert BILLDETAILS (USERID,USERNAME,CONNECTIONDATE,NAME,CORADR,MOBILENUMBER,EMAILID,PAYMENTMODE,BILLNUMBER,BILLDATE,BILLCYCLEID,BILLSTARTDATE,BILLENDDATE,BILLPLANID,PACKAGENAME,EXTRACHARGESPERMB,CYCLECHARGES, DAYSBILLED,OTRC,SECURITYDEPOSIT,EXTRAOFCLENGTH,EXTRAOFCCHARGES,EXTRACAT5LENGTH,EXTRACAT5CHARGES,DTA,ALLOWEDDTA, ACTUALDATATRANSFER,EXTRADATATRANSFER,EXTRADATATRANSFERCHARGES,PRORATEDCYCLECHARGES,ARREARS,OTRCDISCOUNT,SECURITYDEPOSITDISCOUNT,WAIVERS,PERSISTENTWAIVER,TOTALCHARGES,PAYMENTS,NETPAYABLE,SERVICETAX,TOTALOUTSTANDING,LASTDATEOFPAYMENT,FIRSTBILL) values (@USERID,@USERNAME,@CONNECTIONDATE,@NAME,@CORADR,@MOBILENUMBER,@EMAILID,@PAYMENTMODE,@BILLNUMBER,@BILLDATE,@BILLCYCLEID,@BILLSTARTDATE,@BILLENDDATE,@BILLPLANID,@PACKAGENAME,@EXTRACHARGESPERMB,@CYCLECHARGES, @DAYSBILLED,@OTRC,@SECURITYDEPOSIT,@EXTRAOFCLENGTH,@EXTRAOFCCHARGES,@EXTRACAT5LENGTH,@EXTRACAT5CHARGES,@DTA,@ALLOWEDDTA, @ACTUALDATATRANSFER,@EXTRADATATRANSFER,@EXTRADATATRANSFERCHARGES,@PRORATEDCYCLECHARGES,@ARREARS,@OTRCDISCOUNT,@SECURITYDEPOSITDISCOUNT,@WAIVERS,@PERSISTENTWAIVER,@TOTALCHARGES,@PAYMENTS,@NETPAYABLE,@SERVICETAX,@TOTALOUTSTANDING,@LASTDATEOFPAYMENT,@FIRSTBILL)";

            cmdbilldetails.Parameters.AddWithValue("@USERID", Utilities.ValidSql(strNewSubscriberCode));
            cmdbilldetails.Parameters.AddWithValue("@USERNAME", Utilities.ValidSql(pStrUserName));
            cmdbilldetails.Parameters.AddWithValue("@CONNECTIONDATE", Utilities.ValidSql(pStrConnectionDate));
            cmdbilldetails.Parameters.AddWithValue("@NAME", Utilities.ValidSql(reguser.Name));
            cmdbilldetails.Parameters.AddWithValue("@CORADR", Utilities.ValidSql(reguser.CorrespondenceAddress));
            cmdbilldetails.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(reguser.MobileNumber));
            cmdbilldetails.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(reguser.EmailID));
            cmdbilldetails.Parameters.AddWithValue("@PAYMENTMODE", Utilities.ValidSql(reguser.RentalPaymentMode));
            cmdbilldetails.Parameters.AddWithValue("@OTRC", otrcplan.DownPayment);
            cmdbilldetails.Parameters.AddWithValue("@SECURITYDEPOSIT", plan.SecurityDeposit);
            cmdbilldetails.Parameters.AddWithValue("@EXTRAOFCLENGTH", pFloatExtraOFCLength);
            cmdbilldetails.Parameters.AddWithValue("@EXTRAOFCCHARGES", (pFloatExtraOFCLength * (plan.ExtraOFCRate)));
            cmdbilldetails.Parameters.AddWithValue("@EXTRACAT5LENGTH", pFLoatExtraCAT5Length);
            cmdbilldetails.Parameters.AddWithValue("@EXTRACAT5CHARGES", (pFLoatExtraCAT5Length * (plan.ExtraCAT5Rate)));
            cmdbilldetails.Parameters.AddWithValue("@BILLPLANID", Utilities.ValidSql(reguser.BillPlanID));
            cmdbilldetails.Parameters.AddWithValue("@PACKAGENAME", Utilities.ValidSql(plan.PackageName));
            cmdbilldetails.Parameters.AddWithValue("@EXTRACHARGESPERMB", plan.ExtraChargesPerMB);
            cmdbilldetails.Parameters.AddWithValue("@ACTUALDATATRANSFER", 0);
            cmdbilldetails.Parameters.AddWithValue("@EXTRADATATRANSFER", 0);
            cmdbilldetails.Parameters.AddWithValue("@EXTRADATATRANSFERCHARGES", 0);
            cmdbilldetails.Parameters.AddWithValue("@ARREARS", 0);
            cmdbilldetails.Parameters.AddWithValue("@OTRCDISCOUNT", pFloatOTRCDiscount);
            cmdbilldetails.Parameters.AddWithValue("@SECURITYDEPOSITDISCOUNT", pFloatSecurityDiscount);
            cmdbilldetails.Parameters.AddWithValue("@WAIVERS", pFloatWaiver);
            cmdbilldetails.Parameters.AddWithValue("@PERSISTENTWAIVER", pFloatPersistentWaiver);
            cmdbilldetails.Parameters.AddWithValue("@PAYMENTS", 0);


            Int32 cycleid = -1;
            Int32 daysconnected = -1;
            string billstartdate = "";
            string billenddate = "";
            string billdate = pStrConnectionDate;
            double cyclecharges = -1;
            double datatransferredallowed = -1;
            double datatransferredallowedforthecycle = -1;
            double proratedcyclecharges = -1;
            double totalcharges = -1;
            double netpayable = -1;
            double servicetax = -1;
            double totaloutstanding = -1;
            string billnumber = "";
            string lastdateofpayment = "";

            Int32 totalDaysinConnectedMonth = -1;

            if (reguser.RentalPaymentMode == "M")
            {
                cycleid = BillCycles.GetMonthlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));
                billstartdate = BillCycles.GetCycleStartDateOfMonthlyCycle(cycleid);
                billenddate = BillCycles.GetCycleEndDateOfMonthlyCycle(cycleid);

                //    TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));

                TimeSpan dc = (Convert.ToDateTime(billenddate).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                //get total days in connected month
                TimeSpan totalmonthdays = (Convert.ToDateTime(billenddate).Subtract(Convert.ToDateTime(billstartdate))
                    );

                daysconnected = dc.Days + 1;
                totalDaysinConnectedMonth = totalmonthdays.Days + 1;

                cyclecharges = plan.MonthlyUsageCharges;
                datatransferredallowed = plan.MonthlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedMonthlyDataTransferAllowed(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth);

                proratedcyclecharges = plan.GetProratedMonthlyUsageCharges(reguser.BillPlanID, daysconnected, totalDaysinConnectedMonth);

                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");


            }
            else if (reguser.RentalPaymentMode == "Q")
            {
                cycleid = BillCycles.GetQuarterlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                billstartdate = BillCycles.GetCycleStartDateOfQuarterlyCycle(cycleid);

                billenddate = BillCycles.GetCycleEndDateOfQuarterlyCycle(cycleid);

                TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                daysconnected = dc.Days + 1;

                cyclecharges = plan.QuarterlyUsageCharges;

                datatransferredallowed = plan.QuarterlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedQuarterlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                proratedcyclecharges = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");

            }
            else if (reguser.RentalPaymentMode == "H")
            {
                cycleid = BillCycles.GetHalfYearlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                billstartdate = BillCycles.GetCycleStartDateOfHalfYearlyCycle(cycleid);

                billenddate = BillCycles.GetCycleEndDateOfHalfYearlyCycle(cycleid);

                TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfHalfYearlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                daysconnected = dc.Days + 1;

                cyclecharges = plan.HalfYearlyUsageCharges;

                datatransferredallowed = plan.HalfYearlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedHalfYearlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                proratedcyclecharges = plan.GetProratedHalfYearlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");

            }

            else if (reguser.RentalPaymentMode == "A")
            {
                cycleid = BillCycles.GetYearlyBillCycleID(Utilities.ValidSql(pStrConnectionDate));

                billstartdate = BillCycles.GetCycleStartDateOfYearlyCycle(cycleid);

                billenddate = BillCycles.GetCycleEndDateOfYearlyCycle(cycleid);

                TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfYearlyCycle(cycleid)).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrConnectionDate))));
                daysconnected = dc.Days + 1;

                cyclecharges = plan.YearlyUsageCharges;

                datatransferredallowed = plan.YearlyDataTransferLimit;

                datatransferredallowedforthecycle = plan.GetProratedYearlyDataTransferAllowed(Utilities.ValidSql(reguser.BillPlanID), daysconnected);

                proratedcyclecharges = plan.GetProratedYearlyUsageCharges(Utilities.ValidSql(reguser.BillPlanID), daysconnected);
                lastdateofpayment = Convert.ToDateTime(pStrConnectionDate).AddDays(7).ToString("MM-dd-yyyy");

            }


            totalcharges = otrcplan.DownPayment + plan.SecurityDeposit + proratedcyclecharges + (pFloatExtraOFCLength * (plan.ExtraOFCRate)) + (pFLoatExtraCAT5Length * (plan.ExtraCAT5Rate));

            netpayable = totalcharges - pFloatOTRCDiscount - pFloatSecurityDiscount - pFloatWaiver - pFloatPersistentWaiver;

            servicetax = (Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["ServiceTax"].ToString())) * (proratedcyclecharges - pFloatPersistentWaiver);

            totaloutstanding = netpayable + servicetax;

            billnumber = Utilities.ValidSql(BroadbandSubscriberBills.GetNewBillNumber());

            cmdbilldetails.Parameters.AddWithValue("@BILLCYCLEID", cycleid);
            cmdbilldetails.Parameters.AddWithValue("@CYCLECHARGES", cyclecharges);
            cmdbilldetails.Parameters.AddWithValue("@DAYSBILLED", daysconnected);
            cmdbilldetails.Parameters.AddWithValue("@BILLNUMBER", billnumber);
            cmdbilldetails.Parameters.AddWithValue("@BILLDATE", billdate);
            cmdbilldetails.Parameters.AddWithValue("@BILLSTARTDATE", billstartdate);
            cmdbilldetails.Parameters.AddWithValue("@BILLENDDATE", billenddate);
            cmdbilldetails.Parameters.AddWithValue("@DTA", datatransferredallowed);
            cmdbilldetails.Parameters.AddWithValue("@ALLOWEDDTA", datatransferredallowedforthecycle);
            cmdbilldetails.Parameters.AddWithValue("@PRORATEDCYCLECHARGES", proratedcyclecharges);
            cmdbilldetails.Parameters.AddWithValue("@TOTALCHARGES", totalcharges);
            cmdbilldetails.Parameters.AddWithValue("@NETPAYABLE", netpayable);
            cmdbilldetails.Parameters.AddWithValue("@SERVICETAX", servicetax);
            cmdbilldetails.Parameters.AddWithValue("@TOTALOUTSTANDING", totaloutstanding);
            cmdbilldetails.Parameters.AddWithValue("@LASTDATEOFPAYMENT", Utilities.ValidSql(lastdateofpayment));
            cmdbilldetails.Parameters.AddWithValue("@FIRSTBILL", "T");


            //5
            cmdledger.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,exdtpayment,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@exdtpayment,@instrumentid,@modby,@modon)";
            cmdledger.Parameters.AddWithValue("@userid", Utilities.ValidSql(strNewSubscriberCode));
            cmdledger.Parameters.AddWithValue("@specifications", "SymBios Broadband Services Bill:");
            cmdledger.Parameters.AddWithValue("@cr", totaloutstanding);
            cmdledger.Parameters.AddWithValue("@dr", 0);
            cmdledger.Parameters.AddWithValue("@EXDTPAYMENT", "F");
            cmdledger.Parameters.AddWithValue("@instrumentid", billnumber);
            cmdledger.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdledger.Parameters.AddWithValue("@modon", Utilities.ValidSql(billdate));


            String strQuery = String.Empty;

            if (reguser.RentalPaymentMode == "M")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month2 + ",'F'," + (cycleid + 1) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month3 + ",'F'," + (cycleid + 2) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month4 + ",'F'," + (cycleid + 3) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month5 + ",'F'," + (cycleid + 4) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month6 + ",'F'," + (cycleid + 5) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month7 + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month8 + ",'F'," + (cycleid + 7) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month9 + ",'F'," + (cycleid + 8) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month10 + ",'F'," + (cycleid + 9) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month11 + ",'F'," + (cycleid + 10) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + otrcplan.Month12 + ",'F'," + (cycleid + 11) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "Q")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4) + ",'F'," + (cycleid + 3) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7) + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10) + ",'F'," + (cycleid + 9) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "H")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4 + otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7) + ",'F'," + (cycleid + 6) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10 + otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            else if (reguser.RentalPaymentMode == "A")
            {

                strQuery += "insert WAD (userid,waiver,arrear,dnb,cycleid,modby,modon,remarks) values ('" + userid + "',0," + (otrcplan.Month2 + otrcplan.Month3 + otrcplan.Month4 + otrcplan.Month5 + otrcplan.Month6 + otrcplan.Month7 + otrcplan.Month8 + otrcplan.Month9 + otrcplan.Month10 + otrcplan.Month11 + otrcplan.Month12) + ",'F'," + (cycleid + 12) + ",'" + Utilities.ValidSql(pStrSystemUserID) + "','" + Utilities.ValidSql(billdate) + "','Installment of Registration Charges');";
            }
            //6
            cmdwad.CommandText = strQuery;
            //7
            cmdreguser.CommandText = "update Registeredusers set connectiondate='" + Utilities.ValidSql(billdate) + "', status='A' where userid='" + Utilities.ValidSql(pStrRegistrationID) + "'";
            //8
            cmdreguserUpdateBillFlag.CommandText = "UPDATE REGISTEREDUSERS set ISBILLRAISED='T' where USERID='" + Utilities.ValidSql(pStrRegistrationID) + "'";

            cmduserStatusLog.CommandType = CommandType.StoredProcedure;
            //9
            cmduserStatusLog.CommandText = "INSERTUSERSTATUSLOG";
            //INSERT INTO USERSTATUSLOG VALUES(@USERID,@DATE,@REMARKS,  @STATUS, @MODBY)
            cmduserStatusLog.Parameters.AddWithValue("@USERID", userid);
            cmduserStatusLog.Parameters.AddWithValue("@STATUS", "A");
            cmduserStatusLog.Parameters.AddWithValue("DATE", DateTime.Now);
            cmduserStatusLog.Parameters.AddWithValue("@REMARKS", "New Connection");
            cmduserStatusLog.Parameters.AddWithValue("@MODBY", pStrSystemUserID);


            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                //1
                cmduser.Transaction = tr;
                //2
                cmduserbillinginfo.Transaction = tr;
                //3
                cmddiscountsandwaivers.Transaction = tr;
                //4
                cmdbilldetails.Transaction = tr;
                //5
                cmdledger.Transaction = tr;
                //6
                cmdwad.Transaction = tr;
                //7
                cmdreguser.Transaction = tr;
                //8
                cmdreguserUpdateBillFlag.Transaction = tr;
                //9
                cmduserStatusLog.Transaction = tr;

                cmduser.ExecuteNonQuery();
                cmduserbillinginfo.ExecuteNonQuery();
                cmddiscountsandwaivers.ExecuteNonQuery();
                cmdbilldetails.ExecuteNonQuery();
                cmdledger.ExecuteNonQuery();
                cmdwad.ExecuteNonQuery();
                cmdreguser.ExecuteNonQuery();
                cmdreguserUpdateBillFlag.ExecuteNonQuery();
                cmduserStatusLog.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                billnumber = "-1";
                tr.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (billnumber);
        }

        #endregion
        */
        #region Update User Status Functionality

        public void UpdateSubscriberStatus(String pStrUserID, UpdateStatus status)
        {
            String strQueryString = "";
            SqlConnection conn = null;

            switch (status)
            {
                case UpdateStatus.ACTIVATE:
                    strQueryString += "Update USERMASTER set STATUS='" + "A" + "' where userid='" + pStrUserID + "'";
                    break;
                case UpdateStatus.DEACTIVATE:
                    strQueryString += "Update USERMASTER set STATUS='" + "D" + "' where userid='" + pStrUserID + "'";
                    break;
                case UpdateStatus.TEMPORARYDISCONNECTION:
                    strQueryString += "Update USERMASTER set STATUS='" + "T" + "' where userid='" + pStrUserID + "'";
                    break;
                case UpdateStatus.PERMANENTLYDISCONNECTION:
                    strQueryString += "Update USERMASTER set STATUS='" + "P" + "' where userid='" + pStrUserID + "'";
                    break;
                case UpdateStatus.DEACTIVATEDONNONPAYMENT:
                    strQueryString += "Update USERMASTER set STATUS='" + "N" + "' where userid='" + pStrUserID + "'";
                    break; 
                default:
                    throw new Exception("Error: Invalid Type Key");
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
            cmd.CommandText = strQueryString;

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
        
        #region Update User Contact Details

        public void UpdateSubscriberContactDetails(String pStrUserID, String pStrCustomerName, String pStrEmail, String pStrCorrespondenceAddress, String pStrInstallationAddress, String pStrMobileNumber, String pStrLandlineNumber)
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


            SqlCommand cmdupdate = conn.CreateCommand();

            cmdupdate.CommandText = "update USERMASTER set name='" + Utilities.ValidSql(pStrCustomerName) + "', emailid='" + Utilities.ValidSql(pStrEmail) + "', insadr='" + Utilities.ValidSql(pStrInstallationAddress) + "', coradr='" + Utilities.ValidSql(pStrCorrespondenceAddress) + "', landlinenumber='" + Utilities.ValidSql(pStrLandlineNumber) + "', mobilenumber='" + Utilities.ValidSql(pStrMobileNumber) + "' where userid='" + Utilities.ValidSql(pStrUserID) + "'";


            
            try
            {
                conn.Open();
                cmdupdate.ExecuteNonQuery();               
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

        #region Monthly DNP Functionality

        public void DNPUser()
        {
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
            cmd.CommandText = "Select USERID from USERBILLINGINFO";

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["userid"] != DBNull.Value)
                    { 
                        string userid=dr["userid"].ToString();
                        BroadbandSubscriberLedgers sl = new BroadbandSubscriberLedgers();
                        double dOutStanding = sl.GetTotalOutstanding(userid);
                        if (dOutStanding > 0)
                        {
                            this.DNP(userid);
                        }
                    }
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
        
        #region DNP Functionality

        public void DNP(String pStrUserID)
        {
           
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            SqlCommand cmdupdate = conn.CreateCommand();
            SqlCommand cmddnp = conn.CreateCommand();
            cmdupdate.CommandText = "update USERMASTER set STATUS='" + "N" + "' where userid='" + Utilities.ValidSql(pStrUserID) + "'";
            cmddnp.CommandText = "insert DNPDETAILS (userid,dnpdate,remarks) values (@userid,@dnpdate,@remarks)";
            cmddnp.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmddnp.Parameters.AddWithValue("@dnpdate", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmddnp.Parameters.AddWithValue("@remarks", "Disconnected due to Non-Payment.");


            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdupdate.Transaction = tr;
                cmddnp.Transaction = tr;
                cmdupdate.ExecuteNonQuery();
                cmddnp.ExecuteNonQuery();
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

        #region Active Users Count

        public double GetActiveUsersCount()
        {

            double dCount = 0;
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
            cmd.CommandText = "Select count(*) from USERMASTER where status='"+"A"+"'";

            try
            {
                conn.Open();
                dCount = Convert.ToDouble(cmd.ExecuteScalar());              
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dCount);
        }

        #endregion
        
        #region De-Active Users Count

        public double GetDeActiveUsersCount()
        {

            double dCount = 0;
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
            cmd.CommandText = "Select count(*) from USERMASTER where status='" + "D" + "'";

            try
            {
                conn.Open();
                dCount = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dCount);
        }

        #endregion
        
        #region Temporary Disconnections Count

        public double GetTDCount()
        {

            double dCount = 0;
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
            cmd.CommandText = "Select count(*) from USERMASTER where status='" + "T" + "'";

            try
            {
                conn.Open();
                dCount = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dCount);
        }

        #endregion
        
        #region ARPU

        public double GetARPU()
        {

            double dCount = 0;
            Int32 CycleID=0;
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
            

            CycleID=(BillCycles.GetMonthlyBillCycleID(System.DateTime.Now.ToString()));
            String CycleStartDate = "";
            String CycleEndDate = "";
            
            if (CycleID > 0)
            {
                CycleStartDate = BillCycles.GetCycleStartDateOfMonthlyCycle(CycleID);
                CycleEndDate = BillCycles.GetCycleEndDateOfMonthlyCycle(CycleID);
            }

            cmd.CommandText = "select isnull((select sum(netpayable) from billdetails where billcycleid="+ CycleID +")/(select count(*) from usermaster where connectiondate<='" + Utilities.ValidSql(CycleEndDate) + "' and status='A'),0)";

            try
            {
                conn.Open();
                dCount = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (dCount);
        }

        #endregion
        
        #region Temporary Disconnection Functionality

        public void TemporaryDisconnection(String pStrUserID, String pStrStartDate, String pStrEndDate, bool ISTFN, String pStrSystemUserID)
        {            
            
            SqlConnection conn = null;
            SqlTransaction tr = null;
            
            string remarks = "Waiver given for temporary disconnection ";
            Int32 fromcycleid = -1;
            Int32 tocycleid = -1;
            Int32 currentcycleid = -1;
            Int32 disconnectiondays = 0;
            Int32 totaldaysinConnectedMonth = 0;
            //double cyclecharges = -1;
            double waivereachcycle = -1;
            StringBuilder ct;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            //try
            //{
                SqlCommand cmdwaivers = conn.CreateCommand();
                SqlCommand cmdtddetails = conn.CreateCommand();

                BroadbandUserBillingInfo userbi = new BroadbandUserBillingInfo(pStrUserID);
                BroadbandBillPlans plan = new BroadbandBillPlans(userbi.BillPlanID);

                if (userbi.PaymentMode == "M")
                {
                    fromcycleid = BillCycles.GetMonthlyBillCycleID(Utilities.ValidSql(pStrStartDate));
                    tocycleid = BillCycles.GetMonthlyBillCycleID(Utilities.ValidSql(pStrEndDate));
                    currentcycleid = BillCycles.GetMonthlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy"));
                }
                else if (userbi.PaymentMode == "Q")
                {
                    fromcycleid = BillCycles.GetQuarterlyBillCycleID(Utilities.ValidSql(pStrStartDate));
                    tocycleid = BillCycles.GetQuarterlyBillCycleID(Utilities.ValidSql(pStrEndDate));
                    currentcycleid = BillCycles.GetQuarterlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy"));
                }

                if (ISTFN)
                {

                    double waiver = 0;

                    if (userbi.PaymentMode == "M")
                    {
                        TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));

                        TimeSpan totalMonthDays = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(fromcycleid))));

                        disconnectiondays = dc.Days;
                        totaldaysinConnectedMonth = totalMonthDays.Days;

                        waiver = (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) + 1) + plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays, totaldaysinConnectedMonth);

                    }
                    else if (userbi.PaymentMode == "Q")
                    {
                        TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));

                        disconnectiondays = dc.Days;
                        waiver = (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) + 1) + plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);
                    }

                    remarks += "for " + disconnectiondays.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till futher notice";

                    SqlCommand cmdtdtfn = conn.CreateCommand();
                    cmdtddetails = conn.CreateCommand();
 
                    cmdtdtfn.CommandText = "insert TDTILLFURTHERNOTICE (userid,startdate,waiver,reactivationflag,remarks,modby,modon) values (@userid,@startdate,@waiver,@reactivationflag,@remarks,@modby,@modon)";
                    cmdtdtfn.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                    cmdtdtfn.Parameters.AddWithValue("@startdate", Utilities.ValidSql(pStrStartDate));
                    cmdtdtfn.Parameters.AddWithValue("@waiver", waiver);
                    cmdtdtfn.Parameters.AddWithValue("@reactivationflag", "F");
                    cmdtdtfn.Parameters.AddWithValue("@remarks", remarks);
                    cmdtdtfn.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                    cmdtdtfn.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

                    SqlDateTime nulldate = SqlDateTime.Null;

                    cmdtddetails.CommandText = "insert TEMPORARYDISCONNECTIONDETAILS (userid,startdate,enddate,TFN,reactivationflag,modby,modon) values (@userid,@startdate,@enddate,@TFN,@reactivationflag,@modby,@modon)";
                    cmdtddetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                    cmdtddetails.Parameters.AddWithValue("@startdate", Utilities.ValidSql(pStrStartDate));
                    cmdtddetails.Parameters.AddWithValue("@enddate", nulldate);
                    cmdtddetails.Parameters.AddWithValue("@TFN", "T");
                    cmdtddetails.Parameters.AddWithValue("@reactivationflag", "F");
                    cmdtddetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                    cmdtddetails.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));


                    try
                    {
                        conn.Open();
                        tr = conn.BeginTransaction();
                        cmdtdtfn.Transaction = tr;
                        cmdtddetails.Transaction = tr;
                        cmdtdtfn.ExecuteNonQuery();
                        cmdtddetails.ExecuteNonQuery();
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
                else
                {
                    /* ***********************************************
                     * Case I:  The TD Start Cycle=Current Cycle
                     *          The TD End Cycle=Current Cycle
                     * Action:  Pass waiver in the next Cycle
                     ************************************************/

                    if (fromcycleid == tocycleid && fromcycleid == currentcycleid)
                    {

                        TimeSpan dc = (Convert.ToDateTime(pStrEndDate).Subtract(Convert.ToDateTime(Utilities.ValidSql(pStrStartDate))));
                      
                        TimeSpan totalMonthDays = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(fromcycleid))));

                        disconnectiondays = dc.Days;
                        totaldaysinConnectedMonth = totalMonthDays.Days;

                        if (userbi.PaymentMode == "M")
                        {
                            waivereachcycle = plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays, totaldaysinConnectedMonth);
                        }
                        else
                        {
                            waivereachcycle = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);
                        }

                        remarks += "for " + disconnectiondays.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy");
                        ct = new StringBuilder();


                        ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivereachcycle + ",0,\'F\'," + (fromcycleid + 1) + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ")");



                        cmdwaivers.CommandText = ct.ToString();
                    }


                    /* ***********************************************
                     * Case II:  The TD Start Cycle=Current Cycle
                     *          The TD End Cycle=Next Cycle
                     * Action:  Pass waiver in the next Cycle
                     ************************************************/

                    if ((tocycleid - fromcycleid) == 1 && fromcycleid == currentcycleid)
                    {

                        TimeSpan dc = (Convert.ToDateTime(pStrEndDate).Subtract(Convert.ToDateTime(pStrStartDate)));
                        disconnectiondays = dc.Days;

                        if (userbi.PaymentMode == "M")
                        {

                            waivereachcycle = plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);
                        }
                        else
                        {
                            waivereachcycle = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);
                        }

                        remarks += "for " + disconnectiondays.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy");

                        ct = new StringBuilder();

                        ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivereachcycle + ",0,\'F\'," + tocycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," +"\'"+ remarks + "\'" + ")");

                        cmdwaivers.CommandText = ct.ToString();

                    }


                    /* ******************************************************************
                     * Case III:    The TD Start Cycle=Current Cycle
                     *              The TD End Cycle=N Cycle
                     * Action:      1) Pass waiver of current cycle in the N+1 Cycle
                     *              2) Pass full rental waiver from next cycle to N Cycle
                     ********************************************************************/

                    if ((tocycleid - fromcycleid) > 1 && fromcycleid == currentcycleid)
                    {
                        double cyclechargeswithtax = 0;


                        if (userbi.PaymentMode == "M")
                        {
                            TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));
                            disconnectiondays = dc.Days;
                            waivereachcycle = plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);

                            cyclechargeswithtax = plan.MonthlyUsageCharges + (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) * plan.MonthlyUsageCharges);

                            remarks += "for " + disconnectiondays.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid);

                        }
                        else
                        {
                            TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));
                            disconnectiondays = dc.Days;
                            waivereachcycle = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);
                            cyclechargeswithtax = plan.QuarterlyUsageCharges + (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) * plan.QuarterlyUsageCharges);

                            remarks += "for " + disconnectiondays.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + BillCycles.GetCycleEndDateOfQuarterlyCycle(fromcycleid);
                        }

                        ct = new StringBuilder();

                        ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivereachcycle + ",0,\'F\'," + tocycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'" + remarks + "\'" + ")");



                        for (int i = (fromcycleid + 1); i < tocycleid; i++)
                        {
                            remarks = "Not to billed for this cycle as the user is in temporary disconnection this month";
                            ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + "0,0,\'T\'," + i + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ")");
                        }

                        cmdwaivers.CommandText = ct.ToString();
                    }

                    /* ******************************************************************
                     * Case IV:    The TD Start Cycle=N Cycle
                     *              The TD End Cycle=M Cycle
                     * Action:      1) Pass waiver of current cycle in the N+1 Cycle
                     *              2) Pass full rental waiver from next cycle to N Cycle
                     ********************************************************************/

                    if (fromcycleid > currentcycleid)
                    {
                       // double cyclechargeswithtax = 0;
                        double waivertdstartcycle = 0;
                        double waivertdendcycle = 0;
                        Int32 disconnectiondaystdstart = 0;
                        Int32 disconnectiondaystdend = 0;

                        if (userbi.PaymentMode == "M")
                        {

                            if ((Convert.ToDateTime(pStrStartDate) == Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(fromcycleid)) && (Convert.ToDateTime(pStrEndDate) == Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(tocycleid)))))
                            {
                                ct = new StringBuilder();
                                for (int i = fromcycleid; i <= tocycleid; i++)
                                {
                                    remarks = "Not to billed for this cycle as the user is in temporary disconnection this cycle";
                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + "0,0,\'T\'," + i + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ")");
                                }
                            }
                            else
                            {
                                TimeSpan dcs = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));
                                disconnectiondaystdstart = dcs.Days;
                                waivertdstartcycle = plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondaystdstart);
                                //cc
                                TimeSpan dce = (Convert.ToDateTime(pStrEndDate).Subtract(Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(tocycleid))));
                                disconnectiondaystdend = dce.Days;
                                waivertdendcycle = plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondaystdend);


                                ct = new StringBuilder();


                                //Waiver in nth Cycle
                                remarks = "Waiver given for temporary disconnection for " + disconnectiondaystdstart.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(fromcycleid)).ToString("MM-dd-yyyy");


                                ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivertdstartcycle + ",0,\'F\'," + fromcycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");

                                //Fullwaiver in intermediate cycles
                                for (int i = fromcycleid + 1; i < tocycleid; i++)
                                {
                                    remarks = "Not to billed for this cycle as the user is in temporary disconnection this cycle";
                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + "0,0,\'T\'," + i + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");
                                }

                                //Waiver in mth Cycle

                                if ((tocycleid - fromcycleid) > 0)
                                {
                                    remarks = "Waiver given for temporary disconnection for " + disconnectiondaystdend.ToString() + " days starting from " + Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(tocycleid)).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy");

                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivertdendcycle + ",0,\'F\'," + tocycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");
                                }

                            }
                        }
                        else
                        {
                            if ((Convert.ToDateTime(pStrStartDate) == Convert.ToDateTime(BillCycles.GetCycleStartDateOfQuarterlyCycle(fromcycleid)) && (Convert.ToDateTime(pStrEndDate) == Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(tocycleid)))))
                            {
                                ct = new StringBuilder();
                                for (int i = fromcycleid; i <= tocycleid; i++)
                                {
                                    remarks = "Not to billed for this cycle as the user is in temporary disconnection this cycle";
                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + "0,0,\'T\'," + i + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ")");
                                }
                            }
                            else
                            {
                                TimeSpan dcs = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(fromcycleid)).Subtract(Convert.ToDateTime(pStrStartDate)));
                                disconnectiondaystdstart = dcs.Days;
                                waivertdstartcycle = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondaystdstart);
                                //cc
                                TimeSpan dce = (Convert.ToDateTime(pStrEndDate).Subtract(Convert.ToDateTime(BillCycles.GetCycleStartDateOfQuarterlyCycle(tocycleid))));
                                disconnectiondaystdend = dce.Days;
                                waivertdendcycle = plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondaystdend);


                                ct = new StringBuilder();


                                //Waiver in nth Cycle
                                remarks = "Waiver given for temporary disconnection for " + disconnectiondaystdstart.ToString() + " days starting from " + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(fromcycleid)).ToString("MM-dd-yyyy");


                                ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivertdstartcycle + ",0,\'F\'," + fromcycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");

                                //Fullwaiver in intermediate cycles
                                for (int i = fromcycleid + 1; i < tocycleid; i++)
                                {
                                    remarks = "Not to billed for this cycle as the user is in temporary disconnection this cycle";
                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + "0,0,\'T\'," + i + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");
                                }

                                //Waiver in mth Cycle
                                if ((tocycleid - fromcycleid) > 0)
                                {
                                    remarks = "Waiver given for temporary disconnection for " + disconnectiondaystdend.ToString() + " days starting from " + Convert.ToDateTime(BillCycles.GetCycleStartDateOfQuarterlyCycle(tocycleid)).ToString("MM-dd-yyyy") + " till " + Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy");

                                    ct.AppendLine("insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (\'" + Utilities.ValidSql(pStrUserID) + "\'," + waivertdendcycle + ",0,\'F\'," + tocycleid + ",\'" + System.DateTime.Now.ToString("MM-dd-yyyy") + "\',\'" + pStrSystemUserID + "\'," + "\'" + remarks + "\'" + ");");
                                }
                            }
                        }

                        cmdwaivers.CommandText = ct.ToString();
                    }

                    cmdtddetails.CommandText = "insert TEMPORARYDISCONNECTIONDETAILS (userid,startdate,enddate,TFN,reactivationflag,modby,modon) values (@userid,@startdate,@enddate,@TFN,@reactivationflag,@modby,@modon)";
                    cmdtddetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                    cmdtddetails.Parameters.AddWithValue("@startdate", Utilities.ValidSql(pStrStartDate));
                    cmdtddetails.Parameters.AddWithValue("@enddate", Utilities.ValidSql(pStrEndDate));
                    cmdtddetails.Parameters.AddWithValue("@TFN", "F");
                    cmdtddetails.Parameters.AddWithValue("@reactivationflag", "F");
                    cmdtddetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                    cmdtddetails.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));


                    try
                    {
                        conn.Open();
                        tr = conn.BeginTransaction();
                        cmdwaivers.Transaction = tr;
                        cmdtddetails.Transaction = tr;
                        cmdwaivers.ExecuteNonQuery();
                        cmdtddetails.ExecuteNonQuery();
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
            //}
            /*catch
            {
                throw;
            }*/

        }

        #endregion


     



        

        #region change Plan Change Functionality
        /// <summary>
        /// This function will change the payment plan of a user in the database
        /// </summary>
        /// <param name="pStrUserID"></param>
        /// <param name="pStrNewPaymentMode"></param>
        /// <param name="pIntCycleID"></param>
        /// <param name="pStrModby"></param>
        public void ChangePaymentCycle(String pStrUserID, String pStrOldBillPlanID, String pStrOldPaymentMode, String pStrNewPaymentMode, Int32 pIntCycleID, String pStrModby)
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

            SqlCommand cmdbillplanchangedetails = conn.CreateCommand();


            cmdbillplanchangedetails.CommandText = "insert BILLPLANCHANGEDETAILS (userid,oldbillplanid,newbillplanid, oldpaymentmode, newpaymentmode,fromcycleid,changeaffected,modby,modon) values (@userid,@oldbillplanid,@newbillplanid,@oldpaymentmode, @newpaymentmode,@fromcycleid,@changeaffected,@modby,@modon)";

            cmdbillplanchangedetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newbillplanid", Utilities.ValidSql(pStrOldBillPlanID));
            cmdbillplanchangedetails.Parameters.AddWithValue("@oldpaymentmode", Utilities.ValidSql(pStrOldPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@newpaymentmode", Utilities.ValidSql(pStrNewPaymentMode));
            cmdbillplanchangedetails.Parameters.AddWithValue("@fromcycleid", pIntCycleID);
            cmdbillplanchangedetails.Parameters.AddWithValue("@changeaffected", "F");
            cmdbillplanchangedetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmdbillplanchangedetails.Parameters.AddWithValue("@modon", DateTime.Now);


            try
            {
                conn.Open();
             cmdbillplanchangedetails.ExecuteNonQuery();


            
               
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

        #region Listing Functionality for   Bill Plan Change ReQuests for a active user

        public static DataSet GetBillPlanChangeRequests(string pusername)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid,a.fromdate,c.name, c.username, d.packageName oldpackagename, e.packagename newpackagename, case newpaymentmode when 'M' then 'MONTHLY' else 'QUARTERLY' end as PAYMENTMODE, b.billcyclename billcyclename ,a.fromdate fromdate from billplanchangedetails a, billcycles b, usermaster c, billplans d, billplans e where a.fromcycleid=b.billcycleid and a.userid=c.userid and a.oldbillplanid=d.billplanid and a.newbillplanid=e.billplanid and a.newbillplanid <>a.oldbillplanid and c.username='" + Utilities.ValidSql(pusername) + "' and c.status='A' order by a.fromcycleid desc";
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

        #region Listing Functionality for Active Bill Plan Change ReQuest

        public static DataSet GetActiveBillPlanChangeRequests()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid,a.fromdate,c.name, c.username, d.packageName oldpackagename, e.packagename newpackagename, case newpaymentmode when 'M' then 'MONTHLY' else 'QUARTERLY' end as PAYMENTMODE, b.billcyclename billcyclename from billplanchangedetails a, billcycles b, usermaster c, billplans d, billplans e where a.fromcycleid=b.billcycleid and a.userid=c.userid and a.CHANGEAFFECTED='F' and a.oldbillplanid=d.billplanid and a.newbillplanid=e.billplanid and a.newbillplanid <>a.oldbillplanid order by a.userid asc";
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


        #region Listing Functionality for payment cycle Plan Change ReQuest

        public static DataSet GetActivePaymentCycleChangeRequests()
        {
            DataSet dst = new DataSet();//d.packageName oldpackagename, e.packagename newpackagename,
            string strQueryString = "select a.userid,c.name, c.username,a.oldpaymentmode,  case newpaymentmode when 'M' then 'MONTHLY' when 'Q' then 'QUARTERLY' WHEN 'H' THEN 'HALF YEARLY' WHEN 'A' THEN 'YEARLY'  else '' end as PAYMENTMODE, b.billcyclename billcyclename from billplanchangedetails a, billcycles b, usermaster c, billplans d, billplans e where a.fromcycleid=b.billcycleid and a.userid=c.userid and a.CHANGEAFFECTED='F' and  a.oldbillplanid=d.billplanid and a.newbillplanid=e.billplanid and a.oldpaymentmode is not null and a.oldpaymentmode <> a.newpaymentmode order by a.userid asc";
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

        #region Shift Connection Functionality

        public void ShiftConnection(String pStrUserID, String pStrCorrespondenceAddress, String pStrInstallationAddress, String pDtShiftingDate, double dExtraOFC, double dExtraCAT5, String pStrSystemUserID)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }


            SqlCommand cmdupdate = conn.CreateCommand();
            SqlCommand cmdawd = conn.CreateCommand();


            cmdupdate.CommandText = "update USERMASTER set insadr='" + Utilities.ValidSql(pStrInstallationAddress) + "', coradr='" + Utilities.ValidSql(pStrCorrespondenceAddress) + "', NETWORKALLOCATIONSTATUS='N' where userid='"+Utilities.ValidSql(pStrUserID) +"'";

            BroadbandUserBillingInfo bi = new BroadbandUserBillingInfo(pStrUserID);
            BroadbandBillPlans plan = new BroadbandBillPlans(bi.BillPlanID);

            double extraOFCCharges = (dExtraOFC * plan.ExtraOFCRate);
            double extraCAT5Charges = (dExtraCAT5 * plan.ExtraCAT5Rate);
            double totalCharges = (500 + extraOFCCharges + extraCAT5Charges);

            string strRemarks = "Shifting Charges: Rs. 500";

            if (extraOFCCharges > 0)
            {
                strRemarks += ", Rs." + extraOFCCharges + "Extra OFC Charges for " + dExtraOFC + "m @ Rs. " + plan.ExtraOFCRate + "/-";
            }
            if (extraCAT5Charges > 0)
            { 
                strRemarks+=", Rs."+extraCAT5Charges+"Extra CAT5 Charges for "+dExtraCAT5+"m @ Rs. "+plan.ExtraCAT5Rate+"/-";
            }

            cmdawd.CommandText = "insert WAD (userid,waiver,arrear,dnb,cycleid,modon,modby,remarks) values (@userid,@waiver,@arrear,@dnb,@cycleid,@modon,@modby,@remarks)";
            cmdawd.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdawd.Parameters.AddWithValue("@waiver", 0);
            cmdawd.Parameters.AddWithValue("@arrear", totalCharges);
            cmdawd.Parameters.AddWithValue("@dnb", "F");
            cmdawd.Parameters.AddWithValue("@cycleid", ((BillCycles.GetMonthlyBillCycleID(pDtShiftingDate))+1));
            cmdawd.Parameters.AddWithValue("@modon", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmdawd.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdawd.Parameters.AddWithValue("@remarks", strRemarks);

             try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdawd.Transaction = tr;
                cmdupdate.Transaction = tr;

                cmdawd.ExecuteNonQuery();
                cmdupdate.ExecuteNonQuery();
                
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

        #region Checking Valid User ID

        public static bool IsValidUserID(string pStrUserID)
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
            cmdcheck.CommandText = "SELECT count(userid) from USERMASTER where USERID='" + Utilities.ValidSql(pStrUserID) + "'";

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

        #region Permanent Disconnection Functionality

        public static void PermanentlyDisconnect(String pStrUserID, String pStrLastDate, String pStrDisconnectionType, String pStrSystemUserID)
        {

            SqlConnection conn = null;
            SqlTransaction tr = null;

            string remarks = "Waiver on Permanent Disconnection ";

            Int32 currentcycleid = -1;
            Int32 disconnectiondays = 0;
            Int32 totalDaysinConnectedMonth = 0;
            double exdtcharges = 0;
            double waiver = 0;
            double securityrefund = 0;
            //StringBuilder ct;

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

                BroadbandUserBillingInfo userbi = new BroadbandUserBillingInfo(pStrUserID);
                BroadbandBillPlans plan = new BroadbandBillPlans(userbi.BillPlanID);

                if (userbi.PaymentMode == "M")
                {
                    currentcycleid = BillCycles.GetMonthlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy"));

                    TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(currentcycleid)).Subtract(Convert.ToDateTime(pStrLastDate)));

                    TimeSpan totalMonthDays = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfMonthlyCycle(currentcycleid)).Subtract(Convert.ToDateTime(BillCycles.GetCycleStartDateOfMonthlyCycle(currentcycleid))));

                    disconnectiondays = dc.Days;
                    totalDaysinConnectedMonth = totalMonthDays.Days;

                    waiver = (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) + 1) + plan.GetProratedMonthlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays, totalDaysinConnectedMonth);
                    
                    exdtcharges = DataTransferUtilities.GetCurrentExtraDataTransferCharges(pStrUserID);                   

                }
                else if (userbi.PaymentMode == "Q")
                {
                    currentcycleid = BillCycles.GetQuarterlyBillCycleID(System.DateTime.Now.ToString("MM-dd-yyyy"));

                    TimeSpan dc = (Convert.ToDateTime(BillCycles.GetCycleEndDateOfQuarterlyCycle(currentcycleid)).Subtract(Convert.ToDateTime(pStrLastDate)));

                    disconnectiondays = dc.Days;
                    waiver = (Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["ServiceTax"]) + 1) + plan.GetProratedQuarterlyUsageCharges(Utilities.ValidSql(userbi.BillPlanID), disconnectiondays);

                    exdtcharges = DataTransferUtilities.GetCurrentExtraDataTransferCharges(pStrUserID); 
                }

                
                securityrefund=(plan.SecurityDeposit-DiscountsAndWaivers.GetSecurityDepositDiscount(pStrUserID));
                remarks += "from " + Convert.ToDateTime(pStrLastDate).ToString("MM-dd-yyyy");

                SqlCommand cmdpddetails = conn.CreateCommand();
                SqlCommand cmdledgerwaiver = conn.CreateCommand();
                SqlCommand cmdledgerexdt = conn.CreateCommand();
                SqlCommand cmdledgersecrefund = conn.CreateCommand();
                SqlCommand cmdusermaster = conn.CreateCommand();



                cmdpddetails.CommandText = "insert PERMANENTDISCONNECTIONDETAILS (userid,disconnectiondate,remarks,modby,modon) values (@userid,@disconnectiondate,@remarks,@modby,@modon)";
                cmdpddetails.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdpddetails.Parameters.AddWithValue("@disconnectiondate", Utilities.ValidSql(pStrLastDate));
                cmdpddetails.Parameters.AddWithValue("@remarks", Utilities.ValidSql(pStrDisconnectionType));
                cmdpddetails.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                cmdpddetails.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

                cmdledgerwaiver.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@instrumentid,@modby,@modon)";
                cmdledgerwaiver.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdledgerwaiver.Parameters.AddWithValue("@specifications", remarks);
                cmdledgerwaiver.Parameters.AddWithValue("@cr", 0);
                cmdledgerwaiver.Parameters.AddWithValue("@dr", waiver);
                cmdledgerwaiver.Parameters.AddWithValue("@instrumentid", "");
                cmdledgerwaiver.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                cmdledgerwaiver.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

                cmdledgerexdt.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@instrumentid,@modby,@modon)";
                cmdledgerexdt.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdledgerexdt.Parameters.AddWithValue("@specifications", "Pro-rated extra data transfer charges for the last connected bill cycle");
                cmdledgerexdt.Parameters.AddWithValue("@cr", exdtcharges);
                cmdledgerexdt.Parameters.AddWithValue("@dr", 0);
                cmdledgerexdt.Parameters.AddWithValue("@instrumentid", "");
                cmdledgerexdt.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                cmdledgerexdt.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

                cmdledgersecrefund.CommandText = "insert SUBSCRIBERLEDGER (userid,specifications,cr,dr,instrumentid,modby,modon) values (@userid,@specifications,@cr,@dr,@instrumentid,@modby,@modon)";
                cmdledgersecrefund.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
                cmdledgersecrefund.Parameters.AddWithValue("@specifications", "Security Deposit Refund");
                cmdledgersecrefund.Parameters.AddWithValue("@cr", 0);
                cmdledgersecrefund.Parameters.AddWithValue("@dr", securityrefund);
                cmdledgersecrefund.Parameters.AddWithValue("@instrumentid", "");
                cmdledgersecrefund.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
                cmdledgersecrefund.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

                cmdusermaster.CommandText = "Update USERMASTER set STATUS='" + "D" + "' where userid='" + Utilities.ValidSql(pStrUserID) + "'";

                try
                {
                    conn.Open();
                    tr = conn.BeginTransaction();

                    cmdpddetails.Transaction = tr;
                    cmdledgerwaiver.Transaction = tr;
                    if (exdtcharges > 0)
                    {
                        cmdledgerexdt.Transaction = tr;
                    }
                    cmdledgersecrefund.Transaction = tr;
                    cmdusermaster.Transaction = tr;

                    cmdpddetails.ExecuteNonQuery();
                    cmdledgerwaiver.ExecuteNonQuery();
                    if (exdtcharges > 0)
                    {
                        cmdledgerexdt.ExecuteNonQuery();
                    }
                    cmdledgersecrefund.ExecuteNonQuery();
                    cmdusermaster.ExecuteNonQuery();

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
            catch
            {
                throw;
            }
        }

        #endregion

        #region Listing Subscriber based on Bill Plans Functionality

        public static DataSet GetSubscriberListSortedPlanWise(String pStrBillPlanID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.Name NAME, a.emailid EMAILID, a.mobilenumber MOBILENUMBER from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and b.billplanid='" + Utilities.ValidSql(pStrBillPlanID) + "' order by USERID";
            
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

        #region Listing Subscriber based on Connection Date Range

        public static DataSet GetSubscriberListByDOCRange(String pStrStartDate, String pStrEndDate)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.Name NAME, a.emailid EMAILID, a.mobilenumber MOBILENUMBER from USERMASTER where CONNECTIONDATE between '" + Utilities.ValidSql(pStrStartDate) + "' and '" + Utilities.ValidSql(pStrEndDate) + "' order by USERID";

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

        #region Listing Subscriber based on Payment Mode

        public static DataSet GetSubscriberListByPaymentMode(String pStrPaymentMode)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.Name NAME, a.emailid EMAILID, a.mobilenumber MOBILENUMBER from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and b.paymentmode='" + Utilities.ValidSql(pStrPaymentMode) + "' order by USERID";

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

        #region Listing Subscriber based on Subscriber ID

        public static DataSet GetSubscriberByID(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select userid ,username from USERMASTER where UserID='" + Utilities.ValidSql(pStrUserID) + "'";

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

        #region Listing Subscriber based on Point of Presence

        public static DataSet GetSubscriberListByPoP(String pStrPoPID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID, a.username USERNAME, a.Name NAME, a.emailid EMAILID, a.mobilenumber MOBILENUMBER from USERMASTER a, RM_FIBERMASTER b, POPMASTER c  where a.userid=b.userid and b.popid=c.popid  and c.popid='" + Utilities.ValidSql(pStrPoPID) + "' order by a.USERID ";

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

        #region User ID Ordered Listing Functionality

        public static DataSet GetSubscriberListOrderedByUserID(BroadbandUserStatus status)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.insadr INSADR, a.coradr CORADR, a.connectiondate CONNECTIONDATE, a.registrationdate REGISTRATIONDATE, b.billplanid BILLPLANID, b.paymentmode PAYMENTMODE, a.status STATUS, a.emailid EMAILID, a.mobilenumber MOBILENUMBER, a.landlinenumber LANDLINENUMBER from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and b.billflag='T' ";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString += " order by USERID";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " and a.status='" + "A" + "' order by USERID";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " and a.status='" + "D" + "' order by USERID";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " and a.status='" + "T" + "' order by USERID";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status='" + "P" + "' order by USERID";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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

        #region Search Subscriber based on username

        public static DataSet SearchSubscribersByUsername(String pStrUsername)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.coradr CORADR, a.insadr INSADR,	c.packagename BILLPLAN, a.mobilenumber as MOBILENUMBER ,a.landlinenumber , a.status STATUS from USERMASTER a, USERBILLINGINFO b, BILLPLANS c where a.userid=b.userid and b.billplanid=c.billplanid and a.username like '%" + Utilities.ValidSql(pStrUsername) + "%' order by USERID";

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





        public static DataSet SearchUserByUsername(String pStrUsername)
        {
            DataSet dst = new DataSet();
     

            string strQueryString = "SELECT [USERID], [USERNAME], [CAFNUMBER], [CAFDOCUMENTNAME], [CAFANNEXURENAME], [IDPROOFNAME], [PHOTOFILENAME], [ADDPROOFNAME], [IDPROOFTYPE], [ADDRESSPROOFTYPE] FROM [USERMASTER] where username ='"+ Utilities.ValidSql(pStrUsername)+"'";


            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

              //  AKUM
            }
            catch
            {
                throw;
            }

            return (dst);
        }

        public static DataSet SearchUserByUserID(String pStrUserID)
        {
            DataSet dst = new DataSet();


            string strQueryString = "SELECT [USERID], [USERNAME], [CAFNUMBER], [CAFDOCUMENTNAME], [CAFANNEXURENAME], [IDPROOFNAME], [PHOTOFILENAME], [ADDPROOFNAME], [IDPROOFTYPE], [ADDRESSPROOFTYPE],[POPID],[CONNECTIONTYPE],[CONNECTIONDETAILS] FROM [USERMASTER] where userid ='" + Utilities.ValidSql(pStrUserID) + "'";


            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dst);

                //  AKUM
            }
            catch
            {
                throw;
            }

            return (dst);
        }



     
      



        //SearchSubscribersByUsername change this function name

        // string strQueryString = "SELECT [USERID], [USERNAME], [CAFNUMBER], [CAFDOCUMENTNAME], [CAFANNEXURENAME], [IDPROOFNAME], [PHOTOFILENAME], [ADDPROOFNAME], [IDPROOFTYPE], [ADDRESSPROOFTYPE] FROM [USERMASTER] //add where clause for username";

        //  


        #region Search Subscriber based on ID

        public static DataSet SearchSubscribersByUserID(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.insadr INSADR,a.coradr CORADR,	c.packagename BILLPLAN, a.mobilenumber , a.landlinenumber LANDLINENUMBER, a.status STATUS from USERMASTER a, USERBILLINGINFO b, BILLPLANS c where a.userid=b.userid and b.billplanid=c.billplanid and a.userid like '%" + Utilities.ValidSql(pStrUserID) + "%' order by USERID";

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

        #region Subscriber Listed by Payment Type Functionality for bulk billing

        public DataSet GetSubscriberListByPaymentMode(BillCycleType type, string pStrUptoDate)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and b.billflag='T' and a.status='A' and a.status<>'T' and a.connectiondate <'"+ Utilities.ValidSql(pStrUptoDate) +"'";

            switch (type)
            {
                case BillCycleType.ALL:
                    strQueryString += " order by USERID";
                    break;
                case BillCycleType.MONTHLY:
                    strQueryString += " and b.paymentmode='M' order by USERID";
                    break;
                case BillCycleType.QUARTERLY:
                    strQueryString += " and b.paymentmode='Q' order by USERID";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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

        #region Checking for duplicate username

        public static bool UserExists(string pStrUserName)
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
            cmdcheck.CommandText = "SELECT count(*) from USERMASTER where upper(USERNAME)='" + Utilities.ValidSql(pStrUserName.ToUpper()) + "' and status in ('A','T')";
            //need to optimize it to check in registered table also for recently connected user???? to check in billing module first whether any validation is done or not

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

        #region Listing of Broadbandusers based on User STATUS   (SELECTION From Three Tables) - modified 13/may/2010 -hopeto

        public static DataSet BroadbandUserList(BroadbandUserStatus status)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.userid USERID,a.username USERNAME, a.name NAME, a.coradr ADR,	c.packagename BILLPLAN, a.emailId, a.mobilenumber CONTACTNUMBER,  a.status STATUS, a.CONNECTIONDATE, a.INSADR from USERMASTER a, USERBILLINGINFO b, BILLPLANS c where a.userid=b.userid and b.billplanid=c.billplanid";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString += " order by USERID";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " and a.status='" + "A" + "' order by USERID";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " and a.status='" + "D" + "' order by USERID";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " and a.status='" + "T" + "' order by USERID";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " and a.status='" + "P" + "' order by USERID";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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


        #region Listing of Broadbandusers documents //added 3 june 2016

        public static DataSet BroadbandUsersDocuments(BroadbandUserStatus status)
        {
            DataSet dst = new DataSet();
            string strQueryString = "SELECT [USERID], [USERNAME], [CAFNUMBER], [CAFDOCUMENTNAME], [CAFANNEXURENAME], [IDPROOFNAME], [PHOTOFILENAME], [ADDPROOFNAME], [IDPROOFTYPE], [ADDRESSPROOFTYPE] FROM [USERMASTER]";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString += " order by cafnumber desc, USERID DESC";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " where status='" + "A" + "' order by cafnumber desc, USERID DESC";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " where status='" + "D" + "' order by cafnumber desc, USERID DESC";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " where status='" + "T" + "' order by cafnumber desc, USERID DESC";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " where status='" + "P" + "' order by cafnumber desc, USERID DESC";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

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
        
        public void GetSubscriberDetailsforEdit(String pStrUserID)
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
            cmd.CommandText = "select username, name, PHOTOFILENAME,IDPROOFNAME, ADDPROOFNAME, ADDRESSPROOFTYPE, IDPROOFTYPE, CAFNUMBER, CAFDOCUMENTNAME, CAFANNEXURENAME from USERMASTER  where userid='" + Utilities.ValidSql(pStrUserID) + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    _txtUserName = dr["USERNAME"].ToString();
                    _txtName = dr["NAME"].ToString();
                    _photoThumbName = dr["PHOTOFILENAME"].ToString();
                    _idProof = dr["IDPROOFNAME"].ToString();
                    _addrsProof = dr["ADDPROOFNAME"].ToString();
                    _idProofType = dr["IDPROOFTYPE"].ToString();
                    _addrsProofType = dr["ADDRESSPROOFTYPE"].ToString();
                    _cafnumber =dr["CAFNUMBER"].ToString();
                    _cafDocumentName = dr["CAFDOCUMENTNAME"].ToString();
                    _cafAnnexureName = dr["CAFANNEXURENAME"].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }
        
        #region Listing Subscriber Bill details 

        public static DataSet GetBillDetails(String pStrBillNumber)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select * from billdetails where billnumber='" + Utilities.ValidSql(pStrBillNumber) + "'";

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

        #region Get Subcriber's Bill Number based on Subscriber ID and Bill Dates
        public static DataSet GetCustomerBillNumber(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select BILLNUMBER,BILLSTARTDATE,PAYMENTMODE,BILLENDDATE,BILLCYCLEID,cast(TOTALOUTSTANDING as decimal(10,2)) TOTALOUTSTANDING,LASTDATEOFPAYMENT from BILLDETAILS where USERID='"+Utilities.ValidSql(pStrUserID)+"' order by BILLENDDATE DESC";          
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

        #region  Functioanlity to change the Installation Address
        public void InstAddressUpdate(String pStrUserID, String pStrNewInstAddress,String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();          
            cmd.CommandText = "Update USERMASTER set INSADR=@INSADR,MODBY=@MODBY,MODON=@MODON where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(pStrNewInstAddress));
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

        #region Update Subscriber Users Details
        public void SubscriberDetailsUpdate(String pstrUserID, String pStrEmailID, String pStrLandlineNumber, String pStrMobileNumber, String pStrInstAddress, String pStrCorresAddress, String pStrModby, String pstrCustomerGSTIN)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //not allowing change of name
            cmd.CommandText = "Update USERMASTER set EMAILID=@EMAILID,LANDLINENUMBER=@LANDLINENUMBER,MOBILENUMBER=@MOBILENUMBER,INSADR=@INSADR,CORADR=@CORADR,MODBY=@MODBY,MODON=@MODON, USERGSTIN =@USERGSTIN where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(pStrEmailID));
            cmd.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNumber));
            cmd.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNumber));
            cmd.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(pStrInstAddress));
            cmd.Parameters.AddWithValue("@CORADR", Utilities.ValidSql(pStrCorresAddress));            
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmd.Parameters.AddWithValue("@USERGSTIN", Utilities.ValidSql(pstrCustomerGSTIN));
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
       
        public void UserPOPDetailsUpdate(String pstrUserID, String pStrPOPID, String pStrConnectionType, String pStrConnectionDetails)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers(pstrUserID);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Update USERMASTER set POPID=@POPID,CONNECTIONTYPE=@CONNECTIONTYPE, CONNECTIONDETAILS=@CONNECTIONDETAILS where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@POPID", pStrPOPID);
            cmd.Parameters.AddWithValue("@CONNECTIONTYPE", pStrConnectionType);
            cmd.Parameters.AddWithValue("@CONNECTIONDETAILS", Utilities.ValidSql(pStrConnectionDetails));
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
        public void GetPopName(String pstrUserID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            RegisteredBroadbandUsers reguser = new RegisteredBroadbandUsers(pstrUserID);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select POPID from USERMASTER  where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            
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

        #region Count No of Active Users
        public static String GetNumberOfUsers(BroadbandUserStatus status)
        {
            string total = ""; ;
            string strQueryString = "select distinct COUNT(USERID)from USERMASTER";

            switch (status)
            {
                case BroadbandUserStatus.ALL:
                    strQueryString+="";
                    break;
                case BroadbandUserStatus.ALLEXCEPTPERMANENTLYDISCONNECTED:
                    strQueryString += " where status!='D'";
                    break;
                case BroadbandUserStatus.ACTIVE:
                    strQueryString += " where status='A'";
                    break;
                case BroadbandUserStatus.DEACTIVATED:
                    strQueryString += " where status='D'";
                    break;
                case BroadbandUserStatus.TEMPORARILYDISCONNECTED:
                    strQueryString += " where status='T'";
                    break;
                case BroadbandUserStatus.PERMANENTLYDISCONNECTED:
                    strQueryString += " where status='P'";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strQueryString;
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    total = cmd.ExecuteScalar().ToString();
                }
                conn.Close();
               

            }
            catch
            {
                throw;
            }

            return (total);
        }
        #endregion

        #region Listing Functionality get name and id by pStrUsername 19/03/10 -hopeto

        public static string[] GetSubscriberDetails(String pStrUsername)
        {
            string[] details = new string[3];
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();

            string username = Utilities.ValidSql(pStrUsername);
            cmd1.CommandText = "select name from USERMASTER where username ='" + username + "'";
            cmd2.CommandText = "select userid from USERMASTER where username ='" + username + "'";
            cmd3.CommandText = "select mobilenumber from USERMASTER where username ='" + username + "'";

            conn.Open();
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
                details[0] = cmd1.ExecuteScalar().ToString();
                details[1] = cmd2.ExecuteScalar().ToString();
                details[2] = cmd3.ExecuteScalar().ToString();

                try
                {
                    tr = conn.BeginTransaction();
                    cmd1.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd3.Transaction = tr;
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
            return (details);
        }

        #endregion

        #region 

        public static string[] GetSubscriberDetailsandNextBillingCycle(String pStrUsername)
        {
            string[] details = new string[6];
            SqlConnection conn = null;
            SqlTransaction tr = null;

           // Dictionary<string, string> NextbilCycleDetails = new Dictionary<string, string>();     


            try
            {                conn = new SqlConnection(DBConn.GetConString());            }
            catch
            {                throw;            }

            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();

            SqlCommand cmdBillCycle = conn.CreateCommand();

            string username = Utilities.ValidSql(pStrUsername);
            cmd1.CommandText = "select name from USERMASTER where username ='" + username + "'";
            cmd2.CommandText = "select userid from USERMASTER where username ='" + username + "'";
            cmd3.CommandText = "select mobilenumber from USERMASTER where username ='" + username + "'";

            cmdBillCycle.CommandText ="select top 1 BILLCYCLEID,BILLCYCLENAME,CYCLESTARTDATE from inetbilldimapur.dbo.BILLCYCLES where BILLEDSTATUS='N' order by billcycleid asc";

            conn.Open();
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
                details[0] = cmd1.ExecuteScalar().ToString();
                details[1] = cmd2.ExecuteScalar().ToString();
                details[2] = cmd3.ExecuteScalar().ToString();

                try
                {
                    tr = conn.BeginTransaction();
                    cmd1.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd3.Transaction = tr;
                    tr.Commit();
                

                SqlDataReader dr = cmdBillCycle.ExecuteReader();
                    while (dr.Read())
                    {
                        //  NextbilCycleDetails.Add("billcycleid", dr["BILLCYCLEID"].ToString());
                        details[3] = dr["BILLCYCLEID"].ToString();
                        details[4] = dr["BILLCYCLENAME"].ToString();
                        details[5] = dr["CYCLESTARTDATE"].ToString();
                       }
                    dr.Close();
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
            return (details);
        }

        #endregion


        #region Listing Functionality get name and id by userid 19/03/10 -hopeto

        public static string GetSubscriberMobileNumber(String psUserid)
        {
            string mobilenumber="";
            SqlConnection conn = null;
            

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
           
            SqlCommand cmd3 = conn.CreateCommand();

            
            cmd3.CommandText = "select mobilenumber from USERMASTER where userid ='" + psUserid + "'";

            conn.Open();
            if (cmd3.ExecuteScalar() != DBNull.Value)
            {
              

                try
                {

                    mobilenumber = cmd3.ExecuteScalar().ToString();
              

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
            return mobilenumber;
        }

        #endregion


        #region Listing Functionality for morebytes
        public static string[] GetSubscriberInfoForMoreBytes(String pstrUsername, String pDB)
        {
            string[] details = new string[3];
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try           {                conn = new SqlConnection(DBConn.GetConStringByLocation(pDB));            }            catch            {                throw;           }       
             SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();
            cmd1.CommandText = "select name from USERMASTER where username =@username and status='A'";
            cmd1.Parameters.AddWithValue("@username", pstrUsername);
            cmd2.CommandText = "select userid from USERMASTER where username =@username";
            cmd2.Parameters.AddWithValue("@username", pstrUsername);
            cmd3.CommandText = "select billplanid from userbillinginfo where userid =(select userid from usermaster where username=@username and status='A')";
            cmd3.Parameters.AddWithValue("@username", pstrUsername);


            conn.Open();
            try
            {
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
                details[0] = cmd1.ExecuteScalar().ToString();//name
                details[1] = cmd2.ExecuteScalar().ToString(); //billplan
                details[2] = cmd3.ExecuteScalar().ToString(); //billplan
                  return (details);
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
            return (details);
            }
           
        

        #endregion

        #region Listing Functionality get name and id by pStrUsername 24 /jan /2013-hopeto

        public static string[] GetSubscriberDetailsbyUserId(String pstrUserid)
        {
            string[] details = new string[3];
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();

            string userid = Utilities.ValidSql(pstrUserid);
            cmd1.CommandText = "select name from USERMASTER where userid ='" + userid + "'";
            cmd2.CommandText = "select username from USERMASTER where userid ='" + userid + "'";
            cmd3.CommandText = "select mobilenumber from USERMASTER where userid ='" + userid + "'";

            conn.Open();
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
                details[0] = cmd1.ExecuteScalar().ToString();
                details[1] = cmd2.ExecuteScalar().ToString();
                details[2] = cmd3.ExecuteScalar().ToString();

                try
                {
                    tr = conn.BeginTransaction();
                    cmd1.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd3.Transaction = tr;
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
            return (details);
        }

        #endregion


        #region Listing Functionality of client details by pStrUsername
        public void GeClientDetails(String pStrUsername)
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
            SqlCommand cmd1 = conn.CreateCommand();


            string username = Utilities.ValidSql(pStrUsername);//a.MobileNumber as SMSMobileNumber, b.mobilenumber  as StoredMobileNumber
            cmd1.CommandText = "select a.RequestMessage,a.modon,b.name,b.userid  from smsservicerequests a, usermaster b where b.userid = @BRANCHCODE + convert(varchar,a.accountnumber) and b.username =@USERNAME";
            cmd1.Parameters.AddWithValue("@BRANCHCODE", DBConn.GetBranchCode() + "-SCLX");
             cmd1.Parameters.AddWithValue("@USERNAME", username);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    _txtName = dr["name"].ToString();
                    _txtUserID = dr["userid"].ToString();
                    _string1 = dr["RequestMessage"].ToString();
                    _string2 = dr["modon"].ToString();
                    //_string3 = dr[""].ToString();
                   // _string4 = dr[""].ToString();
                    

                }
                dr.Close();
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

        #region get the number of all the different types of subscribers 23/03/10 -hopeto

        public static int[] GetSubscribersCounts()
        {
            int[] Counts = new int[4];
            SqlConnection conn = null;
            SqlTransaction tr = null;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
            SqlCommand cmd3 = conn.CreateCommand();

            //active
            cmd1.CommandText = "select distinct COUNT(USERID)from USERMASTER where status='A'";
            //temporarily desconnected
            cmd2.CommandText = "select distinct COUNT(USERID)from USERMASTER where status='T'";
            //disconnected
            cmd3.CommandText = "select distinct COUNT(USERID)from USERMASTER where status='D'";
            conn.Open();

            Counts[0] = Convert.ToInt32(cmd1.ExecuteScalar());
            Counts[1] = Convert.ToInt32(cmd2.ExecuteScalar());
            Counts[2] = Convert.ToInt32(cmd3.ExecuteScalar());            

                try
                {
                    tr = conn.BeginTransaction();
                    cmd1.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd3.Transaction = tr;
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
                Counts[3] = Counts[0] + Counts[1] + Counts[2];
         
            return (Counts);
        }

        #endregion

        #region Listing Of Subscribers By MONTH 24/03/2010 -hopeto
        public static DataSet GetSubscribersByMonth()
        {
            DataSet dst = new DataSet();
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
           
            //string strQueryString = "SELECT COUNT(a.USERID) AS newUsers FROM  USERMASTER AS a RIGHT OUTER JOIN  BILLCYCLES AS b ON a.CONNECTIONDATE >= b.CYCLESTARTDATE AND a.CONNECTIONDATE <= b.CYCLEENDDATE WHERE (b.BILLEDSTATUS = 'y') GROUP BY b.BILLCYCLEID, b.BILLCYCLENAME ORDER BY b.BILLCYCLEID DESC, b.BILLCYCLENAME";
            //string strQueryString2 = "SELECT b.BILLCYCLENAME AS Month, COUNT(a.userid) AS allusers FROM USERMASTER AS a INNER JOIN BILLCYCLES AS b ON a.CONNECTIONDATE <= b.CYCLEENDDATE and b.billedstatus='y' GROUP BY b.BILLCYCLEID, b.BILLCYCLENAME ORDER BY b.BILLCYCLEID DESC";
            string strQueryString = "SELECT b.BILLCYCLENAME AS Month, COUNT(a.USERID) AS newUsers FROM  USERMASTER AS a RIGHT OUTER JOIN  BILLCYCLES AS b ON a.CONNECTIONDATE >= b.CYCLESTARTDATE AND a.CONNECTIONDATE <= b.CYCLEENDDATE where b.cyclestartdate < '" + System.DateTime.Now + "' GROUP BY b.BILLCYCLEID, b.BILLCYCLENAME ORDER BY b.BILLCYCLEID DESC, b.BILLCYCLENAME";
            string strQueryString2 = "SELECT b.BILLCYCLENAME AS Month, COUNT(a.userid) AS allusers FROM USERMASTER AS a INNER JOIN BILLCYCLES AS b ON a.CONNECTIONDATE <= b.CYCLEENDDATE where b.cyclestartdate < '"+ System.DateTime.Now + "'  GROUP BY b.BILLCYCLEID, b.BILLCYCLENAME ORDER BY b.BILLCYCLEID DESC";
            try
            {
                conn.Open();
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                SqlDataAdapter dad2 = new SqlDataAdapter(strQueryString2, conn);
                dad.Fill(dst, "TotalConnection");               
                dad2.Fill(dst, "NewConnection");
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            

            return (dst);
            
        }
        #endregion

        #region update photo of Client Functionality 26/03/10 -hope

        public void UpdatePhoto(String pStrUserID, String pStrPhotoThumbName, String pStrModby)
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
            SqlCommand cmduser = conn.CreateCommand(); 
            cmduser.CommandText = "update USERMASTER set PHOTOFILENAME=@PHOTOFILENAME, modby=@MODBY where userid = @userid";  
        
            cmduser.Parameters.AddWithValue("@PHOTOFILENAME", Utilities.ValidSql(pStrPhotoThumbName));            
            cmduser.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrModby));
            cmduser.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));

            try
            {
                conn.Open();
                cmduser.ExecuteNonQuery();
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

        #region update doucuments of Client Functionality 
        //26/03/10 -hope updated 4 march 2016
        
        public void UpdateDocuments(String pStrUserID, string pCAFNumber, String pStrIDProofName, String pStrAddrsProofName,  String pStrModby, string pCAFAnnexureName, string pPhotoName, string pCAFDocumentName)
        {

            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();
            bool CAFExists = true;
            SqlCommand cmdcheck = conn.CreateCommand();
            cmdcheck.CommandText = "select 'true' where EXISTS(SELECT Cafnumber from USERMASTER where CAFNUMBER=@CAFNUMBER and userid <> @USERID )";   //TO CHECK IN REGISTERED USERS OR IN USERMASTER
            cmdcheck.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmdcheck.Parameters.AddWithValue("@CAFNUMBER", Utilities.ValidSql(pCAFNumber));

            cmd.CommandText = "update USERMASTER set PHOTOFILENAME=@PHOTOFILENAME, IDPROOFNAME=@IDPROOFNAME, ADDPROOFNAME= @ADDPROOFNAME,CAFNUMBER=@CAFNUMBER, CAFANNEXURENAME=@CAFANNEXURENAME, CAFDOCUMENTNAME=@CAFDOCUMENTNAME, modby=@MODBY where USERID = @USERID";
            cmd.Parameters.AddWithValue("@CAFDOCUMENTNAME", Utilities.ValidSql(pCAFDocumentName));
            cmd.Parameters.AddWithValue("@PHOTOFILENAME", Utilities.ValidSql(pPhotoName));
            cmd.Parameters.AddWithValue("@IDPROOFNAME", Utilities.ValidSql(pStrIDProofName));
            cmd.Parameters.AddWithValue("@ADDPROOFNAME", Utilities.ValidSql(pStrAddrsProofName));
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));
            cmd.Parameters.AddWithValue("@CAFNUMBER", pCAFNumber);
            cmd.Parameters.AddWithValue("@CAFANNEXURENAME", Utilities.ValidSql(pCAFAnnexureName));
            cmd.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));

            try
            {
                conn.Open();

                if (cmdcheck.ExecuteScalar() != DBNull.Value)
                {
                    CAFExists = Convert.ToBoolean((cmdcheck.ExecuteScalar()));
                }
                if (CAFExists)
                {
                    //return error message
                    ReturnMessage = "ERROR! CAF Number already exists in the application.";
                    return;
                }
                else
                {

                    cmd.ExecuteNonQuery();
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

        #region Listing Of Connected Subscriber by ID from USERMASTER Table. - MODIFIED -13/may/2010 -hopeto
        public DataSet GetConnectedSubscriberByID(String pStrUserID)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select A.NAME,A.USERNAME,A.INSADR,A.CORADR,A.REGISTRATIONDATE,A.MOBILENUMBER,A.ALTMOBILENUMBER,A.LANDLINENUMBER,A.EMAILID,B.PACKAGENAME BILLPLAN,C.PAYMENTMODE RENTALPAYMODE,A.STATUS STATUS ,A.IDPROOFTYPE,A.ADDRESSPROOFTYPE from USERMASTER A, BILLPLANS B, USERBILLINGINFO C where A.USERID=C.USERID and B.BILLPLANID=C.BILLPLANID and  A.USERID='" + Utilities.ValidSql(pStrUserID) + "'";
            
 
            //
              
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select A.PHOTOFILENAME PHOTOFILENAME,A.IDPROOFNAME IDPROOFNAMERESIZE, A.ADDPROOFNAME ADDPROOFNAMERESIZE,A.ADDRESSPROOFTYPE ADDRESSPROOFTYPE,A.IDPROOFTYPE IDPROOFTYPE, A.CAFDOCUMENTNAME CAFDOCUMENTNAME from USERMASTER A, BILLPLANS B, USERBILLINGINFO C where A.USERID=C.USERID and B.BILLPLANID=C.BILLPLANID and  A.USERID='" + Utilities.ValidSql(pStrUserID) + "'";

                conn.Open();               
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   // _photoThumbName = dr["PHOTOTHUMBNAME"].ToString();
                    _photoThumbName = dr["PHOTOFILENAME"].ToString();
                    _idProof = dr["IDPROOFNAMERESIZE"].ToString();
                    _addrsProof = dr["ADDPROOFNAMERESIZE"].ToString();
                    _cafDocumentName = dr["CAFDOCUMENTNAME"].ToString();
                    _idProofType = dr["IDPROOFTYPE"].ToString();
                    _addrsProofType = dr["ADDRESSPROOFTYPE"].ToString();
                }
                dr.Close();
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



        #region update selective documents of broadband user
        /// <summary>
        /// update selective uploaded docuements of registered user to db
        /// hopeto - 12 feb 2016
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="fileType"></param>
        /// <param name="updatedFileName"></param>
        /// <param name="FileType"></param>
        public void UpdateSelectiveDocumentsOfBroadbandUser(string userid, FILETYPE fileType, String updatedFileName, string FileTypeorCAFNo)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmd = conn.CreateCommand();


            switch (fileType)
            {
                case FILETYPE.USERPHOTO:
                    cmd.CommandText = "UPDATE USERMASTER set PHOTOFILENAME=@PHOTOFILENAME  where userid=@USERID";
                    cmd.Parameters.AddWithValue("@PHOTOFILENAME", updatedFileName);
                    break;
                case FILETYPE.IDPROOF:
                    cmd.CommandText = "UPDATE USERMASTER set IDPROOFNAME=@IDPROOFNAME, IDPROOFTYPE=@IDPROOFTYPE where userid=@USERID";
                    cmd.Parameters.AddWithValue("@IDPROOFTYPE", FileTypeorCAFNo);
                    cmd.Parameters.AddWithValue("@IDPROOFNAME", updatedFileName);
                    break;
                case FILETYPE.ADDRESSPROOF:
                    cmd.CommandText = "UPDATE USERMASTER set ADDPROOFNAME=@ADDPROOFNAME, ADDRESSPROOFTYPE=@ADDRESSPROOFTYPE  where userid=@USERID";
                    cmd.Parameters.AddWithValue("@ADDPROOFNAME", updatedFileName);
                    cmd.Parameters.AddWithValue("@ADDRESSPROOFTYPE", FileTypeorCAFNo);

                    break;
                case FILETYPE.CAFDOCUMENT:
                    cmd.CommandText = "UPDATE USERMASTER set CAFDOCUMENTNAME=@CAFDOCUMENTNAME, CAFNUMBER=@CAFNUMBER  where userid=@USERID";
                    cmd.Parameters.AddWithValue("@CAFDOCUMENTNAME", updatedFileName);
                    cmd.Parameters.AddWithValue("@CAFNUMBER", FileTypeorCAFNo);

                    break;
                case FILETYPE.CAFANNEXURE:
                    cmd.CommandText = "UPDATE USERMASTER set CAFANNEXURENAME=@CAFANNEXURENAME  where userid=@USERID";
                    cmd.Parameters.AddWithValue("@CAFANNEXURENAME", updatedFileName);
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
            cmdcheck.CommandText = "select 'true' where EXISTS(SELECT Cafnumber from USERMASTER where CAFNUMBER=@CAFNUMBER and userid <> @USERID )";
            //   cmdcheck.CommandText = "select 'true' where EXISTS(SELECT Cafnumber from REGISTEREDUSERS where CAFNUMBER='" + pCAFNumber + ")";

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
        /* #region Funtionality to permanently Delete Broadband Subscriber

        public void DeleteSubscriberPermanently(String pStrUserID, String pStrEmpID)
        {
            SqlTransaction tr = null;
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            
            SqlCommand cmda = conn.CreateCommand();
            SqlCommand cmdb = conn.CreateCommand();
            SqlCommand cmdc = conn.CreateCommand();
            SqlCommand cmdd = conn.CreateCommand();
            SqlCommand cmde = conn.CreateCommand();

            
            cmda.CommandText = "delete usermaster where userid=@USERID";
            cmda.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));

            cmdb.CommandText = "delete userbillinginfo where userid=@USERID";
            cmdb.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));

            cmdc.CommandText = "delete discountsandwaivers where userid=@USERID";
            cmdc.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));

            cmdd.CommandText = "delete subscriberledger where userid=@USERID";
            cmdd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));

            cmde.CommandText = "delete billdetails where userid=@USERID";
            cmde.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pStrUserID));    
           

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmda.Transaction = tr;
                cmdb.Transaction = tr;
                cmdc.Transaction = tr;
                cmdd.Transaction = tr;
                cmde.Transaction = tr;


                cmda.ExecuteNonQuery(); 
                cmdb.ExecuteNonQuery();
                cmdc.ExecuteNonQuery();
                cmdd.ExecuteNonQuery();
                cmde.ExecuteNonQuery();
                SystemEventLog log = new SystemEventLog();
                log.WriteEventLog(pStrEmpID, pStrUserID, "User ID:" + pStrUserID + " has been permanently deleted after confirmation");  
               
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

        #endregion */



    }
}
