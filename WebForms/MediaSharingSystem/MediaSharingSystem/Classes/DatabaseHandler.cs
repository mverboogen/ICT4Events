using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Oracle.DataAccess.Client;

namespace MediaSharingSystem
{
    class DatabaseHandler
    {
        private OracleCommand cmd;
        private OracleConnection con;
        private OracleDataReader dr;
        private static DatabaseHandler self;

        private DatabaseHandler()
        {
            self = this;
            Connect();
            //Disconnect();
        }

        /// <summary>
        ///     Gets the instance of this class.
        /// </summary>
        /// <returns>A Singleton instance of this class</returns>
        public static DatabaseHandler GetInstance()
        {
            if (self == null)
            {
                return new DatabaseHandler();
            }
            return self;
        }

        /// <summary>
        ///     Creates a connection with the Oracle database
        /// </summary>
        public void Connect()
        {
            con = new OracleConnection();

            con.ConnectionString = "User Id=Mediasharing; Password=Drowssap;Data Source=localhost/xe";
            //con.ConnectionString = "User Id=dbi316166;Password=ULo8qNEWmA;Data Source=fhictora01.fhict.local/fhictora";
            con.Open();
            Debug.WriteLine("CONNECTION SUCCESFULL");
        }

        /// <summary>
        ///     Disconnects the connection with the Oracle database.
        /// </summary>
        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        /// <summary>
        ///     Creates a new OracleCommand object to execute a e.g. SELECT(read) query.
        /// </summary>
        /// <param name="sql">The SQL query.</param>
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

