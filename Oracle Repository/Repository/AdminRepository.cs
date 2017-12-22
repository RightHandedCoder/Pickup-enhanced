using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class AdminRepository 
    {
        OracleConnection con = OraDataContext.GetInstance();

        public Admin Get(int? id)
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from ADMINS where id = " + id;

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Admin a = new Admin()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Gender = reader.GetString(3),
                    Email = reader.GetString(4),
                    Phone = reader.GetString(5),
                    AreaId = reader.GetInt32(6),
                    DepartmentId = reader.GetInt32(7),
                    Salary = reader.GetInt32(8)
                };

                con.Close();

                return a;
            }

            else return null;
        }

        public List<Admin> GetAll()
        {
            List<Admin> list = new List<Admin>();

            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from admins";

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Admin {

                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Gender = reader.GetString(3),
                    Email = reader.GetString(4),
                    Phone = reader.GetString(5),
                    AreaId = reader.GetInt32(6),
                    DepartmentId = reader.GetInt32(7),
                    Salary = reader.GetInt32(8)
                });

            }

            con.Close();

            return list;
        }

        public int Insert(Admin user)
        {
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into admins values(DEFAULT,'" + user.FirstName + "','" + user.LastName + "','" + user.Gender + "','" + user.Email + "','" + user.Phone + "'," + user.AreaId + "," + user.DepartmentId + "," + user.Salary+")";

            int result = cmd.ExecuteNonQuery();

            con.Clone();

            return result;
        }
    }
}
