using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IOrdersStorage
    {
        void Add(Cart cart);
    }
}