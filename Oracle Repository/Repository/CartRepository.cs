using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class CartRepository : Repository<ShoppingCart>
    {
        Repository<Product> productRepo = new Repository<Product>();
        OracleConnection con = OraDataContext.GetInstance();

        public List<Product> GetCurrentCartProducts(List<int> list)
        {
            List<Product> productList = new List<Product>();

            foreach (int id in list)
            {
                productList.Add(productRepo.Get(id));
            }

            return productList;
        }

        public int GetLastCartId(int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select max(id) from shoppingcarts where buyerid=" + id;

            try
            {
                var result = cmd.ExecuteScalar();
                con.Close();
                return Convert.ToInt32(result);
            }
            catch (Exception)
            {
                con.Close();
                return 1;
            }
        }

        public int InsertSoldProducts(List<int> list, int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            foreach (int pid in list)
            {
                cmd.CommandText = "insert into productpurchase values("+id+","+pid+")";

                if (cmd.ExecuteNonQuery()!=1)
                {
                    con.Close();
                    return 0;
                }
            }

            con.Close();
            return 1;
        }

        //public int GetLastCart(int? id)
        //{
        //    if (id==null)
        //    {
        //        return 0;
        //    }

        //    else
        //    {
        //        con.Open();
        //        OracleCommand cmd = con.CreateCommand();
        //        cmd.CommandText = "get_last_cart";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("id", OracleDbType.Decimal).Value = id;
        //        cmd.Parameters.Add("cart_id", OracleDbType.Decimal).Direction = ParameterDirection.ReturnValue;

        //        var result = cmd.ExecuteScalar();
        //        con.Close();
        //        return Convert.ToInt32(result);
        //    }


        //}
    }
}
