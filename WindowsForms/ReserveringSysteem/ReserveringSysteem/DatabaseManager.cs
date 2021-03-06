﻿using System;
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
        private Manager manager = new Manager();

        private List<Item> itemList = new List<Item>();
        private List<Campsite> campSiteList = new List<Campsite>();
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        public List<Item> ItemList { get { return itemList; } }
        public List<Campsite> CampsiteList { get { return campSiteList; } }

        private int eventID = 1;
        private int reservationID;
        private int bookerID;

        public DatabaseManager()
        {
            Connect();
            //Disconnect();
        }


        /// <summary>
        /// Connect with database
        /// </summary>
        public void Connect()
        {
            try
            {
                con = new OracleConnection();
<<<<<<< HEAD
                con.ConnectionString = "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=fhictora01.fhict.local/fhictora";
=======
                con.ConnectionString = "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=192.168.15.50/fhictora";
>>>>>>> origin/master
                con.Open();

                //MessageBox.Show("DATABASE VERBINDING GELUKT");
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

        /// <summary>
        /// Read data from database
        /// </summary>
        public void ReadData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Write data to database
        /// </summary>
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

        /// <summary>
        /// Get all available campsites from database
        /// </summary>
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


        /// <summary>
        /// Get all available items from database
        /// </summary>
        public List<Item> GetAllItems()
        {
            ReadData("SELECT * FROM MATERIAAL m WHERE m.materiaalID NOT IN (SELECT mg.materiaalID FROM MATERIAAL_GERMATERIAAL mg) ORDER BY m.naam");

            try
            {
                while (dr.Read())
                {
                    int id;
                    string name;
                    decimal price;

                    id = dr.GetInt32(0);
                    name = dr.GetString(2);
                    price = dr.GetDecimal(3);

                    Item item = new Item(id, name, price);
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

        /// <summary>
        /// Add reservation to database
        /// If items reserved, Set items as reserved
        /// </summary>
        public void AddReservation(int aantalpersonen, int aantalItems)
        {
            int ReservedItemID = 0;

            //Maak een nieuw reserveringsID aan
            ReadData("SELECT MAX(reserveringID) + 1 FROM RESERVERING");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        reservationID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            //Kijk of er items gereserveerd zijn zo ja, maak reserveringsID aan
            if (aantalItems >= 1)
            {

                ReadData("SELECT MAX(GERESERVEERDEMATERIAALID) + 1 FROM GERESERVEERDEMATERIAAL");
                try
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            ReservedItemID = dr.GetInt32(0);
                        }
                    }
                }
                catch (InvalidCastException ICE)
                {
                    MessageBox.Show(ICE.ToString());
                }


                try
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO GERESERVEERDEMATERIAAL (GERESERVEERDEMATERIAALID, EVENTID) VALUES (:ReservedMaterialID, :EventID)";
                    cmd.Parameters.Add("ReservedMaterialID", OracleDbType.Int32).Value = ReservedItemID;
                    cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                    int rowsUpdated = cmd.ExecuteNonQuery();

                   // MessageBox.Show("ADD RESERVATIONMATERIALID SUCCES");
                }
                catch (OracleException OE)
                {
                    MessageBox.Show(OE.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }


                try
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Reservering (RESERVERINGID, EVENTID, GERESERVEERDEMATERIAALID, AANTALPERSONEN) VALUES (:ReservationID, :EventID, :ReservedMaterialID, :NumberOfVisitors)";
                    cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;
                    cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                    cmd.Parameters.Add("ReservedMaterialID", OracleDbType.Int32).Value = ReservedItemID;
                    cmd.Parameters.Add("NumberOfVisitors", OracleDbType.Int32).Value = aantalpersonen;

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    //MessageBox.Show("ADD RESERVATION SUCCES");
                }
                catch (OracleException OE)
                {
                    MessageBox.Show(OE.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            else
            {
                try
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Reservering (RESERVERINGID, EVENTID, AANTALPERSONEN) VALUES (:ReservationID, :EventID, :NumberOfVisitors)";
                    cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;
                    cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                    cmd.Parameters.Add("NumberOfVisitors", OracleDbType.Int32).Value = aantalpersonen;

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    //MessageBox.Show("ADD RESERVATION SUCCES");
                }
                catch (OracleException OE)
                {
                    MessageBox.Show(OE.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }            
          
        }

        /// <summary>
        /// Add a booker to database
        /// </summary>
        public void AddBooker(string surname, string lastname, string address, string zipcode, string city, string email)
        {
            int visitorID = 0;
            int reservationID = 0;

            ReadData("SELECT MAX(bezoekerID) +1 FROM BEZOEKER");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        bookerID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            ReadData("SELECT MAX(reserveringID) FROM RESERVERING");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        reservationID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            ReadData("SELECT MAX(bezoekerID) + 1 FROM BEZOEKER");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        visitorID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Bezoeker (BezoekerID, ReserveringID, EventID, Voornaam, Achternaam, Email, Reserveerder, Adres, Postcode, Woonplaats) VALUES (:VisitorID, :ReservationID, :EventID, :Surname, :Lastname, :Email, :Reserver, :Address, :Zipcode, :City)";
                cmd.Parameters.Add("VisitorID", OracleDbType.Int32).Value = visitorID;
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("Surname", OracleDbType.Varchar2).Value = surname;
                cmd.Parameters.Add("Lastname", OracleDbType.Varchar2).Value = lastname;
                cmd.Parameters.Add("Email", OracleDbType.Varchar2).Value = email;
                cmd.Parameters.Add("Reserver", OracleDbType.Int32).Value = bookerID;
                cmd.Parameters.Add("Reserver", OracleDbType.Varchar2).Value = address;
                cmd.Parameters.Add("Reserver", OracleDbType.Varchar2).Value = zipcode;
                cmd.Parameters.Add("Reserver", OracleDbType.Varchar2).Value = city;

                int rowsUpdated = cmd.ExecuteNonQuery();

                //MessageBox.Show("ADD BOOKER SUCCES");

            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Add visistor to database
        /// </summary>
        public void AddVisitor(string surname, string lastname, string email)
        {
            int visitorID = 0;
            int reservationID = 0;

            ReadData("SELECT MAX(bezoekerID) FROM BEZOEKER");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        bookerID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            ReadData("SELECT MAX(reserveringID) FROM RESERVERING");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        reservationID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            ReadData("SELECT MAX(bezoekerID) + 1 FROM BEZOEKER");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        visitorID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Bezoeker (BezoekerID, ReserveringID, EventID, Voornaam, Achternaam, Email, Reserveerder) VALUES (:VisitorID, :ReservationID, :EventID, :Surname, :Lastname, :Email, :Reserver)";
                cmd.Parameters.Add("VisitorID", OracleDbType.Int32).Value = visitorID;
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("Surname", OracleDbType.Varchar2).Value = surname;
                cmd.Parameters.Add("Lastname", OracleDbType.Varchar2).Value = lastname;
                cmd.Parameters.Add("Email", OracleDbType.Varchar2).Value = email;
                cmd.Parameters.Add("Reserver", OracleDbType.Int32).Value = bookerID;

                int rowsUpdated = cmd.ExecuteNonQuery();

                //MessageBox.Show("ADD VISITOR SUCCES");

            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// set campsite as reserved
        /// </summary>
        public void AddCampsite(int campsiteID)
        {
            int reservationID = 0;
            ReadData("SELECT MAX(reserveringID) FROM RESERVERING");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        reservationID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Verhuurdeplaats (KampeerplaatsID, ReserveringID) VALUES (:CampsiteID, :ReservationID)";
                cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = campsiteID;
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;

                int rowsUpdated = cmd.ExecuteNonQuery();

                //MessageBox.Show("ADD CAMPSITE SUCCES");

            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        /// <summary>
        /// Set item as reserved
        /// </summary>
        public void AddReservedItem(int itemID)
        {
            int ReservedItemID = 0;

            ReadData("SELECT MAX(GERESERVEERDEMATERIAALID) FROM GERESERVEERDEMATERIAAL");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        ReservedItemID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO MATERIAAL_GERMATERIAAL (MateriaalID, GereserveerdemateriaalID) VALUES (:ItemID, :ReservedItemID)";
                cmd.Parameters.Add("ItemID", OracleDbType.Int32).Value = itemID;
                cmd.Parameters.Add("ReservedItemID", OracleDbType.Int32).Value = ReservedItemID;

                int rowsUpdated = cmd.ExecuteNonQuery();

                //MessageBox.Show("ADD ITEM SUCCES");

            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void AddUser(string gebruikersnaam)
        {
            int bezoekerID = 0;

            ReadData("SELECT MAX(GEBRUIKERID) +1 FROM GEBRUIKER");
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        bezoekerID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }


            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO GEBRUIKER (GebruikerID, EventID, Naam) VALUES (:UserID, :EventID, :Name)";
                cmd.Parameters.Add("UserID", OracleDbType.Int32).Value = bezoekerID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("EventID", OracleDbType.Varchar2).Value = gebruikersnaam;

                int rowsUpdated = cmd.ExecuteNonQuery();

                //MessageBox.Show("ADD USER SUCCES");

            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
