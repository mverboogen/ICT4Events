using System;
using System.Collections.Generic;

namespace EventBeheerSysteem
{
    public class Item
    {
        private List<string> categorie;
        private List<Booker> renterList = new List<Booker>();
        public int ID { get; set; }

        public string Name
        {
            get { return Brand + " " + Serie; }
        }

        public int MainCatID { get; set; }

        public List<string> Categorie
        {
            get
            {
                if (categorie == null)
                {
                    categorie = new List<string>();
                }
                return categorie;
            }
            set { categorie = value; }
        }

        public string Brand { get; set; }
        public string Serie { get; set; }
        public int TypeNumber { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public int Amount { get; set; }
        public int Available { get; set; }
        public bool Payed { get; set; }
        public int InstanceNumber { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        public List<Booker> RenterList
        {
            get { return renterList; }
            set
            {
                if (renterList == null && value == null)
                {
                    renterList = new List<Booker>();
                }
                renterList = value;
            }
        }

        public Item()
        {
        }

        public Item(string brand, string serie, decimal price, int catID)
        {
            Brand = brand;
            Serie = serie;
            Price = price;
            MainCatID = catID;
        }
    }
}