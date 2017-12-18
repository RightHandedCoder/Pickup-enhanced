using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Oracle_Repository
{
    public class Repository
    {
        private OracleConnection con = OraDataContext.GetInstance();

        public string Get()
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select first_name from employees where employee_id = 100";

            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return reader.GetString(0);
            
        }
    }
}
