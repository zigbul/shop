using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryOrdersStorage : IOrdersStorage
    {
        private List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            _orders.Add(order);
        }
    }
}
