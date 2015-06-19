using System.Collections.Generic;

namespace ReserveringSysteem
{
    public class Item
    {
        private List<string> categorie;
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public int Volgnummer { get; set; }
        public int Barcode { get; set; }
        public int Amount { get; set; }
        public int CatId { get; set; }

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

        public Item()
        {
        }

        public Item(int id)
        {
            Id = id;
        }

        public Item(int id, string brand, string serie, int number, decimal price)
        {
            Id = id;
            Brand = brand;
            Serie = serie;
            Number = number;
            Price = price;
        }

        public override string ToString()
        {
            return "ID: " + Id + "  -  Merk: " + Brand + "  -  Serie: " + Serie + "  -  Prijs: " + Price;
        }
    }
}