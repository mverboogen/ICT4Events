using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Data;
using System.Diagnostics;

namespace MediaSharingSystem
{
    class DatabaseHandler
    {

        private static DatabaseHandler self;

        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        private DatabaseHandler()
        {
            self = this;
            //Connect();
            //Disconnect();
        }

        public static DatabaseHandler GetInstance()
        {
            if (self == null)
            {
                return new DatabaseHandler();
            }
            else
            {
                return self;
            }
        }

        public void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = "User Id=Mediasharing; Password=Drowssap;Data Source=localhost/xe";
            con.Open();
            Console.WriteLine("CONNECTION SUCCESFULL");

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
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void WriteData(string sql)
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
                //MessageBox.Show(e.ToString());
            }
        }

        
        public int GetNextID(string columnname, string idname)
        {
            Connect();
            ReadData("SELECT MAX(" + idname + ") FROM " + columnname);
            try
            {
                while (dr.Read())
                {

                    int id = dr.GetInt32(0);

                    return id + 1;

                }
            }
            catch (InvalidCastException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Downloads the media.
        /// </summary>
        /// <param name="amount">The amount of media items to download.</param>
        /// <returns>List with media objects</returns>
        public List<Media> DownloadMedia(int amount = 10)
        {
            Connect();

            List<Bijdrage> bijdragelist = new List<Bijdrage>();
            List<Media> medialist = new List<Media>();

            if (amount == 0)
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE SOORT = 'bestand' OR SOORT = 'bericht'");
            }
            else
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE ROWNUM <= "+amount+" SOORT = 'bestand' OR SOORT = 'bericht'");
            }

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int accountid = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdragelist.Add(new Bijdrage(id, accountid, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdragelist)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    Connect();

                    if (bijdrage.Soort.Equals("bestand"))
                    {
                        
                        ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = "+bijdrage.ID);
                            
                        try
                        {
                            while(dr.Read())
                            {
                                int bijdrageid = dr.GetInt32(0);
                                int categorieid = dr.GetInt32(1);
                                string title = dr.GetString(2);
                                string filepath = "Resources/Uploads/"+title;
                                int filesize = dr.GetInt32(3);

                                medialist.Add(new MediaFile(bijdrageid, categorieid, user, title, filepath));
                            }
                        }
                        catch(Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }

                    }
                    else if(bijdrage.Soort.Equals("bericht"))
                    {
                        ReadData("SELECT * FROM BERICHT WHERE BIJDRAGE_ID = " + bijdrage.ID);

                        try
                        {
                            while (dr.Read())
                            {
                                int bijdrageid = dr.GetInt32(0);
                                string title = dr.GetString(1);
                                string content = dr.GetString(2);

                                medialist.Add(new TextMessage(bijdrageid, user, title, content));
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                    }
                }
                Disconnect();
                return medialist;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }

        public List<Media> DownloadPhotos(int amount = 10)
        {
            Connect();

            List<Bijdrage> bijdragelist = new List<Bijdrage>();
            List<Media> medialist = new List<Media>();

            if (amount == 0)
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE SOORT = 'bestand'");
            }
            else
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE ROWNUM <= " + amount + " SOORT = 'bestand'");
            }

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int accountid = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdragelist.Add(new Bijdrage(id, accountid, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdragelist)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    Connect();
                    ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageid = dr.GetInt32(0);
                            int categorieid = dr.GetInt32(1);
                            string title = dr.GetString(2);
                            string filepath = "Resources/Uploads/" + title;
                            int filesize = dr.GetInt32(3);

                            string extension = title.Substring(title.LastIndexOf('.'), title.Length - title.LastIndexOf('.'));
                            // Filter only the image extensions
                            if(extension == ".jpg" || extension == ".png"){
                                medialist.Add(new MediaFile(bijdrageid, categorieid, user, title, filepath));
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

                Disconnect();
                return medialist;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }

        public List<Media> DownloadVideos(int amount = 10)
        {
            Connect();

            List<Bijdrage> bijdragelist = new List<Bijdrage>();
            List<Media> medialist = new List<Media>();

            if (amount == 0)
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE SOORT = 'bestand'");
            }
            else
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE ROWNUM <= " + amount + " SOORT = 'bestand'");
            }

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int accountid = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdragelist.Add(new Bijdrage(id, accountid, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdragelist)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    Connect();
                    ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageid = dr.GetInt32(0);
                            int categorieid = dr.GetInt32(1);
                            string title = dr.GetString(2);
                            string filepath = "Resources/Uploads/" + title;
                            int filesize = dr.GetInt32(3);

                            string extension = title.Substring(title.LastIndexOf('.'), title.Length - title.LastIndexOf('.'));
                            // Filter only the image extensions
                            if (extension == ".mp4" || extension == ".ogg")
                            {
                                medialist.Add(new MediaFile(bijdrageid, categorieid, user, title, filepath));
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

                Disconnect();
                return medialist;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }

        public List<Media> DownloadMessages(int amount = 10)
        {
            Connect();

            List<Bijdrage> bijdragelist = new List<Bijdrage>();
            List<Media> medialist = new List<Media>();

            if (amount == 0)
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE SOORT = 'bericht'");
            }
            else
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE ROWNUM <= " + amount + " SOORT = 'bericht'");
            }

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int accountid = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdragelist.Add(new Bijdrage(id, accountid, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdragelist)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    Connect();
                    ReadData("SELECT * FROM BERICHT WHERE TITEL IS NOT NULL AND BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageid = dr.GetInt32(0);
                            string title = dr.GetString(1);
                            string content = dr.GetString(2);
                            
                            medialist.Add(new TextMessage(bijdrageid, user, title, content));

                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

                Disconnect();
                return medialist;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }

        /// <summary>
        /// Downloads the user by identifier.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>The user object</returns>
        public User DownloadUserByID(int userid)
        {
            Connect();

            ReadData("SELECT * FROM ACCOUNT WHERE ID = " + userid);

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string username = dr.GetString(1);
                    string mail = dr.GetString(2);

                    Disconnect();
                    return new User(id, username, mail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }

        public User DownloadUserByName(string name)
        {
            Connect();

            ReadData("SELECT * FROM ACCOUNT WHERE GEBRUIKERSNAAM = " + name);

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string username = dr.GetString(1);
                    string mail = dr.GetString(2);

                    Disconnect();
                    return new User(id, username, mail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            return null;
        }





        public void LikePost(int id)
        {

        }
    }
}