        /// <summary>
        ///     Creates a new OracleCommand object to execute a e.g. UPDATE/DELETE(write) query.
        /// </summary>
        /// <param name="sql">The SQL query.</param>
        private void WriteData(string sql)
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Downloads the media by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A new Media object selected by the given identifier</returns>
        public Media DownloadMediaById(int id)
        {
            // Select the bijdrage with the type "bestand/bericht" and the same identifier as the parameter.
            // This will return the right startingpoint from which the rest of the necessary data could be retrieved.
            ReadData("SELECT * FROM BIJDRAGE WHERE (SOORT = 'bestand' OR SOORT = 'bericht') AND ID = " + id);

            Bijdrage bijdrage = null;
            Media media = null;

            try
            {
                while (dr.Read())
                {
                    int accountID = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdrage = new Bijdrage(id, accountID, date, soort);
                }

                User user = DownloadUserByID(bijdrage.UserID);
                // Check if it's a mediafile or a textfile.
                if (bijdrage.Soort.Equals("bestand"))
                {
                    ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageID = dr.GetInt32(0);
                            int categorieID = dr.GetInt32(1);
                            string title = dr.GetString(2);
                            string filePath = "Resources/Uploads/" + title;
                            int fileSize = dr.GetInt32(3);

                            media = new MediaFile(bijdrageID, categorieID, user, title, filePath);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
                else if (bijdrage.Soort.Equals("bericht"))
                {
                    ReadData("SELECT * FROM BERICHT WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageID = dr.GetInt32(0);
                            string title = dr.GetString(1);
                            string content = dr.GetString(2);

                            media = new TextMessage(bijdrageID, user, title, content);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }

                Disconnect();
                Connect();
                // Return the media that's selected by the given identifier.
                return media;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            Connect();
            return null;
        }

        /// <summary>
        ///     Downloads the media.
        /// </summary>
        /// <param name="amount">The amount of media items to download. (0=infinite)</param>
        /// <returns>List with media objects</returns>
        public List<Media> DownloadMedia(int amount = 10)
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();
            List<Media> mediaList = new List<Media>();

            // If there is no amountparameter given, SELECT all records matching the conditions.
            if (amount == 0)
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE SOORT = 'bestand' OR SOORT = 'bericht'");
            }
            else
            {
                ReadData("SELECT * FROM BIJDRAGE WHERE ROWNUM <= " + amount + " SOORT = 'bestand' OR SOORT = 'bericht'");
            }

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int accountID = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdrageList.Add(new Bijdrage(id, accountID, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdrageList)
                {
                    User user = DownloadUserByID(bijdrage.UserID);

                    if (bijdrage.Soort.Equals("bestand"))
                    {
                        ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                        try
                        {
                            while (dr.Read())
                            {
                                int bijdrageID = dr.GetInt32(0);
                                int categorieID = dr.GetInt32(1);
                                string title = dr.GetString(2);
                                string filePath = "Resources/Uploads/" + title;
                                int fileSize = dr.GetInt32(3);

                                mediaList.Add(new MediaFile(bijdrageID, categorieID, user, title, filePath));
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                    }
                    else if (bijdrage.Soort.Equals("bericht"))
                    {
                        ReadData("SELECT * FROM BERICHT WHERE TITEL IS NOT NULL AND BIJDRAGE_ID = " + bijdrage.ID);

                        try
                        {
                            while (dr.Read())
                            {
                                int bijdrageID = dr.GetInt32(0);
                                string title = dr.GetString(1);
                                string content = dr.GetString(2);

                                mediaList.Add(new TextMessage(bijdrageID, user, title, content));
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                        }
                    }
                }
                Disconnect();
                Connect();
                return mediaList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            Connect();
            return null;
        }

        /// <summary>
        ///     Download photo type media.
        /// </summary>
        /// <param name="amount">The amount of photo items to download. (0=infinite) </param>
        /// <returns>List with photo objects</returns>
        public List<Media> DownloadPhotos(int amount = 10)
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();
            List<Media> mediaList = new List<Media>();

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
                    int accountID = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdrageList.Add(new Bijdrage(id, accountID, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdrageList)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageID = dr.GetInt32(0);
                            int categorieID = dr.GetInt32(1);
                            string title = dr.GetString(2);
                            string filePath = "Resources/Uploads/" + title;
                            int fileSize = dr.GetInt32(3);

                            string extension = title.Substring(title.LastIndexOf('.'),
                                title.Length - title.LastIndexOf('.'));
                            // Filter only the image extensions
                            if (extension == ".jpg" || extension == ".png")
                            {
                                mediaList.Add(new MediaFile(bijdrageID, categorieID, user, title, filePath));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
                Disconnect();
                Connect();
                return mediaList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            Connect();
            return null;
        }

        /// <summary>
        ///     Download video type media.
        /// </summary>
        /// <param name="amount">The amount of video items to download. (0=infinite)</param>
        /// <returns>List with video objects</returns>
        public List<Media> DownloadVideos(int amount = 10)
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();
            List<Media> mediaList = new List<Media>();

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
                    int accountID = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdrageList.Add(new Bijdrage(id, accountID, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdrageList)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    ReadData("SELECT * FROM BESTAND WHERE BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageID = dr.GetInt32(0);
                            int categorieID = dr.GetInt32(1);
                            string title = dr.GetString(2);
                            string filePath = "Resources/Uploads/" + title;
                            int fileSize = dr.GetInt32(3);

                            string extension = title.Substring(title.LastIndexOf('.'),
                                title.Length - title.LastIndexOf('.'));
                            // Filter only the image extensions
                            if (extension == ".mp4" || extension == ".ogg")
                            {
                                mediaList.Add(new MediaFile(bijdrageID, categorieID, user, title, filePath));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
                Disconnect();
                Connect();
                return mediaList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            Connect();
            return null;
        }

        /// <summary>
        ///     Download message type media.
        /// </summary>
        /// <param name="amount">The amount of message items to download. (0=infinite)</param>
        /// <returns>List with message objects</returns>
        public List<Media> DownloadMessages(int amount = 10)
        {
            List<Bijdrage> bijdrageList = new List<Bijdrage>();
            List<Media> mediaList = new List<Media>();

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
                    int accountID = dr.GetInt32(1);
                    DateTime date = dr.GetDateTime(2);
                    string soort = dr.GetString(3);

                    bijdrageList.Add(new Bijdrage(id, accountID, date, soort));
                }

                foreach (Bijdrage bijdrage in bijdrageList)
                {
                    User user = DownloadUserByID(bijdrage.UserID);
                    ReadData("SELECT * FROM BERICHT WHERE TITEL IS NOT NULL AND BIJDRAGE_ID = " + bijdrage.ID);

                    try
                    {
                        while (dr.Read())
                        {
                            int bijdrageID = dr.GetInt32(0);
                            string title = dr.GetString(1);
                            string content = dr.GetString(2);

                            mediaList.Add(new TextMessage(bijdrageID, user, title, content));
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
                Disconnect();
                Connect();
                return mediaList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            Disconnect();
            Connect();
            return null;
        }

        /// <summary>
        /// Searches for media containing the given string.
        /// </summary>
        /// <param name="search">The searchstring.</param>
        /// <returns>List corresponding the searchstring.</returns>
        public List<Media> SearchMedia(string search)
        {
            List<int> idlist = new List<int>();
            List<Media> medialist = new List<Media>();
            
            ReadData(String.Format("SELECT BIJDRAGE_ID FROM BESTAND WHERE LOWER(BESTANDSLOCATIE) LIKE LOWER('%{0}%')", search));
            try
            {
                while (dr.Read())
                {
                    idlist.Add(dr.GetInt32(0));
                }

                ReadData(String.Format("SELECT BIJDRAGE_ID FROM BERICHT WHERE LOWER(TITEL) LIKE LOWER('%{0}%')", search));

                while (dr.Read())
                {
                    idlist.Add(dr.GetInt32(0));
                }

                foreach (int id in idlist)
                {
                    medialist.Add(DownloadMediaById(id));
                }

                return medialist;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        ///     Downloads the user by identifier.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>The user object selected by identifier</returns>
        public User DownloadUserByID(int userid)
        {
            ReadData("SELECT * FROM ACCOUNT WHERE ID = " + userid);

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string username = dr.GetString(1);
                    string mail = dr.GetString(2);

                    return new User(id, username, mail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return null;
        }

        /// <summary>
        ///     Downloads the user by username.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <returns>The user object selected by username</returns>
        public User DownloadUserByName(string name)
        {
            ReadData("SELECT * FROM ACCOUNT WHERE GEBRUIKERSNAAM = '" + name + "'");

            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string username = dr.GetString(1);
                    string mail = dr.GetString(2);

                    return new User(id, username, mail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return null;
        }

        /// <summary>
        ///     Downloads the likes.
        /// </summary>
        /// <param name="mediaid">The mediaid.</param>
        /// <returns>The amount of likes. -1 if an error occured</returns>
        public int DownloadLikes(int mediaid)
        {
            ReadData("SELECT COUNT(*) FROM ACCOUNT_BIJDRAGE WHERE \"LIKE\" = 1 AND BIJDRAGE_ID = " + mediaid);

            try
            {
                while (dr.Read())
                {
                    int amount = dr.GetInt32(0);
                    return amount;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return 0;
        }

        /// <summary>
        ///     Downloads the reports.
        /// </summary>
        /// <param name="mediaid">The mediaid.</param>
        /// <returns>The amount of reports. -1 if an error occured</returns>
        public int DownloadReports(int mediaid)
        {
            ReadData("SELECT COUNT(*) FROM ACCOUNT_BIJDRAGE WHERE ONGEWENST = 1 AND BIJDRAGE_ID = " + mediaid);

            try
            {
                while (dr.Read())
                {
                    int amount = dr.GetInt32(0);
                    return amount;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return 0;
        }

        /// <summary>
        ///     Downloads the comments for the given media.
        /// </summary>
        /// <param name="mediaid">The mediaid.</param>
        /// <returns>The corresponding Comment objects for this Media object</returns>
        public List<Comment> DownloadCommentsForMedia(int mediaid)
        {
            List<Comment> commentlist = new List<Comment>();
            ReadData(
                string.Format(
                    "SELECT * FROM BERICHT WHERE TITEL IS NULL AND BIJDRAGE_ID IN (SELECT BERICHT_ID FROM BIJDRAGE_BERICHT WHERE BIJDRAGE_ID = {0})",
                    mediaid));
            try
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string content = dr.GetString(2);

                    commentlist.Add(new Comment(id, content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return commentlist;
        }

        /// <summary>
        ///     Checks if the given media is liked by the given user.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="mediaid">The mediaid.</param>
        /// <returns>True if the given user has liked the given media</returns>
        public bool LikedBy(int userid, int mediaid)
        {
            ReadData(
                string.Format(
                    "SELECT COUNT(*) FROM ACCOUNT_BIJDRAGE WHERE \"LIKE\" = 1 AND ACCOUNT_ID = {0} AND BIJDRAGE_ID = {1}",
                    userid, mediaid));

            try
            {
                while (dr.Read())
                {
                    bool likedBy = dr.GetInt32(0) > 0 ? true : false;
                    return likedBy;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        /// <summary>
        ///     Checks if the given media is reported by the given user.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="mediaid">The mediaid.</param>
        /// <returns>True if the given user has reported the given media</returns>
        public bool ReportedBy(int userid, int mediaid)
        {
            ReadData(
                string.Format(
                    "SELECT COUNT(*) FROM ACCOUNT_BIJDRAGE WHERE ONGEWENST = 1 AND ACCOUNT_ID = {0} AND BIJDRAGE_ID = {1}",
                    userid, mediaid));

            try
            {
                while (dr.Read())
                {
                    bool reportedBy = dr.GetInt32(0) > 0 ? true : false;
                    return reportedBy;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        /// <summary>
        ///     Like the given post
        /// </summary>
        /// <param name="user">The user that likes the selected media.</param>
        /// <param name="id">The identifier of the selected media.</param>
        public void LikePost(User user, int id)
        {
            try
            {
                WriteData(
                    string.Format(
                        "INSERT INTO ACCOUNT_BIJDRAGE (ID, ACCOUNT_ID, BIJDRAGE_ID, \"LIKE\", ONGEWENST) VALUES (ACCOUNT_BIJDRAGE_FCSEQ.NEXTVAL,{0},{1},{2},{3})",
                        user.ID, id, 1, 0));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Undo a given like.
        /// </summary>
        /// <param name="user">The user that dislikes the selected media.</param>
        /// <param name="id">The identifier of the selected media.</param>
        public void DislikePost(User user, int id)
        {
            try
            {
                WriteData(
                    string.Format(
                        "DELETE FROM ACCOUNT_BIJDRAGE WHERE \"LIKE\" = 1 AND ACCOUNT_ID = {0} AND BIJDRAGE_ID = {1}",
                        user.ID, id));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Reports the post.
        /// </summary>
        /// <param name="user">The user that reports the selected media.</param>
        /// <param name="id">The identifier of the selected media.</param>
        public void ReportPost(User user, int id)
        {
            try
            {
                WriteData(
                    string.Format(
                        "INSERT INTO ACCOUNT_BIJDRAGE (ID, ACCOUNT_ID, BIJDRAGE_ID, \"LIKE\", ONGEWENST) VALUES (ACCOUNT_BIJDRAGE_FCSEQ.NEXTVAL,{0},{1},{2},{3})",
                        user.ID, id, 0, 1));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Undo a given report.
        /// </summary>
        /// <param name="user">The user that undoes the report.</param>
        /// <param name="id">The identifier of the selected media.</param>
        public void UnreportPost(User user, int id)
        {
            try
            {
                WriteData(
                    string.Format(
                        "DELETE FROM ACCOUNT_BIJDRAGE WHERE ONGEWENST = 1 AND ACCOUNT_ID = {0} AND BIJDRAGE_ID = {1}",
                        user.ID, id));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Uploads a comment.
        /// </summary>
        /// <param name="mediaid">The mediaid of the selected media.</param>
        /// <param name="user">The user that commits a comment.</param>
        /// <param name="comment">The comment content.</param>
        public void UploadComment(int mediaid, User user, string comment)
        {
            Disconnect();
            Connect();
            int newID = 0;
            try
            {
                // Select the next id.
                ReadData("SELECT BIJDRAGE_FCSEQ.NEXTVAL FROM DUAL");
                while (dr.Read())
                {
                    newID = dr.GetInt32(0);
                }
                // Insert the data in the right tables.
                WriteData(
                    string.Format(
                        "INSERT INTO BIJDRAGE (ID, ACCOUNT_ID, DATUM, SOORT) VALUES ({0}, {1}, to_date('{2}', 'dd-mm-yy HH24:MI:SS'), 'bericht')",
                        newID, user.ID, DateTime.Now));
                WriteData(string.Format("INSERT INTO BERICHT (BIJDRAGE_ID, TITEL, INHOUD) VALUES ({0}, NULL, '{1}')",
                    newID, comment));
                WriteData(string.Format("INSERT INTO BIJDRAGE_BERICHT (BIJDRAGE_ID, BERICHT_ID) VALUES ({0}, {1})",
                    mediaid, newID));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Uploads a file.
        /// </summary>
        /// <param name="filename">The filename(title) of the file.</param>
        /// <param name="user">The user that uploads the file.</param>
        public void UploadFile(string filename, User user)
        {
            int newID = 0;
            ReadData("SELECT BIJDRAGE_FCSEQ.NEXTVAL FROM DUAL");
            while (dr.Read())
            {
                newID = dr.GetInt32(0);
            }

            try
            {
                WriteData(
                    string.Format(
                        "INSERT INTO BIJDRAGE (ID, ACCOUNT_ID, DATUM, SOORT) VALUES ({0}, {1}, to_date('{2}', 'dd-mm-yy HH24:MI:SS'), 'bestand')",
                        newID, user.ID, DateTime.Now));
                WriteData(
                    string.Format("INSERT INTO CATEGORIE (BIJDRAGE_ID, CATEGORIE_ID, NAAM) VALUES ({0}, {1}, '{2}')",
                        newID, 4, filename));
                WriteData(
                    string.Format(
                        "INSERT INTO BESTAND (BIJDRAGE_ID, CATEGORIE_ID, BESTANDSLOCATIE, GROOTTE) VALUES ({0}, {1}, '{2}', 0)",
                        newID, 4, filename));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Uploads a message.
        /// </summary>
        /// <param name="title">The title of the message.</param>
        /// <param name="message">The message content.</param>
        /// <param name="user">The user that uploads the file.</param>
        public void UploadMessage(string title, string message, User user)
        {
            int newID = 0;
            ReadData("SELECT BIJDRAGE_FCSEQ.NEXTVAL FROM DUAL");
            while (dr.Read())
            {
                newID = dr.GetInt32(0);
            }

            try
            {
                WriteData(
                    string.Format(
                        "INSERT INTO BIJDRAGE (ID, ACCOUNT_ID, DATUM, SOORT) VALUES ({0}, {1}, to_date('{2}', 'dd-mm-yy HH24:MI:SS'), 'bericht')",
                        newID, user.ID, DateTime.Now));
                WriteData(string.Format("INSERT INTO BERICHT (BIJDRAGE_ID, TITEL, INHOUD) VALUES ({0}, '{1}', '{2}')",
                    newID, title, message));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}