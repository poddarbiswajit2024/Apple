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
    public class Pop
    {

        #region POP Getter ans Setter methods

        protected String _txtPopID;
        protected String _txtPopName;
        protected String _txtPopAddress;
        protected String _txtContactPerson;
        protected String _txtMobileNo;
        protected String _txtLandlineNo;
        protected String _txtStatus;
        protected String gpdip;
        protected String bpdip;
        protected string _lastL1sms;
        protected string _lastL2sms;
        protected string _lastL3sms;
        protected string _locationCode;

        public string PopID
        {
            get { return _txtPopID; }
            set { _txtPopID = value; }
        }

        public string PopName
        {
            get { return _txtPopName; }
            set { _txtPopName = value; }
        }

        public string PopAddress
        {
            get { return _txtPopAddress; }
            set { _txtPopAddress = value; }
        }

        public string PopConatactPerson
        {
            get { return _txtContactPerson; }
            set { _txtContactPerson = value; }
        }

        public string MobileNumber
        {
            get { return _txtMobileNo; }
            set { _txtMobileNo = value; }
        }

        public string LandlineNumber
        {
            get { return _txtLandlineNo; }
            set { _txtLandlineNo = value; }
        }

        public string PopStatus
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
        }

        public string GBDIP
        {
            get { return gpdip; }
            set { gpdip = value; }
        }

        public string BPDIP
        {
            get { return bpdip; }
            set { bpdip = value; }
        }

        public string LASTL1SMS
        {
            get { return _lastL1sms; }
            set { _lastL1sms = value; }
        }
        public string LASTL2SMS
        {
            get { return _lastL2sms; }
            set { _lastL2sms = value; }
        }
        public string LASTL3SMS
        {
            get { return _lastL3sms; }
            set { _lastL3sms = value; }
        }

        public string LocationCode
        {
            get { return _locationCode; }
            set { _locationCode = value; }
        }


        #endregion

        #region Class Constructors
        public Pop()
        {
        }
       
        public Pop(string pStrPopID)
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
            SqlCommand cmdPop = conn.CreateCommand();
            cmdPop.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopID));
            cmdPop.CommandText = "SELECT POPID,POPNAME,ADDRESS,CONTACTPERSON,MOBILENUMBER,LANDLINENUMBER,STATUS,GPDIP, BPDIP, LOCATIONCODE from POPMASTER where POPID=@POPID";
            try
            {
                conn.Open();
                SqlDataReader dr = cmdPop.ExecuteReader();
                while (dr.Read())
                {
                    _txtPopID = dr["POPID"].ToString();
                    _txtPopName = dr["POPNAME"].ToString();
                    _txtPopAddress = dr["ADDRESS"].ToString();
                    _txtContactPerson = dr["CONTACTPERSON"].ToString();
                    _txtMobileNo = dr["MOBILENUMBER"].ToString();
                    _txtLandlineNo = dr["LANDLINENUMBER"].ToString();
                    _txtStatus = dr["STATUS"].ToString();
                    gpdip = dr["GPDIP"].ToString();
                    bpdip = dr["BPDIP"].ToString();
                    _locationCode = dr["LOCATIONCODE"].ToString();
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

        #region Create New POP Functionality

        private String GetNewPopID()
        {

            string strPopID = "SPOP";
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
            cmd.CommandText = "Select cast((max(substring(POPID,5,4)))+1 as varchar) code from POPMASTER";

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["code"] == DBNull.Value)
                    {
                        strPopID += "1001";
                    }
                    else
                    {
                        strPopID += dr["code"].ToString();
                    }
                }


                dr.Close();
                conn.Close();

            }
            catch
            {
                throw;
            }

            return (strPopID);
        }

        #endregion

        #region Register POP Functionality
        /// <summary>
        /// Register pop will add the pop details to two tables
        /// one to pop master
        /// and another to powerstatus alert
        /// </summary>
        /// <param name="pStrPopName"></param>
        /// <param name="pStrPopAddress"></param>
        /// <param name="pStrConatctPerson"></param>
        /// <param name="pStrMobileNo"></param>
        /// <param name="pStrLandlineNo"></param>
        /// <param name="pStrModby"></param>
        /// <param name="pStrGridIP"></param>
        /// <param name="pStrBackUpIP"></param>
        public void RegisterPop(String pStrPopName, String pStrPopAddress, String pStrConatctPerson, String pStrMobileNo, String pStrLandlineNo, String pStrModby, String pStrGridIP, String pStrBackUpIP, String pstrLocationCode)
        {

            SqlConnection conn = null;
            SqlTransaction tr = null;
            string strNewPopID = "";

            try
            {
                strNewPopID += this.GetNewPopID();
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

            SqlCommand cmdPop = conn.CreateCommand();
            SqlCommand cmdPowerStatus = conn.CreateCommand();
            SqlCommand cmdPowerSms = conn.CreateCommand();

            //insert into POPMASTER table

            cmdPop.CommandText = "insert POPMASTER(POPID,POPNAME,ADDRESS,CONTACTPERSON,MOBILENUMBER,LANDLINENUMBER,STATUS,MODBY,MODON,GPDIP, BPDIP, LOCATIONCODE) values (@POPID,@POPNAME,@ADDRESS,@CONTACTPERSON,@MOBILENUMBER,@LANDLINENUMBER,@STATUS,@MODBY,@MODON,@GPDIP,@BPDIP, @LOCATIONCODE)";

            cmdPop.Parameters.AddWithValue("@POPID", strNewPopID);
            cmdPop.Parameters.AddWithValue("@POPNAME", Utilities.ValidSql(pStrPopName));
            cmdPop.Parameters.AddWithValue("@ADDRESS", Utilities.ValidSql(pStrPopAddress));
            cmdPop.Parameters.AddWithValue("@CONTACTPERSON", Utilities.ValidSql(pStrConatctPerson));
            cmdPop.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNo));
            cmdPop.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNo));
            cmdPop.Parameters.AddWithValue("@STATUS", "A");
            cmdPop.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdPop.Parameters.AddWithValue("@MODON", System.DateTime.Now.ToString("MM-dd-yyyy"));
            cmdPop.Parameters.AddWithValue("@GPDIP", pStrGridIP);
            cmdPop.Parameters.AddWithValue("@BPDIP", pStrBackUpIP);
            cmdPop.Parameters.AddWithValue("@LOCATIONCODE", pstrLocationCode);

     
            //cmdPowerStatus.CommandText = "insert POWERCHECKSTATUS (POPID,popname,gridcheck, batterycheck, prevstate, currstate) values(@POPID,@popname,@gridcheck, @batterycheck, @prevstate, @currstate)";
            //cmdPowerStatus.Parameters.AddWithValue("@POPID", strNewPopID);
            //cmdPowerStatus.Parameters.AddWithValue("@POPNAME", Utilities.ValidSql(pStrPopName));
            //cmdPowerStatus.Parameters.AddWithValue("@gridcheck", "true");
            //cmdPowerStatus.Parameters.AddWithValue("@batterycheck", "true");
            //cmdPowerStatus.Parameters.AddWithValue("@prevstate", "1");
            //cmdPowerStatus.Parameters.AddWithValue("@currstate", "1");

            // insert into power check sms table
            //cmdPowerSms.CommandText = "insert POWERCHECKSMS (POPID,LASTL1SMS,LASTL2SMS,LASTL3SMS) values(@POPID,@LASTL1SMS,@LASTL2SMS,@LASTL3SMS)";
            //cmdPowerSms.Parameters.AddWithValue("@POPID", strNewPopID);
            //cmdPowerSms.Parameters.AddWithValue("@LASTL1SMS", System.DateTime.Now);
            //cmdPowerSms.Parameters.AddWithValue("@LASTL2SMS", System.DateTime.Now);
            //cmdPowerSms.Parameters.AddWithValue("@LASTL3SMS", System.DateTime.Now);



            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdPop.Transaction = tr;
            //    cmdPowerStatus.Transaction = tr;
            //    cmdPowerSms.Transaction = tr;
                cmdPop.ExecuteNonQuery();
             //   cmdPowerStatus.ExecuteNonQuery();
              //  cmdPowerSms.ExecuteNonQuery();
                tr.Commit();
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



        #region Listing Funtionality of POINT OF PRESENCE by current status kohim

        public static DataTable GetPOPPowerListByStatusKohimawithTime()
        {

            DataTable dt = new DataTable();
            // string strQueryString = "Exec [GetPOPPowerListByStatuswithFailureTime]";
            string strQueryString = "Exec [GetPOPDownListByStatuswithFailureTime]";

            SqlConnection conn = new SqlConnection(DBConn.GetConStringKohima());
            try
            {

                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dt);
        }
        #endregion

        #region Listing Funtionality of POINT OF PRESENCE by current status and provided location
        public static DataTable GetPOPPowerListByStatusandLocation(string pLocationCode)
        {

            DataTable dt = new DataTable();
            string strQueryString = "Exec GetPSM_POPDownListByStatusAndLocation '" + pLocationCode + "'";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dt);
        }
        #endregion

        #region Listing Funtionality of POINT OF PRESENCE by current status dimapur

        public static DataTable GetPOPPowerListByStatusDimapurWithTime()
        {

            DataTable dt = new DataTable();          
            string strQueryString = "Exec [GetPSM_POPDownListByStatuswithFailureTime]";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dt);
        }
        #endregion

        #region Listing Funtionality of POINT OF PRESENCE

        public static DataTable GetPointOfPresence()
        {

            DataTable dt = new DataTable();
            string strQueryString = "Exec GetPOPDetails";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {

                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);

                dad.Fill(dt);

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dt);
        }
        #endregion

        #region LIST POP BY POPID

        public static DataSet GetPopNamePopID()
        {
            DataSet dst = new DataSet();
            string strQueryString = "select POPID,POPNAME from POPMASTER order by popname asc";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConStringByLocation("DMP"));
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst);
            }
            catch
            {
                throw;
            }
            return (dst);
        }
        //public static DataSet GetPopNamePopIDD(string strPopID)
        //{
        //    //DataSet dst = new DataSet();
            //string strQueryString = "select POPNAME from POPMASTER where POPID='" + strPopID + "'";
           
            //try
            //{
            //    SqlConnection conn = new SqlConnection(DBConn.GetConStringByLocation("DMP"));
            //    SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
            //    dad.Fill(dst);
            //}
            //catch
            //{
            //    throw;
            //}
            //return (dst);
       
        #endregion

        #region UPDATE POP FUNTIONALITY

        public void PopUpdate(String pstrPopID, String pStrPopName, String pStrPopAddress, String pStrConatctPerson, String pStrMobileNo, String pStrLandlineNo, String pStrModby, string pstrGip, string pstrBip, string pstrLocationCode)
        {

            SqlTransaction tr = null;
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdPop = conn.CreateCommand();
            SqlCommand cmdPowerStatus = conn.CreateCommand();
            //UPDATE NEWS
            cmdPop.CommandText = "UPDATE POPMASTER set POPNAME=@POPNAME,ADDRESS=@ADDRESS,CONTACTPERSON=@CONTACTPERSON,MOBILENUMBER=@MOBILENUMBER,LANDLINENUMBER=@LANDLINENUMBER,STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON,GPDIP=@GPDIP, BPDIP=@BPDIP, LOCATIONCODE = @LOCATIONCODE where POPID=@POPID";
            cmdPop.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pstrPopID));
            cmdPop.Parameters.AddWithValue("@POPNAME", Utilities.ValidSql(pStrPopName));
            cmdPop.Parameters.AddWithValue("@ADDRESS", Utilities.ValidSql(pStrPopAddress));
            cmdPop.Parameters.AddWithValue("@CONTACTPERSON", Utilities.ValidSql(pStrConatctPerson));
            cmdPop.Parameters.AddWithValue("@MOBILENUMBER", Utilities.ValidSql(pStrMobileNo));
            cmdPop.Parameters.AddWithValue("@LANDLINENUMBER", Utilities.ValidSql(pStrLandlineNo));
            cmdPop.Parameters.AddWithValue("@STATUS", "A");
            cmdPop.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdPop.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));
            cmdPop.Parameters.AddWithValue("@GPDIP", pstrGip);
            cmdPop.Parameters.AddWithValue("@BPDIP", pstrBip);
            cmdPop.Parameters.AddWithValue("@LOCATIONCODE", pstrLocationCode);

            cmdPowerStatus.CommandText = "UPDATE POWERSTATUS set POPNAME=@POPNAME where POPID=@POPID";
            cmdPowerStatus.Parameters.AddWithValue("@POPID", pstrPopID);
            cmdPowerStatus.Parameters.AddWithValue("@POPNAME", Utilities.ValidSql(pStrPopName));

            try
            {
                conn.Open();
                tr = conn.BeginTransaction();
                cmdPop.Transaction = tr;
                cmdPowerStatus.Transaction = tr;

                cmdPop.ExecuteNonQuery();
                cmdPowerStatus.ExecuteNonQuery();
                tr.Commit();
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

        #region DEACTIVATE POP FUNTIONALITY

        public static void PopDeActivate(String pStrPopID, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdPop = conn.CreateCommand();
            //UPDATE NEWS
            cmdPop.CommandText = "UPDATE POPMASTER set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where POPID=@POPID";
            cmdPop.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopID));
            cmdPop.Parameters.AddWithValue("@STATUS", "D");
            cmdPop.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdPop.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdPop.ExecuteNonQuery();
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

        #region ACTIVATE POP FUNTIONALITY
        public static void PopActivate(String pStrPopID, String pStrModby)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdPop = conn.CreateCommand();
            //UPDATE NEWS
            cmdPop.CommandText = "UPDATE POPMASTER set STATUS=@STATUS,MODBY=@MODBY,MODON=@MODON where POPID=@POPID";
            cmdPop.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopID));
            cmdPop.Parameters.AddWithValue("@STATUS", "A");
            cmdPop.Parameters.AddWithValue("@MODBY", Utilities.ValidSql(pStrModby));
            cmdPop.Parameters.AddWithValue("@MODON", Utilities.ValidSql(System.DateTime.Now.ToString("MM-dd-yyyy")));

            try
            {
                conn.Open();
                cmdPop.ExecuteNonQuery();
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

        #region DELETE POP PERMANENTLY
        public static void PopDeleteByID(string pStrPopId)
        {
            SqlConnection conn;
            conn = new SqlConnection(DBConn.GetConString());

            SqlCommand cmdPop = conn.CreateCommand();
            cmdPop.CommandText = "Delete from POPMASTER Where POPID=@POPID";
            cmdPop.Parameters.AddWithValue("@POPID", Utilities.ValidSql(pStrPopId));
            try
            {
                conn.Open();
                cmdPop.ExecuteNonQuery();
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
