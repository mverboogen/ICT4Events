using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class CommentData
    {
        private int userID;
        private int likes;
        private string content;
        // The user that has posted this comment
        private User commentOwner;

        public int ID
        {
            get { return this.userID; }
        }

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public User CommentOwner
        {
            get { return commentOwner; }
            set { commentOwner = value; }
        }

        public CommentData(User owner, string content)
        {
            commentOwner = owner;
            this.content = content;
        }

        public CommentData(int userid, string content)
        {
            userID = userid;
            this.content = content;
        }

    }
}
