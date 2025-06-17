using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IOrdersStorage
    {
        void Add(Order order);

        List<Order> GetAll();

        Order? TryGetById(int id);
    }
}