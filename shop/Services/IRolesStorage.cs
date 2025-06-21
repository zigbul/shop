using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IRolesStorage
    {
        List<Role> GetAll();

        Role? GetByName(string name);

        void Remove(Role role);

        void Add(Role role);
    }
}
