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
            con.ConnectionString = "User ID=dbi317913; Password=I8zOKDgbJd; Data Source=192.168.15.50:1521/fhictora;";
            //con.ConnectionString = "User Id=system; Password=Drowssap;Data Source=localhost/xe";
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
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
            }
        }
        
        public List<MediaData> getAllMedia()
        {
            List<MediaData> medialist = new List<MediaData>();

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

                    MediaData media = new MediaData(mediaid, mediatitle, gebruikerid, postdate);
                    //media.Likes = likes;

                    medialist.Add(media);
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
        public List<AVPhotoData> getAllPhotos(List<MediaData> list)
        {
            List<AVPhotoData> photolist = new List<AVPhotoData>();

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

                    foreach (MediaData media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            AVPhotoData photo = new AVPhotoData(media.ID, media.Title, media.UserID, filepath, media.Postdate, width, height);
                            //photo.Likes = media.Likes;
                            photolist.Add(photo);
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
        public List<AVVideoData> getAllVideos(List<MediaData> list)
        {
            List<AVVideoData> videolist = new List<AVVideoData>();

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

                    foreach (MediaData media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            AVVideoData video = new AVVideoData(mediaid, media.Title, media.UserID, filepath, media.Postdate, width, height, duration);
                            video.PreviewImage = Properties.Resources.video_call;
                            //video.Likes = media.Likes;
                            videolist.Add(video);
                        }
                    }
                }

                return videolist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        /// <summary>
        /// Downloads all messages and links them with the right parent object
        /// </summary>
        /// <param name="list">The parent medialist to connect the message to</param>
        /// <returns>A list with all TextMessage objects</returns>
        public List<MessageData> getAllMessages(List<MediaData> list)
        {
            List<MessageData> messagelist = new List<MessageData>();

            ReadData("SELECT * FROM Message");

            try
            {
                while (dr.Read())
                {
                    int mediaid;
                    string content;

                    mediaid = dr.GetInt32(0);
                    content = dr.GetString(1);

                    foreach (MediaData media in list)
                    {
                        if (media.ID == mediaid)
                        {
                            MessageData message = new MessageData(mediaid, media.Title, media.UserID, media.Postdate, content);
                            //message.Likes = media.Likes;
                            messagelist.Add(message);
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

        public List<UserData> getAllUsers()
        {
            List<UserData> userlist = new List<UserData>();

            ReadData("SELECT * FROM Gebruiker");

            try
            {
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        int userid;
                        String username;
                        String password;
                        bool isadmin;

                        userid = dr.GetInt32(0);
                        username = dr.GetString(1);
                        password = dr.GetString(2);
                        isadmin = dr.GetInt32(3) == 1 ? true : false;


                        UserData media = new UserData(userid, username, password, isadmin);

                        userlist.Add(media);
                    }
                }

                return userlist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<LikeData> getAllLikes()
        {
            List<LikeData> likelist = new List<LikeData>();

            ReadData("SELECT * FROM Likes");

            try
            {
                while (dr.Read())
                {
                    int likeid = 0;
                    int mediaid = 0;
                    int commentid = 0;
                    int userid = 0;

                    likeid = dr.GetInt32(0);
                    if (!dr.IsDBNull(1))
                    {
                        mediaid = dr.GetInt32(1);

                    }
                    if (!dr.IsDBNull(2))
                    {
                        commentid = dr.GetInt32(2);
                    }

                    userid = dr.GetInt32(3);

                    LikeData like = new LikeData(likeid, mediaid, commentid, userid);

                    likelist.Add(like);
                }

                return likelist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<ReportData> getAllReports()
        {
            List<ReportData> reportlist = new List<ReportData>();

            ReadData("SELECT * FROM Reports");

            try
            {
                while (dr.Read())
                {
                    int reportid = 0;
                    int mediaid = 0;
                    int userid = 0;

                    reportid = dr.GetInt32(0);
                    mediaid = dr.GetInt32(1);
                    userid = dr.GetInt32(2);

                    ReportData report = new ReportData(reportid, mediaid, userid);

                    reportlist.Add(report);
                }

                return reportlist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public List<CommentData> getAllComments()
        {
            List<CommentData> commentlist = new List<CommentData>();

            ReadData("SELECT * FROM MediaComment");

            try
            {
                while (dr.Read())
                {
                    int commentid = 0;
                    int mediaid = 0;
                    int userid = 0;
                    string content = "";
                    int likes = 0;

                    commentid = dr.GetInt32(0);
                    mediaid = dr.GetInt32(1);
                    userid = dr.GetInt32(2);
                    content = dr.GetString(3);
                    if (!dr.IsDBNull(4))
                    {
                        likes = dr.GetInt32(4);
                    }

                    CommentData comment = new CommentData(commentid, userid, mediaid, content);

                    commentlist.Add(comment);
                }

                return commentlist;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;

        }

        public void likePost(MediaData media, UserData user)
        {
            WriteData("UPDATE MEDIA SET LIKES = " + media.Likes + " WHERE MediaID = " + media.ID);

            int nextid = getNextID("LikeID", "Likes");

            WriteData("INSERT INTO LIKES(likeID, mediaID, commentID, gebruikerID) VALUES (" + nextid + "," + media.ID + ", null ," + user.ID + ")");
        }

        public void dislikePost(MediaData media, UserData user)
        {
            WriteData("UPDATE MEDIA SET LIKES = " + media.Likes + " WHERE MediaID = " + media.ID);
            WriteData("DELETE FROM LIKES WHERE gebruikerID = " + user.ID +"AND mediaID = "+media.ID);
        }

        public void likeComment(CommentData comment, UserData user)
        {
            WriteData("UPDATE MEDIACOMMENT SET LIKES = " + comment.Likes + " WHERE CommentID = " + comment.ID);

            int nextid = getNextID("LikeID", "Likes");

            WriteData("INSERT INTO LIKES(likeID, mediaID, commentID, gebruikerID) VALUES (" + nextid + ", null ,"+ comment.ID +"," + user.ID + ")");
        }

        public void dislikeComment(CommentData comment, UserData user)
        {
            WriteData("UPDATE MEDIACOMMENT SET LIKES = " + comment.Likes + " WHERE CommentID = " + comment.ID);
            WriteData("DELETE FROM LIKES WHERE gebruikerID = " + user.ID + "AND commentID = " + comment.ID);
        }

        public void reportPost(MediaData media, UserData user)
        {

            int nextid = getNextID("reportID", "Reports");

            WriteData("INSERT INTO Reports(reportID, mediaID, gebruikerID) VALUES (" + nextid + "," + media.ID + "," + user.ID + ")");
        }

        public void dereportPost(MediaData media, UserData user)
        {
            WriteData("DELETE FROM Reports WHERE gebruikerID = " + user.ID + "AND mediaID = " + media.ID);
        }

        public void addCommentToMedia(MediaData media, CommentData comment)
        {

            int nextid = getNextID("CommentID","MediaComment");
         
            WriteData("INSERT INTO MEDIACOMMENT(CommentID, MediaID, GebruikerID, Inhoud, Likes) VALUES ("+nextid+","+media.ID+","+comment.UserID+",'"+comment.Content+"', 0)");
        }

        /// <summary>
        /// Returns the next id in the given table
        /// </summary>
        /// <param name="table">The table you want the next id from</param>
        /// <returns></returns>
        public int getNextID(string idcolumn, string table)
        {
            ReadData("SELECT MAX(" + idcolumn + ") FROM " + table);
            int nextid = 1;
            try
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        nextid = dr.GetInt32(0) + 1;
                        return nextid;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        public void uploadMedia(MediaData media)
        {
            if (media is AVPhotoData)
            {
                AVPhotoData photo = (AVPhotoData)media;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO MEDIA (MediaID, GebruikerID, Title, PostDate, Likes) VALUES (:MediaID, :GebruikerID, :Title, :PostDate, :Likes)";
                cmd.Parameters.Add("MediaID", OracleDbType.Int32).Value = media.ID;
                cmd.Parameters.Add("GebruikerID", OracleDbType.Int32).Value = media.UserID;
                cmd.Parameters.Add("Title", OracleDbType.Varchar2).Value = media.Title;
                cmd.Parameters.Add("PostDate", OracleDbType.Date).Value = media.Postdate.Date;
                cmd.Parameters.Add("Likes", OracleDbType.Int32).Value = media.Likes;
                cmd.ExecuteNonQuery();

                WriteData("INSERT INTO PHOTO (MediaID, FilePath, Width, Height) VALUES (" + media.ID + ",'" + photo.Filepath + "'," + photo.Width + "," + photo.Height+")");
            }
            else if (media is AVVideoData)
            {
                AVVideoData video = (AVVideoData)media;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO MEDIA (MediaID, GebruikerID, Title, PostDate, Likes) VALUES (:MediaID, :GebruikerID, :Title, :PostDate, :Likes)";
                cmd.Parameters.Add("MediaID", OracleDbType.Int32).Value = media.ID;
                cmd.Parameters.Add("GebruikerID", OracleDbType.Int32).Value = media.UserID;
                cmd.Parameters.Add("Title", OracleDbType.Varchar2).Value = media.Title;
                cmd.Parameters.Add("PostDate", OracleDbType.Date).Value = media.Postdate;
                cmd.Parameters.Add("Likes", OracleDbType.Int32).Value = media.Likes;
                cmd.ExecuteNonQuery();


                WriteData("INSERT INTO VIDEO (MediaID, FilePath, MovieLength, Width, Height) VALUES (" + media.ID + ",'" + video.Filepath + "',"+video.Duration+","+ video.Width + "," + video.Height + ")");
            }
            else if (media is MessageData)
            {
                MessageData message = (MessageData)media;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO MEDIA (MediaID, GebruikerID, Title, PostDate, Likes) VALUES (:MediaID, :GebruikerID, :Title, :PostDate, :Likes)";
                cmd.Parameters.Add("MediaID", OracleDbType.Int32).Value = media.ID;
                cmd.Parameters.Add("GebruikerID", OracleDbType.Int32).Value = media.UserID;
                cmd.Parameters.Add("Title", OracleDbType.Varchar2).Value = media.Title;
                cmd.Parameters.Add("PostDate", OracleDbType.Date).Value = media.Postdate;
                cmd.Parameters.Add("Likes", OracleDbType.Int32).Value = media.Likes;
                cmd.ExecuteNonQuery();

                WriteData("INSERT INTO MESSAGE (MediaID, MessageText) VALUES (" + media.ID + ",'" + message.Content + "')");
            }
        }

    }
}
