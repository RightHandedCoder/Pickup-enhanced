using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class Repository<TEntity> where TEntity : Entity
    {
        OracleConnection con = OraDataContext.GetInstance();

        public List<TEntity> GetAll()
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();

            if (typeof(TEntity) == typeof(Area))
            {
                List<Area> list = new List<Area>();
                cmd.CommandText = "select * from areas";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Area()
                    {

                        Id = reader.GetInt32(0),
                        AreaName = reader.GetString(1)
                    });
                }

                con.Close();
                return list as List<TEntity>;
            }

            else if (typeof(TEntity) == typeof(Department))
            {
                List<Department> list = new List<Department>();
                cmd.CommandText = "select * from dept";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1)

                    });
                }

                con.Close();
                return list as List<TEntity>;
            }

            else if (typeof(TEntity) == typeof(Product))
            {
                List<Product> list = new List<Product>();
                cmd.CommandText = "select p.id, productname, price, firstname, lastname, catagoryname from products p,sellers s, catagory c where p.catagoryid=c.id and s.id=p.sellerid and p.catagoryid=c.id";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product()
                    {
                        Id = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        SellerName = reader.GetString(3) + " " + reader.GetString(4),
                        CatagoryName = reader.GetString(5)
                    });
                }

                con.Close();
                return list as List<TEntity>;
            }

            else if (typeof(TEntity) == typeof(Catagory))
            {
                List<Catagory> list = new List<Catagory>();
                cmd.CommandText = "select * from catagory";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add( new Catagory(){

                        Id = reader.GetInt32(0),
                        CatagoryName = reader.GetString(1)
                    });
                }

                con.Close();
                return list as List<TEntity>;
            }

            else if (typeof(TEntity) == typeof(ShoppingCart))
            {
                return null;                
            }

            else
            {
                con.Close();
                return null;
            }
        }

        public TEntity Get(int? id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (id == null )
            {
                con.Close();
                return null;
            }

            else if (typeof(TEntity) == typeof(Area))
            {
                Area a = null;
                cmd.CommandText = "select * from areas where id=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    a = new Area() { Id = reader.GetInt32(0), AreaName = reader.GetString(1) };
                }

                con.Close();

                return a as TEntity;
            }

            else if (typeof(TEntity) == typeof(Department))
            {
                Department d = null;

                cmd.CommandText = "select * from departments where id=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    d = new Department() { Id = reader.GetInt32(0), DepartmentName = reader.GetString(1) };
                }

                
                con.Close();
                return d as TEntity;
            }

            else if (typeof(TEntity) == typeof(Product))
            {
                Product p = null;
                cmd.CommandText = "select p.id, productname, price, firstname, lastname, catagoryname from products p,sellers s, catagory c where p.id=" + id + " and sellerid=p.sellerid and p.catagoryid=c.id";

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    p = new Product() { Id = reader.GetInt32(0), ProductName = reader.GetString(1), Price = reader.GetInt32(2), SellerName = reader.GetString(3) + " " + reader.GetString(4), CatagoryName = reader.GetString(5)};
                }

                con.Close();
                return p as TEntity;
            }

            else if (typeof(TEntity) == typeof(Catagory))
            {
                Catagory c = null;
                cmd.CommandText = "select * from catagory where id="+id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    c = new Catagory() { Id = reader.GetInt32(0), CatagoryName = reader.GetString(1) };
                }

                con.Close();
                return c as TEntity;
            }

            else
            {
                con.Close();
                return null;
            }


        }

        public int Insert(TEntity entity)
        {
            if (typeof(TEntity) == typeof(Area))
            {
                Area a = entity as Area;

                con.Open();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = "insert into areas values(DEFAULT,'" + a.AreaName + "')";

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;
            }

            else if (typeof(TEntity) == typeof(Department))
            {
                Department d = entity as Department;

                con.Open();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = "insert into dept values(DEFAULT,'" + d.DepartmentName + "')";

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;
            }

            else if (typeof(TEntity) == typeof(Product))
            {
                Product p = entity as Product;

                con.Open();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = "insert into products values(DEFAULT,'"+p.ProductName+"',"+p.Price+","+p.SellerId+","+p.CatagoryId+")";

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;

            }

            else if (typeof(TEntity) == typeof(Catagory))
            {
                Catagory c = entity as Catagory;

                con.Open();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = "insert into catagory values(DEFAULT,'" + c.CatagoryName + "')";

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;
            }

            else if (typeof(TEntity)==typeof(ShoppingCart))
            {
                ShoppingCart c = entity as ShoppingCart;
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into shoppingcarts values(DEFAULT," + c.BuyerId + ",'" + c.Time + "','" + c.Date + "')";

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;
            }

            else return 0;
            
        }
    }
}
