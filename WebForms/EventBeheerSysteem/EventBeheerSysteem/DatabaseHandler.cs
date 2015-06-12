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

namespace EventBeheerSysteem
{
    public class DatabaseHandler
    {

        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        private static DatabaseHandler self;

        private DatabaseHandler()
        {
            self = this;
        }

        public static DatabaseHandler GetInstance()
        {
            if(self == null)
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
        
        public List<Event> GetAllEvents()
        {
            Connect();

            int amount = 0;

            ReadData(@"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers FROM event E, locatie L WHERE E.Locatie_id = L.id");

            List<Event> eventList = new List<Event>();

            try
            {
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        Event newEvent = new Event();

                        newEvent.ID = Convert.ToInt32(dr.GetValue(0));
                        newEvent.Name = dr.GetString(1);
                        newEvent.LocationName = dr.GetString(2);
                        if(!dr.IsDBNull(3))
                        {
                            newEvent.LocationStreet = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            newEvent.LocationNumber = Convert.ToInt32(dr.GetValue(4));
                        }
                        if (!dr.IsDBNull(5))
                        {
                            newEvent.LocationZipCode = dr.GetString(5);
                        }
                        if(!dr.IsDBNull(6))
                        {
                            newEvent.LocationCity = dr.GetString(6);
                        }
                        if (!dr.IsDBNull(7))
                        {
                            newEvent.StartDate = dr.GetDateTime(7);
                        }
                        if (!dr.IsDBNull(8))
                        {
                            newEvent.EndDate = dr.GetDateTime(8);
                        }
                        if (!dr.IsDBNull(9))
                        {
                            newEvent.MaxVisitors = Convert.ToInt32(dr.GetValue(9));
                        }

                        eventList.Add(newEvent);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            finally
            {
                Disconnect();
            }

            return eventList;
        }

        public Event GetEventByID(int id)
        {
            Connect();

            int amount = 0;

            ReadData(@"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers FROM event E, locatie L WHERE E.Locatie_id = L.id AND E.ID = " + id.ToString());

            Event selEvent = new Event();

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        

                        selEvent.ID = Convert.ToInt32(dr.GetValue(0));
                        selEvent.Name = dr.GetString(1);
                        selEvent.LocationName = dr.GetString(2);
                        if (!dr.IsDBNull(3))
                        {
                            selEvent.LocationStreet = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            selEvent.LocationNumber = Convert.ToInt32(dr.GetValue(4));
                        }
                        if (!dr.IsDBNull(5))
                        {
                            selEvent.LocationZipCode = dr.GetString(5);
                        }
                        if (!dr.IsDBNull(6))
                        {
                            selEvent.LocationCity = dr.GetString(6);
                        }
                        if (!dr.IsDBNull(7))
                        {
                            selEvent.StartDate = dr.GetDateTime(7);
                        }
                        if (!dr.IsDBNull(8))
                        {
                            selEvent.EndDate = dr.GetDateTime(8);
                        }
                        if (!dr.IsDBNull(9))
                        {
                            selEvent.MaxVisitors = Convert.ToInt32(dr.GetValue(9));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            finally
            {
                Disconnect();
            }

            return selEvent;
        }

        public List<Reservation> GetAllReservations(int id)
        {
            List<Reservation> reservationList = new List<Reservation>();

            Connect();

            try
            {
                ReadData("SELECT DISTINCT(R.ID), R.Persoon_ID, R.DatumStart, R.DatumEinde, R.Betaald, Pe.Voornaam, Pe.TussenVoegsel, Pe.Achternaam, Pe.Straat, Pe.Huisnr, Pe.Woonplaats, Pe.Banknr FROM Reservering R, Event E, Locatie L, Plek P, Plek_Reservering PK, Persoon Pe WHERE E.Locatie_ID = L.ID AND P.Locatie_ID = L.ID AND PK.Plek_ID = P.ID AND PK.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND E.ID = " + id.ToString());

                while(dr.Read())
                {
                    Reservation r = new Reservation();
                    Booker b = new Booker();

                    //Reservation
                    r.ID = dr.IsDBNull(0) == false ? Convert.ToInt32(dr.GetValue(0)) : 0;
                    r.BookerID = dr.IsDBNull(1) == false ? Convert.ToInt32(dr.GetValue(1)) : 0;
                    if(!dr.IsDBNull(2))
                    {
                        r.StartDate = dr.GetDateTime(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        r.EndDate = dr.GetDateTime(3);
                    }
                    r.Payed = Convert.ToInt32(dr.GetValue(4)) == 1 ? true : false;

                    //Booker
                    b.Firstname = dr.IsDBNull(5) == false ? dr.GetString(5) : null;
                    b.Inlas = dr.IsDBNull(6) == false ? dr.GetString(6) : null;
                    b.Surname = dr.IsDBNull(7) == false ? dr.GetString(7) : null;
                    b.Street = dr.IsDBNull(8) == false ? dr.GetString(8) : null;
                    b.Number = dr.IsDBNull(9) == false ? Convert.ToInt32(dr.GetValue(9)) : 0;
                    b.City = dr.IsDBNull(10) == false ? dr.GetString(10) : null;
                    b.BankAccount = dr.IsDBNull(11) == false ? dr.GetString(11) : null;

                    r.ReservationBooker = b;

                    reservationList.Add(r);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return reservationList;
        }
    }
}