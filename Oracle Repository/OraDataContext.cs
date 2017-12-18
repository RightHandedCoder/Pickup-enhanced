using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Oracle_Repository
{
    public class OraDataContext
    {
        private static OracleConnection con = null;
        private static string conString = ConfigurationManager.ConnectionStrings["OraConnection"].ConnectionString;

        private OraDataContext()
        {

        }

        public static OracleConnection GetInstance()
        {
            if (con == null)
            {
                con = new OracleConnection(conString);
                return con;
            }

            else return null;
        }
    }
}
