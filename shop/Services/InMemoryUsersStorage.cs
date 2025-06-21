using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryUsersStorage : IUsersStorage
    {
        private readonly List<User> _users =
        [
            new User()
            {
                Id = Guid.NewGuid(),
                Login = "User666",
                Email = "user666@gmail.com",
                Password = "12345",
                ConfirmPassword = "12345"
            }
        ];

        public void Add(User user)
        {
            _users.Add(user);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }

        public User? Get(Auth auth)
        {
            return _users.FirstOrDefault(user => user.Password == auth.Password && user.Login == auth.Login);
        }
    }
}