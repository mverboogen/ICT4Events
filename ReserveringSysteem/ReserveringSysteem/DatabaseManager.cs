using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ReserveringSysteem
{
    class DatabaseManager
    {
        public List<Item> itemList = new List<Item>();
        public List<Campsite> campSiteList = new List<Campsite>();
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        public DatabaseManager()
        {
            Connect();
            //Disconnect();
        }

        public void Connect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString = "User Id=WesleyDB;Password=WesOracleDB;Data Source=localhost";
                con.Open();

                MessageBox.Show("DATABASE VERBINDING GELUKT");
            }
            catch
            {
                MessageBox.Show("DATABASE VERBINDNG MISLUKT");
            }
        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public void ReadData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
              //cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void WriteData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void GetAllCampSites()
        {
            ReadData("SELECT k.KampeerplaatsID, Prijs, MaxPersonen FROM KAMPEERPLAATS k WHERE k.KampeerplaatsID NOT IN (SELECT v.KampeerplaatsID FROM verhuurdeplaats v) ORDER BY k.kampeerplaatsID");

            try
            {
                while (dr.Read())
                {
                    int id;
                    decimal price;
                    int maxOccupation;

                    id = dr.GetInt32(0);
                    price = dr.GetDecimal(1);
                    maxOccupation = dr.GetInt32(2);

                    Campsite newCampSite = new Campsite(id, price, maxOccupation);

                    campSiteList.Add(newCampSite);
                }

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        public List<Item> GetAllItems()
        {
            ReadData("SELECT * FROM MATERIAAL m WHERE m.materiaalID NOT IN (SELECT g.gereserveerdemateriaalID FROM gereserveerdemateriaal g) ORDER BY m.naam");

            try
            {
                while (dr.Read())
                {
                    string name;
                    decimal price;
                    int quantity = 0;

                    name = dr.GetString(2);
                    price = dr.GetDecimal(3);

                    Item item = new Item(name, price,quantity);
                    itemList.Add(item);
                }

                return itemList;

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }
    }
}
