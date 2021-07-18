using System;
using System.Text;
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
    public class DiscountsAndWaivers
    {
        public static double GetSecurityDepositDiscount(String pStrUserID)
        {
            SqlConnection conn = null;
            double discount = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select SECURITYDEPOSITDISCOUNT from DISCOUNTSANDWAIVERS where USERID='" + Utilities.ValidSql(pStrUserID) + "'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    discount = Convert.ToDouble(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (discount);
        }

        public static double GetOTRCDiscount(String pStrUserID)
        {
            SqlConnection conn = null;
            double discount = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select OTRCDISCOUNT from DISCOUNTSANDWAIVERS where USERID='" + Utilities.ValidSql(pStrUserID) + "'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    discount = Convert.ToDouble(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (discount);
        }


        public static double GetPersistentWaiver(String pStrUserID)
        {
            SqlConnection conn = null;
            double discount = 0;

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select PersistentWaiver from DISCOUNTSANDWAIVERS where USERID='" + Utilities.ValidSql(pStrUserID) + "'";
            try
            {
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    discount = Convert.ToDouble(cmd.ExecuteScalar());
                }
                conn.Close();
            }
            catch
            {
                throw;
            }

            return (discount);
        }           

    }
}
