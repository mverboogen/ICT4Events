using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class CommentData
    {
        private int commentID;
        private int userID;
        private int mediaID;
        private int likes;
        private string content;
        // The user that has posted this comment
        private UserData commentOwner;

        // Contains all users that liked this post. 
        // This is also the counter that returns the amount of likes
        private List<UserData> likedByList;

        // contains all users that reported this post
        // This is also the counter that returns the amount of reports
        private List<UserData> reportedByList;

        public int ID
        {
            get { return this.commentID; }
        }

        public int UserID
        {
            get { return this.userID; }
        }

        public int MediaID
        {
            get { return mediaID; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public UserData CommentOwner
        {
            get { return commentOwner; }
            set { commentOwner = value; }
        }

        public CommentData(int commentid, UserData owner, int mediaid, string content)
        {
            commentID = commentid;
            commentOwner = owner;
            this.content = content;
            mediaID = mediaid;
            this.userID = owner.ID;

            likedByList = new List<UserData>();
            reportedByList = new List<UserData>();
        }

        public CommentData(int commentid, int userid, int mediaid, string content)
        {
            commentID = commentid;
            userID = userid;
            this.content = content;
            mediaID = mediaid;

            likedByList = new List<UserData>();
            reportedByList = new List<UserData>();
        }

        public int Likes
        {
            get { return likedByList.Count; }
        }

        public List<UserData> LikedBy
        {
            get { return likedByList; }
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

    }
}
