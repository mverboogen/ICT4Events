using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class MediaManager
    {
        private List<UserData> userList;
        private List<MediaData> mediaList;
        private String eventName;
        private UserData currentUser;

        // Custom DatabaseHandler
        private DatabaseManager dbmanager;

        public List<UserData> Userlist
        {
            get { return userList; }
        }

        public List<MediaData> Medialist
        {
            get { return mediaList; }
        }

        public String Eventname
        {
            get { return eventName; }
            set { eventName = value; }
        }

        public UserData CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public MediaManager(String eventname)
        {
            
            userList = new List<UserData>();
            mediaList = new List<MediaData>();
            eventName = eventname;

            // Create databasemanager and connect to the database
            dbmanager = new DatabaseManager();
            dbmanager.Connect();
        }

        /// <summary>
        /// This method downloads all media from the database and prepares it so there will be a ready to user media list with all derived objects with it
        /// </summary>
        public void downloadData()
        {
            addUserRange(dbmanager.getAllUsers());

            // Downloads all media
            List<MediaData> medialist = new List<MediaData>();
            medialist = dbmanager.getAllMedia();

            

            // Downloads all photos and links them with the right parent object
            List<AVPhotoData> photolist = new List<AVPhotoData>();
            photolist = dbmanager.getAllPhotos(medialist);

            // Downloads all videos and links them with the right parent object
            List<AVVideoData> videolist = new List<AVVideoData>();
            videolist = dbmanager.getAllVideos(medialist);

            // Downloads all messages and links them with the right parent object
            List<MessageData> messagelist = new List<MessageData>();
            messagelist = dbmanager.getAllMessages(medialist);

            // Clears the unlinked medialist and adds the derived objects to the list
            medialist.Clear();
            medialist.AddRange(photolist);
            medialist.AddRange(videolist);
            medialist.AddRange(messagelist);

            // Adds the complete medialist to the mediamanager so it's available for use now
            mediaList.Clear();
            addMediaRange(medialist);

            foreach (MediaData media in mediaList)
            {
                foreach (UserData user in userList)
                {
                    if (media.UserID == user.ID)
                    {
                        media.User = user;
                        break;
                    }
                }
            }

            

            // Download all reports
            List<ReportData> reportlist = dbmanager.getAllReports();
            foreach (ReportData report in reportlist)
            {
                foreach (MediaData media in medialist)
                {
                    if (report.MediaID == media.ID)
                    {
                        foreach (UserData user in userList)
                        {
                            if (user.ID == report.UserID)
                            {
                                media.Report(user);
                            }
                        }
                    }
                }
            }

            // Download all comments
            List<CommentData> commentlist = dbmanager.getAllComments();
            foreach (CommentData comment in commentlist)
            {
                foreach (MediaData media in medialist)
                {
                    if (comment.MediaID == media.ID)
                    {
                        media.addComment(comment);
                    }
                }
            }

            foreach (CommentData comment in commentlist)
            {
                foreach (UserData user in userList)
                {
                    if (comment.UserID == user.ID)
                    {
                        comment.CommentOwner = user;
                        break;
                    }
                }
            }

            // Downloads all likes
            List<LikeData> likelist = dbmanager.getAllLikes();
            foreach (LikeData like in likelist)
            {
                foreach (MediaData media in medialist)
                {
                    if (like.MediaID == media.ID)
                    {
                        foreach (UserData user in userList)
                        {
                            if (user.ID == like.UserID)
                            {
                                media.Like(user);
                            }
                        }
                    }
                }
                foreach (CommentData comment in commentlist)
                {
                    if (like.CommentID == comment.ID)
                    {
                        foreach (UserData user in userList)
                        {
                            if (user.ID == like.UserID)
                            {
                                comment.Like(user);
                            }
                        }
                    }
                }
            }

        }

        public bool addMedia(MediaData media)
        {
            mediaList.Add(media);
            return true;
        }

        public bool addMediaRange(List<MediaData> list)
        {
            mediaList.AddRange(list);
            return true;
        }

        public bool addMessage(MessageData message)
        {
            mediaList.Add(message);
            return true;
        }

        public bool addVideo(AVVideoData video)
        {
            mediaList.Add(video);
            return true;
        }

        public bool addPhoto(AVPhotoData photo)
        {
            mediaList.Add(photo);
            return true;
        }

        public bool removeMedia(MediaData media)
        {
            mediaList.Remove(media);
            dbmanager.removeMedia(media);
            return true;
        }

        public bool addUser(UserData user)
        {
            userList.Add(user);
            return true;
        }

        public bool addUserRange(List<UserData> list)
        {
            userList.AddRange(list);
            return true;
        }

        public UserData getUserById(int id)
        {
            try
            {
                foreach (UserData user in userList)
                {
                    if (user.ID == id)
                    {
                        return user;
                    }
                }
                throw new NullReferenceException("No user found with this ID");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Increments the likes of the selected media
        /// and sends an update query to the database
        /// </summary>
        /// <param name="media">The media you want to like</param>
        public void likeMedia(MediaData media)
        {
            media.Like(currentUser);
            dbmanager.likePost(media, currentUser);
        }

        /// <summary>
        /// Decrement the likes of the selected media
        /// and sends an delete query to the database
        /// </summary>
        /// <param name="media">The media you want to dislike</param>
        public void dislikeMedia(MediaData media)
        {
            media.Dislike(currentUser);
            dbmanager.dislikePost(media, currentUser);
        }

        /// <summary>
        /// Increments the likes of the selected comment
        /// and sends an update query to the database
        /// </summary>
        /// <param name="comment">The comment you want to like</param>
        public void likeComment(CommentData comment)
        {
            comment.Like(currentUser);
            dbmanager.likeComment(comment, currentUser);
        }

        /// <summary>
        /// Decrement the likes of the selected comment
        /// and sends an delete query to the database
        /// </summary>
        /// <param name="comment">The media you want to dislike</param>
        public void dislikeComment(CommentData comment)
        {
            comment.Dislike(currentUser);
            dbmanager.dislikeComment(comment, currentUser);
        }

        /// <summary>
        /// Increments the reports of the selected media
        /// and sends an update query to the database
        /// </summary>
        /// <param name="media">The media you want to report</param>
        public void reportMedia(MediaData media)
        {
            media.Report(currentUser);
            dbmanager.reportPost(media, currentUser);
        }

        /// <summary>
        /// Decrement the reports of the selected media
        /// and sends an delete query to the database
        /// </summary>
        /// <param name="media">The media you want to dereport</param>
        public void dereportMedia(MediaData media)
        {
            media.UndoReport(currentUser);
            dbmanager.dereportPost(media, currentUser);
        }

        public void addCommentToMedia(MediaData media, string content)
        {
            CommentData comment = new CommentData(dbmanager.getNextID("CommentID", "Mediacomment"), currentUser, media.ID, content);
            media.addComment(comment);
            dbmanager.addCommentToMedia(media, comment);
        }

        public void uploadAVMedia(string filetype, string title, string summary, string destination)
        {
            switch (filetype)
            {
                case "Photo":
                    AVPhotoData photo = new AVPhotoData(dbmanager.getNextID("MediaID", "Media"), title, currentUser, destination, DateTime.Today, 0, 0);
                    addPhoto(photo);
                    dbmanager.uploadMedia(photo);
                    break;
                case "Video":
                    AVVideoData video = new AVVideoData(dbmanager.getNextID("MediaID", "Media"), title, currentUser, destination, DateTime.Today, 0, 0, 0);
                    addVideo(video);
                    dbmanager.uploadMedia(video);
                    break;
            }
        }

        public void uploadMessageMedia(string filetype, string title, string summary)
        {
            MessageData message = new MessageData(dbmanager.getNextID("MediaID", "Media"), title, currentUser, DateTime.Today, summary);
            addMessage(message);
            dbmanager.uploadMedia(message);
        }
        
    }
}
