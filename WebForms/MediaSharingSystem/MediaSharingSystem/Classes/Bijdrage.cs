using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaSharingSystem
{
    public class Bijdrage
    {

        public readonly int ID;
        public readonly int UserID;
        public DateTime Date { get; set; }
        public string Soort { get; set; }

        public Bijdrage(int id, int userid, DateTime date, string soort)
        {
            ID = id;
            UserID = userid;
            Date = date;
            Soort = soort;
        }

    }
}