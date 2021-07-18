using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Apple_Bss.CodeFile
{
    public class ServiceCallsCable
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

        public ServiceCallsCable()
        {
        }
        public ServiceCallsCable(String pStrIssueID)
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


        #region Create New ID
        private static String GetNewIssueID()
        {

            String strNewIssueID = "SRC";
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
            cmd.CommandText = "Select cast((max(substring(ISSUEID,4,5)))+1 as varchar) code from SERVICECALLRECORDCABLE";

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strNewIssueID += "10001";
                    }
                    else
                    {
                        strNewIssueID += dr["code"].ToString();
                    }
                }


                dr.Close();
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (strNewIssueID);
        }

        #endregion

        #region Add New Service Call Record

        public static string AddNewServiceCallRecord(String pStrUserID, String pStrPoPID, String pStrIssueReportedDateTime, String pStrIsseResolvedDateTime, String pStrIssueType, String pStrIssueStatement, String pStrIssueCause, String pStrActionTaken, String pStrStatus, String pStrSupportType, String pStrSystemUserID)
        {
            SqlConnection conn = null;
            SqlTransaction tr = null;
            string strNewIssueID = "";
            try
            {
                strNewIssueID = ServiceCallsCable.GetNewIssueID();
            }
            catch
            {                throw;            }

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {                throw;            }
            SqlDateTime resolvedDateTime = SqlDateTime.Null;
            if (pStrIsseResolvedDateTime != "")
            {
                resolvedDateTime = Convert.ToDateTime(pStrIsseResolvedDateTime);
            }
            SqlCommand cmdsrv = conn.CreateCommand();
            SqlCommand cmdsrlog=conn.CreateCommand();
            SqlCommand cmdsmssr = conn.CreateCommand();

            cmdsrv.CommandText = "insert SERVICECALLRECORDCABLE(issueid,userid,issuereporteddatetime,issueresolveddatetime,issuetype,issue,issuecause,systemuserid,popid,status,supporttype,modby,modon) values (@issueid,@userid,@issuereporteddatetime,@issueresolveddatetime,@issuetype,@issue,@issuecause,@systemuserid,@popid,@status,@supporttype,@modby,@modon)";
            cmdsrv.Parameters.AddWithValue("@issueid", strNewIssueID);
            cmdsrv.Parameters.AddWithValue("@userid", Utilities.ValidSql(pStrUserID));
            cmdsrv.Parameters.AddWithValue("@issuereporteddatetime", Utilities.ValidSql(pStrIssueReportedDateTime));
            cmdsrv.Parameters.AddWithValue("@issueresolveddatetime", resolvedDateTime);
            cmdsrv.Parameters.AddWithValue("@issuetype", Utilities.ValidSql(pStrIssueType));
            cmdsrv.Parameters.AddWithValue("@issue", Utilities.ValidSql(pStrIssueStatement));
                      
            cmdsrv.Parameters.AddWithValue("@issuecause", Utilities.ValidSql(pStrIssueCause));
            cmdsrv.Parameters.AddWithValue("@systemuserid", Utilities.ValidSql(pStrSystemUserID));
            cmdsrv.Parameters.AddWithValue("@popid", Utilities.ValidSql(pStrPoPID));
            cmdsrv.Parameters.AddWithValue("@status", Utilities.ValidSql(pStrStatus));
            cmdsrv.Parameters.AddWithValue("@supporttype", Utilities.ValidSql(pStrSupportType));
            cmdsrv.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdsrv.Parameters.AddWithValue("@modon", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            cmdsrlog.CommandText = "insert SERVICEREQUESTLOGS (issueid,actiontaken,modby,modon) values (@issueid,@actiontaken,@modby,@modon)";
            cmdsrlog.Parameters.AddWithValue("@issueid", strNewIssueID);
            cmdsrlog.Parameters.AddWithValue("@actiontaken", Utilities.ValidSql(pStrActionTaken));
            cmdsrlog.Parameters.AddWithValue("@modby", Utilities.ValidSql(pStrSystemUserID));
            cmdsrlog.Parameters.AddWithValue("@modon", Utilities.ValidSql(pStrIssueReportedDateTime));

         

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

            return strNewIssueID;

        }

        #endregion

    }
}
