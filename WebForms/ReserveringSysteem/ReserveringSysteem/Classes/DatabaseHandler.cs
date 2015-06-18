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

        private HashGenerator hashGenerator = new HashGenerator();

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

        public void Connect()
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
            return itemList;
        }

        public List<Campsite> GetAllCampsites()
        {
            Connect();

            try
            {
                ReadData("SELECT P.ID, P.Nummer, P.Capaciteit FROM Plek P, Locatie L, Event E WHERE P.Locatie_ID = L.ID AND E.Locatie_ID = L.ID AND P.ID NOT IN (SELECT Plek_ID FROM Plek_Reservering) AND E.ID = 1");
                while(dr.Read())
                {
                    Campsite c = new Campsite();

                    c.Id = Convert.ToInt32(dr.GetValue(0));
                    c.Number = Convert.ToInt32(dr.GetValue(0));
                    c.Capacity = Convert.ToInt32(dr.GetValue(0));

                    campsiteList.Add(c);
                }

                foreach(Campsite campsite in campsiteList)
                {
                    ReadData("SELECT PS.Specificatie_ID, PS.Waarde FROM Plek_Specificatie PS, Plek P WHERE P.ID = PS.Plek_ID AND P.ID = " + campsite.Id);
                    while(dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0));

                        switch(id)
                        {
                         case 2:
                            campsite.Comfort = dr.GetString(1) == "JA" ? true : false;
                            break;
                        case 3:
                            campsite.Handicap = dr.GetString(1) == "JA" ? true : false;
                            break;
                        case 4:
                            campsite.Size = Convert.ToInt32(dr.GetValue(1));
                            break;
                        case 5:
                            campsite.Crane = dr.GetString(1) == "JA" ? true : false;
                            break;
                        case 6:
                            campsite.XCor = Convert.ToInt32(dr.GetValue(1));
                            break;
                        case 7:
                            campsite.YCor = Convert.ToInt32(dr.GetValue(1));
                            break;
                        }

                        id++;
                    }
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
             return campsiteList;
        }

        public void AddPerson(string firstname, string inlas, string lastname, string street, string streetnumber, string city, string bankAccount)
        {
            Connect();
            
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddPerson";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Firstname", "varchar2").Value = firstname;
                cmd.Parameters.Add("Inlas", "varchar2").Value = inlas;
                cmd.Parameters.Add("Surname", "varchar2").Value = lastname;
                cmd.Parameters.Add("Street", "varchar2").Value = street;
                cmd.Parameters.Add("StreetNumber", "varchar2").Value = streetnumber;
                cmd.Parameters.Add("City", "varchar2").Value = city;
                cmd.Parameters.Add("BankAccount", "varchar2").Value = bankAccount;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddAccount(string gebruikersnaam, string email)
        {
            Connect();

            string hash = hashGenerator.GenerateToken(32);

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddAccount";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Username", "varchar2").Value = gebruikersnaam;
                cmd.Parameters.Add("Email", "varchar2").Value = email;
                cmd.Parameters.Add("Hash", "varchar2").Value = hash;
                cmd.Parameters.Add("Activated", "number").Value = 0;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddPlekReservering(int campsiteID)
        {
            Connect();

            int ReserveringID = 0;

            try
            {
                ReadData("SELECT MAX(ID) FROM RESERVERING");

                while (dr.Read())
                {
                    ReserveringID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddPlekReservering";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Campsite", "number").Value = campsiteID;
                cmd.Parameters.Add("Reservation", "number").Value = ReserveringID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddReservering(string startDatum, string eindDatum)
        {
            Connect();

            int personID = 0;

            try
            {
                ReadData("SELECT MAX(ID) FROM PERSOON");

                while (dr.Read())
                {
                    personID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddReservering";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PersonID", "number").Value = personID;
                cmd.Parameters.Add("DateStart", "date").Value = startDatum;
                cmd.Parameters.Add("DateEnd", "date").Value = eindDatum;
                cmd.Parameters.Add("Paid", "number").Value = 0;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddPolsbandje()
        {
            Connect();

            Random random = new Random();
            int randomBarcode = random.Next(0, 100000);
            string barcode = randomBarcode.ToString();

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddPolsbandje";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Barcode", "varchar2").Value = barcode;
                cmd.Parameters.Add("Active", "number").Value = 0;


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddReserveringPolsbandje()
        {
            Connect();

            int reserveringID = 0;
            int polsbandjeID = 0;
            int accountID = 0;


            try
            {
                ReadData("SELECT MAX(ID) FROM RESERVERING");

                while (dr.Read())
                {
                    reserveringID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                ReadData("SELECT MAX(ID) FROM POLSBANDJE");

                while (dr.Read())
                {
                    polsbandjeID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

             try
            {
                ReadData("SELECT MAX(ID) FROM ACCOUNT");

                while (dr.Read())
                {
                    accountID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "ReserveringPolsbandje";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ReservationID", "number").Value = reserveringID;
                cmd.Parameters.Add("PolsbandjeID", "number").Value = polsbandjeID;
                cmd.Parameters.Add("AccountID", "number").Value = accountID;
                cmd.Parameters.Add("Present", "number").Value = 0;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public void AddVerhuur(int itemID)
        {
            Connect();

            int resPbID = 0;

            try
            {
                ReadData("SELECT MAX(ID) FROM RESERVERING_POLSBANDJE");

                while (dr.Read())
                {
                    resPbID = Convert.ToInt32(dr.GetValue(0));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddVerhuur";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ProductInstance", "number").Value = itemID;
                cmd.Parameters.Add("ResPBId", "number").Value = resPbID;
                cmd.Parameters.Add("DateIn", "Date").Value = 0;
                cmd.Parameters.Add("DateOut", "Date").Value = 0;
                cmd.Parameters.Add("Price", "number").Value = 0;
                cmd.Parameters.Add("Paid", "number").Value = 0;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}