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
    public class GISLogic
    {

        #region POP Getter ans Setter methods

        protected String _locationID;
        protected String _locationType;
        protected String _latitude;
        protected String _longitude;
        protected String _title;
        protected String _description;
    


        public string LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        public string LocationType
        {
            get { return _locationType; }
            set { _locationType = value; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    


        #endregion

        #region Class Constructors
        public GISLogic()
        {
        }

        public GISLogic(string pStrLocationID)
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
            cmdPop.Parameters.AddWithValue("@LOCATIONID", Utilities.ValidSql(pStrLocationID));
            cmdPop.CommandText = "SELECT LOCATIONID,TYPE,LAT,LONG,TITLE,DESCRIPTION from POPMASTER where POPID=@POPID";
            try
            {
                conn.Open();
                SqlDataReader dr = cmdPop.ExecuteReader();
                while (dr.Read())
                {
                    //_txtPopID = dr["POPID"].ToString();
                    //_txtPopName = dr["POPNAME"].ToString();
                    //_txtPopAddress = dr["ADDRESS"].ToString();
                    //_txtContactPerson = dr["CONTACTPERSON"].ToString();
                    //_txtMobileNo = dr["MOBILENUMBER"].ToString();
                    //_txtLandlineNo = dr["LANDLINENUMBER"].ToString();
                    //_txtStatus = dr["STATUS"].ToString();
                    //gpdip = dr["GPDIP"].ToString();
                    //bpdip = dr["BPDIP"].ToString();
                    //_locationCode = dr["LOCATIONCODE"].ToString();
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

        

        



        
    }
}
