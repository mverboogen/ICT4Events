using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class Comment
    {
        private int userID;
        private int likes;
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

    }
}
