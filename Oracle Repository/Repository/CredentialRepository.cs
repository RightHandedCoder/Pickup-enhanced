using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class CredentialRepository<TCredential> where TCredential : Credential
    {
        OracleConnection con = OraDataContext.GetInstance();

        public int Get(TCredential obj)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                cmd.CommandText = "select buyerid from buyercredentials where username='" + obj.Username + "' and password='" + obj.Password +"'";
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                cmd.CommandText = "select sellerid from sellercredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            else return 0;
        }

        
    }
}
