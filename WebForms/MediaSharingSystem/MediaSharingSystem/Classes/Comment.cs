namespace MediaSharingSystem
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }

        public Comment(int id, string comment)
        {
            ID = id;
            Content = comment;
        }
    }
}