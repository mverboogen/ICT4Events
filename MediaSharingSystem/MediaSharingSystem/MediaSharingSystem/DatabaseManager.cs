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

namespace MediaSharingSystem
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
            con.ConnectionString = "User Id=system; Password=Drowssap;Data Source=localhost/xe";
            con.Open();
            Console.WriteLine("CONNECTION SUCCESFULL");

        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        
        public List<Media> getAllMedia()
        {
            List<Media> medialist = new List<Media>();

            ReadData("SELECT * FROM Media");

            try
            {
                while (dr.Read())
                {
                    int mediaid;
                    string mediatitle;
                    int gebruikerid;
                    DateTime postdate;
                    int likes;

                    mediaid = dr.GetInt32(0);
                    gebruikerid = dr.GetInt32(1);
                    mediatitle = dr.GetString(2);
                    postdate = dr.GetDateTime(3);
                    likes = dr.GetInt32(4);

                    medialist.Add(new Media(mediaid, mediatitle, gebruikerid, postdate));
                }

                return medialist;
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        /// <summary>
        /// Downloads all photos and links them with the right parent object
        /// </summary>
        /// <param name="list">The parent medialist to connect the photos to</param>
        /// <returns>A list with all AVPhoto objects</returns>
        public List<AVPhoto> getAllPhotos(List<Media> list)
        {
            List<AVPhoto> photolist = new List<AVPhoto>();

            ReadData("SELECT * FROM Photo");

            try
            {
                while (dr.Read())
                {
                    int mediaid;
                    string filepath;
                    int width;
                    int height;

                    mediaid = dr.GetInt32(0);
                    filepath = dr.GetString(1);
                    width = dr.GetInt32(2);
                    height = dr.GetInt32(3);

                    foreach (Media media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            photolist.Add(new AVPhoto(media.ID, media.Title, media.UserID, filepath, media.Postdate, width, height));
                        }
                    }
                }

                return photolist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        /// <summary>
        /// Downloads all videos and links them with the right parent object
        /// </summary>
        /// <param name="list">The parent medialist to connect the videos to</param>
        /// <returns>A list with all AVVideo objects</returns>
        public List<AVVideo> getAllVideos(List<Media> list)
        {
            List<AVVideo> photolist = new List<AVVideo>();

            ReadData("SELECT * FROM Video");

            try
            {
                while (dr.Read())
                {
                    int mediaid;
                    string filepath;
                    int width;
                    int height;
                    int duration;

                    mediaid = dr.GetInt32(0);
                    filepath = dr.GetString(1);
                    duration = dr.GetInt32(2);
                    width = dr.GetInt32(3);
                    height = dr.GetInt32(4);

                    foreach (Media media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            photolist.Add(new AVVideo(mediaid, media.Title, media.UserID, filepath, media.Postdate, width, height, duration));
                        }
                    }
                }

                return photolist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        /// <summary>
        /// Downloads all videos and links them with the right parent object
        /// </summary>
        /// <param name="list">The parent medialist to connect the videos to</param>
        /// <returns>A list with all AVVideo objects</returns>
        public List<TextMessage> getAllMessages(List<Media> list)
        {
            List<TextMessage> messagelist = new List<TextMessage>();

            ReadData("SELECT * FROM Message");

            try
            {
                while (dr.Read())
                {
                    int mediaid;
                    string content;

                    mediaid = dr.GetInt32(0);
                    content = dr.GetString(1);

                    foreach (Media media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            messagelist.Add(new TextMessage(mediaid, media.Title,media.UserID, media.Postdate, content));
                        }
                    }
                }

                return messagelist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<User> getAllUsers()
        {
            List<User> userlist = new List<User>();

            ReadData("SELECT * FROM Gebruiker");

            try
            {
                while (dr.Read())
                {
                    int userid;
                    String username;
                    String password;

                    userid = dr.GetInt32(0);
                    username = dr.GetString(1);
                    password = dr.GetString(2);

                    User media = new User(userid, username, password);

                    userlist.Add(media);
                }

                return userlist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }
        /*
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
        }*/
    }
}
