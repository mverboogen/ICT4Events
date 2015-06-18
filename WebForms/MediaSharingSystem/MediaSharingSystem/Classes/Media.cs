using System;
using System.Collections.Generic;

namespace MediaSharingSystem
{
    public class Media
    {
        public int ID { get; set; }
        public User Author { get; set; }
        public DateTime PostDate { get; set; }

        public int LikeCount
        {
            get { return DatabaseHandler.GetInstance().DownloadLikes(ID); }
        }

        public int ReportCount
        {
            get { return DatabaseHandler.GetInstance().DownloadReports(ID); }
        }

        public string Title { get; set; }

        public Media(int id, User author, string title)
        {
            ID = id;
            Author = author;
            Title = title;
        }

        public List<Comment> GetComments()
        {
            return null;
        }

        /// <summary>
        ///     Checks if this post has been liked by the given user.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>True if the given user has liked this post.</returns>
        public bool LikedBy(int userid)
        {
            return DatabaseHandler.GetInstance().LikedBy(userid, ID);
        }

        /// <summary>
        ///     Checks if this post has been reported by the given user.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>True if the given user has reported this post.</returns>
        public bool ReportedBy(int userid)
        {
            return DatabaseHandler.GetInstance().ReportedBy(userid, ID);
        }
    }
}