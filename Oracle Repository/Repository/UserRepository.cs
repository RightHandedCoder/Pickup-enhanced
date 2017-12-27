using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class UserRepository<TUser> where TUser : User
    {
        OracleConnection con = OraDataContext.GetInstance();

        public List<TUser> GetAll()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TUser) == typeof(Buyer))
            {
                List<Buyer> list = new List<Buyer>();

                cmd.CommandText = "select buyers.id,firstname,lastname,gender,email,phone,areaname,address from buyers,areas where buyers.areaid=areas.id";
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Buyer
                    {

                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        Address = reader.GetString(7)

                    });
                }

                con.Close();
                return list as List<TUser>;
            }

            else if (typeof(TUser) == typeof(Seller))
            {
                List<Seller> list = new List<Seller>();

                cmd.CommandText = "select sellers.id,firstname,lastname,gender,email,phone,areaname,shopname from sellers,areas where sellers.areaid=areas.id";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Seller
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        ShopName = reader.GetString(7)

                    });
                }

                con.Close();
                return list as List<TUser>;
            }

            else if (typeof(TUser) == typeof(Admin))
            {
                List<Admin> list = new List<Admin>();

                cmd.CommandText = "select admins.id,firstname,lastname,gender,email,phone,areaname,departmentname from admins,areas,dept where admins.areaid=areas.id and admins.departmentid=dept.id";

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Admin
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        DepartmentName = reader.GetString(7)

                    });
                }

                con.Close();
                return list as List<TUser>;
            }

            else return null;

        }

        public User Get(int? id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TUser) == typeof(Buyer))
            {
                Buyer buyer = null;
                cmd.CommandText = "select buyers.id,firstname,lastname,gender,email,phone,areaname,address from buyers,areas where buyers.areaid = areas.id and buyers.id=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    buyer = new Buyer()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        Address = reader.GetString(7)
                    };
                }

                con.Close();
                return buyer as TUser;
            }

            else if (typeof(TUser) == typeof(Seller))
            {
                Seller seller = null;
                cmd.CommandText = "select sellers.id,firstname,lastname,gender,email,phone,areaname,shopname from sellers,areas where sellers.areaid=areas.id and sellers.id=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    seller = new Seller()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        ShopName = reader.GetString(7)
                    };
                }

                con.Close();
                return seller as TUser;
            }

            else if (typeof(TUser) == typeof(Admin))
            {
                Admin admin = null;
                cmd.CommandText = "select admins.id,firstname,lastname,gender,email,phone,areaname,departmentname from admins,areas,dept where admins.areaid=areas.id and admins.departmentid=dept.id and admins.id=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    admin = new Admin()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        AreaName = reader.GetString(6),
                        DepartmentName = reader.GetString(7)
                    };
                }

                con.Close();
                return admin as TUser;
            }

            else return null;
        }

        public int Insert(TUser user)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TUser) == typeof(Buyer))
            {
                Buyer b = user as Buyer;

                cmd.CommandText = "insert into buyers values(DEFAULT,'"+b.FirstName+"','"+b.LastName+"','"+b.Gender+"','"+b.Email+"','"+b.Phone+"',"+b.AreaId+",'"+b.Address+"')";
            }

            else if (typeof(TUser) == typeof(Seller))
            {
                Seller s = user as Seller;
                cmd.CommandText = "insert into sellers values(DEFAULT,'" + s.FirstName + "','" + s.LastName + "','" + s.Gender + "','" + s.Email + "','" + s.Phone + "'," + s.AreaId + ",'"+s.ShopName+"')";
            }

            else if (typeof(TUser) == typeof(Admin))
            {
                Admin a = user as Admin;
                cmd.CommandText = "insert into admins values(DEFAULT,'" + a.FirstName + "','" + a.LastName + "','" + a.Gender + "','" + a.Email + "','" + a.Phone + "'," + a.AreaId + "," + a.DepartmentId + "," + a.Salary + ")";
            }

            int result = cmd.ExecuteNonQuery();

            con.Close();

            return result;
        }

        public int GetId(string email)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TUser)==typeof(Buyer))
            {
                cmd.CommandText = "select id from buyers where email='" + email + "'";
            }

            else if (typeof(TUser) == typeof(Seller))
            {
                cmd.CommandText = "select id from sellers where email='" + email + "'";
            }

            else if (typeof(TUser) == typeof(Admin))
            {
                cmd.CommandText = "select id from admins where email='" + email + "'";
            }

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            else return 0;
        }

        public int Update(TUser user)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TUser) == typeof(Buyer))
            {
                Buyer b = user as Buyer;

                cmd.CommandText = "update buyers set firstname='"+b.FirstName+"',lastname='"+b.LastName+"',email='"+b.Email+"',address='"+b.Address+"',phone='"+b.Phone+"',areaid="+b.AreaId+" where id="+b.Id;
                int result = cmd.ExecuteNonQuery();

                con.Close();
                return result;
            }

            else if (typeof(TUser) == typeof(Seller))
            {
                Seller s = user as Seller;
                cmd.CommandText = "update sellers set firstname='" + s.FirstName + "',lastname='" + s.LastName + "',email='" + s.Email + "',shopname='" + s.ShopName + "',phone='" + s.Phone + "',areaid=" + s.AreaId + " where id="+s.Id;
                int result = cmd.ExecuteNonQuery();

                con.Close();
                return result;

            }

            else return 0;
        }

    }
}
