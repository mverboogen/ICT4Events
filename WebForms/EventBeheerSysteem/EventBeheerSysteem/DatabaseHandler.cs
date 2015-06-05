using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventBeheerSysteem
{
    public class DatabaseHandler
    {

        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        public DatabaseHandler()
        {
            Connect();
            Disconnect();
        }

        private void Connect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "User Id=smeAdmin;Password=password;Data Source=localhost";
                con.Open();
                Console.WriteLine("Connection Succesfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        private void ReadData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public int GetEvents()
        {
            Connect();

            ReadData("SELECT COUNT(*) FROM Event");

            int amount = 0;

            try
            {
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        amount = Convert.ToInt32(dr.GetInt32(0));
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Disconnect();
            }

            return amount;
        }
    }
}