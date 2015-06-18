using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Oracle.DataAccess.Client;

namespace MateriaalBeheerSysteem
{
    public class DatabaseHandler
    {
        private OracleCommand cmd;
        private OracleConnection con;
        private OracleDataReader dr;
        private static DatabaseHandler self;

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

        private int GetNextID(string table)
        {
            int id = 1;

            try
            {
                ReadData("SELECT MAX(ID) + 1 FROM " + table);
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        id = Convert.ToInt32(dr.GetValue(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return id;
        }

        public bool AddCategorie(Categorie c)
        {
            Connect();

            int updatedRows = 0;

            try
            {
                c.ID = GetNextID("ProductCat");

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO ProductCat (ID, Naam) VALUES (:NewID, :Name)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = c.ID;
                cmd.Parameters.Add("Name", OracleDbType.Varchar2).Value = c.Name;

                updatedRows = cmd.ExecuteNonQuery();

                if (c.SubID != null && c.SubID != 0)
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE ProductCat SET ProductCat_ID = :SubID WHERE ID = :ID";
                    cmd.Parameters.Add("SubID", OracleDbType.Int32).Value = c.SubID;
                    cmd.Parameters.Add("ID", OracleDbType.Varchar2).Value = c.ID;

                    updatedRows += cmd.ExecuteNonQuery();
                }


                if (updatedRows > 0)
                {
                    return true;
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

            return false;
        }

        public bool AddMaterial(Item item, int amount)
        {
            Connect();

            int nextID = GetNextID("Product");
            string nextTypeNumber = "";
            int updatedRows = 0;

            try
            {
                ReadData("SELECT MAX(TypeNummer) FROM PRODUCT");
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        nextTypeNumber = dr.GetString(0);
                        nextTypeNumber = Convert.ToString((Convert.ToInt32(nextTypeNumber) + 1));
                    }
                }

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "INSERT INTO Product (ID, ProductCat_ID, Merk, Serie, TypeNummer, Prijs) VALUES (:NewID, :NewProductCat, :NewBrand, :NewSerie, :NewNumber, :NewPrice)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextID;
                cmd.Parameters.Add("NewProductCat", OracleDbType.Int32).Value = item.MainCatID;
                cmd.Parameters.Add("NewBrand", OracleDbType.Varchar2).Value = item.Brand;
                cmd.Parameters.Add("NewSerie", OracleDbType.Varchar2).Value = item.Serie;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = nextTypeNumber;
                cmd.Parameters.Add("NewPrice", OracleDbType.Decimal).Value = item.Price;

                updatedRows = cmd.ExecuteNonQuery();

                AddItemAmount(nextID, Convert.ToInt32(nextTypeNumber), amount);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public void AddItemAmount(int itemID, int typeNumber, int amount)
        {
            int updatedRows = 0;
            int nextNumber = 1;
            int nextID;

            ReadData("SELECT MAX(Volgnummer) + 1 FROM ProductExemplaar WHERE Product_ID = " + itemID);
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    nextNumber = Convert.ToInt32(dr.GetValue(0));
                }
            }

            nextID = GetNextID("ProductExemplaar");

            for (int i = 0; i < amount; i++)
            {
                string barcode = typeNumber + "." + (i + 1).ToString().PadLeft(3, '0');

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "INSERT INTO ProductExemplaar (ID, Product_ID, Volgnummer, Barcode) VALUES (:NewID, :NewProductID, :NewNumber, :NewBarcode)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextID + i;
                cmd.Parameters.Add("NewProductID", OracleDbType.Int32).Value = itemID;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = nextNumber + i;
                cmd.Parameters.Add("NewBarcode", OracleDbType.Varchar2).Value = barcode;

                updatedRows = cmd.ExecuteNonQuery();
            }
        }

        public bool AddCampsite(Campsite c)
        {
            int updatedRows = 0;
            int nextNumber = 1;
            int nextCampsiteID = 1;
            int nextSpecificationID = 1;

            Connect();

            try
            {
                nextCampsiteID = GetNextID("Plek");
                nextSpecificationID = GetNextID("Plek_Specificatie");

                ReadData("SELECT MAX(Nummer) + 1 FROM Plek");

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        nextNumber = Convert.ToInt32(dr.GetValue(0));
                    }
                }

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "INSERT INTO Plek (ID, Locatie_ID, Nummer, Capaciteit) VALUES (:NewID, :LocationID, :NewNumber, :NewCapacity)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextCampsiteID;
                cmd.Parameters.Add("LocationID", OracleDbType.Int32).Value = c.LocationID;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = nextNumber;
                cmd.Parameters.Add("NewCapacity", OracleDbType.Int32).Value = c.Capacity;

                updatedRows += cmd.ExecuteNonQuery();

                for (int i = 0; i < 6; i++)
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
                        "INSERT INTO Plek_Specificatie (ID, Specificatie_ID, Plek_ID, Waarde) VALUES (:NewID, :SpecificationID, :CampsiteID, :Value)";
                    cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextSpecificationID + i;
                    cmd.Parameters.Add("SpecificationID", OracleDbType.Int32).Value = i + 2;
                    cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = nextCampsiteID;

                    switch (i)
                    {
                        case 0:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Comfort ? "JA" : "NEE";
                            break;
                        case 1:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Handicap ? "JA" : "NEE";
                            break;
                        case 2:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.Size);
                            break;
                        case 3:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Crane ? "JA" : "NEE";
                            break;
                        case 4:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.XCor);
                            break;
                        case 5:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.YCor);
                            break;
                    }

