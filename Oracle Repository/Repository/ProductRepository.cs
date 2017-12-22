using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class ProductRepository
    {
        OracleConnection con =  OraDataContext.GetInstance();
        

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from products";

            OracleDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Product p = new Product();

                p.Id = reader.GetInt32(0);
                p.ProductName = reader.GetString(1);
                p.Price = reader.GetInt32(2);
                p.SellerId = reader.GetInt32(3);
                p.CatagoryId = reader.GetInt32(4);

                products.Add(p);
            }

            con.Close();
            return products;

        }

        public List<Product> GetCatagoryWiseProduct(int id)
        {
            List<Product> products = new List<Product>();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from products where catagoryid="+id;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product p = new Product();

                p.Id = reader.GetInt32(0);
                p.ProductName = reader.GetString(1);
                p.Price = reader.GetInt32(2);
                p.SellerId = reader.GetInt32(3);
                p.CatagoryId = reader.GetInt32(4);

                products.Add(p);
            }

            con.Close();
            return products;

        }

        public Product Get(int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from products where id=" + id;

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Product p = new Product();

                p.Id = reader.GetInt32(0);
                p.ProductName = reader.GetString(1);
                p.Price = reader.GetInt32(2);
                p.SellerId = reader.GetInt32(3);
                p.CatagoryId = reader.GetInt32(4);

                return p;
            }

            else return null;
        }


    }
}
