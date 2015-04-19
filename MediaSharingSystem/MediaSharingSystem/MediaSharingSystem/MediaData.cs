using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class MediaData
    {
        private readonly int mediaID;
        private String title;
        private DateTime postDate;

        // The user that has posted this mediafile
        private User mediaOwner;
        private int userID;
        private List<CommentData> commentList;
        private List<MediaTag> tagList;
        // Contains all users that liked this post. 
        // This is also the counter that returns the amount of likes
        private List<User> likedByList;

        // contains all users that reported this post
        // This is also the counter that returns the amount of reports
        private List<User> reportedByList;

        public int ID
        {
            get { return mediaID; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public List<CommentData> Comments
        {
            get { return commentList; }
            set { commentList = value; }
        }

        public int Likes
        {
            get { return likedByList.Count; }
        }

        public List<User> LikedBy
        {
            get { return likedByList; }
        }

        public int Reports
        {
            get { return reportedByList.Count; }
        }

        public List<User> ReportedBy
        {
            get { return reportedByList; }
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

        public MediaData(int id, String title, User owner, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.mediaOwner = owner;
            this.postDate = postdate;

            likedByList = new List<User>();
            reportedByList = new List<User>();
        }

        public MediaData(int id, String title, int userid, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.userID = userid;
            this.postDate = postdate;

            likedByList = new List<User>();
            reportedByList = new List<User>();
        }

        public void Like(User user)
        {
            likedByList.Add(user);
        }

        public void Dislike(User user)
        {
            likedByList.Remove(user);
        }

        public void Report(User user)
        {
            reportedByList.Add(user);
        }

        public void UndoReport(User user)
        {
            reportedByList.Remove(user);
        }

    }
}
