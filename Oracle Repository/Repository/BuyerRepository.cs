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

        public List<Product> GetRecentPurchase(int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            List<Product> list = new List<Product>();

            cmd.CommandText = "select productname,price,timeofpurchase,dateofpurchase from shoppingcarts s, productpurchase p, products where s.id=p.cartid and p.productid = products.id and s.buyerid="+id;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Product() { ProductName=reader.GetString(0), Price=reader.GetInt32(1), Time=reader.GetString(2), Date=reader.GetString(3)}); 
            }

            con.Close();

            return list;
        }
    }
}
