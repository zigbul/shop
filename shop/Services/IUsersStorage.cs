using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IUsersStorage
    {
        void Add(User user);

        void Remove(User user);

        List<User> GetAll();

        User? Get(Auth auth);

        User? GetById(Guid id);
    }
}
