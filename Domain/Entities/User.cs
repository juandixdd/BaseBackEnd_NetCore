namespace BaseBackend.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private User() { }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
