namespace EventBeheerSysteem
{
    public class Categorie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SubID { get; set; }
        public Categorie SubCategorie { get; set; }

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