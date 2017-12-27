using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarySearch
{
    public class Util
    {
        private static string _connectionString = ConfigurationManager.AppSettings["connectionstring"];
        public static SqlConnection SqlConnection()
        {
            try
            {
                SqlConnection sqlConn = null;
                string connString = null;
                connString = _connectionString;
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();
                sqlConn.Close();
                return sqlConn;
            }
            catch
            {
                throw new Exception("SQL Connection Error!");
            }
        }



    }
}
