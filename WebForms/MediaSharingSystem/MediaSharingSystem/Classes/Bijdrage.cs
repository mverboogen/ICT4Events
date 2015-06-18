using System;

namespace MediaSharingSystem
{
    public class Bijdrage
    {
        public readonly int ID;
        public readonly int UserID;
        public DateTime Date { get; set; }
        public string Soort { get; set; }

        public Bijdrage(int id, int userID, DateTime date, string soort)
        {
            ID = id;
            UserID = userID;
            Date = date;
            Soort = soort;
        }
    }
}