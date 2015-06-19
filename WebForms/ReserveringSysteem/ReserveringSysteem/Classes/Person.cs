namespace ReserveringSysteem
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Bank { get; set; }

        public Person(string firstname, string insertion, string lastname, string street, string adress, string city,
            string bank)
        {
            this.Firstname = firstname;
            this.Insertion = insertion;
            this.Lastname = lastname;
            this.Street = street;
            this.Adress = adress;
            this.City = city;
            this.Bank = bank;
        }
    }
}