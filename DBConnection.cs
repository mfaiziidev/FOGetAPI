using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOGetAPI
{
    public class DBConnection
    {
        public SqlConnection GetDBConnection()
        {
            try
            {
                string strConn = "Data Source=DESKTOP-B7IJGUC\\DEVZONE;Initial Catalog=FO_API;Persist Security Info=True;User ID=sa;Password=Tmrc123;";
                SqlConnection conn = new SqlConnection(strConn);
                return conn;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new Exception("Error creating database connection.", ex);
            }

        }
    }
    
}