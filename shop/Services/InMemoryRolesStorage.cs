using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryRolesStorage : IRolesStorage
    {
        private readonly List<Role> _roles =
        [
            new Role() { Name = "Admin" }
        ];

        public void Add(Role role)
        {
            _roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return _roles;
        }

        public Role? GetByName(string name)
        {
            return _roles.FirstOrDefault(role => role.Name == name);
        }

        public void Remove(Role role)
        {
            _roles.Remove(role);
        }
    }
}