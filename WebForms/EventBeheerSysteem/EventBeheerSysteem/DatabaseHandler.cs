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
        
        public List<Event> GetAllEvents()
        {
            Connect();

            int amount = 0;

            ReadData(@"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers FROM event E, locatie L");

            List<Event> eventList = new List<Event>();

            try
            {
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        Event newEvent = new Event();

                        newEvent.ID = dr.GetInt32(0);
                        newEvent.Name = dr.GetString(1);
                        newEvent.LocationName = dr.GetString(2);
                        if(!dr.IsDBNull(3))
                        {
                            newEvent.LocationStreet = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            newEvent.LocationNumber = dr.GetInt32(4);
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
                            newEvent.MaxVisitors = dr.GetInt32(9);
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

            ReadData(@"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers FROM event E, locatie L WHERE E.id = " + id.ToString());

            Event selEvent = new Event();

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        

                        selEvent.ID = dr.GetInt32(0);
                        selEvent.Name = dr.GetString(1);
                        selEvent.LocationName = dr.GetString(2);
                        if (!dr.IsDBNull(3))
                        {
                            selEvent.LocationStreet = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            selEvent.LocationNumber = dr.GetInt32(4);
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
                            selEvent.MaxVisitors = dr.GetInt32(9);
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
    }
}