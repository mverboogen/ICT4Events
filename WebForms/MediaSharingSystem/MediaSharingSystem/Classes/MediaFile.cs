namespace MediaSharingSystem
{
    public class MediaFile : Media
    {
        public readonly int CategoryID;
        public string FilePath { get; set; }
        public float FileSize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MediaFile(int id, int categorieID, User author, string title, string filePath) : base(id, author, title)
        {
            FilePath = filePath;
            CategoryID = categorieID;
        }
    }
}