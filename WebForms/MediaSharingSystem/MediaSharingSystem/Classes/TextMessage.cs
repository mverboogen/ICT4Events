namespace MediaSharingSystem
{
    public class TextMessage : Media
    {
        public string Content { get; set; }

        public TextMessage(int id, User author, string title, string content) : base(id, author, title)
        {
            Content = content;
        }
    }
}