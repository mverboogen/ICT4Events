using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class Media
    {
        private readonly int mediaID;
        private String title;
        private int likes;
        private DateTime postDate;

        // The user that has posted this mediafile
        private User mediaOwner;
        private int userID;
        private List<Comment> commentList;
        private List<MediaTag> tagList;

        public int ID
        {
            get { return mediaID; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public DateTime Postdate
        {
            get { return postDate; }
            set { postDate = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public User User
        {
            get { return mediaOwner; }
            set { mediaOwner = value; }
        }

        public Media(int id, String title, User owner, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.mediaOwner = owner;
            this.postDate = postdate;
        }

        public Media(int id, String title, int userid, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.userID = userid;
            this.postDate = postdate;
        }

    }
}