                    updatedRows += cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool AddCampsiteToReservation(int campsiteID, int reservationID)
        {
            Connect();

            try
            {
                int results = 0;
                int nextID = GetNextID("Plek_Reservering");

                ReadData("SELECT COUNT(ID) FROM Plek_Reservering WHERE Plek_ID = " + campsiteID +
                         " AND Reservering_ID = " + reservationID);

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        results = Convert.ToInt32(dr.GetValue(0));
                    }
                }

                if (results == 1)
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
                        "DELETE FROM Plek_Reservering WHERE Plek_ID = :CampsiteID AND Reservering_ID = :ReservationID";
                    cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = campsiteID;
                    cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;

                    cmd.ExecuteNonQuery();
                }

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "INSERT INTO Plek_Reservering (ID, Plek_ID, Reservering_ID) VALUES (:NewID, :CampsiteID, :ReservationID)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextID;
                cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = campsiteID;
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool AddItemToBraclet(int itemID, int bracletID)
        {
            Connect();

            int nextID = 0;
            int itemExemplaarID = 0;
            int ResLinkID = 0;

            try
            {
                ReadData(
                    "SELECT PE.ID FROM ProductExemplaar PE, Product P WHERE P.ID = PE.Product_ID AND PE.ID NOT IN (SELECT PE.ID FROM ProductExemplaar Pe, Verhuur V WHERE PE.ID = V.ProductExemplaar_ID) AND P.ID = " +
                    itemID);

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        itemExemplaarID = Convert.ToInt32(dr.GetValue(0));
                    }
                }

                ReadData(
                    "SELECT RP.ID FROM Reservering_Polsbandje RP, Polsbandje P WHERE P.ID = RP.Polsbandje_ID AND P.ID = " +
                    bracletID);

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        ResLinkID = Convert.ToInt32(dr.GetValue(0));
                    }
                }

                nextID = GetNextID("Verhuur");

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "INSERT INTO Verhuur (ID, ProductExemplaar_ID, Res_Pb_ID) VALUES (:NewID, :ProductID, :BracletID)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextID;
                cmd.Parameters.Add("ProductID", OracleDbType.Int32).Value = itemExemplaarID;
                cmd.Parameters.Add("BracletID", OracleDbType.Int32).Value = ResLinkID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool AddItemToReservation(int itemID, int reservationID)
        {
            Connect();

            int bracletID = 0;


            try
            {
                ReadData(
                    "SELECT MIN(P.ID) FROM Polsbandje P, Reservering_Polsbandje RP, Reservering R WHERE P.ID = RP.Polsbandje_ID AND RP.Reservering_ID = R.ID AND R.ID = " +
                    reservationID);

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        bracletID = Convert.ToInt32(dr.GetValue(0));
                    }
                }

                if (AddItemToBraclet(itemID, bracletID))
                {
                    return true;
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

            return false;
        }

        public int GetReservationByBarcode(string barcode)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "SELECT R.ID FROM Reservering R, Reservering_Polsbandje RP, Polsbandje P WHERE P.ID = RP.Polsbandje_ID AND RP.Reservering_ID = R.ID AND P.Barcode = :BarCode";
                cmd.Parameters.Add("BarCode", OracleDbType.Varchar2).Value = barcode;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        return Convert.ToInt32(dr.GetValue(0));
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

            return 0;
        }

        public bool PayReservation(int reservationID)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Reservering SET Betaald = 1 WHERE ID = :ReservationID";
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = reservationID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public List<Event> GetAllEvents()
        {
            Connect();

            int amount = 0;

            ReadData(
                @"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers FROM event E, locatie L WHERE E.Locatie_id = L.id");

            List<Event> eventList = new List<Event>();

            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0) && !dr.IsDBNull(1))
                    {
                        Event newEvent = new Event();

                        newEvent.ID = Convert.ToInt32(dr.GetValue(0));
                        newEvent.Name = dr.GetString(1);
                        newEvent.LocationName = dr.GetString(2);
                        if (!dr.IsDBNull(3))
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
                        if (!dr.IsDBNull(6))
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
            catch (Exception ex)
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

            ReadData(
                @"SELECT E.id, E.naam, L.naam, L.straat, L.nr, L.postcode, L.plaats, E.datumStart, E.datumEinde, E.maxBezoekers, L.ID FROM event E, locatie L WHERE E.Locatie_id = L.id AND E.ID = " +
                id);

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
                        if (!dr.IsDBNull(10))
                        {
                            selEvent.LocationID = Convert.ToInt32(dr.GetValue(10));
                        }
                    }
                    return selEvent;
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

            return null;
        }

        public List<Reservation> GetAllReservations(int id)
        {
            List<Reservation> reservationList = new List<Reservation>();

            Connect();

            try
            {
                ReadData(
                    "SELECT DISTINCT(R.ID), R.Persoon_ID, R.DatumStart, R.DatumEinde, R.Betaald, Pe.Voornaam, Pe.TussenVoegsel, Pe.Achternaam, Pe.Straat, Pe.Huisnr, Pe.Woonplaats, Pe.Banknr FROM Reservering R, Event E, Locatie L, Plek P, Plek_Reservering PK, Persoon Pe WHERE E.Locatie_ID = L.ID AND P.Locatie_ID = L.ID AND PK.Plek_ID = P.ID AND PK.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND E.ID = " +
                    id);

                while (dr.Read())
                {
                    Reservation r = new Reservation();
                    Booker b = new Booker();

                    //Reservation
                    r.ID = dr.IsDBNull(0) == false ? Convert.ToInt32(dr.GetValue(0)) : 0;
                    r.BookerID = dr.IsDBNull(1) == false ? Convert.ToInt32(dr.GetValue(1)) : 0;
                    if (!dr.IsDBNull(2))
                    {
                        r.StartDate = dr.GetDateTime(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        r.EndDate = dr.GetDateTime(3);
                    }
                    r.Payed = Convert.ToInt32(dr.GetValue(4)) == 1 ? true : false;

                    b = SetBookerData(b);

                    r.ReservationBooker = b;

                    reservationList.Add(r);
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

            return reservationList;
        }

        public List<Item> GetReservedItems(int reservationID)
        {
            Connect();

            List<Item> reservedItemList = new List<Item>();

            try
            {
                ReadData(
                    "SELECT Pex.ID, Pex.Barcode, P.Merk, P.Serie, P.TypeNummer FROM Verhuur V, Reservering R, Reservering_Polsbandje RP, ProductExemplaar Pex, Product P WHERE R.ID = RP.Reservering_ID AND V.Res_Pb_ID = RP.ID AND V.ProductExemplaar_ID = Pex.ID AND P.ID = Pex.Product_ID AND R.ID = " +
                    reservationID);

                while (dr.Read())
                {
                    Item item = new Item();
                    item.InstanceNumber = Convert.ToInt32(dr.GetValue(0));
                    item.Barcode = dr.GetString(1);
                    item.Brand = dr.GetString(2);
                    item.Serie = dr.GetString(3);
                    item.TypeNumber = Convert.ToInt32(dr.GetValue(4));

                    reservedItemList.Add(item);
                }

                foreach (Item item in reservedItemList)
                {
                    ReadData(
                        "SELECT V.Betaald, V.DatumUit, V.DatumIn FROM Verhuur V, ProductExemplaar Pex WHERE Pex.ID = V.ProductExemplaar_ID AND Pex.Barcode = " +
                        item.Barcode);
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            item.Payed = Convert.ToInt32(dr.GetValue(0)) == 1 ? true : false;
                            if (!dr.IsDBNull(1))
                            {
                                item.DateOut = dr.GetDateTime(1);
                            }
                            if (!dr.IsDBNull(2))
                            {
                                item.DateIn = dr.GetDateTime(2);
                            }
                        }
                    }
                }

                return reservedItemList;
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

        public List<Item> GetAllItems(int id)
        {
            List<Item> itemList = new List<Item>();

            Connect();

            try
            {
                ReadData("SELECT P.ID, P.ProductCat_ID, P.Merk, P.Serie, P.TypeNummer, P.Prijs FROM Product P");

                while (dr.Read())
                {
                    Item item = new Item();
                    item.ID = Convert.ToInt32(dr.GetValue(0));
                    item.MainCatID = Convert.ToInt32(dr.GetValue(1));
                    item.Brand = dr.IsDBNull(2) != true ? dr.GetString(2) : null;
                    item.Serie = dr.IsDBNull(3) != true ? dr.GetString(3) : null;
                    item.TypeNumber = Convert.ToInt32(dr.GetValue(4));
                    item.Price = Convert.ToDecimal(dr.GetValue(5));

                    itemList.Add(item);
                }

                foreach (Item item in itemList)
                {
                    bool end = false;
                    int catID = item.MainCatID;
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
                        "SELECT Pe.ID, Pe.Voornaam, Pe.Tussenvoegsel, Pe.Achternaam FROM Persoon Pe, Reservering_Polsbandje RP, Verhuur V, ProductExemplaar Pex, Product P, Reservering R WHERE P.ID = Pex.Product_ID AND Pex.ID = V.ProductExemplaar_ID AND RP.ID = V.Res_Pb_ID AND RP.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND P.ID = " +
                        item.ID);

                    List<Booker> renterList = new List<Booker>();

                    while (dr.Read())
                    {
                        Booker b = new Booker();
                        b.ID = Convert.ToInt32(dr.GetValue(0));
                        b.Firstname = dr.IsDBNull(1) != true ? dr.GetString(1) : null;
                        b.Inlas = dr.IsDBNull(2) != true ? dr.GetString(2) : null;
                        b.Surname = dr.IsDBNull(3) != true ? dr.GetString(3) : null;

                        renterList.Add(b);
                    }

                    ReadData(
                        "SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P WHERE P.ID = Pex.Product_ID AND P.ID = " +
                        item.ID);

                    while (dr.Read())
                    {
                        item.Amount = Convert.ToInt32(dr.GetValue(0));
                    }

                    ReadData(
                        "SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P, Verhuur V WHERE P.ID = Pex.Product_ID AND Pex.ID = V.PRODUCTEXEMPLAAR_ID AND P.ID = " +
                        item.ID);

                    while (dr.Read())
                    {
                        item.Available = item.Amount - Convert.ToInt32(dr.GetValue(0));
                    }
                    item.RenterList = renterList;
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

        public List<Campsite> GetAllCampsites(int id)
        {
            Connect();

            List<Campsite> campsiteList = new List<Campsite>();

            try
            {
                ReadData(
                    "SELECT P.ID, P.NUMMER FROM Plek P, Locatie L, Event E WHERE P.Locatie_ID = L.ID AND E.Locatie_ID = L.ID AND E.ID = " +
                    id);
                while (dr.Read())
                {
                    Campsite campsite = new Campsite();
                    campsite.ID = dr.IsDBNull(0) != true ? Convert.ToInt32(dr.GetValue(0)) : 0;
                    campsite.Number = dr.IsDBNull(1) != true ? Convert.ToInt32(dr.GetValue(1)) : 0;

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

        public List<Categorie> GetAllCategories()
        {
            Connect();

            List<Categorie> categorieList = new List<Categorie>();

            try
            {
                ReadData("SELECT ID, Naam, ProductCat_ID FROM ProductCat");

                while (dr.Read())
                {
                    Categorie cat = new Categorie();
                    cat.ID = Convert.ToInt32(dr.GetValue(0));
                    cat.Name = dr.GetString(1);
                    if (!dr.IsDBNull(2))
                    {
                        cat.SubID = Convert.ToInt32(dr.GetValue(0));
                    }

                    categorieList.Add(cat);
                }

                foreach (Categorie c in categorieList)
                {
                    if (c.SubID != null)
                    {
                        foreach (Categorie subC in categorieList)
                        {
                            if (subC.ID == c.SubID)
                            {
                                c.SubCategorie = subC;
                            }
                        }
                    }
                }

                return categorieList;
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

        public Reservation GetReservation(int id)
        {
            Reservation r;

            Connect();

            try
            {
                ReadData(
                    "SELECT DISTINCT(R.ID), R.Persoon_ID, R.DatumStart, R.DatumEinde, R.Betaald, Pe.Voornaam, Pe.TussenVoegsel, Pe.Achternaam, Pe.Straat, Pe.Huisnr, Pe.Woonplaats, Pe.Banknr FROM Reservering R, Event E, Locatie L, Plek P, Plek_Reservering PK, Persoon Pe WHERE E.Locatie_ID = L.ID AND P.Locatie_ID = L.ID AND PK.Plek_ID = P.ID AND PK.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND R.ID = " +
                    id);

                r = new Reservation();
                Booker b = new Booker();

                while (dr.Read())
                {
                    //Reservation
                    r.ID = dr.IsDBNull(0) == false ? Convert.ToInt32(dr.GetValue(0)) : 0;
                    r.BookerID = dr.IsDBNull(1) == false ? Convert.ToInt32(dr.GetValue(1)) : 0;
                    if (!dr.IsDBNull(2))
                    {
                        r.StartDate = dr.GetDateTime(2);
                    }
                    if (!dr.IsDBNull(3))
                    {
                        r.EndDate = dr.GetDateTime(3);
                    }
                    r.Payed = Convert.ToInt32(dr.GetValue(4)) == 1 ? true : false;

                    b = SetBookerData(b);

                    r.ReservationBooker = b;
                }

                ReadData(
                    "SELECT A.ID, A.Gebruikersnaam, A.Email, P.ID, P.Barcode FROM Reservering R, Reservering_Polsbandje RP, Polsbandje P, Account A WHERE R.ID = RP.Reservering_ID AND P.ID = RP.Polsbandje_ID AND A.ID = RP.Account_ID AND R.ID = " +
                    id);

                List<Account> accountList = new List<Account>();

                while (dr.Read())
                {
                    Account a = new Account();
                    a.ID = Convert.ToInt32(dr.GetValue(0));
                    a.Gebruikersnaam = dr.GetString(1);
                    a.Email = dr.GetString(2);
                    a.BarcodeID = Convert.ToInt32(dr.GetValue(3));
                    a.Barcode = dr.GetString(4);

                    accountList.Add(a);
                }

                r.AccountList = accountList;

                ReadData(
                    "SELECT P.Nummer FROM Plek P, Plek_Reservering PK, Reservering R WHERE P.ID = PK.Plek_ID AND PK.Reservering_ID = R.ID AND R.ID = " +
                    r.ID);

                List<int> campsiteNumberList = new List<int>();

                while (dr.Read())
                {
                    campsiteNumberList.Add(Convert.ToInt32(dr.GetValue(0)));
                }

                r.CampsiteNumberList = campsiteNumberList;

                return r;
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

        public Campsite GetCampsite(int id)
        {
            Connect();

            Campsite campsite = new Campsite();
            Booker booker = new Booker();

            try
            {
                ReadData("SELECT P.ID, P.Nummer, P.Capaciteit FROM Plek P WHERE P.ID = " + id);

                while (dr.Read())
                {
                    campsite.ID = Convert.ToInt32(dr.GetValue(0));
                    campsite.Number = Convert.ToInt32(dr.GetValue(1));
                    campsite.Capacity = Convert.ToInt32(dr.GetValue(2));
                    /*
                    booker.Firstname = dr.IsDBNull(3) != true ? dr.GetString(3) : null;
                    booker.Inlas = dr.IsDBNull(4) != true ? dr.GetString(4) : null;
                    booker.Surname = dr.IsDBNull(5) != true ? dr.GetString(5) : null;
                    */
                }

                ReadData(
                    "SELECT S.ID, PS.Waarde FROM Plek P, Locatie L, Event E, Plek_Specificatie PS, Specificatie S WHERE E.LOCATIE_ID = L.ID AND L.ID = P.LOCATIE_ID AND P.ID = PS.PLEK_ID AND S.ID = PS.SPECIFICATIE_ID AND P.ID = " +
                    id);

                while (dr.Read())
                {
                    int specID = Convert.ToInt32(dr.GetValue(0));

                    switch (specID)
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

                    specID++;
                }

                ReadData(
                    "SELECT Pe.Voornaam, Pe.Tussenvoegsel, Pe.Achternaam FROM Persoon Pe, Plek_Reservering PR, Plek P, Reservering R WHERE Pe.ID = R.Persoon_ID AND PR.Reservering_ID = R.ID AND PR.Plek_ID = P.ID AND P.ID = " +
                    id);
                while (dr.Read())
                {
                    Booker b = new Booker();
                    b.Firstname = dr.IsDBNull(0) != true ? dr.GetString(0) : null;
                    b.Inlas = dr.IsDBNull(1) != true ? dr.GetString(1) : null;
                    b.Surname = dr.IsDBNull(2) != true ? dr.GetString(2) : null;

                    campsite.CampsiteBooker = b;
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

            return campsite;
        }

        public bool UpdateEventDetails(Event e)
        {
            Connect();

            int updatedRows = 0;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Event SET Naam = :NewName, DatumStart = :NewStartDate, DatumEinde = :NewEndDate, MaxBezoekers = :VisitorLimit WHERE ID = :EventID";
                cmd.Parameters.Add("NewName", OracleDbType.Varchar2).Value = e.Name;
                cmd.Parameters.Add("NewStartDate", OracleDbType.Date).Value = e.StartDate;
                cmd.Parameters.Add("NewEndDate", OracleDbType.Date).Value = e.EndDate;
                cmd.Parameters.Add("VisitorLimit", OracleDbType.Int32).Value = e.MaxVisitors;
                cmd.Parameters.Add("EventID", OracleDbType.Int32).Value = e.ID;

                updatedRows += cmd.ExecuteNonQuery();

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Locatie SET Naam = :NewName, Straat = :NewStreet, NR = :NewNumber, Postcode = :NewZipCode, Plaats = :NewCity WHERE ID = :LocationID";
                cmd.Parameters.Add("NewName", OracleDbType.Varchar2).Value = e.LocationName;
                cmd.Parameters.Add("NewStreet", OracleDbType.Varchar2).Value = e.LocationStreet;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = e.LocationNumber;
                cmd.Parameters.Add("NewZipCode", OracleDbType.Varchar2).Value = e.LocationZipCode;
                cmd.Parameters.Add("NewCity", OracleDbType.Varchar2).Value = e.LocationCity;
                cmd.Parameters.Add("LocationID", OracleDbType.Int32).Value = e.LocationID;

                updatedRows += cmd.ExecuteNonQuery();

                if (updatedRows == 2)
                {
                    return true;
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

            return false;
        }

        public bool UpdateReservation(Reservation r)
        {
            Connect();

            int updatedRows = 0;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Reservering SET DatumStart = :NewDateStart, DatumEinde = :NewDateEnd, Betaald = :NewPayed WHERE ID = :ReservationID";
                cmd.Parameters.Add("NewDateStart", OracleDbType.Date).Value = r.StartDate;
                cmd.Parameters.Add("NewDateEnd", OracleDbType.Date).Value = r.EndDate;
                cmd.Parameters.Add("NewPayed", OracleDbType.Int32).Value = r.Payed ? 1 : 0;
                cmd.Parameters.Add("ReservationID", OracleDbType.Int32).Value = r.ID;

                updatedRows += cmd.ExecuteNonQuery();

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Persoon SET Straat = :NewStreet, HuisNr = :NewNumber, Woonplaats = :NewCity WHERE ID = :PersoonID";
                cmd.Parameters.Add("NewStreet", OracleDbType.Varchar2).Value = r.ReservationBooker.Street;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = r.ReservationBooker.Number;
                cmd.Parameters.Add("NewCity", OracleDbType.Varchar2).Value = r.ReservationBooker.City;
                cmd.Parameters.Add("PersoonID", OracleDbType.Int32).Value = r.BookerID;

                updatedRows += cmd.ExecuteNonQuery();

                if (updatedRows == 2)
                {
                    return true;
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

            return false;
        }

        public bool UpdateItem(Item i)
        {
            Connect();

            int updatedRows = 0;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Product SET Merk = :NewBrand, Serie = :NewSerie, Prijs = :NewPrice WHERE ID = :ItemID";
                cmd.Parameters.Add("NewBrand", OracleDbType.Varchar2).Value = i.Brand;
                cmd.Parameters.Add("NewSerie", OracleDbType.Varchar2).Value = i.Serie;
                cmd.Parameters.Add("NewPrice", OracleDbType.Decimal).Value = i.Price;
                cmd.Parameters.Add("ItemID", OracleDbType.Int32).Value = i.ID;

                updatedRows += cmd.ExecuteNonQuery();

                if (updatedRows == 1)
                {
                    return true;
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

            return false;
        }

        public bool UpdateCampsite(Campsite c)
        {
            Connect();

            int updatedRows = 0;
            int nextSpecificationID = 1;

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Plek SET Capaciteit = :NewCapacity WHERE ID = :CampsiteID";
                cmd.Parameters.Add("NewCapacity", OracleDbType.Varchar2).Value = c.Capacity;
                cmd.Parameters.Add("CampsiteID", OracleDbType.Varchar2).Value = c.ID;

                cmd.ExecuteNonQuery();

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Plek_Specificatie WHERE Plek_ID = :CampsiteID";
                cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = c.ID;

                cmd.ExecuteNonQuery();

                nextSpecificationID = GetNextID("Plek_Specificatie");

                for (int i = 0; i < 6; i++)
                {
                    cmd = new OracleCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
                        "INSERT INTO Plek_Specificatie (ID, Specificatie_ID, Plek_ID, Waarde) VALUES (:NewID, :SpecificationID, :CampsiteID, :Value)";
                    cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextSpecificationID + i;
                    cmd.Parameters.Add("SpecificationID", OracleDbType.Int32).Value = i + 2;
                    cmd.Parameters.Add("CampsiteID", OracleDbType.Int32).Value = c.ID;

                    switch (i)
                    {
                        case 0:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Comfort ? "JA" : "NEE";
                            break;
                        case 1:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Handicap ? "JA" : "NEE";
                            break;
                        case 2:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.Size);
                            break;
                        case 3:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = c.Crane ? "JA" : "NEE";
                            break;
                        case 4:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.XCor);
                            break;
                        case 5:
                            cmd.Parameters.Add("Value", OracleDbType.Varchar2).Value = Convert.ToString(c.YCor);
                            break;
                    }

                    updatedRows += cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool UpdateItemPayed(int itemInstanceID, int payed)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Verhuur SET Betaald = :Payed WHERE ProductExemplaar_ID = :ItemInstanceID";
                cmd.Parameters.Add("Payed", OracleDbType.Int32).Value = payed;
                cmd.Parameters.Add("ItemInstanceID", OracleDbType.Int32).Value = itemInstanceID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool UpdateItemCheckOut(int itemInstanceID)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Verhuur SET DatumUit = :Now WHERE ProductExemplaar_ID = :ItemInstanceID";
                cmd.Parameters.Add("Now", OracleDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("ItemInstanceID", OracleDbType.Int32).Value = itemInstanceID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        public bool UpdateItemCheckIn(int itemInstanceID)
        {
            Connect();

            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Verhuur SET DatumIn = :Now WHERE ProductExemplaar_ID = :ItemInstanceID";
                cmd.Parameters.Add("Now", OracleDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("ItemInstanceID", OracleDbType.Int32).Value = itemInstanceID;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return false;
        }

        private Booker SetBookerData(Booker b)
        {
            b.Firstname = dr.IsDBNull(5) == false ? dr.GetString(5) : null;
            b.Inlas = dr.IsDBNull(6) == false ? dr.GetString(6) : null;
            b.Surname = dr.IsDBNull(7) == false ? dr.GetString(7) : null;
            b.Street = dr.IsDBNull(8) == false ? dr.GetString(8) : null;
            b.Number = dr.IsDBNull(9) == false ? Convert.ToInt32(dr.GetValue(9)) : 0;
            b.City = dr.IsDBNull(10) == false ? dr.GetString(10) : null;
            b.BankAccount = dr.IsDBNull(11) == false ? dr.GetString(11) : null;

            return b;
        }
    }
}