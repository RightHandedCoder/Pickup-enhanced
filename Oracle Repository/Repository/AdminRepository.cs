using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class AdminRepository : UserRepository<Admin>
    {
        OracleConnection con = OraDataContext.GetInstance();

        public int ChangeBuyerStatus(int id, string status)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "change_buyer_status";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Buyer_id",OracleDbType.Decimal).Value=id;
            cmd.Parameters.Add("Status", OracleDbType.Varchar2).Value = status;

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception)
            {
                con.Close();
                return 0;
                throw;
            }
        }

        public int ChangeSellerStatus(int id, string status)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "change_seller_status";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Seller_id", OracleDbType.Decimal).Value = id;
            cmd.Parameters.Add("Status", OracleDbType.Varchar2).Value = status;

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch (Exception)
            {
                con.Close();
                return 0;
                throw;
            }
        }


    }
}
