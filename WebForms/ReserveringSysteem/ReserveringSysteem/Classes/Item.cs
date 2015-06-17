using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReserveringSysteem
{
    public class Item
    {
        private int id;
        private string brand;
        private string serie;
        private int number;
        private decimal price;
        private int volgnummer;
        private int barcode;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Volgnummer
        {
            get { return volgnummer; }
            set { volgnummer = value; }
        }

        public int Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public Item(int id)
        {
            this.id = id;
        }

        public Item(int id, string brand, string serie, int number, decimal price)
        {
            this.id = id;
            this.brand = brand;
            this.serie = serie;
            this.number = number;
            this.price = price;
        }

        public override string ToString()
        {
            return brand + serie + price.ToString();
        }
    }
}