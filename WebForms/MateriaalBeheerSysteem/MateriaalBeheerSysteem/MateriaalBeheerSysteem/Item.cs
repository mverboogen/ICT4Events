using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateriaalBeheerSysteem
{
    public class Item
    {
        private int id;
        private List<string> categorie;
        private int mainCatID;
        private string brand;
        private string serie;
        private int typeNumber;
        private decimal price;
        private string barcode;
        private int amount;
        private int available;
        private List<Booker> renterList = new List<Booker>();

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return brand + " " + serie; }
        }

        public int MainCatID
        {
            get { return mainCatID; }
            set { mainCatID = value; }
        }

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

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public int TypeNumber
        {
            get { return typeNumber; }
            set { typeNumber = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        
        public int Available
        {
            get { return available; }
            set { available = value; }
        }

        public List<Booker> RenterList
        {
            get { return renterList; }
            set
            {
                if(renterList == null && value == null)
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
            mainCatID = catID;
        }
    }
}