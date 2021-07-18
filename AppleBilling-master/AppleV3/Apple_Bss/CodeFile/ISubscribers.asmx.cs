using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Apple_Bss.CodeFile
{
    /// <summary>
    /// Summary description for ISubscribers
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]


    public class ISubscribers : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] GetSubscribers(string prefixText)
        {
         
           // string sql = "select a.username USERNAME from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and USERNAME like @prefixText and status='A' order by USERNAME";
            //modified 13/may/10 -hopeto-  removed status
            string sql = "select a.username USERNAME from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and USERNAME like @prefixText order by USERNAME";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value  = "%" + Utilities.ValidSql(prefixText) + "%";
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] items = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    items.SetValue(dr["USERNAME"].ToString(), i);
                    i++;
                }
                return items;
            }

            catch
            { throw; }
        } 

         [WebMethod]
        public string[] GetSubscribersUserID(string prefixText)
        {
            string sql = "select userid  from USERMASTER  where  USERID like @prefixText order by USERID desc";
            try
            {
                SqlConnection conn = new SqlConnection(DBConn.GetConString());
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value ="%" + Utilities.ValidSql(prefixText) + "%";
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] items = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    items.SetValue(dr["USERID"].ToString(), i);
                    i++;
                }
                return items;
            }

            catch
            { throw; }
        }

         [WebMethod]
         public string[] GetSubscriberInfoByLocation(string prefixText, string contextKey)
         {
             string sql = "select a.username USERNAME from USERMASTER a, USERBILLINGINFO b where a.userid=b.userid and USERNAME like @prefixText order by USERNAME";
             try
             {
                 SqlConnection conn = new SqlConnection(DBConn.GetConStringByLocation(contextKey));
                 SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                 da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 10).Value = "%" + Utilities.ValidSql(prefixText) + "%";
                
               
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 string[] items = new string[dt.Rows.Count];
                 int i = 0;
                 foreach (DataRow dr in dt.Rows)
                 {
                     items.SetValue(dr["USERNAME"].ToString(), i);
                     i++;
                 }
                 return items;
             }

             catch
             { throw; }
         } 
 


        
    }
}
