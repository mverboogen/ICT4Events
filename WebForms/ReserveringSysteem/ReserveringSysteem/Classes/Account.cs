namespace ReserveringSysteem
{
    public class Account
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public Account(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }
    }
}