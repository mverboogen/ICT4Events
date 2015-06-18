namespace EventBeheerSysteem
{
    public class Booker
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Inlas { get; set; }
        public string Surname { get; set; }

        public string Name
        {
            get { return Inlas != null ? Inlas + " " : "" + Surname + ", " + Firstname.Substring(0, 1); }
        }

        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string BankAccount { get; set; }
    }
}