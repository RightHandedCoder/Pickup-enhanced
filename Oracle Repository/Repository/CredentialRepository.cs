using Oracle.ManagedDataAccess.Client;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_Repository
{
    public class CredentialRepository<TCredential> where TCredential : Credential
    {
        OracleConnection con = OraDataContext.GetInstance();

        public int Insert(TCredential obj)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                BuyerCredential b = obj as BuyerCredential;

                cmd.CommandText = "insert into buyercredentials values(DEFAULT,"+b.BuyerId+",'"+b.Username+"','"+b.Password+"','active')";
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                SellerCredential c = obj as SellerCredential;

                cmd.CommandText = "insert into sellercredentials values(DEFAULT," + c.SellerId + ",'" + c.Username + "','" + c.Password + "','active')";
            }

            int result = cmd.ExecuteNonQuery();

            con.Close();
            
            return result;
        }

        public int Get(TCredential obj)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                cmd.CommandText = "select buyerid from buyercredentials where username='" + obj.Username + "' and password='" + obj.Password +"'";
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                cmd.CommandText = "select sellerid from sellercredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            else if (typeof(TCredential) == typeof(AdminCredential))
            {
                cmd.CommandText = "select adminid from admincredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32(0);
            }

            else return 0;
        }

        public bool GetStatus(TCredential obj)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                cmd.CommandText = "select status from buyercredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                cmd.CommandText = "select status from sellercredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            else if (typeof(TCredential) == typeof(AdminCredential))
            {
                cmd.CommandText = "select status from admincredentials where username='" + obj.Username + "' and password='" + obj.Password + "'";
            }

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader.GetString(0) == "active")
                {
                    con.Close();
                    return true;
                }


                else { con.Close(); return false; }
            }

            else { con.Close(); return false; }
        }

        public Credential GetById(int id)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                BuyerCredential bc = null;

                cmd.CommandText = "select * from buyercredentials where buyerid=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bc = new BuyerCredential() { Id = reader.GetInt32(0), BuyerId = reader.GetInt32(1), Username = reader.GetString(2), Password = reader.GetString(3) };
                }

                con.Close();
                return bc;
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                SellerCredential sc = null;

                cmd.CommandText = "select * from sellercredentials where sellerid=" + id;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sc = new SellerCredential() { Id = reader.GetInt32(0), SellerId = reader.GetInt32(1), Username = reader.GetString(2), Password = reader.GetString(3) };
                }

                con.Close();
                return sc;

            }

            else return null;
        }

        public int UpdatePassword(TCredential obj)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();

            if (typeof(TCredential) == typeof(BuyerCredential))
            {
                BuyerCredential bc = obj as BuyerCredential;

                cmd.CommandText = "update buyercredentials set password='" + bc.Password +"' where id="+bc.Id;

                int result=cmd.ExecuteNonQuery();

                con.Close();

                return result;
            }

            else if (typeof(TCredential) == typeof(SellerCredential))
            {
                SellerCredential sc = obj as SellerCredential;

                cmd.CommandText = "update sellercredentials set password='" + sc.Password + "' where id=" + sc.Id;

                int result = cmd.ExecuteNonQuery();

                con.Close();

                return result;

            }

            else return 0;
        }
        
    }
}
