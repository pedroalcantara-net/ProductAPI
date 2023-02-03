namespace Products.Domain.Entities
{
    public class User
    {
        public User(string username, string password) => (Id, Username, Password) = (0, username, password);

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
