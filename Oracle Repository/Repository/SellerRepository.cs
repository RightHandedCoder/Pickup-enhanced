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

        public string GetSellerName(int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "get_sel_name";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("sel_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("sel_name", OracleDbType.Varchar2).Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters["sel_name"].Size = 20;

            try
            {
               
                cmd.ExecuteNonQuery();
                
                string temp = cmd.Parameters["sel_name"].Value.ToString();

                con.Close();
                return temp;


            }
            catch (Exception ex)
            {
                con.Close();
                return "null";
            }

            

        }
    }
}
