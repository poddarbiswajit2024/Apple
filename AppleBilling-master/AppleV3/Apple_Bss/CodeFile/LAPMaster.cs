using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Apple_Bss.CodeFile
{
    public class LAPMaster
    {
        #region LAP master Getter ans Setter methods
        protected int _lapID;
        protected String _lapTechContactID1;
        protected String _lapTechContactID2;
        protected String _lapTechEmailID;

        public int LAPID
        {
            get { return _lapID; }
            set { _lapID = value; }
        }

        public string LAPTechContactID1
        {
            get { return _lapTechContactID1; }
            set { _lapTechContactID1 = value; }
        }

        public string LAPTechContactID2
        {
            get { return _lapTechContactID2; }
            set { _lapTechContactID2 = value; }
        }

        public string LAPTechEmailID
        {
            get { return _lapTechEmailID; }
            set { _lapTechEmailID = value; }
        }

        public LAPMaster()
        {
        }

        public LAPMaster(string LAPID)
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
            
            cmd.CommandText = "SELECT  LAPTECHCONTACT1, LAPTECHCONTACT2,LAPTECHEMAILID FROM LAPMASTER where LAPID =@LAPID"; 
            cmd.Parameters.AddWithValue("@LAPID", LAPID);
               
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _lapTechContactID1 = dr["LAPTECHCONTACT1"].ToString();
                    _lapTechContactID2 = dr["LAPTECHCONTACT2"].ToString();
                    _lapTechEmailID = dr["LAPTECHEMAILID"].ToString();
               
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

        public static DataTable  GetCableProviders()
        {
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {

                DataTable dt = new DataTable();
                SqlCommand cmd = conn.CreateCommand();               
                
                cmd.CommandText = "SELECT LAPID, LAPNAME FROM LAPMASTER where LAPstatus='A' ORDER BY LAPNAME ASC "; 
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr); dr.Close();
                return (dt);

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
