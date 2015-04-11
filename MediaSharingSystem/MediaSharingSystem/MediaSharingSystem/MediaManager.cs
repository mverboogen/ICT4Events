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
        private List<Media> mediaList;
        private String eventName;

        // Custom DatabaseHandler
        private DatabaseManager dbmanager;

        public List<User> Userlist
        {
            get { return userList; }
        }

        public List<Media> Medialist
        {
            get { return mediaList; }
        }

        public String Eventname
        {
            get { return eventName; }
            set { eventName = value; }
        }

        public MediaManager(String eventname)
        {
            userList = new List<User>();
            mediaList = new List<Media>();
            eventName = eventname;

            // Create databasemanager and connect to the database
            dbmanager = new DatabaseManager();
            dbmanager.Connect();
        }

        /// <summary>
        /// This method downloads all media from the database and prepares it so there will be a ready to user media list with all derived objects with it
        /// </summary>
        public void initializeData()
        {
            addUserRange(dbmanager.getAllUsers());

            // Downloads all media
            List<Media> medialist = new List<Media>();
            medialist = dbmanager.getAllMedia();

            // Downloads all photos and links them with the right parent object
            List<AVPhoto> photolist = new List<AVPhoto>();
            photolist = dbmanager.getAllPhotos(medialist);

            // Downloads all videos and links them with the right parent object
            List<AVVideo> videolist = new List<AVVideo>();
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
            addMediaRange(medialist);

        }

        public bool addMedia(Media media)
        {
            mediaList.Add(media);
            return true;
        }

        public bool addMediaRange(List<Media> list)
        {
            mediaList.AddRange(list);
            return true;
        }

        public bool addMessage(TextMessage message)
        {
            mediaList.Add(message);
            return true;
        }

        public bool addVideo(AVVideo video)
        {
            mediaList.Add(video);
            return true;
        }

        public bool addPhoto(AVPhoto photo)
        {
            mediaList.Add(photo);
            return true;
        }

        public bool removeMedia(Media media)
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
        
    }
}
