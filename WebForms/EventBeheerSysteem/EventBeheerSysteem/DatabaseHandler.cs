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


/*
Connect();

try
{

}
catch(Exception ex)
{
    Debug.WriteLine(ex.Message);
}
finally
{
    Disconnect();
}
 */

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
        
        private int GetNextID(string table)
        {
            int id = 1;

            try
            {
                ReadData("SELECT MAX(ID) + 1 FROM " + table);
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0))
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

                if(c.SubID != null && c.SubID != 0)
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
                while(dr.Read())
                {
                    if(!dr.IsDBNull(0))
                    {
                        nextTypeNumber = dr.GetString(0);
                        nextTypeNumber = Convert.ToString((Convert.ToInt32(nextTypeNumber) + 1)); 
                    }
                }

                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Product (ID, ProductCat_ID, Merk, Serie, TypeNummer, Prijs) VALUES (:NewID, :NewProductCat, :NewBrand, :NewSerie, :NewNumber, :NewPrice)";
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
            int barcodeBase = 0;
            int nextID;

            ReadData("SELECT MAX(Volgnummer) + 1 FROM ProductExemplaar WHERE Product_ID = " + itemID);
            while(dr.Read())
            {
                if(!dr.IsDBNull(0))
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
                cmd.CommandText = "INSERT INTO ProductExemplaar (ID, Product_ID, Volgnummer, Barcode) VALUES (:NewID, :NewProductID, :NewNumber, :NewBarcode)";
                cmd.Parameters.Add("NewID", OracleDbType.Int32).Value = nextID + i;
                cmd.Parameters.Add("NewProductID", OracleDbType.Int32).Value = itemID;
                cmd.Parameters.Add("NewNumber", OracleDbType.Int32).Value = nextNumber + i;
                cmd.Parameters.Add("NewBarcode", OracleDbType.Varchar2).Value = barcode;

                updatedRows = cmd.ExecuteNonQuery();
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

                    b = SetBookerData(b);

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

        public List<Item> GetAllItems(int id)
        {
            List<Item> itemList = new List<Item>();

            Connect();

            try
            {
                ReadData("SELECT P.ID, P.ProductCat_ID, P.Merk, P.Serie, P.TypeNummer, P.Prijs FROM Product P");

                while(dr.Read())
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

                foreach(Item item in itemList)
                {
                    bool end = false;
                    int catID = item.MainCatID;
                    while (!end)
                    {
                        ReadData("SELECT Naam, ProductCat_ID FROM ProductCat WHERE ID = " + catID.ToString());

                        int oldID = catID;

                        while (dr.Read())
                        {
                            string name = dr.GetString(0);
                            item.Categorie.Add(name);
                            if(!dr.IsDBNull(1))
                            {
                                catID = Convert.ToInt32(dr.GetValue(1));
                            }
                        }

                        if (catID == oldID)
                        {
                            end = true;
                        }
                    }

                    ReadData("SELECT Pe.ID, Pe.Voornaam, Pe.Tussenvoegsel, Pe.Achternaam FROM Persoon Pe, Reservering_Polsbandje RP, Verhuur V, ProductExemplaar Pex, Product P, Reservering R WHERE P.ID = Pex.Product_ID AND Pex.ID = V.ProductExemplaar_ID AND RP.ID = V.Res_Pb_ID AND RP.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND P.ID = " + item.ID.ToString());

                    List<Booker> renterList = new List<Booker>();

                    while(dr.Read())
                    {
                        Booker b = new Booker();
                        b.ID = Convert.ToInt32(dr.GetValue(0));
                        b.Firstname = dr.IsDBNull(1) != true ? dr.GetString(1) : null;
                        b.Inlas = dr.IsDBNull(2) != true ? dr.GetString(2) : null;
                        b.Surname = dr.IsDBNull(3) != true ? dr.GetString(3) : null;

                        renterList.Add(b);
                    }

                    ReadData("SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P WHERE P.ID = Pex.Product_ID AND P.ID = " + item.ID.ToString());

                    while(dr.Read())
                    {
                        item.Amount = Convert.ToInt32(dr.GetValue(0));
                    }

                    ReadData("SELECT COUNT(Pex.ID) FROM ProductExemplaar Pex, Product P, Verhuur V WHERE P.ID = Pex.Product_ID AND Pex.ID = V.PRODUCTEXEMPLAAR_ID AND P.ID = " + item.ID.ToString());

                    while(dr.Read())
                    {
                        item.Available = item.Amount - Convert.ToInt32(dr.GetValue(0));
                    }
                    item.RenterList = renterList;
                }

                return itemList;
            }
            catch(Exception ex)
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
                ReadData("SELECT P.ID, P.NUMMER FROM Plek P, Locatie L, Event E WHERE P.Locatie_ID = L.ID AND E.Locatie_ID = L.ID AND E.ID = " + id.ToString());
                while(dr.Read())
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

                while(dr.Read())
                {
                    Categorie cat = new Categorie();
                    cat.ID = Convert.ToInt32(dr.GetValue(0));
                    cat.Name = dr.GetString(1);
                    if(!dr.IsDBNull(2))
                    {
                        cat.SubID = Convert.ToInt32(dr.GetValue(0));
                    }

                    categorieList.Add(cat);
                }

                foreach(Categorie c in categorieList)
                {
                    if(c.SubID != null)
                    {
                        foreach(Categorie subC in categorieList)
                        {
                            if(subC.ID == c.SubID)
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
                ReadData("SELECT DISTINCT(R.ID), R.Persoon_ID, R.DatumStart, R.DatumEinde, R.Betaald, Pe.Voornaam, Pe.TussenVoegsel, Pe.Achternaam, Pe.Straat, Pe.Huisnr, Pe.Woonplaats, Pe.Banknr FROM Reservering R, Event E, Locatie L, Plek P, Plek_Reservering PK, Persoon Pe WHERE E.Locatie_ID = L.ID AND P.Locatie_ID = L.ID AND PK.Plek_ID = P.ID AND PK.Reservering_ID = R.ID AND R.Persoon_ID = Pe.ID AND R.ID = " + id.ToString());

                r = new Reservation();
                Booker b = new Booker();

                while(dr.Read())
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

                ReadData("SELECT A.ID, A.Gebruikersnaam, A.Email, P.ID, P.Barcode FROM Reservering R, Reservering_Polsbandje RP, Polsbandje P, Account A WHERE R.ID = RP.Reservering_ID AND P.ID = RP.Polsbandje_ID AND A.ID = RP.Account_ID AND R.ID = " + id.ToString());

                List<Account> accountList = new List<Account>();

                while(dr.Read())
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

                ReadData("SELECT P.Nummer FROM Plek P, Plek_Reservering PK, Reservering R WHERE P.ID = PK.Plek_ID AND PK.Reservering_ID = R.ID AND R.ID = " + r.ID);

                List<int> campsiteNumberList = new List<int>();

                while(dr.Read())
                {
                    campsiteNumberList.Add(Convert.ToInt32(dr.GetValue(0)));
                }

                r.CampsiteNumberList = campsiteNumberList;

                return r;
                
            }
            catch(Exception ex)
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
                ReadData("SELECT P.ID, P.Nummer, P.Capaciteit FROM Plek P WHERE P.ID = " + id.ToString());

                while(dr.Read())
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

                ReadData("SELECT S.ID, PS.Waarde FROM Plek P, Locatie L, Event E, Plek_Specificatie PS, Specificatie S WHERE E.LOCATIE_ID = L.ID AND L.ID = P.LOCATIE_ID AND P.ID = PS.PLEK_ID AND S.ID = PS.SPECIFICATIE_ID AND P.ID = " + id.ToString());

                while(dr.Read())
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

                ReadData("SELECT Pe.Voornaam, Pe.Tussenvoegsel, Pe.Achternaam FROM Persoon Pe, Plek_Reservering PR, Plek P, Reservering R WHERE Pe.ID = R.Persoon_ID AND PR.Reservering_ID = R.ID AND PR.Plek_ID = P.ID AND P.ID = " + id.ToString());
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