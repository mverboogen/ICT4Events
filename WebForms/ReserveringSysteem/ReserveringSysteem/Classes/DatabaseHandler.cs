using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Oracle.DataAccess.Client;

namespace ReserveringSysteem
{
    public class DatabaseHandler
    {
        private readonly List<Campsite> campsiteList = new List<Campsite>();
        private readonly List<Item> itemList = new List<Item>();
        private OracleCommand cmd;
        private OracleConnection con;
        private OracleDataReader dr;
        private HashGenerator hashGenerator = new HashGenerator();
        private static DatabaseHandler self;

        public List<Item> ItemList
        {
            get { return itemList; }
        }

        public List<Campsite> CampsiteList
        {
            get { return campsiteList; }
        }

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

        /// <summary>
        ///     Connects to database
        /// </summary>
        public void Connect()
        {
            try
            {
                con = new OracleConnection();
                con.ConnectionString =
                    "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=fhictora01.fhict.local/fhictora";
                con.Open();
                Console.WriteLine("Connection Succesfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     Disconnects form database
        /// </summary>
        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        /// <summary>
        ///     Runs a sql statement
        /// </summary>
        /// <param name="sql"></param>
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

        /// <summary>
        ///     Gets all available items from database
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItems()
        {
            Connect();

            try
            {
                ReadData("SELECT P.ID, P.ProductCat_ID, P.Merk, P.Serie, P.TypeNummer, P.Prijs FROM Product P");

                while (dr.Read())
                {
                    Item item = new Item();
                    item.Id = Convert.ToInt32(dr.GetValue(0));
                    item.CatId = Convert.ToInt32(dr.GetValue(1));
                    item.Brand = dr.IsDBNull(2) != true ? dr.GetString(2) : null;
                    item.Serie = dr.IsDBNull(3) != true ? dr.GetString(3) : null;
                    item.Number = Convert.ToInt32(dr.GetValue(4));
                    item.Price = Convert.ToDecimal(dr.GetValue(5));

                    itemList.Add(item);
                }

                foreach (Item item in itemList)
                {
                    bool end = false;
                    int catID = item.CatId;
                    while (!end)
                    {
                        ReadData("SELECT Naam, ProductCat_ID FROM ProductCat WHERE ID = " + catID);

                        int oldID = catID;

                        while (dr.Read())
                        {
                            string name = dr.GetString(0);
                            item.Categorie.Add(name);
                            if (!dr.IsDBNull(1))
                            {
                                catID = Convert.ToInt32(dr.GetValue(1));
                            }
                        }

                        if (catID == oldID)
                        {
                            end = true;
                        }
                    }


                    ReadData(
                        "SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P WHERE P.ID = Pex.Product_ID AND P.ID = " +
                        item.Id);

                    while (dr.Read())
                    {
                        item.Amount = Convert.ToInt32(dr.GetValue(0));
                    }

                    ReadData(
                        "SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P, Verhuur V WHERE P.ID = Pex.Product_ID AND Pex.ID = V.PRODUCTEXEMPLAAR_ID AND P.ID = " +
                        item.Id);

                    while (dr.Read())
                    {
                        // item.Available = item.Amount - Convert.ToInt32(dr.GetValue(0));
                    }
                }

                return itemList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return null;
        }

        /// <summary>
        ///     Gets all available campsites from database
        /// </summary>
        /// <returns></returns>
        public List<Campsite> GetAllCampsites()
        {
            Connect();

            try
            {
                ReadData(
                    "SELECT P.ID, P.Nummer, P.Capaciteit FROM Plek P, Locatie L, Event E WHERE P.Locatie_ID = L.ID AND E.Locatie_ID = L.ID AND P.ID NOT IN (SELECT Plek_ID FROM Plek_Reservering) AND E.ID = 1");
                while (dr.Read())
                {
                    Campsite c = new Campsite();

                    c.Id = Convert.ToInt32(dr.GetValue(0));
                    c.Number = Convert.ToInt32(dr.GetValue(0));
                    c.Capacity = Convert.ToInt32(dr.GetValue(0));

                    campsiteList.Add(c);
                }

                foreach (Campsite campsite in campsiteList)
                {
                    ReadData(
                        "SELECT PS.Specificatie_ID, PS.Waarde FROM Plek_Specificatie PS, Plek P WHERE P.ID = PS.Plek_ID AND P.ID = " +
                        campsite.Id);
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0));

                        switch (id)
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

        /// <summary>
        ///     Adds a person to the database using a stored procedure
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="inlas"></param>
        /// <param name="lastname"></param>
        /// <param name="street"></param>
        /// <param name="streetnumber"></param>
        /// <param name="city"></param>
        /// <param name="bankAccount"></param>
        public void AddPerson(string firstname, string inlas, string lastname, string street, string streetnumber,
            string city, string bankAccount)
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

        /// <summary>
        ///     Adds a account to the database using a stored procedure
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <param name="email"></param>
        /// <param name="hash"></param>
        public void AddAccount(string gebruikersnaam, string email, string hash)
        {
            Connect();

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

        /// <summary>
        ///     Adds a campsite reservation to the database using a stored procedure
        /// </summary>
        /// <param name="campsiteID"></param>
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

        /// <summary>
        ///     Adds a reservation to the database using a stored procedure
        /// </summary>
        /// <param name="startDatum"></param>
        /// <param name="eindDatum"></param>
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

        /// <summary>
        ///     Adds a bracelet to the database using a stored procedure
        /// </summary>
        public void AddPolsbandje()
        {
            Connect();

            Random random = new Random();
            int randomBarcode = 0;
            randomBarcode = random.Next(1,100);

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

        /// <summary>
        ///     Adds a reserved bracelet to the database using a stored procedure
        /// </summary>
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

        /// <summary>
        ///     Adds a item reservation to the database using a stored procedure
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="startDate"></param>
        /// <param name="eindDate"></param>
        public void AddVerhuur(int itemID, string startDate, string eindDate)
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
                cmd.Parameters.Add("DateIn", "Date").Value = startDate;
                cmd.Parameters.Add("DateOut", "Date").Value = eindDate;
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

        /// <summary>
        ///     Updates the activation status in database
        /// </summary>
        /// <param name="username"></param>
        public void UpdateStatus(string username)
        {
            Connect();

            int geactiveerd = 1;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = ("UPDATE ACCOUNT SET GEACTIVEERD = :geactiveerd WHERE GEBRUIKERSNAAM = :username");
                cmd.Parameters.Add("geactiveerd", OracleDbType.Int32).Value = geactiveerd;
                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

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

        /// <summary>
        ///     Gets the hash from a username from database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetHash(string username)
        {
            Connect();

            string hash = "";

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = ("SELECT ACTIVATIEHASH FROM ACCOUNT WHERE GEBRUIKERSNAAM = :username");
                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    hash = dr.GetString(0);
                }

                return hash;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            finally
            {
                Disconnect();
            }

            return null;
        }
    }
}