namespace ReserveringSysteem
{
    public class Campsite
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public bool Comfort { get; set; }
        public int XCor { get; set; }
        public int YCor { get; set; }
        public bool Crane { get; set; }
        public bool Handicap { get; set; }

        public Campsite()
        {
        }

        public Campsite(int id)
        {
            this.Id = id;
        }

        public Campsite(int id, int number, int capacity, decimal price)
        {
            this.Id = id;
            this.Number = number;
            this.Capacity = capacity;
            this.Price = price;
        }

        public override string ToString()
        {
            return "ID: " + Id + "  -  Nummer: " + Number + "  -  Aantal personen: " + Capacity + "  -  Grootte: " +
                   Size + "  -  Comfort: " + Comfort + "  - Heeft kraan: " + Crane + "  -  Handicap: " + Handicap;
        }
    }
}