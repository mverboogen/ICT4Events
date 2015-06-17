using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using Oracle;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace ReserveringSysteem
{
    public class DatabaseHandler
    {
        private List<Item> itemList = new List<Item>();
        private List<Campsite> campsiteList = new List<Campsite>();

        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        private static DatabaseHandler self;


        public List<Item> ItemList { get { return itemList; } }
        public List<Campsite> CampsiteList { get { return campsiteList; } }

        private DatabaseHandler()
        {
            self = this;
        }

        public static DatabaseHandler GetInstance()
        {
            if (self == null)
            {
                self = new DatabaseHandler();
            }

            return self;
        }

        private void Connect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=fhictora01.fhict.local/fhictora";
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


        public List<Item> GetAllItems()
        {
            Connect();

            int id;
            string brand;
            string serie;
            int number;
            decimal price;

          try
          {
              ReadData("SELECT P.ID, P.Merk, P.Serie, P.TypeNummer, P.Prijs FROM Product P");

              while (dr.Read())
              {
                  id = Convert.ToInt32(dr.GetValue(0));
                  brand =  dr.GetString(2);
                  serie = dr.GetString(3);
                  number = Convert.ToInt32(dr.GetValue(4));
                  price = Convert.ToDecimal(dr.GetValue(5));

                  Item item = new Item(id, brand, serie, number, price);

                  itemList.Add(item);

                  return itemList;
               }
            }

            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

          return null;
        }

        public List<Campsite> GetAllCampsites()
        {
             Connect();

            int id;
            int number;
            int capacity;
            //decimal price;

            try
            {
                ReadData("SELECT P.ID, P.NUMMER, PS.WAARDE FROM Plek P");
                while(dr.Read())
                {
                    id = dr.IsDBNull(0) != true ? Convert.ToInt32(dr.GetValue(0)) : 0;
                    number = dr.IsDBNull(2) != true ? Convert.ToInt32(dr.GetValue(2)) : 0;
                    capacity = dr.IsDBNull(3) != true ? Convert.ToInt32(dr.GetValue(3)) : 0;

                    Campsite campsite = new Campsite(id,number,capacity,100);
                    campsiteList.Add(campsite);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return campsiteList;
        }
    }
}