using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class LikeData
    {
        private int likeID;
        private int mediaID;
        private int commentID;
        private int userID;

        public int LikeID
        {
            get { return likeID; }
        }

        public int MediaID
        {
            get { return mediaID; }
        }

        public int CommentID
        {
            get { return commentID; }
        }

        public int UserID
        {
            get { return userID; }
        }

        public LikeData(int likeid, int mediaid, int commentid, int userid)
        {
            likeID = likeid;
            mediaID = mediaid;
            commentID = commentid;
            userID = userid;
        }

    }
}
