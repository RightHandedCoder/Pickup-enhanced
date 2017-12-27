using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class SellerRepository : UserRepository<Seller>
    {
        OracleConnection con = OraDataContext.GetInstance();

        public List<Product> GetMyProducts(int? id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            List<Product> list = new List<Product>();

            if (id != null)
            {
                cmd.CommandText = "select productname,catagoryname,amount from products p, catagory c, log_purchase lp where p.id=lp.productid and p.sellerid=lp.sellerid and p.catagoryid=c.id";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product() { ProductName = reader.GetString(0), CatagoryName = reader.GetString(1), UnitSold = reader.GetInt32(2) });
                }

                con.Close();
                return list;
            }

            else
            {
                con.Close();
                return list;
            } 
        }
    }
}
