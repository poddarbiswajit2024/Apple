using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Apple_Bss.CodeFile
{
    public class ServiceCalls
    {


        #region Class Members & Accessor functions

        protected string _issueID;
        protected string _userID;
        protected string _reportedDate;
        protected string _issueResolvedDate;
        protected string _startTime;
        protected string _endTime;
        protected string _issueType;
        protected string _issue;
        protected string _issueCause;
        protected string _issueAssignedTo;
        protected string _actionTaken;
        protected string _systemUserID;
        protected string _popID;
        protected string _status;
        protected string _supportType;
        protected string _modby;
        protected string _modOn;


        public string IssueID
        {
            get { return _issueID; }
            set { _issueID = value; }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string ReportedDate
        {
            get { return _reportedDate; }
            set { _reportedDate = value; }
        }

        public string ResolvedDate
        {
            get { return _issueResolvedDate; }
            set { _issueResolvedDate = value; }
        }

        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public string IssueType
        {
            get { return _issueType; }
            set { _issueType = value; }
        }

        public string Issue
        {
            get { return _issue; }
            set { _issue = value; }
        }

        public string IssueCause
        {
            get { return _issueCause; }
            set { _issueCause = value; }
        }

        public string IssueAssignedTo
        {
            get { return _issueAssignedTo; }
            set { _issueAssignedTo = value; }
        }

        public string ActionTaken
        {
            get { return _actionTaken; }
            set { _actionTaken = value; }
        }

        public string SystemUserID
        {
            get { return _systemUserID; }
            set { _systemUserID = value; }
        }

        public string PoPID
        {
            get { return _popID; }
            set { _popID = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string SupportType
        {
            get { return _supportType; }
            set { _supportType = value; }
        }

        public string ModBy
        {
            get { return _modby; }
            set { _modby = value; }
        }

        public string ModOn
        {
            get { return _modOn; }
            set { _modOn = value; }
        }

        public ServiceCalls()
        {
        }
        public ServiceCalls(String pStrIssueID)
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
            cmd.CommandText = "select issueid,userid,popid,issue,issuecause,supporttype,issuetype,systemuserid,issueassignedto,issuereporteddatetime,issueresolveddatetime,status,modby,modon from servicecallrecord where issueid ='" + Utilities.ValidSql(pStrIssueID) + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    _issueID = dr["issueid"].ToString();
                    _userID = dr["userid"].ToString();
                    _reportedDate = dr["issuereporteddatetime"].ToString();
                    _issueResolvedDate = dr["issueresolveddatetime"].ToString();
                    _issueType = dr["issuetype"].ToString();
                    _issue = dr["issue"].ToString();
                    _issueCause = dr["issuecause"].ToString();
                    _issueAssignedTo = dr["issueassignedto"].ToString();
                    _systemUserID = dr["systemuserid"].ToString();
                    _popID = dr["popid"].ToString();
                    _status = dr["status"].ToString();
                    _supportType = dr["supporttype"].ToString();
                    _modby = dr["modby"].ToString();
                    _modOn = dr["modon"].ToString();
                    
                    
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


        #region Create New PoP Code Functionality

        //private static String GetNewIssueID()
        //{

        //    String strNewIssueID = "SRV";
        //    SqlConnection conn;

        //    try
        //    {
        //        conn = new SqlConnection(DBConn.GetConString());
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = "Select cast((max(substring(ISSUEID,4,5)))+1 as varchar) code from SERVICECALLRECORD";

        //    try
        //    {
        //        conn.Open();

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            if (dr["code"] != DBNull.Value)
        //            {
        //                strNewIssueID += dr["code"].ToString();

        //            }
        //            else
        //            {
        //                strNewIssueID += "10001";
        //            }
        //        }


        //        dr.Close();
        //        conn.Close();

        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    return (strNewIssueID);
        //}

        #endregion

        #region Add New Service Call Record

        public static string AddNewServiceCallRecord(String pStrUserID, String pStrPoPID, String pStrIssueReportedDateTime, String pStrIsseResolvedDateTime, String pStrIssueType, String pStrIssueStatement, String pStrIssueCause, String pStrActionTaken, String pStrStatus, String pStrSupportType, String pStrSystemUserID)
        {

            SqlConnection conn = null;
            SqlTransaction tr = null;
           
            string strNewIssueID = "";

            //try
            //{
            //    strNewIssueID = ServiceCalls.GetNewIssueID();
            //}
            //catch
            //{
            //    throw;
            //}

            try
            {              
                conn = new SqlConnection(DBConn.GetConString());
             
            }
            catch
            {
                throw;
            }
           
            SqlDateTime resolvedDateTime = SqlDateTime.Null;

            if (pStrIsseResolvedDateTime != "")
            {
                resolvedDateTime = Convert.ToDateTime(pStrIsseResolvedDateTime);
            }

        

            SqlCommand cmdsrv = conn.CreateCommand();
            SqlCommand cmdsrlog = conn.CreateCommand();
            SqlCommand cmdsmssr = conn.CreateCommand();
            SqlCommand cmd = conn.CreateCommand();


            cmd.CommandText = "Select cast((max(substring(ISSUEID,4,5)))+1 as varchar) code from SERVICECALLRECORD";

           

            strNewIssueID = "SRV";

            conn.Open();
            cmd.Transaction = tr;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["code"] != DBNull.Value)
                {
                    strNewIssueID += dr["code"].ToString();

                }
                else
                {
                    strNewIssueID += "10001";
                }
            }
            dr.Close();
         
            
            cmdsrv.CommandText = "insert SERVICECALLRECORD (issueid,userid,issuereporteddatetime,issueresolveddatetime,issuetype,issue,issuecause,systemuserid,popid,status,supporttype,modby,modon) values (@issueid,@userid,@issuereporteddatetime,@issueresolveddatetime,@issuetype,@issue,@issuecause,@systemuserid,@popid,@status,@supporttype,@modby,@modon)";
            cmdsrv.Parameters.AddWithValue("@issueid", strNewIssueID);
            cmdsrv.Parameters.AddWithValue("@userid", pStrUserID);
            cmdsrv.Parameters.AddWithValue("@issuereporteddatetime", pStrIssueReportedDateTime);
            cmdsrv.Parameters.AddWithValue("@issueresolveddatetime", resolvedDateTime);
            cmdsrv.Parameters.AddWithValue("@issuetype",pStrIssueType);
            cmdsrv.Parameters.AddWithValue("@issue", pStrIssueStatement);
                      
            cmdsrv.Parameters.AddWithValue("@issuecause",pStrIssueCause);
            cmdsrv.Parameters.AddWithValue("@systemuserid",pStrSystemUserID);
            cmdsrv.Parameters.AddWithValue("@popid", pStrPoPID);
            cmdsrv.Parameters.AddWithValue("@status",pStrStatus);
            cmdsrv.Parameters.AddWithValue("@supporttype", pStrSupportType);
            cmdsrv.Parameters.AddWithValue("@modby", pStrSystemUserID);
            cmdsrv.Parameters.AddWithValue("@modon",System.DateTime.Now.ToString("MM-dd-yyyy"));

            cmdsrlog.CommandText = "insert  SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon) values (@issueid,@actiontaken,@modby,@modon)";
            cmdsrlog.Parameters.AddWithValue("@issueid", strNewIssueID);
            cmdsrlog.Parameters.AddWithValue("@actiontaken", pStrActionTaken);
            cmdsrlog.Parameters.AddWithValue("@modby", pStrSystemUserID);
            cmdsrlog.Parameters.AddWithValue("@modon", pStrIssueReportedDateTime);


            try
            {
               // conn.Open();
                tr = conn.BeginTransaction();
                cmdsrv.Transaction = tr;
                cmdsrlog.Transaction = tr;
                cmdsrv.ExecuteNonQuery();             
                cmdsrlog.ExecuteNonQuery();

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

            return strNewIssueID;

        }

        #endregion

        #region Update Service Call Record for sms support

        public static void updateServiceCallRecord(String psIssueID, String pStrUserID, String pStrPoPID, String pStrIsseResolvedDateTime, String pStrIssueType, String pStrIssueStatement, String pStrIssueAssignedTo, String pStrIssueCause, String pStrActionTaken, String pStrStatus, String pStrSupportType, String pStrSystemUserID)
        {

            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            SqlTransaction tr = null;
          
            
            SqlDateTime resolvedDateTime = SqlDateTime.Null;

            if (pStrIsseResolvedDateTime != "")
            {
                resolvedDateTime = Convert.ToDateTime(pStrIsseResolvedDateTime);
            }



            SqlCommand cmdsrv = conn.CreateCommand();
            SqlCommand cmdsrlog = conn.CreateCommand();
            SqlCommand cmdsmssr = conn.CreateCommand();

            cmdsrv.CommandText = "update SERVICECALLRECORD set issueresolveddatetime=@issueresolveddatetime,issuetype=@issuetype,issue=@issue,issueassignedto=@issueassignedto,issuecause=@issuecause,systemuserid =@systemuserid,popid=@popid,status=@status,supporttype=@supporttype,modby=@modby,modon=@modon where issueid=@issueid";

            cmdsrv.Parameters.AddWithValue("@issueid", psIssueID);
            cmdsrv.Parameters.AddWithValue("@issueresolveddatetime", resolvedDateTime);
            cmdsrv.Parameters.AddWithValue("@issuetype",pStrIssueType);
            cmdsrv.Parameters.AddWithValue("@issue", pStrIssueStatement);
            cmdsrv.Parameters.AddWithValue("@issueassignedto", pStrIssueAssignedTo);
            cmdsrv.Parameters.AddWithValue("@issuecause", pStrIssueCause);
            cmdsrv.Parameters.AddWithValue("@systemuserid", pStrSystemUserID);
            cmdsrv.Parameters.AddWithValue("@popid", pStrPoPID);
            cmdsrv.Parameters.AddWithValue("@status", pStrStatus);
            cmdsrv.Parameters.AddWithValue("@supporttype", pStrSupportType);
            cmdsrv.Parameters.AddWithValue("@modby", pStrSystemUserID);
            cmdsrv.Parameters.AddWithValue("@modon", DateTime.Now);

            cmdsrlog.CommandText = "insert SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon) values (@issueid,@actiontaken,@modby,@modon)";
            cmdsrlog.Parameters.AddWithValue("@issueid", psIssueID);
            cmdsrlog.Parameters.AddWithValue("@actiontaken", pStrActionTaken);
            cmdsrlog.Parameters.AddWithValue("@modby", pStrSystemUserID);
            cmdsrlog.Parameters.AddWithValue("@modon", DateTime.Now);

            cmdsmssr.CommandText = "update SMSServiceRequests set status =@status, modon=@modon where issueid=@issueid";
            cmdsmssr.Parameters.AddWithValue("@issueid", psIssueID);
            cmdsmssr.Parameters.AddWithValue("@status", pStrStatus);//P for Processing, R for resolved
            cmdsmssr.Parameters.AddWithValue("@ModOn", DateTime.Now);

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdsrv.Transaction = tr;
                cmdsrlog.Transaction = tr;
                cmdsrv.ExecuteNonQuery();
                cmdsrlog.ExecuteNonQuery();
                cmdsmssr.Transaction = tr;
                cmdsmssr.ExecuteNonQuery();
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

        #region Listing Subscriber Service Call Records based on Status

        public static DataSet GetServiceCallRecordsByStatus(String pStrSystemUserID, ServiceCallStatus pServiceCallStatus, Int32 pInt32Priv)
        {
            DataSet dst = new DataSet();



            string strQueryString = "select a.userid userid,b.username username,a.issue issue, a.issueassignedto issueassignedto, a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime, a.status status from servicecallrecord a, usermaster b where a.userid=b.userid ";

            switch (pServiceCallStatus)
            {
                case ServiceCallStatus.ALL:
                    strQueryString += "";
                    break;
                case ServiceCallStatus.RESOLVED:
                    strQueryString += " and a.status='R'";
                    break;
                case ServiceCallStatus.PENDING:
                    strQueryString += " and a.status='P'";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

            if (pInt32Priv > 1)
            {
                strQueryString += "and a.systemuserid='" + pStrSystemUserID + "' ORDER BY a.userid";
            }
            else if (pInt32Priv <= 1)
            {
                strQueryString += "ORDER BY a.userid";
            }

            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());             
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                conn.Open();
                dad.Fill(dst);
                conn.Close();

            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return (dst);
        }

        #endregion


        public static String GetSRNumber(String pStrUserID, String pStrLoggedDateTime)
        {
            String issueid = String.Empty;

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
            cmd.CommandText = "SELECT issueid from servicecallrecord where USERID='" + Utilities.ValidSql(pStrUserID) + "' and ISSUEREPORTEDDATETIME='" + Utilities.ValidSql(pStrLoggedDateTime) + "'";

            conn.Open();

            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                issueid = cmd.ExecuteScalar().ToString();
            }

            return (issueid);

        }

        /// <summary>
        /// Close issue from technical team. status = C. till customer care head makes it R
        /// </summary>
        /// <param name="pStrIssueID"></param>
        /// <param name="pStrEndDateTime"></param>
        public static void FixedIssueRegister(String pStrIssueID, String pStrEndDateTime, String psSupportType)
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
            cmd.CommandText = "UPDATE servicecallrecord set status='F',supporttype='" + Utilities.ValidSql(psSupportType) + "', issueresolveddatetime='" + Utilities.ValidSql(pStrEndDateTime) + "' where Issueid='" + Utilities.ValidSql(pStrIssueID) + "'";

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

        #region Listing Subscriber Service Call Records based on Status and Date Range // For Direct Support

        public static DataSet GetServiceRequests(String pStrStartDate, String pStrEndDate,ServiceCallStatus pServiceCallStatus,String pStrServiceEmpId)
        {
            
            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, b.username username,a.issue issue, a.issueassignedto issueassignedto, c.name assignedtotechsupport,a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime, case when a.status ='P' then 'PENDING' else 'RESOLVED' end  status from servicecallrecord a, usermaster b, systemusermaster c where a.userid=b.userid  and a.issueassignedto=c.empid  and a.issuereporteddatetime between '" + Utilities.ValidSql(Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy")) + "' and '" + Utilities.ValidSql(Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy")) + "'and a.issueassignedto='"+Utilities.ValidSql(pStrServiceEmpId)+"'";

            //case when c.status ='P' then 'PENDING' else 'RESOLVED' end

            switch (pServiceCallStatus)
            {
                case ServiceCallStatus.ALL:
                    strQueryString += " ";
                    break;
                case ServiceCallStatus.RESOLVED:
                    strQueryString += " and a.status='R'";
                    break;
                case ServiceCallStatus.PENDING:
                    strQueryString += " and a.status='P'";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

            strQueryString += " order by a.modon asc";

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

        #region Listing Subscriber Service Call Records based on Status and Date Range // For Help Desk

        public static DataSet GetServiceRequestsForHelpDesk(String pStrStartDate, String pStrEndDate, ServiceCallStatus pServiceCallStatus)
        {

            DataSet dst = new DataSet();
            
            string strQueryString = "select a.issueid issueid, a.userid userid, b.username username,a.issue issue,  a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime, case when a.status ='P' then 'PENDING' when a.status='F' then 'FIXED' else 'RESOLVED' end  status from servicecallrecord a, usermaster b where a.userid=b.userid and a.issuereporteddatetime between '" + Utilities.ValidSql(Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy")) + "' and '" + Utilities.ValidSql(Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy")) + "'";
            
            switch (pServiceCallStatus)
            {
                case ServiceCallStatus.ALL:
                    strQueryString += " ";
                    break;
                case ServiceCallStatus.RESOLVED:
                    strQueryString += " and a.status='R'";
                    break;
                    case ServiceCallStatus.FIXED:
                    strQueryString += " and a.status='F'";
                    break;
                case ServiceCallStatus.PENDING:
                    strQueryString += " and a.status='P'";
                    break;
                default:
                    
                    throw new Exception("Error: Invalid Type Key");
            }

            strQueryString += " order by a.modon asc";

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

        #region Listing Subscriber Call Record Based on Status  For n/w Management -modified april 8 10- based on to whom it was assigned
        
        public static DataSet GetNmServiceRequests(String pStrStartDate, String pStrEndDate, ServiceCallStatus pServiceCallStatus,String pStrModBy)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, b.username username,a.issue issue,a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime,datediff(mi,a.issuereporteddatetime,a.issueresolveddatetime) resolvedtimetaken, case a.status when 'P' then 'PENDING' when 'R' then 'RESOLVED' end status  from servicecallrecord a, usermaster b where a.userid=b.userid and a.issuereporteddatetime between '" + Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy") + "' and '" + Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy") + "' and a.issueassignedto='" + Utilities.ValidSql(pStrModBy) + "'";
            
            switch (pServiceCallStatus)
            {
                case ServiceCallStatus.ALL:
                    strQueryString += " ";
                    break;
                case ServiceCallStatus.RESOLVED:
                    strQueryString += " and a.status='R'";
                    break;
                case ServiceCallStatus.PENDING:
                    strQueryString += " and a.status='P'";
                    break;
                default:
                    throw new Exception("Error: Invalid Type Key");
            }

            strQueryString += " order by a.modon asc";

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

        #region Service Call Record Listing Based on Issue ID

        public static DataSet GetNmServiceRequestDetail(String pStrIssueId)
        {

            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, b.username username,a.issue issue,a.issuecause issuecause,a.issuetype issuetype,a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime,a.status status,a.issueassignedto issueassignedto, c.name assignedtotechsupport from servicecallrecord a, usermaster b, systemusermaster c where a.userid=b.userid and a.issueassignedto=c.empid and a.modby=c.empid and a.issueid='"+Utilities.ValidSql(pStrIssueId)+"'";
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

        #region List all pending service request for all // For Direct Support

        public static DataSet GetPendingServiceRequests()
        {

            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, b.username username,a.issue issue,a.issuereporteddatetime startdatetime from servicecallrecord a, usermaster b where a.userid=b.userid and a.status='P' order by a.modon desc";
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

        #region List all fixed service request for all // For Customer care

        public  DataSet GetFixedServiceRequestList()
        {

            DataSet dst = new DataSet();
            string strQueryString = "exec GetServiceRequestList 'F'";
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

        #region Add New Service Call Record

        public void UpdateServiceRequest(String psIssueID,  String pStrActionTaken, String pStrStatus, String pStrSystemUserID, String pStrActionTime)
        {

            SqlConnection conn = null;
            SqlTransaction tr = null;
            conn = new SqlConnection(DBConn.GetConString());
          SqlCommand cmdsrv = conn.CreateCommand();
            SqlCommand cmdsrlog = conn.CreateCommand();
            SqlCommand cmdsmssr = conn.CreateCommand();

            cmdsrv.CommandText = "update SERVICECALLRECORD set status=@status,modby=@modby,modon=@modon where issueid=@issueid";

            cmdsrv.Parameters.AddWithValue("@issueid", psIssueID);       
            cmdsrv.Parameters.AddWithValue("@status", pStrStatus);   
            cmdsrv.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdsrv.Parameters.AddWithValue("@modon", DateTime.Now);

            cmdsrlog.CommandText = "insert SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon) values (@issueid,@actiontaken,@modby,@modon)";
            cmdsrlog.Parameters.AddWithValue("@issueid", psIssueID);
            cmdsrlog.Parameters.AddWithValue("@actiontaken", Utilities.ValidSql(pStrActionTaken));
            cmdsrlog.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdsrlog.Parameters.AddWithValue("@modon", Utilities.ValidSql(pStrActionTime));
            cmdsrlog.Parameters.AddWithValue("@status", pStrStatus);



            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdsrv.Transaction = tr;
                cmdsrlog.Transaction = tr;
                cmdsrv.ExecuteNonQuery();
                cmdsrlog.ExecuteNonQuery();
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


        #region Listing Cable Service Call Records based on Status and Date Range For Help Desk 
        //15 march 2016

        public static DataSet GetCableServiceRequestsForHelpDesk(String pStrStartDate, String pStrEndDate, ServiceCallStatus pServiceCallStatus)
        {
            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, a.issue issue,  a.issuereporteddatetime startdatetime, a.issueresolveddatetime enddatetime, case when a.status ='P' then 'PENDING' when a.status='F' then 'FIXED' else 'RESOLVED' end  status from servicecallrecord a where issuetype in('CP', 'CC') and  a.issuereporteddatetime between '" + Utilities.ValidSql(Convert.ToDateTime(pStrStartDate).ToString("MM-dd-yyyy")) + "' and '" + Utilities.ValidSql(Convert.ToDateTime(pStrEndDate).ToString("MM-dd-yyyy")) + "'";
            switch (pServiceCallStatus)
            {
                case ServiceCallStatus.ALL:
                    strQueryString += " ";
                    break;
                case ServiceCallStatus.RESOLVED:
                    strQueryString += " and a.status='R'";
                    break;
                case ServiceCallStatus.FIXED:
                    strQueryString += " and a.status='F'";
                    break;
                case ServiceCallStatus.PENDING:
                    strQueryString += " and a.status='P'";
                    break;
                default:

                    throw new Exception("Error: Invalid Type Key");
            }
            strQueryString += " order by a.modon asc";
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


        #region List all pending service request for all // For Direct Support

        public static DataSet GetCablePendingServiceRequests()
        {

            DataSet dst = new DataSet();
            string strQueryString = "select a.issueid issueid, a.userid userid, a.issue issue,a.issuereporteddatetime startdatetime from servicecallrecord a where issuetype in('CP', 'CC') and  a.status='P' order by a.modon asc";
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
