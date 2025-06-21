using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IRolesStorage
    {
        List<Role> GetAll();

        Role? TryGetByName(string name);

        void Remove(Role role);

        void Add(Role role);
    }
}
