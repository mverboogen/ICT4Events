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

    }
}
