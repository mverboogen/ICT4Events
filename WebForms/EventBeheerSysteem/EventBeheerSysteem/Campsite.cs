namespace EventBeheerSysteem
{
    public class Campsite
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public bool Comfort { get; set; }
        public int XCor { get; set; }
        public int YCor { get; set; }
        public bool Crane { get; set; }
        public bool Handicap { get; set; }
        public int LocationID { get; set; }
        public Booker CampsiteBooker { get; set; }

        public Campsite()
        {
        }

        public Campsite(int id, string name)
        {
            ID = id;
        }

        public Campsite(int id, int number, string name, int capacity, decimal price)
        {
            ID = id;
            Number = number;
            Capacity = capacity;
            Price = price;
        }

        public Campsite(int capacity, bool comfort, bool handicap, int size, bool crane, int xCor, int yCor)
        {
            Capacity = capacity;
            Comfort = comfort;
            Handicap = handicap;
            Size = size;
            Crane = crane;
            XCor = xCor;
            YCor = yCor;
        }
    }
}