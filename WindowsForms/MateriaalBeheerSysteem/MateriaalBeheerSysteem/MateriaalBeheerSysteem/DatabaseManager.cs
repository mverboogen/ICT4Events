using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Data;
using Oracle;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace MateriaalBeheerSysteem
{
    public class DatabaseManager
    {

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
                con.ConnectionString = "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=192.168.15.50/fhictora";
                con.Open();
                Console.WriteLine("CONNECTION SUCCESFULL");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ReadData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
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

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        /// <summary>
        /// Retrieves all Campsites from the database
        /// </summary>
        /// <returns>A list with all Campsites</returns>
        public List<CampSite> GetAllCampSites(int eventID)
        {
            Connect();

            List<CampSite> campSiteList = new List<CampSite>();

            ReadData("SELECT K.KampeerplaatsID, K.EventID, K.Prijs, K.MaxPersonen, K.Oppervlakte, K.KampeerType, V.ReserveringID FROM KAMPEERPLAATS K LEFT JOIN VERHUURDEPLAATS V ON K.KampeerplaatsID = V.KampeerplaatsID WHERE EventID = " + eventID.ToString());

            try
            {
                while (dr.Read())
                {
                    int id;
                    string name;
                    decimal price;
                    int type;
                    int size;
                    int maxOccupation;
                    int reservationID = -1;

                    id = dr.GetInt32(0);
                    name = Convert.ToString(dr.GetInt32(0));
                    price = dr.GetDecimal(2);
                    size = dr.GetInt32(4);
                    type = dr.GetInt32(5);
                    maxOccupation = dr.GetInt32(3);

                    CampSite newCampSite = new CampSite(id, name, price, type, size, maxOccupation);
                    if (!dr.IsDBNull(6))
                    {
                        reservationID = dr.GetInt32(6);
                    }

                    newCampSite.ReservationID = reservationID;
                    campSiteList.Add(newCampSite);
                }

                campSiteList.Sort();

                return campSiteList;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;

        }

        /// <summary>
        /// Retrieves all Items from the database
        /// </summary>
        /// <returns>A list with all Items</returns>
        public List<Item> GetAllItems(int eventID)
        {

            Connect();

            List<Item> itemList = new List<Item>();

            ReadData("SELECT * FROM MATERIAAL WHERE EventID = " + eventID.ToString());

            try
            {
                while (dr.Read())
                {
                    int id;
                    int eventId;
                    string name;
                    decimal price;
                    decimal newPrice;

                    id = dr.GetInt32(0);
                    eventId = dr.GetInt32(1);
                    name = dr.GetString(2);
                    price = dr.GetDecimal(3);
                    newPrice = dr.GetDecimal(4);

                    Item item = new Item(id, name, price, newPrice);
                    itemList.Add(item);
                }

                itemList.Sort();

                return itemList;
                
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;
        }

        /// <summary>
        /// Retrieves all Visitors from the database
        /// </summary>
        /// <returns>A list with all Visitors</returns>
        public List<Visitor> GetAllVisitors(int eventID)
        {

            Connect();

            List<Visitor> visitorList = new List<Visitor>();

            ReadData("SELECT * FROM BEZOEKER WHERE EventID = " + eventID.ToString());

            try
            {
                while(dr.Read())
                {
                    int id = 0;
                    string surname = "";
                    string lastname = "";
                    string email = "";
                    string rfid = "";
                    int bookerID = -1;
                    int reservationID = -1;
                    
                    if(!dr.IsDBNull(0))
                    {
                        id = dr.GetInt32(0);
                    }
                    else
                    {
                        throw new NullReferenceException("ID is null");
                    }

                    if (!dr.IsDBNull(1))
                    {
                        reservationID = dr.GetInt32(1);
                    }
                    else
                    {
                        throw new NullReferenceException("reservationID is null");
                    }

                    if (!dr.IsDBNull(3))
                    {
                        surname = dr.GetString(3);
                    }
                    else
                    {
                        throw new NullReferenceException("Surname is null");
                    }

                    if (!dr.IsDBNull(4))
                    {
                        lastname = dr.GetString(4);
                    }
                    else
                    {
                        throw new NullReferenceException("Lastname is null");
                    }

                    if (!dr.IsDBNull(5))
                    {
                        email = Convert.ToString(dr.GetValue(5));
                    }
                    else
                    {
                        throw new NullReferenceException("Email is null");
                    }

                    if (!dr.IsDBNull(6))
                    {
                        rfid = dr.GetString(6);
                    }

                    if (!dr.IsDBNull(7))
                    {
                        bookerID = dr.GetInt32(7);
                    }
                    else
                    {
                        throw new NullReferenceException("BookerID is null");
                    }

                    Visitor newVisitor = new Visitor(id, surname, lastname, email, bookerID, reservationID, rfid);
                    visitorList.Add(newVisitor);
                }

                visitorList.Sort();

                return visitorList;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;
            
        }

        /// <summary>
        /// Retrieves all Reservations from the database
        /// </summary>
        /// <returns>A list with all Reservations</returns>
        public List<Reservation> GetAllReservations(int eventID)
        {

            Connect();

            List<Reservation> reservationList = new List<Reservation>();

            ReadData("SELECT * FROM RESERVERING WHERE EventID = " + eventID.ToString());

            try
            {
                while(dr.Read())
                {
                    int id;
                    DateTime reservationDate;
                    

                    id = dr.GetInt32(0);
                    reservationDate = dr.GetDateTime(4);

                    Reservation newReservation = new Reservation(id, reservationDate);

                    if (!dr.IsDBNull(2))
                    {
                        newReservation.ReservedItemID = dr.GetInt32(2);
                    }
                    else
                    {
                        newReservation.ReservedItemID = -1;
                    }

                    if(!dr.IsDBNull(5))
                    {
                        newReservation.CheckinDate = dr.GetDateTime(5);
                    }

                    if (!dr.IsDBNull(6))
                    {
                        newReservation.DepartDate = dr.GetDateTime(6);
                    }

                    if(dr.GetInt32(7) == 1)
                    {
                        newReservation.Payed = true;
                    }
                    else
                    {
                        newReservation.Payed = false;
                    }

                    reservationList.Add(newReservation);

                    
                }

                reservationList.Sort();

                return reservationList;

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;
        }

        /// <summary>
        /// Retrieves the booker from the database with the suppleid eventID
        /// </summary>
        /// <returns>A Booker Object</returns>
        public Booker GetBooker(int eventID, int reserveringsID)
        {
            Connect();

            ReadData("SELECT * FROM BEZOEKER WHERE EventID = " + eventID.ToString() + " AND ReserveringID = " + reserveringsID.ToString());

            try
            {
                int id;
                string surname;
                string lastname;
                string email;
                int bookerID;
                int reservationID;
                string rfid = "";
                string address;
                string zipcode;
                string city;

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    surname = dr.GetString(3);
                    lastname = dr.GetString(4);
                    email = Convert.ToString(dr.GetValue(5));
                    bookerID = dr.GetInt32(7);
                    reservationID = dr.GetInt32(1);
                    if(!dr.IsDBNull(6))
                    {
                        rfid = dr.GetString(6);
                    }
                    address = dr.GetString(8);
                    zipcode = dr.GetString(9);
                    city = dr.GetString(10);

                    Booker newBooker = new Booker(id, surname, lastname, email, bookerID, reservationID, rfid, address, zipcode, city);
                    return newBooker;
                }
                
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;
        }

        /// <summary>
        /// Retrieves all Items from the database that belong to the supplied ReservationID and EventID
        /// </summary>
        /// <returns>A list with all Items that belong to the reservationID</returns>
        public List<int> GetReserverdItems(int eventID, int reservationID)
        {

            Connect();

            List<int> intList = new List<int>();

            ReadData("SELECT M.MateriaalID FROM Materiaal M, Materiaal_Germateriaal MGM, GereserveerdeMateriaal GM, Reservering G WHERE M.MateriaalID = MGM.MateriaalID AND MGM.GereserveerdeMateriaalID = GM.GereserveerdeMateriaalID AND GM.GereserveerdeMateriaalID = " + reservationID.ToString() + "AND M.EventID = " + eventID.ToString() + "GROUP BY M.MateriaalID");

            try
            {
                int id;

                while(dr.Read())
                {
                    id = dr.GetInt32(0);
                    intList.Add(id);
                }

                return intList;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Disconnect();

            return null;
        }

        /// <summary>
        /// Counts the amount of Visitors that belong to the supplied EventID
        /// </summary>
        /// <returns>Returns a integer</returns>
        public int GetVistiorAmount(int eventID)
        {

            Connect();

            int visitorAmount = 0;

            ReadData("SELECT COUNT(*) FROM Bezoeker WHERE EventID = " + eventID.ToString());

            try
            {
                while(dr.Read())
                {
                    visitorAmount = dr.GetInt32(0);
                }
            }
            catch(InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return visitorAmount;
        }

        public int GetNewVisitorID(int eventID)
        {

            Connect();
            
            int newID = 0;

            ReadData("SELECT MAX(BezoekerID) + 1 FROM Bezoeker WHERE EventID = " + eventID.ToString());

            try
            {
                while (dr.Read())
                {
                    newID = dr.GetInt32(0);
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return newID;
        }

        /// <summary>
        /// Checks if the reservations are open for the suppleid EventID
        /// </summary>
        /// <returns>Returns a boolean</returns>
        public bool GetReservationState(int eventID)
        {

            Connect();

            bool state = false;
            int reservationState = 0;

            ReadData("SELECT ReserveringOpen FROM Event WHERE EventID = " + eventID.ToString());

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        reservationState = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            if(reservationState == 1)
            {
                state = true;
            }

            Disconnect();

            return state;
        }

        /// <summary>
        /// An function to check how many items there are of a type by name
        /// </summary>
        /// <param name="eventID">For which event</param>
        /// <param name="itemName">What item</param>
        /// <returns>Returns an int containing the amount of items</returns>
        public int GetItemAmount(int eventID, string itemName)
        {

            Connect();

            int itemAmount = 0;

            ReadData("SELECT COUNT(Naam) FROM MATERIAAL WHERE EventID = " + eventID.ToString() + " AND Naam = '" + itemName.ToString() + "'");

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        itemAmount = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return itemAmount;
        }

        public int GetnewItemID()
        {
            Connect();

            int newID = 1;

            ReadData("SELECT MAX(MateriaalID) + 1 FROM Materiaal");

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        newID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return newID;
        }

        /// <summary>
        /// An function to check how many items there are left of a type by name
        /// </summary>
        /// <param name="eventID">For which event</param>
        /// <param name="itemName">What item</param>
        /// <returns>Returns an in containg the amount of items left</returns>
        public int GetAviableItemAmount(int eventID, string itemName)
        {

            Connect();

            int availibleItemAmount = 0;

            ReadData("SELECT COUNT(*) FROM Materiaal WHERE EventID = " + eventID.ToString() + " AND Naam = '"+ itemName +"' AND MateriaalID IN (SELECT MateriaalID FROM Materiaal_GerMateriaal)");

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        availibleItemAmount = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return availibleItemAmount;
        }


        public int GetNewItemReservationID(int eventID)
        {

            Connect();

            int newID = 1;

            ReadData("SELECT MAX(GereserveerdeMateriaalID) + 1 FROM GereserveerdeMateriaal WHERE EventID = " + eventID.ToString());

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        newID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return newID;
        }


        public int GetNewCampSiteID()
        {

            Connect();

            int newID = 1;

            ReadData("SELECT MAX(KampeerplaatsID) + 1 FROM Kampeerplaats");

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        newID = dr.GetInt32(0);
                    }
                }
            }
            catch (InvalidCastException ICE)
            {
                MessageBox.Show(ICE.ToString());
            }

            Disconnect();

            return newID; 
        }

        /// <summary>
        /// Adds a new Event to the database
        /// </summary>
        public void AddEvent(string name, DateTime beginDate, DateTime endDate, string location)
        {

            Connect();

            int eventID = 0;

            ReadData("SELECT MAX(EventID) + 1 FROM Event");

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        eventID = dr.GetInt32(0);
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
                cmd.CommandText = "INSERT INTO Event (EventID, Naam, BeginDatum, EindDatum, Lokatie) VALUES (:EventID, :Name, :BeginDate, :EndDate, :Location)";
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("Name", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("BeginDate", OracleDbType.Date).Value = beginDate;
                cmd.Parameters.Add("EndDate", OracleDbType.Date).Value = endDate;
                cmd.Parameters.Add("Location", OracleDbType.Varchar2).Value = location;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitorID"></param>
        /// <param name="reservationID"></param>
        /// <param name="eventID"></param>
        /// <param name="surname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="reserver"></param>
        public void AddVisitor(int visitorID, int reservationID, int eventID, string surname, string lastname, string email, int reserver)
        {

            Connect();

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
                cmd.Parameters.Add("Reserver", OracleDbType.Int32).Value = reserver;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();
        }

        /// <summary>
        /// Adds a new Campsite to the database
        /// </summary>
        public void AddCampSite(int eventID, decimal price, int maxPersons, int surfaceArea, int campType)
        {

            Connect();

            int campSiteID = 1;

            ReadData("SELECT MAX(KampeerplaatsID) + 1 FROM Kampeerplaats");

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        campSiteID = dr.GetInt32(0);
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
                cmd.CommandText = "INSERT INTO Kampeerplaats (KampeerplaatsID, EventID, Prijs, MaxPersonen, Oppervlakte, KampeerType) VALUES (:CampSiteID, :EventID, :Price, :MaxPersons, :SurfaceArea, :CampType)";
                cmd.Parameters.Add("CampSiteID", OracleDbType.Int32).Value = campSiteID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("Price", OracleDbType.Decimal).Value = price;
                cmd.Parameters.Add("MaxPersons", OracleDbType.Int32).Value = maxPersons;
                cmd.Parameters.Add("SurfaceArea", OracleDbType.Int32).Value = surfaceArea;
                cmd.Parameters.Add("CampType", OracleDbType.Int32).Value = campType;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// Adds a new Item to the database
        /// </summary>
        public void AddItem(int eventID, int materialID, string name, decimal price, decimal newPrice)
        {
            Connect();

            ReadData("SELECT MAX(MateriaalID) + 1 FROM Materiaal");

            try
            {
                while (dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        materialID = dr.GetInt32(0);
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
                cmd.CommandText = "INSERT INTO Materiaal (MateriaalID, EventID, Naam, Prijs, NieuwPrijs) VALUES (:MaterialID, :EventID, :Name, :Price, :NewPrice)";
                cmd.Parameters.Add("MaterialID", OracleDbType.Int32).Value = materialID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("Name", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("Price", OracleDbType.Decimal).Value = price;
                cmd.Parameters.Add("NewPrice", OracleDbType.Decimal).Value = newPrice;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                Console.WriteLine(OE.ToString());
                MessageBox.Show(OE.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show(e.Message);
            }

            Disconnect();
        }

        public void AddItemReservationID(int eventID, int reservationID, int itemReservationID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO GereserveerdeMateriaal (GereserveerdeMateriaalID, EventID) VALUES (:ItemReservationID, :EventID)";
                cmd.Parameters.Add("ItemReservationID", OracleDbType.Int32).Value = itemReservationID;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Reservering SET GereserveerdeMateriaalID = " + itemReservationID.ToString() + " WHERE EventID = " + eventID.ToString() + " AND ReserveringID = " + reservationID.ToString();

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        public int AddItemToReservation(int eventID, int itemReservationID, string itemName)
        {

            Connect();

            int itemID = 0;
            try
            {
                ReadData("SELECT MateriaalID FROM Materiaal WHERE EventID = " + eventID.ToString() + " AND Naam = '" + itemName + "' AND MateriaalID NOT IN (SELECT MateriaalID FROM Materiaal_GerMateriaal)");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        itemID = dr.GetInt32(0);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Materiaal_GerMateriaal (MateriaalID, GereserveerdeMateriaalID) VALUES (:ItemID, :ItemReservationID)";
                cmd.Parameters.Add("ItemID", OracleDbType.Int32).Value = itemID;
                cmd.Parameters.Add("ItemReservationID", OracleDbType.Int32).Value = itemReservationID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                Console.WriteLine(OE.ToString());
                MessageBox.Show(OE.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show(e.Message);
            }

            Disconnect();

            return itemID;
        }

        public void UpdateRFID(int eventID, int visitorID, string RFID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Bezoeker SET RFID = '" + RFID + "' WHERE EventID = '" + eventID.ToString() + "' AND BezoekerID = " + visitorID.ToString();

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                Console.WriteLine(OE.ToString());
                MessageBox.Show(OE.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show(e.Message);
            }

            Disconnect();
        }

        /// <summary>
        /// Updates the Name based on the supplied eventID
        /// </summary>
        public void UpdateEventName(int eventID, string newEventName)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET Naam = :NewEventName WHERE EventID = :EventID";
                cmd.Parameters.Add("NewEventName", OracleDbType.Varchar2).Value = newEventName;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// Updates the Location based on the supplied eventID
        /// </summary>
        public void UpdateEventLocation(int eventID, string newEventLocation)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET Lokatie = :NewEventLocation WHERE EventID = :EventID";
                cmd.Parameters.Add("NewEventLocation", OracleDbType.Varchar2).Value = newEventLocation;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// Updates the ReservationState based on the supplied eventID
        /// </summary>
        public void UpdateEventReservationState(int eventID, bool newReservationState)
        {

            Connect();

            int state = 0;

            if(newReservationState)
            {
                state = 1;
            }

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET ReserveringOpen = :NewReservationState WHERE EventID = :EventID";
                cmd.Parameters.Add("NewReservationState", OracleDbType.Int32).Value = state;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();
        }

        /// <summary>
        /// Updates the Begin Date based on the supplied eventID
        /// </summary>
        public void UpdateEventBeginDate(int eventID, DateTime newBeginDate)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET BeginDatum = :NewBeginDate WHERE EventID = :EventID";
                cmd.Parameters.Add("NewBeginDate", OracleDbType.Date).Value = newBeginDate;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// Updates the End Date based on the supplied eventID
        /// </summary>
        public void UpdateEventEndDate(int eventID, DateTime newEndDate)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET EindDatum = :NewEndDate WHERE EventID = :EventID";
                cmd.Parameters.Add("NewEndDate", OracleDbType.Date).Value = newEndDate;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// Disables the event from visibility
        /// </summary>
        /// <param name="eventID"></param>
        public void UpdateDisableEvent(int eventID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Event SET Zichtbaar = 0 WHERE EventID = :EventID";
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        public void SetReservationPayement(int eventID, int reservationID, bool payment)
        {

            Connect();

            int paymentValue = payment == true ? 1:0;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Reservering SET Betaald = :Betaald WHERE EventID = :EventID AND ReserveringID = :ReserveringID";
                cmd.Parameters.Add("Betaald", OracleDbType.Int32).Value = paymentValue;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("ReserveringID", OracleDbType.Int32).Value = reservationID;


                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();
        }

        /// <summary>
        /// TODO: FILL IN
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="reservationID"></param>
        public void SetReservationCheckInDate(int eventID, int reservationID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Reservering SET IncheckDatum = :IncheckDatum WHERE EventID = :EventID AND ReserveringID = :ReserveringID";
                cmd.Parameters.Add("IncheckDatum", OracleDbType.Date).Value = System.DateTime.Now.Date;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("ReserveringID", OracleDbType.Int32).Value = reservationID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        /// <summary>
        /// TODO: FILL IN
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="reservationID"></param>
        public void RemoveReservationCheckInDate(int eventID, int reservationID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Reservering SET IncheckDatum = :IncheckDatum WHERE EventID = :EventID AND ReserveringID = :ReserveringID";
                cmd.Parameters.Add("IncheckDatum", OracleDbType.Date).Value = null;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("ReserveringID", OracleDbType.Int32).Value = reservationID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        public void DeleteItem(int eventID, string itemName)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE Materiaal WHERE EventID = :EventID AND Naam = :ItemName";
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("ItemName", OracleDbType.Varchar2).Value = itemName;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }

        public void DeleteItemReservation(int itemID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE Materiaal_GerMateriaal WHERE MateriaalID = :ItemID";
                cmd.Parameters.Add("ItemID", OracleDbType.Int32).Value = itemID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            Disconnect();
        }

        public void DeleteVisitor(int eventID, int visitorID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE Bezoeker WHERE EventID = :EventID AND BezoekerID = :VisitorID";
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("VisitorID", OracleDbType.Int32).Value = visitorID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();
        }

        public void DeleteCampSite(int eventID, int campSiteID)
        {

            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE Kampeerplaats WHERE EventID = :EventID AND KampeerplaatsID = :CampSiteID";
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = eventID;
                cmd.Parameters.Add("CampSiteID", OracleDbType.Int32).Value = campSiteID;

                int rowsUpdated = cmd.ExecuteNonQuery();
            }
            catch (OracleException OE)
            {
                MessageBox.Show(OE.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Disconnect();

        }        
    }
}