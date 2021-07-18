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
    public class BroadbandAgents
    {
        protected String _txtAgentCode;
        protected String _txtAgentName;
        protected String _txtContactNumber;
        protected String _txtAddress;        
        protected String _txtStatus;
        protected String _txtModby;
        protected String _txtModOn;

        public string AgentCode
        {
            get { return _txtAgentCode; }
            set { _txtAgentCode = value; }
        }

        public string AgentName
        {
            get { return _txtAgentName; }
            set { _txtAgentName = value; }
        }

        public string ContactNumber
        {
            get { return _txtContactNumber; }
            set { _txtContactNumber = value; }
        }

        public string Address
        {
            get { return _txtAddress; }
            set { _txtAddress = value; }
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

        #region Class Constructors
        
        public BroadbandAgents()
        {
            _txtAgentCode=String.Empty;
            _txtAgentName=String.Empty;
            _txtContactNumber=String.Empty;
            _txtAddress=String.Empty;        
            _txtStatus=String.Empty;
            _txtModby=String.Empty;
            _txtModOn=String.Empty;
        }


        public BroadbandAgents(String pStrAgentCode)
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
            cmd.CommandText = "select agentcode,agentname,contactnumber,address,status,modby,modon from agentmaster where agentcode ='" + pStrAgentCode + "'";

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    _txtAgentCode = dr["AGENTCODE"].ToString();
                    _txtAgentName = dr["AGENTNAME"].ToString();
                    _txtContactNumber = dr["CONTACTNUMBER"].ToString();
                    _txtAddress = dr["ADDRESS"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    _txtModby = dr["MODBY"].ToString();
                    _txtModOn = dr["MODON"].ToString();
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

        private String GetNewAgentCode()
        {
            
            String strNewUserCode = DBConn.GetBranchCode();
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
            cmd.CommandText = "Select cast((max(substring(AGENTCODE,4,5)))+1 as varchar) code from AGENTMASTER";
            
            try
            {
                conn.Open();
                
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                    {
                        if (dr["code"] == DBNull.Value)
                        {
                            strNewUserCode += "10001";
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

        #region Register Agent Functionality
        
        public void RegisterAgents(String pStrAgentName, String pStrAgentAddress, String pStrContactNumber, String pStrModby)
        {

            SqlConnection conn = null;
            string strNewUserCode = "";

            try
            {
                strNewUserCode += this.GetNewAgentCode();
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


            SqlCommand cmdAgent = conn.CreateCommand();
        
            //insert into AGENTMASTER table

            cmdAgent.CommandText = "insert AGENTMASTER (AGENTCODE,AGENTNAME,CONTACTNUMBER,ADDRESS,STATUS,MODBY,MODON) values (@AGENTCODE,@AGENTNAME,@CONTACTNUMBER,@ADDRESS,@STATUS,@MODBY,@MODON)";

            cmdAgent.Parameters.AddWithValue("@AGENTCODE", Utilities.ValidSql(strNewUserCode));
            cmdAgent.Parameters.AddWithValue("@AGENTNAME", Utilities.ValidSql(pStrAgentName));
            cmdAgent.Parameters.AddWithValue("@CONTACTNUMBER", Utilities.ValidSql(pStrContactNumber));
            cmdAgent.Parameters.AddWithValue("@ADDRESS", Utilities.ValidSql(pStrAgentAddress));
            cmdAgent.Parameters.AddWithValue("@STATUS", "A");
            cmdAgent.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdAgent.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            try
            {
                conn.Open();
                cmdAgent.ExecuteNonQuery();
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

        #region Listing Functionality for both active and deactive agents

        public static DataSet GetAllAgents()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select agentcode,agentname,contactnumber,address,status,modby,modon from agentmaster where status in ('A','D')";

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

        #region Listing Functionality only active agents 16/03/10 - hopeto

        public static DataSet GetActiveAgents()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select agentcode,agentname from agentmaster where status='A'";

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

        #region Update Agent Funtionality
       
        public void AgentUpdate(String pstrAgentCode,String pStrAgentName, String pStrAgentAddress, String pStrContactNumber, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdAgent = conn.CreateCommand();
            //UPDATE NEWS
            cmdAgent.CommandText = "UPDATE AGENTMASTER set AGENTNAME=@AGENTNAME,CONTACTNUMBER=@CONTACTNUMBER,ADDRESS=@ADDRESS,STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where AGENTCODE=@AGENTCODE";

            cmdAgent.Parameters.AddWithValue("@AGENTCODE", Utilities.ValidSql(pstrAgentCode));
            cmdAgent.Parameters.AddWithValue("@AGENTNAME", Utilities.ValidSql(pStrAgentName));
            cmdAgent.Parameters.AddWithValue("@CONTACTNUMBER", Utilities.ValidSql(pStrContactNumber));
            cmdAgent.Parameters.AddWithValue("@ADDRESS", Utilities.ValidSql(pStrAgentAddress));
            cmdAgent.Parameters.AddWithValue("@STATUS", "A");
            cmdAgent.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdAgent.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdAgent.ExecuteNonQuery();
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

        #region DeActivate Agent Funtionality

        public static void AgentDeActivate(String pStrAgentCode, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdAgent = conn.CreateCommand();
            //UPDATE NEWS
            cmdAgent.CommandText = "UPDATE AGENTMASTER set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where AGENTCODE=@AGENTCODE";
            cmdAgent.Parameters.AddWithValue("@AGENTCODE", Utilities.ValidSql(pStrAgentCode));
            cmdAgent.Parameters.AddWithValue("@STATUS", "D");
            cmdAgent.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdAgent.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdAgent.ExecuteNonQuery();
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

        #region Activate Agent Funtionality
       
        public static void AgentActivate(String pStrAgentCode, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdAgent = conn.CreateCommand();
            //UPDATE NEWS
            cmdAgent.CommandText = "UPDATE AGENTMASTER set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where AGENTCODE=@AGENTCODE";
            cmdAgent.Parameters.AddWithValue("@AGENTCODE", Utilities.ValidSql(pStrAgentCode));
            cmdAgent.Parameters.AddWithValue("@STATUS", "A");
            cmdAgent.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdAgent.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdAgent.ExecuteNonQuery();
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

        #region Delete Agent Permanently
       
        public static void AgentDeleteByAgentCode(string pStrAgentCode)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());
            SqlCommand cmdAgent = conn.CreateCommand();
            cmdAgent.CommandText = "Delete from AGENTMASTER Where AGENTCODE=@AGENTCODE";
            cmdAgent.Parameters.AddWithValue("@AGENTCODE",Utilities.ValidSql(pStrAgentCode));
            try
            {
                conn.Open();
                cmdAgent.ExecuteNonQuery();
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
