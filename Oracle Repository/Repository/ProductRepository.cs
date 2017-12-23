using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class ProductRepository : Repository<Product>
    {
        OracleConnection con = OraDataContext.GetInstance();

        public List<Product> GetCatagoryWiseProduct(int?id)
        {
            List<Product> products = new List<Product>();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select p.id,p.productname,p.price,s.firstname,s.lastname,c.catagoryname from products p,sellers s,catagory c where p.catagoryid=c.id and p.sellerid=s.id and c.id=" + id;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Price = reader.GetInt32(2),
                    SellerName = reader.GetString(3) + " " + reader.GetString(4),
                    CatagoryName = reader.GetString(5)
                 }); 
            }

            con.Close();
            return products;
        }


    }
}
