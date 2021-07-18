using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Apple_Bss.CodeFile
{
    public class developerLogic
    {
        #region Delete Bills

        public static void DeleteFirstUserBills(String pStrUserID)
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
            //delete
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
      
            string userid = Utilities.ValidSql(pStrUserID);
            cmd1.CommandText = "DELETEUSER";
            cmd1.Parameters.AddWithValue("@USERID", pStrUserID);


            try
            {
                conn.Open();
             
         
             
              
                    cmd1.ExecuteNonQuery();
             
            }
            catch
            {    throw;
            }
            finally
            {
                conn.Close();
            }
         
        }

        #endregion

        #region Listing Functionality get name and id by pStrUsername 19/03/10 -hopeto

        public static string GetNewSubscriberUserName(String pStrUserID)
        {
            string username="";
            SqlConnection conn = null;
           

            try
            {
                conn = new SqlConnection(DBConn.GetConString());
            }
            catch
            {
                throw;
            }
            SqlCommand cmd1 = conn.CreateCommand();




            cmd1.CommandText = "select username from USERMASTER where USERID ='" + pStrUserID + "' and datediff(DAY,CONNECTIONDATE,GETDATE()) <= 30";
        

            conn.Open();
               try
                {
                  
            if (cmd1.ExecuteScalar() != DBNull.Value)
            {
               username=  cmd1.ExecuteScalar().ToString();
               
                

             
            }

                  
               

                }

                catch
                {
                
                    throw;
                }
                finally
                {
                    conn.Close();
                }
             return (username);
            }
           
        }

        #endregion
    }
