using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class ReportData : IComparable
    {
        private int reportID;
        private int mediaID;
        private int userID;

        public int ReportID
        {
            get { return reportID; }
        }

        public int MediaID
        {
            get { return mediaID; }
        }

        public int UserID
        {
            get { return userID; }
        }

        public ReportData(int reportid, int mediaid, int userid)
        {
            reportID = reportid;
            mediaID = mediaid;
            userID = userid;
        }


        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
