namespace MediaSharingSystem
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public User(int id, string username, string email)
        {
            ID = id;
            Username = username;
            Email = email;
        }
    }
}