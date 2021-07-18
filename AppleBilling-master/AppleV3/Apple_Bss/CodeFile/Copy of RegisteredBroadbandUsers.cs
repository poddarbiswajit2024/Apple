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
        protected String _txtAddressProof;
        protected String _txtIdProof;
        protected String _txtPhotoThumbName;
        protected String _txtIdProofNameResize;
        protected String _txtAddressProofNameResize;

        public string AddressProof
        {
            get { return _txtAddressProof; }
            set { _txtAddressProof = value; }
        }
                     
        public string IDProof
        {
            get { return _txtIdProof; }
            set { _txtIdProof = value; }
        }
        public string PhotoThumbName
        {
            get { return _txtPhotoThumbName; }
            set { _txtPhotoThumbName = value; }
        }
        public string IDProofNameResize
        {
            get { return _txtIdProofNameResize; }
            set { _txtIdProofNameResize = value; }
        }
        public string AddressProofNameResize
        {
            get { return _txtAddressProofNameResize; }
            set { _txtAddressProofNameResize = value; }
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
            _txtAddressProof = String.Empty;
            _txtAddressProofNameResize = String.Empty;
            _txtIdProof = String.Empty;
            _txtIdProofNameResize = String.Empty;
            _txtPhotoThumbName = String.Empty;
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
            cmd.CommandText = "SELECT USERID,NAME,USERNAME,PASSWORD,INSADR,CORADR,REGISTRATIONDATE,CONNECTIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON,IDPROOF,IDPROOFNAMERESIZE,ADDRESSPROOF,ADDPROOFNAMERESIZE,PHOTOTHUMBNAME from REGISTEREDUSERS where userid='" + pStrUserID + "'";

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
                    _txtAddressProof=dr["ADDRESSPROOF"].ToString();
                    _txtAddressProofNameResize=dr["ADDPROOFNAMERESIZE"].ToString();
                    _txtIdProof=dr["IDPROOF"].ToString();
                    _txtIdProofNameResize=dr["IDPROOFNAMERESIZE"].ToString();
                    _txtPhotoThumbName=dr["PHOTOTHUMBNAME"].ToString();;
                    
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
        
         
        #region Listing Of Subscriber by ID
        public static DataSet GetRegisteredSubscriberByID(String pStrUserID)
        {
            DataSet dst = new DataSet();

            string strQueryString = "select A.NAME,A.USERNAME,A.INSADR,A.CORADR,A.REGISTRATIONDATE,A.MOBILENUMBER,A.ALTMOBILENUMBER,A.LANDLINENUMBER,A.EMAILID,A.EMPID,B.PACKAGENAME BILLPLAN, RENTALPAYMODE,A.STATUS STATUS,A.ADDRESSPROOF,A.IDPROOF,A.MODBY from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID and USERID='" + Utilities.ValidSql(pStrUserID) + "'";
           
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

        #region Listing Functionality pending Connections

        public static DataSet GetPendingConnections()
        {
            DataSet dst = new DataSet();

            string strQueryString = "select USERID,NAME,INSADR,CORADR,REGISTRATIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID,ADDRESSPROOF,IDPROOF,PHOTOTHUMBNAME,IDPROOFNAMERESIZE,ADDPROOFNAMERESIZE, A.BILLPLANID,B.PACKAGENAME BILLPLAN, RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,A.STATUS STATUS,REMARKS,A.MODBY,A.MODON from REGISTEREDUSERS A, BILLPLANS B where  A.BILLPLANID=B.BILLPLANID AND A.STATUS='P' order by REGISTRATIONDATE desc";


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
        public void UpdateCustProfileDetails(String pstrUserID,String pStrName,String pStrInsAdr,String pStrCorAdr, String pStrLandlineNo, String pStrMobileNo, String pStrEmailID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set NAME=@NAME,CORADR=@CORADR,INSADR=@INSADR,LANDLINENUMBER=@LANDLINENUMBER,MOBILENUMBER=@MOBILENUMBER, EMAILID=@EMAILID where USERID=@USERID";
           
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@NAME",Utilities.ValidSql(pStrName));
            cmd.Parameters.AddWithValue("CORADR", Utilities.ValidSql(pStrCorAdr));
            cmd.Parameters.AddWithValue("@INSADR", Utilities.ValidSql(pStrInsAdr));
            cmd.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNo));
            cmd.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNo));
            cmd.Parameters.AddWithValue("@EMAILID", Utilities.ValidSql(pStrEmailID));
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
        public void UpdateBillPlanDetails(String pstrUserID, String pStrBillPlanID, String pStrRentalPayMode,String pStrORTCID)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set OTRCID=@OTRCID,BILLPLANID=@BILLPLANID,RENTALPAYMODE=@RENTALPAYMODE where USERID=@USERID";

            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            cmd.Parameters.AddWithValue("@BILLPLANID", Utilities.ValidSql(pStrBillPlanID));
            cmd.Parameters.AddWithValue("@RENTALPAYMODE", Utilities.ValidSql(pStrRentalPayMode));
            cmd.Parameters.AddWithValue("@OTRCID", Utilities.ValidSql(pStrORTCID));           
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

        public void RegisterSubscriber(String pStrCustomerName, String pStrInstallationAddress, String pStrCorrespondenceAddress, String pStrRegistrationDate, String pStrMobileNumber, String pStrAltMobileNumber, String pStrLandlineNumber, String pStrEmail, String pStrbillplanid, String pStrRentalPaymentmode, String pStrOTRCPaymentmode, Int32 pInt32Priority, String pStrRegisteredByEmpID, String pStrAgentCode, String pStrIsAgentAccount, String pStrRemarks, String pStrModby, String pStrAddrsProof, String pStrIDProof, String pStrPhotoThumbName, String idproofimgname, String addproofimgname)
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
      
            SqlCommand cmduser = conn.CreateCommand();
            //insert into registered subscriber table
            cmduser.CommandText = "insert REGISTEREDUSERS (USERID,NAME,INSADR,CORADR,REGISTRATIONDATE,MOBILENUMBER,ALTMOBILENUMBER,LANDLINENUMBER,EMAILID, BILLPLANID,RENTALPAYMODE,OTRCID,PRIORITY,EMPID,AGENTCODE,ISAGENTACCOUNT,STATUS,REMARKS,MODBY,MODON, ADDRESSPROOF, IDPROOF, PHOTOTHUMBNAME, IDPROOFNAMERESIZE, ADDPROOFNAMERESIZE) values (@USERID,@NAME,@INSADR,@CORADR,@REGISTRATIONDATE,@MOBILENUMBER,@ALTMOBILENUMBER,@LANDLINENUMBER,@EMAILID,@BILLPLANID,@RENTALPAYMODE,@OTRCID,@PRIORITY,@EMPID,@AGENTCODE,@ISAGENTACCOUNT,@STATUS,@REMARKS,@MODBY,@MODON, @ADDRESSPROOF, @IDPROOF, @PHOTOTHUMBNAME,@IDPROOFNAMERESIZE,@ADDPROOFNAMERESIZE)";

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
            cmduser.Parameters.AddWithValue("@STATUS", "P");
            cmduser.Parameters.AddWithValue("@REMARKS", Utilities.ValidSql(pStrRemarks));
            cmduser.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmduser.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            cmduser.Parameters.AddWithValue("@ADDRESSPROOF", Utilities.ValidSql(pStrAddrsProof));
            cmduser.Parameters.AddWithValue("@IDPROOF", Utilities.ValidSql(pStrIDProof));
            cmduser.Parameters.AddWithValue("@PHOTOTHUMBNAME", Utilities.ValidSql(pStrPhotoThumbName));
            cmduser.Parameters.AddWithValue("@IDPROOFNAMERESIZE", Utilities.ValidSql(idproofimgname));
            cmduser.Parameters.AddWithValue("@ADDPROOFNAMERESIZE", Utilities.ValidSql(addproofimgname));

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

        #region Connect Client Funtionality Update REGISTEREDUSERS TABLE by Network Manager
        
        public void ConnectClientUser(String pstrUserID, String pStrCustName, String pStrConnDate, String pStrUserName, String pStrPassword,String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmd = conn.CreateCommand();
            //UPDATE NEWS
            cmd.CommandText = "UPDATE REGISTEREDUSERS set USERNAME=@USERNAME,PASSWORD=@PASSWORD,CONNECTIONDATE=@CONNECTIONDATE,STATUS=@STATUS,ISBILLRAISED=@ISBILLRAISED,MODBY=@MODBY,MODON=@MODON where USERID=@USERID";
            cmd.Parameters.AddWithValue("@USERID", Utilities.ValidSql(pstrUserID));
            //cmd.Parameters.AddWithValue("@CUSTNAME", Utilities.ValidSql(pStrCustName));
            cmd.Parameters.AddWithValue("@USERNAME", Utilities.ValidSql(pStrUserName));
            cmd.Parameters.AddWithValue("@PASSWORD", Utilities.ValidSql(Encryption.encrypt(pStrPassword, 20)));
            cmd.Parameters.AddWithValue("@CONNECTIONDATE", Utilities.ValidSql(pStrConnDate));
            cmd.Parameters.AddWithValue("@STATUS", "C");
            cmd.Parameters.AddWithValue("@ISBILLRAISED", "F");
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


    }
}
