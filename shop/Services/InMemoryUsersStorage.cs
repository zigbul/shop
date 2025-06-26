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

        private Guid _currentUserId;

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
            var user = _users.FirstOrDefault(user => user.Password == auth.Password && user.Login == auth.Login);

            if (user != null)
            {
                _currentUserId = user.Id;
            }

            return user;
        }

        public User? GetById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public Guid GetCurrentUserId()
        {
            return _currentUserId;
        }
    }
}