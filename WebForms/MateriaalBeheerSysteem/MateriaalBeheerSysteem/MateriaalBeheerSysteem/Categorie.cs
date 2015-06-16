using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateriaalBeheerSysteem
{
    public class Categorie
    {
        private int id;
        private string name;
        private int subID;
        private Categorie subCategorie;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int SubID
        {
            get { return subID; }
            set { subID = value; }
        }

        public Categorie SubCategorie
        {
            get { return subCategorie; }
            set { subCategorie = value; }
        }

        public Categorie()
        {

        }

        public Categorie(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Categorie(int id, string name, int subID, Categorie subCategorie)
        {
            ID = id;
            Name = name;
            SubID = subID;
            SubCategorie = subCategorie;
        }
    }
}