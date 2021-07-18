using Apple_Bss.CodeFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Apple_Bss.PopPowerStatus
{
    /// <summary>
    /// Summary description for symbiospopstatus
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class symbiospopstatus : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet HelloWorld()
        {
            DataSet dst = new DataSet();
            string strQueryString = "Exec [GetPSM_POPDownListByStatuswithFailureTime]";
            SqlConnection conn = new SqlConnection(DBConn.GetConString());
            try
            {
                SqlDataAdapter dad = new SqlDataAdapter(strQueryString, conn);
                dad.Fill(dst);

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (dst);
        }
    }
}
