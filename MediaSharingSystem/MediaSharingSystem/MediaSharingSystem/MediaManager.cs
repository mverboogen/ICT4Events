using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class MediaManager
    {
        private List<User> userList;
        private List<MediaData> mediaList;
        private String eventName;
        private User currentUser;

        // Custom DatabaseHandler
        private DatabaseManager dbmanager;

        public List<User> Userlist
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

        public User CurrentUser
        {
            get { return currentUser; }
        }

        public MediaManager(String eventname)
        {
            
            // THIS IS A DUMMY USER ONLY.. 
            currentUser = new User(1, "JasperRouwhorst", "Drowssap", true);


            userList = new List<User>();
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
            List<TextMessage> messagelist = new List<TextMessage>();
            messagelist = dbmanager.getAllMessages(medialist);

            // Clears the unlinked medialist and adds the derived objects to the list
            medialist.Clear();
            medialist.AddRange(photolist);
            medialist.AddRange(videolist);
            medialist.AddRange(messagelist);

            // Adds the complete medialist to the mediamanager so it's available for use now
            mediaList.Clear();
            addMediaRange(medialist);

            // Downloads all likes
            List<LikeData> likelist = dbmanager.getAllLikes();
            foreach (LikeData like in likelist)
            {
                foreach (MediaData media in medialist)
                {
                    if (like.MediaID == media.ID)
                    {
                        foreach (User user in userList)
                        {
                            if (user.ID == like.UserID)
                            {
                                media.Like(user);
                            }
                        }
                    }
                }
            }

            // Download all reports
            List<Report> reportlist = dbmanager.getAllReports();
            foreach (Report report in reportlist)
            {
                foreach (MediaData media in medialist)
                {
                    if (report.MediaID == media.ID)
                    {
                        foreach (User user in userList)
                        {
                            if (user.ID == report.UserID)
                            {
                                media.Report(user);
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

        public bool addMessage(TextMessage message)
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
            return true;
        }

        public bool addUser(User user)
        {
            userList.Add(user);
            return true;
        }

        public bool addUserRange(List<User> list)
        {
            userList.AddRange(list);
            return true;
        }

        public User getUserById(int id)
        {
            try
            {
                foreach (User user in userList)
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

        public void uploadMedia(MediaData media)
        {
            dbmanager.uploadMedia(media);
        }
        
    }
}
