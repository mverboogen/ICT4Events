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
        private UserData mediaOwner;
        private int userID;
        private List<CommentData> commentList;
        private List<TagData> tagList;
        // Contains all users that liked this post. 
        // This is also the counter that returns the amount of likes
        private List<UserData> likedByList;

        // contains all users that reported this post
        // This is also the counter that returns the amount of reports
        private List<UserData> reportedByList;

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

        public List<UserData> LikedBy
        {
            get { return likedByList; }
        }

        public int Reports
        {
            get { return reportedByList.Count; }
        }

        public List<UserData> ReportedBy
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

        public UserData User
        {
            get { return mediaOwner; }
            set { mediaOwner = value; }
        }

        public MediaData(int id, String title, UserData owner, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.mediaOwner = owner;
            this.postDate = postdate;

            likedByList = new List<UserData>();
            reportedByList = new List<UserData>();
            commentList = new List<CommentData>();
            tagList = new List<TagData>();

        }

        public MediaData(int id, String title, int userid, DateTime postdate)
        {
            this.mediaID = id;
            this.title = title;
            this.userID = userid;
            this.postDate = postdate;

            likedByList = new List<UserData>();
            reportedByList = new List<UserData>();
            commentList = new List<CommentData>();
            tagList = new List<TagData>();
        }

        public void Like(UserData user)
        {
            likedByList.Add(user);
        }

        public void Dislike(UserData user)
        {
            likedByList.Remove(user);
        }

        public void Report(UserData user)
        {
            reportedByList.Add(user);
        }

        public void UndoReport(UserData user)
        {
            reportedByList.Remove(user);
        }

        public void addComment(CommentData comment)
        {
            commentList.Add(comment);
        }

    }
}
