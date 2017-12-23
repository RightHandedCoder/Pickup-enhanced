using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class BuyerRepository : UserRepository<Buyer>
    {
        OracleConnection con = OraDataContext.GetInstance();

        public int AddToCart(int cartId, int productId)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into productpurchase values("+cartId+","+productId+",'"+DateTime.Now.ToShortTimeString()+"','"+DateTime.Now.ToShortDateString()+"')";

            if (cmd.ExecuteNonQuery()==1)
            {
                return 1;
            }

            else return 0;
        }

        public int GetCartId(int? id)
        {
            con.Open();
            int cartId = 0;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select id from carts where buyerid=" + id;

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cartId = reader.GetInt32(0);
            }

            con.Close();

            return cartId;
        }

    }
}
