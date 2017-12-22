using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class CatagoryRepository
    {
        OracleConnection con = OraDataContext.GetInstance();

        public List<Catagory> GetAll()
        {
            List<Catagory> list = new List<Catagory>();
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from catagory";

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add( new Catagory{

                    Id = reader.GetInt32(0),
                    CatagoryName = reader.GetString(1)
                });
            }

            return list;
        }
    }
}
