namespace ReserveringSysteem
{
    public class Account
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Hash { get; set; }

        public Account(string username, string email, string hash)
        {
            this.Username = username;
            this.Email = email;
            this.Hash = hash;
        }
    }
}