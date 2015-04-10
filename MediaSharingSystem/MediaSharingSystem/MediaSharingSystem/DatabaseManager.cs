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

namespace EventBeheerSysteem
{
    class DatabaseManager
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
            con = new OracleConnection();
            con.ConnectionString = "User Id=system; Password=Drowssap;Data Source=localhost";
            con.Open();
            Console.WriteLine("CONNECTION SUCCESFULL");

        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public List<Event> GetEvents()
        {
            List<Event> eventList = new List<Event>();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM EVENT";
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            try
            {
                while (dr.Read())
                {
                    int id;
                    string name;
                    string location;
                    DateTime beginDate = new DateTime();
                    DateTime endDate = new DateTime();

                    id = dr.GetInt32(0);
                    name = Convert.ToString(dr.GetValue(1));
                    beginDate = dr.GetDateTime(2);
                    endDate = dr.GetDateTime(3);
                    location = dr.GetString(4);

                    Event newEvent = new Event(id, location, beginDate, endDate, this);
                    newEvent.Name = name;

                    eventList.Add(newEvent);
                }

                return eventList;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<CampSite> GetAllCampSites(int eventID)
        {
            List<CampSite> campSiteList = new List<CampSite>();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT K.KampeerplaatsID, K.EventID, K.Prijs, K.MaxPersonen, K.Oppervlakte, K.KampeerType, V.ReserveringID FROM KAMPEERPLAATS K LEFT JOIN VERHUURDEPLAATS V ON K.KampeerplaatsID = V.KampeerplaatsID WHERE EventID = " + eventID.ToString();
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

            try
            {
                while (dr.Read())
                {
                    int id;
                    string name;
                    decimal price;
                    int type;
                    Size size;
                    int maxOccupation;
                    int reservationID;

                    id = dr.GetInt32(0);
                    name = Convert.ToString(dr.GetInt32(0));
                    price = dr.GetDecimal(2);
                    type = dr.GetInt32(5);
                    size = new Size(5, 5);
                    maxOccupation = dr.GetInt32(3);

                    CampSite newCampSite = new CampSite(id, name, price, type, size, maxOccupation);
                    if (!dr.IsDBNull(6))
                    {
                        reservationID = dr.GetInt32(6);
                        newCampSite.ReservationID = reservationID;
                    }
                    
                    campSiteList.Add(newCampSite);
                }

                return campSiteList;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<Item> GetAllItems(int eventID)
        {
            List<Item> itemList = new List<Item>();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM MATERIAAL WHERE EventID = " + eventID.ToString();
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

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

                return itemList;
                
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }

        public List<Visitor> GetAllVisitors(int eventID)
        {
            List<Visitor> visitorList = new List<Visitor>();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM BEZOEKER WHERE EventID = " + eventID.ToString();
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

            try
            {
                while(dr.Read())
                {
                    int id;
                    string name;
                    string email;
                    int bookerID;
                    int reservationID;

                    id = dr.GetInt32(0);
                    name = dr.GetString(4) + " " + dr.GetString(5);
                    email = Convert.ToString(dr.GetValue(6));
                    bookerID = dr.GetInt32(7);
                    reservationID = dr.GetInt32(2);

                    Visitor newVisitor = new Visitor(id, name, email, bookerID, reservationID);
                    visitorList.Add(newVisitor);
                }
                return visitorList;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
            
        }
        
        public List<Reservation> GetAllReservations(int eventID)
        {
            List<Reservation> reservationList = new List<Reservation>();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM RESERVERING WHERE EventID = " + eventID.ToString();
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

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
                    reservationList.Add(newReservation);

                    
                }

                return reservationList;

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }

        public Booker GetBooker(int eventID, int reserveringsID)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM BEZOEKER WHERE EventID = " + eventID.ToString() + "AND ReserveringID = " + reserveringsID.ToString();
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

            try
            {
                int id;
                string name;
                string email;
                int bookerID;
                int reservationID;
                string address;
                string zipcode;
                string city;

                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    name = dr.GetString(4) + " " + dr.GetString(5);
                    email = Convert.ToString(dr.GetValue(6));
                    bookerID = dr.GetInt32(7);
                    reservationID = dr.GetInt32(2);
                    address = dr.GetString(8);
                    zipcode = dr.GetString(9);
                    city = dr.GetString(10);

                    Booker newBooker = new Booker(id, name, email, bookerID, reservationID, address, zipcode, city);
                    return newBooker;
                }
                
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }
        public List<int> GetReserverdItems(int eventID, int reservationID)
        {
            List<int> intList = new List<int>();
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT M.MateriaalID FROM Materiaal M, Materiaal_Germateriaal MGM, GereserveerdeMateriaal GM, Reservering G WHERE M.MateriaalID = MGM.MateriaalID AND MGM.GereserveerdeMateriaalID = GM.GereserveerdeMateriaalID AND GM.GereserveerdeMateriaalID = " + reservationID.ToString() + "AND M.EventID = " + eventID.ToString() + "GROUP BY M.MateriaalID";
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

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

            return null;
        }
    }
}
